using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Global
{
    public class Producto
    {
        private bool _AplicaIVA;
        private bool _AplicaPrecioEspecial;
        private bool _AplicaPrecioMayoreo;
        private bool _AplicaPrecioTemporada;
        private bool _BuscarTodos;
        private int _Cantidad;
        private int _CantidadMayoreo;
        private int _CantidadMetrica;
        private string _Clave;
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private string _FamiliaDesc;
        private DateTime _FechaFinTemp;
        private DateTime _FechaInicioTemp;
        private int _IDFamilia;
        private int _IDMetrica;
        private string _IDProducto;
        private string _IDProductoXServicio;
        private int _IDTipoProducto;
        private int _IDTipoUso;
        private int _IDUnidadMedida;
        private string _IDUsuario;
        private bool _IncluirSelect;
        private byte[] _Imagen;
        private string _MensajeError;
        private string _MetricaDesc;
        private string _NombreProducto;
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
        private DataTable _TablaProveedores;
        private string _TipoProductoDesc;
        private string _TipoUsoDesc;
        private string _UnidadMedidaDesc;
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
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        public int CantidadMayoreo
        {
            get { return _CantidadMayoreo; }
            set { _CantidadMayoreo = value; }
        }
        public int CantidadMetrica
        {
            get { return _CantidadMetrica; }
            set { _CantidadMetrica = value; }
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
        public int IDMetrica
        {
            get { return _IDMetrica; }
            set { _IDMetrica = value; }
        }
        public string IDProducto
        {
            get { return _IDProducto; }
            set { _IDProducto = value; }
        }
        public string IDProductoXServicio
        {
            get { return _IDProductoXServicio; }
            set { _IDProductoXServicio = value; }
        }
        public int IDTipoProducto
        {
            get { return _IDTipoProducto; }
            set { _IDTipoProducto = value; }
        }
        public int IDTipoUso
        {
            get { return _IDTipoUso; }
            set { _IDTipoUso = value; }
        }
        public int IDUnidadMedida
        {
            get { return _IDUnidadMedida; }
            set { _IDUnidadMedida = value; }
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
        public string MetricaDesc
        {
            get { return _MetricaDesc; }
            set { _MetricaDesc = value; }
        }
        public string NombreProducto
        {
            get { return _NombreProducto; }
            set { _NombreProducto = value; }
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
        public DataTable TablaProveedores
        {
            get { return _TablaProveedores; }
            set { _TablaProveedores = value; }
        }
        public string TipoProductoDesc
        {
            get { return _TipoProductoDesc; }
            set { _TipoProductoDesc = value; }
        }
        public string TipoUsoDesc
        {
            get { return _TipoUsoDesc; }
            set { _TipoUsoDesc = value; }
        }
        public string UnidadMedidaDesc
        {
            get { return _UnidadMedidaDesc; }
            set { _UnidadMedidaDesc = value; }
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

        private decimal _Iva;

        public decimal Iva
        {
            get { return _Iva; }
            set { _Iva = value; }
        }

        private decimal _IvaTotal;

        public decimal IvaTotal
        {
            get { return _IvaTotal; }
            set { _IvaTotal = value; }
        }


        private decimal _Descuento;

        public decimal Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        private decimal _DescuentoTotal;

        public decimal DescuentoTotal
        {
            get { return _DescuentoTotal; }
            set { _DescuentoTotal = value; }
        }

        private decimal _Subtotal;

        public decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }

        private decimal _PorcentajeIva;

        public decimal PorcentajeIva
        {
            get { return _PorcentajeIva; }
            set { _PorcentajeIva = value; }
        }


        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }


        private decimal _PrecioCompra;

        public decimal PrecioCompra
        {
            get { return _PrecioCompra; }
            set { _PrecioCompra = value; }
        }

        private decimal _UltimoCosto;

        public decimal UltimoCosto
        {
            get { return _UltimoCosto; }
            set { _UltimoCosto = value; }
        }

        private string _IDProveedor;

        public string IDProveedor
        {
            get { return _IDProveedor; }
            set { _IDProveedor = value; }
        }

        private decimal _MargenError;

        public decimal MargenError
        {
            get { return _MargenError; }
            set { _MargenError = value; }
        }

        private List<PedidoDetalle> _ListaClaves;

        public List<PedidoDetalle> ListaClaves
        {
            get { return _ListaClaves; }
            set { _ListaClaves = value; }
        }

        private string _IDServicio;

        public string IDServicio
        {
            get { return _IDServicio; }
            set { _IDServicio = value; }
        }

        private DataTable _ImportarExcel;

        public DataTable ImportarExcel
        {
            get { return _ImportarExcel; }
            set { _ImportarExcel = value; }
        }

        private string _IDSucursal;

        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }

        private decimal _Existencia;

        public decimal Existencia
        {
            get { return _Existencia; }
            set { _Existencia = value; }
        }

        private int _IDPromocion;

        public int IDPromocion
        {
            get { return _IDPromocion; }
            set { _IDPromocion = value; }
        }

        private int _IDPromocionDetalle;

        public int IDPromocionDetalle
        {
            get { return _IDPromocionDetalle; }
            set { _IDPromocionDetalle = value; }
        }

        private int _IDPromocionDetalleProd;

        public int IDPromocionDetalleProd
        {
            get { return _IDPromocionDetalleProd; }
            set { _IDPromocionDetalleProd = value; }
        }

        private decimal _ExistenciaAlmacen;

        public decimal ExistenciaAlmacen
        {
            get { return _ExistenciaAlmacen; }
            set { _ExistenciaAlmacen = value; }
        }

        private decimal _ExistenciaUso;

        public decimal ExistenciaUso
        {
            get { return _ExistenciaUso; }
            set { _ExistenciaUso = value; }
        }

        private string _IDAsignacion;

        public string IDAsignacion
        {
            get { return _IDAsignacion; }
            set { _IDAsignacion = value; }
        }

        private string _ClaveProduccion;

        public string ClaveProduccion
        {
            get { return _ClaveProduccion; }
            set { _ClaveProduccion = value; }
        }

    }
}
