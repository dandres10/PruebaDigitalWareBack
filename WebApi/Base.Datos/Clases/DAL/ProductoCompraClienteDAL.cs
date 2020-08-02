namespace Base.Datos.Clases.DAL
{
    using AutoMapper;
    using Base.Datos.Contexto;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.Acciones.Entidades;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.RecursosTexto;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductoCompraClienteDAL : IProductoCompraClienteAccion
    {
        private readonly Contexto contexto;
        private readonly IMapper mapper;
        private ProductoCompraCliente datos;
        private List<ProductoCompraCliente> datosLista;
        private List<string> listaMensajes;
        private Respuesta<IProductoCompraClienteDTO> Respuesta;
        private Respuestas<IProductoCompraClienteDTO> Respuestas;
        private List<IProductoCompraClienteDTO> listaProductoCompraCliente;

        public ProductoCompraClienteDAL(Contexto contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
            this.datos = new ProductoCompraCliente();
            this.datosLista = new List<ProductoCompraCliente>();
            this.listaMensajes = new List<string>();
            this.Respuesta = new Respuesta<IProductoCompraClienteDTO>();
            this.Respuestas = new Respuestas<IProductoCompraClienteDTO>();
            this.listaProductoCompraCliente = new List<IProductoCompraClienteDTO>();
        }

        public async Task<Respuesta<IProductoCompraClienteDTO>> ConsultarListaProductoCompraCliente()
        {
            try
            {
                listaProductoCompraCliente = mapper.Map<List<IProductoCompraClienteDTO>>(await contexto.ProductoCompraCliente.ToListAsync());
                listaMensajes.Add(MensajesBase.ConsultaExitosa);
                Respuesta = Respuestas.Exitosa(listaProductoCompraCliente, listaMensajes);
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }



        public async Task<Respuesta<IProductoCompraClienteDTO>> GuardarProductoCompraCliente(IProductoCompraClienteDTO productoCompraCliente)
        {
            try
            {
                listaProductoCompraCliente.Add(productoCompraCliente);
                contexto.ProductoCompraCliente.Add(mapper.Map<ProductoCompraCliente>(productoCompraCliente));
                await contexto.SaveChangesAsync();
                listaMensajes.Add(MensajesBase.GuardadoExitoso);
                Respuesta = Respuestas.Exitosa(listaProductoCompraCliente, listaMensajes);
            }
            catch (Exception ex)
            {
                var data = ex.Message;
                listaMensajes.Add(MensajesBase.GuardadoFallido);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }

            return Respuesta;
        }
    }
}