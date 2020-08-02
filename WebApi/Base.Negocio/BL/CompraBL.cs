namespace Base.Negocio.BL
{
    using Base.Datos.Clases.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public class CompraBL : ICompraAccion
    {
        private readonly CompraDAL compraDAL;

        public CompraBL(CompraDAL compraDAL)
        {
            this.compraDAL = compraDAL;
        }

        public async Task<Respuesta<ICompraDTO>> ConsultarCompra(ICompraDTO compra)
        {
            return await compraDAL.ConsultarCompra(compra);
        }

        public async Task<Respuesta<ICompraDTO>> ConsultarListaCompra()
        {
            return await compraDAL.ConsultarListaCompra();
        }

        public async Task<Respuesta<ICompraDTO>> EditarCompra(ICompraDTO compra)
        {
            return await compraDAL.EditarCompra(compra);
        }

        public async Task<Respuesta<ICompraDTO>> EliminarCompra(ICompraDTO compra)
        {
            return await compraDAL.EliminarCompra(compra);
        }

        public async Task<Respuesta<ICompraDTO>> GuardarCompra(ICompraDTO compra)
        {
            return await compraDAL.GuardarCompra(compra);
        }
    }
}