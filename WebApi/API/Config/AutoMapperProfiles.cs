﻿namespace API.Config
{
    using API.Clases.Cliente;
    using API.Clases.Compra;
    using API.Clases.InventarioProducto;
    using API.Clases.Producto;
    using API.Clases.ProductoCompraCliente;
    using AutoMapper;
    using Base.Datos.Clases.DO.Consultas;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.Consultas.Cliente;
    using Base.IC.DTO.Consultas.Producto;
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
            //Producto
            CreateMap<Respuesta<ProductoB>, Respuesta<IProductoDTO>>().ReverseMap();
            CreateMap<ProductoB, IProductoDTO>().ReverseMap();
            CreateMap<Producto, IProductoDTO>().ReverseMap();
            //consultasProducto
            //ProductosCantidadMinimaPermitida
            CreateMap<Respuesta<ProductosCantidadMinimaPermitidaSpB>, Respuesta<IProductosCantidadMinimaPermitidaSpDTO>>().ReverseMap();
            CreateMap<ProductosCantidadMinimaPermitidaSpDO, IProductosCantidadMinimaPermitidaSpDTO>().ReverseMap();
            CreateMap<ProductosCantidadMinimaPermitidaSpB, IProductosCantidadMinimaPermitidaSpDTO>().ReverseMap();
            //ProductosVendidoAno
            CreateMap<Respuesta<ListaProductosVendidoAnoSpB>, Respuesta<IListaProductosVendidoAnoSpDTO>>().ReverseMap();
            CreateMap<ListaProductosVendidoAnoSpDO, IListaProductosVendidoAnoSpDTO>().ReverseMap();
            CreateMap<ListaProductosVendidoAnoSpB, IListaProductosVendidoAnoSpDTO>().ReverseMap();
            CreateMap<RequestListaProductosVendidoAnoSpB, IRequestListaProductosVendidoAnoSpDTO>().ReverseMap();
            //
            //consultaCliente
            CreateMap<Respuesta<ClientesFiltroEdadFechaCompraSpB>, Respuesta<IClientesFiltroEdadFechaCompraSpDTO>>().ReverseMap();
            CreateMap<ClientesFiltroEdadFechaCompraSpDO, IClientesFiltroEdadFechaCompraSpDTO>().ReverseMap();
            CreateMap<ClientesFiltroEdadFechaCompraSpB, IClientesFiltroEdadFechaCompraSpDTO>().ReverseMap();
            CreateMap<RequestClientesFiltroEdadFechaCompraSpB, IRequestClientesFiltroEdadFechaCompraSpDTO>().ReverseMap();
        }
    }
}