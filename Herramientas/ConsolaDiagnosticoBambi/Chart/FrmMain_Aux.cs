using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private void PrintFPS(string msje)
        {
            if (this.lblFPS.InvokeRequired)
            {
                SetAddLogSerieCallback d = new SetAddLogSerieCallback(PrintFPS);
                this.Invoke(d, new object[] { msje });
            }
            else
                lblFPS.Text = msje;
        }
        

        private void Graficar(List<uint> muestras)
        {
            //Creo la nueva serie de datos.
            _graphSerie = new Series("Muestras");
            _graphSerie.Color = System.Drawing.Color.Green;
            _graphSerie.ChartType = SeriesChartType.Column; //SeriesChartType.Line;
            _graphSerie.BorderWidth = 1; //2;
            chartEspectro.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            List<DataPoint> listaMaximos = null;
            List<DataPoint> curva;

            curva = Curva.CrearLogaritmica(muestras, false, 0, 0);
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


        private void DataCommandReceived(object sender, SerialDataReceivedEventArgs e)
        {
            PrintMessage(_serial.ReadExisting());
        }

        
        private void DataPlotRecieved_Arduino(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                while (_serial.BytesToRead >= ARDUINO_SAMPLES_PER_DATAFRAME)
                {
                    if (_serial.ReadByte() == 255)
                    {
                        byte[] frameBuffer = new byte[ARDUINO_SAMPLES_PER_DATAFRAME];
                        _serial.Read(frameBuffer, 0, ARDUINO_SAMPLES_PER_DATAFRAME);                //Leo la trama completa
                        _samplesBuffer.Enqueue(frameBuffer.Select(x => (uint)x).ToList());    //Convierto el byte[] a lista de uint y lo vuelco en la cola
                    }
                    
                    if (_samplesBuffer.Count != 0)
                    {
                        Graficar(_samplesBuffer.Dequeue());   //Tomo un valor de la cola buffer y lo grafico
                        ContarFPS();
                    }
                }
            }
            catch { }
        }



        byte[] _frameBuffer = new byte[ESP32_SAMPLES_PER_DATAFRAME * ESP32_BYTES_PER_SAMPLE];

        //El try no afecta a la velocidad de resolucion
        //Valores con rutina en ESP 32 de alta velocidad, es decir, la del array con valores en rampa precargados
        //y transmitidos con Serial.write(array, 2048)), que es la que demostro por lejos ser la de mayor eficiencia,
        //mucho mas que la de transmitir byte por byte:
        //921600: 45 FPS
        //460800: 23 FPS
        //230400: 13 FPS
        //115200: 6  FPS

        //Prueba de SPS
        //460800: 141-144 SPS
        //230400: 86-89
        //115200: 44-46
        private void DataPlotRecieved_ESP32(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                while (_serial.ReadByte() != HEADER_TRAMA) { }       //Enganche del HEADER de trama

                //Si el buffer no tiene suficientes datos, la sobrecarga de Read() que lee a un array solo llena una parte del Array, no espera hasta el TimeOut!!
                while (_serial.BytesToRead < _frameBuffer.Length) { Thread.Sleep(10); }
                
                _serial.Read(_frameBuffer, 0, _frameBuffer.Length);                //Leo la trama completa

                List<uint> samples = new List<uint>();
                uint valor = 0;

                for (int i = 0; i < _frameBuffer.Length; i += ESP32_BYTES_PER_SAMPLE)
                {
                    valor = (uint)_frameBuffer[i] + (uint)(_frameBuffer[i + 1] << 8); //+ (uint)(frameBuffer[i + 2] << 16) + (uint)(frameBuffer[i + 3] << 24);
                    samples.Add(valor);
                }
                _samplesBuffer.Enqueue(samples);

                while (_samplesBuffer.Count != 0)
                {
                    var sample = _samplesBuffer.Dequeue();
                    Graficar(sample);   //Tomo un valor de la cola buffer y lo grafico
                    _fpsCounter++;
                }

                //Depuracion de serial buffer
                //if (_serial.BytesToRead > _serial.ReceivedBytesThreshold * 20) _serial.DiscardInBuffer();
                //Depuracion de cola
                //if (_samplesBuffer.Count > 10) _samplesBuffer.Clear();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR al leer puerto serie!: {ex.Message}");
            }
            return;
        }


        TimeSpan _lastScreen = new TimeSpan(DateTime.Now.Ticks);
        private void ContarFPS()
        {
            _fpsCounter++;
            if (DateTime.Now.Ticks - _lastScreen.Ticks >= 10000000)
            {
                PrintFPS("FPS:" + _fpsCounter);
                _fpsCounter = 0;
                _lastScreen = new TimeSpan(DateTime.Now.Ticks);
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
