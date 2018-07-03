using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using StephSoft.ClasesAux;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace StephSoft
{
    public partial class frmInventario : Form
    {
        //Producto InfoProducto = new Producto();

        #region Constructor

        public frmInventario()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ frmInventario()");
            }
        }

        #endregion

        #region Métodos

        private System.Data.DataTable BusquedaResultados(Producto Datos)
        {
            try
            {
                Producto_Negocio ProdNeg = new Producto_Negocio();
                ProdNeg.ObtenerProductosInventario(Datos);
                return Datos.TablaDatos;
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
                this.ActiveControl = this.txtBusqueda;
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

        private void LlenarTablaProductos(System.Data.DataTable Datos)
        {
            try
            {
                this.dgvProductos.AutoGenerateColumns = false;
                this.dgvProductos.DataSource = Datos;
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
                Producto DatosProd = new Producto { Conexion = Comun.Conexion, IDSucursal = Comun.IDSucursalCaja, NombreProducto = this.txtBusqueda.Text.Trim() };
                this.LlenarTablaProductos(this.BusquedaResultados(DatosProd));
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void frmInventario_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ frmInventario_Load");
            }
        }

        #endregion

        #region Manejo de Excel

        private void btnLeerInventario_Click(object sender, EventArgs e)
        {
            try
            {
                this.ImportarExcel();
            }

            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ btnLeerInventario_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDescargarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarExcel())
                {
                    this.ExportarExcel();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ btnDescargarArchivo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<Producto> GenerarListaMatrizXIDSUCURSALCAJA()
        {
            try
            {
                Producto_Negocio ProdNeg = new Producto_Negocio();
                Producto Datos = new Producto { Conexion = Comun.Conexion, IDSucursal = Comun.IDSucursalCaja };
                ProdNeg.ObtenerProductosInventarioMatrizXIDSUCURSALCAJA(Datos);
                List<Producto> Lista = new List<Producto>();
                Producto Item;
                foreach (DataRow Fila in Datos.TablaDatos.Rows)
                {
                    Item = new Producto();
                    Item.Clave = Fila["Clave"].ToString();
                    Item.NombreProducto = Fila["NombreProducto"].ToString();
                    Item.Existencia = Convert.ToDecimal(Fila["Existencia"].ToString());
                    Item.IDProducto = Fila["IDProducto"].ToString();
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ExportarExcel()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application xlsApp = new Microsoft.Office.Interop.Excel.Application();

                Workbook xlsBook;
                Worksheet Inventario;
                Sheets xlHojas;
                List<Producto> ListaProductos = this.GenerarListaMatrizXIDSUCURSALCAJA();
                xlsApp.DisplayAlerts = false;
                xlsApp.Visible = false;
                string PathAr = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Excel\StepthSoft.xlsx");
                xlsBook = xlsApp.Workbooks.Open(PathAr);
                xlHojas = xlsBook.Sheets;
                Inventario = (Worksheet)xlHojas["Inventario"];
                int FilaInicio = 4;

                if (ListaProductos.Count != 0)
                {
                    foreach (Producto Item in ListaProductos)
                    {
                        Inventario.Cells[FilaInicio, 1] = Item.Clave;
                        Inventario.Cells[FilaInicio, 2] = Item.NombreProducto;
                        Inventario.Cells[FilaInicio, 3] = Item.Existencia;
                        Inventario.Cells[FilaInicio, 4] = 0;
                        Inventario.Cells[FilaInicio, 6] = Item.IDProducto;
                        FilaInicio++;
                    }
                }
                SaveFileDialog saveFileDialogExcel = new SaveFileDialog();
                saveFileDialogExcel.Filter = "Excel Files|*.xlsx";
                saveFileDialogExcel.FileName = "";
                saveFileDialogExcel.Title = "Seleccione donde guardar el excel";
                saveFileDialogExcel.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
                if (saveFileDialogExcel.ShowDialog() == DialogResult.OK)
                {
                    xlsBook.SaveAs(saveFileDialogExcel.FileName);
                }

                xlsBook.Close();
                xlsApp.Quit();
                releaseObject(xlHojas);
                releaseObject(xlsBook);
                releaseObject(Inventario);
                releaseObject(xlsApp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ImportarExcel()
        {
            OpenFileDialog openFileDialogExcel = new OpenFileDialog();
            openFileDialogExcel.Filter = "Excel Files|*.xlsx";
            openFileDialogExcel.FileName = "";
            openFileDialogExcel.Title = "Seleccione el archivo excel";
            openFileDialogExcel.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
            if (openFileDialogExcel.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application xlsApp = new Microsoft.Office.Interop.Excel.Application();

                Workbook xlsBook;
                Worksheet Inventario;
                Sheets xlHojas;

                xlsApp.DisplayAlerts = false;
                xlsApp.Visible = false;
                string PathAr = openFileDialogExcel.FileName;
                xlsBook = xlsApp.Workbooks.Open(PathAr);

                xlHojas = xlsBook.Sheets;
                Inventario = (Worksheet)xlHojas["Inventario"];
                int FilaInicio = 4;
                Producto InfoProducto = new Producto();
                InfoProducto.ImportarExcel = new System.Data.DataTable();
                InfoProducto.ImportarExcel.Columns.Add("Importar", typeof(bool));
                InfoProducto.ImportarExcel.Columns.Add("Clave", typeof(string));
                InfoProducto.ImportarExcel.Columns.Add("NombreProducto", typeof(string));
                InfoProducto.ImportarExcel.Columns.Add("Existencia", typeof(int));
                InfoProducto.ImportarExcel.Columns.Add("CanteoFisico", typeof(int));
                InfoProducto.ImportarExcel.Columns.Add("Diferencia", typeof(int));
                InfoProducto.ImportarExcel.Columns.Add("IDProducto", typeof(string));

                while ((Inventario.Cells[FilaInicio, 1] as Microsoft.Office.Interop.Excel.Range).Value2 != null)
                {
                    string a = (Inventario.Cells[FilaInicio, 1] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                    bool importar = true;
                    string Codigo = "", producto = "", IDProducto = "";
                    int existenciaSistema = 0, CanteoFisico = 0, diferencia = 0;

                    int.TryParse((Inventario.Cells[FilaInicio, 4] as Microsoft.Office.Interop.Excel.Range).Value2.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out CanteoFisico);

                    Codigo = (Inventario.Cells[FilaInicio, 1] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                    producto = (Inventario.Cells[FilaInicio, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                    int.TryParse((Inventario.Cells[FilaInicio, 3] as Microsoft.Office.Interop.Excel.Range).Value2.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out existenciaSistema);
                    int.TryParse((Inventario.Cells[FilaInicio, 5] as Microsoft.Office.Interop.Excel.Range).Value2.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out diferencia);
                    IDProducto = (Inventario.Cells[FilaInicio, 6] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                        InfoProducto.ImportarExcel.Rows.Add(new Object[] {
                            importar, 
                            Codigo,
                            producto,
                            existenciaSistema,                                                                
                            CanteoFisico,                                                                
                            diferencia,
                            IDProducto,
                        });
                    FilaInicio++;
                }

                Producto AuxProducto = new Producto();
                Producto_Negocio ProdNeg = new Producto_Negocio();
                AuxProducto.Conexion = Comun.Conexion;
                AuxProducto.IDSucursal = Comun.IDSucursalCaja;
                AuxProducto.IDUsuario = Comun.IDUsuario;
                AuxProducto.ImportarExcel = InfoProducto.ImportarExcel;
                ProdNeg.AInventarioEXCEL(AuxProducto);
                if (AuxProducto.Completado)
                {
                    MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Datos no se guardaron correctamente. Intente mas tarde", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                xlsBook.Close();
                xlsApp.Quit();
                releaseObject(xlHojas);
                releaseObject(xlsBook);
                releaseObject(Inventario);
                releaseObject(xlsApp);
            }
        }
        private bool ValidarExcel()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application xlsApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook xlsBook;
                Sheets xlHojas;

                xlsApp.DisplayAlerts = false;
                xlsApp.Visible = false;
                string PathAr = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Excel\StepthSoft.xlsx");
                xlsBook = xlsApp.Workbooks.Open(PathAr);
                xlHojas = xlsBook.Sheets;
                xlsBook.Close(true);
                xlsApp.Quit();
                releaseObject(xlHojas);
                releaseObject(xlsBook);
                releaseObject(xlsApp);
                return true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ ValidarExcel");
                return false;
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ releaseObject");
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        #endregion

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ txtBusqueda_KeyPress");
            }
        }

        private void btnDescantarExistencia_Click(object sender, EventArgs e)
        {
            try
            {
                frmDescontarExistencia DescExist = new frmDescontarExistencia();
                DescExist.ShowDialog();
                DescExist.Dispose();
                if (DescExist.DialogResult == DialogResult.OK)
                {
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ btnDescantarExistencia_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
