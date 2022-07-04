using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Linq;

namespace Registrador_FFT
{
    public partial class FrmMain : Form
    {
        public enum Commandos {MedirDistancias= '1', ModoManual = 'e', ModoAutomatico = 'c', Analizador = 'f' , RecNotas= 'r', Forward = 'w', Reverse = 'x', Izquierda = 'a' , Derecha = 'd'};

        //Usar com0com (o el vspd) para emular el null modem sin usar adaptadores
        //La frecuencia máxima que se muestrea es 19Khz.
        const string PUERTO_DEFAULT = "COM12"; //"COM12";
        const string BAUDRATE_DEFAULT = "19200"; //"19200";
        const int ANCHO_DE_TRAMA = 128;             //Cantidad de muestras por trama.
        const int TIMEOUT_CONEXION = 15000;           //Timeout para detectar la desconexion del dispositivo.

        const Single UMBRAL_MAXIMOS_LOG = 50;
        const Single UMBRAL_MAXIMOS_LIN = 0.1F;
        const Single AXIS_X_INTERVAL = 100;//200;

        private static SerialPort _serial = new SerialPort();
        private const int DATAFRAME_WIDTH = 128;  //Ancho del payload del frame sin la cabecera
        private static Queue<byte[]> _dataFrameBuffer = new Queue<byte[]>();

        bool _lecturaEnCurso;
        Series _graphSerie;


        public FrmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Cargo y seteo los combos
            foreach (String puerto in SerialPort.GetPortNames())
                cmbPuertos.Items.Add(puerto);

            cmbPuertos.Text = PUERTO_DEFAULT;
            cmbBaudRate.Text = BAUDRATE_DEFAULT;

            //Acondiciono el grafico principal
            _graphSerie = new Series("Muestras");
            chartEspectro.ChartAreas[0].AxisX.Minimum = 0;
            chartEspectro.ChartAreas[0].AxisX.Interval = AXIS_X_INTERVAL;
            chartEspectro.ChartAreas[0].AxisY.Minimum = 0;
            chartEspectro.ChartAreas[0].AxisY.Maximum = 250;
            chartEspectro.ChartAreas[0].AxisX.Title = "Frecuencia [Hz]";
            chartEspectro.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            _serial.Close();
        }


        private void btnIniciarDetener_Click(object sender, EventArgs e)
        {
            chkRetener.Checked = false;

            if (_lecturaEnCurso)
            {
                _serial.Close();
                _lecturaEnCurso = false;
                cmbPuertos.Enabled = true;
                cmbBaudRate.Enabled = true;
                btnIniciarDetener.Text = "Iniciar Lectura";
            }
            else
            {
                if (cmbPuertos.Text == "" )
                {
                    MessageBox.Show(this, "Debe seleccionar un puerto de comunicacion", 
                        "Lectura en curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _lecturaEnCurso = true;
                cmbPuertos.Enabled = false;
                cmbBaudRate.Enabled = false;

                _serial = new SerialPort(cmbPuertos.Text, int.Parse(cmbBaudRate.Text), Parity.None, 8, StopBits.One);
                _serial.DataReceived += DataPlotRecieved; //new SerialDataReceivedEventHandler(DataRecieved);
                _serial.ReceivedBytesThreshold = DATAFRAME_WIDTH + 1; //El +1 corresponde al byte de cabecera
                _serial.ReadTimeout = 1000;
                _serial.Open();
                _serial.DiscardInBuffer();
                _serial.DiscardOutBuffer();
                _serial.Write("f");

                btnIniciarDetener.Text = "Detener Lectura";
            }
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


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
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

        private void btnVerNotas_Click(object sender, EventArgs e)
        {
            mFormReconocerNotas = new FrmReconocerNotas();
            mFormReconocerNotas.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mFormReconocerNotasAVG = new FrmReconocerNotasAVG();
            mFormReconocerNotasAVG.Show();
        }


        private void Conectar_Click(object sender, EventArgs e)
        {
            if (_lecturaEnCurso)
            {
                MessageBox.Show(this, "Hay una lectura de graficos en curso. Finalizela para poder enviar comandos", "Lectura en curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cmbPuertos.Text == "")
            {
                MessageBox.Show(this, "Debe seleccionar un puerto de comunicacion",
                    "Lectura en curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _serial = new SerialPort(cmbPuertos.Text, int.Parse(cmbBaudRate.Text), Parity.None, 8, StopBits.One);
            _serial.DataReceived += DataCommandRecieved;
            _serial.ReceivedBytesThreshold = 1;
            _serial.ReadTimeout = 1000;
            _serial.Open();
            _serial.DiscardInBuffer();
            _serial.DiscardOutBuffer();
            _serial.DtrEnable = true;
            Thread.Sleep(10);
            _serial.DtrEnable = false;
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


        private void DataCommandRecieved(object sender, SerialDataReceivedEventArgs e)
        {

            PrintMessage(_serial.ReadExisting());
        }



        private void btnForward_Click(object sender, EventArgs e)
        {
            _serial.Write("w");
        }

        private void chkModo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModo.Checked)
                SendCommand(Commandos.ModoAutomatico);
            else
                SendCommand(Commandos.ModoManual);

        }

        private void SendCommand(Commandos command)
        {
            try
            {
                _serial.Write(((char) command).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error al enviar el comando. Detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
