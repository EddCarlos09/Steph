using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using CreativaSL.Dll.Validaciones;
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
    public partial class frmEntregaMaterial : Form
    {
        #region Constructores

        public frmEntregaMaterial()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEntregaMaterial ~ frmEntregaMaterial()");
            }
        }

        #endregion

        #region Métodos
                
        private void BusquedaUsuario(string TextoEmpleado)
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion, Nombre = TextoEmpleado, BuscarTodos = false, IDSucursalActual = Comun.IDSucursalCaja };
                Usuario_Negocio CN = new Usuario_Negocio();
                CN.ObtenerCatUsuarioXIDSucBusq(DatosAux);
                this.dgvUsuario.AutoGenerateColumns = false;
                this.dgvUsuario.DataSource = DatosAux.TablaDatos;
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
                this.LlenarGridUsuario();
                this.txtBusqueda.Focus();
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

        private void LlenarGridUsuario()
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion, IDSucursalActual = Comun.IDSucursalCaja };
                Usuario_Negocio CN = new Usuario_Negocio();
                CN.ObtenerEmpleadosMaterialesXIDSuc(DatosAux);
                this.dgvUsuario.AutoGenerateColumns = false;
                this.dgvUsuario.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Usuario ObtenerDatosUsuario(int RowData)
        {
            try
            {
                Usuario DatosAux = new Usuario();
                //Int32 RowData = this.dgvUsuario.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    DataGridViewRow FilaDatos = this.dgvUsuario.Rows[RowData];
                    DatosAux.IDEmpleado = FilaDatos.Cells["IDEmpleado"].Value.ToString();
                    DatosAux.CodigoUsuario = FilaDatos.Cells["ClaveUsuario"].Value.ToString();
                    DatosAux.Nombre = FilaDatos.Cells["Nombre"].Value.ToString();
                    DatosAux.ApellidoPat = FilaDatos.Cells["ApellidoPat"].Value.ToString();
                    DatosAux.ApellidoMat = FilaDatos.Cells["ApellidoMat"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                {
                    if (Validar.IsValidName(txtBusqueda.Text.Trim()))
                        this.BusquedaUsuario(this.txtBusqueda.Text.Trim());
                    else
                        this.txtBusqueda.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEntregaMaterial ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEntregaMaterial ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void frmEntregaMaterial_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEntregaMaterial ~ frmEntregaMaterial_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEntregaMaterial ~ txtBusqueda_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnClavesSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                frmClavesXIDEmpleado Claves = new frmClavesXIDEmpleado();
                Claves.ShowDialog();
                Claves.Dispose();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEntregaMaterial ~ btnClavesSucursal_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgvUsuario.Columns[e.ColumnIndex].Name.Equals("VerMateriales"))
                    {
                        Usuario DatosUser = this.ObtenerDatosUsuario(e.RowIndex);
                        if (!string.IsNullOrEmpty(DatosUser.IDEmpleado))
                        {
                            frmClavesXIDEmpleado Claves = new frmClavesXIDEmpleado(DatosUser);
                            Claves.ShowDialog();
                            Claves.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEntregaMaterial ~ dgvUsuario_CellContentClick");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
