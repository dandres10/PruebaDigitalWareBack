namespace Base.IC.DTO.Consultas.Producto
{
    public interface IProductosCantidadMinimaPermitidaSpDTO
    {
        int CodigoProducto { get; set; }
        string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}