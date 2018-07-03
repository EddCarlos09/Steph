using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Global
{
    public class VentaDetalle
    {
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private string _IDCliente;
        private string _IDUsuario;
        private int _Opcion;
        private bool _Seleccionado;
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
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string IDCliente
        {
            get { return _IDCliente; }
            set { _IDCliente = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public bool Seleccionado
        {
            get { return _Seleccionado; }
            set { _Seleccionado = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private string _IDVentaDetalle;

        public string IDVentaDetalle
        {
            get { return _IDVentaDetalle; }
            set { _IDVentaDetalle = value; }
        }
        


        private string _IDVenta;

        public string IDVenta
        {
            get { return _IDVenta; }
            set { _IDVenta = value; }
        }

        private string _FolioVenta;

        public string FolioVenta
        {
            get { return _FolioVenta; }
            set { _FolioVenta = value; }
        }

        private string _NombreCliente;

        public string NombreCliente
        {
            get { return _NombreCliente; }
            set { _NombreCliente = value; }
        }

        private DateTime _HoraInicio;

        public DateTime HoraInicio
        {
            get { return _HoraInicio; }
            set { _HoraInicio = value; }
        }

        private int _TiempoTranscurridoSegundos;

        public int TiempoTranscurridoSegundos
        {
            get { return _TiempoTranscurridoSegundos; }
            set { _TiempoTranscurridoSegundos = value; }
        }

        private decimal _Subtotal;

        public decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }


        private decimal _Descuento;

        public decimal Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        private decimal _Iva;

        public decimal Iva
        {
            get { return _Iva; }
            set { _Iva = value; }
        }

        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private decimal _CantidadVenta;

        public decimal CantidadVenta
        {
            get { return _CantidadVenta; }
            set { _CantidadVenta = value; }
        }

        private string _IDProducto;

        public string IDProducto
        {
            get { return _IDProducto; }
            set { _IDProducto = value; }
        }

        private string _IDServicio;

        public string IDServicio
        {
            get { return _IDServicio; }
            set { _IDServicio = value; }
        }

        private string _NombreProducto;

        public string NombreProducto
        {
            get { return _NombreProducto; }
            set { _NombreProducto = value; }
        }

        private string _NombreServicio;

        public string NombreServicio
        {
            get { return _NombreServicio; }
            set { _NombreServicio = value; }
        }

        private string _IDEmpleado;

        public string IDEmpleado
        {
            get { return _IDEmpleado; }
            set { _IDEmpleado = value; }
        }

        private int _Resultado;

        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }

        private string _Clave;

        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }
        private string _NombreEmpleado;

        public string NombreEmpleado
        {
            get { return _NombreEmpleado; }
            set { _NombreEmpleado = value; }
        }

        private int _IDEstatus;

        public int IDEstatus
        {
            get { return _IDEstatus; }
            set { _IDEstatus = value; }
        }

        private string _Estatus;

        public string Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private string _TiempoTranscurrido;

        public string TiempoTranscurrido
        {
            get { return _TiempoTranscurrido; }
            set { _TiempoTranscurrido = value; }
        }

        private decimal _PrecioNormal;

        public decimal PrecioNormal
        {
            get { return _PrecioNormal; }
            set { _PrecioNormal = value; }
        }

        private decimal _IvaUnitario;

        public decimal IvaUnitario
        {
            get { return _IvaUnitario; }
            set { _IvaUnitario = value; }
        }

        private string _MensajeError;

        public string MensajeError
        {
            get { return _MensajeError; }
            set { _MensajeError = value; }
        }

        private int _IDEstatusServicio;

        public int IDEstatusServicio
        {
            get { return _IDEstatusServicio; }
            set { _IDEstatusServicio = value; }
        }

        private bool _Concluido;

        public bool Concluido
        {
            get { return _Concluido; }
            set { _Concluido = value; }
        }

        private string _IDVentaServicio;

        public string IDVentaServicio
        {
            get { return _IDVentaServicio; }
            set { _IDVentaServicio = value; }
        }

        private string _IDSucursal;

        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }

        private string _IDProductoXVentaServicio;

        public string IDProductoXVentaServicio
        {
            get { return _IDProductoXVentaServicio; }
            set { _IDProductoXVentaServicio = value; }
        }

        private string _IDClaveAsignacion;

        public string IDClaveAsignacion
        {
            get { return _IDClaveAsignacion; }
            set { _IDClaveAsignacion = value; }
        }

        private bool _ClaveExtra;

        public bool ClaveExtra
        {
            get { return _ClaveExtra; }
            set { _ClaveExtra = value; }
        }

        private bool _ClaveEsEmpleado;

        public bool ClaveEsEmpleado
        {
            get { return _ClaveEsEmpleado; }
            set { _ClaveEsEmpleado = value; }
        }
        
    }
}
