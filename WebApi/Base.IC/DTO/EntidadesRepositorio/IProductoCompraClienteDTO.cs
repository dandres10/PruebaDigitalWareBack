namespace Base.IC.DTO.EntidadesRepositorio
{
    public interface IProductoCompraClienteDTO
    {
        int CodigoProducto { get; set; }
        int CodigoCompra { get; set; }
        int CodigoCliente { get; set; }
    }
}