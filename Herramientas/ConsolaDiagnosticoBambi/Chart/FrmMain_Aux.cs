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

                while (_serial.BytesToRead >= SAMPLES_PER_DATAFRAME_ARDUINO)
                {
                    if (_serial.ReadByte() == 255)
                    {
                        byte[] frameBuffer = new byte[SAMPLES_PER_DATAFRAME_ARDUINO];
                        _serial.Read(frameBuffer, 0, SAMPLES_PER_DATAFRAME_ARDUINO);                //Leo la trama completa
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


        private const int BYTES_PER_SAMPLE_EPS32 = 2;
        private Queue<byte> _bufferQueue = new Queue<byte>();
        private int _muestrasEncoladas = 0;

        byte[] _frameBuffer = new byte[SAMPLES_PER_DATAFRAME_ESP32 * BYTES_PER_SAMPLE_EPS32];
        /*
                private void DataPlotRecieved_ESP32(object sender, SerialDataReceivedEventArgs e)
                {
                    //460800: 22-23 SPS
                    //230400: 11-12 SPS
                    //115200: 5-6 SPS
        //            int alpedo = 0;
        //            _serial.Read(_frameBuffer, 0, _frameBuffer.Length);        //Cada muestra pesa 4 bytes

                    // Vuelco el input serial buffer a una queue
                    int bufferSize = _serial.BytesToRead;
                    byte[] tempBuffer = new byte[bufferSize];
                    _serial.Read(tempBuffer, 0, bufferSize);
                    foreach (byte data in tempBuffer) _bufferQueue.Enqueue(data);

                    while (_bufferQueue.Count > 0 && _bufferQueue.Peek() != 255)
                    {
                        _bufferQueue.Dequeue();
                    }

                    if (_bufferQueue.Count < (SAMPLES_PER_DATAFRAME_ESP32 * BYTES_PER_SAMPLE_EPS32) + 1)
                    {
                        return;
                    }

                    _bufferQueue.Dequeue();
                    //Debug.WriteLine($"DEQ: {_bufferQueue.Dequeue()}");     //Tiro la cabecera
                    for (int i = 0; i < SAMPLES_PER_DATAFRAME_ESP32; i++)
                    {
                        uint valor = (uint)_bufferQueue.Dequeue() + (uint)(_bufferQueue.Dequeue() << 8); //+ (uint)(frameBuffer[i + 2] << 16) + (uint)(frameBuffer[i + 3] << 24);
                        //samples.Add(valor);
                    }
                    //_samplesBuffer.Enqueue(samples);

                    _muestrasEncoladas++;
                    //Debug.WriteLine("*");
                    return;
                }
          */
        int _contadorPatinadas = 0;
        private void DataPlotRecieved_ESP32(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                if (!_serial.IsOpen) return;
                //460800: 141-144
                //230400: 86-89
                //115200: 44-46
                //            int alpedo = 0;
                //            _serial.Read(_frameBuffer, 0, _frameBuffer.Length);        //Cada muestra pesa 4 bytes

                // Vuelco el input serial buffer a una queue

                while (_serial.ReadByte() != 255) { }

                // int aLeer = _serial.BytesToRead;

                while (_serial.BytesToRead < _frameBuffer.Length)
                {
                    int j = 0;
                    Thread.Sleep(10);       //!!Si el buffer no tiene suficientes datos, la sobrecarga de Read() que lee a un array solo llena una parte del Array, no espera hasta el TimeOut!!
                    j++;
                }

                //if (aLeer < _frameBuffer.Length)
                //  {
                //  Debug.WriteLine("No entra");
                //return;

                //}

                _serial.Read(_frameBuffer, 0, _frameBuffer.Length);                //Leo la trama completa


                List<uint> samples = new List<uint>();
                uint valor = 0;


                for (int i = 0; i < _frameBuffer.Length; i += BYTES_PER_SAMPLE_EPS32)
                {
                    valor = (uint)_frameBuffer[i] + (uint)(_frameBuffer[i + 1] << 8); //+ (uint)(frameBuffer[i + 2] << 16) + (uint)(frameBuffer[i + 3] << 24);
                    if (valor == 1022)
                    {
                        _contadorPatinadas++;
                    }

                    if (valor != i / 2)
                    {
                        if (valor != 254 && valor != 510 && valor != 766 && valor != 1022)
                        {
                            _contadorPatinadas++;
                        }
                    }

                    if (valor != 200) _contadorPatinadas++;

                    samples.Add(valor);
                }

                _samplesBuffer.Enqueue(samples);

                int bytesToRead = _serial.BytesToRead;
                if (bytesToRead > 30000)
                {
                    //    _serial.DiscardInBuffer();
                    //         Debug.WriteLine($"Tire todo {bytesToRead} bytes**************");
                }

                while (_samplesBuffer.Count != 0)
                {
                    var sample = _samplesBuffer.Dequeue();
                    // Debug.WriteLine("Grafico!");
                    Graficar(sample);   //Tomo un valor de la cola buffer y lo grafico
                }

                _muestrasEncoladas++;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR!!");
            }
            return;
        }

        /*
        private void DataPlotRecieved_ESP32(object sender, SerialDataReceivedEventArgs e)
        {
            long lecturaInputBuffer = 0, volcadoQueue = 0, creacionSample = 0, graficar =0 ;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Vuelco el input serial buffer a una queue
            int bufferSize = _serial.BytesToRead;
            byte[] tempBuffer = new byte[bufferSize];
            _serial.Read(tempBuffer, 0, bufferSize);        
            foreach (byte data in tempBuffer) _bufferQueue.Enqueue(data);

            sw.Stop();
            lecturaInputBuffer = sw.ElapsedMilliseconds;

            sw.Restart();
            int dequeued = 0;
            while (_bufferQueue.Count > 0 && _bufferQueue.Peek() != 255)
            {
                dequeued++;
                _bufferQueue.Dequeue();

            }
            //Debug.WriteLine($"Descartados: {dequeued}");
            sw.Stop();
            volcadoQueue = sw.ElapsedMilliseconds;


            if (_bufferQueue.Count < (SAMPLES_PER_DATAFRAME_ESP32 * BYTES_PER_SAMPLE_EPS32) + 1)
            {
                Debug.WriteLine("FUI");
                return;

            }

            sw.Restart();
            List<uint> samples = new List<uint>();
            while (_bufferQueue.Count > (SAMPLES_PER_DATAFRAME_ESP32 * BYTES_PER_SAMPLE_EPS32) + 1)
            {

                _bufferQueue.Dequeue();
                //Debug.WriteLine($"DEQ: {_bufferQueue.Dequeue()}");     //Tiro la cabecera
                for (int i = 0; i < SAMPLES_PER_DATAFRAME_ESP32; i++)
                {
                    uint valor = (uint)_bufferQueue.Dequeue() + (uint)(_bufferQueue.Dequeue() << 8); //+ (uint)(frameBuffer[i + 2] << 16) + (uint)(frameBuffer[i + 3] << 24);
                    samples.Add(valor);
                }
                _samplesBuffer.Enqueue(samples);
            }
            sw.Stop();
            creacionSample = sw.ElapsedMilliseconds;

            //Debug.WriteLine($"DEqueued: {dequeued}  -  SW:{sw.ElapsedMilliseconds}");
            // Debug.WriteLine($"input Buffer: {bufferSize}  -   Queue size: {_bufferQueue.Count()}");

            int graficados = 0;
            sw.Restart();
            while (_samplesBuffer.Count != 0)
            {
                graficados++;
               // Debug.WriteLine("Grafico!");
                Graficar(_samplesBuffer.Dequeue());   //Tomo un valor de la cola buffer y lo grafico
                ContarFPS();
            }
            sw.Stop();

            graficar = sw.ElapsedMilliseconds;

            Debug.WriteLine($"lecInpBuf: {lecturaInputBuffer}  -  volcQueue:{volcadoQueue}  -  sample:{creacionSample}  -  graficar:{graficar}  -  buf:{_bufferQueue.Count}  -  sampBuf:{_samplesBuffer.Count}  -  Dequeued:{dequeued}  -  Graficados:{graficados}");
        }
        */

        /* private void DataPlotRecieved_ESP32(object sender, SerialDataReceivedEventArgs e)
         {
             int bufferSize = _serial.BytesToRead;
             byte[] tempBuffer = new byte[bufferSize];

             _serial.Read(tempBuffer, 0, bufferSize);        //Cada muestra pesa 4 bytes

             foreach (byte data in tempBuffer)
                 _bufferQueue.Enqueue(data);

             Stopwatch sw = new Stopwatch();
             sw.Start();
             int dequeued = 0;
             while (_bufferQueue.Count != 0 && _bufferQueue.Dequeue() != 255)
             { dequeued++; }
             sw.Stop();
             Debug.WriteLine($"DEqueued: {dequeued}  -  SW:{sw.ElapsedMilliseconds}");
            // Debug.WriteLine($"input Buffer: {bufferSize}  -   Queue size: {_bufferQueue.Count()}");
             List<uint> samples = new List<uint>();

             if (_bufferQueue.Count >= SAMPLES_PER_DATAFRAME_ESP32 * BYTES_PER_SAMPLE_EPS32)
             {
                 for (int i=0; i < SAMPLES_PER_DATAFRAME_ESP32 * BYTES_PER_SAMPLE_EPS32; i+= BYTES_PER_SAMPLE_EPS32)
                 {
                     uint valor = (uint)_bufferQueue.Dequeue() + (uint)(_bufferQueue.Dequeue() << 8); //+ (uint)(frameBuffer[i + 2] << 16) + (uint)(frameBuffer[i + 3] << 24);
                     samples.Add(valor);
                 }
                 _dataFrameBuffer.Enqueue(samples);
             }

             while (_dataFrameBuffer.Count != 0)
             {
                 _dataFrameBuffer.Dequeue();
                // Graficar(_dataFrameBuffer.Dequeue());   //Tomo un valor de la cola buffer y lo grafico
                 ContarFPS();
             }

         }
         */

        /*
        byte[] _frameBuffer = new byte[SAMPLES_PER_DATAFRAME_ESP32 * BYTES_PER_SAMPLE_EPS32];
        private void DataPlotRecieved_ESP32(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                while (_serial.BytesToRead >= SAMPLES_PER_DATAFRAME_ESP32 * BYTES_PER_SAMPLE_EPS32)
                {

                    if (_serial.ReadByte() == 255)
                    {
                        uint valor = 0;
                        List<uint> samples = new List<uint>();

                        //byte[] frameBuffer = new byte[SAMPLES_PER_DATAFRAME_ESP32 * BYTES_PER_SAMPLE_EPS32];
                        _serial.Read(_frameBuffer, 0, SAMPLES_PER_DATAFRAME_ESP32 * BYTES_PER_SAMPLE_EPS32);        //Cada muestra pesa 4 bytes

                        for (int i = 0; i < _frameBuffer.Length; i += BYTES_PER_SAMPLE_EPS32)
                        {
                            valor = (uint)_frameBuffer[i] + (uint)(_frameBuffer[i + 1] << 8); //+ (uint)(frameBuffer[i + 2] << 16) + (uint)(frameBuffer[i + 3] << 24);
                            samples.Add(valor);
                        }
                        _samplesBuffer.Enqueue(samples);
                        _muestrasEncoladas++;
                    }
                    else
                    {
                        PrintMessage("Patino" + '\n');
                    }

                    if (_samplesBuffer.Count != 0)
                    {
                        Graficar(_samplesBuffer.Dequeue());   //Tomo un valor de la cola buffer y lo grafico
                        ContarFPS();
                    }
                }
            }
            catch (Exception ex)
            {
                PrintMessage(ex.Message + '\n');
            }
        }
        */

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
