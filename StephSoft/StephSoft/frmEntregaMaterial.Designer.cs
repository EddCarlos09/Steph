namespace StephSoft
{
    partial class frmEntregaMaterial
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
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label42 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IDEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaveUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoPat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerMateriales = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnClavesSucursal = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnSalir = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            this.panel7.SuspendLayout();
            this.PanelMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
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
            this.panel5.Location = new System.Drawing.Point(0, 50);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1008, 558);
            this.panel5.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1008, 478);
            this.panel8.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.AutoScroll = true;
            this.panel12.Controls.Add(this.dgvUsuario);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1008, 478);
            this.panel12.TabIndex = 2;
            // 
            // dgvUsuario
            // 
            this.dgvUsuario.AllowUserToAddRows = false;
            this.dgvUsuario.AllowUserToDeleteRows = false;
            this.dgvUsuario.AllowUserToResizeRows = false;
            this.dgvUsuario.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDEmpleado,
            this.ClaveUsuario,
            this.Nombre,
            this.ApellidoPat,
            this.ApellidoMat,
            this.VerMateriales});
            this.dgvUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuario.Location = new System.Drawing.Point(0, 0);
            this.dgvUsuario.MultiSelect = false;
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuario.Size = new System.Drawing.Size(1008, 478);
            this.dgvUsuario.TabIndex = 1;
            this.dgvUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuario_CellContentClick);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.PanelMenu);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 478);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1008, 80);
            this.panel7.TabIndex = 0;
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.Gray;
            this.PanelMenu.Controls.Add(this.btnClavesSucursal);
            this.PanelMenu.Controls.Add(this.btnSalir);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(1008, 80);
            this.PanelMenu.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.panel10);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 50);
            this.panel4.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.DarkGray;
            this.panel10.Controls.Add(this.label2);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1008, 50);
            this.panel10.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(547, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 37);
            this.label1.TabIndex = 58;
            this.label1.Text = "Empleados";
            this.label1.Visible = false;
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
            this.btnBuscar.Location = new System.Drawing.Point(751, 21);
            this.btnBuscar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBuscar.MouseOverColor = System.Drawing.Color.Red;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.OffsetPressedContent = true;
            this.btnBuscar.Size = new System.Drawing.Size(100, 25);
            this.btnBuscar.TabIndex = 56;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextDropShadow = true;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Visible = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBusqueda.Location = new System.Drawing.Point(501, 39);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(350, 25);
            this.txtBusqueda.TabIndex = 13;
            this.txtBusqueda.Visible = false;
            this.txtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
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
            this.panel6.Controls.Add(this.label42);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Controls.Add(this.txtBusqueda);
            this.panel6.Controls.Add(this.btnBuscar);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1008, 80);
            this.panel6.TabIndex = 2;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(26, 12);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(515, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Entrega de materiales";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(1008, 50);
            this.label2.TabIndex = 59;
            this.label2.Text = "Seleccione un empleado para ver las claves asignadas.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IDEmpleado
            // 
            this.IDEmpleado.DataPropertyName = "IDEmpleado";
            this.IDEmpleado.HeaderText = "IDEmpleado";
            this.IDEmpleado.Name = "IDEmpleado";
            this.IDEmpleado.ReadOnly = true;
            this.IDEmpleado.Visible = false;
            // 
            // ClaveUsuario
            // 
            this.ClaveUsuario.DataPropertyName = "ClaveUsuario";
            this.ClaveUsuario.HeaderText = "Clave Empleado";
            this.ClaveUsuario.Name = "ClaveUsuario";
            this.ClaveUsuario.ReadOnly = true;
            this.ClaveUsuario.Width = 150;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 180;
            // 
            // ApellidoPat
            // 
            this.ApellidoPat.DataPropertyName = "ApellidoPat";
            this.ApellidoPat.HeaderText = "Apellido Paterno";
            this.ApellidoPat.Name = "ApellidoPat";
            this.ApellidoPat.ReadOnly = true;
            this.ApellidoPat.Width = 150;
            // 
            // ApellidoMat
            // 
            this.ApellidoMat.DataPropertyName = "ApellidoMat";
            this.ApellidoMat.HeaderText = "Apellido Materno";
            this.ApellidoMat.Name = "ApellidoMat";
            this.ApellidoMat.ReadOnly = true;
            this.ApellidoMat.Width = 150;
            // 
            // VerMateriales
            // 
            this.VerMateriales.HeaderText = "Ver materiales";
            this.VerMateriales.Name = "VerMateriales";
            this.VerMateriales.ReadOnly = true;
            this.VerMateriales.Text = "Ver Materiales";
            this.VerMateriales.UseColumnTextForButtonValue = true;
            this.VerMateriales.Width = 150;
            // 
            // btnClavesSucursal
            // 
            this.btnClavesSucursal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClavesSucursal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnClavesSucursal.BorderColor = System.Drawing.Color.Red;
            this.btnClavesSucursal.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnClavesSucursal.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClavesSucursal.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnClavesSucursal.FocusRectangle = true;
            this.btnClavesSucursal.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClavesSucursal.ForeColor = System.Drawing.Color.White;
            this.btnClavesSucursal.Image = null;
            this.btnClavesSucursal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClavesSucursal.ImageBorderColor = System.Drawing.Color.Red;
            this.btnClavesSucursal.ImageFocused = null;
            this.btnClavesSucursal.ImageInactive = null;
            this.btnClavesSucursal.ImageMouseOver = global::StephSoft.Properties.Resources.icons_steph_vino_ver_detalles_a;
            this.btnClavesSucursal.ImageNormal = global::StephSoft.Properties.Resources.icons_steph_vino_ver_detalles;
            this.btnClavesSucursal.ImagePressed = null;
            this.btnClavesSucursal.ImageSize = new System.Drawing.Size(44, 44);
            this.btnClavesSucursal.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnClavesSucursal.KeyButtonView = false;
            this.btnClavesSucursal.Location = new System.Drawing.Point(822, 5);
            this.btnClavesSucursal.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnClavesSucursal.MouseOverColor = System.Drawing.Color.Red;
            this.btnClavesSucursal.Name = "btnClavesSucursal";
            this.btnClavesSucursal.OffsetPressedContent = true;
            this.btnClavesSucursal.Size = new System.Drawing.Size(80, 70);
            this.btnClavesSucursal.TabIndex = 21;
            this.btnClavesSucursal.Text = "Sucursal";
            this.btnClavesSucursal.TextDropShadow = true;
            this.btnClavesSucursal.UseVisualStyleBackColor = false;
            this.btnClavesSucursal.Click += new System.EventHandler(this.btnClavesSucursal_Click);
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
            this.btnSalir.Location = new System.Drawing.Point(908, 5);
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
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(857, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // frmEntregaMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 688);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "frmEntregaMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEntregaMaterial_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            this.panel7.ResumeLayout(false);
            this.PanelMenu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel10;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBuscar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Panel PanelMenu;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnClavesSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaveUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoPat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoMat;
        private System.Windows.Forms.DataGridViewButtonColumn VerMateriales;
    }
}

