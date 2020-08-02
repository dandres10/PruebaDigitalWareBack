namespace API.Clases.InventarioProducto
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class InventarioProductoB : IInventarioProductoDTO
    {
        public int Codigo { get; set; }
        public int CodigoProducto { get; set; }
        public int? Cantidad { get; set; }
    }
}