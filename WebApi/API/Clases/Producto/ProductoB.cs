namespace API.Clases.Producto
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class ProductoB : IProductoDTO
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}