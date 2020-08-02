using System;
using System.Collections.Generic;

namespace Base.Datos.Contexto.Entidades
{
    public partial class Producto
    {
        public Producto()
        {
            InventarioProducto = new HashSet<InventarioProducto>();
            ProductoCompraCliente = new HashSet<ProductoCompraCliente>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public virtual ICollection<InventarioProducto> InventarioProducto { get; set; }
        public virtual ICollection<ProductoCompraCliente> ProductoCompraCliente { get; set; }
    }
}
