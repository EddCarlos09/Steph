using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Global
{
    public class FormaPago
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

        private int _IDFormaPago;

        public int IDFormaPago
        {
            get { return _IDFormaPago; }
            set { _IDFormaPago = value; }
        }

        private string _IDCobroDetalle;

        public string IDCobroDetalle
        {
            get { return _IDCobroDetalle; }
            set { _IDCobroDetalle = value; }
        }

        private decimal _MontoAPagar;

        public decimal MontoAPagar
        {
            get { return _MontoAPagar; }
            set { _MontoAPagar = value; }
        }

        private decimal _Comision;

        public decimal Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }

        private decimal _MontoTotal;

        public decimal MontoTotal
        {
            get { return _MontoTotal; }
            set { _MontoTotal = value; }
        }

        private string _Autorizacion;

        public string Autorizacion
        {
            get { return _Autorizacion; }
            set { _Autorizacion = value; }
        }

        private int _IDTipoIDentificacion;

        public int IDTipoIdentificacion
        {
            get { return _IDTipoIDentificacion; }
            set { _IDTipoIDentificacion = value; }
        }

        private string _TipoIdentDesc;

        public string TipoIdentDesc
        {
            get { return _TipoIdentDesc; }
            set { _TipoIdentDesc = value; }
        }

        private string _FolioDNI;

        public string FolioDNI
        {
            get { return _FolioDNI; }
            set { _FolioDNI = value; }
        }

        private string _NumTarjeta;

        public string NumTarjeta
        {
            get { return _NumTarjeta; }
            set { _NumTarjeta = value; }
        }

        private int _IDBanco;

        public int IDBanco
        {
            get { return _IDBanco; }
            set { _IDBanco = value; }
        }

        private string _Banco;

        public string Banco
        {
            get { return _Banco; }
            set { _Banco = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        
    }
}
