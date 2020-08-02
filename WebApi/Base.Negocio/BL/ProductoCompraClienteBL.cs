namespace Base.Negocio.BL
{
    using Base.Datos.Clases.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public class ProductoCompraClienteBL : IProductoCompraClienteAccion
    {
        private readonly ProductoCompraClienteDAL productoCompraClienteDAL;

        public ProductoCompraClienteBL(ProductoCompraClienteDAL productoCompraClienteDAL)
        {
            this.productoCompraClienteDAL = productoCompraClienteDAL;
        }

        public async Task<Respuesta<IProductoCompraClienteDTO>> ConsultarListaProductoCompraCliente()
        {
            return await productoCompraClienteDAL.ConsultarListaProductoCompraCliente();
        }

        public async Task<Respuesta<IProductoCompraClienteDTO>> GuardarProductoCompraCliente(IProductoCompraClienteDTO productoCompraCliente)
        {
            return await productoCompraClienteDAL.GuardarProductoCompraCliente(productoCompraCliente);
        }
    }
}