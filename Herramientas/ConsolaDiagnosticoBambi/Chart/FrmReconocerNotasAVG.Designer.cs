namespace Registrador_FFT
{
    partial class FrmReconocerNotasAVG
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
            this.listBoxSalida = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudFPB = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.chkFiltroRepeticion = new System.Windows.Forms.CheckBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFPB)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxSalida
            // 
            this.listBoxSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSalida.FormattingEnabled = true;
            this.listBoxSalida.ItemHeight = 16;
            this.listBoxSalida.Location = new System.Drawing.Point(8, 10);
            this.listBoxSalida.Name = "listBoxSalida";
            this.listBoxSalida.Size = new System.Drawing.Size(443, 244);
            this.listBoxSalida.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudFPB);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.chkFiltroRepeticion);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 272);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 50);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrado por Repetición";
            // 
            // nudFPB
            // 
            this.nudFPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFPB.Location = new System.Drawing.Point(166, 18);
            this.nudFPB.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.nudFPB.Name = "nudFPB";
            this.nudFPB.Size = new System.Drawing.Size(43, 26);
            this.nudFPB.TabIndex = 29;
            this.nudFPB.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(92, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 18);
            this.label10.TabIndex = 24;
            this.label10.Text = "N° Repet.";
            // 
            // chkFiltroRepeticion
            // 
            this.chkFiltroRepeticion.AutoSize = true;
            this.chkFiltroRepeticion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.chkFiltroRepeticion.Location = new System.Drawing.Point(11, 21);
            this.chkFiltroRepeticion.Name = "chkFiltroRepeticion";
            this.chkFiltroRepeticion.Size = new System.Drawing.Size(49, 22);
            this.chkFiltroRepeticion.TabIndex = 22;
            this.chkFiltroRepeticion.Text = "On";
            this.chkFiltroRepeticion.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(326, 336);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(125, 31);
            this.btnLimpiar.TabIndex = 22;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FrmReconocerNotasAVG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 376);
            this.Controls.Add(this.listBoxSalida);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLimpiar);
            this.Name = "FrmReconocerNotasAVG";
            this.Text = "FrmReconocerNotasAVG";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSalida;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudFPB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkFiltroRepeticion;
        private System.Windows.Forms.Button btnLimpiar;
    }
}