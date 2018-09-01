using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephSoft.Global;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace CreativaSL.Dll.StephSoft.Datos
{
    public class Servicio_Datos
    {
        public void ABCCatServicio(Servicio Datos)
        {
            try
            {
                Datos.Completado = false;
                int Resultado = 0;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_abc_CatServicio",
                     new SqlParameter("@Opcion", Datos.Opcion),
                     new SqlParameter("@IDProducto", Datos.IDServicio),
                     new SqlParameter("@IDFamilia", Datos.IDFamilia),
                     new SqlParameter("@Clave", Datos.Clave),
                     new SqlParameter("@Nombre", Datos.NombreServicio),
                     new SqlParameter("@PrecioNormal", Datos.PrecioNormal),
                     new SqlParameter("@Descripcion", Datos.Descripcion),
                     new SqlParameter("@AplicaIVA", Datos.AplicaIVA),
                     new SqlParameter("@AplicaPrecioMay", Datos.AplicaPrecioMayoreo),
                     new SqlParameter("@PrecioMayoreo", Datos.PrecioMayoreo),
                     new SqlParameter("@CantidadMayoreo", Datos.CantidadMayoreo),
                     new SqlParameter("@AplicaPrecioTemp", Datos.AplicaPrecioTemporada),
                     new SqlParameter("@PrecioTemp", Datos.PrecioTemporada),
                     new SqlParameter("@TiempoMinuto", Datos.TiempoMinutos),
                     new SqlParameter("@FechaInicioTemp", Datos.FechaInicioTemp),
                     new SqlParameter("@FechaFinTemp", Datos.FechaFinTemp),
                     new SqlParameter("@AplicaPrecioEsp", Datos.AplicaPrecioEspecial),
                     new SqlParameter("@PrecioEspecial", Datos.PrecioEspecial),
                     new SqlParameter("@LunesPrecioEsp", Datos.PrecioEspecialLunes),
                     new SqlParameter("@MartesPrecioEsp", Datos.PrecioEspecialMartes),
                     new SqlParameter("@MiercolesPrecioEsp", Datos.PrecioEspecialMiercoles),
                     new SqlParameter("@JuevesPrecioEsp", Datos.PrecioEspecialJueves),
                     new SqlParameter("@ViernesPrecioEsp", Datos.PrecioEspecialViernes),
                     new SqlParameter("@SabadoPrecioEsp", Datos.PrecioEspecialSabado),
                     new SqlParameter("@DomingoPrecioEsp", Datos.PrecioEspecialDomingo),
                     new SqlParameter("@UrlImagen", Datos.UrlImagen),
                     new SqlParameter("@Imagen", Datos.Imagen),
                     new SqlParameter("@TablaServicio", Datos.TablaProductos),
                     new SqlParameter("@TablaMonedero", Datos.TablaMonederos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (dr.Read())
                {
                    Resultado = !dr.IsDBNull(dr.GetOrdinal("Resultado")) ? dr.GetInt32(dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDProducto = dr.GetString(dr.GetOrdinal("IDProducto"));
                        Datos.UrlImagen = Datos.IDProducto + ".JPG";
                    }
                    else
                    {
                        Datos.Completado = false;
                        Datos.Resultado = Resultado;
                        Datos.MensajeError = dr.GetString(dr.GetOrdinal("Mensaje"));
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerCatServicios(Servicio Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatServicios", Datos.BuscarTodos);
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

        public void ObtenerCatServicioBusqueda(Servicio Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatServiciosBusqueda", Datos.BuscarTodos, Datos.NombreServicio);
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



        public void ObtenerCatTipoMonederoXIDProducto(TipoMonedero Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_MonederoXProducto", Datos.IDProducto);
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

        public Servicio ObtenerDatosServicioXID(Servicio Datos)
        {
            try
            {
                Servicio DatosResultado = new Servicio();
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ServicioDetalleXID", Datos.IDServicio);
                while (Dr.Read())
                {
                    DatosResultado.IDServicio = Datos.IDServicio;
                    DatosResultado.IDFamilia = Dr.IsDBNull(Dr.GetOrdinal("IDFamilia")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDFamilia"));
                    DatosResultado.Clave = Dr.IsDBNull(Dr.GetOrdinal("Clave")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Clave"));
                    DatosResultado.NombreServicio = Dr.IsDBNull(Dr.GetOrdinal("Nombre")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Nombre"));
                    DatosResultado.PrecioNormal = Dr.IsDBNull(Dr.GetOrdinal("PrecioNormal")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PrecioNormal"));
                    DatosResultado.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    DatosResultado.AplicaIVA = Dr.IsDBNull(Dr.GetOrdinal("AplicaIVA")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaIVA"));
                    DatosResultado.AplicaPrecioMayoreo = Dr.IsDBNull(Dr.GetOrdinal("AplicaPrecioMayoreo")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaPrecioMayoreo"));
                    DatosResultado.PrecioMayoreo = Dr.IsDBNull(Dr.GetOrdinal("PrecioMayoreo")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PrecioMayoreo"));
                    DatosResultado.CantidadMayoreo = Dr.IsDBNull(Dr.GetOrdinal("CantidadMayoreo")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("CantidadMayoreo"));
                    DatosResultado.AplicaPrecioTemporada = Dr.IsDBNull(Dr.GetOrdinal("AplicaPrecioTemporada")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaPrecioTemporada"));
                    DatosResultado.PrecioTemporada = Dr.IsDBNull(Dr.GetOrdinal("PrecioTemporada")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PrecioTemporada"));
                    DatosResultado.TiempoMinutos = Dr.IsDBNull(Dr.GetOrdinal("TiempoMinuto")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("TiempoMinuto"));
                    DatosResultado.FechaInicioTemp = Dr.IsDBNull(Dr.GetOrdinal("FechaInicioTemporada")) ? DateTime.Today : Dr.GetDateTime(Dr.GetOrdinal("FechaInicioTemporada"));
                    DatosResultado.FechaFinTemp = Dr.IsDBNull(Dr.GetOrdinal("FechaFinTemporada")) ? DateTime.Today : Dr.GetDateTime(Dr.GetOrdinal("FechaFinTemporada"));
                    DatosResultado.AplicaPrecioEspecial = Dr.IsDBNull(Dr.GetOrdinal("AplicaPrecioEspecial")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaPrecioEspecial"));
                    DatosResultado.PrecioEspecial = Dr.IsDBNull(Dr.GetOrdinal("PrecioEspecial")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PrecioEspecial"));
                    DatosResultado.PrecioEspecialLunes = Dr.IsDBNull(Dr.GetOrdinal("AplicaLunes")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaLunes"));
                    DatosResultado.PrecioEspecialMartes = Dr.IsDBNull(Dr.GetOrdinal("AplicaMartes")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaMartes"));
                    DatosResultado.PrecioEspecialMiercoles = Dr.IsDBNull(Dr.GetOrdinal("AplicaMiercoles")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaMiercoles"));
                    DatosResultado.PrecioEspecialJueves = Dr.IsDBNull(Dr.GetOrdinal("AplicaJueves")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaJueves"));
                    DatosResultado.PrecioEspecialViernes = Dr.IsDBNull(Dr.GetOrdinal("AplicaViernes")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaViernes"));
                    DatosResultado.PrecioEspecialSabado = Dr.IsDBNull(Dr.GetOrdinal("AplicaSabado")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaSabado"));
                    DatosResultado.PrecioEspecialDomingo = Dr.IsDBNull(Dr.GetOrdinal("AplicaDomingo")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaDomingo"));
                    DatosResultado.UrlImagen = Dr.IsDBNull(Dr.GetOrdinal("UrlImagen")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("UrlImagen"));
                    break;
                }
                return DatosResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Producto> ObtenerProductosDisponiblesXIDServicio(Servicio Datos)
        {
            try
            {
                List<Producto> Lista = new List<Producto>();
                Producto Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatProductoDispXIDServicio", Datos.IDServicio);
                while (Dr.Read())
                {
                    Item = new Producto();
                    Item.IDProducto = Dr.IsDBNull(Dr.GetOrdinal("IDProducto")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDProducto"));
                    Item.NombreProducto = Dr.IsDBNull(Dr.GetOrdinal("NombreProducto")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreProducto"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Producto> ObtenerProductoXIDServicio(Servicio Datos)
        {
            try
            {
                List<Producto> Lista = new List<Producto>();
                Producto Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ProductoXServicio", Datos.IDServicio);
                while (Dr.Read())
                {
                    Item = new Producto();
                    Item.IDProductoXServicio = Dr.IsDBNull(Dr.GetOrdinal("IDProductoXServicio")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDProductoXServicio"));
                    Item.IDProducto = Dr.IsDBNull(Dr.GetOrdinal("IDProducto")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDProducto"));
                    Item.NombreProducto = Dr.IsDBNull(Dr.GetOrdinal("NombreProducto")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreProducto"));
                    Item.Cantidad = Dr.IsDBNull(Dr.GetOrdinal("Cantidad")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("Cantidad"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<Servicio> LlenarComboCatServicios(Servicio Datos)
        {
            try
            {
                List<Servicio> Lista = new List<Servicio>();
                Servicio Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatServiciosTiempo", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new Servicio();
                    Item.IDServicio = Dr.IsDBNull(Dr.GetOrdinal("IDServicio")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDServicio"));
                    Item.NombreServicio = Dr.IsDBNull(Dr.GetOrdinal("NombreServicio")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreServicio"));
                    Item.TiempoMinutos = Dr.IsDBNull(Dr.GetOrdinal("TiempoMinutos")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("TiempoMinutos"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Producto> ObtenerProductosXIDServicio(Servicio Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDServicio, Datos.IDEmpleado, Datos.IDSucursal };
                List<Producto> ListaProductos = new List<Producto>();
                Producto Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ProductosXIDServicioEmpleado", Parametros);
                while (Dr.Read())
                {
                    Item = new Producto();
                    Item.IDServicio = Dr.GetString(Dr.GetOrdinal("IDServicio"));
                    Item.IDProducto = Dr.GetString(Dr.GetOrdinal("IDProducto"));
                    Item.NombreProducto = Dr.GetString(Dr.GetOrdinal("Producto"));
                    string Aux = Dr.GetString(Dr.GetOrdinal("TablaClaves"));
                    if (string.IsNullOrEmpty(Aux))
                    {
                        Item.ListaClaves = new List<PedidoDetalle>();
                    }
                    else
                    {
                        Aux = string.Format("<Main>{0}</Main>", Aux);
                        XmlDocument xm = new XmlDocument();
                        xm.LoadXml(Aux);
                        XmlNodeList Registros = xm.GetElementsByTagName("Main");
                        XmlNodeList Lista = ((XmlElement)Registros[0]).GetElementsByTagName("D");
                        List<PedidoDetalle> ListaClaves = new List<PedidoDetalle>();
                        PedidoDetalle ItemPD;
                        foreach (XmlElement Nodo in Lista)
                        {
                            ItemPD = new PedidoDetalle();
                            XmlNodeList IDAsignacion = Nodo.GetElementsByTagName("IDAsignacion");
                            XmlNodeList ClaveProduccion = Nodo.GetElementsByTagName("ClaveProduccion");
                            XmlNodeList EsEmpleado = Nodo.GetElementsByTagName("EsEmpleado");
                            ItemPD.IDAsignacion = IDAsignacion[0].InnerText;
                            ItemPD.ClaveProduccion = ClaveProduccion[0].InnerText;
                            bool EsEmpl = true;
                            bool.TryParse(EsEmpleado[0].InnerText, out EsEmpl);
                            ItemPD.EsEmpleado = EsEmpl;
                            ListaClaves.Add(ItemPD);
                        }
                        Item.ListaClaves = ListaClaves;
                    }
                    ListaProductos.Add(Item);
                }
                return ListaProductos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Producto> ObtenerServiciosXIDPromocion(string Conexion, int IDPromocion)
        {
            try
            {
                object[] Parametros = { IDPromocion };
                List<Producto> ListaServicios = new List<Producto>();
                Producto Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Ventas.spCSLBD_get_DetallePromocionVenta", Parametros);
                while (Dr.Read())
                {
                    Item = new Producto();
                    Item.IDPromocion = !Dr.IsDBNull(Dr.GetOrdinal("IDPromocion")) ? Dr.GetInt32(Dr.GetOrdinal("IDPromocion")) : -1;
                    Item.IDPromocionDetalle = !Dr.IsDBNull(Dr.GetOrdinal("IDPromocionDetalle")) ? Dr.GetInt32(Dr.GetOrdinal("IDPromocionDetalle")) : -1;
                    Item.IDPromocionDetalleProd = !Dr.IsDBNull(Dr.GetOrdinal("IDPromocionDetalleProd")) ? Dr.GetInt32(Dr.GetOrdinal("IDPromocionDetalleProd")) : -1;
                    Item.IDServicio = Dr.GetString(Dr.GetOrdinal("IDServicio"));
                    Item.NombreProducto = Dr.GetString(Dr.GetOrdinal("Servicio"));
                    ListaServicios.Add(Item);
                }
                return ListaServicios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
