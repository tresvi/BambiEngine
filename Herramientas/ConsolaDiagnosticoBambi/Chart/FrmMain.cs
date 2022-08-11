using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

//Analizador de espectro online
//https://www.compadre.org/osp/pwa/soundanalyzer/
//Generador de tonos online
//https://www.szynalski.com/tone-generator/

namespace Registrador_FFT
{
    public partial class FrmMain : Form
    {
        public enum BambiCommands {DistanceMeas= '1', ResetWanderingCounter = '2',
            WanderingCounter = '3', ManualMode = 'e', AutomaticMode = 'c',
            AnalizerMode = 'f' , NoteRec = 'r', Forward = 'w', Reverse = 'x', TurnLeft = 'a',
            TurnRight = 'd', Stop = 's', SpeedUp = 'q', SpeedDown = 'z'};

        //Usar com0com (o el vspd) para emular el null modem sin usar adaptadores
        //La frecuencia máxima que se muestrea es 19Khz.
        const string PUERTO_DEFAULT = "COM12"; //"COM12";
        const string BAUDRATE_DEFAULT = "19200"; //"19200";
        const int READ_TIMEOUT = 1000;
        const int WRITE_TIMEOUT = 1000;

        const Single UMBRAL_MAXIMOS_LOG = 50;
        const Single UMBRAL_MAXIMOS_LIN = 0.1F;
        const Single AXIS_X_INTERVAL = 1000;//100;//200;


        //Cantidad de muestras enviadas por trama. 
        //En Arduino como cada una pesa 1 byte, coincide con el ancho de la trama en bytes.
        private const int HEADER_TRAMA = 255;
        private const int ESP32_BYTES_PER_SAMPLE = 2;
        private const int ESP32_SAMPLES_PER_DATAFRAME = 1024;
        private const int ARDUINO_SAMPLES_PER_DATAFRAME = 128;
        
        private int _fpsCounter = 0;
        private static SerialPort _serial = new SerialPort();                 
        private static Queue<List<uint>> _samplesBuffer = new Queue<List<uint>>();

        bool _lecturaEnCurso;
        bool _conectadoParaComandos;
        Series _graphSerie;

        public FrmMain()
        {
            InitializeComponent();
        }


        //Marcar los maximos
        //chart1.DataManipulator.FilterTopN(5, "SeriesName");
        //https://stackoverflow.com/questions/11943378/top-5-max-values-in-mschart

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
            chartEspectro.ChartAreas[0].AxisX.Interval = AXIS_X_INTERVAL/4;
            chartEspectro.ChartAreas[0].AxisY.Minimum = 0;
            chartEspectro.ChartAreas[0].AxisY.Maximum = 4096; //250;
            chartEspectro.ChartAreas[0].AxisX.Title = "Frecuencia [Hz]";
            chartEspectro.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;

            chartEspectro.ChartAreas[0].AxisX.LabelStyle.Format = "{#,#}";  //Solo 1 decimal para los interval de los ejes
            chartEspectro.ChartAreas[0].AxisY.LabelStyle.Format = "{#,#}";


            chartEspectro.DataManipulator.FilterTopN(5, "Muestras");
            chartEspectro.Series["Muestras"].Points.AddXY(50, 50);

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
                    _serial.DataReceived -= DataPlotRecieved_ESP32;
                    Thread.Sleep(500);
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

                    _serial = new SerialPort(cmbPuertos.Text, int.Parse(cmbBaudRate.Text), Parity.None, 8, StopBits.One);
                    _serial.DataReceived += DataPlotRecieved_ESP32; //new SerialDataReceivedEventHandler(DataRecieved);
                    _serial.ReceivedBytesThreshold = 4*(ESP32_SAMPLES_PER_DATAFRAME * 2 + 1); //El +1 corresponde al byte de cabecera
                    _serial.ReadTimeout = READ_TIMEOUT;
                    _serial.WriteTimeout = WRITE_TIMEOUT;
                    _serial.Open();
                    _serial.DiscardInBuffer();
                    _serial.DiscardOutBuffer();
                    SendCommand(BambiCommands.AnalizerMode);

                    _lecturaEnCurso = true;
                    cmbPuertos.Enabled = false;
                    cmbBaudRate.Enabled = false;
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
                    _serial.DataReceived += DataCommandReceived;
                    _serial.ReceivedBytesThreshold = 2049;
                    _serial.ReadBufferSize = 40960;
                    _serial.ReadTimeout = READ_TIMEOUT;
                    _serial.WriteTimeout = WRITE_TIMEOUT;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { Environment.Exit(0); }
            catch { }
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
            bool envioOK;

            if (tbModeAutoManual.Checked)
            {
                envioOK = SendCommand(BambiCommands.ManualMode);             
            }
            else
            {
                SendCommand(BambiCommands.Stop);
                envioOK = SendCommand(BambiCommands.AutomaticMode);
            }

            if (envioOK)
            {
                gbMovementCommands.Enabled = tbModeAutoManual.Checked;
            }
            else
            {
                tbModeAutoManual.CheckedChanged -= tbModeAutoManual_CheckedChanged;
                tbModeAutoManual.Checked = !tbModeAutoManual.Checked;
                tbModeAutoManual.CheckedChanged += tbModeAutoManual_CheckedChanged;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SendCommand(BambiCommands.Stop);
        }

        private void btnForward_Click(object sender, EventArgs e) {SendCommand(BambiCommands.Forward);}

        private void btnReverse_Click(object sender, EventArgs e) {SendCommand(BambiCommands.Reverse);}

        private void btnTurnRight_Click(object sender, EventArgs e){ SendCommand(BambiCommands.TurnRight);}

        private void btnTurnLeft_Click(object sender, EventArgs e){ SendCommand(BambiCommands.TurnLeft);}

        private void btnSpeedUp_Click(object sender, EventArgs e) { SendCommand(BambiCommands.SpeedUp);}

        private void btnSpeedDown_Click(object sender, EventArgs e){SendCommand(BambiCommands.SpeedDown);}

        private void btnSendCommand_Click(object sender, EventArgs e)
        {
            if (txtCommand.Text.Trim().Length != 1) return;
            SendCommand(txtCommand.Text.Trim());
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
        }

        private void btnContadorDeambulaciones_Click(object sender, EventArgs e)
        {
            SendCommand(BambiCommands.WanderingCounter);
        }

        private void btnResetContDeambulacion_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show(this, "Confirma resetear el contador de deambulaciones?"
                , "Reset de contador", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (response == DialogResult.Yes) SendCommand(BambiCommands.ResetWanderingCounter);
        }


        private void tmrFps_Tick(object sender, EventArgs e)
        {
            lblFPS.Text = $"FPS: {_fpsCounter}";
            _fpsCounter = 0;
        }


        bool _enable = false;
        private void button13_Click(object sender, EventArgs e)
        {

            // Enable range selection and zooming end user interface
            _enable = !_enable;
            this.chartEspectro.ChartAreas[0].CursorX.IsUserEnabled = _enable;
            this.chartEspectro.ChartAreas[0].CursorX.IsUserSelectionEnabled = _enable;
            this.chartEspectro.ChartAreas[0].CursorX.Interval = 0;
            this.chartEspectro.ChartAreas[0].AxisX.ScaleView.Zoomable = _enable;
            this.chartEspectro.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            this.chartEspectro.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            this.chartEspectro.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 0;

            this.chartEspectro.ChartAreas[0].CursorY.IsUserEnabled = _enable;
            this.chartEspectro.ChartAreas[0].CursorY.IsUserSelectionEnabled = _enable;
            this.chartEspectro.ChartAreas[0].CursorY.Interval = 0;
            this.chartEspectro.ChartAreas[0].AxisY.ScaleView.Zoomable = _enable;
            this.chartEspectro.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            this.chartEspectro.ChartAreas[0].AxisY.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            this.chartEspectro.ChartAreas[0].AxisY.ScaleView.SmallScrollMinSize = 0;
            if (_enable == false)
            {
                //Remove the cursor lines
                this.chartEspectro.ChartAreas[0].CursorX.SetCursorPosition(double.NaN);
                this.chartEspectro.ChartAreas[0].CursorY.SetCursorPosition(double.NaN);
            }

        }

        private void btnResetZoom_Click(object sender, EventArgs e)
        {
            //double maximo = this.chartEspectro.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
            //chartEspectro.ChartAreas[0].AxisX.Interval = (int) maximo / 10;
            this.chartEspectro.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            this.chartEspectro.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            double maximo = this.chartEspectro.ChartAreas[0].AxisY.ScaleView.ViewMaximum;
            chartEspectro.ChartAreas[0].AxisY.Interval = (int) maximo / 10;

            this.chartEspectro.ChartAreas[0].AxisX.RoundAxisValues();
            this.chartEspectro.ChartAreas[0].AxisY.RoundAxisValues();
        }

        private void chartEspectro_AxisViewChanged(object sender, ViewEventArgs e)
        {
            PrintMessage("Cambio X");
        }

    }
}
