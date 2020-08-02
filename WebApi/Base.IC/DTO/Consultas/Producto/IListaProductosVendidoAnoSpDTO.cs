namespace Base.IC.DTO.Consultas.Producto
{
    public interface IListaProductosVendidoAnoSpDTO
    {
        int CodigoProducto { get; set; }
        string Nombre { get; set; }
        decimal Vendido { get; set; }
        int Cantidad { get; set; }
        decimal ValorUnidad { get; set; }
    }
}