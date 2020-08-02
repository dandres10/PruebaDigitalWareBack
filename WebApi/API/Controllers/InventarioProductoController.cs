namespace API.Controllers
{
    using API.Clases.InventarioProducto;
    using AutoMapper;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.Negocio.BL;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class InventarioProductoController
    {
        private readonly InventarioProductoBL inventarioProductoBL;
        private readonly IMapper mapper;

        public InventarioProductoController(InventarioProductoBL inventarioProductoBL, IMapper mapper)
        {
            this.inventarioProductoBL = inventarioProductoBL;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("ConsultarInventarioProducto")]
        public async Task<Respuesta<InventarioProductoB>> ConsultarInventarioProducto(InventarioProductoB inventarioProducto)
        {
            return mapper.Map<Respuesta<InventarioProductoB>>(await inventarioProductoBL.ConsultarInventarioProducto(mapper.Map<IInventarioProductoDTO>(inventarioProducto)));
        }

        [HttpPost]
        [Route("GuardarInventarioProducto")]
        public async Task<Respuesta<InventarioProductoB>> GuardarInventarioProducto(InventarioProductoB inventarioProducto)
        {
            return mapper.Map<Respuesta<InventarioProductoB>>(await inventarioProductoBL.GuardarInventarioProducto(mapper.Map<IInventarioProductoDTO>(inventarioProducto)));
        }

        [HttpGet]
        [Route("ConsultarListaInventarioProducto")]
        public async Task<Respuesta<InventarioProductoB>> ConsultarListaInventarioProducto()
        {
            return mapper.Map<Respuesta<InventarioProductoB>>(await inventarioProductoBL.ConsultarListaInventarioProducto());
        }

        [HttpPut]
        [Route("EditarInventarioProducto")]
        public async Task<Respuesta<InventarioProductoB>> EditarInventarioProducto(InventarioProductoB inventarioProducto)
        {
            return mapper.Map<Respuesta<InventarioProductoB>>(await inventarioProductoBL.EditarInventarioProducto(mapper.Map<IInventarioProductoDTO>(inventarioProducto)));
        }

        [HttpDelete]
        [Route("EliminarInventarioProducto")]
        public async Task<Respuesta<InventarioProductoB>> EliminarInventarioProducto(InventarioProductoB inventarioProducto)
        {
            return mapper.Map<Respuesta<InventarioProductoB>>(await inventarioProductoBL.EliminarInventarioProducto(mapper.Map<IInventarioProductoDTO>(inventarioProducto)));
        }
    }
}