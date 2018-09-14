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
    public partial class frmNotificacionesProdStockMaximo : Form
    {
        #region Constructores

        public frmNotificacionesProdStockMaximo()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNotificacionesProdStockMaximo ~ frmNotificacionesProdStockMaximo()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.LlenarGridCatProductosStockMaximo(false);
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

        private void LlenarGridCatProductosStockMaximo(bool Band)
        {
            try
            {
                Producto DatosAux = new Producto { Conexion = Comun.Conexion, IDSucursal = Comun.IDSucursalCaja, BuscarTodos = Band };
                Producto_Negocio PN = new Producto_Negocio();
                PN.ObtenerCatProductosStockMaximo(DatosAux);
                this.dgvProductos.AutoGenerateColumns = false;
                this.dgvProductos.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ActualizarVisto()
        {
            try
            {
                Notificacion_Negocio Neg = new Notificacion_Negocio();
                Neg.ActualizarNotificacionVisto(Comun.Conexion, Comun.IDSucursalCaja, true, 2, Comun.IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNotificacionesProdStockMaximo ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNotificacionesProdStockMaximo_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActualizarVisto();
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNotificacionesProdStockMaximo ~ frmNotificacionesProdStockMaximo_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
