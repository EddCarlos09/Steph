using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Datos;

namespace CreativaSL.Dll.StephSoft.Negocio
{
    public class Usuario_Negocio
    {

        public void ABCUsuario(Usuario Datos)
        {
            try
            {
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ABCUsuario(Datos);
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
                Usuario_Datos UD = new Usuario_Datos();
                UD.AsignarHuellaXIDEmpleado(Datos);
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
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ObtenerUsuario(Datos);
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
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ObtenerUsuarioBusqueda(Datos);
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
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ObtenerComboCatTipoUsuario(Datos);
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
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ObtenerHuellaDigitalXIDEmpleado(Datos);
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
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ObtenerHuellasDigitales(Datos);
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
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ObtenerHuellasDigitalesXIDSuc(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Sucursal> ObtenerSucursales(Usuario Datos)
        {
            try
            {
                Usuario_Datos Ud = new Usuario_Datos();
                return Ud.ObtenerSucursal(Datos);
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
                Usuario_Datos Ud = new Usuario_Datos();
                return Ud.ObtenerSucursalXIDEmpleado(Datos);
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
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ABCCuentaUsuario(Datos);
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
                Usuario_Datos UD = new Usuario_Datos();
                return UD.LlenarComboCatEmpleados(Datos);
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
                Usuario_Datos UD = new Usuario_Datos();
                return UD.LlenarComboCatEmpleadosPedidos(Datos);
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
                Usuario_Datos UD = new Usuario_Datos();
                return UD.LlenarComboCatEmpleadosCita(Datos);
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
                Usuario_Datos UD = new Usuario_Datos();
                UD.ObtenerCatUsuarioXIDSuc(Datos);
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
                Usuario_Datos UD = new Usuario_Datos();
                UD.ObtenerCatUsuarioXIDSucBusq(Datos);
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
                Usuario_Datos UD = new Usuario_Datos();
                UD.AsignarHorarioEmpleado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Usuario ObtenerUsuarioXID(Usuario Datos)
        {
            try
            {
                Usuario_Datos Ud = new Usuario_Datos();
                return Ud.obtenerDatosUsuario(Datos);
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
                Usuario_Datos UD = new Usuario_Datos();
                UD.ActualizarDatosUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
