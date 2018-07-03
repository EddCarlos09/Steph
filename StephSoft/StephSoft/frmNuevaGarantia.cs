using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using StephSoft.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephSoft
{
    public partial class frmNuevaGarantia : Form
    {
        #region Variables

        private Venta Datos = new Venta();

        #endregion

        #region Constructor

        public frmNuevaGarantia(Venta DatosAux)
        {
            try
            {
                InitializeComponent();
                Datos = DatosAux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaGarantia ~ frmNuevaGarantia()");
            }
        }

        #endregion

        #region Métodos

        private void CargarGridVentaDetalle()
        {
            try
            {
                Venta DatosAux = new Venta { Conexion = Comun.Conexion, IDVenta = this.Datos.IDVenta };
                Venta_Negocio VN = new Venta_Negocio();
                VN.ObtenerDetalleVenta(DatosAux);
                this.dgvProductos.AutoGenerateColumns = false;
                this.dgvProductos.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTablaGarantiaDetalle()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDVentaDetalle", typeof(string));
                foreach (DataGridViewRow Fila in this.dgvProductos.SelectedRows)
                {
                    string IDVentaDetalleAux = Fila.Cells["IDVentaDetalle"].Value.ToString();
                    object[] NewRow = { IDVentaDetalleAux };
                    Tabla.Rows.Add(NewRow);
                }
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarDatos()
        {
            try
            {
                this.lblTicket.Text = "Ticket " + Datos.FolioVenta;
                this.txtNombreCliente.Text = Datos.NombreCliente;
                this.txtFechaVenta.Text = Datos.FechaVenta.ToShortDateString();
                this.txtTotal.Text = string.Format("{0:c}", Datos.Total);
                this.CargarGridVentaDetalle();
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
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.IniciarDatos();
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

        private Garantia ObtenerDatos()
        {
            try
            {
                Garantia DatosAux = new Garantia();
                DatosAux.IDVenta = this.Datos.IDVenta;
                DatosAux.IDSucursal = Comun.IDSucursalCaja;
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.IDEmpleadoAutoriza = Comun.IDUsuario;
                DatosAux.Observaciones = this.txtObservaciones.Text.Trim();
                DatosAux.TablaDatos = this.GenerarTablaGarantiaDetalle();
                DatosAux.Conexion = Comun.Conexion;
                return DatosAux;
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
                if (this.dgvProductos.SelectedRows.Count == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione el servicio al que se le aplicará la garantía.", ControlSender = this.dgvProductos });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaGarantia ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevaGarantia_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaGarantia ~ frmNuevaGarantia_Load");
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
                    Garantia DatosAux = this.ObtenerDatos();
                    Garantia_Negocio GN = new Garantia_Negocio();
                    GN.AplicarNuevaGarantia(DatosAux);
                    if (DatosAux.Completado)
                    {
                        //Imprimir el ticket
                        try
                        {
                            Ticket Impresion = new Ticket(4, 1, DatosAux.IDGarantia);
                            Impresion.ImprimirTicket();
                        }
                        catch (Exception exTicket)
                        {
                            LogError.AddExcFileTxt(exTicket, "Impresion de ticket");
                        }
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (DatosAux.Resultado == -1)
                        {
                            List<Error> LstError = new List<Error>();
                            LstError.Add(new Error { Numero = 1, Descripcion = "El estatus de la venta no permite la aplicación de la garantía.", ControlSender = this });
                            this.MostrarMensajeError(LstError);
                        }
                        else
                            MessageBox.Show(Comun.MensajeError + " Código: " + DatosAux.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaGarantia ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}