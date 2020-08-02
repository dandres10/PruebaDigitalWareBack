namespace Base.IC.Acciones.Entidades
{
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public interface IProductoCompraClienteAccion
    {
        Task<Respuesta<IProductoCompraClienteDTO>> GuardarProductoCompraCliente(IProductoCompraClienteDTO inventarioProducto);
        
        Task<Respuesta<IProductoCompraClienteDTO>> ConsultarListaProductoCompraCliente();


    }
}