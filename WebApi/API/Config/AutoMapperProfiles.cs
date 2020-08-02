namespace API.Config
{
    using API.Clases.Cliente;
    using API.Clases.Compra;
    using API.Clases.InventarioProducto;
    using API.Clases.ProductoCompraCliente;
    using AutoMapper;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Mapper Cliente
            CreateMap<Respuesta<ClienteB>, Respuesta<IClienteDTO>>().ReverseMap();
            CreateMap<ClienteB, IClienteDTO>().ReverseMap();
            CreateMap<Cliente, IClienteDTO>().ReverseMap();
            //Mapper Compra
            CreateMap<Respuesta<CompraB>, Respuesta<ICompraDTO>>().ReverseMap();
            CreateMap<CompraB, ICompraDTO>().ReverseMap();
            CreateMap<Compra, ICompraDTO>().ReverseMap();
            //InventarioProducto
            CreateMap<Respuesta<InventarioProductoB>, Respuesta<IInventarioProductoDTO>>().ReverseMap();
            CreateMap<InventarioProductoB, IInventarioProductoDTO>().ReverseMap();
            CreateMap<InventarioProducto, IInventarioProductoDTO>().ReverseMap();
            //ProductoCompraCliente
            CreateMap<Respuesta<ProductoCompraClienteB>, Respuesta<IProductoCompraClienteDTO>>().ReverseMap();
            CreateMap<ProductoCompraClienteB, IProductoCompraClienteDTO>().ReverseMap();
            CreateMap<ProductoCompraCliente, IProductoCompraClienteDTO>().ReverseMap();
        }
    }
}