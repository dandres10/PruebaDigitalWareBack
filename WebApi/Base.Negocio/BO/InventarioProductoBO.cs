namespace Base.Negocio.BO
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class InventarioProductoBO : IInventarioProductoDTO
    {
        public int Codigo { get; set; }
        public int CodigoProducto { get; set; }
        public int? Cantidad { get; set; }
    }
}