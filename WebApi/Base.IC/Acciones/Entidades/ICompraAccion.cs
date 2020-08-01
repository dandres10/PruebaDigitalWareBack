namespace Base.IC.Acciones.Entidades
{
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public interface ICompraAccion
    {
        Task<Respuesta<ICompraDTO>> GuardarCompra(ICompraDTO compra);

        Task<Respuesta<ICompraDTO>> ConsultarCompra(ICompraDTO compra);

        Task<Respuesta<ICompraDTO>> EditarCompra(ICompraDTO compra);

        Task<Respuesta<ICompraDTO>> ConsultarListaCompra();

        Task<Respuesta<ICompraDTO>> EliminarCompra(ICompraDTO compra);
    }
}