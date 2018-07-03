using CreativaSL.Dll.StephSoft.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Datos
{
    public class Garantia_Datos
    {
        public void AplicarNuevaGarantia(Garantia Datos)
        {
            try
            {
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_set_NuevaGarantia", 
                                new SqlParameter("@IDVenta", Datos.IDVenta),
                                new SqlParameter("@IDSucursal", Datos.IDSucursal),
                                new SqlParameter("@IDEmpleadoAutoriza", Datos.IDEmpleadoAutoriza),
                                new SqlParameter("@Observaciones", Datos.Observaciones),
                                new SqlParameter("@IDUsuario", Datos.IDUsuario),
                                new SqlParameter("@DetalleProductos", Datos.TablaDatos));
                if (Result != null)
                {
                    int Resultado = 0;
                    if(int.TryParse(Result.ToString(), out Resultado))
                    {
                        Datos.Resultado = Resultado;
                    }
                    else
                    {
                        Datos.Completado = true;
                        Datos.IDGarantia = Result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BusquedaGarantias(Garantia Datos)
        {
            try
            {
                object[] Parametros = { Datos.Band, Datos.TextoBusqueda};
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_BusqGarantias", Parametros);
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.TablaDatos = Ds.Tables[0];
                        Datos.Completado = true;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Garantia ObtenerDetalleGarantia(Garantia Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_GarantiaDetalle", Datos.IDGarantia);
                Garantia Resultado = new Garantia();
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Resultado.FolioVenta = Dr.GetString(Dr.GetOrdinal("FolioVenta"));
                            Resultado.CodigoVale = Dr.GetString(Dr.GetOrdinal("FolioVale"));
                            Resultado.IDEmpleadoAutoriza = Dr.GetString(Dr.GetOrdinal("EmpleadoAutoriza"));
                            Resultado.IDCliente = Dr.GetString(Dr.GetOrdinal("Cliente"));
                            Resultado.Observaciones = Dr.GetString(Dr.GetOrdinal("Observaciones"));
                            Resultado.TextoBusqueda = Dr.GetString(Dr.GetOrdinal("TextoGarantia"));
                        }

                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        List<VentaDetalle> Lista = new List<VentaDetalle>();
                        VentaDetalle Item;
                        while (Dr2.Read())
                        {
                            Item = new VentaDetalle();
                            Item.Clave = Dr2.GetString(Dr2.GetOrdinal("Clave"));
                            Item.NombreProducto = Dr2.GetString(Dr2.GetOrdinal("Servicio"));
                            Item.Total = Dr2.GetDecimal(Dr2.GetOrdinal("Monto"));
                            Lista.Add(Item);
                        }
                        Resultado.ListaDetalle = Lista;
                        Resultado.Completado = true;
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
