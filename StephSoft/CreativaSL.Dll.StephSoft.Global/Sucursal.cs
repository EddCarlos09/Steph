using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Global
{
    public class Sucursal
    {
        private bool _Completado;
        private string _Conexion;
        private string _CodigoPostal;
        private string _Direccion;
        private int _IDEmpresa;
        private string _IDSucursal;
        private int _IDTipoSucursal;
        private string _IDUsuario;
        private int _IDMunicipio;
        private int _IDEstado;
        private int _IDPais;
        private int _Opcion;
        private float _PorcentajeMonedero;
        private string _Telefono;
        private string _NombreSucursal;
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
        public string CodigoPostal
        {
            get { return _CodigoPostal; }
            set { _CodigoPostal = value; }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public int IDEmpresa
        {
            get { return _IDEmpresa; }
            set { _IDEmpresa = value; }
        }
        public int IDTipoSucursal
        {
            get { return _IDTipoSucursal; }
            set { _IDTipoSucursal = value; }
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
        public int IDMunicipio
        {
            get { return _IDMunicipio; }
            set { _IDMunicipio = value; }
        }
        public int IDEstado
        {
            get { return _IDEstado; }
            set { _IDEstado = value; }
        }
        public int IDPais
        {
            get { return _IDPais; }
            set { _IDPais = value; }
        }

        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public float PorcentajeMonedero
        {
            get { return _PorcentajeMonedero; }
            set { _PorcentajeMonedero = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public string NombreSucursal
        {
            get { return _NombreSucursal; }
            set { _NombreSucursal = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
    }
}
