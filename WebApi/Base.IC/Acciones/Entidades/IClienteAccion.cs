namespace Base.IC.Acciones.Entidades
{
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public interface IClienteAccion
    {
        Task<Respuesta<IClienteDTO>> GuardarCliente(IClienteDTO cliente);

        Task<Respuesta<IClienteDTO>> ConsultarCliente(IClienteDTO cliente);

        Task<Respuesta<IClienteDTO>> EditarCliente(IClienteDTO cliente);

        Task<Respuesta<IClienteDTO>> ConsultarListaCliente();

        Task<Respuesta<IClienteDTO>> EliminarCliente(IClienteDTO cliente);
    }
}