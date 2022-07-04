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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.chartEspectro = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtEnviarAlIniciar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnVerNotas = new System.Windows.Forms.Button();
            this.chkRetener = new System.Windows.Forms.CheckBox();
            this.btnIniciarDetener = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPuertos = new System.Windows.Forms.ComboBox();
            this.gbComandos = new System.Windows.Forms.GroupBox();
            this.chkModo = new System.Windows.Forms.CheckBox();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnTurnLeft = new System.Windows.Forms.Button();
            this.btnTurnRight = new System.Windows.Forms.Button();
            this.Conectar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartEspectro)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.gbComandos.SuspendLayout();
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
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Name = "Muestras";
            this.chartEspectro.Series.Add(series1);
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
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txtEnviarAlIniciar);
            this.groupBox3.Controls.Add(this.label9);
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1383, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 45);
            this.button1.TabIndex = 21;
            this.button1.Text = "&Notas AVG";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEnviarAlIniciar
            // 
            this.txtEnviarAlIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnviarAlIniciar.Location = new System.Drawing.Point(838, 34);
            this.txtEnviarAlIniciar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEnviarAlIniciar.Name = "txtEnviarAlIniciar";
            this.txtEnviarAlIniciar.Size = new System.Drawing.Size(218, 35);
            this.txtEnviarAlIniciar.TabIndex = 20;
            this.txtEnviarAlIniciar.Text = "f";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(834, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(244, 26);
            this.label9.TabIndex = 19;
            this.label9.Text = "Enviar al Iniciar la com.";
            // 
            // btnVerNotas
            // 
            this.btnVerNotas.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerNotas.Location = new System.Drawing.Point(1250, 22);
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
            this.chkRetener.AutoSize = true;
            this.chkRetener.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetener.Location = new System.Drawing.Point(1078, 20);
            this.chkRetener.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkRetener.Name = "chkRetener";
            this.chkRetener.Size = new System.Drawing.Size(151, 39);
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
            this.btnIniciarDetener.Size = new System.Drawing.Size(224, 46);
            this.btnIniciarDetener.TabIndex = 16;
            this.btnIniciarDetener.Text = "&Iniciar Lectura";
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
            this.gbComandos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbComandos.Controls.Add(this.chkModo);
            this.gbComandos.Controls.Add(this.btnReverse);
            this.gbComandos.Controls.Add(this.btnForward);
            this.gbComandos.Controls.Add(this.btnTurnLeft);
            this.gbComandos.Controls.Add(this.btnTurnRight);
            this.gbComandos.Controls.Add(this.Conectar);
            this.gbComandos.Controls.Add(this.button2);
            this.gbComandos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbComandos.Location = new System.Drawing.Point(1429, 98);
            this.gbComandos.Name = "gbComandos";
            this.gbComandos.Size = new System.Drawing.Size(228, 874);
            this.gbComandos.TabIndex = 16;
            this.gbComandos.TabStop = false;
            this.gbComandos.Text = "Comandos";
            // 
            // chkModo
            // 
            this.chkModo.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkModo.AutoSize = true;
            this.chkModo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkModo.Location = new System.Drawing.Point(29, 490);
            this.chkModo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkModo.Name = "chkModo";
            this.chkModo.Size = new System.Drawing.Size(180, 39);
            this.chkModo.TabIndex = 40;
            this.chkModo.Text = "&Modo Manual";
            this.chkModo.UseVisualStyleBackColor = true;
            this.chkModo.CheckedChanged += new System.EventHandler(this.chkModo_CheckedChanged);
            // 
            // btnReverse
            // 
            this.btnReverse.BackgroundImage = global::Registrador_FFT.Properties.Resources.arrow_down;
            this.btnReverse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReverse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReverse.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReverse.Location = new System.Drawing.Point(65, 762);
            this.btnReverse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(96, 97);
            this.btnReverse.TabIndex = 38;
            this.btnReverse.Text = "Rev.";
            this.btnReverse.UseVisualStyleBackColor = true;
            // 
            // btnForward
            // 
            this.btnForward.BackgroundImage = global::Registrador_FFT.Properties.Resources.arrow_up;
            this.btnForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForward.ForeColor = System.Drawing.Color.White;
            this.btnForward.Location = new System.Drawing.Point(64, 556);
            this.btnForward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(96, 97);
            this.btnForward.TabIndex = 37;
            this.btnForward.Text = "Forw.";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnTurnLeft
            // 
            this.btnTurnLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTurnLeft.BackgroundImage")));
            this.btnTurnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTurnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTurnLeft.ForeColor = System.Drawing.Color.White;
            this.btnTurnLeft.Location = new System.Drawing.Point(8, 661);
            this.btnTurnLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTurnLeft.Name = "btnTurnLeft";
            this.btnTurnLeft.Size = new System.Drawing.Size(96, 97);
            this.btnTurnLeft.TabIndex = 36;
            this.btnTurnLeft.Text = "Left";
            this.btnTurnLeft.UseVisualStyleBackColor = true;
            // 
            // btnTurnRight
            // 
            this.btnTurnRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTurnRight.BackgroundImage")));
            this.btnTurnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTurnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTurnRight.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTurnRight.Location = new System.Drawing.Point(127, 661);
            this.btnTurnRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTurnRight.Name = "btnTurnRight";
            this.btnTurnRight.Size = new System.Drawing.Size(96, 97);
            this.btnTurnRight.TabIndex = 35;
            this.btnTurnRight.Text = "Right";
            this.btnTurnRight.UseVisualStyleBackColor = true;
            // 
            // Conectar
            // 
            this.Conectar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Conectar.Location = new System.Drawing.Point(16, 44);
            this.Conectar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Conectar.Name = "Conectar";
            this.Conectar.Size = new System.Drawing.Size(205, 46);
            this.Conectar.TabIndex = 17;
            this.Conectar.Text = "Enviar Comandos";
            this.Conectar.UseVisualStyleBackColor = true;
            this.Conectar.Click += new System.EventHandler(this.Conectar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 153);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(206, 66);
            this.button2.TabIndex = 0;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1669, 1050);
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEnviarAlIniciar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbComandos;
        private System.Windows.Forms.Button Conectar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnTurnLeft;
        private System.Windows.Forms.Button btnTurnRight;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.CheckBox chkModo;
    }
}

