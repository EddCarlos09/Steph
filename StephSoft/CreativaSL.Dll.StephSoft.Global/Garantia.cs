using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Global
{
    public class Garantia
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

        private string _IDVenta;

        public string IDVenta
        {
            get { return _IDVenta; }
            set { _IDVenta = value; }
        }

        private string _IDEmpleadoAutoriza;

        public string IDEmpleadoAutoriza
        {
            get { return _IDEmpleadoAutoriza; }
            set { _IDEmpleadoAutoriza = value; }
        }

        private string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private string _IDGarantia;

        public string IDGarantia
        {
            get { return _IDGarantia; }
            set { _IDGarantia = value; }
        }

        private string _IDVale;

        public string IDVale
        {
            get { return _IDVale; }
            set { _IDVale = value; }
        }

        private string _CodigoVale;

        public string CodigoVale
        {
            get { return _CodigoVale; }
            set { _CodigoVale = value; }
        }

        private int _Resultado;

        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }

        private bool _Band;

        public bool Band
        {
            get { return _Band; }
            set { _Band = value; }
        }

        private string _TextoBusqueda;

        public string TextoBusqueda
        {
            get { return _TextoBusqueda; }
            set { _TextoBusqueda = value; }
        }

        private string _FolioVenta;

        public string FolioVenta
        {
            get { return _FolioVenta; }
            set { _FolioVenta = value; }
        }

        private string _IDCliente;

        public string IDCliente
        {
            get { return _IDCliente; }
            set { _IDCliente = value; }
        }

        private List<VentaDetalle> _ListaDetalle;

        public List<VentaDetalle> ListaDetalle
        {
            get { return _ListaDetalle; }
            set { _ListaDetalle = value; }
        }
        
    }
}
