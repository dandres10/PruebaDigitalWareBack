using System;
using System.Collections.Generic;

namespace Base.Datos.Contexto.Entidades
{
    public partial class ProductoCompraCliente
    {
        public int Codigo { get; set; }
        public int CodigoProducto { get; set; }
        public int CodigoCompra { get; set; }
        public int CodigoCliente { get; set; }

        public virtual Cliente CodigoClienteNavigation { get; set; }
        public virtual Compra CodigoCompraNavigation { get; set; }
        public virtual Producto CodigoProductoNavigation { get; set; }
    }
}
