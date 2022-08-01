﻿using System;
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
            _graphSerie.BorderWidth = 2;

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


        private void DataCommandRecieved(object sender, SerialDataReceivedEventArgs e)
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
                        _dataFrameBuffer.Enqueue(frameBuffer.Select(x => (uint)x).ToList());    //Convierto el byte[] a lista de uint y lo vuelco en la cola
                    }
                    
                    if (_dataFrameBuffer.Count != 0)
                    {
                        Graficar(_dataFrameBuffer.Dequeue());   //Tomo un valor de la cola buffer y lo grafico
                        ContarFPS();
                    }
                }
            }
            catch { }
        }


        private const int BYTES_PER_SAMPLE_EPS32 = 2;
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

                        byte[] frameBuffer = new byte[SAMPLES_PER_DATAFRAME_ESP32 * BYTES_PER_SAMPLE_EPS32];
                        _serial.Read(frameBuffer, 0, SAMPLES_PER_DATAFRAME_ESP32 * BYTES_PER_SAMPLE_EPS32);        //Cada muestra pesa 4 bytes

                        for (int i = 0; i < frameBuffer.Length; i += BYTES_PER_SAMPLE_EPS32)
                        {
                            valor = (uint)frameBuffer[i] + (uint)(frameBuffer[i + 1] << 8); //+ (uint)(frameBuffer[i + 2] << 16) + (uint)(frameBuffer[i + 3] << 24);
                            samples.Add(valor);
                        }
                        _dataFrameBuffer.Enqueue(samples);
                    }


                    if (_dataFrameBuffer.Count != 0)
                    {
                        Graficar(_dataFrameBuffer.Dequeue());   //Tomo un valor de la cola buffer y lo grafico
                        ContarFPS();
                    }
                }
            }
            catch { }
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
