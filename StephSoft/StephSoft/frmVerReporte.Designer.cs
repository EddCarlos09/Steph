namespace StephSoft
{
    partial class frmVerReporte
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.btnGenerar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.btnSalir = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.PanelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 688);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 608);
            this.panel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1008, 608);
            this.panel5.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.reportViewer1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1008, 532);
            this.panel7.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DarkGray;
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.dtpFechaFin);
            this.panel8.Controls.Add(this.dtpFechaInicio);
            this.panel8.Controls.Add(this.lblFechaInicio);
            this.panel8.Controls.Add(this.btnGenerar);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1008, 76);
            this.panel8.TabIndex = 2;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(273, 24);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(119, 25);
            this.dtpFechaInicio.TabIndex = 63;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.ForeColor = System.Drawing.Color.Maroon;
            this.lblFechaInicio.Location = new System.Drawing.Point(231, 28);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(36, 20);
            this.lblFechaInicio.TabIndex = 62;
            this.lblFechaInicio.Text = "Del";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnGenerar.BorderColor = System.Drawing.Color.Red;
            this.btnGenerar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnGenerar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGenerar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnGenerar.FocusRectangle = true;
            this.btnGenerar.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.Black;
            this.btnGenerar.Image = null;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGenerar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnGenerar.ImageFocused = null;
            this.btnGenerar.ImageInactive = null;
            this.btnGenerar.ImageMouseOver = null;
            this.btnGenerar.ImageNormal = null;
            this.btnGenerar.ImagePressed = null;
            this.btnGenerar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnGenerar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnGenerar.KeyButtonView = false;
            this.btnGenerar.Location = new System.Drawing.Point(807, 4);
            this.btnGenerar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnGenerar.MouseOverColor = System.Drawing.Color.Red;
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.OffsetPressedContent = true;
            this.btnGenerar.Size = new System.Drawing.Size(80, 70);
            this.btnGenerar.TabIndex = 59;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextDropShadow = true;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1008, 532);
            this.reportViewer1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.PanelMenu);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 532);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 76);
            this.panel4.TabIndex = 0;
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.Gray;
            this.PanelMenu.Controls.Add(this.btnSalir);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(1008, 76);
            this.PanelMenu.TabIndex = 2;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnSalir.BorderColor = System.Drawing.Color.Red;
            this.btnSalir.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnSalir.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSalir.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnSalir.FocusRectangle = true;
            this.btnSalir.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = null;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.ImageBorderColor = System.Drawing.Color.Red;
            this.btnSalir.ImageFocused = null;
            this.btnSalir.ImageInactive = null;
            this.btnSalir.ImageMouseOver = global::StephSoft.Properties.Resources._0000s_0001s_0000_salir_a;
            this.btnSalir.ImageNormal = global::StephSoft.Properties.Resources._0000s_0001s_0000_salir;
            this.btnSalir.ImagePressed = null;
            this.btnSalir.ImageSize = new System.Drawing.Size(44, 44);
            this.btnSalir.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnSalir.KeyButtonView = false;
            this.btnSalir.Location = new System.Drawing.Point(908, 3);
            this.btnSalir.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSalir.MouseOverColor = System.Drawing.Color.Red;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.OffsetPressedContent = true;
            this.btnSalir.Size = new System.Drawing.Size(80, 70);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextDropShadow = true;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 80);
            this.panel2.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(205)))), ((int)(((byte)(215)))));
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Controls.Add(this.lblTitulo);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1008, 80);
            this.panel6.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(849, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(21, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 55);
            this.lblTitulo.TabIndex = 24;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(470, 24);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(119, 25);
            this.dtpFechaFin.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(421, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 20);
            this.label1.TabIndex = 65;
            this.label1.Text = "al";
            // 
            // frmVerReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 688);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "frmVerReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerReporte_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.PanelMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel PanelMenu;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaInicio;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnGenerar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
    }
}

