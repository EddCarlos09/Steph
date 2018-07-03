using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Datos;

namespace CreativaSL.Dll.StephSoft.Negocio
{
    public class Caja_Negocio
    {
        public void AgregarDeposito(DepositoRetiro deposito)
        {
            try
            {
                Caja_Datos cd = new Caja_Datos();
                cd.AgregarDeposito(deposito);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarRetiro(DepositoRetiro retiro)
        {
            try
            {
                Caja_Datos cd = new Caja_Datos();
                cd.AgregarRetiro(retiro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AsignarCajaMac(Caja Datos)
        {
            try
            {
                Caja_Datos CD = new Caja_Datos();
                CD.AsignarCajaMac(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarAperturaCaja(Caja Datos)
        {
            try
            {
                Caja_Datos CD = new Caja_Datos();
                CD.GuardarAperturaCaja(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarCierreCaja(Caja Datos)
        {
            try
            {
                Caja_Datos CD = new Caja_Datos();
                CD.GuardarCierreCaja(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Caja> LlenarComboCatCajas(Caja Datos)
        {
            try
            {
                Caja_Datos CD = new Caja_Datos();
                return CD.LlenarComboCatCajas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Caja obtenerDatosConfiguracionLocal(Caja Datos)
        {
            try
            {
                Caja_Datos CD = new Caja_Datos();
                return CD.obtenerDatosConfiguracionLocal(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizaConfiguracionLocal(Caja Datos)
        {
            try
            {
                Caja_Datos CD = new Caja_Datos();
                CD.actualizarConfiguracionLocal(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerReporteTicketCaja(Caja Datos)
        {
            try
            {
                Caja_Datos CD = new Caja_Datos();
                CD.ObtenerReporteTicketCaja(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerReporteResumenCaja(Caja Datos)
        {
            try
            {
                Caja_Datos CD = new Caja_Datos();
                CD.ObtenerReporteResumenCaja(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
