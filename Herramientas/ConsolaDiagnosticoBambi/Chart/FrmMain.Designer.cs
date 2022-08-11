namespace Registrador_FFT
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.chartEspectro = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnResetContDeambulacion = new System.Windows.Forms.Button();
            this.btnContadorDeambulaciones = new System.Windows.Forms.Button();
            this.picBat = new System.Windows.Forms.PictureBox();
            this.picPuntaPila = new System.Windows.Forms.PictureBox();
            this.lblBat = new System.Windows.Forms.Label();
            this.btnReconocNotas = new System.Windows.Forms.Button();
            this.gbMovementCommands = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClean = new System.Windows.Forms.Button();
            this.lblFPS = new System.Windows.Forms.Label();
            this.cmbPuertos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIniciarDetener = new System.Windows.Forms.Button();
            this.chkRetener = new System.Windows.Forms.CheckBox();
            this.btnNotasAVG = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tmrFPS = new System.Windows.Forms.Timer(this.components);
            this.gbComandos = new System.Windows.Forms.GroupBox();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnVerNotas = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnSensoresDist = new System.Windows.Forms.Button();
            this.gbNavegacion = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSpeedUp = new System.Windows.Forms.Button();
            this.btnSpeedDown = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.btnResetZoom = new System.Windows.Forms.Button();
            this.tbModeAutoManual = new CustomControls.RJControls.ToggleButton();
            this.vpBat = new ConsolaBambiBot.Controls.VerticalProgressBar();
            this.toggleButton1 = new CustomControls.RJControls.ToggleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartEspectro)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPuntaPila)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.gbComandos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbNavegacion.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartEspectro
            // 
            this.chartEspectro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartEspectro.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 15;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea1.AxisX.Title = "Frecuencia[Hz]";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.Maximum = 250D;
            chartArea1.AxisY.Title = "Amplitud";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea1.Name = "ChartArea1";
            this.chartEspectro.ChartAreas.Add(chartArea1);
            this.chartEspectro.Location = new System.Drawing.Point(16, 92);
            this.chartEspectro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartEspectro.Name = "chartEspectro";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.MarkerStep = 10;
            series1.Name = "Muestras";
            this.chartEspectro.Series.Add(series1);
            this.chartEspectro.Size = new System.Drawing.Size(1388, 702);
            this.chartEspectro.TabIndex = 0;
            this.chartEspectro.Text = "chart1";
            this.chartEspectro.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.chartEspectro_AxisViewChanged);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(13, 814);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(870, 222);
            this.txtLog.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnResetContDeambulacion);
            this.groupBox1.Controls.Add(this.btnContadorDeambulaciones);
            this.groupBox1.Location = new System.Drawing.Point(18, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 95);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deambulacion";
            // 
            // btnResetContDeambulacion
            // 
            this.btnResetContDeambulacion.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetContDeambulacion.Location = new System.Drawing.Point(84, 29);
            this.btnResetContDeambulacion.Name = "btnResetContDeambulacion";
            this.btnResetContDeambulacion.Size = new System.Drawing.Size(100, 60);
            this.btnResetContDeambulacion.TabIndex = 55;
            this.btnResetContDeambulacion.Text = "Reset";
            this.btnResetContDeambulacion.UseVisualStyleBackColor = true;
            this.btnResetContDeambulacion.Click += new System.EventHandler(this.btnResetContDeambulacion_Click);
            // 
            // btnContadorDeambulaciones
            // 
            this.btnContadorDeambulaciones.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContadorDeambulaciones.Location = new System.Drawing.Point(12, 29);
            this.btnContadorDeambulaciones.Name = "btnContadorDeambulaciones";
            this.btnContadorDeambulaciones.Size = new System.Drawing.Size(66, 60);
            this.btnContadorDeambulaciones.TabIndex = 54;
            this.btnContadorDeambulaciones.Text = "#";
            this.btnContadorDeambulaciones.UseVisualStyleBackColor = true;
            this.btnContadorDeambulaciones.Click += new System.EventHandler(this.btnContadorDeambulaciones_Click);
            // 
            // picBat
            // 
            this.picBat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBat.BackgroundImage")));
            this.picBat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBat.Location = new System.Drawing.Point(99, 508);
            this.picBat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBat.Name = "picBat";
            this.picBat.Size = new System.Drawing.Size(39, 42);
            this.picBat.TabIndex = 49;
            this.picBat.TabStop = false;
            // 
            // picPuntaPila
            // 
            this.picPuntaPila.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPuntaPila.BackgroundImage")));
            this.picPuntaPila.Location = new System.Drawing.Point(101, 422);
            this.picPuntaPila.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picPuntaPila.Name = "picPuntaPila";
            this.picPuntaPila.Size = new System.Drawing.Size(35, 12);
            this.picPuntaPila.TabIndex = 50;
            this.picPuntaPila.TabStop = false;
            // 
            // lblBat
            // 
            this.lblBat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBat.Location = new System.Drawing.Point(75, 622);
            this.lblBat.Name = "lblBat";
            this.lblBat.Size = new System.Drawing.Size(87, 25);
            this.lblBat.TabIndex = 48;
            this.lblBat.Text = "--%";
            this.lblBat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReconocNotas
            // 
            this.btnReconocNotas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReconocNotas.Location = new System.Drawing.Point(20, 154);
            this.btnReconocNotas.Name = "btnReconocNotas";
            this.btnReconocNotas.Size = new System.Drawing.Size(190, 47);
            this.btnReconocNotas.TabIndex = 42;
            this.btnReconocNotas.Text = "Modo R/Notas";
            this.btnReconocNotas.UseVisualStyleBackColor = true;
            this.btnReconocNotas.Click += new System.EventHandler(this.btnReconocNotas_Click);
            // 
            // gbMovementCommands
            // 
            this.gbMovementCommands.Enabled = false;
            this.gbMovementCommands.Location = new System.Drawing.Point(216, 1);
            this.gbMovementCommands.Name = "gbMovementCommands";
            this.gbMovementCommands.Size = new System.Drawing.Size(535, 233);
            this.gbMovementCommands.TabIndex = 52;
            this.gbMovementCommands.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 29);
            this.label3.TabIndex = 48;
            this.label3.Text = "Auto / Manual";
            // 
            // btnClean
            // 
            this.btnClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClean.Location = new System.Drawing.Point(787, 981);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(63, 50);
            this.btnClean.TabIndex = 18;
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // lblFPS
            // 
            this.lblFPS.AutoSize = true;
            this.lblFPS.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFPS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblFPS.Location = new System.Drawing.Point(13, 98);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(57, 25);
            this.lblFPS.TabIndex = 19;
            this.lblFPS.Text = "FPS:";
            // 
            // cmbPuertos
            // 
            this.cmbPuertos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuertos.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPuertos.FormattingEnabled = true;
            this.cmbPuertos.Location = new System.Drawing.Point(100, 26);
            this.cmbPuertos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPuertos.Name = "cmbPuertos";
            this.cmbPuertos.Size = new System.Drawing.Size(134, 34);
            this.cmbPuertos.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "Puerto";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "50",
            "110",
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.cmbBaudRate.Location = new System.Drawing.Point(388, 26);
            this.cmbBaudRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(112, 34);
            this.cmbBaudRate.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 26);
            this.label2.TabIndex = 14;
            this.label2.Text = "BuadRate";
            // 
            // btnIniciarDetener
            // 
            this.btnIniciarDetener.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarDetener.Location = new System.Drawing.Point(800, 21);
            this.btnIniciarDetener.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIniciarDetener.Name = "btnIniciarDetener";
            this.btnIniciarDetener.Size = new System.Drawing.Size(268, 46);
            this.btnIniciarDetener.TabIndex = 16;
            this.btnIniciarDetener.Text = "Análisis de Espectro";
            this.btnIniciarDetener.UseVisualStyleBackColor = true;
            this.btnIniciarDetener.Click += new System.EventHandler(this.btnIniciarDetener_Click);
            // 
            // chkRetener
            // 
            this.chkRetener.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRetener.Enabled = false;
            this.chkRetener.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetener.Location = new System.Drawing.Point(1150, 21);
            this.chkRetener.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkRetener.Name = "chkRetener";
            this.chkRetener.Size = new System.Drawing.Size(166, 46);
            this.chkRetener.TabIndex = 17;
            this.chkRetener.Text = "&Retener (R)";
            this.chkRetener.UseVisualStyleBackColor = true;
            // 
            // btnNotasAVG
            // 
            this.btnNotasAVG.Enabled = false;
            this.btnNotasAVG.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotasAVG.Location = new System.Drawing.Point(1476, 22);
            this.btnNotasAVG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNotasAVG.Name = "btnNotasAVG";
            this.btnNotasAVG.Size = new System.Drawing.Size(144, 45);
            this.btnNotasAVG.TabIndex = 21;
            this.btnNotasAVG.Text = "&Notas AVG";
            this.btnNotasAVG.UseVisualStyleBackColor = true;
            this.btnNotasAVG.Click += new System.EventHandler(this.btn_NotasAVG_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Arduino",
            "ESP32"});
            this.comboBox1.Location = new System.Drawing.Point(613, 24);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(112, 34);
            this.comboBox1.TabIndex = 22;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.btnNotasAVG);
            this.groupBox3.Controls.Add(this.chkRetener);
            this.groupBox3.Controls.Add(this.btnIniciarDetener);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cmbBaudRate);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbPuertos);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(18, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(1645, 82);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Conexión";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F);
            this.label4.Location = new System.Drawing.Point(545, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 26);
            this.label4.TabIndex = 23;
            this.label4.Text = "CPU";
            // 
            // tmrFPS
            // 
            this.tmrFPS.Enabled = true;
            this.tmrFPS.Interval = 1000;
            this.tmrFPS.Tick += new System.EventHandler(this.tmrFps_Tick);
            // 
            // gbComandos
            // 
            this.gbComandos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbComandos.Controls.Add(this.btnSendCommand);
            this.gbComandos.Controls.Add(this.pictureBox1);
            this.gbComandos.Controls.Add(this.pictureBox2);
            this.gbComandos.Controls.Add(this.label5);
            this.gbComandos.Controls.Add(this.txtCommand);
            this.gbComandos.Controls.Add(this.btnReset);
            this.gbComandos.Controls.Add(this.btnVerNotas);
            this.gbComandos.Controls.Add(this.btnConectar);
            this.gbComandos.Controls.Add(this.btnSensoresDist);
            this.gbComandos.Controls.Add(this.vpBat);
            this.gbComandos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbComandos.Location = new System.Drawing.Point(1429, 92);
            this.gbComandos.Name = "gbComandos";
            this.gbComandos.Size = new System.Drawing.Size(228, 696);
            this.gbComandos.TabIndex = 20;
            this.gbComandos.TabStop = false;
            this.gbComandos.Text = "Comandos";
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendCommand.Location = new System.Drawing.Point(148, 359);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(61, 45);
            this.btnSendCommand.TabIndex = 51;
            this.btnSendCommand.Text = ">>";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(99, 512);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 42);
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(101, 426);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 12);
            this.pictureBox2.TabIndex = 50;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 626);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 25);
            this.label5.TabIndex = 48;
            this.label5.Text = "--%";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCommand
            // 
            this.txtCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommand.Location = new System.Drawing.Point(24, 361);
            this.txtCommand.MaxLength = 1;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(118, 39);
            this.txtCommand.TabIndex = 44;
            this.txtCommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(24, 284);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(185, 54);
            this.btnReset.TabIndex = 43;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnVerNotas
            // 
            this.btnVerNotas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerNotas.Location = new System.Drawing.Point(24, 202);
            this.btnVerNotas.Name = "btnVerNotas";
            this.btnVerNotas.Size = new System.Drawing.Size(185, 65);
            this.btnVerNotas.TabIndex = 42;
            this.btnVerNotas.Text = "Recon. Notas";
            this.btnVerNotas.UseVisualStyleBackColor = true;
            this.btnVerNotas.Click += new System.EventHandler(this.btnReconocNotas_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.Location = new System.Drawing.Point(24, 31);
            this.btnConectar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(185, 63);
            this.btnConectar.TabIndex = 17;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnSensoresDist
            // 
            this.btnSensoresDist.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSensoresDist.Location = new System.Drawing.Point(24, 114);
            this.btnSensoresDist.Name = "btnSensoresDist";
            this.btnSensoresDist.Size = new System.Drawing.Size(185, 66);
            this.btnSensoresDist.TabIndex = 0;
            this.btnSensoresDist.Text = "Distancia";
            this.btnSensoresDist.UseVisualStyleBackColor = true;
            this.btnSensoresDist.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // gbNavegacion
            // 
            this.gbNavegacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbNavegacion.Controls.Add(this.tbModeAutoManual);
            this.gbNavegacion.Controls.Add(this.groupBox2);
            this.gbNavegacion.Controls.Add(this.label6);
            this.gbNavegacion.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNavegacion.Location = new System.Drawing.Point(906, 802);
            this.gbNavegacion.Name = "gbNavegacion";
            this.gbNavegacion.Size = new System.Drawing.Size(751, 234);
            this.gbNavegacion.TabIndex = 21;
            this.gbNavegacion.TabStop = false;
            this.gbNavegacion.Text = "Navegacion";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSpeedUp);
            this.groupBox2.Controls.Add(this.btnSpeedDown);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.btnForward);
            this.groupBox2.Controls.Add(this.btnReverse);
            this.groupBox2.Controls.Add(this.btnRight);
            this.groupBox2.Controls.Add(this.btnLeft);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(216, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 233);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            // 
            // btnSpeedUp
            // 
            this.btnSpeedUp.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeedUp.Location = new System.Drawing.Point(19, 33);
            this.btnSpeedUp.Name = "btnSpeedUp";
            this.btnSpeedUp.Size = new System.Drawing.Size(135, 85);
            this.btnSpeedUp.TabIndex = 58;
            this.btnSpeedUp.Text = "Speed+";
            this.btnSpeedUp.UseVisualStyleBackColor = true;
            this.btnSpeedUp.Click += new System.EventHandler(this.btnSpeedUp_Click);
            // 
            // btnSpeedDown
            // 
            this.btnSpeedDown.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeedDown.Location = new System.Drawing.Point(19, 126);
            this.btnSpeedDown.Name = "btnSpeedDown";
            this.btnSpeedDown.Size = new System.Drawing.Size(135, 85);
            this.btnSpeedDown.TabIndex = 57;
            this.btnSpeedDown.Text = "Speed-";
            this.btnSpeedDown.UseVisualStyleBackColor = true;
            this.btnSpeedDown.Click += new System.EventHandler(this.btnSpeedDown_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(402, 18);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(96, 85);
            this.btnStop.TabIndex = 56;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnForward
            // 
            this.btnForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnForward.Font = new System.Drawing.Font("Wingdings", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnForward.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnForward.Location = new System.Drawing.Point(297, 18);
            this.btnForward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(96, 85);
            this.btnForward.TabIndex = 54;
            this.btnForward.Text = "";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReverse.Font = new System.Drawing.Font("Wingdings", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnReverse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReverse.Location = new System.Drawing.Point(297, 112);
            this.btnReverse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(96, 97);
            this.btnReverse.TabIndex = 55;
            this.btnReverse.Text = "ê";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRight.Font = new System.Drawing.Font("Wingdings", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRight.Location = new System.Drawing.Point(402, 111);
            this.btnRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(96, 97);
            this.btnRight.TabIndex = 52;
            this.btnRight.Text = "";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnTurnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLeft.Font = new System.Drawing.Font("Wingdings", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLeft.Location = new System.Drawing.Point(192, 111);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(96, 97);
            this.btnLeft.TabIndex = 53;
            this.btnLeft.Text = "";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnTurnLeft_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 29);
            this.label6.TabIndex = 48;
            this.label6.Text = "Auto / Manual";
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(1166, 718);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(132, 36);
            this.button14.TabIndex = 54;
            this.button14.Text = "redondear Ejes";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // btnResetZoom
            // 
            this.btnResetZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetZoom.Font = new System.Drawing.Font("Arial", 13F);
            this.btnResetZoom.Location = new System.Drawing.Point(33, 730);
            this.btnResetZoom.Name = "btnResetZoom";
            this.btnResetZoom.Size = new System.Drawing.Size(183, 51);
            this.btnResetZoom.TabIndex = 56;
            this.btnResetZoom.Text = "Reset Zoom";
            this.btnResetZoom.UseVisualStyleBackColor = true;
            this.btnResetZoom.Click += new System.EventHandler(this.btnResetZoom_Click);
            // 
            // tbModeAutoManual
            // 
            this.tbModeAutoManual.Location = new System.Drawing.Point(34, 113);
            this.tbModeAutoManual.MinimumSize = new System.Drawing.Size(45, 22);
            this.tbModeAutoManual.Name = "tbModeAutoManual";
            this.tbModeAutoManual.OffBackColor = System.Drawing.Color.Gray;
            this.tbModeAutoManual.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tbModeAutoManual.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.tbModeAutoManual.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tbModeAutoManual.Size = new System.Drawing.Size(146, 64);
            this.tbModeAutoManual.TabIndex = 53;
            this.tbModeAutoManual.UseVisualStyleBackColor = true;
            this.tbModeAutoManual.CheckedChanged += new System.EventHandler(this.tbModeAutoManual_CheckedChanged);
            // 
            // vpBat
            // 
            this.vpBat.Location = new System.Drawing.Point(68, 439);
            this.vpBat.Name = "vpBat";
            this.vpBat.Size = new System.Drawing.Size(104, 187);
            this.vpBat.TabIndex = 52;
            this.vpBat.Value = 70;
            // 
            // toggleButton1
            // 
            this.toggleButton1.Location = new System.Drawing.Point(33, 111);
            this.toggleButton1.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.OffBackColor = System.Drawing.Color.Gray;
            this.toggleButton1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton1.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.toggleButton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButton1.Size = new System.Drawing.Size(140, 63);
            this.toggleButton1.TabIndex = 53;
            this.toggleButton1.UseVisualStyleBackColor = true;
            this.toggleButton1.CheckedChanged += new System.EventHandler(this.tbModeAutoManual_CheckedChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1669, 1050);
            this.Controls.Add(this.btnResetZoom);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.gbNavegacion);
            this.Controls.Add(this.gbComandos);
            this.Controls.Add(this.lblFPS);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.chartEspectro);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.Text = "Consola Bambibot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartEspectro)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPuntaPila)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbComandos.ResumeLayout(false);
            this.gbComandos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbNavegacion.ResumeLayout(false);
            this.gbNavegacion.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartEspectro;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReconocNotas;
        private System.Windows.Forms.GroupBox gbMovementCommands;
        private System.Windows.Forms.PictureBox picBat;
        private System.Windows.Forms.PictureBox picPuntaPila;
        private System.Windows.Forms.Label lblBat;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnResetContDeambulacion;
        private System.Windows.Forms.Button btnContadorDeambulaciones;
        private System.Windows.Forms.Label lblFPS;
        private System.Windows.Forms.ComboBox cmbPuertos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIniciarDetener;
        private System.Windows.Forms.CheckBox chkRetener;
        private System.Windows.Forms.Button btnNotasAVG;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer tmrFPS;
        private System.Windows.Forms.GroupBox gbComandos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnVerNotas;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnSensoresDist;
        private System.Windows.Forms.GroupBox gbNavegacion;
        private CustomControls.RJControls.ToggleButton toggleButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSpeedUp;
        private System.Windows.Forms.Button btnSpeedDown;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button14;
        private CustomControls.RJControls.ToggleButton tbModeAutoManual;
        private System.Windows.Forms.Button btnSendCommand;
        private ConsolaBambiBot.Controls.VerticalProgressBar vpBat;
        private System.Windows.Forms.Button btnResetZoom;
    }
}

