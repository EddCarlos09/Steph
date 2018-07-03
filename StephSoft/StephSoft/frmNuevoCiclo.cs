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
    public partial class frmNuevoCiclo : Form
    {
        #region Propiedades / Variables

        private bool NuevoRegistro = true;
        private CicloHorario _DatosCiclo;
        public CicloHorario DatosCiclo
        {
            get { return _DatosCiclo; }
            set { _DatosCiclo = value; }
        }
        private List<Horario> ListaTurnos = new List<Horario>();

        #endregion

        #region Constructor(es)

        public frmNuevoCiclo()
        {
            try
            {
                InitializeComponent();
                this._DatosCiclo = new CicloHorario();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ frmNuevoCiclo()");
            }
        }

        public frmNuevoCiclo(CicloHorario Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosCiclo = Datos;
                this.NuevoRegistro = false;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ frmNuevoPedido(Pedido Datos)");
            }
        }

        #endregion

        #region Métodos

        private void AgregarFilasGrid()
        {
            try
            {
                List<Horario> Lista = new List<Horario>();
                int CantCiclos = this.ObtenerCantidadCiclos();
                UnidadCiclo UC = this.ObtenerUnidadCombo();
                Horario Item;
                int j = 1;
                for (int i = 0; i < CantCiclos * UC.DiasCiclo; i++)
                {
                    Item = new Horario();
                    if (i == UC.DiasCiclo)
                        j = 1;
                    if (UC.IDUnidadCiclo == 1)
                        Item.NombreDia = this.ObtenerNombreDia(i + 1, UC.IDUnidadCiclo);
                    else
                        Item.NombreDia = this.ObtenerNombreDia(j, UC.IDUnidadCiclo);
                    j++;
                    Item.IDCicloDetalle = string.Empty;
                    Item.IDTurno = 0;
                    Item.NombreTurno = string.Empty;
                    Lista.Add(Item);
                }
                this.dgvProveedor.AutoGenerateColumns = false;
                this.dgvProveedor.DataSource = null;
                this.dgvProveedor.DataSource = Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AsignarTurno(Horario Datos)
        {
            try
            {
                if (Datos.IDTurno == 0)
                {
                    Datos.IDTurno = 0;
                    Datos.NombreTurno = string.Empty;
                }
                foreach (DataGridViewRow Fila in this.dgvProveedor.SelectedRows)
                {
                    Fila.Cells["IDTurno"].Value = Datos.IDTurno;
                    Fila.Cells["Turno"].Value = Datos.NombreTurno;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboTurnos()
        {
            try
            {
                Horario DatosAux = new Horario { Conexion = Comun.Conexion, IncluirSelect = true };
                Ciclo_Negocio CN = new Ciclo_Negocio();
                this.ListaTurnos = CN.LlenarComboTurnos(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboUnidadCiclo()
        {
            try
            {
                UnidadCiclo DatosAux = new UnidadCiclo { Conexion = Comun.Conexion, IncluirSelect = true };
                Ciclo_Negocio CN = new Ciclo_Negocio();
                this.cmbUnidadMedida.DataSource = CN.LlenarComboUnidadCiclo(DatosAux);
                this.cmbUnidadMedida.DisplayMember = "Descripcion";
                this.cmbUnidadMedida.ValueMember = "IDUnidadCiclo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatosAModificar(CicloHorario Datos)
        {
            try
            {
                if (!string.IsNullOrEmpty(Datos.IDCiclo.Trim()))
                {
                    this.cmbUnidadMedida.SelectedValueChanged -= new System.EventHandler(this.cmbUnidadMedida_SelectedValueChanged);
                    this.cmbUnidadMedida.Validating -= new System.ComponentModel.CancelEventHandler(this.cmbUnidadMedida_Validating);
                    this.NUDCantidadCiclos.ValueChanged -= new System.EventHandler(this.NUDCantidadCiclos_ValueChanged);

                    this.txtNombreCiclo.Text = Datos.NombreCiclo;
                    this.NUDCantidadCiclos.Value = Datos.CantidadCiclos;
                    if (this.ExisteItemEnCombo(Datos.IDUnidadCiclo))
                        this.cmbUnidadMedida.SelectedValue = Datos.IDUnidadCiclo;
                    this.cmbUnidadMedida.SelectedValueChanged += new System.EventHandler(this.cmbUnidadMedida_SelectedValueChanged);
                    this.cmbUnidadMedida.Validating += new System.ComponentModel.CancelEventHandler(this.cmbUnidadMedida_Validating);
                    this.NUDCantidadCiclos.ValueChanged += new System.EventHandler(this.NUDCantidadCiclos_ValueChanged);
                    this.LlenarTablaCicloDetalle();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnCombo(int ID)
        {
            try 
            {
                bool Band = false;
                foreach (UnidadCiclo Item in this.cmbUnidadMedida.Items)
                {
                    if (Item.IDUnidadCiclo == ID)
                    {
                        Band = true;
                        break;
                    }
                }
                return Band;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTablaProductos()
        {
            try
            {
                DataTable Tabla = new DataTable();                
                Tabla.Columns.Add("", typeof(string));
                Tabla.Columns.Add("", typeof(string));
                Tabla.Columns.Add("", typeof(decimal));
                foreach (DataGridViewRow Fila in this.dgvProveedor.Rows)
                {
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
                this.txtNombreCiclo.Text = string.Empty;
                this.NUDCantidadCiclos.Value = 1;
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
                this.CargarComboUnidadCiclo();
                this.CargarComboTurnos();
                if (NuevoRegistro)
                    this.IniciarDatos();
                else
                    this.CargarDatosAModificar(this._DatosCiclo);
                this.ActiveControl = this.txtNombreCiclo;
                this.txtNombreCiclo.Focus();
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
                Horario DatosAux = new Horario { Conexion = Comun.Conexion, IDCiclo = this._DatosCiclo.IDCiclo };
                Ciclo_Negocio CN = new Ciclo_Negocio();
                List<Horario> Lista = CN.ObtenerCatCiclosDetalle(DatosAux);
                this.dgvProveedor.AutoGenerateColumns = false;
                this.dgvProveedor.DataSource = Lista;
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

        private int ObtenerCantidadCiclos()
        {
            try
            {
                return (int)this.NUDCantidadCiclos.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private CicloHorario ObtenerDatos()
        {
            try
            {
                CicloHorario DatosAux = new CicloHorario();
                UnidadCiclo UCAux = this.ObtenerUnidadCombo();
                DatosAux.NuevoRegistro = NuevoRegistro;
                DatosAux.IDCiclo = NuevoRegistro ? string.Empty : this._DatosCiclo.IDCiclo;
                DatosAux.NombreCiclo = this.txtNombreCiclo.Text.Trim();
                DatosAux.IDUnidadCiclo = UCAux.IDUnidadCiclo;
                DatosAux.UnidadCicloDesc = UCAux.Descripcion;
                DatosAux.CantidadCiclos = this.ObtenerCantidadCiclos();
                DatosAux.TablaDatos = this.ObtenerTablaTurnos();
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.IDSucursal = Comun.IDSucursalCaja;
                DatosAux.Conexion = Comun.Conexion;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ObtenerNombreDia(int Dia, int IDUnidad)
        {
            try
            {
                string NombreDia = string.Empty;
                switch (IDUnidad)
                {
                    case 2:
                        switch (Dia)
                        {
                            case 1: NombreDia = "Lunes";
                                break;
                            case 2: NombreDia = "Martes";
                                break;
                            case 3: NombreDia = "Miércoles";
                                break;
                            case 4: NombreDia = "Jueves";
                                break;
                            case 5: NombreDia = "Viernes";
                                break;
                            case 6: NombreDia = "Sábado";
                                break;
                            case 7: NombreDia = "Domingo";
                                break;
                        }
                        break;
                    case 1:
                    case 3:
                        NombreDia = "Día " + Dia;
                        break;
                }
                return NombreDia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable ObtenerTablaTurnos()
        {
            try
            {
                DataTable TablaDatos = new DataTable();
                TablaDatos.Columns.Add("IDCicloDetalle", typeof(string));
                TablaDatos.Columns.Add("Consecutivo", typeof(int));
                TablaDatos.Columns.Add("IDTurno", typeof(string));
                TablaDatos.Columns.Add("NombreDia", typeof(string));

                List<Horario> ListaDatos = (List<Horario>)this.dgvProveedor.DataSource;
                int Consecutivo = 0;
                foreach(Horario Item in ListaDatos)
                {
                    object [] FilaDatos = { Item.IDCicloDetalle, Consecutivo, Item.IDTurno, Item.NombreDia };
                    TablaDatos.Rows.Add(FilaDatos);
                    Consecutivo++;
                }
                return TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private UnidadCiclo ObtenerUnidadCombo()
        {
            try
            {
                UnidadCiclo DatosAux = new UnidadCiclo();
                if (this.cmbUnidadMedida.Items.Count > 0)
                {
                    if (this.cmbUnidadMedida.SelectedIndex != -1)
                        DatosAux = (UnidadCiclo)this.cmbUnidadMedida.SelectedItem;
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
                if(string.IsNullOrEmpty(this.txtNombreCiclo.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un identificador para el ciclo", ControlSender = this.txtNombreCiclo });
                UnidadCiclo AuxUC = this.ObtenerUnidadCombo();
                if(AuxUC.IDUnidadCiclo == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una unidad para el ciclo.", ControlSender = this.cmbUnidadMedida });
                if(this.ObtenerCantidadCiclos() <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La cantidad de ciclos debe ser mayor a 0.", ControlSender = this.NUDCantidadCiclos });
                if(this.dgvProveedor.Rows.Count == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe existir al menos un día.", ControlSender = this.dgvProveedor });
                if(!ValidarDatosGrid())
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Al menos un día debe tener horario asignado.", ControlSender = this.dgvProveedor });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarDatosGrid()
        {
            try
            {
                bool Band = false;
                List<Horario> Lista = (List<Horario>)this.dgvProveedor.DataSource;
                foreach (Horario Item in Lista)
                {
                    string Nombre = Item.NombreTurno;
                    if (Item.IDTurno != 0)
                    {
                        Band = true;
                        break;
                    }
                }
                return Band;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos    
        
        private void btnAsignarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProveedor.SelectedRows.Count > 0)
                {
                    frmElegirTurnoCombo Turno = new frmElegirTurnoCombo(this.ListaTurnos);
                    Turno.ShowDialog();
                    Turno.Dispose();
                    Horario Aux = new Horario { IDTurno = Turno.HorarioElegido.IDTurno, NombreTurno = Turno.HorarioElegido.NombreTurno };
                    if (Turno.DialogResult == DialogResult.OK)
                    {
                        this.AsignarTurno(Aux);
                    }
                }

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ btnAsignarTurno_Click");
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
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ btnCancelar_Click");
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
                    CicloHorario Datos = this.ObtenerDatos();
                    Ciclo_Negocio CN = new Ciclo_Negocio();
                    CN.ACCatCiclos(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosCiclo = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbUnidadMedida_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.NUDCantidadCiclos.Value = 1;
                this.AgregarFilasGrid();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ cmbUnidadMedida_SelectedValueChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbUnidadMedida_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.AgregarFilasGrid();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ cmbUnidadMedida_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoCiclo_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ frmNuevoCiclo_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NUDCantidadCiclos_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.AgregarFilasGrid();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ NUDCantidadCiclos_ValueChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
