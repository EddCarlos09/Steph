using CreativaSL.Dll.StephSoft.Global;
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

namespace StephSoft
{
    public partial class frmElegirTurnoCombo : Form
    {
        List<Horario> Lista = new List<Horario>();
        public Horario HorarioElegido = new Horario();

        public frmElegirTurnoCombo(List<Horario> Combo)
        {
            try
            {
                InitializeComponent();
                Lista = Combo;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTurnoCombo ~ frmElegirTurnoCombo(List<Horario> Combo)");
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
                LogError.AddExcFileTxt(ex, "frmElegirTurnoCombo ~ btnCancelar_Click");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Horario Item = this.ObtenerHorario();
                HorarioElegido = Item;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {   
                LogError.AddExcFileTxt(ex, "frmElegirTurnoCombo ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombo()
        {
            try
            {
                this.cmbUnidadMedida.DataSource = this.Lista;
                this.cmbUnidadMedida.DisplayMember = "NombreTurno";
                this.cmbUnidadMedida.ValueMember = "IDTurno";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Horario ObtenerHorario()
        {
            try
            {
                Horario DatosAux = new Horario();
                if (this.cmbUnidadMedida.Items.Count > 0)
                    if (this.cmbUnidadMedida.SelectedIndex != -1)
                        DatosAux = (Horario)this.cmbUnidadMedida.SelectedItem;
                return DatosAux;
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
                this.CargarCombo();
                this.ActiveControl = this.cmbUnidadMedida;
                this.cmbUnidadMedida.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmElegirTurnoCombo_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTurnoCombo ~ frmElegirTurnoCombo_Load");
            }
        }
    }
}
