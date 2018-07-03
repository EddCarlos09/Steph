using CreativaSL.Dll.StephSoft.Datos;
using CreativaSL.Dll.StephSoft.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Negocio
{
    public class MobiliarioResguardo_Negocio
    {
        public void ObtenerCatMobiliarioResguardo(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo_Datos MRD = new MobiliarioResguardo_Datos();
                MRD.ObtenerCatMobiliarioResguardo(Datos);
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
                MobiliarioResguardo_Datos MRD = new MobiliarioResguardo_Datos();
                return MRD.ObtenerDetalleMobiliarioResguardo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MobiliarioResguardo ObtenerDatosDetalleMobiliario(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo_Datos MRD = new MobiliarioResguardo_Datos();
                return MRD.ObtenerDetalleMobiliarios(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatMobiliarioResguardoBusqueda(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo_Datos MRD = new MobiliarioResguardo_Datos();
                MRD.ObtenerCatMobiliarioResguaardoBusqueda(Datos);
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
                MobiliarioResguardo_Datos MRD = new MobiliarioResguardo_Datos();
                MRD.RecibirMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
