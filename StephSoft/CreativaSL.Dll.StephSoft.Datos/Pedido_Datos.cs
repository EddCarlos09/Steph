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
    public class Pedido_Datos
    {

        public List<PedidoDetalle> ObtenerComboClavesProduccion(PedidoDetalle Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDSucursal, Datos.IDEmpleado, Datos.IDProducto };
                List<PedidoDetalle> Lista = new List<PedidoDetalle>();
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboProductosProduccion", Parametros);
                PedidoDetalle Item;
                while (Dr.Read())
                {
                    Item = new PedidoDetalle();
                    Item.IDAsignacion = Dr.GetString(Dr.GetOrdinal("IDAsignacion"));
                    Item.ClaveProduccion = Dr.GetString(Dr.GetOrdinal("Clave"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACPedidos(Pedido Datos)
        {
            try
            {
                int Resultado = 0;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "Produccion.spCSLDB_ac_Pedidos",
                     new SqlParameter("@NuevoRegistro", Datos.NuevoRegistro),
                     new SqlParameter("@IDPedido", Datos.IDPedido),
                     new SqlParameter("@IDSucursal", Datos.IDSucursal),
                     new SqlParameter("@TablaPedidoDetalle", Datos.TablaDatos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (Dr.Read())
                {
                    Resultado = !Dr.IsDBNull(Dr.GetOrdinal("Resultado")) ? Dr.GetInt32(Dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDPedido = Dr.GetString(Dr.GetOrdinal("IDPedido"));
                    }
                    else
                    {
                        Datos.Completado = false;
                        Datos.Resultado = Resultado;
                        Datos.MensajeError = Dr.GetString(Dr.GetOrdinal("Mensaje"));
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerPedidosTab(Pedido Datos)
        {
            try
            {
                object[] Parametros = { Datos.Opcion, Datos.BuscarTodos, Datos.IDSucursal };
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Produccion.spCSLDB_get_PedidosTabSoft", Parametros);
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

        public void ObtenerPedidosTabBusq(Pedido Datos)
        {
            try
            {
                object[] Parametros = { Datos.Opcion, Datos.BuscarTodos, Datos.FolioPedido, Datos.IDSucursal };
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Produccion.spCSLDB_get_PedidosTabBusqSoft", Parametros);
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


        public void ObtenerPedidosSurtidos(Pedido Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDSucursal, Datos.BuscarTodos};
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Produccion.spCSLDB_get_PedidosSurtidosXIDSuc", Parametros);
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

        public void ObtenerPedidosSurtidosBusq(Pedido Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDSucursal, Datos.BuscarTodos, Datos.FolioPedido };
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Produccion.spCSLDB_get_PedidosSurtidosXIDSucBusq", Parametros);
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


        public void ObtenerPedidosXIDEstatusXIDSucursal(Pedido Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDSucursal, Datos.IDEstatus, Datos.BuscarTodos };
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_PedidosXIDEstatusXSucursal", Parametros);
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

        public List<PedidoDetalle> ObtenerDetalleClavesPedido(Pedido Datos)
        {
            try
            {
                List<PedidoDetalle> Lista = new List<PedidoDetalle>();
                PedidoDetalle Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "Produccion.spCSLDB_get_PedidoDetalleClavesXID", Datos.IDPedido);
                while (Dr.Read())
                {
                    Item = new PedidoDetalle();
                    Item.IDPedidoDetalle = Dr.GetString(Dr.GetOrdinal("IDPedidoDetalle"));
                    Item.IDProducto = Dr.GetString(Dr.GetOrdinal("IDProducto"));
                    Item.ClaveProducto = Dr.GetString(Dr.GetOrdinal("Clave"));
                    Item.NombreProducto = Dr.GetString(Dr.GetOrdinal("NombreProducto"));
                    Item.Cantidad = Dr.GetDecimal(Dr.GetOrdinal("Cantidad"));
                    Item.IDEmpleado = Dr.GetString(Dr.GetOrdinal("IDEmpleado"));
                    Item.NombreEmpleado = Dr.GetString(Dr.GetOrdinal("NombreEmpleado"));
                    Item.IDAsignacion = Dr.GetString(Dr.GetOrdinal("IDAsignacion"));
                    Item.ClaveProduccion = Dr.GetString(Dr.GetOrdinal("ClaveProduccion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PedidoDetalle> ObtenerDetallePedidoSurtido(Pedido Datos)
        {
            try
            {
                List<PedidoDetalle> Lista = new List<PedidoDetalle>();
                PedidoDetalle Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "Produccion.spCSLDB_get_PedidoSurtidoDetalleXID", Datos.IDPedido, Datos.IDPedidoSurtido);
                while (Dr.Read())
                {
                    Item = new PedidoDetalle();
                    Item.IDPedidoSurtidoDetalle = Dr.GetString(Dr.GetOrdinal("IDPedidoSurtidoDetalle"));
                    Item.IDPedidoDetalle = Dr.GetString(Dr.GetOrdinal("IDPedidoDetalle"));
                    Item.IDProducto = Dr.GetString(Dr.GetOrdinal("IDProducto"));
                    Item.ClaveProducto = Dr.GetString(Dr.GetOrdinal("Clave"));
                    Item.NombreProducto = Dr.GetString(Dr.GetOrdinal("NombreProducto"));
                    Item.Cantidad = Dr.GetDecimal(Dr.GetOrdinal("Cantidad"));
                    Item.CantidadSurtida = Dr.GetDecimal(Dr.GetOrdinal("CantidadSurtida"));
                    Item.CantidadRecibida = Dr.GetDecimal(Dr.GetOrdinal("CantidadRecibida"));
                    Item.CantidadPendiente = Item.CantidadSurtida - Item.CantidadRecibida;
                    Item.CantidadARecibir = Item.CantidadPendiente;
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EnviarPedido(Pedido Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Produccion.spCSLDB_set_EnviarPedido", Datos.IDPedido, Datos.IDUsuario);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RecibirPedido(Pedido Datos)
        {
            try
            {
                int Resultado = 0;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, CommandType.StoredProcedure, "Produccion.spCSLDB_set_RecibirPedido",
                     new SqlParameter("@IDPedidoSurtido", Datos.IDPedidoSurtido),
                     new SqlParameter("@IDPedido", Datos.IDPedido),
                     new SqlParameter("@IDSucursal", Datos.IDSucursal),
                     new SqlParameter("@TablaDetalle", Datos.TablaDatos),
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

        public void EliminarPedido(Pedido Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Produccion.spCSLDB_del_EliminarPedido", Datos.IDPedido, Datos.IDUsuario);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
