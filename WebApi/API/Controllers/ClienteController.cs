namespace API.Controllers
{
    using API.Clases.Cliente;
    using AutoMapper;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.Consultas.Cliente;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.Negocio.BL;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController
    {
        private readonly ClienteBL clienteBL;
        private readonly IMapper mapper;

        public ClienteController(ClienteBL clienteBL, IMapper mapper)
        {
            this.clienteBL = clienteBL;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("ConsultarCliente")]
        public async Task<Respuesta<ClienteB>> ConsultarCliente(ClienteB cliente)
        {
            return mapper.Map<Respuesta<ClienteB>>(await clienteBL.ConsultarCliente(mapper.Map<IClienteDTO>(cliente)));
        }

        [HttpPost]
        [Route("GuardarCliente")]
        public async Task<Respuesta<ClienteB>> GuardarCliente(ClienteB cliente)
        {
            return mapper.Map<Respuesta<ClienteB>>(await clienteBL.GuardarCliente(mapper.Map<IClienteDTO>(cliente)));
        }

        [HttpGet]
        [Route("ConsultarListaCliente")]
        public async Task<Respuesta<ClienteB>> ConsultarListaCliente()
        {
            return mapper.Map<Respuesta<ClienteB>>(await clienteBL.ConsultarListaCliente());
        }

        [HttpPut]
        [Route("EditarCliente")]
        public async Task<Respuesta<ClienteB>> EditarCliente(ClienteB cliente)
        {
            return mapper.Map<Respuesta<ClienteB>>(await clienteBL.EditarCliente(mapper.Map<IClienteDTO>(cliente)));
        }

        [HttpDelete]
        [Route("EliminarCliente")]
        public async Task<Respuesta<ClienteB>> EliminarCliente(ClienteB cliente)
        {
            return mapper.Map<Respuesta<ClienteB>>(await clienteBL.EliminarCliente(mapper.Map<IClienteDTO>(cliente)));
        }


        [HttpPost]
        [Route("ConsultarClientesFiltroEdadFechaCompra")]
        public async Task<Respuesta<ClientesFiltroEdadFechaCompraSpB>> ClientesFiltroEdadFechaCompra(RequestClientesFiltroEdadFechaCompraSpB datos)
        {
            return mapper.Map<Respuesta<ClientesFiltroEdadFechaCompraSpB>>(await clienteBL.ClientesFiltroEdadFechaCompra(mapper.Map<IRequestClientesFiltroEdadFechaCompraSpDTO>(datos)));
        }
    }
}