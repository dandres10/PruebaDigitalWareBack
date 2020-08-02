namespace API.Clases.Producto
{
    using Base.IC.DTO.Consultas.Producto;

    public class ListaProductosVendidoAnoSpB : IListaProductosVendidoAnoSpDTO
    {
        public int CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Vendido { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnidad { get; set; }
    }
}