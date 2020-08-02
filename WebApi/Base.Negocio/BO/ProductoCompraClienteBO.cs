namespace Base.Negocio.BO
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class ProductoCompraClienteBO : IProductoCompraClienteDTO
    {
        public int CodigoProducto { get; set; }
        public int CodigoCompra { get; set; }
        public int CodigoCliente { get; set; }
        public int Codigo { get ; set ; }
    }
}