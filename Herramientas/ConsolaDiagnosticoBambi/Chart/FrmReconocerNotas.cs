using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Registrador_FFT
{

    public partial class FrmReconocerNotas : Form
    {        
        public enum Id_Nota_t{NOTA_INDEFINIDA, C2, D2, E2, F2, G3 };
        //Global variables use 967 bytes (47%) of dynamic memory, leaving 1.081 bytes for local variables. Maximum is 2.048 bytes.
        //Constantes de Filtros
        
        private const uint FILTRO_REPETICION_RESET = 6;       //Al alcanzar este valor de repeticion de NOTAS_INDEFINIDAS, el contador de notas se resetea (cuanto mas alto, mas permisivo). Para desactivar asignar 255 como max.
        private const uint CONDICION_MAXIMO_FUNDAMENTAL = 17; //Para desactivar, asignar 1
        private const uint CONDICION_MAXIMO_SOBRETONO = 11;   //Para desactivar, asignar 1

        private const int UMBRAL_FILTRO_FUNDAMENTAL = 45;
        private const int CONDICION_MAXIMO = 1;//20;
        //enum Id_Nota_t{ INEXISTENTE, C2, D2, E2, F2, G3 };

        private struct Nota_t
        {
            public Id_Nota_t Id;
            public uint F0;
            public uint F1;
            public uint UMBRAL_F0;    //Umbral Filtro para la fundamental.
            public uint UMBRAL_F1;    //Umbral Filtro para el 1er sobretono.
            public uint DURACION;
        };

        const uint CANTIDAD_NOTAS = 5;
        //F0=Frecuencia Fundamental/Resolucion   F1=Sobretono elegido / Resolucion
        //private Nota_t[] mNotas = new Nota_t[] {
        //    new Nota_t {Id = Id_Nota_t.C2, F0 = 2050/50, F1 = 5550/50, UMBRAL_F0 = 93, UMBRAL_F1 = 79, DURACION=3}, 
        //    new Nota_t {Id = Id_Nota_t.D2, F0 = 2300/50, F1 = 6200/50, UMBRAL_F0 = 75, UMBRAL_F1 = 45, DURACION=2},
        //    new Nota_t {Id = Id_Nota_t.E2, F0 = 2600/50, F1 = 5800/50, UMBRAL_F0 = 75, UMBRAL_F1 = 45, DURACION=2},
        //    new Nota_t {Id = Id_Nota_t.F2, F0 = 2750/50, F1 = 5450/50, UMBRAL_F0 = 55, UMBRAL_F1 = 10, DURACION=2},   //5450ex3200
        //    new Nota_t {Id = Id_Nota_t.G3, F0 = 3100/50, F1 = 3500/50, UMBRAL_F0 = 85, UMBRAL_F1 = 60, DURACION=3}
        //};
        //Lineal
        private Nota_t[] mNotas = new Nota_t[] {
            new Nota_t {Id = Id_Nota_t.C2, F0 = 2050/50, F1 = 5550/50, UMBRAL_F0 = 93, UMBRAL_F1 = 70, DURACION=2}, 
            new Nota_t {Id = Id_Nota_t.D2, F0 = 2300/50, F1 = 6200/50, UMBRAL_F0 = 75, UMBRAL_F1 = 50, DURACION=2},
            new Nota_t {Id = Id_Nota_t.E2, F0 = 2600/50, F1 = 5800/50, UMBRAL_F0 = 75, UMBRAL_F1 = 30, DURACION=2},
            new Nota_t {Id = Id_Nota_t.F2, F0 = 2750/50, F1 = 5450/50, UMBRAL_F0 = 55, UMBRAL_F1 = 10, DURACION=2},   //5450ex3200
            new Nota_t {Id = Id_Nota_t.G3, F0 = 3100/50, F1 = 3500/50, UMBRAL_F0 = 85, UMBRAL_F1 = 60, DURACION=3}
        };

        private uint[] fht_log_out = new uint[128];


        //Retorna la nota que reconoció. Devuelve 0 si no reconoció ninguna.
        public Id_Nota_t EscucharNotas(List<uint> byteArray)
        {
            //EjecutarFFT();
            fht_log_out = byteArray.ToArray();
            Id_Nota_t nota_escuchada = BuscarNotas();

            switch (nota_escuchada)
            {
                case Id_Nota_t.C2: ConsolePrintLn("#C2"); break;
                case Id_Nota_t.D2: ConsolePrintLn("#D2"); break;
                case Id_Nota_t.E2: ConsolePrintLn("#E2"); break;
                case Id_Nota_t.F2: ConsolePrintLn("#F2"); break;
                case Id_Nota_t.G3: ConsolePrintLn("#G3"); break;
            }
            return nota_escuchada;
        }


        Id_Nota_t mIdNotaAnterior = Id_Nota_t.NOTA_INDEFINIDA;
        uint mRepeticionesNotas = 1;
        uint mRepeticionesNotaIndefinida = 1;

        //!!!!Cambiar en el prog de Arduino uint8_t por Id_Nota_t
        Id_Nota_t BuscarNotas()
        {
            Id_Nota_t nota_encontrada = Id_Nota_t.NOTA_INDEFINIDA;
            uint intensidad_nota = 0;
            uint intensidad_max = 0;
            uint filtro_repeticion_notas = 100;

            for (int i = 0; i < CANTIDAD_NOTAS; i++)
            {
                if (FrecuenciaEsMaximo(mNotas[i].F0, mNotas[i].UMBRAL_F0) &&
                    FrecuenciaEsMaximo(mNotas[i].F1, mNotas[i].UMBRAL_F1))
                {
                    switch (mNotas[i].Id)
                    {
                        case Id_Nota_t.C2: ConsolePrintLn("C2"); break;
                        case Id_Nota_t.D2: ConsolePrintLn("D2"); break;
                        case Id_Nota_t.E2: ConsolePrintLn("E2"); break;
                        case Id_Nota_t.F2: ConsolePrintLn("F2"); break;
                        case Id_Nota_t.G3: ConsolePrintLn("G3"); break;
                    }
                    intensidad_nota = fht_log_out[mNotas[i].F0] / 2 + fht_log_out[mNotas[i].F1] / 4;  //GetIntensidadNota(&mNotas[i]);
                    if (intensidad_nota > intensidad_max)
                    {
                        intensidad_max = intensidad_nota;       //Me quedo con la nota de mayor intensidad.
                        nota_encontrada = mNotas[i].Id;         //
                        filtro_repeticion_notas = mNotas[i].DURACION;
                    }
                }
            }

            if (nota_encontrada == Id_Nota_t.NOTA_INDEFINIDA)
            {
                mRepeticionesNotaIndefinida++;
                if (mRepeticionesNotaIndefinida == FILTRO_REPETICION_RESET)
                {
                    mRepeticionesNotas = 0;           //Reseteo el contador de notas encontradas
                    mRepeticionesNotaIndefinida = 0;  //Reseteo el contador de Indefinidas
                }
            }
            else
            {
                mRepeticionesNotaIndefinida = 0;  //Reseteo el contador de notas indefinidas
                if (nota_encontrada == mIdNotaAnterior)
                    mRepeticionesNotas++;           //Se repitio la nota anterior
                else
                    mRepeticionesNotas = 1;         //Reseteo el contador de repeticiones
                mIdNotaAnterior = nota_encontrada;
            }

            //Si se repitio el nro suficiente de veces, la doy como buena.
            if (mRepeticionesNotas == filtro_repeticion_notas)
            {
                mRepeticionesNotas = 0;
                return nota_encontrada;
            }
            else
                return Id_Nota_t.NOTA_INDEFINIDA;     //Si no, no la reconozco.
        }


        bool FrecuenciaEsMaximo(uint frecuencia, uint umbralDeteccion)
        {
            uint valor_actual = fht_log_out[frecuencia];
            uint valor_anterior = fht_log_out[frecuencia - 1];
            uint valor_posterior = fht_log_out[frecuencia + 1];
            uint valor_ante_anterior = fht_log_out[frecuencia - 2];
            uint valor_pos_posterior = fht_log_out[frecuencia + 2];
            bool es_maximo = false;

            if (valor_actual < umbralDeteccion) return false;

            //Primera condición de Maximo.
            if ((valor_actual > valor_anterior) && (valor_actual > valor_posterior))
            {
                if (valor_actual >= valor_ante_anterior + CONDICION_MAXIMO_FUNDAMENTAL &&
                     valor_actual >= valor_pos_posterior + CONDICION_MAXIMO_FUNDAMENTAL)
                {
                    es_maximo = true;
                }
                else
                    es_maximo = false;
            }

            //2da condición de maximos. Contempla las "puntas cuadradas" que no son captadas por la otra condicion
            if (valor_actual == valor_anterior && valor_actual > valor_posterior)
                es_maximo = true;

            return es_maximo;
        }


        delegate void SetGraphCallback(string msje);

        void ConsolePrintLn(string msje)
        {
            if (this.listBoxSalida.InvokeRequired)
            {
                SetGraphCallback d = new SetGraphCallback(ConsolePrintLn);
                this.BeginInvoke(d, new object[] { msje });
            }
            else
            {
                listBoxSalida.Items.Add(msje);
                listBoxSalida.SelectedIndex = listBoxSalida.Items.Count - 1;
            }
        }








        List<int> mTramaBytes;
        long mContadorNotasReconocidas;
        public FrmReconocerNotas()
        {
            InitializeComponent();
            List<int> tramaBytes = new List<int>();
        }

        List<Nota_t> mNotasEncontradas;
        Id_Nota_t mNotaAnterior = 0;

        public void BuscarNotas(List<int> tramaBytes) {

            mTramaBytes = tramaBytes;
            mNotasEncontradas = new List<Nota_t>();
            Boolean notaEncontrada = false;

            //for (int i=0; i<5; i++)
            //{
            //    if (FrecuenciaEsMaximo(notas[i].F0) && FrecuenciaEsMaximo(notas[i].F1))
            //    {
            //        notaEncontrada = true;
            //        mContadorNotasReconocidas++;
            //        notas[i].Intensidad = notas[i].F0 * 2 + notas[i].F1;
            //        mNotasEncontradas.Add(notas[i]);
            //        mNotaAnterior = notas[i].Id;
            //        txtSalida.Text += mContadorNotasReconocidas + " - " + notas[i].Id.ToString() + "\r\n";
            //    }
            //    if (!notaEncontrada) mNotaAnterior = Id_Nota_t.INEXISTENTE;
            //}

            //txtSalida.SelectionStart = txtSalida.TextLength;
            //txtSalida.ScrollToCaret();
        }


        public bool FrecuenciaEsMaximo(int F0) {
            if (mTramaBytes[F0] < UMBRAL_FILTRO_FUNDAMENTAL) return false;

            if ((mTramaBytes[F0] > mTramaBytes[F0 - 1]) && (mTramaBytes[F0] > mTramaBytes[F0 + 1]))
            {
                //if ((mTramaBytes[F0] - mTramaBytes[F0 - 1]) > CONDICION_MAXIMO)
                    return true;
            }
            else
                return false;
        }



/*
        int mContadorNotasReconocidas = 0;

        public void BuscarNotas(List<DataPoint> listaMaximos)
        {
            int valorParse;

            foreach (DataPoint punto in listaMaximos)
            {
                if (int.TryParse(F0_1.Text, out valorParse))
                {
                    if (punto.XValue == valorParse)
                    {
                        mContadorNotasReconocidas++;
                        txtSalida.Text += mContadorNotasReconocidas + " - " + txtNombre1.Text + "\r\n";
                    }
                }

                if (int.TryParse(F0_2.Text, out valorParse))
                {
                    if (punto.XValue == valorParse)
                    {
                        mContadorNotasReconocidas++;
                        txtSalida.Text += mContadorNotasReconocidas + " - " + txtNombre2.Text + "\r\n";
                    }
                }

                if (int.TryParse(F0_3.Text, out valorParse))
                {
                    if (punto.XValue == valorParse)
                    {
                        mContadorNotasReconocidas++;
                        txtSalida.Text += mContadorNotasReconocidas + " - " + txtNombre3.Text + "\r\n";
                    }
                }
            }
            txtSalida.SelectionStart = txtSalida.TextLength;
            txtSalida.ScrollToCaret();
        }
        */


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            listBoxSalida.Items.Clear();
        }
    }
}
