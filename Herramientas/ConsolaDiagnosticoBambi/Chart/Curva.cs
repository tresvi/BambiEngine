using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Registrador_FFT
{
    public static class Curva
    {
        //const Single FACTOR_ESCALA_X = 151;       //Clock 16Mhz 0-19Khz
        //const Single FACTOR_ESCALA_X = 173.5F;      //Clock 18.432Mhz 0-22Khz
        //const Single FACTOR_ESCALA_X = 19.82F;      //Creo que para 18Mhz 0-2500 Hz
        //const Single FACTOR_ESCALA_X = 38.4F;      //Para clock 16Mhz 0-5000 Hz
        //const Single FACTOR_ESCALA_X = 57F;     //60.8F/ //Para clock 16Mhz 0-8000 Hz
        const Single FACTOR_ESCALA_X = 50F;     //60.8F/ //Para clock 16Mhz 0-8000 Hz
        const int CANTIDAD_PUNTOS = 20000;


        public static List<DataPoint> CrearLogaritmica(List<uint> tramaBytes, bool aplicarFiltrado, uint umbralFiltro, uint profundidad)
        {
            Double valorY = 0;
            DataPoint punto;
            List<DataPoint> listaPuntos = new List<DataPoint>();

            //Recorro la trama
            for (int i = 0; i < tramaBytes.Count; i++)
            {
                if (aplicarFiltrado)
                    valorY = AplicarFiltro(tramaBytes[i], umbralFiltro, profundidad);
                else
                    valorY = tramaBytes[i];

                punto = new DataPoint(ConvertirNroMuestraEnFrecuencia(i), valorY);
                listaPuntos.Add(punto);
            }
            return listaPuntos;
        }


        public static List<DataPoint> CrearLineal(List<uint> tramaBytes, bool aplicarFiltrado, uint umbralFiltro, uint profundidad, bool expresarValorPicoAPico)
        {
            Double valorY = 0;
            DataPoint punto;
            List<DataPoint> listaPuntos = new List<DataPoint>();

            //Recorro la trama
            for (int i = 0; i < tramaBytes.Count; i++)
            {
                if (aplicarFiltrado)
                    valorY = AplicarFiltro(tramaBytes[i], umbralFiltro, profundidad);  //Si se aplica el filtrado, se lo aplico al valor log.
                else
                    valorY = tramaBytes[i];  //Si se aplica el filtrado, se lo aplico al valor log.

                valorY = GetCoeficienteAmplitud(valorY);
                if (expresarValorPicoAPico) valorY *= 2;
                punto = new DataPoint(ConvertirNroMuestraEnFrecuencia(i), valorY);
                listaPuntos.Add(punto);
            }
            return listaPuntos;
        }


        //public static List<DataPoint> ReconstruirSenal2(List<DataPoint> listaCoficientes, Filtro filtro)
        //{
        //    List<DataPoint> listaPuntos = new List<DataPoint>();

        //    double y = 0;
        //    const double offset = 2.5;
        //    double fIn;
        //    double angulo;
        //    double fase = 0;
        //    double amplitud = 0;

        //    for (int i = 0; i <= CANTIDAD_PUNTOS; i += 10)
        //    {
        //        angulo = 3.14 * i / 180;
        //        y = offset;
        //        for (int j = 0; j < listaCoficientes.Count; j++)
        //        {
        //            if (listaCoficientes[j].YValues[0] != 0)
        //            {
        //                amplitud = listaCoficientes[j].YValues[0];
        //                fIn = listaCoficientes[j].XValue;

        //                if (filtro.FPBEnable)
        //                    if (fIn >= filtro.FPB_FCorte) amplitud = 0;
        //                if (filtro.FPAEnable)
        //                    if (fIn <= filtro.FPA_FCorte) amplitud = 0;
        //                if (filtro.FPBandaEnable)
        //                    if (fIn < filtro.FPBanda_F1 || fIn > filtro.FPBanda_F2) amplitud = 0;

        //                //v(t)= A.sen(wt + fi)
        //                y += amplitud * Math.Sin(angulo * GetCoeficienteFrecuencia(fIn) + fase); 
        //            }
        //        }
        //        DataPoint punto = new DataPoint(i, y);
        //        listaPuntos.Add(punto);
        //    }
        //    return listaPuntos;
        //}



        // Linealizar el valor logaritmico obtenido del micro
        static double GetCoeficienteAmplitud(double valor)
        {
            return  Math.Exp((valor - 186.04) / 23); //.027); 
        }

        private const double F_MIN = 39;//20;//172;
        static double GetCoeficienteFrecuencia(double fIn)
        {
            return fIn * 2 * 180 / (F_MIN * 20000);//0.000105 * frecuencia; //El 7 es para convertir la escala a 2500Hz
        }


        static int ConvertirNroMuestraEnFrecuencia(int nroMuestra)
        {
            return (int)(FACTOR_ESCALA_X * nroMuestra);
            //return (int)(nroMuestra);
        }

        static uint AplicarFiltro(uint valor, uint umbralFiltro, uint profundidad)
        {
            return (valor > umbralFiltro ? valor : valor / profundidad);
        }


        /// <summary>
        /// Recibe una curva en un DataPointCollection, y devuelve una lista de los puntos máximos en ella.
        /// </summary>
        public static List<DataPoint> CalcularMaximos(List<DataPoint> listaPuntos, double umbral_maximos, Chart barrasChart)
        {
            //List<DataPoint> maximos = new List<DataPoint>();
            List<DataPoint> maximos = new List<DataPoint>();
            double valorAnterior;
            double valorActual;
            double valorPosterior;
            DataPoint punto;
            List<DataPoint> barras = new List<DataPoint>();

            for (int i = 0; i < listaPuntos.Count; i++)
            {
                punto = null;

                if (listaPuntos[i].YValues[0] > umbral_maximos)
                {
                    if (i > 0 && i < (listaPuntos.Count - 1))
                    {
                        valorAnterior = listaPuntos[i - 1].YValues[0];
                        valorActual = listaPuntos[i].YValues[0];
                        valorPosterior = listaPuntos[i + 1].YValues[0];

                        //Condicion para Detectar los máximos
                        if (valorActual > valorAnterior && valorActual > valorPosterior)
                        {
                            maximos.Add(listaPuntos[i]);
                            punto = new DataPoint(listaPuntos[i].XValue, valorActual);
                        }

                        //2da condición de maximos. Contempla las "puntas cuadradas" que no son captadas por la otra condicion
                        if (valorActual == valorAnterior && valorActual > valorPosterior)
                        {
                            maximos.Add(listaPuntos[i]);
                            punto = new DataPoint(listaPuntos[i].XValue, valorActual);
                        }
                    }
                }

                if (punto == null) punto = new DataPoint(listaPuntos[i].XValue, 0);
                barras.Add(punto);
                //promedio += punto.YValues[0];
            }

            //Muestro los máximos si es que se habilitó esta función
            //if (chkMostrarMaximos.Checked)
            //{
            //    String cadenaMaximos = "";
            //    for (int i = 0; i < maximos.Count; i++)
            //    {
            //        cadenaMaximos = cadenaMaximos + maximos[i].XValue.ToString() + "->" + maximos[i].YValues[0].ToString() + "///";
            //    }
            //    txtLogInput.Text += cadenaMaximos + "\r\n";//maximos[1].ToString();
            //}
            Series serieMaximos = new Series("Maximos");
            foreach (DataPoint punto2 in barras)
            {
                serieMaximos.Points.Add(punto2);
            }

            serieMaximos.Color = System.Drawing.Color.Red;
            //!!!!!! se comenta para evitar Cross-Thread barrasChart.Series["Maximos"] = serieMaximos;    //Muestro el gráfico que acaba de finalizar.
            serieMaximos = new Series("Maximos");
            serieMaximos.ChartType = SeriesChartType.Bar;
            serieMaximos.BorderWidth = 3;

            return maximos;
        }

    }
}
