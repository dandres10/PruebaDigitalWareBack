namespace Base.Negocio.BL

{
    using Base.Datos.Clases.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public class InventarioProductoBL: IInventarioProductoAccion
    {
        private readonly InventarioProductoDAL inventarioProductoDAL;

        public InventarioProductoBL(InventarioProductoDAL inventarioProductoDAL)
        {
            this.inventarioProductoDAL = inventarioProductoDAL;
        }

        public async Task<Respuesta<IInventarioProductoDTO>> ConsultarInventarioProducto(IInventarioProductoDTO inventarioProducto)
        {
            return await inventarioProductoDAL.ConsultarInventarioProducto(inventarioProducto);
        }

        public async Task<Respuesta<IInventarioProductoDTO>> ConsultarListaInventarioProducto()
        {
            return await inventarioProductoDAL.ConsultarListaInventarioProducto();
        }

        public async Task<Respuesta<IInventarioProductoDTO>> EditarInventarioProducto(IInventarioProductoDTO inventarioProducto)
        {
            return await inventarioProductoDAL.EditarInventarioProducto(inventarioProducto);
        }

        public async Task<Respuesta<IInventarioProductoDTO>> EliminarInventarioProducto(IInventarioProductoDTO inventarioProducto)
        {
            return await inventarioProductoDAL.EliminarInventarioProducto(inventarioProducto);
        }

        public async Task<Respuesta<IInventarioProductoDTO>> GuardarInventarioProducto(IInventarioProductoDTO inventarioProducto)
        {
            return await inventarioProductoDAL.GuardarInventarioProducto(inventarioProducto);
        }
    }
}