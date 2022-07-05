﻿namespace Registrador_FFT
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartEspectro = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNotasAVG = new System.Windows.Forms.Button();
            this.btnVerNotas = new System.Windows.Forms.Button();
            this.chkRetener = new System.Windows.Forms.CheckBox();
            this.btnIniciarDetener = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPuertos = new System.Windows.Forms.ComboBox();
            this.gbComandos = new System.Windows.Forms.GroupBox();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnReconocNotas = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnSensoresDist = new System.Windows.Forms.Button();
            this.gbNavegacion = new System.Windows.Forms.GroupBox();
            this.gbMovementCommands = new System.Windows.Forms.GroupBox();
            this.btnSpeedUp = new System.Windows.Forms.Button();
            this.btnSpeedDown = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnTurnRight = new System.Windows.Forms.Button();
            this.btnTurnLeft = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbModeAutoManual = new CustomControls.RJControls.ToggleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartEspectro)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.gbComandos.SuspendLayout();
            this.gbNavegacion.SuspendLayout();
            this.gbMovementCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartEspectro
            // 
            this.chartEspectro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartEspectro.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.AxisX.LabelAutoFitMaxFontSize = 15;
            chartArea2.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea2.AxisX.Title = "Frecuencia[Hz]";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.Maximum = 250D;
            chartArea2.AxisY.Title = "Amplitud";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea2.Name = "ChartArea1";
            this.chartEspectro.ChartAreas.Add(chartArea2);
            this.chartEspectro.Location = new System.Drawing.Point(16, 92);
            this.chartEspectro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartEspectro.Name = "chartEspectro";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Name = "Muestras";
            this.chartEspectro.Series.Add(series2);
            this.chartEspectro.Size = new System.Drawing.Size(1388, 702);
            this.chartEspectro.TabIndex = 0;
            this.chartEspectro.Text = "chart1";
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
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnNotasAVG);
            this.groupBox3.Controls.Add(this.btnVerNotas);
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
            // btnVerNotas
            // 
            this.btnVerNotas.Enabled = false;
            this.btnVerNotas.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerNotas.Location = new System.Drawing.Point(1307, 22);
            this.btnVerNotas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVerNotas.Name = "btnVerNotas";
            this.btnVerNotas.Size = new System.Drawing.Size(144, 45);
            this.btnVerNotas.TabIndex = 18;
            this.btnVerNotas.Text = "&Ver Notas";
            this.btnVerNotas.UseVisualStyleBackColor = true;
            this.btnVerNotas.Click += new System.EventHandler(this.btnVerNotas_Click);
            // 
            // chkRetener
            // 
            this.chkRetener.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRetener.Enabled = false;
            this.chkRetener.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetener.Location = new System.Drawing.Point(1112, 21);
            this.chkRetener.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkRetener.Name = "chkRetener";
            this.chkRetener.Size = new System.Drawing.Size(166, 46);
            this.chkRetener.TabIndex = 17;
            this.chkRetener.Text = "&Retener (R)";
            this.chkRetener.UseVisualStyleBackColor = true;
            // 
            // btnIniciarDetener
            // 
            this.btnIniciarDetener.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarDetener.Location = new System.Drawing.Point(544, 22);
            this.btnIniciarDetener.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIniciarDetener.Name = "btnIniciarDetener";
            this.btnIniciarDetener.Size = new System.Drawing.Size(302, 46);
            this.btnIniciarDetener.TabIndex = 16;
            this.btnIniciarDetener.Text = "Análisis de Espectro";
            this.btnIniciarDetener.UseVisualStyleBackColor = true;
            this.btnIniciarDetener.Click += new System.EventHandler(this.btnIniciarDetener_Click);
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
            "115200"});
            this.cmbBaudRate.Location = new System.Drawing.Point(388, 26);
            this.cmbBaudRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(112, 34);
            this.cmbBaudRate.TabIndex = 13;
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
            // gbComandos
            // 
            this.gbComandos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbComandos.Controls.Add(this.btnSendCommand);
            this.gbComandos.Controls.Add(this.txtCommand);
            this.gbComandos.Controls.Add(this.btnReset);
            this.gbComandos.Controls.Add(this.btnReconocNotas);
            this.gbComandos.Controls.Add(this.btnConectar);
            this.gbComandos.Controls.Add(this.btnSensoresDist);
            this.gbComandos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbComandos.Location = new System.Drawing.Point(1429, 98);
            this.gbComandos.Name = "gbComandos";
            this.gbComandos.Size = new System.Drawing.Size(228, 696);
            this.gbComandos.TabIndex = 16;
            this.gbComandos.TabStop = false;
            this.gbComandos.Text = "Comandos";
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Location = new System.Drawing.Point(148, 487);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(61, 42);
            this.btnSendCommand.TabIndex = 45;
            this.btnSendCommand.Text = ">>";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommand.Location = new System.Drawing.Point(24, 489);
            this.txtCommand.MaxLength = 1;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(118, 39);
            this.txtCommand.TabIndex = 44;
            this.txtCommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(24, 351);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(185, 95);
            this.btnReset.TabIndex = 43;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnReconocNotas
            // 
            this.btnReconocNotas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReconocNotas.Location = new System.Drawing.Point(24, 234);
            this.btnReconocNotas.Name = "btnReconocNotas";
            this.btnReconocNotas.Size = new System.Drawing.Size(185, 95);
            this.btnReconocNotas.TabIndex = 42;
            this.btnReconocNotas.Text = "Reconoc. Notas";
            this.btnReconocNotas.UseVisualStyleBackColor = true;
            this.btnReconocNotas.Click += new System.EventHandler(this.btnReconocNotas_Click);
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
            this.btnSensoresDist.Location = new System.Drawing.Point(24, 116);
            this.btnSensoresDist.Name = "btnSensoresDist";
            this.btnSensoresDist.Size = new System.Drawing.Size(185, 95);
            this.btnSensoresDist.TabIndex = 0;
            this.btnSensoresDist.Text = "Sensores de distancia";
            this.btnSensoresDist.UseVisualStyleBackColor = true;
            this.btnSensoresDist.Click += new System.EventHandler(this.btnSensoresDist_Click);
            // 
            // gbNavegacion
            // 
            this.gbNavegacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbNavegacion.Controls.Add(this.gbMovementCommands);
            this.gbNavegacion.Controls.Add(this.label3);
            this.gbNavegacion.Controls.Add(this.tbModeAutoManual);
            this.gbNavegacion.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNavegacion.Location = new System.Drawing.Point(906, 801);
            this.gbNavegacion.Name = "gbNavegacion";
            this.gbNavegacion.Size = new System.Drawing.Size(751, 234);
            this.gbNavegacion.TabIndex = 17;
            this.gbNavegacion.TabStop = false;
            this.gbNavegacion.Text = "Navegacion";
            // 
            // gbMovementCommands
            // 
            this.gbMovementCommands.Controls.Add(this.btnSpeedUp);
            this.gbMovementCommands.Controls.Add(this.btnSpeedDown);
            this.gbMovementCommands.Controls.Add(this.btnStop);
            this.gbMovementCommands.Controls.Add(this.btnForward);
            this.gbMovementCommands.Controls.Add(this.btnReverse);
            this.gbMovementCommands.Controls.Add(this.btnTurnRight);
            this.gbMovementCommands.Controls.Add(this.btnTurnLeft);
            this.gbMovementCommands.Enabled = false;
            this.gbMovementCommands.Location = new System.Drawing.Point(216, 1);
            this.gbMovementCommands.Name = "gbMovementCommands";
            this.gbMovementCommands.Size = new System.Drawing.Size(535, 233);
            this.gbMovementCommands.TabIndex = 52;
            this.gbMovementCommands.TabStop = false;
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
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click_1);
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
            // btnTurnRight
            // 
            this.btnTurnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTurnRight.Font = new System.Drawing.Font("Wingdings", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnTurnRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTurnRight.Location = new System.Drawing.Point(402, 111);
            this.btnTurnRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTurnRight.Name = "btnTurnRight";
            this.btnTurnRight.Size = new System.Drawing.Size(96, 97);
            this.btnTurnRight.TabIndex = 52;
            this.btnTurnRight.Text = "";
            this.btnTurnRight.UseVisualStyleBackColor = true;
            this.btnTurnRight.Click += new System.EventHandler(this.btnTurnRight_Click);
            // 
            // btnTurnLeft
            // 
            this.btnTurnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTurnLeft.Font = new System.Drawing.Font("Wingdings", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnTurnLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTurnLeft.Location = new System.Drawing.Point(192, 111);
            this.btnTurnLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTurnLeft.Name = "btnTurnLeft";
            this.btnTurnLeft.Size = new System.Drawing.Size(96, 97);
            this.btnTurnLeft.TabIndex = 53;
            this.btnTurnLeft.Text = "";
            this.btnTurnLeft.UseVisualStyleBackColor = true;
            this.btnTurnLeft.Click += new System.EventHandler(this.btnTurnLeft_Click);
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
            // tbModeAutoManual
            // 
            this.tbModeAutoManual.Location = new System.Drawing.Point(41, 113);
            this.tbModeAutoManual.MinimumSize = new System.Drawing.Size(45, 22);
            this.tbModeAutoManual.Name = "tbModeAutoManual";
            this.tbModeAutoManual.OffBackColor = System.Drawing.Color.Gray;
            this.tbModeAutoManual.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tbModeAutoManual.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.tbModeAutoManual.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tbModeAutoManual.Size = new System.Drawing.Size(140, 63);
            this.tbModeAutoManual.TabIndex = 47;
            this.tbModeAutoManual.UseVisualStyleBackColor = true;
            this.tbModeAutoManual.CheckedChanged += new System.EventHandler(this.tbModeAutoManual_CheckedChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1669, 1050);
            this.Controls.Add(this.gbNavegacion);
            this.Controls.Add(this.gbComandos);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.chartEspectro);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.Text = "Registrador Serie FFT/FHT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartEspectro)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbComandos.ResumeLayout(false);
            this.gbComandos.PerformLayout();
            this.gbNavegacion.ResumeLayout(false);
            this.gbNavegacion.PerformLayout();
            this.gbMovementCommands.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartEspectro;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnIniciarDetener;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPuertos;
        private System.Windows.Forms.CheckBox chkRetener;
        private System.Windows.Forms.Button btnVerNotas;
        private System.Windows.Forms.Button btnNotasAVG;
        private System.Windows.Forms.GroupBox gbComandos;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnSensoresDist;
        private System.Windows.Forms.GroupBox gbNavegacion;
        private CustomControls.RJControls.ToggleButton tbModeAutoManual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnReconocNotas;
        private System.Windows.Forms.GroupBox gbMovementCommands;
        private System.Windows.Forms.Button btnSpeedUp;
        private System.Windows.Forms.Button btnSpeedDown;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnTurnRight;
        private System.Windows.Forms.Button btnTurnLeft;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.TextBox txtCommand;
    }
}

