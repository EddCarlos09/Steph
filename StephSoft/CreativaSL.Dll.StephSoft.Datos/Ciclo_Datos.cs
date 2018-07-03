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
    public class Ciclo_Datos
    {
        public void ACCatCiclos(CicloHorario Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion,
                    CommandType.StoredProcedure, "spCSLDB_ac_CatCiclos",
                     new SqlParameter("@NuevoRegistro", Datos.NuevoRegistro),
                     new SqlParameter("@IDCiclo", Datos.IDCiclo),
                     new SqlParameter("@NombreCiclo", Datos.NombreCiclo),
                     new SqlParameter("@CantidadCiclos", Datos.CantidadCiclos),
                     new SqlParameter("@IDUnidadCiclo", Datos.IDUnidadCiclo),
                     new SqlParameter("@CicloDetalle", Datos.TablaDatos),
                     new SqlParameter("@IDSucursal", Datos.IDSucursal),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                if (Result != null)
                {
                    if (!string.IsNullOrEmpty(Result.ToString()))
                    {
                        Datos.IDCiclo = Result.ToString();
                        Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatCiclos(CicloHorario Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatCiclos", Datos.IDSucursal);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.Completado = true;
                        Datos.TablaDatos = Ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatCiclosBusq(CicloHorario Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatCiclosBusq", Datos.IDSucursal, Datos.NombreCiclo);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.Completado = true;
                        Datos.TablaDatos = Ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CicloHorario> ObtenerComboCiclos(CicloHorario Datos)
        {
            try
            {
                List<CicloHorario> Lista = new List<CicloHorario>();
                CicloHorario Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatCiclos", Datos.IncluirSelect, Datos.IDSucursal);
                while (Dr.Read())
                {
                    Item = new CicloHorario();
                    Item.IDCiclo = Dr.GetString(Dr.GetOrdinal("IDCiclo"));
                    Item.NombreCiclo = Dr.GetString(Dr.GetOrdinal("NombreCiclo"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Horario> ObtenerCatCiclosDetalle(Horario Datos)
        {
            try
            {
                List<Horario> Lista = new List<Horario>();
                Horario Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatCicloDetalle", Datos.IDCiclo);
                while (Dr.Read())
                {
                    Item = new Horario();
                    Item.IDCicloDetalle = Dr.GetString(Dr.GetOrdinal("IDCicloDetalle"));
                    Item.IDTurno = Dr.GetInt32(Dr.GetOrdinal("IDTurno"));
                    Item.NombreTurno = Dr.GetString(Dr.GetOrdinal("NombreTurno"));
                    Item.NombreDia = Dr.GetString(Dr.GetOrdinal("NombreDia"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarCiclo(CicloHorario Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_del_EliminarCicloHorario", Datos.IDCiclo, Datos.IDUsuario);
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

        public List<UnidadCiclo> LlenarComboUnidadCiclo(UnidadCiclo Datos)
        {
            try
            {
                List<UnidadCiclo> Lista = new List<UnidadCiclo>();
                UnidadCiclo Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboUnidadCiclo", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new UnidadCiclo();
                    Item.IDUnidadCiclo = Dr.GetInt32(Dr.GetOrdinal("IDUnidadCiclo"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("UnidadCiclo"));
                    Item.DiasCiclo = Dr.GetInt32(Dr.GetOrdinal("Cantidad"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Horario> LlenarComboTurnos(Horario Datos)
        {
            try
            {
                List<Horario> Lista = new List<Horario>();
                Horario Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatTurnos", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new Horario();
                    Item.IDTurno = Dr.GetInt32(Dr.GetOrdinal("IDTurno"));
                    Item.NombreTurno = Dr.GetString(Dr.GetOrdinal("Descripcion"));
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
