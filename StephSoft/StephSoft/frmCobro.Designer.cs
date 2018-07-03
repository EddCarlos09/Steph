namespace StephSoft
{
    partial class frmCobro
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMensajeError = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnRemoverVale = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.txtValeAplicado = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtErrorVale = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.btnAplicarVale = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVale = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.txtMonedero = new System.Windows.Forms.TextBox();
            this.txtNumTarjeta = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPuntosObtenidos = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label42 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCobrar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCancelar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.txtMensajeError);
            this.panel2.Controls.Add(this.btnCobrar);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 608);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 80);
            this.panel2.TabIndex = 1;
            // 
            // txtMensajeError
            // 
            this.txtMensajeError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMensajeError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensajeError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensajeError.Location = new System.Drawing.Point(40, 6);
            this.txtMensajeError.Multiline = true;
            this.txtMensajeError.Name = "txtMensajeError";
            this.txtMensajeError.ReadOnly = true;
            this.txtMensajeError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajeError.Size = new System.Drawing.Size(689, 69);
            this.txtMensajeError.TabIndex = 62;
            this.txtMensajeError.Text = "Ocurrió un Error";
            this.txtMensajeError.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 528);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 179);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1008, 349);
            this.panel5.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1008, 349);
            this.panel7.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.btnRemoverVale);
            this.panel8.Controls.Add(this.txtValeAplicado);
            this.panel8.Controls.Add(this.label16);
            this.panel8.Controls.Add(this.txtErrorVale);
            this.panel8.Controls.Add(this.txtTotal);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.txtDescuento);
            this.panel8.Controls.Add(this.btnAplicarVale);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.txtVale);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.label13);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.txtSubtotal);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1008, 349);
            this.panel8.TabIndex = 0;
            // 
            // btnRemoverVale
            // 
            this.btnRemoverVale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnRemoverVale.BorderColor = System.Drawing.Color.Red;
            this.btnRemoverVale.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnRemoverVale.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemoverVale.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnRemoverVale.FocusRectangle = true;
            this.btnRemoverVale.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoverVale.ForeColor = System.Drawing.Color.Black;
            this.btnRemoverVale.Image = null;
            this.btnRemoverVale.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemoverVale.ImageBorderColor = System.Drawing.Color.Red;
            this.btnRemoverVale.ImageFocused = null;
            this.btnRemoverVale.ImageInactive = null;
            this.btnRemoverVale.ImageMouseOver = null;
            this.btnRemoverVale.ImageNormal = null;
            this.btnRemoverVale.ImagePressed = null;
            this.btnRemoverVale.ImageSize = new System.Drawing.Size(44, 44);
            this.btnRemoverVale.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnRemoverVale.KeyButtonView = false;
            this.btnRemoverVale.Location = new System.Drawing.Point(500, 160);
            this.btnRemoverVale.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnRemoverVale.MouseOverColor = System.Drawing.Color.Red;
            this.btnRemoverVale.Name = "btnRemoverVale";
            this.btnRemoverVale.OffsetPressedContent = true;
            this.btnRemoverVale.Size = new System.Drawing.Size(27, 25);
            this.btnRemoverVale.TabIndex = 3;
            this.btnRemoverVale.Text = "X";
            this.btnRemoverVale.TextDropShadow = true;
            this.btnRemoverVale.UseVisualStyleBackColor = false;
            // 
            // txtValeAplicado
            // 
            this.txtValeAplicado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValeAplicado.Location = new System.Drawing.Point(270, 160);
            this.txtValeAplicado.MaxLength = 25;
            this.txtValeAplicado.Name = "txtValeAplicado";
            this.txtValeAplicado.ReadOnly = true;
            this.txtValeAplicado.Size = new System.Drawing.Size(231, 24);
            this.txtValeAplicado.TabIndex = 12154;
            this.txtValeAplicado.TabStop = false;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(80, 160);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(150, 22);
            this.label16.TabIndex = 12146;
            this.label16.Text = "Vale aplicado";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtErrorVale
            // 
            this.txtErrorVale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtErrorVale.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtErrorVale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrorVale.Location = new System.Drawing.Point(270, 90);
            this.txtErrorVale.Multiline = true;
            this.txtErrorVale.Name = "txtErrorVale";
            this.txtErrorVale.ReadOnly = true;
            this.txtErrorVale.Size = new System.Drawing.Size(331, 43);
            this.txtErrorVale.TabIndex = 12158;
            this.txtErrorVale.Text = "Ocurrió un Error";
            this.txtErrorVale.Visible = false;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(650, 285);
            this.txtTotal.MaxLength = 25;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(270, 40);
            this.txtTotal.TabIndex = 12142;
            this.txtTotal.TabStop = false;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(80, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 22);
            this.label5.TabIndex = 12154;
            this.label5.Text = "Código del vale:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescuento
            // 
            this.txtDescuento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(350, 285);
            this.txtDescuento.MaxLength = 25;
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(270, 40);
            this.txtDescuento.TabIndex = 12144;
            this.txtDescuento.TabStop = false;
            this.txtDescuento.Text = "0.00";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAplicarVale
            // 
            this.btnAplicarVale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAplicarVale.BorderColor = System.Drawing.Color.Red;
            this.btnAplicarVale.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAplicarVale.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAplicarVale.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnAplicarVale.FocusRectangle = true;
            this.btnAplicarVale.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarVale.ForeColor = System.Drawing.Color.Black;
            this.btnAplicarVale.Image = null;
            this.btnAplicarVale.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAplicarVale.ImageBorderColor = System.Drawing.Color.Red;
            this.btnAplicarVale.ImageFocused = null;
            this.btnAplicarVale.ImageInactive = null;
            this.btnAplicarVale.ImageMouseOver = null;
            this.btnAplicarVale.ImageNormal = null;
            this.btnAplicarVale.ImagePressed = null;
            this.btnAplicarVale.ImageSize = new System.Drawing.Size(44, 44);
            this.btnAplicarVale.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnAplicarVale.KeyButtonView = false;
            this.btnAplicarVale.Location = new System.Drawing.Point(500, 60);
            this.btnAplicarVale.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAplicarVale.MouseOverColor = System.Drawing.Color.Red;
            this.btnAplicarVale.Name = "btnAplicarVale";
            this.btnAplicarVale.OffsetPressedContent = true;
            this.btnAplicarVale.Size = new System.Drawing.Size(100, 25);
            this.btnAplicarVale.TabIndex = 2;
            this.btnAplicarVale.Text = "Aplicar";
            this.btnAplicarVale.TextDropShadow = true;
            this.btnAplicarVale.UseVisualStyleBackColor = false;
            this.btnAplicarVale.Click += new System.EventHandler(this.btnAplicarVale_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(650, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 45);
            this.label4.TabIndex = 99;
            this.label4.Text = "TOTAL A PAGAR";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtVale
            // 
            this.txtVale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVale.Location = new System.Drawing.Point(270, 60);
            this.txtVale.MaxLength = 20;
            this.txtVale.Name = "txtVale";
            this.txtVale.Size = new System.Drawing.Size(231, 24);
            this.txtVale.TabIndex = 1;
            this.txtVale.TabStop = false;
            this.txtVale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVale_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 45);
            this.label3.TabIndex = 94;
            this.label3.Text = "SUBTOTAL";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 50);
            this.label13.TabIndex = 12156;
            this.label13.Text = "VALES";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(350, 240);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(270, 45);
            this.label11.TabIndex = 12145;
            this.label11.Text = "DESCUENTO";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Location = new System.Drawing.Point(50, 285);
            this.txtSubtotal.MaxLength = 25;
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(270, 40);
            this.txtSubtotal.TabIndex = 5;
            this.txtSubtotal.TabStop = false;
            this.txtSubtotal.Text = "0.00";
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtNombreCliente);
            this.panel4.Controls.Add(this.txtMonedero);
            this.panel4.Controls.Add(this.txtNumTarjeta);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtPuntosObtenidos);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 179);
            this.panel4.TabIndex = 0;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.Location = new System.Drawing.Point(270, 41);
            this.txtNombreCliente.MaxLength = 300;
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(489, 24);
            this.txtNombreCliente.TabIndex = 12147;
            this.txtNombreCliente.TabStop = false;
            // 
            // txtMonedero
            // 
            this.txtMonedero.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMonedero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonedero.Location = new System.Drawing.Point(270, 102);
            this.txtMonedero.MaxLength = 25;
            this.txtMonedero.Name = "txtMonedero";
            this.txtMonedero.ReadOnly = true;
            this.txtMonedero.Size = new System.Drawing.Size(140, 24);
            this.txtMonedero.TabIndex = 102;
            this.txtMonedero.TabStop = false;
            this.txtMonedero.Text = "0.00";
            this.txtMonedero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNumTarjeta
            // 
            this.txtNumTarjeta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNumTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumTarjeta.Location = new System.Drawing.Point(270, 71);
            this.txtNumTarjeta.MaxLength = 25;
            this.txtNumTarjeta.Name = "txtNumTarjeta";
            this.txtNumTarjeta.ReadOnly = true;
            this.txtNumTarjeta.Size = new System.Drawing.Size(140, 24);
            this.txtNumTarjeta.TabIndex = 12153;
            this.txtNumTarjeta.TabStop = false;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(80, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 22);
            this.label12.TabIndex = 12146;
            this.label12.Text = "Cliente:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(420, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 22);
            this.label7.TabIndex = 100;
            this.label7.Text = "Puntos obtenidos:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPuntosObtenidos
            // 
            this.txtPuntosObtenidos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPuntosObtenidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuntosObtenidos.Location = new System.Drawing.Point(610, 102);
            this.txtPuntosObtenidos.MaxLength = 25;
            this.txtPuntosObtenidos.Name = "txtPuntosObtenidos";
            this.txtPuntosObtenidos.ReadOnly = true;
            this.txtPuntosObtenidos.Size = new System.Drawing.Size(149, 24);
            this.txtPuntosObtenidos.TabIndex = 103;
            this.txtPuntosObtenidos.TabStop = false;
            this.txtPuntosObtenidos.Text = "0.00";
            this.txtPuntosObtenidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(80, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(150, 22);
            this.label15.TabIndex = 12152;
            this.label15.Text = "Num. Tarjeta:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(80, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 22);
            this.label6.TabIndex = 101;
            this.label6.Text = "Monedero:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(21, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(238, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Resumen";
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
            this.btnCobrar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnCobrar.KeyButtonView = false;
            this.btnCobrar.Location = new System.Drawing.Point(829, 6);
            this.btnCobrar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCobrar.MouseOverColor = System.Drawing.Color.Red;
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.OffsetPressedContent = true;
            this.btnCobrar.Size = new System.Drawing.Size(80, 70);
            this.btnCobrar.TabIndex = 4;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.TextDropShadow = true;
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(913, 6);
            this.btnCancelar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelar.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OffsetPressedContent = true;
            this.btnCancelar.Size = new System.Drawing.Size(80, 70);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar y Regresar al Menú");
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            // frmCobro
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
            this.Name = "frmCobro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph V.10";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCobro_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCobrar;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtMensajeError;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtNumTarjeta;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPuntosObtenidos;
        private System.Windows.Forms.TextBox txtMonedero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtVale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValeAplicado;
        private System.Windows.Forms.Label label16;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnAplicarVale;
        private System.Windows.Forms.TextBox txtErrorVale;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnRemoverVale;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

