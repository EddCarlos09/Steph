using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Global
{
    public class Servicio
    {
        private bool _AplicaIVA;
        private bool _AplicaPrecioEspecial;
        private bool _AplicaPrecioMayoreo;
        private bool _AplicaPrecioTemporada;
        private bool _BuscarTodos;
        private int _CantidadMayoreo;
        private string _Clave;
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private string _FamiliaDesc;
        private DateTime _FechaFinTemp;
        private DateTime _FechaInicioTemp;
        private int _IDFamilia;
        private string _IDProducto;



        private string _IDServicio;
        private string _IDUsuario;
        private byte[] _Imagen;
        private string _MensajeError;
        private string _NombreServicio;
        private string _NumInventario;
        private int _Opcion;
        private decimal _PrecioEspecial;
        private bool _PrecioEspecialLunes;
        private bool _PrecioEspecialMartes;
        private bool _PrecioEspecialMiercoles;
        private bool _PrecioEspecialJueves;
        private bool _PrecioEspecialViernes;
        private bool _PrecioEspecialSabado;
        private bool _PrecioEspecialDomingo;
        private decimal _PrecioMayoreo;
        private decimal _PrecioNormal;
        private decimal _PrecioTemporada;
        private int _Resultado;
        private bool _Seleccionado;
        private DataTable _TablaDatos;
        private DataTable _TablaMonederos;
        private DataTable _TablaProductos;
        private string _UrlImagen;

        public bool AplicaIVA
        {
            get { return _AplicaIVA; }
            set { _AplicaIVA = value; }
        }
        public bool AplicaPrecioEspecial
        {
            get { return _AplicaPrecioEspecial; }
            set { _AplicaPrecioEspecial = value; }
        }
        public bool AplicaPrecioMayoreo
        {
            get { return _AplicaPrecioMayoreo; }
            set { _AplicaPrecioMayoreo = value; }
        }
        public bool AplicaPrecioTemporada
        {
            get { return _AplicaPrecioTemporada; }
            set { _AplicaPrecioTemporada = value; }
        }
        public bool BuscarTodos
        {
            get { return _BuscarTodos; }
            set { _BuscarTodos = value; }
        }
        public int CantidadMayoreo
        {
            get { return _CantidadMayoreo; }
            set { _CantidadMayoreo = value; }
        }
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }
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
        public string FamiliaDesc
        {
            get { return _FamiliaDesc; }
            set { _FamiliaDesc = value; }
        }
        public DateTime FechaFinTemp
        {
            get { return _FechaFinTemp; }
            set { _FechaFinTemp = value; }
        }
        public DateTime FechaInicioTemp
        {
            get { return _FechaInicioTemp; }
            set { _FechaInicioTemp = value; }
        }
        public int IDFamilia
        {
            get { return _IDFamilia; }
            set { _IDFamilia = value; }
        }
        public string IDProducto
        {
            get { return _IDProducto; }
            set { _IDProducto = value; }
        }
        public string IDServicio
        {
            get { return _IDServicio; }
            set { _IDServicio = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public byte[] Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }
        public string MensajeError
        {
            get { return _MensajeError; }
            set { _MensajeError = value; }
        }
        public string NombreServicio
        {
            get { return _NombreServicio; }
            set { _NombreServicio = value; }
        }
        public string NumInventario
        {
            get { return _NumInventario; }
            set { _NumInventario = value; }
        }
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public decimal PrecioEspecial
        {
            get { return _PrecioEspecial; }
            set { _PrecioEspecial = value; }
        }
        public bool PrecioEspecialLunes
        {
            get { return _PrecioEspecialLunes; }
            set { _PrecioEspecialLunes = value; }
        }
        public bool PrecioEspecialMartes
        {
            get { return _PrecioEspecialMartes; }
            set { _PrecioEspecialMartes = value; }
        }
        public bool PrecioEspecialMiercoles
        {
            get { return _PrecioEspecialMiercoles; }
            set { _PrecioEspecialMiercoles = value; }
        }
        public bool PrecioEspecialJueves
        {
            get { return _PrecioEspecialJueves; }
            set { _PrecioEspecialJueves = value; }
        }
        public bool PrecioEspecialViernes
        {
            get { return _PrecioEspecialViernes; }
            set { _PrecioEspecialViernes = value; }
        }
        public bool PrecioEspecialSabado
        {
            get { return _PrecioEspecialSabado; }
            set { _PrecioEspecialSabado = value; }
        }
        public bool PrecioEspecialDomingo
        {
            get { return _PrecioEspecialDomingo; }
            set { _PrecioEspecialDomingo = value; }
        }
        public decimal PrecioMayoreo
        {
            get { return _PrecioMayoreo; }
            set { _PrecioMayoreo = value; }
        }
        public decimal PrecioNormal
        {
            get { return _PrecioNormal; }
            set { _PrecioNormal = value; }
        }
        public decimal PrecioTemporada
        {
            get { return _PrecioTemporada; }
            set { _PrecioTemporada = value; }
        }
        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
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
        public DataTable TablaMonederos
        {
            get { return _TablaMonederos; }
            set { _TablaMonederos = value; }
        }
        public DataTable TablaProductos
        {
            get { return _TablaProductos; }
            set { _TablaProductos = value; }
        }
        public string UrlImagen
        {
            get { return _UrlImagen; }
            set { _UrlImagen = value; }
        }


        private int _TiempoMinutos;

        public int TiempoMinutos
        {
            get { return _TiempoMinutos; }
            set { _TiempoMinutos = value; }
        }

        private bool _IncluirSelect;

        public bool IncluirSelect
        {
            get { return _IncluirSelect; }
            set { _IncluirSelect = value; }
        }

        private string _IDVenta;

        public string IDVenta
        {
            get { return _IDVenta; }
            set { _IDVenta = value; }
        }

        private string _IDSucursal;

        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }

        private string _IDEmpleado;

        public string IDEmpleado
        {
            get { return _IDEmpleado; }
            set { _IDEmpleado = value; }
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


        private decimal _CantidadVenta;

        public decimal CantidadVenta
        {
            get { return _CantidadVenta; }
            set { _CantidadVenta = value; }
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

        private decimal _IvaUnitario;

        public decimal IvaUnitario
        {
            get { return _IvaUnitario; }
            set { _IvaUnitario = value; }
        }

        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }


    }
}
