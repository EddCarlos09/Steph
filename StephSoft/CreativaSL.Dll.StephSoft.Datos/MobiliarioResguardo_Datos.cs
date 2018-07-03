using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephSoft.Global;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;

namespace CreativaSL.Dll.StephSoft.Datos
{
    public class MobiliarioResguardo_Datos
    {

        public void ObtenerCatMobiliarioResguardo(MobiliarioResguardo Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_MobiliarioRecepcion", Datos.BuscarTodos, Datos.IDSucursal);
                Datos.TablaDatos = new DataTable();
                if (ds != null)
                    if (ds.Tables.Count == 1)
                        Datos.TablaDatos = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MobiliarioResguardo> ObtenerDetalleMobiliarioResguardo(MobiliarioResguardo Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDMobiliarioResguardo };
                List<MobiliarioResguardo> Lista = new List<MobiliarioResguardo>();
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_Mobiliario_Detalle", Parametros);
                MobiliarioResguardo Item;
                while (Dr.Read())
                {
                    Item = new MobiliarioResguardo();
                    Item.IDMobiliarioResguardo = Dr.GetString(Dr.GetOrdinal("IDMobiliarioResguardo"));
                    Item.IDSucursal = Dr.GetString(Dr.GetOrdinal("IDSucursal"));
                    Item.IDStatusMobiliario = Dr.GetInt32(Dr.GetOrdinal("Estatus"));
                    Item.IDMobiliarioDetalle = Dr.GetString(Dr.GetOrdinal("IDMobiliarioDetalle"));
                    Item.IDMobiliario = Dr.GetString(Dr.GetOrdinal("IDMobiliario"));
                    Item.Codigo = Dr.GetString(Dr.GetOrdinal("Codigo"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.Marca = Dr.GetString(Dr.GetOrdinal("Marca"));
                    Item.Modelo = Dr.GetString(Dr.GetOrdinal("Modelo"));
                    Item.Cantidad = Dr.GetInt32(Dr.GetOrdinal("Cantidad"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MobiliarioResguardo ObtenerDetalleMobiliarios(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo DatosGuardados = new MobiliarioResguardo();
                DatosGuardados.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_Mobiliario_Recepcion_Detalle", Datos.IDMobiliarioResguardo);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        if (Ds.Tables[0] != null)
                        {
                            DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                            while (Dr.Read())
                            {
                                DatosGuardados.IDMobiliarioResguardo = Datos.IDMobiliarioResguardo;
                                DatosGuardados.IDSucursal = !Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? Dr.GetString(Dr.GetOrdinal("IDSucursal")) : string.Empty;
                                DatosGuardados.IDStatusMobiliario = (int)(!Dr.IsDBNull(Dr.GetOrdinal("Estatus")) ? Dr.GetInt32(Dr.GetOrdinal("Estatus")) : 0);
                            }
                        }
                        if (Ds.Tables[1] != null)
                        {
                            List<MobiliarioResguardo> Lista = new List<MobiliarioResguardo>();
                            MobiliarioResguardo Item;
                            DataTableReader Dr = Ds.Tables[1].CreateDataReader();
                            while (Dr.Read())
                            {
                                Item = new MobiliarioResguardo();
                                Item.IDMobiliarioDetalle = !Dr.IsDBNull(Dr.GetOrdinal("IDMobiliarioDetalle")) ? Dr.GetString(Dr.GetOrdinal("IDMobiliarioDetalle")) : string.Empty;
                                Item.IDMobiliario = !Dr.IsDBNull(Dr.GetOrdinal("IDMobiliario")) ? Dr.GetString(Dr.GetOrdinal("IDMobiliario")) : string.Empty;
                                Item.Codigo = !Dr.IsDBNull(Dr.GetOrdinal("Codigo")) ? Dr.GetString(Dr.GetOrdinal("Codigo")) : string.Empty;
                                Item.Descripcion = !Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? Dr.GetString(Dr.GetOrdinal("Descripcion")) : string.Empty;
                                Item.Marca = !Dr.IsDBNull(Dr.GetOrdinal("Marca")) ? Dr.GetString(Dr.GetOrdinal("Marca")) : string.Empty;
                                Item.Modelo = !Dr.IsDBNull(Dr.GetOrdinal("Modelo")) ? Dr.GetString(Dr.GetOrdinal("Modelo")) : string.Empty;
                                Item.Cantidad = (int)(!Dr.IsDBNull(Dr.GetOrdinal("Cantidad")) ? Dr.GetInt32(Dr.GetOrdinal("Cantidad")) : 0);
                                Item.CantidadSurtir = (int)(!Dr.IsDBNull(Dr.GetOrdinal("CantidadSurtir")) ? Dr.GetInt32(Dr.GetOrdinal("CantidadSurtir")) : 0);
                                Lista.Add(Item);
                            }
                            DatosGuardados.ListaMobiliarioDetalle = Lista;
                        }
                        DatosGuardados.Completado = true;
                    }
                }
                return DatosGuardados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatMobiliarioResguaardoBusqueda(MobiliarioResguardo Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_MobiliarioRecepcionXIDSucBusq", Datos.BuscarTodos, Datos.IDSucursal, Datos.FolioResguardo);
                Datos.TablaDatos = new DataTable();
                if (ds != null)
                    if (ds.Tables.Count == 1)
                        Datos.TablaDatos = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RecibirMobiliario(MobiliarioResguardo Datos)
        {
            try
            {
                int Resultado = 0;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_set_RecibirMobiliario",
                     new SqlParameter("@IDMobiliarioResguardo", Datos.IDMobiliarioResguardo),
                     new SqlParameter("@FolioResguardo", Datos.FolioResguardo),
                     new SqlParameter("@TablaDetalleRecepcion", Datos.TablaDatos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                if (Result != null)
                {
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
