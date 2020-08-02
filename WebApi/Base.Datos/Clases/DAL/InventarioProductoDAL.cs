namespace Base.Datos.Clases.DAL

{
    using AutoMapper;
    using Base.Datos.Contexto;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.RecursosTexto;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class InventarioProductoDAL
    {
        private readonly Contexto contexto;
        private readonly IMapper mapper;
        private InventarioProducto datos;
        private List<string> listaMensajes;
        private Respuesta<IInventarioProductoDTO> Respuesta;
        private Respuestas<IInventarioProductoDTO> Respuestas;
        private List<IInventarioProductoDTO> listaInventarioProducto;

        public InventarioProductoDAL(Contexto contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
            this.datos = new InventarioProducto();
            this.listaMensajes = new List<string>();
            this.Respuesta = new Respuesta<IInventarioProductoDTO>();
            this.Respuestas = new Respuestas<IInventarioProductoDTO>();
            this.listaInventarioProducto = new List<IInventarioProductoDTO>();
        }

        public async Task<Respuesta<IInventarioProductoDTO>> ConsultarInventarioProducto(IInventarioProductoDTO inventarioProducto)
        {
            try
            {
                datos = await contexto.InventarioProducto.FirstOrDefaultAsync(x => x.Codigo == inventarioProducto.Codigo);
                if (datos == null)
                {
                    listaMensajes.Add(MensajesBase.DatoNoEncontrado);
                    Respuesta = Respuestas.Alerta(listaMensajes);
                }
                else
                {
                    listaInventarioProducto.Add(datos);
                    listaMensajes.Add(MensajesBase.ConsultaExitosa);
                    Respuesta = Respuestas.Exitosa(listaInventarioProducto, listaMensajes);
                }
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IInventarioProductoDTO>> ConsultarListaInventarioProducto()
        {
            try
            {
                listaInventarioProducto = mapper.Map<List<IInventarioProductoDTO>>(await contexto.InventarioProducto.ToListAsync());
                listaMensajes.Add(MensajesBase.ConsultaExitosa);
                Respuesta = Respuestas.Exitosa(listaInventarioProducto, listaMensajes);
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IInventarioProductoDTO>> EditarInventarioProducto(IInventarioProductoDTO inventarioProducto)
        {
            try
            {
                contexto.Entry(mapper.Map<InventarioProducto>(inventarioProducto)).State = EntityState.Modified;
                await contexto.SaveChangesAsync();
                listaInventarioProducto.Add(mapper.Map<InventarioProducto>(inventarioProducto));
                listaMensajes.Add(MensajesBase.DatosEditados);
                Respuesta = Respuestas.Exitosa(listaInventarioProducto, listaMensajes);
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.DatosNoEditados);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IInventarioProductoDTO>> EliminarInventarioProducto(IInventarioProductoDTO inventarioProducto)
        {
            try
            {
                int compraId = await contexto.InventarioProducto.Select(x => x.Codigo).FirstOrDefaultAsync(x => x == inventarioProducto.Codigo);

                if (compraId == default(int))
                {
                    listaInventarioProducto.Add(inventarioProducto);
                    listaMensajes.Add(MensajesBase.DatoNoEncontrado);
                    Respuesta = Respuestas.Alerta(listaInventarioProducto, listaMensajes);
                }
                else
                {
                    contexto.InventarioProducto.Remove(new InventarioProducto { Codigo = compraId });
                    await contexto.SaveChangesAsync();
                    listaMensajes.Add(MensajesBase.EliminacionExitosa);
                    Respuesta = Respuestas.Exitosa(listaMensajes);
                }
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.EliminacionFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }

            return Respuesta;
        }

        public async Task<Respuesta<IInventarioProductoDTO>> GuardarInventarioProducto(IInventarioProductoDTO cliente)
        {
            try
            {
                listaInventarioProducto.Add(cliente);
                contexto.Add(mapper.Map<InventarioProducto>(cliente));
                await contexto.SaveChangesAsync();
                listaMensajes.Add(MensajesBase.GuardadoExitoso);
                Respuesta = Respuestas.Exitosa(listaInventarioProducto, listaMensajes);
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.GuardadoFallido);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }

            return Respuesta;
        }
    }
}