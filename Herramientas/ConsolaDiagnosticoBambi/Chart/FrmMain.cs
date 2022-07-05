using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Registrador_FFT
{
    public partial class FrmMain : Form
    {
        public enum BambiCommands {DistanceMeas= '1', ManualMode = 'e', AutomaticMode = 'c',
            AnalizerMode = 'f' , NoteRec = 'r', Forward = 'w', Reverse = 'x', TurnLeft = 'a',
            TurnRight = 'd', Stop = 's', SpeedUp = 'q', SpeedDown = 'z'};


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
        bool _conectadoParaComandos;
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

            EnableCommandControls(false);
        }


        private void btnIniciarDetener_Click(object sender, EventArgs e)
        {
            if (_conectadoParaComandos)
            {
                MessageBox.Show(this, "El modo de envio de comandos esta activo. Desconecte dicho modo para poder ver el modo analisis de especrtro",
                    "Lectura en curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
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
                    if (cmbPuertos.Text == "")
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
                    _serial.WriteTimeout = 2000;
                    _serial.Open();
                    _serial.DiscardInBuffer();
                    _serial.DiscardOutBuffer();
                    SendCommand(BambiCommands.AnalizerMode);

                    btnIniciarDetener.Text = "Detener Lectura";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Hubo un error al realizar la operacion. Detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnVerNotas_Click(object sender, EventArgs e)
        {
            mFormReconocerNotas = new FrmReconocerNotas();
            mFormReconocerNotas.Show();
        }

        private void btn_NotasAVG_Click(object sender, EventArgs e)
        {
            mFormReconocerNotasAVG = new FrmReconocerNotasAVG();
            mFormReconocerNotasAVG.Show();
        }


        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (_lecturaEnCurso)
            {
                MessageBox.Show(this, "Hay una lectura de graficos en curso. Finalizela para poder enviar comandos",
                    "Lectura en curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbPuertos.Text == "")
            {
                MessageBox.Show(this, "Debe seleccionar un puerto de comunicacion",
                    "Lectura en curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (!_conectadoParaComandos)
                {
                    _serial = new SerialPort(cmbPuertos.Text, int.Parse(cmbBaudRate.Text), Parity.None, 8, StopBits.One);
                    _serial.DataReceived += DataCommandRecieved;
                    _serial.ReceivedBytesThreshold = 1;
                    _serial.ReadTimeout = 1000;
                    _serial.Open();
                    _serial.DiscardInBuffer();
                    _serial.DiscardOutBuffer();
                    SendReset();

                    _conectadoParaComandos = true;
                    btnConectar.Text = "Desconectar";
                    EnableCommandControls(true);
                    btnIniciarDetener.Enabled = false;
                }
                else
                {
                    _serial.Close();
                    _conectadoParaComandos = false;
                    btnConectar.Text = "Conectar";
                    EnableCommandControls(false);
                    btnIniciarDetener.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Detalles: {ex.Message}", "Error en la operacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnForward_Click(object sender, EventArgs e)
        {
            _serial.Write("w");
        }
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnSensoresDist_Click(object sender, EventArgs e)
        {
            SendCommand(BambiCommands.DistanceMeas);
        }

        private void btnReconocNotas_Click(object sender, EventArgs e)
        {
            SendCommand(BambiCommands.NoteRec);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SendReset();
        }

        private void tbModeAutoManual_CheckedChanged(object sender, EventArgs e)
        {
            if (tbModeAutoManual.Checked)
            {
                gbMovementCommands.Enabled = true;
                SendCommand(BambiCommands.ManualMode);
            }
            else
            {
                gbMovementCommands.Enabled = false;
                SendCommand(BambiCommands.Stop);
                SendCommand(BambiCommands.AutomaticMode);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SendCommand(BambiCommands.Stop);
        }

        private void btnForward_Click_1(object sender, EventArgs e)
        {
            SendCommand(BambiCommands.Forward);
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            SendCommand(BambiCommands.Reverse);
        }

        private void btnTurnRight_Click(object sender, EventArgs e)
        {
            SendCommand(BambiCommands.TurnRight);
        }

        private void btnTurnLeft_Click(object sender, EventArgs e)
        {
            SendCommand(BambiCommands.TurnLeft);
        }

        private void btnSpeedUp_Click(object sender, EventArgs e)
        {
            SendCommand(BambiCommands.SpeedUp);
        }

        private void btnSpeedDown_Click(object sender, EventArgs e)
        {
            SendCommand(BambiCommands.SpeedDown);
        }

        private void btnSendCommand_Click(object sender, EventArgs e)
        {
            if (txtCommand.Text.Trim().Length != 1) return;
            SendCommand(txtCommand.Text.Trim());
        }

    }
}
