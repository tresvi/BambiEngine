using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Registrador_FFT
{
    partial class FrmMain
    {
        private void EnableCommandControls(bool enable)
        {
            btnSensoresDist.Enabled = enable;
            btnReconocNotas.Enabled = enable;
            btnReset.Enabled = enable;
            btnSendCommand.Enabled = enable;
            txtCommand.Enabled = enable;
            gbNavegacion.Enabled = enable;
            txtCommand.Enabled = enable;
            btnContadorDeambulaciones.Enabled = enable;
            btnResetContDeambulacion.Enabled = enable;
        }


        delegate void SetGraphCallback(int value);

        private void DibujarGrafico(int value)
        {
            try
            {
                if (this.chartEspectro.InvokeRequired)
                {
                    SetGraphCallback d = new SetGraphCallback(DibujarGrafico);
                    this.Invoke(d, new object[] { value });
                }
                else
                    chartEspectro.Series["Muestras"] = _graphSerie;    //Muestro el gráfico que acaba de finalizar.
            }
            catch { }
        }


        delegate void SetAddLogSerieCallback(string msje);

        private void PrintMessage(string msje)
        {
            if (this.txtLog.InvokeRequired)
            {
                SetAddLogSerieCallback d = new SetAddLogSerieCallback(PrintMessage);
                this.Invoke(d, new object[] { msje });
            }
            else
            {
                txtLog.Text += msje;
                txtLog.ScrollToCaret();
                txtLog.SelectionStart = txtLog.Text.Length;
                txtLog.ScrollToCaret();
                txtLog.Refresh();
            }
        }




        private void Graficar(List<uint> tramaBytes)
        {
            //Creo la nueva serie de datos.
            _graphSerie = new Series("Muestras");
            _graphSerie.Color = System.Drawing.Color.Green;
            _graphSerie.ChartType = SeriesChartType.Column; //SeriesChartType.Line;
            _graphSerie.BorderWidth = 2;

            List<DataPoint> listaMaximos = null;
            List<DataPoint> curva;

            curva = Curva.CrearLogaritmica(tramaBytes, false, 0, 0);
            CargarCurvaEnGrafico(curva);

            ReconocerMaximos(listaMaximos);
            DibujarGrafico(0);                 //Muestro el gráfico que acaba de finalizar.
        }


        void CargarCurvaEnGrafico(List<DataPoint> listaPuntos)
        {
            foreach (DataPoint punto in listaPuntos)
            {
                _graphSerie.Points.Add(punto);
            }
        }


        FrmReconocerNotas mFormReconocerNotas;
        FrmReconocerNotasAVG mFormReconocerNotasAVG;
        void ReconocerMaximos(List<DataPoint> listaMaximos)
        {
            if (mFormReconocerNotas == null) return;
            //mReconocerNotas.BuscarNotas(listaMaximos);
            //mReconocerNotas.BuscarNotas(mTramaBytes);

        }


        private void DataCommandRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            PrintMessage(_serial.ReadExisting());
        }


        private void DataPlotRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            while (_serial.BytesToRead >= DATAFRAME_WIDTH)
            {
                byte[] frameBuffer = new byte[DATAFRAME_WIDTH];
                if (_serial.ReadByte() == 255) _serial.Read(frameBuffer, 0, DATAFRAME_WIDTH - 1);
                _dataFrameBuffer.Enqueue(frameBuffer);

                List<uint> byteArray = _dataFrameBuffer.Dequeue().Select(x => (uint)x).ToList();
                Graficar(byteArray);
            }
        }

        private bool SendCommand(BambiCommands command)
        {
            try
            {
                _serial.Write(((char)command).ToString());
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error al enviar el comando. Revise que el dispositivo esté conectado. Detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SendCommand(string command)
        {
            try
            {
                _serial.Write(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error al enviar el comando. Detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SendReset()
        {
            try
            {
                _serial.DtrEnable = true;
                Thread.Sleep(10);
                _serial.DtrEnable = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error al enviar el comando. Detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
