using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Datos
{
    public class Notificacion_Datos
    {
        public DataTable ObtenerNotificaciones(string Conexion, string IDSucursal)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Conexion, "Produccion.spCSLDB_get_NotificacionesXTipoActivas", IDSucursal);
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        return Ds.Tables[0];
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarNotificacionVisto(string Conexion, string IDSucursal, bool Visto, int IDTipoNotificacion, string IDUsuario)
        {
            try
            {
                object[] Parametro = { IDSucursal, Visto, IDTipoNotificacion, IDUsuario };
                SqlHelper.ExecuteDataset(Conexion, "spCSLDB_set_NotificacionesSistemaVisto", Parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
