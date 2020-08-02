namespace API.Controllers
{
    using API.Clases.ProductoCompraCliente;
    using AutoMapper;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.Negocio.BL;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductoCompraClienteController
    {
        private readonly ProductoCompraClienteBL productoCompraClienteBL;
        private readonly IMapper mapper;

        public ProductoCompraClienteController(ProductoCompraClienteBL productoCompraClienteBL, IMapper mapper)
        {
            this.productoCompraClienteBL = productoCompraClienteBL;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("GuardarProductoCompraCliente")]
        public async Task<Respuesta<ProductoCompraClienteB>> GuardarProductoCompraCliente(ProductoCompraClienteB compra)
        {
            return mapper.Map<Respuesta<ProductoCompraClienteB>>(await productoCompraClienteBL.GuardarProductoCompraCliente(mapper.Map<IProductoCompraClienteDTO>(compra)));
        }

        [HttpGet]
        [Route("ConsultarListaProductoCompraCliente")]
        public async Task<Respuesta<ProductoCompraClienteB>> ConsultarListaProductoCompraCliente()
        {
            return mapper.Map<Respuesta<ProductoCompraClienteB>>(await productoCompraClienteBL.ConsultarListaProductoCompraCliente());
        }
    }
}