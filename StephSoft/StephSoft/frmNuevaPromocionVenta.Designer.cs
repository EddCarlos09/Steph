namespace StephSoft
{
    partial class frmNuevaPromocionVenta
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGuardar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCancelar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.txtMensajeError = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPromociones = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvServiciosPromocion = new System.Windows.Forms.DataGridView();
            this.pedidoDetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.productoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IDPromocion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDPromocionDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDPromocionDetalleProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosPromocion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidoDetalleBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(205)))), ((int)(((byte)(215)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label42);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 80);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(600, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(21, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(456, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Agregar Promoción";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.txtMensajeError);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 458);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(750, 80);
            this.panel2.TabIndex = 1;
            this.toolTip1.SetToolTip(this.panel2, "Guardar la información");
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnGuardar.BorderColor = System.Drawing.Color.Red;
            this.btnGuardar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnGuardar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGuardar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnGuardar.FocusRectangle = true;
            this.btnGuardar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = null;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnGuardar.ImageFocused = null;
            this.btnGuardar.ImageInactive = null;
            this.btnGuardar.ImageMouseOver = global::StephSoft.Properties.Resources._0000s_0000s_0003_guardar_a;
            this.btnGuardar.ImageNormal = global::StephSoft.Properties.Resources._0000s_0000s_0003_guardar;
            this.btnGuardar.ImagePressed = null;
            this.btnGuardar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnGuardar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnGuardar.KeyButtonView = false;
            this.btnGuardar.Location = new System.Drawing.Point(575, 5);
            this.btnGuardar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnGuardar.MouseOverColor = System.Drawing.Color.Red;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OffsetPressedContent = true;
            this.btnGuardar.Size = new System.Drawing.Size(80, 70);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextDropShadow = true;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCancelar.BorderColor = System.Drawing.Color.Red;
            this.btnCancelar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCancelar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnCancelar.FocusRectangle = true;
            this.btnCancelar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = null;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnCancelar.ImageFocused = null;
            this.btnCancelar.ImageInactive = null;
            this.btnCancelar.ImageMouseOver = global::StephSoft.Properties.Resources._0000s_0000s_0002_cancelar_a;
            this.btnCancelar.ImageNormal = global::StephSoft.Properties.Resources._0000s_0000s_0002_cancelar;
            this.btnCancelar.ImagePressed = null;
            this.btnCancelar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnCancelar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnCancelar.KeyButtonView = false;
            this.btnCancelar.Location = new System.Drawing.Point(659, 5);
            this.btnCancelar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelar.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OffsetPressedContent = true;
            this.btnCancelar.Size = new System.Drawing.Size(80, 70);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar y Regresar al Menú");
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtMensajeError
            // 
            this.txtMensajeError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMensajeError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensajeError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensajeError.Location = new System.Drawing.Point(12, 6);
            this.txtMensajeError.Multiline = true;
            this.txtMensajeError.Name = "txtMensajeError";
            this.txtMensajeError.ReadOnly = true;
            this.txtMensajeError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajeError.Size = new System.Drawing.Size(533, 69);
            this.txtMensajeError.TabIndex = 63;
            this.txtMensajeError.Text = "Ocurrió un Error";
            this.txtMensajeError.Visible = false;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.cmbPromociones);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.dgvServiciosPromocion);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(750, 378);
            this.panel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(16, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 173;
            this.label1.Text = "*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPromociones
            // 
            this.cmbPromociones.FormattingEnabled = true;
            this.cmbPromociones.Location = new System.Drawing.Point(31, 33);
            this.cmbPromociones.Name = "cmbPromociones";
            this.cmbPromociones.Size = new System.Drawing.Size(284, 28);
            this.cmbPromociones.TabIndex = 170;
            this.cmbPromociones.SelectedValueChanged += new System.EventHandler(this.cmbPromociones_SelectedValueChanged);
            this.cmbPromociones.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPromociones_Validating);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(16, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 20);
            this.label10.TabIndex = 171;
            this.label10.Text = "*";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(52, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(207, 20);
            this.label9.TabIndex = 172;
            this.label9.Text = "Promoción";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(52, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(309, 20);
            this.label3.TabIndex = 169;
            this.label3.Text = "Servicios que incluye";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvServiciosPromocion
            // 
            this.dgvServiciosPromocion.AllowUserToAddRows = false;
            this.dgvServiciosPromocion.AllowUserToDeleteRows = false;
            this.dgvServiciosPromocion.AllowUserToOrderColumns = true;
            this.dgvServiciosPromocion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServiciosPromocion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvServiciosPromocion.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvServiciosPromocion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiciosPromocion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPromocion,
            this.IDPromocionDetalle,
            this.IDPromocionDetalleProd,
            this.IDServicio,
            this.Servicio,
            this.Empleado});
            this.dgvServiciosPromocion.Location = new System.Drawing.Point(31, 101);
            this.dgvServiciosPromocion.Name = "dgvServiciosPromocion";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosPromocion.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServiciosPromocion.Size = new System.Drawing.Size(681, 237);
            this.dgvServiciosPromocion.TabIndex = 168;
            // 
            // pedidoDetalleBindingSource
            // 
            this.pedidoDetalleBindingSource.DataSource = typeof(CreativaSL.Dll.StephSoft.Global.PedidoDetalle);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(750, 378);
            this.panel3.TabIndex = 2;
            // 
            // productoBindingSource
            // 
            this.productoBindingSource.DataSource = typeof(CreativaSL.Dll.StephSoft.Global.Producto);
            // 
            // IDPromocion
            // 
            this.IDPromocion.DataPropertyName = "IDPromocion";
            this.IDPromocion.HeaderText = "IDPromocion";
            this.IDPromocion.Name = "IDPromocion";
            this.IDPromocion.ReadOnly = true;
            this.IDPromocion.Visible = false;
            // 
            // IDPromocionDetalle
            // 
            this.IDPromocionDetalle.DataPropertyName = "IDPromocionDetalle";
            this.IDPromocionDetalle.HeaderText = "IDPromocionDetalle";
            this.IDPromocionDetalle.Name = "IDPromocionDetalle";
            this.IDPromocionDetalle.ReadOnly = true;
            this.IDPromocionDetalle.Visible = false;
            // 
            // IDPromocionDetalleProd
            // 
            this.IDPromocionDetalleProd.DataPropertyName = "IDPromocionDetalleProd";
            this.IDPromocionDetalleProd.HeaderText = "IDPromocionDetalleProd";
            this.IDPromocionDetalleProd.Name = "IDPromocionDetalleProd";
            this.IDPromocionDetalleProd.ReadOnly = true;
            this.IDPromocionDetalleProd.Visible = false;
            // 
            // IDServicio
            // 
            this.IDServicio.DataPropertyName = "IDServicio";
            this.IDServicio.HeaderText = "IDServicio";
            this.IDServicio.Name = "IDServicio";
            this.IDServicio.Visible = false;
            // 
            // Servicio
            // 
            this.Servicio.DataPropertyName = "NombreProducto";
            this.Servicio.HeaderText = "Servicio";
            this.Servicio.Name = "Servicio";
            this.Servicio.Width = 250;
            // 
            // Empleado
            // 
            this.Empleado.DisplayStyleForCurrentCellOnly = true;
            this.Empleado.HeaderText = "Empleado";
            this.Empleado.Name = "Empleado";
            this.Empleado.Width = 350;
            // 
            // frmNuevaPromocionVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(750, 538);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(830, 600);
            this.Name = "frmNuevaPromocionVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmNuevaPromocionVenta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosPromocion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidoDetalleBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtMensajeError;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnGuardar;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvServiciosPromocion;
        private System.Windows.Forms.ComboBox cmbPromociones;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource pedidoDetalleBindingSource;
        private System.Windows.Forms.BindingSource productoBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPromocion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPromocionDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPromocionDetalleProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Servicio;
        private System.Windows.Forms.DataGridViewComboBoxColumn Empleado;
    }
}

