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
    using System.Linq;
    using System.Threading.Tasks;

    public class CompraDAL : ICompraAccion
    {
        private readonly Contexto contexto;
        private readonly IMapper mapper;
        private Compra datos;
        private List<string> listaMensajes;
        private Respuesta<ICompraDTO> Respuesta;
        private Respuestas<ICompraDTO> Respuestas;
        private List<ICompraDTO> listaCompra;

        public CompraDAL(Contexto contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
            this.datos = new Compra();
            this.listaMensajes = new List<string>();
            this.Respuesta = new Respuesta<ICompraDTO>();
            this.Respuestas = new Respuestas<ICompraDTO>();
            this.listaCompra = new List<ICompraDTO>();
        }

        public async Task<Respuesta<ICompraDTO>> ConsultarCompra(ICompraDTO compra)
        {
            try
            {
                datos = await contexto.Compra.FirstOrDefaultAsync(x => x.Codigo == compra.Codigo);
                if (datos == null)
                {
                    listaMensajes.Add(MensajesBase.DatoNoEncontrado);
                    Respuesta = Respuestas.Alerta(listaMensajes);
                }
                else
                {
                    listaCompra.Add(datos);
                    listaMensajes.Add(MensajesBase.ConsultaExitosa);
                    Respuesta = Respuestas.Exitosa(listaCompra, listaMensajes);
                }
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<ICompraDTO>> ConsultarListaCompra()
        {
            try
            {
                listaCompra = mapper.Map<List<ICompraDTO>>(await contexto.Compra.ToListAsync());
                listaMensajes.Add(MensajesBase.ConsultaExitosa);
                Respuesta = Respuestas.Exitosa(listaCompra, listaMensajes);
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<ICompraDTO>> EditarCompra(ICompraDTO compra)
        {
            try
            {
                contexto.Entry(mapper.Map<Compra>(compra)).State = EntityState.Modified;
                await contexto.SaveChangesAsync();
                listaCompra.Add(mapper.Map<Compra>(compra));
                listaMensajes.Add(MensajesBase.DatosEditados);
                Respuesta = Respuestas.Exitosa(listaCompra, listaMensajes);
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.DatosNoEditados);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<ICompraDTO>> EliminarCompra(ICompraDTO compra)
        {
            try
            {
                int compraId = await contexto.Compra.Select(x => x.Codigo).FirstOrDefaultAsync(x => x == compra.Codigo);

                if (compraId == default(int))
                {
                    listaCompra.Add(compra);
                    listaMensajes.Add(MensajesBase.DatoNoEncontrado);
                    Respuesta = Respuestas.Alerta(listaCompra, listaMensajes);
                }
                else
                {
                    contexto.Compra.Remove(new Compra { Codigo = compraId });
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

        public async Task<Respuesta<ICompraDTO>> GuardarCompra(ICompraDTO cliente)
        {
            try
            {
                listaCompra.Add(cliente);
                contexto.Add(mapper.Map<Compra>(cliente));
                await contexto.SaveChangesAsync();
                listaMensajes.Add(MensajesBase.GuardadoExitoso);
                Respuesta = Respuestas.Exitosa(listaCompra, listaMensajes);
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