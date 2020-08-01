namespace Base.IC.DTO.EntidadesRepositorio
{
    public interface IProductoDTO
    {
        int Codigo { get; set; }
        string Nombre { get; set; }
        decimal Precio { get; set; }
    }
}