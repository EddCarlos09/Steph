using CreativaSL.Dll.StephSoft.Negocio;
using CreativaSL.Dll.StephSoft.Global;
using StephSoft;
using StephSoft.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StephSoft
{
    public partial class frmNuevoTicket : Form
    {
        private Cliente Actual = new Cliente();
        private Venta _DatosVenta;
        public Venta DatosVenta
        {
            get { return _DatosVenta; }
            set { _DatosVenta = value; }
        }

        public frmNuevoTicket()
        {
            try
            {
                InitializeComponent();
                this._DatosVenta = new Venta();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTicket ~ frmNuevoTicket()");
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
                LogError.AddExcFileTxt(ex, "frmNuevoTicket ~ btnElegirCliente_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarCliente ElegirCliente = new frmSeleccionarCliente();
                ElegirCliente.Location = this.txtCliente.PointToScreen(new Point());
                ElegirCliente.Location = new Point(ElegirCliente.Location.X - 1, ElegirCliente.Location.Y - 2);
                ElegirCliente.ShowDialog();
                ElegirCliente.Dispose();
                if (ElegirCliente.DialogResult == DialogResult.OK)
                {
                    Cliente Aux = ElegirCliente.Datos;
                    Actual = Aux;
                    this.txtCliente.Text = Aux.Nombre;
                    this.label3.Text = Aux.Padecimientos;
                    this.btnGuardar.Focus();
                }
                else
                {
                    this.Actual = new Cliente();
                    this.txtCliente.Text = string.Empty;
                         
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTicket ~ btnElegirCliente_Click");
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
                    Venta Datos = this.ObtenerDatos();
                    Venta_Negocio VN = new Venta_Negocio();
                    VN.InsertarNuevaVentaAbierta(Datos);
                    if (Datos.Completado)
                    {
                        this.DialogResult = DialogResult.OK;
                        this._DatosVenta = Datos;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al crear una nueva venta. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTicket ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoTicket_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTicket ~ frmNuevoTicket_Load");
            }
        }

        private void IniciarForm()
        {
            try
            {                
                this.ActiveControl = this.btnElegirCliente;
                this.btnElegirCliente.Focus();
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

        private Venta ObtenerDatos()
        {
            try
            {
                Venta Datos = new Venta();
                Datos.IDCliente = this.Actual.IDCliente;
                Datos.IDCaja = Comun.CajaAbierta ? Comun.IDCaja : string.Empty;
                Datos.IDSucursal = Comun.IDSucursalCaja;
                Datos.IDUsuario = Comun.IDUsuario;
                Datos.Conexion = Comun.Conexion;
                return Datos;
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
                if (string.IsNullOrEmpty(this.Actual.IDCliente))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un cliente.", ControlSender = this.btnElegirCliente });                
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmNuevoTicket_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Escape)
                    this.btnCancelar_Click(this.btnCancelar, new EventArgs());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTicket ~ frmNuevoTicket_KeyUp");
            }
        }

    }
}
