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
    public partial class frmVerDetalleCiclo : Form
    {
        #region Propiedades / Variables
        string IDCiclo;
        #endregion

        #region Constructor(es)
        
        public frmVerDetalleCiclo(string _IDCiclo)
        {
            try
            {
                InitializeComponent();
                IDCiclo = _IDCiclo;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerDetalleCiclo ~ frmVerDetalleCiclo(string _IDCiclo)");
            }
        }

        #endregion

        #region Métodos
        
        private void IniciarForm()
        {
            try
            {
                LlenarTablaCicloDetalle();
                this.ActiveControl = this.btnRegresar;
                this.btnRegresar.Focus();
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

        private void LlenarTablaCicloDetalle()
        {
            try
            {
                Horario DatosAux = new Horario { Conexion = Comun.Conexion, IDCiclo = IDCiclo };
                Ciclo_Negocio CN = new Ciclo_Negocio();
                List<Horario> Lista = CN.ObtenerCatCiclosDetalle(DatosAux);
                this.dgvHorarios.AutoGenerateColumns = false;
                this.dgvHorarios.DataSource = Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion

        #region Eventos    
        
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerDetalleCiclo ~ btnRegresar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void frmVerDetalleCiclo_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerDetalleCiclo ~ frmVerDetalleCiclo_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
