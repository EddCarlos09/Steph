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
    public partial class frmAsignarHorario : Form
    {
        private Usuario DatosEmpleado = new Usuario();

        public frmAsignarHorario(Usuario DatosEmp)
        {
            try
            {
                InitializeComponent();
                this.DatosEmpleado = DatosEmp;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmAsignarHoraro ~ frmAsignarHorario()");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LogError.AddExcFileTxt(ex, "frmAsignarHoraro ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Usuario_Negocio UN = new Usuario_Negocio();
                    Usuario Datos = this.ObtenerDatos();
                    UN.AsignarHorarioEmpleado(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmAsignarHoraro ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAsignarHorario_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmAsignarHoraro ~ frmAsignarHorario_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.txtNombreEmpleado.Text = DatosEmpleado.Nombre + " " + DatosEmpleado.ApellidoPat + " " + DatosEmpleado.ApellidoMat;
                this.dtpFechaInicio.Value = DateTime.Today;
                this.dtpFechaFin.Value = DateTime.Today;
                this.CargarComboCiclos();
                this.ActiveControl = this.cmbCicloHorario;
                this.cmbCicloHorario.Focus();
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

        private void CargarComboCiclos()
        {
            try
            {
                CicloHorario DatosAux = new CicloHorario { Conexion = Comun.Conexion, IncluirSelect = true, IDSucursal = Comun.IDSucursalCaja };
                Ciclo_Negocio CN = new Ciclo_Negocio();
                this.cmbCicloHorario.DataSource = CN.ObtenerComboCiclos(DatosAux);
                this.cmbCicloHorario.DisplayMember = "NombreCiclo";
                this.cmbCicloHorario.ValueMember = "IDCiclo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private CicloHorario ObtenerCicloCombo()
        {
            try
            {
                CicloHorario DatosAux = new CicloHorario();
                if (this.cmbCicloHorario.Items.Count > 0)
                {
                    if (this.cmbCicloHorario.SelectedIndex != -1)
                        DatosAux = (CicloHorario)this.cmbCicloHorario.SelectedItem;
                }
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
                CicloHorario AuxUC = this.ObtenerCicloCombo();
                if (string.IsNullOrEmpty(AuxUC.IDCiclo))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un ciclo.", ControlSender = this.cmbCicloHorario });
                if (this.dtpFechaInicio.Value < DateTime.Today)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La fecha de Inicio debe ser mayor a la fecha actual.", ControlSender = this.dtpFechaInicio });
                if (this.dtpFechaFin.Value < this.dtpFechaInicio.Value)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La fecha final debe ser mayor a la fecha de Inicio.", ControlSender = this.dtpFechaFin });
                return Errores;
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

        private Usuario ObtenerDatos()
        {
            try
            {
                Usuario DatosAux = new Usuario();
                CicloHorario CHAux = this.ObtenerCicloCombo();
                DatosAux.IDEmpleado = this.DatosEmpleado.IDEmpleado;
                DatosAux.IDCiclo = CHAux.IDCiclo;
                DatosAux.FechaInicio = this.dtpFechaInicio.Value;
                DatosAux.FechaFin = this.dtpFechaFin.Value;
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.Conexion = Comun.Conexion;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnVerDetalleCiclo_Click(object sender, EventArgs e)
        {
            try
            {
                string _IDCiclo = this.ObtenerCicloCombo().IDCiclo;
                if(!string.IsNullOrEmpty(_IDCiclo))
                {
                    frmVerDetalleCiclo Detalle = new frmVerDetalleCiclo(_IDCiclo);
                    Detalle.ShowDialog();
                    Detalle.Dispose();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmAsignarHoraro ~ btnVerDetalleCiclo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
