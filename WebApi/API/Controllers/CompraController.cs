namespace API.Controllers
{
    using API.Clases.Compra;
    using AutoMapper;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.Negocio.BL;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class CompraController
    {
        private readonly CompraBL clienteBL;
        private readonly IMapper mapper;

        public CompraController(CompraBL clienteBL, IMapper mapper)
        {
            this.clienteBL = clienteBL;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("ConsultarCompra")]
        public async Task<Respuesta<CompraB>> ConsultarCompra(CompraB compra)
        {
            return mapper.Map<Respuesta<CompraB>>(await clienteBL.ConsultarCompra(mapper.Map<ICompraDTO>(compra)));
        }

        [HttpPost]
        [Route("GuardarCompra")]
        public async Task<Respuesta<CompraB>> GuardarCompra(CompraB compra)
        {
            return mapper.Map<Respuesta<CompraB>>(await clienteBL.GuardarCompra(mapper.Map<ICompraDTO>(compra)));
        }

        [HttpGet]
        [Route("ConsultarListaCompra")]
        public async Task<Respuesta<CompraB>> ConsultarListaCompra()
        {
            return mapper.Map<Respuesta<CompraB>>(await clienteBL.ConsultarListaCompra());
        }

        [HttpPut]
        [Route("EditarCompra")]
        public async Task<Respuesta<CompraB>> EditarCompra(CompraB compra)
        {
            return mapper.Map<Respuesta<CompraB>>(await clienteBL.EditarCompra(mapper.Map<ICompraDTO>(compra)));
        }

        [HttpDelete]
        [Route("EliminarCompra")]
        public async Task<Respuesta<CompraB>> EliminarCompra(CompraB compra)
        {
            return mapper.Map<Respuesta<CompraB>>(await clienteBL.EliminarCompra(mapper.Map<ICompraDTO>(compra)));
        }
    }
}