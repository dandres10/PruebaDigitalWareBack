using System;
using System.Collections.Generic;

namespace Base.Datos.Contexto.Entidades
{
    public partial class Compra
    {
        public Compra()
        {
            ProductoCompraCliente = new HashSet<ProductoCompraCliente>();
        }

        public int Codigo { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<ProductoCompraCliente> ProductoCompraCliente { get; set; }
    }
}
