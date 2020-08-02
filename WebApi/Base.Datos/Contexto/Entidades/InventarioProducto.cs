using System;
using System.Collections.Generic;

namespace Base.Datos.Contexto.Entidades
{
    public partial class InventarioProducto
    {
        public int Codigo { get; set; }
        public int CodigoProducto { get; set; }
        public int? Cantidad { get; set; }

        public virtual Producto CodigoProductoNavigation { get; set; }
    }
}
