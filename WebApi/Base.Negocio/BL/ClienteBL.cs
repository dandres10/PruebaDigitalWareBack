namespace Base.Negocio.BL
{
    using Base.Datos.Clases.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public class ClienteBL : IClienteAccion
    {
        private readonly ClienteDAL clienteDAL;

        public ClienteBL(ClienteDAL clienteDAL)
        {
            this.clienteDAL = clienteDAL;
        }

        public async Task<Respuesta<IClienteDTO>> ConsultarCliente(IClienteDTO cliente)
        {
            return await clienteDAL.ConsultarCliente(cliente);
        }

        public async Task<Respuesta<IClienteDTO>> ConsultarListaCliente()
        {
            return await clienteDAL.ConsultarListaCliente();
        }

        public async Task<Respuesta<IClienteDTO>> EditarCliente(IClienteDTO cliente)
        {
            return await clienteDAL.EditarCliente(cliente);
        }

        public async Task<Respuesta<IClienteDTO>> EliminarCliente(IClienteDTO cliente)
        {
            return await clienteDAL.EliminarCliente(cliente);
        }

        public async Task<Respuesta<IClienteDTO>> GuardarCliente(IClienteDTO cliente)
        {
            return await clienteDAL.GuardarCliente(cliente);
        }
    }
}