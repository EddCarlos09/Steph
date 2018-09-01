namespace StephSoft
{
    partial class frmClavesXIDEmpleado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCrearClave = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnBaja = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnReemplazar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCancelar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBuscar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreEmpleado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoEmpleado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvClaves = new System.Windows.Forms.DataGridView();
            this.Fila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDAsignacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaveProduccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Metrica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadMetrica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MargenError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadUsos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadConsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasTranscurridos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AplicaMetrica = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CumpleMetrica = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label42 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnInicializar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClaves)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.btnInicializar);
            this.panel2.Controls.Add(this.btnCrearClave);
            this.panel2.Controls.Add(this.btnBaja);
            this.panel2.Controls.Add(this.btnReemplazar);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 608);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 80);
            this.panel2.TabIndex = 1;
            this.toolTip1.SetToolTip(this.panel2, "Guardar la información");
            // 
            // btnCrearClave
            // 
            this.btnCrearClave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrearClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCrearClave.BorderColor = System.Drawing.Color.Red;
            this.btnCrearClave.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCrearClave.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCrearClave.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnCrearClave.FocusRectangle = true;
            this.btnCrearClave.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearClave.ForeColor = System.Drawing.Color.White;
            this.btnCrearClave.Image = null;
            this.btnCrearClave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrearClave.ImageBorderColor = System.Drawing.Color.Red;
            this.btnCrearClave.ImageFocused = null;
            this.btnCrearClave.ImageInactive = null;
            this.btnCrearClave.ImageMouseOver = null;
            this.btnCrearClave.ImageNormal = null;
            this.btnCrearClave.ImagePressed = null;
            this.btnCrearClave.ImageSize = new System.Drawing.Size(44, 44);
            this.btnCrearClave.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnCrearClave.KeyButtonView = false;
            this.btnCrearClave.Location = new System.Drawing.Point(655, 6);
            this.btnCrearClave.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCrearClave.MouseOverColor = System.Drawing.Color.Red;
            this.btnCrearClave.Name = "btnCrearClave";
            this.btnCrearClave.OffsetPressedContent = true;
            this.btnCrearClave.Size = new System.Drawing.Size(80, 70);
            this.btnCrearClave.TabIndex = 38;
            this.btnCrearClave.Text = "Entregar";
            this.btnCrearClave.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnCrearClave, "Generar nuevas claves");
            this.btnCrearClave.UseVisualStyleBackColor = true;
            this.btnCrearClave.Click += new System.EventHandler(this.btnCrearClave_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnBaja.BorderColor = System.Drawing.Color.Red;
            this.btnBaja.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnBaja.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBaja.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnBaja.FocusRectangle = true;
            this.btnBaja.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaja.ForeColor = System.Drawing.Color.White;
            this.btnBaja.Image = null;
            this.btnBaja.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBaja.ImageBorderColor = System.Drawing.Color.Red;
            this.btnBaja.ImageFocused = null;
            this.btnBaja.ImageInactive = null;
            this.btnBaja.ImageMouseOver = null;
            this.btnBaja.ImageNormal = null;
            this.btnBaja.ImagePressed = null;
            this.btnBaja.ImageSize = new System.Drawing.Size(44, 44);
            this.btnBaja.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnBaja.KeyButtonView = false;
            this.btnBaja.Location = new System.Drawing.Point(741, 6);
            this.btnBaja.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBaja.MouseOverColor = System.Drawing.Color.Red;
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.OffsetPressedContent = true;
            this.btnBaja.Size = new System.Drawing.Size(80, 70);
            this.btnBaja.TabIndex = 37;
            this.btnBaja.Text = "Baja";
            this.btnBaja.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnBaja, "Dar de baja clave");
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnReemplazar
            // 
            this.btnReemplazar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReemplazar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnReemplazar.BorderColor = System.Drawing.Color.Red;
            this.btnReemplazar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnReemplazar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReemplazar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnReemplazar.FocusRectangle = true;
            this.btnReemplazar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReemplazar.ForeColor = System.Drawing.Color.White;
            this.btnReemplazar.Image = null;
            this.btnReemplazar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReemplazar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnReemplazar.ImageFocused = null;
            this.btnReemplazar.ImageInactive = null;
            this.btnReemplazar.ImageMouseOver = null;
            this.btnReemplazar.ImageNormal = null;
            this.btnReemplazar.ImagePressed = null;
            this.btnReemplazar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnReemplazar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnReemplazar.KeyButtonView = false;
            this.btnReemplazar.Location = new System.Drawing.Point(827, 6);
            this.btnReemplazar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnReemplazar.MouseOverColor = System.Drawing.Color.Red;
            this.btnReemplazar.Name = "btnReemplazar";
            this.btnReemplazar.OffsetPressedContent = true;
            this.btnReemplazar.Size = new System.Drawing.Size(80, 70);
            this.btnReemplazar.TabIndex = 36;
            this.btnReemplazar.Text = "Reemplazar";
            this.btnReemplazar.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnReemplazar, "Reemplazar clave");
            this.btnReemplazar.UseVisualStyleBackColor = true;
            this.btnReemplazar.Click += new System.EventHandler(this.btnReemplazar_Click);
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
            this.btnCancelar.ImageMouseOver = global::StephSoft.Properties.Resources._0000s_0001s_0000_salir_a;
            this.btnCancelar.ImageNormal = global::StephSoft.Properties.Resources._0000s_0001s_0000_salir;
            this.btnCancelar.ImagePressed = null;
            this.btnCancelar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnCancelar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnCancelar.KeyButtonView = false;
            this.btnCancelar.Location = new System.Drawing.Point(913, 6);
            this.btnCancelar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelar.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OffsetPressedContent = true;
            this.btnCancelar.Size = new System.Drawing.Size(80, 70);
            this.btnCancelar.TabIndex = 35;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar y Regresar al Menú");
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.btnBuscar);
            this.panel3.Controls.Add(this.txtProducto);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtNombreEmpleado);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtCodigoEmpleado);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.dgvClaves);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 528);
            this.panel3.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnBuscar.BorderColor = System.Drawing.Color.Red;
            this.btnBuscar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnBuscar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBuscar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnBuscar.FocusRectangle = true;
            this.btnBuscar.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Image = null;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnBuscar.ImageFocused = null;
            this.btnBuscar.ImageInactive = null;
            this.btnBuscar.ImageMouseOver = null;
            this.btnBuscar.ImageNormal = null;
            this.btnBuscar.ImagePressed = null;
            this.btnBuscar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnBuscar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnBuscar.KeyButtonView = false;
            this.btnBuscar.Location = new System.Drawing.Point(485, 58);
            this.btnBuscar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBuscar.MouseOverColor = System.Drawing.Color.Red;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.OffsetPressedContent = true;
            this.btnBuscar.Size = new System.Drawing.Size(100, 25);
            this.btnBuscar.TabIndex = 121;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextDropShadow = true;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(120, 56);
            this.txtProducto.MaxLength = 180;
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(348, 25);
            this.txtProducto.TabIndex = 119;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 120;
            this.label2.Text = "Producto";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNombreEmpleado
            // 
            this.txtNombreEmpleado.Enabled = false;
            this.txtNombreEmpleado.Location = new System.Drawing.Point(422, 15);
            this.txtNombreEmpleado.MaxLength = 1000;
            this.txtNombreEmpleado.Name = "txtNombreEmpleado";
            this.txtNombreEmpleado.Size = new System.Drawing.Size(348, 25);
            this.txtNombreEmpleado.TabIndex = 117;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(314, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 118;
            this.label1.Text = "Empleado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodigoEmpleado
            // 
            this.txtCodigoEmpleado.Enabled = false;
            this.txtCodigoEmpleado.Location = new System.Drawing.Point(120, 13);
            this.txtCodigoEmpleado.MaxLength = 1000;
            this.txtCodigoEmpleado.Name = "txtCodigoEmpleado";
            this.txtCodigoEmpleado.Size = new System.Drawing.Size(130, 25);
            this.txtCodigoEmpleado.TabIndex = 115;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(17, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 116;
            this.label5.Text = "Código";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvClaves
            // 
            this.dgvClaves.AllowUserToAddRows = false;
            this.dgvClaves.AllowUserToDeleteRows = false;
            this.dgvClaves.AllowUserToResizeRows = false;
            this.dgvClaves.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClaves.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvClaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClaves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fila,
            this.IDAsignacion,
            this.Producto,
            this.ClaveProduccion,
            this.Metrica,
            this.CantidadMetrica,
            this.MargenError,
            this.CantidadUsos,
            this.CantidadConsumo,
            this.DiasTranscurridos,
            this.AplicaMetrica,
            this.CumpleMetrica,
            this.FechaInicio,
            this.FechaFin});
            this.dgvClaves.Location = new System.Drawing.Point(12, 103);
            this.dgvClaves.MultiSelect = false;
            this.dgvClaves.Name = "dgvClaves";
            this.dgvClaves.RowHeadersWidth = 20;
            this.dgvClaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClaves.Size = new System.Drawing.Size(981, 397);
            this.dgvClaves.TabIndex = 12;
            this.dgvClaves.Sorted += new System.EventHandler(this.dgvClaves_Sorted);
            // 
            // Fila
            // 
            this.Fila.DataPropertyName = "Fila";
            this.Fila.HeaderText = "";
            this.Fila.Name = "Fila";
            this.Fila.ReadOnly = true;
            this.Fila.Width = 30;
            // 
            // IDAsignacion
            // 
            this.IDAsignacion.DataPropertyName = "IDAsignacion";
            this.IDAsignacion.HeaderText = "IDAsignacion";
            this.IDAsignacion.Name = "IDAsignacion";
            this.IDAsignacion.ReadOnly = true;
            this.IDAsignacion.Visible = false;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "NombreProducto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 180;
            // 
            // ClaveProduccion
            // 
            this.ClaveProduccion.DataPropertyName = "ClaveProduccion";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ClaveProduccion.DefaultCellStyle = dataGridViewCellStyle7;
            this.ClaveProduccion.HeaderText = "Clave de Producción";
            this.ClaveProduccion.Name = "ClaveProduccion";
            this.ClaveProduccion.ReadOnly = true;
            this.ClaveProduccion.Width = 95;
            // 
            // Metrica
            // 
            this.Metrica.DataPropertyName = "Metrica";
            this.Metrica.HeaderText = "Métrica";
            this.Metrica.Name = "Metrica";
            this.Metrica.ReadOnly = true;
            this.Metrica.Width = 180;
            // 
            // CantidadMetrica
            // 
            this.CantidadMetrica.DataPropertyName = "CantidadMetrica";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CantidadMetrica.DefaultCellStyle = dataGridViewCellStyle8;
            this.CantidadMetrica.HeaderText = "Cantidad estimada";
            this.CantidadMetrica.Name = "CantidadMetrica";
            this.CantidadMetrica.ReadOnly = true;
            this.CantidadMetrica.Width = 110;
            // 
            // MargenError
            // 
            this.MargenError.DataPropertyName = "MargenError";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MargenError.DefaultCellStyle = dataGridViewCellStyle9;
            this.MargenError.HeaderText = "Margen de Error";
            this.MargenError.Name = "MargenError";
            this.MargenError.ReadOnly = true;
            // 
            // CantidadUsos
            // 
            this.CantidadUsos.DataPropertyName = "CantidadUsos";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CantidadUsos.DefaultCellStyle = dataGridViewCellStyle10;
            this.CantidadUsos.HeaderText = "Usos";
            this.CantidadUsos.Name = "CantidadUsos";
            this.CantidadUsos.ReadOnly = true;
            this.CantidadUsos.Width = 85;
            // 
            // CantidadConsumo
            // 
            this.CantidadConsumo.DataPropertyName = "CantidadConsumo";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CantidadConsumo.DefaultCellStyle = dataGridViewCellStyle11;
            this.CantidadConsumo.HeaderText = "Consumo";
            this.CantidadConsumo.Name = "CantidadConsumo";
            this.CantidadConsumo.ReadOnly = true;
            this.CantidadConsumo.Width = 90;
            // 
            // DiasTranscurridos
            // 
            this.DiasTranscurridos.DataPropertyName = "DiasTranscurridos";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DiasTranscurridos.DefaultCellStyle = dataGridViewCellStyle12;
            this.DiasTranscurridos.HeaderText = "Días transcurridos";
            this.DiasTranscurridos.Name = "DiasTranscurridos";
            this.DiasTranscurridos.ReadOnly = true;
            this.DiasTranscurridos.Width = 110;
            // 
            // AplicaMetrica
            // 
            this.AplicaMetrica.DataPropertyName = "AplicaMetrica";
            this.AplicaMetrica.HeaderText = "AplicaMetrica";
            this.AplicaMetrica.Name = "AplicaMetrica";
            this.AplicaMetrica.ReadOnly = true;
            this.AplicaMetrica.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AplicaMetrica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AplicaMetrica.Visible = false;
            // 
            // CumpleMetrica
            // 
            this.CumpleMetrica.DataPropertyName = "CumpleMetrica";
            this.CumpleMetrica.HeaderText = "¿Cumple Métrica?";
            this.CumpleMetrica.Name = "CumpleMetrica";
            this.CumpleMetrica.ReadOnly = true;
            this.CumpleMetrica.Visible = false;
            // 
            // FechaInicio
            // 
            this.FechaInicio.DataPropertyName = "FechaInicio";
            this.FechaInicio.HeaderText = "Fecha de Inicio";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            this.FechaInicio.Visible = false;
            // 
            // FechaFin
            // 
            this.FechaFin.DataPropertyName = "FechaFin";
            this.FechaFin.HeaderText = "Fecha de término";
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.ReadOnly = true;
            this.FechaFin.Visible = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(21, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(498, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Claves por empleado";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(205)))), ((int)(((byte)(215)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label42);
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
            this.pictureBox1.Location = new System.Drawing.Point(851, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // btnInicializar
            // 
            this.btnInicializar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInicializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnInicializar.BorderColor = System.Drawing.Color.Red;
            this.btnInicializar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnInicializar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnInicializar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnInicializar.FocusRectangle = true;
            this.btnInicializar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicializar.ForeColor = System.Drawing.Color.White;
            this.btnInicializar.Image = null;
            this.btnInicializar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInicializar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnInicializar.ImageFocused = null;
            this.btnInicializar.ImageInactive = null;
            this.btnInicializar.ImageMouseOver = null;
            this.btnInicializar.ImageNormal = null;
            this.btnInicializar.ImagePressed = null;
            this.btnInicializar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnInicializar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnInicializar.KeyButtonView = false;
            this.btnInicializar.Location = new System.Drawing.Point(569, 7);
            this.btnInicializar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnInicializar.MouseOverColor = System.Drawing.Color.Red;
            this.btnInicializar.Name = "btnInicializar";
            this.btnInicializar.OffsetPressedContent = true;
            this.btnInicializar.Size = new System.Drawing.Size(80, 70);
            this.btnInicializar.TabIndex = 39;
            this.btnInicializar.Text = "Inicializar";
            this.btnInicializar.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnInicializar, "Generar nuevas claves");
            this.btnInicializar.UseVisualStyleBackColor = true;
            this.btnInicializar.Click += new System.EventHandler(this.btnInicializar_Click);
            // 
            // frmClavesXIDEmpleado
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
            this.Name = "frmClavesXIDEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph V.10";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmClavesXIDEmpleado_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClaves)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dgvClaves;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCodigoEmpleado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombreEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label label2;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fila;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDAsignacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaveProduccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Metrica;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadMetrica;
        private System.Windows.Forms.DataGridViewTextBoxColumn MargenError;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadUsos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadConsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasTranscurridos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AplicaMetrica;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CumpleMetrica;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCrearClave;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBaja;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnReemplazar;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnInicializar;
    }
}

