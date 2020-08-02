namespace Base.Negocio.BO
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class ProductoBO : IProductoDTO
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}