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
    public class Catalogo_Datos
    {
        public void ObtenerCatFamiliaProductos(FamiliaProducto Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatFamiliasProductos", Datos.Opcion);
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

        public void ObtenerCatTipoMetrica(TipoMetrica Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatTipoMetrica", Datos.Opcion);
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

        public void ObtenerCatTipoUso(TipoUso Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatTipoUso", Datos.Opcion);
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

        public void ObtenerCatUnidadMedida(UnidadMedida Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatUnidadMedida", Datos.Opcion);
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

        public List<TipoRegistro> ObtenerCatTipoRegistro(TipoRegistro Datos)
        {
            try
            {
                List<TipoRegistro> Lista = new List<TipoRegistro>();
                TipoRegistro Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatTipoRegistro", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new TipoRegistro();
                    Item.IDTipoRegistro = Dr.IsDBNull(Dr.GetOrdinal("IDTipoRegistro")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDTipoRegistro"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime ObtenerFechaSistema(string Conexion)
        {
            try
            {
                DateTime FechaSistema = new DateTime();
                object FechaServidor = SqlHelper.ExecuteScalar(Conexion, "spCSLDB_get_FechaHoraServidor");
                if (FechaServidor != null)
                {
                    DateTime.TryParse(FechaServidor.ToString(), out FechaSistema);
                }
                return FechaSistema;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoIdentificacion> ObtenerComboTipoIdentificacion(TipoIdentificacion Datos)
        {
            try
            {
                List<TipoIdentificacion> Lista = new List<TipoIdentificacion>();
                TipoIdentificacion Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboTipoIDentificacion", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new TipoIdentificacion();
                    Item.IDTipoIdentificacion = Dr.GetInt32(Dr.GetOrdinal("IDTipoIdentificacion"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("TipoIdentificacion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Banco> ObtenerComboBancos(Banco Datos)
        {
            try
            {
                List<Banco> Lista = new List<Banco>();
                Banco Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatBancos", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new Banco();
                    Item.IDBanco = Dr.GetInt32(Dr.GetOrdinal("IDBanco"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Banco"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}