using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Global
{
    public class CicloHorario
    {
        private bool _Completado;
        private string _Conexion;
        private string _IDSucursal;
        private string _IDUsuario;
        private bool _IncluirSelect;
        private int _Opcion;
        private DataTable _TablaDatos;

        public bool Completado
        {
            get { return _Completado; }
            set { _Completado = value; }
        }
        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }
        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public bool IncluirSelect
        {
            get { return _IncluirSelect; }
            set { _IncluirSelect = value; }
        }
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private string _IDCiclo;

        public string IDCiclo
        {
            get { return _IDCiclo; }
            set { _IDCiclo = value; }
        }

        private string _NombreCiclo;

        public string NombreCiclo
        {
            get { return _NombreCiclo; }
            set { _NombreCiclo = value; }
        }

        private int _CantidadCiclos;

        public int CantidadCiclos
        {
            get { return _CantidadCiclos; }
            set { _CantidadCiclos = value; }
        }

        private int _IDUnidadCiclo;

        public int IDUnidadCiclo
        {
            get { return _IDUnidadCiclo; }
            set { _IDUnidadCiclo = value; }
        }

        private string _UnidadCicloDesc;

        public string UnidadCicloDesc
        {
            get { return _UnidadCicloDesc; }
            set { _UnidadCicloDesc = value; }
        }
        

        private bool _NuevoRegistro;

        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
        }

        private DateTime _FechaInicio;

        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }

        private DateTime _FechaFin;

        public DateTime FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }
        
    }
}
