namespace API.Clases.Producto
{
    using Base.IC.DTO.Consultas.Producto;

    public class ProductosCantidadMinimaPermitidaSpB : IProductosCantidadMinimaPermitidaSpDTO
    {
        public int CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}