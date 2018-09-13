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
    public class Usuario_Datos
    {

        public void ABCUsuario(Usuario Datos)
        {
            try
            {
                SqlDataReader Resultado = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_abc_CatEmpleado",
                     new SqlParameter("@Opcion", Datos.Opcion),
                     new SqlParameter("@IDEmpleado", Datos.IDEmpleado),
                     new SqlParameter("@IDTipoUsuario", Datos.IDTipoUsuario),
                     new SqlParameter("@IDPuesto", Datos.IDPuesto),
                     new SqlParameter("@IDCategoria", Datos.IDCategoriaPuesto),
                     new SqlParameter("@AbrirCaja", Datos.AbrirCaja),
                     new SqlParameter("@Nombre", Datos.Nombre),
                     new SqlParameter("@ApellidoPat", Datos.ApellidoPat),
                     new SqlParameter("@ApellidoMat", Datos.ApellidoMat),
                     new SqlParameter("@DirCalle", Datos.DirCalle),
                     new SqlParameter("@DirColonia", Datos.DirColonia),
                     new SqlParameter("@DirNumero", Datos.DirNumero),
                     new SqlParameter("@TablaUsuarioSucursal", Datos.TablaUsuarioSucursal),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDEmpleado = Resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AsignarHuellaXIDEmpleado(Usuario Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEmpleado, Datos.BufferHuella, Datos.HuellaString, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_HuellaXIDEmpleado", Parametros);
                Datos.Completado = false;
                if (Result != null)
                {
                    int Aux = 0;
                    int.TryParse(Result.ToString(), out Aux);
                    if (Aux == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerUsuario(Usuario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatEmpleado", Datos.BuscarTodos);
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

        public void ObtenerUsuarioBusqueda(Usuario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatEmpleadoBusqueda", Datos.BuscarTodos, Datos.Nombre);
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

        public void ObtenerComboCatTipoUsuario(TipoUsuario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ComboCatTipoUsuario");
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

        public void ObtenerHuellaDigitalXIDEmpleado(Usuario Datos)
        {
            try
            {
                Datos.Completado = false;
                object Imagen = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_get_HuellaXIDEmpleado", Datos.IDEmpleado);
                if (Imagen != null)
                {
                    Datos.BufferHuella = (byte[])Imagen;
                    Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerHuellasDigitales(Usuario Datos)
        {
            try
            {
                Datos.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatEmpleadosHuella");
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.TablaDatos = Ds.Tables[0];
                        Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerHuellasDigitalesXIDSuc(Usuario Datos)
        {
            try
            {
                Datos.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatEmpleadosHuellaXIDSuc", Datos.IDSucursalActual);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.TablaDatos = Ds.Tables[0];
                        Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sucursal> ObtenerSucursal(Usuario Datos)
        {
            try
            {
                List<Sucursal> Lista = new List<Sucursal>();
                Sucursal Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatSursalesUsuario", Datos.IDEmpleado);
                while (Dr.Read())
                {
                    Item = new Sucursal();
                    Item.IDSucursal = Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDSucursal"));
                    Item.NombreSucursal = Dr.IsDBNull(Dr.GetOrdinal("NombreSucursal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreSucursal"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sucursal> ObtenerSucursalXIDEmpleado(Usuario Datos)
        {
            try
            {
                List<Sucursal> Lista = new List<Sucursal>();
                Sucursal Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_UsuarioXSucursal", Datos.IDEmpleado);
                while (Dr.Read())
                {
                    Item = new Sucursal();
                    Item.IDSucursal = Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDSucursal"));
                    Item.NombreSucursal = Dr.IsDBNull(Dr.GetOrdinal("NombreSucursal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreSucursal"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCCuentaUsuario(Usuario Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDEmpleado, Datos.CuentaUsuario, Datos.Password, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CuentaUsuario", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDEmpleado = Resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> LlenarComboCatEmpleados(Usuario Datos)
        {
            try
            {
                List<Usuario> Lista = new List<Usuario>();
                Usuario Item;
                object[] Parametros = { Datos.IncluirSelect, Datos.IDSucursalActual };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboEmpleadosXIDSucursal", Parametros);
                while (Dr.Read())
                {
                    Item = new Usuario();
                    Item.IDEmpleado = Dr.IsDBNull(Dr.GetOrdinal("IDEmpleado")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDEmpleado"));
                    Item.Nombre = Dr.IsDBNull(Dr.GetOrdinal("NombreEmpleado")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreEmpleado"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<Usuario> LlenarComboCatEmpleadosPedidos(Usuario Datos)
        {
            try
            {
                List<Usuario> Lista = new List<Usuario>();
                Usuario Item;
                object[] Parametros = { Datos.IncluirSelect, Datos.IDSucursalActual };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboEmpleadosXIDSucursalPed", Parametros);
                while (Dr.Read())
                {
                    Item = new Usuario();
                    Item.IDEmpleado = Dr.IsDBNull(Dr.GetOrdinal("IDEmpleado")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDEmpleado"));
                    Item.Nombre = Dr.IsDBNull(Dr.GetOrdinal("NombreEmpleado")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreEmpleado"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> LlenarComboCatEmpleadosCita(Usuario Datos)
        {
            try
            {
                List<Usuario> Lista = new List<Usuario>();
                Usuario Item;
                object[] Parametros = { Datos.IncluirSelect, Datos.IDSucursalActual };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboEmpleadosXIDSucursalCita", Parametros);
                while (Dr.Read())
                {
                    Item = new Usuario();
                    Item.IDEmpleado = Dr.IsDBNull(Dr.GetOrdinal("IDEmpleado")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDEmpleado"));
                    Item.Nombre = Dr.IsDBNull(Dr.GetOrdinal("NombreEmpleado")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreEmpleado"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatUsuarioXIDSuc(Usuario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatEmpleadoXIDSuc", Datos.BuscarTodos, Datos.IDSucursalActual);
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

        public void ObtenerCatUsuarioXIDSucBusq(Usuario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatEmpleadoBusquedaXIDSuc", Datos.BuscarTodos, Datos.IDSucursalActual, Datos.Nombre);
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

        public void AsignarHorarioEmpleado(Usuario Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDEmpleado, Datos.IDCiclo, Datos.FechaInicio, Datos.FechaFin, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_AsignacionHorario", Parametros);
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

        public Usuario obtenerDatosUsuario(Usuario datos)
        {
            try
            {
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.Conexion, "ObtenerUsuarioID", datos.IDUsuario);
                while (dr.Read())
                {
                    datos.IDUsuario = dr["IDEmpleado"].ToString();
                    datos.IDTipoUsuario = Convert.ToInt32(dr["IDTipoUsuario"].ToString());
                    datos.TipoUsuario = dr["TipoUsuario"].ToString();
                    datos.IDSucursalActual = dr["IDSucursalActual"].ToString();
                    datos.NombreSucursal = dr["NombreSucursal"].ToString();
                    datos.Nombre = dr["Nombre"].ToString();
                    datos.ApellidoPat = dr["ApPaterno"].ToString();
                    datos.ApellidoMat = dr["ApMaterno"].ToString();
                    datos.DirCalle = dr["DirCalle"].ToString();
                    datos.DirColonia = dr["DirColonia"].ToString();
                    datos.DirNumero = dr["DirNumero"].ToString();
                    datos.CuentaUsuario = dr["CuentaUsuario"].ToString();
                    datos.Password = dr["password"].ToString();
                }
                dr.Close();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarDatosUsuario(Usuario Datos)
        {
            try
            {

                int Resultado = 0;
                object[] Parametros = { Datos.Opcion, Datos.IDSucursalActual, Datos.Nombre,
                                      Datos.ApellidoPat, Datos.ApellidoMat, Datos.DirCalle,
                                      Datos.DirColonia, Datos.DirNumero, Datos.Password, 
                                      Datos.changePassword, Datos.IDUsuario};
                SqlDataReader Ds = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_set_actualizarPerfil", Parametros);
                while (Ds.Read())
                {
                    Resultado = !Ds.IsDBNull(Ds.GetOrdinal("Resultado")) ? Ds.GetInt32(Ds.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Comun.NombreUsuario = Ds.GetString(Ds.GetOrdinal("Nombre"));
                        Comun.ApellidoPatUsuario = Ds.GetString(Ds.GetOrdinal("ApPaterno"));
                        Comun.ApellidoMatUsuario = Ds.GetString(Ds.GetOrdinal("ApMaterno"));
                    }
                    else
                    {
                        Datos.Completado = false;
                        Datos.Resultado = Resultado;
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerEmpleadosMaterialesXIDSuc(Usuario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Produccion.spCSLDB_get_EmpleadosXIDSucMateriales", Datos.IDSucursalActual);
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

        public string ObtenerNombreEmpleadoXClave(string Conexion, string IDSucursal, string ClaveEmpleado)
        {
            try
            {
                object Result = SqlHelper.ExecuteScalar(Conexion, "Ventas.spCSLDB_get_NombreEmpleadoXClave", ClaveEmpleado, IDSucursal);
                if(Result != null)
                {
                    return Result.ToString();
                }
                return string.Empty;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
