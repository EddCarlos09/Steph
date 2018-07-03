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
    public partial class frmCancelar : Form
    {

        private Venta Datos = new Venta();

        public frmCancelar(Venta Aux)
        {
            try
            {
                InitializeComponent();
                Datos = Aux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCancelar ~ frmCancelar()");
            }
        }

        private void frmCancelar_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCancelar ~ frmCancelar_Load");
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.label42.Text = "Ticket: " + Datos.FolioVenta;
                this.IniciarDatos();
                this.ActiveControl = this.cmbMotivoCanc;
                this.cmbMotivoCanc.Focus();
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

        private void IniciarDatos()
        {
            try
            {
                this.CargarComboMotivoCanc();
                this.txtMontoMaximo.Text = string.Format("{0:c}", Datos.Total);
                this.txtMotivo.Text = string.Empty;
                this.txtMontoPenalizacion.Text = string.Format("{0:c}", 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboMotivoCanc()
        {
            try
            {
                MotivoCanc Datos = new MotivoCanc { IncluirSelect = true, Conexion = Comun.Conexion };
                Venta_Negocio VN = new Venta_Negocio();
                this.cmbMotivoCanc.DataSource = VN.ObtenerComboMotivoCanc(Datos);
                this.cmbMotivoCanc.DisplayMember = "Descripcion";
                this.cmbMotivoCanc.ValueMember = "IDMotivo";
            }
            catch (Exception ex)
            {
                throw ex;
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
                LogError.AddExcFileTxt(ex, "frmCancelar ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private MotivoCanc ObtenerMotivoCombo()
        {
            try
            {
                MotivoCanc Datos = new MotivoCanc();
                if (this.cmbMotivoCanc.Items.Count > 0)
                {
                    if (this.cmbMotivoCanc.SelectedIndex != -1)
                    {
                        Datos = (MotivoCanc)this.cmbMotivoCanc.SelectedItem;
                    }
                }
                return Datos;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private decimal ObtenerMontoPenalizacion()
        {
            try
            {
                decimal Aux = 0;
                decimal.TryParse(this.txtMontoPenalizacion.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Aux);
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbMotivoCanc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MotivoCanc Datos = this.ObtenerMotivoCombo();
                if (Datos.RequiereDatos)
                {
                    this.txtMotivo.Enabled = true;
                    this.txtMotivo.Text = string.Empty;
                }
                else
                {
                    this.txtMotivo.Enabled = false;
                    this.txtMotivo.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCancelar ~ cmbMotivoCanc_SelectedIndexChanged");
            }
        }

        private void cmbMotivoCanc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.cmbMotivoCanc.SelectedIndex == -1)
                {
                    this.txtMotivo.Enabled = false;
                    this.txtMotivo.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCancelar ~ cmbMotivoCanc_Validating");
            }
        }

        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                int aux = 0;
                MotivoCanc AuxMC = this.ObtenerMotivoCombo();
                if(AuxMC.IDMotivo == 0)
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Seleccione un motivo.", ControlSender = this.cmbMotivoCanc });
                decimal Monto = this.ObtenerMontoPenalizacion();
                if(Monto< 0)
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "El monto de penalización debe ser mayor o igual a 0.", ControlSender = this.cmbMotivoCanc });
                if(Monto > Datos.Total)
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "El monto de penalización no debe ser mayor al total.", ControlSender = this.cmbMotivoCanc });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtMontoPenalización_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal Monto = this.ObtenerMontoPenalizacion();
                this.txtMontoPenalizacion.Text = string.Format("{0:c}", Monto);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCancelar ~ cmbMotivoCanc_SelectedIndexChanged");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    Venta DatosAux = this.ObtenerDatos();
                    Venta_Negocio VN = new Venta_Negocio();
                    VN.CancelarVenta(DatosAux);
                    if (DatosAux.Completado)
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCancelar ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Venta DatosAux = new Venta();
                MotivoCanc MCAux = this.ObtenerMotivoCombo();
                DatosAux.IDVenta = this.Datos.IDVenta;
                DatosAux.IDMotivoCan = MCAux.IDMotivo;
                DatosAux.ComentariosCanc = this.txtMotivo.Text.Trim();
                DatosAux.MontoPenalizacionCanc = this.ObtenerMontoPenalizacion();
                DatosAux.IDSucursal = Comun.IDSucursalCaja;
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.IDCaja = Comun.IDCaja;
                DatosAux.Conexion = Comun.Conexion;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
