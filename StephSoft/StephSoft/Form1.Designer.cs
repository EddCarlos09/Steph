namespace StephSoft
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.IDPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDEstatusPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstatusPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surtido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FechaPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.btnModificar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnNuevo = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnDetallePedido = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnProcesarPedido = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnSalir = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCancelar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelarBusq = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label42 = new System.Windows.Forms.Label();
            this.button_Creativa1 = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.panel7.SuspendLayout();
            this.PanelMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
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
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 608);
            this.panel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 70);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1008, 538);
            this.panel5.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1008, 458);
            this.panel8.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.AutoScroll = true;
            this.panel12.Controls.Add(this.dgvPedidos);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1008, 458);
            this.panel12.TabIndex = 2;
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.AllowUserToResizeRows = false;
            this.dgvPedidos.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPedido,
            this.IDEstatusPedido,
            this.Folio,
            this.EstatusPedido,
            this.Sucursal,
            this.Surtido,
            this.FechaPedido,
            this.Empleado});
            this.dgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidos.Location = new System.Drawing.Point(0, 0);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(1008, 458);
            this.dgvPedidos.TabIndex = 12;
            // 
            // IDPedido
            // 
            this.IDPedido.DataPropertyName = "IDPedido";
            this.IDPedido.HeaderText = "IDPedido";
            this.IDPedido.Name = "IDPedido";
            this.IDPedido.ReadOnly = true;
            this.IDPedido.Visible = false;
            // 
            // IDEstatusPedido
            // 
            this.IDEstatusPedido.DataPropertyName = "IDEstatusPedido";
            this.IDEstatusPedido.HeaderText = "IDEstatusPedido";
            this.IDEstatusPedido.Name = "IDEstatusPedido";
            this.IDEstatusPedido.ReadOnly = true;
            this.IDEstatusPedido.Visible = false;
            // 
            // Folio
            // 
            this.Folio.DataPropertyName = "Folio";
            this.Folio.HeaderText = "Folio";
            this.Folio.Name = "Folio";
            this.Folio.ReadOnly = true;
            this.Folio.Width = 150;
            // 
            // EstatusPedido
            // 
            this.EstatusPedido.DataPropertyName = "EstatusPedido";
            this.EstatusPedido.HeaderText = "Estatus";
            this.EstatusPedido.Name = "EstatusPedido";
            this.EstatusPedido.ReadOnly = true;
            // 
            // Sucursal
            // 
            this.Sucursal.DataPropertyName = "NombreSucursal";
            this.Sucursal.HeaderText = "Sucursal";
            this.Sucursal.Name = "Sucursal";
            this.Sucursal.ReadOnly = true;
            this.Sucursal.Width = 250;
            // 
            // Surtido
            // 
            this.Surtido.DataPropertyName = "Completo";
            this.Surtido.HeaderText = "Surtido";
            this.Surtido.Name = "Surtido";
            this.Surtido.ReadOnly = true;
            this.Surtido.Width = 120;
            // 
            // FechaPedido
            // 
            this.FechaPedido.DataPropertyName = "FechaPedido";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.FechaPedido.DefaultCellStyle = dataGridViewCellStyle1;
            this.FechaPedido.HeaderText = "Fecha de Pedido";
            this.FechaPedido.Name = "FechaPedido";
            this.FechaPedido.ReadOnly = true;
            this.FechaPedido.Width = 160;
            // 
            // Empleado
            // 
            this.Empleado.DataPropertyName = "EmpleadoCaptura";
            this.Empleado.HeaderText = "Empleado que capturó";
            this.Empleado.Name = "Empleado";
            this.Empleado.ReadOnly = true;
            this.Empleado.Width = 280;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.PanelMenu);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 458);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1008, 80);
            this.panel7.TabIndex = 0;
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.PaleVioletRed;
            this.PanelMenu.Controls.Add(this.btnModificar);
            this.PanelMenu.Controls.Add(this.btnNuevo);
            this.PanelMenu.Controls.Add(this.btnDetallePedido);
            this.PanelMenu.Controls.Add(this.btnProcesarPedido);
            this.PanelMenu.Controls.Add(this.btnSalir);
            this.PanelMenu.Controls.Add(this.btnCancelar);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(1008, 80);
            this.PanelMenu.TabIndex = 1;
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnModificar.BackColor = System.Drawing.Color.Orchid;
            this.btnModificar.BorderColor = System.Drawing.Color.DeepPink;
            this.btnModificar.BorderFocusColor = System.Drawing.Color.Fuchsia;
            this.btnModificar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnModificar.BorderNoFocusColor = System.Drawing.Color.Purple;
            this.btnModificar.FocusRectangle = true;
            this.btnModificar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Image = null;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModificar.ImageBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnModificar.ImageFocused = null;
            this.btnModificar.ImageInactive = null;
            this.btnModificar.ImageMouseOver = null;
            this.btnModificar.ImageNormal = null;
            this.btnModificar.ImagePressed = null;
            this.btnModificar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnModificar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnModificar.KeyButtonView = false;
            this.btnModificar.Location = new System.Drawing.Point(564, 5);
            this.btnModificar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnModificar.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.OffsetPressedContent = true;
            this.btnModificar.Size = new System.Drawing.Size(80, 70);
            this.btnModificar.TabIndex = 24;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextDropShadow = true;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNuevo.BackColor = System.Drawing.Color.Orchid;
            this.btnNuevo.BorderColor = System.Drawing.Color.DeepPink;
            this.btnNuevo.BorderFocusColor = System.Drawing.Color.Fuchsia;
            this.btnNuevo.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnNuevo.BorderNoFocusColor = System.Drawing.Color.Purple;
            this.btnNuevo.FocusRectangle = true;
            this.btnNuevo.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = null;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevo.ImageBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnNuevo.ImageFocused = null;
            this.btnNuevo.ImageInactive = null;
            this.btnNuevo.ImageMouseOver = null;
            this.btnNuevo.ImageNormal = null;
            this.btnNuevo.ImagePressed = null;
            this.btnNuevo.ImageSize = new System.Drawing.Size(44, 44);
            this.btnNuevo.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnNuevo.KeyButtonView = false;
            this.btnNuevo.Location = new System.Drawing.Point(466, 5);
            this.btnNuevo.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnNuevo.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.OffsetPressedContent = true;
            this.btnNuevo.Size = new System.Drawing.Size(80, 70);
            this.btnNuevo.TabIndex = 23;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextDropShadow = true;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnDetallePedido
            // 
            this.btnDetallePedido.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDetallePedido.BackColor = System.Drawing.Color.Orchid;
            this.btnDetallePedido.BorderColor = System.Drawing.Color.DeepPink;
            this.btnDetallePedido.BorderFocusColor = System.Drawing.Color.Fuchsia;
            this.btnDetallePedido.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDetallePedido.BorderNoFocusColor = System.Drawing.Color.Purple;
            this.btnDetallePedido.FocusRectangle = true;
            this.btnDetallePedido.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetallePedido.ForeColor = System.Drawing.Color.White;
            this.btnDetallePedido.Image = null;
            this.btnDetallePedido.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDetallePedido.ImageBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDetallePedido.ImageFocused = null;
            this.btnDetallePedido.ImageInactive = null;
            this.btnDetallePedido.ImageMouseOver = null;
            this.btnDetallePedido.ImageNormal = null;
            this.btnDetallePedido.ImagePressed = null;
            this.btnDetallePedido.ImageSize = new System.Drawing.Size(44, 44);
            this.btnDetallePedido.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnDetallePedido.KeyButtonView = false;
            this.btnDetallePedido.Location = new System.Drawing.Point(822, 5);
            this.btnDetallePedido.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnDetallePedido.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDetallePedido.Name = "btnDetallePedido";
            this.btnDetallePedido.OffsetPressedContent = true;
            this.btnDetallePedido.Size = new System.Drawing.Size(80, 70);
            this.btnDetallePedido.TabIndex = 22;
            this.btnDetallePedido.Text = "Ver Detalle";
            this.btnDetallePedido.TextDropShadow = true;
            this.btnDetallePedido.UseVisualStyleBackColor = false;
            this.btnDetallePedido.Click += new System.EventHandler(this.btnDetallePedido_Click);
            // 
            // btnProcesarPedido
            // 
            this.btnProcesarPedido.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnProcesarPedido.BackColor = System.Drawing.Color.Orchid;
            this.btnProcesarPedido.BorderColor = System.Drawing.Color.DeepPink;
            this.btnProcesarPedido.BorderFocusColor = System.Drawing.Color.Fuchsia;
            this.btnProcesarPedido.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnProcesarPedido.BorderNoFocusColor = System.Drawing.Color.Purple;
            this.btnProcesarPedido.FocusRectangle = true;
            this.btnProcesarPedido.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesarPedido.ForeColor = System.Drawing.Color.White;
            this.btnProcesarPedido.Image = null;
            this.btnProcesarPedido.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProcesarPedido.ImageBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnProcesarPedido.ImageFocused = null;
            this.btnProcesarPedido.ImageInactive = null;
            this.btnProcesarPedido.ImageMouseOver = null;
            this.btnProcesarPedido.ImageNormal = null;
            this.btnProcesarPedido.ImagePressed = null;
            this.btnProcesarPedido.ImageSize = new System.Drawing.Size(44, 44);
            this.btnProcesarPedido.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnProcesarPedido.KeyButtonView = false;
            this.btnProcesarPedido.Location = new System.Drawing.Point(736, 5);
            this.btnProcesarPedido.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnProcesarPedido.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnProcesarPedido.Name = "btnProcesarPedido";
            this.btnProcesarPedido.OffsetPressedContent = true;
            this.btnProcesarPedido.Size = new System.Drawing.Size(80, 70);
            this.btnProcesarPedido.TabIndex = 21;
            this.btnProcesarPedido.Text = "Enviar";
            this.btnProcesarPedido.TextDropShadow = true;
            this.btnProcesarPedido.UseVisualStyleBackColor = false;
            this.btnProcesarPedido.Click += new System.EventHandler(this.btnProcesarPedido_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.BackColor = System.Drawing.Color.Orchid;
            this.btnSalir.BorderColor = System.Drawing.Color.DeepPink;
            this.btnSalir.BorderFocusColor = System.Drawing.Color.Fuchsia;
            this.btnSalir.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSalir.BorderNoFocusColor = System.Drawing.Color.Purple;
            this.btnSalir.FocusRectangle = true;
            this.btnSalir.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = null;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.ImageBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSalir.ImageFocused = null;
            this.btnSalir.ImageInactive = null;
            this.btnSalir.ImageMouseOver = null;
            this.btnSalir.ImageNormal = null;
            this.btnSalir.ImagePressed = null;
            this.btnSalir.ImageSize = new System.Drawing.Size(44, 44);
            this.btnSalir.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnSalir.KeyButtonView = false;
            this.btnSalir.Location = new System.Drawing.Point(908, 5);
            this.btnSalir.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSalir.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.OffsetPressedContent = true;
            this.btnSalir.Size = new System.Drawing.Size(80, 70);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextDropShadow = true;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.BackColor = System.Drawing.Color.Orchid;
            this.btnCancelar.BorderColor = System.Drawing.Color.DeepPink;
            this.btnCancelar.BorderFocusColor = System.Drawing.Color.Fuchsia;
            this.btnCancelar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCancelar.BorderNoFocusColor = System.Drawing.Color.Purple;
            this.btnCancelar.FocusRectangle = true;
            this.btnCancelar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = null;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.ImageBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCancelar.ImageFocused = null;
            this.btnCancelar.ImageInactive = null;
            this.btnCancelar.ImageMouseOver = null;
            this.btnCancelar.ImageNormal = null;
            this.btnCancelar.ImagePressed = null;
            this.btnCancelar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnCancelar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnCancelar.KeyButtonView = false;
            this.btnCancelar.Location = new System.Drawing.Point(650, 5);
            this.btnCancelar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelar.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OffsetPressedContent = true;
            this.btnCancelar.Size = new System.Drawing.Size(80, 70);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextDropShadow = true;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.button_Creativa1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.btnCancelarBusq);
            this.panel4.Controls.Add(this.dtpFecha);
            this.panel4.Controls.Add(this.btnBuscar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 70);
            this.panel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Script MT Bold", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(54, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 38);
            this.label2.TabIndex = 150;
            this.label2.Text = "Búsqueda";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Location = new System.Drawing.Point(284, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 20);
            this.label5.TabIndex = 148;
            this.label5.Text = "Fecha de pedido";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancelarBusq
            // 
            this.btnCancelarBusq.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelarBusq.BackColor = System.Drawing.Color.Orchid;
            this.btnCancelarBusq.BorderColor = System.Drawing.Color.DeepPink;
            this.btnCancelarBusq.BorderFocusColor = System.Drawing.Color.Fuchsia;
            this.btnCancelarBusq.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCancelarBusq.BorderNoFocusColor = System.Drawing.Color.Purple;
            this.btnCancelarBusq.FocusRectangle = true;
            this.btnCancelarBusq.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarBusq.ForeColor = System.Drawing.Color.Black;
            this.btnCancelarBusq.Image = null;
            this.btnCancelarBusq.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelarBusq.ImageBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCancelarBusq.ImageFocused = null;
            this.btnCancelarBusq.ImageInactive = null;
            this.btnCancelarBusq.ImageMouseOver = null;
            this.btnCancelarBusq.ImageNormal = null;
            this.btnCancelarBusq.ImagePressed = null;
            this.btnCancelarBusq.ImageSize = new System.Drawing.Size(44, 44);
            this.btnCancelarBusq.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnCancelarBusq.KeyButtonView = false;
            this.btnCancelarBusq.Location = new System.Drawing.Point(604, 32);
            this.btnCancelarBusq.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelarBusq.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCancelarBusq.Name = "btnCancelarBusq";
            this.btnCancelarBusq.OffsetPressedContent = true;
            this.btnCancelarBusq.Size = new System.Drawing.Size(23, 25);
            this.btnCancelarBusq.TabIndex = 18;
            this.btnCancelarBusq.Text = "X";
            this.btnCancelarBusq.TextDropShadow = true;
            this.btnCancelarBusq.UseVisualStyleBackColor = false;
            this.btnCancelarBusq.Click += new System.EventHandler(this.btnCancelarBusq_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(288, 32);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(155, 25);
            this.dtpFecha.TabIndex = 11;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscar.BackColor = System.Drawing.Color.Orchid;
            this.btnBuscar.BorderColor = System.Drawing.Color.DeepPink;
            this.btnBuscar.BorderFocusColor = System.Drawing.Color.Fuchsia;
            this.btnBuscar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBuscar.BorderNoFocusColor = System.Drawing.Color.Purple;
            this.btnBuscar.FocusRectangle = true;
            this.btnBuscar.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Image = null;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.ImageBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBuscar.ImageFocused = null;
            this.btnBuscar.ImageInactive = null;
            this.btnBuscar.ImageMouseOver = null;
            this.btnBuscar.ImageNormal = null;
            this.btnBuscar.ImagePressed = null;
            this.btnBuscar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnBuscar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnBuscar.KeyButtonView = false;
            this.btnBuscar.Location = new System.Drawing.Point(505, 32);
            this.btnBuscar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBuscar.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.OffsetPressedContent = true;
            this.btnBuscar.Size = new System.Drawing.Size(100, 25);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextDropShadow = true;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.panel6.BackColor = System.Drawing.Color.Plum;
            this.panel6.Controls.Add(this.label42);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1008, 80);
            this.panel6.TabIndex = 2;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Script MT Bold", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(21, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(177, 58);
            this.label42.TabIndex = 24;
            this.label42.Text = "Pedidos";
            // 
            // button_Creativa1
            // 
            this.button_Creativa1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Creativa1.BackColor = System.Drawing.Color.Orchid;
            this.button_Creativa1.BorderColor = System.Drawing.Color.DeepPink;
            this.button_Creativa1.BorderFocusColor = System.Drawing.Color.Fuchsia;
            this.button_Creativa1.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button_Creativa1.BorderNoFocusColor = System.Drawing.Color.Purple;
            this.button_Creativa1.FocusRectangle = true;
            this.button_Creativa1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Creativa1.ForeColor = System.Drawing.Color.Black;
            this.button_Creativa1.Image = null;
            this.button_Creativa1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Creativa1.ImageBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button_Creativa1.ImageFocused = null;
            this.button_Creativa1.ImageInactive = null;
            this.button_Creativa1.ImageMouseOver = null;
            this.button_Creativa1.ImageNormal = null;
            this.button_Creativa1.ImagePressed = null;
            this.button_Creativa1.ImageSize = new System.Drawing.Size(44, 44);
            this.button_Creativa1.KeyButton = System.Windows.Forms.Keys.F1;
            this.button_Creativa1.KeyButtonView = false;
            this.button_Creativa1.Location = new System.Drawing.Point(666, 32);
            this.button_Creativa1.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.button_Creativa1.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_Creativa1.Name = "button_Creativa1";
            this.button_Creativa1.OffsetPressedContent = true;
            this.button_Creativa1.Size = new System.Drawing.Size(23, 25);
            this.button_Creativa1.TabIndex = 151;
            this.button_Creativa1.Text = "X";
            this.button_Creativa1.TextDropShadow = true;
            this.button_Creativa1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 688);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPedidos_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.panel7.ResumeLayout(false);
            this.PanelMenu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel PanelMenu;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnSalir;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelar;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBuscar;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnProcesarPedido;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelarBusq;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnDetallePedido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDEstatusPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstatusPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sucursal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Surtido;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnModificar;
        private CreativaSL.LibControls.WinForms.Button_Creativa button_Creativa1;
    }
}

