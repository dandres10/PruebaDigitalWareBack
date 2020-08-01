namespace Base.IC.Acciones.Entidades
{
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public interface IInventarioProductoAccion
    {
        Task<Respuesta<IInventarioProductoDTO>> GuardarInventarioProducto(IInventarioProductoDTO inventarioProducto);

        Task<Respuesta<IInventarioProductoDTO>> EditarInventarioProducto(IInventarioProductoDTO inventarioProducto);

        Task<Respuesta<IInventarioProductoDTO>> ConsultarListaInventarioProducto();

        Task<Respuesta<IInventarioProductoDTO>> EliminarInventarioProducto(IInventarioProductoDTO inventarioProducto);

        Task<Respuesta<IInventarioProductoDTO>> ConsultarInventarioProducto(IInventarioProductoDTO inventarioProducto);
    }
}