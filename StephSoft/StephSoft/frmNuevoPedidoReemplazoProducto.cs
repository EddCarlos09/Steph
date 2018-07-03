using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using StephSoft.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephSoft
{
    public partial class frmNuevoPedidoReemplazoProducto : Form
    {
        private PedidoDetalle _Datos;
        public PedidoDetalle Datos
        {
            get { return _Datos; }
            set { _Datos = value; }
        }

        private Producto Actual = new Producto();

        public frmNuevoPedidoReemplazoProducto()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoReemplazoProducto ~ frmNuevoPedidoReemplazoProducto()");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                int TipoForm = 0;
                if (string.IsNullOrEmpty(this.ObtenerEmpleado().IDEmpleado))
                    TipoForm = 8;
                else
                    TipoForm = 6;
                frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(TipoForm);
                ElegirProducto.Location = this.txtProducto.PointToScreen(new Point());
                ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                ElegirProducto.ShowDialog();
                ElegirProducto.Dispose();
                if (ElegirProducto.DialogResult == DialogResult.OK)
                {
                    Producto Aux = ElegirProducto.Datos;
                    Actual = Aux;
                    this.txtProducto.Text = Aux.NombreProducto;
                    this.CargarComboClaves();
                    this.btnGuardar.Focus();
                }
                else
                {
                    this.CargarComboClaves();
                    this.Actual = new Producto();
                    this.txtProducto.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ btnElegirProducto_Click");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMensajeError.Visible = false;
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    this._Datos = this.ObtenerDatos();
                    this.DialogResult = DialogResult.OK;
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.CargarComboClaves();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ cmbEmpleados_SelectedIndexChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoPedidoProducto_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ frmNuevoPedidoProducto_Load");
            }
        }

        private void CargarComboEmpleados()
        {
            try
            {
                Usuario DatosAux = new Usuario { IncluirSelect = true, Conexion = Comun.Conexion, IDSucursalActual = Comun.IDSucursalCaja };
                Usuario_Negocio UN = new Usuario_Negocio();
                this.cmbEmpleados.DisplayMember = "Nombre";
                this.cmbEmpleados.ValueMember = "IDEmpleado";
                this.cmbEmpleados.DataSource = UN.LlenarComboCatEmpleadosPedidos(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboClaves()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.Actual.IDProducto))
                {
                    Usuario DatosUsuario = ObtenerEmpleado();
                    PedidoDetalle Datos = new PedidoDetalle { Conexion = Comun.Conexion, IDEmpleado = DatosUsuario.IDEmpleado, IDSucursal = Comun.IDSucursalCaja, IDProducto = this.Actual.IDProducto };
                    Pedido_Negocio PedNeg = new Pedido_Negocio();
                    this.cmbClaves.DataSource = PedNeg.ObtenerComboClavesProduccion(Datos);
                    this.cmbClaves.DisplayMember = "ClaveProduccion";
                    this.cmbClaves.ValueMember = "IDAsignacion";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.CargarComboEmpleados();
                this.txtProducto.Text = string.Empty;
                this.Actual = new Producto();
                this.ActiveControl = this.btnElegirProducto;
                this.btnElegirProducto.Focus();
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MostrarMensajeError(List<Error> Errores)
        {
            try
            {
                string cadenaErrores = string.Empty;
                cadenaErrores = "No se pudo guardar la información. Se presentaron los siguientes errores: \r\n";
                foreach (Error item in Errores)
                {
                    cadenaErrores += item.Numero + "\t" + item.Descripcion + "\r\n";
                }
                this.txtMensajeError.Visible = true;
                this.txtMensajeError.Text = cadenaErrores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private PedidoDetalle ObtenerDatos()
        {
            try
            {
                PedidoDetalle Datos = new PedidoDetalle();
                Datos.IDProducto = Actual.IDProducto;
                Datos.NombreProducto = Actual.NombreProducto;
                Datos.ClaveProducto = Actual.Clave;
                Datos.Cantidad = 1;
                Usuario DatosEmpleado = this.ObtenerEmpleado();
                PedidoDetalle Clave = this.ObtenerClaveSeleccionada();
                if (!string.IsNullOrEmpty(DatosEmpleado.IDEmpleado))
                {
                    Datos.IDEmpleado = DatosEmpleado.IDEmpleado;
                    Datos.NombreEmpleado = DatosEmpleado.Nombre;
                }
                else
                {
                    Datos.IDEmpleado = string.Empty;
                    Datos.NombreEmpleado = string.Empty;
                }
                if (!string.IsNullOrEmpty(Clave.IDAsignacion))
                {
                    Datos.IDAsignacion = Clave.IDAsignacion;
                    Datos.ClaveProduccion = Clave.ClaveProduccion;
                }
                else
                {
                    Datos.IDAsignacion = string.Empty;
                    Datos.ClaveProduccion = string.Empty;
                }
                
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Usuario ObtenerEmpleado()
        {
            try
            {
                Usuario DatosCombo = new Usuario();
                if (this.cmbEmpleados.Items.Count > 0)
                {
                    if (this.cmbEmpleados.SelectedIndex != -1)
                    {
                        DatosCombo = (Usuario)this.cmbEmpleados.SelectedItem;
                    }
                }
                return DatosCombo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private PedidoDetalle ObtenerClaveSeleccionada()
        {
            try
            {
                PedidoDetalle DatosClaves = new PedidoDetalle();
                if (this.cmbClaves.Items.Count > 0)
                {
                    if (this.cmbClaves.SelectedIndex != -1)
                    {
                        DatosClaves = (PedidoDetalle)this.cmbClaves.SelectedItem;
                    }
                }
                return DatosClaves;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                if (string.IsNullOrEmpty(this.Actual.IDProducto))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un producto.", ControlSender = this.btnElegirProducto });
                if (this.cmbEmpleados.SelectedIndex == -1)
                {
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un empleado.", ControlSender = this.cmbEmpleados });
                }
                PedidoDetalle AuxClave = this.ObtenerClaveSeleccionada();
                if(string.IsNullOrEmpty(AuxClave.IDAsignacion))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una clave de producto.", ControlSender = this.btnElegirProducto });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
