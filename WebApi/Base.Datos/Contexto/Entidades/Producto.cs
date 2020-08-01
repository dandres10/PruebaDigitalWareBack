namespace Base.Datos.Contexto.Entidades
{
    using System.Collections.Generic;

    public partial class Producto
    {
        public Producto()
        {
            InventarioProducto = new HashSet<InventarioProducto>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public virtual ICollection<InventarioProducto> InventarioProducto { get; set; }
    }
}