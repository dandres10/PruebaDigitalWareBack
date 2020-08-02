namespace API.Clases.Producto
{
    using Base.IC.DTO.Consultas.Producto;

    public class RequestListaProductosVendidoAnoSpB : IRequestListaProductosVendidoAnoSpDTO
    {
        public int Ano { get; set; }
    }
}