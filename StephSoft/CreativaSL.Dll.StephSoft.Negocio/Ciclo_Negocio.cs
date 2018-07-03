using CreativaSL.Dll.StephSoft.Datos;
using CreativaSL.Dll.StephSoft.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Negocio
{
    public class Ciclo_Negocio
    {
        public void ACCatCiclos(CicloHorario Datos)
        {
            try
            {
                Ciclo_Datos CD = new Ciclo_Datos();
                CD.ACCatCiclos(Datos);
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
                Ciclo_Datos CD = new Ciclo_Datos();
                CD.ObtenerCatCiclos(Datos);
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
                Ciclo_Datos CD = new Ciclo_Datos();
                CD.ObtenerCatCiclosBusq(Datos);
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
                Ciclo_Datos CD = new Ciclo_Datos();
                return CD.ObtenerCatCiclosDetalle(Datos);
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
                Ciclo_Datos CD = new Ciclo_Datos();
                return CD.ObtenerComboCiclos(Datos);
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
                Ciclo_Datos CD = new Ciclo_Datos();
                CD.EliminarCiclo(Datos);
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
                Ciclo_Datos CD = new Ciclo_Datos();
                return CD.LlenarComboUnidadCiclo(Datos);
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
                Ciclo_Datos CD = new Ciclo_Datos();
                return CD.LlenarComboTurnos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
