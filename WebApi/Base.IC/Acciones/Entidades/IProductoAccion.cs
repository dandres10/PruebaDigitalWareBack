namespace Base.IC.Acciones.Entidades
{
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.Consultas.Producto;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public interface IProductoAccion
    {
        Task<Respuesta<IProductoDTO>> GuardarProducto(IProductoDTO producto);

        Task<Respuesta<IProductoDTO>> ConsultarProducto(IProductoDTO producto);

        Task<Respuesta<IProductoDTO>> EditarProducto(IProductoDTO producto);

        Task<Respuesta<IProductoDTO>> ConsultarListaProducto();

        Task<Respuesta<IProductoDTO>> EliminarProducto(IProductoDTO producto);

        Task<Respuesta<IProductosCantidadMinimaPermitidaSpDTO>> ProductosCantidadMinimaPermitida(int cantidadMinima);

        Task<Respuesta<IListaProductosVendidoAnoSpDTO>> ListaProductosVendidoAno(IRequestListaProductosVendidoAnoSpDTO datos);
    }
}