namespace StephSoft
{
    partial class frmVentaServicios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblFolio = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMensajeError = new System.Windows.Forms.TextBox();
            this.btnCobrar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnRegresar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.btnConcluirServicio = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCancelarServicio = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnAgregarServicio = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.IDVentaServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDEstatusServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoExtra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concluido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TimerTiempo = new System.Windows.Forms.Timer(this.components);
            this.bgwDibujarTiempo = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(205)))), ((int)(((byte)(215)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblFolio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 80);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(857, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolio.ForeColor = System.Drawing.Color.White;
            this.lblFolio.Location = new System.Drawing.Point(21, 9);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(540, 55);
            this.lblFolio.TabIndex = 24;
            this.lblFolio.Text = "Ticket 201701030001X";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.txtMensajeError);
            this.panel2.Controls.Add(this.btnCobrar);
            this.panel2.Controls.Add(this.btnRegresar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 608);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 80);
            this.panel2.TabIndex = 1;
            this.toolTip1.SetToolTip(this.panel2, "Guardar la información");
            // 
            // txtMensajeError
            // 
            this.txtMensajeError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMensajeError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensajeError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensajeError.Location = new System.Drawing.Point(8, 8);
            this.txtMensajeError.Multiline = true;
            this.txtMensajeError.Name = "txtMensajeError";
            this.txtMensajeError.ReadOnly = true;
            this.txtMensajeError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajeError.Size = new System.Drawing.Size(802, 68);
            this.txtMensajeError.TabIndex = 63;
            this.txtMensajeError.Text = "Ocurrió un Error";
            this.txtMensajeError.Visible = false;
            // 
            // btnCobrar
            // 
            this.btnCobrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCobrar.BorderColor = System.Drawing.Color.Red;
            this.btnCobrar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCobrar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCobrar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnCobrar.FocusRectangle = true;
            this.btnCobrar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.ForeColor = System.Drawing.Color.White;
            this.btnCobrar.Image = null;
            this.btnCobrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCobrar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnCobrar.ImageFocused = null;
            this.btnCobrar.ImageInactive = null;
            this.btnCobrar.ImageMouseOver = global::StephSoft.Properties.Resources._0000s_0001s_0017_nomina_a;
            this.btnCobrar.ImageNormal = global::StephSoft.Properties.Resources._0000s_0001s_0017_nomina;
            this.btnCobrar.ImagePressed = null;
            this.btnCobrar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnCobrar.KeyButton = System.Windows.Forms.Keys.None;
            this.btnCobrar.KeyButtonView = false;
            this.btnCobrar.Location = new System.Drawing.Point(830, 6);
            this.btnCobrar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCobrar.MouseOverColor = System.Drawing.Color.Red;
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.OffsetPressedContent = true;
            this.btnCobrar.Size = new System.Drawing.Size(80, 70);
            this.btnCobrar.TabIndex = 123;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.TextDropShadow = true;
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnRegresar.BorderColor = System.Drawing.Color.Red;
            this.btnRegresar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnRegresar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRegresar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnRegresar.FocusRectangle = true;
            this.btnRegresar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Image = null;
            this.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRegresar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnRegresar.ImageFocused = null;
            this.btnRegresar.ImageInactive = null;
            this.btnRegresar.ImageMouseOver = global::StephSoft.Properties.Resources._0000s_0000s_0006_regresr_a;
            this.btnRegresar.ImageNormal = global::StephSoft.Properties.Resources._0000s_0000s_0006_regresr;
            this.btnRegresar.ImagePressed = null;
            this.btnRegresar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnRegresar.KeyButton = System.Windows.Forms.Keys.None;
            this.btnRegresar.KeyButtonView = false;
            this.btnRegresar.Location = new System.Drawing.Point(916, 7);
            this.btnRegresar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnRegresar.MouseOverColor = System.Drawing.Color.Red;
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.OffsetPressedContent = true;
            this.btnRegresar.Size = new System.Drawing.Size(80, 70);
            this.btnRegresar.TabIndex = 15;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnRegresar, "Cancelar y Regresar al Menú");
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtNombreCliente);
            this.panel3.Controls.Add(this.btnConcluirServicio);
            this.panel3.Controls.Add(this.btnCancelarServicio);
            this.panel3.Controls.Add(this.btnAgregarServicio);
            this.panel3.Controls.Add(this.dgvServicios);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 528);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(228, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 124;
            this.label2.Text = "Cliente";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(311, 15);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(427, 25);
            this.txtNombreCliente.TabIndex = 123;
            // 
            // btnConcluirServicio
            // 
            this.btnConcluirServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnConcluirServicio.BorderColor = System.Drawing.Color.Red;
            this.btnConcluirServicio.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnConcluirServicio.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnConcluirServicio.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnConcluirServicio.FocusRectangle = true;
            this.btnConcluirServicio.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConcluirServicio.ForeColor = System.Drawing.Color.Black;
            this.btnConcluirServicio.Image = null;
            this.btnConcluirServicio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConcluirServicio.ImageBorderColor = System.Drawing.Color.Red;
            this.btnConcluirServicio.ImageFocused = null;
            this.btnConcluirServicio.ImageInactive = null;
            this.btnConcluirServicio.ImageMouseOver = null;
            this.btnConcluirServicio.ImageNormal = null;
            this.btnConcluirServicio.ImagePressed = null;
            this.btnConcluirServicio.ImageSize = new System.Drawing.Size(44, 44);
            this.btnConcluirServicio.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnConcluirServicio.KeyButtonView = false;
            this.btnConcluirServicio.Location = new System.Drawing.Point(88, 15);
            this.btnConcluirServicio.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnConcluirServicio.MouseOverColor = System.Drawing.Color.Red;
            this.btnConcluirServicio.Name = "btnConcluirServicio";
            this.btnConcluirServicio.OffsetPressedContent = true;
            this.btnConcluirServicio.Size = new System.Drawing.Size(116, 29);
            this.btnConcluirServicio.TabIndex = 122;
            this.btnConcluirServicio.Text = "Concluir servicio";
            this.btnConcluirServicio.TextDropShadow = true;
            this.btnConcluirServicio.UseVisualStyleBackColor = false;
            this.btnConcluirServicio.Click += new System.EventHandler(this.btnConcluirServicio_Click);
            // 
            // btnCancelarServicio
            // 
            this.btnCancelarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCancelarServicio.BorderColor = System.Drawing.Color.Red;
            this.btnCancelarServicio.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCancelarServicio.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelarServicio.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnCancelarServicio.FocusRectangle = true;
            this.btnCancelarServicio.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarServicio.ForeColor = System.Drawing.Color.Black;
            this.btnCancelarServicio.Image = null;
            this.btnCancelarServicio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelarServicio.ImageBorderColor = System.Drawing.Color.Red;
            this.btnCancelarServicio.ImageFocused = null;
            this.btnCancelarServicio.ImageInactive = null;
            this.btnCancelarServicio.ImageMouseOver = null;
            this.btnCancelarServicio.ImageNormal = null;
            this.btnCancelarServicio.ImagePressed = null;
            this.btnCancelarServicio.ImageSize = new System.Drawing.Size(44, 44);
            this.btnCancelarServicio.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnCancelarServicio.KeyButtonView = false;
            this.btnCancelarServicio.Location = new System.Drawing.Point(48, 15);
            this.btnCancelarServicio.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelarServicio.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancelarServicio.Name = "btnCancelarServicio";
            this.btnCancelarServicio.OffsetPressedContent = true;
            this.btnCancelarServicio.Size = new System.Drawing.Size(34, 29);
            this.btnCancelarServicio.TabIndex = 121;
            this.btnCancelarServicio.Text = "-";
            this.btnCancelarServicio.TextDropShadow = true;
            this.btnCancelarServicio.UseVisualStyleBackColor = false;
            this.btnCancelarServicio.Click += new System.EventHandler(this.btnCancelarServicio_Click);
            // 
            // btnAgregarServicio
            // 
            this.btnAgregarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarServicio.BorderColor = System.Drawing.Color.Red;
            this.btnAgregarServicio.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarServicio.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAgregarServicio.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnAgregarServicio.FocusRectangle = true;
            this.btnAgregarServicio.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarServicio.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarServicio.Image = null;
            this.btnAgregarServicio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarServicio.ImageBorderColor = System.Drawing.Color.Red;
            this.btnAgregarServicio.ImageFocused = null;
            this.btnAgregarServicio.ImageInactive = null;
            this.btnAgregarServicio.ImageMouseOver = null;
            this.btnAgregarServicio.ImageNormal = null;
            this.btnAgregarServicio.ImagePressed = null;
            this.btnAgregarServicio.ImageSize = new System.Drawing.Size(44, 44);
            this.btnAgregarServicio.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnAgregarServicio.KeyButtonView = false;
            this.btnAgregarServicio.Location = new System.Drawing.Point(8, 15);
            this.btnAgregarServicio.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAgregarServicio.MouseOverColor = System.Drawing.Color.Red;
            this.btnAgregarServicio.Name = "btnAgregarServicio";
            this.btnAgregarServicio.OffsetPressedContent = true;
            this.btnAgregarServicio.Size = new System.Drawing.Size(34, 29);
            this.btnAgregarServicio.TabIndex = 120;
            this.btnAgregarServicio.Text = "+";
            this.btnAgregarServicio.TextDropShadow = true;
            this.btnAgregarServicio.UseVisualStyleBackColor = false;
            this.btnAgregarServicio.Click += new System.EventHandler(this.btnAgregarServicio_Click);
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.AllowUserToOrderColumns = true;
            this.dgvServicios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServicios.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDVentaServicio,
            this.IDServicio,
            this.Clave,
            this.NombreServicio,
            this.IDEmpleado,
            this.NombreEmpleado,
            this.IDEstatusServicio,
            this.Estatus,
            this.HoraInicio,
            this.HoraFin,
            this.Tiempo,
            this.Importe,
            this.CostoExtra,
            this.Total,
            this.Concluido});
            this.dgvServicios.Location = new System.Drawing.Point(8, 71);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicios.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicios.Size = new System.Drawing.Size(988, 451);
            this.dgvServicios.TabIndex = 116;
            this.dgvServicios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellContentDoubleClick);
            // 
            // IDVentaServicio
            // 
            this.IDVentaServicio.DataPropertyName = "IDVentaServicio";
            this.IDVentaServicio.HeaderText = "IDVentaServicio";
            this.IDVentaServicio.Name = "IDVentaServicio";
            this.IDVentaServicio.ReadOnly = true;
            this.IDVentaServicio.Visible = false;
            // 
            // IDServicio
            // 
            this.IDServicio.DataPropertyName = "IDServicio";
            this.IDServicio.HeaderText = "IDServicio";
            this.IDServicio.Name = "IDServicio";
            this.IDServicio.ReadOnly = true;
            this.IDServicio.Visible = false;
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "Clave";
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            // 
            // NombreServicio
            // 
            this.NombreServicio.DataPropertyName = "NombreServicio";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.NombreServicio.DefaultCellStyle = dataGridViewCellStyle1;
            this.NombreServicio.HeaderText = "Servicio";
            this.NombreServicio.Name = "NombreServicio";
            this.NombreServicio.ReadOnly = true;
            this.NombreServicio.Width = 205;
            // 
            // IDEmpleado
            // 
            this.IDEmpleado.DataPropertyName = "IDEmpleado";
            this.IDEmpleado.HeaderText = "IDEmpleado";
            this.IDEmpleado.Name = "IDEmpleado";
            this.IDEmpleado.ReadOnly = true;
            this.IDEmpleado.Visible = false;
            // 
            // NombreEmpleado
            // 
            this.NombreEmpleado.DataPropertyName = "NombreEmpleado";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.NombreEmpleado.DefaultCellStyle = dataGridViewCellStyle2;
            this.NombreEmpleado.HeaderText = "Empleado";
            this.NombreEmpleado.Name = "NombreEmpleado";
            this.NombreEmpleado.ReadOnly = true;
            this.NombreEmpleado.Width = 190;
            // 
            // IDEstatusServicio
            // 
            this.IDEstatusServicio.DataPropertyName = "IDEstatus";
            this.IDEstatusServicio.HeaderText = "IDEstatusServicio";
            this.IDEstatusServicio.Name = "IDEstatusServicio";
            this.IDEstatusServicio.ReadOnly = true;
            this.IDEstatusServicio.Visible = false;
            // 
            // Estatus
            // 
            this.Estatus.DataPropertyName = "Estatus";
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.Width = 85;
            // 
            // HoraInicio
            // 
            this.HoraInicio.DataPropertyName = "HoraInicio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "HH:mm:ss";
            this.HoraInicio.DefaultCellStyle = dataGridViewCellStyle3;
            this.HoraInicio.HeaderText = "Hora Inicio";
            this.HoraInicio.Name = "HoraInicio";
            this.HoraInicio.ReadOnly = true;
            this.HoraInicio.Width = 85;
            // 
            // HoraFin
            // 
            this.HoraFin.DataPropertyName = "HoraFin";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.HoraFin.DefaultCellStyle = dataGridViewCellStyle4;
            this.HoraFin.HeaderText = "Hora de Término";
            this.HoraFin.Name = "HoraFin";
            this.HoraFin.ReadOnly = true;
            this.HoraFin.Width = 85;
            // 
            // Tiempo
            // 
            this.Tiempo.DataPropertyName = "Tiempo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Tiempo.DefaultCellStyle = dataGridViewCellStyle5;
            this.Tiempo.HeaderText = "Tiempo total";
            this.Tiempo.Name = "Tiempo";
            this.Tiempo.ReadOnly = true;
            this.Tiempo.Width = 95;
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "c";
            dataGridViewCellStyle6.NullValue = "0";
            this.Importe.DefaultCellStyle = dataGridViewCellStyle6;
            this.Importe.HeaderText = "Precio";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.Width = 85;
            // 
            // CostoExtra
            // 
            this.CostoExtra.DataPropertyName = "MontoExtra";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "c";
            dataGridViewCellStyle7.NullValue = "0";
            this.CostoExtra.DefaultCellStyle = dataGridViewCellStyle7;
            this.CostoExtra.HeaderText = "Costo Extra";
            this.CostoExtra.Name = "CostoExtra";
            this.CostoExtra.ReadOnly = true;
            this.CostoExtra.Width = 80;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "c";
            dataGridViewCellStyle8.NullValue = "0";
            this.Total.DefaultCellStyle = dataGridViewCellStyle8;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 95;
            // 
            // Concluido
            // 
            this.Concluido.DataPropertyName = "Concluido";
            this.Concluido.HeaderText = "Concluido";
            this.Concluido.Name = "Concluido";
            this.Concluido.ReadOnly = true;
            this.Concluido.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Concluido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Concluido.Visible = false;
            // 
            // TimerTiempo
            // 
            this.TimerTiempo.Interval = 1000;
            this.TimerTiempo.Tick += new System.EventHandler(this.TimerTiempo_Tick);
            // 
            // bgwDibujarTiempo
            // 
            this.bgwDibujarTiempo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDibujarTiempo_DoWork);
            this.bgwDibujarTiempo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDibujarTiempo_RunWorkerCompleted);
            // 
            // frmVentaServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 688);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "frmVentaServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph V.10";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDatosServicio_FormClosing);
            this.Load += new System.EventHandler(this.frmDatosServicio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnRegresar;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtMensajeError;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvServicios;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCobrar;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnConcluirServicio;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelarServicio;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnAgregarServicio;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer TimerTiempo;
        private System.ComponentModel.BackgroundWorker bgwDibujarTiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDVentaServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDEstatusServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoExtra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Concluido;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

