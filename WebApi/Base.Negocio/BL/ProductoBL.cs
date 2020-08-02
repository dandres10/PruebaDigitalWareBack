namespace Base.Negocio.BL
{
    using Base.Datos.Clases.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.Consultas.Producto;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public class ProductoBL : IProductoAccion
    {
        private readonly ProductoDAL productoDAL;

        public ProductoBL(ProductoDAL productoDAL)
        {
            this.productoDAL = productoDAL;
        }

        public async Task<Respuesta<IProductoDTO>> ConsultarProducto(IProductoDTO producto)
        {
            return await productoDAL.ConsultarProducto(producto);
        }

        public async Task<Respuesta<IProductoDTO>> ConsultarListaProducto()
        {
            return await productoDAL.ConsultarListaProducto();
        }

        public async Task<Respuesta<IProductoDTO>> EditarProducto(IProductoDTO producto)
        {
            return await productoDAL.EditarProducto(producto);
        }

        public async Task<Respuesta<IProductoDTO>> EliminarProducto(IProductoDTO producto)
        {
            return await productoDAL.EliminarProducto(producto);
        }

        public async Task<Respuesta<IProductoDTO>> GuardarProducto(IProductoDTO producto)
        {
            return await productoDAL.GuardarProducto(producto);
        }

        public async Task<Respuesta<IProductosCantidadMinimaPermitidaSpDTO>> ProductosCantidadMinimaPermitida(int cantidadMinima)
        {
            return await productoDAL.ProductosCantidadMinimaPermitida(cantidadMinima);
        }
    }
}