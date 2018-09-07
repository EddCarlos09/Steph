﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Datos;

namespace CreativaSL.Dll.StephSoft.Negocio
{
    public class Login_Negocio
    {
        public void IniciarDatos(DatosIniciales Datos)
        {
            try
            {
                Login_Datos LD = new Login_Datos();
                LD.IniciarDatos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool IsNewSystem(string Conexion)
        {
            try
            {
                Login_Datos LD = new Login_Datos();
                return LD.IsNewSystem(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ValidarUsuario(Usuario Datos)
        {
            try
            {
                Login_Datos LD = new Login_Datos();
                LD.ValidarUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Usuario Autorizacion(string Conexion, string User, string Password, int TipoAcceso)
        {
            try
            {
                Login_Datos LogDat = new Login_Datos();
                return LogDat.Autorizacion(Conexion, User, Password, TipoAcceso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
