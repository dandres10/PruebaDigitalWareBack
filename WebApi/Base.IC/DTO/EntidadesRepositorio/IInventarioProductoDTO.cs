namespace Base.IC.DTO.EntidadesRepositorio
{
    public interface IInventarioProductoDTO
    {
        int Codigo { get; set; }
        int CodigoProducto { get; set; }
        int? Cantidad { get; set; }
    }
}