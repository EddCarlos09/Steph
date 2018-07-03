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
    public partial class frmMobiliarioRecibir : Form
    {
        #region Propiedades / Variables
        private MobiliarioResguardo _DatosMobiliarioRecepcion;
        public MobiliarioResguardo DatosMobiliarioRecepcion
        {
            get { return _DatosMobiliarioRecepcion; }
            set { _DatosMobiliarioRecepcion = value; }
        }
        private string IDMobiliarioResguardos = string.Empty;
        private List<MobiliarioResguardo> ListadeReguardo = new List<MobiliarioResguardo>();
        #endregion

        #region Constructor(es)

        public frmMobiliarioRecibir(MobiliarioResguardo Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosMobiliarioRecepcion = Datos;
                this.IDMobiliarioResguardos = Datos.IDMobiliarioResguardo;

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliarioRecibir ~ frmMobiliarioRecibir(MobiliarioResguardo Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarGridPedidoDetalle()
        {
            try
            {
                this.dgvMobiliarioDetalle.AutoGenerateColumns = false;
                this.dgvMobiliarioDetalle.DataSource = null;
                this.dgvMobiliarioDetalle.DataSource = this.ListadeReguardo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void CargarDatosAModificar(MobiliarioResguardo Datos)
        {
            try
            {
                if (!string.IsNullOrEmpty(Datos.IDMobiliarioResguardo.Trim()))
                {
                    this.txtFolioPedido.Text = this._DatosMobiliarioRecepcion.FolioResguardo;
                    this.txtEstatus.Text = this._DatosMobiliarioRecepcion.NombreEstatus.ToString();
                    this.ListadeReguardo = Datos.ListaMobiliarioDetalle;
                    this.CargarGridPedidoDetalle();
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
                MobiliarioResguardo DatosAux = this.CargarGribMobiliarioDetalle();
                this.CargarDatosAModificar(DatosAux);
                this.ActiveControl = this.btnCancelar;
                this.btnCancelar.Focus();
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

        private MobiliarioResguardo CargarGribMobiliarioDetalle()
        {
            try
            {
                MobiliarioResguardo DatosAux = new MobiliarioResguardo { Conexion = Comun.Conexion, IDMobiliarioResguardo = this.IDMobiliarioResguardos };
                MobiliarioResguardo_Negocio MBNeg = new MobiliarioResguardo_Negocio();
                return MBNeg.ObtenerDatosDetalleMobiliario(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private MobiliarioResguardo ObtenerDatosPedido()
        {
            try
            {
                MobiliarioResguardo DatosAux = new MobiliarioResguardo();
                DatosAux.IDMobiliarioResguardo = this._DatosMobiliarioRecepcion.IDMobiliarioResguardo;
                DatosAux.FolioResguardo = this._DatosMobiliarioRecepcion.FolioResguardo;
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.TablaDatos = this.ObtenerTablaDatos();
                DatosAux.Conexion = Comun.Conexion;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable ObtenerTablaDatos()
        {
            try
            {
                DataTable Datos = new DataTable();
                Datos.Columns.Add("IDMobiliarioDetalle", typeof(string));
                Datos.Columns.Add("IDMobiliario", typeof(string));
                Datos.Columns.Add("CantidadSurtir", typeof(int));
                List<MobiliarioResguardo> Lista = (List<MobiliarioResguardo>)this.dgvMobiliarioDetalle.DataSource;
                foreach (MobiliarioResguardo Item in Lista)
                {
                    if (Item.CantidadSurtir > 0)
                    {
                        object[] Fila = { Item.IDMobiliarioDetalle, Item.IDMobiliario, Item.CantidadSurtir };
                        Datos.Rows.Add(Fila);
                    }
                }
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
                int Aux = 0, Cont = 0;
                List<MobiliarioResguardo> Lista = (List<MobiliarioResguardo>)this.dgvMobiliarioDetalle.DataSource;
                foreach (MobiliarioResguardo Item in Lista)
                {
                    if (Item.CantidadSurtir > 0)
                    {
                        Cont ++;
                    }
                }
                if(Cont == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe surtir al menos un producto.", ControlSender = this.dgvMobiliarioDetalle});
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
                LogError.AddExcFileTxt(ex, "frmMobiliarioRecibir ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMensajeError.Visible = false;
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    MobiliarioResguardo Datos = this.ObtenerDatosPedido();
                    MobiliarioResguardo_Negocio MobiNeg = new MobiliarioResguardo_Negocio();
                    MobiNeg.RecibirMobiliario(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar los datos. Código del error: " + Datos.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliarioRecibir ~ btnRecibir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPedidoDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (this.dgvMobiliarioDetalle.Columns["CantidadARecibir"] == this.dgvMobiliarioDetalle.Columns[e.ColumnIndex])
                    {
                        if (this.dgvMobiliarioDetalle.Rows[e.RowIndex].IsNewRow) { return; }
                        decimal CantidadAux = 0;
                        if (!decimal.TryParse(e.FormattedValue.ToString(), out CantidadAux))
                        {
                            e.Cancel = true;
                            this.dgvMobiliarioDetalle.Rows[e.RowIndex].ErrorText = "Ingrese un dato válido.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliarioRecibir ~ dgvPedidoDetalle_CellValidating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPedidoDetalle_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (this.dgvMobiliarioDetalle.Columns["CantidadARecibir"] == this.dgvMobiliarioDetalle.Columns[e.ColumnIndex])
                    {
                        this.dgvMobiliarioDetalle.Rows[e.RowIndex].ErrorText = "";
                        decimal CantidadAux = 0, CantidadPendiente = 0, CantidadSurtida = 0;
                        decimal.TryParse(this.dgvMobiliarioDetalle.Rows[e.RowIndex].Cells["CantidadARecibir"].Value.ToString(), out CantidadAux);
                        decimal.TryParse(this.dgvMobiliarioDetalle.Rows[e.RowIndex].Cells["CantidadPendiente"].Value.ToString(), out CantidadPendiente);
                        decimal.TryParse(this.dgvMobiliarioDetalle.Rows[e.RowIndex].Cells["CantidadSurtida"].Value.ToString(), out CantidadSurtida);
                        if (!string.IsNullOrEmpty(this.dgvMobiliarioDetalle.Rows[e.RowIndex].Cells["IDAsignacion"].Value.ToString()))
                        {
                            if (CantidadAux > 0 && CantidadPendiente > 0)
                            {
                                this.dgvMobiliarioDetalle.Rows[e.RowIndex].Cells["CantidadARecibir"].Value = (decimal)((int)CantidadSurtida);
                            }
                            else
                            {
                                CantidadAux = 0;
                                this.dgvMobiliarioDetalle.Rows[e.RowIndex].Cells["CantidadARecibir"].Value = (decimal)((int)CantidadAux);
                            }
                        }
                        else
                        {
                            if (CantidadAux > CantidadPendiente)
                            {
                                this.dgvMobiliarioDetalle.Rows[e.RowIndex].Cells["CantidadARecibir"].Value = (decimal)((int)CantidadPendiente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliarioRecibir ~ dgvPedidoDetalle_CellValidating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMobiliarioRecibir_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliarioRecibir ~ frmMobiliarioRecibir_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
