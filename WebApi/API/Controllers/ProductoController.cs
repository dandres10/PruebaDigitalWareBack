namespace API.Controllers
{
    using API.Clases.Producto;
    using AutoMapper;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.Negocio.BL;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController
    {
        private readonly ProductoBL productoBL;
        private readonly IMapper mapper;

        public ProductoController(ProductoBL productoBL, IMapper mapper)
        {
            this.productoBL = productoBL;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("ConsultarProducto")]
        public async Task<Respuesta<ProductoB>> ConsultarProducto(ProductoB producto)
        {
            return mapper.Map<Respuesta<ProductoB>>(await productoBL.ConsultarProducto(mapper.Map<IProductoDTO>(producto)));
        }

        [HttpPost]
        [Route("GuardarProducto")]
        public async Task<Respuesta<ProductoB>> GuardarProducto(ProductoB producto)
        {
            return mapper.Map<Respuesta<ProductoB>>(await productoBL.GuardarProducto(mapper.Map<IProductoDTO>(producto)));
        }

        [HttpGet]
        [Route("ConsultarListaProducto")]
        public async Task<Respuesta<ProductoB>> ConsultarListaProducto()
        {
            return mapper.Map<Respuesta<ProductoB>>(await productoBL.ConsultarListaProducto());
        }

        [HttpPut]
        [Route("EditarProducto")]
        public async Task<Respuesta<ProductoB>> EditarProducto(ProductoB producto)
        {
            return mapper.Map<Respuesta<ProductoB>>(await productoBL.EditarProducto(mapper.Map<IProductoDTO>(producto)));
        }

        [HttpPost]
        [Route("EliminarProducto")]
        public async Task<Respuesta<ProductoB>> EliminarProducto(ProductoB producto)
        {
            return mapper.Map<Respuesta<ProductoB>>(await productoBL.EliminarProducto(mapper.Map<IProductoDTO>(producto)));
        }

        [HttpPost]
        [Route("ConsultarProductosCantidadMinimaPermitida")]
        public async Task<Respuesta<ProductosCantidadMinimaPermitidaSpB>> ProductosCantidadMinimaPermitida(RequestProductosCantidadPermitida requestProductosCantidadPermitida)
        {
            return mapper.Map<Respuesta<ProductosCantidadMinimaPermitidaSpB>>(await productoBL.ProductosCantidadMinimaPermitida(requestProductosCantidadPermitida.cantidadMinima));
        }

        [HttpPost]
        [Route("ConsultarListaProductosVendidoAno")]
        public async Task<Respuesta<ListaProductosVendidoAnoSpB>> ListaProductosVendidoAno(RequestListaProductosVendidoAnoSpB datos)
        {
            return mapper.Map<Respuesta<ListaProductosVendidoAnoSpB>>(await productoBL.ListaProductosVendidoAno(datos));
        }
    }
}