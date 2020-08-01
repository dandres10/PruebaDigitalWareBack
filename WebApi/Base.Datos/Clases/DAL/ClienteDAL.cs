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

    public class ClienteDAL : IClienteAccion
    {
        private readonly Contexto contexto;
        private readonly IMapper mapper;
        private Cliente datos;
        private List<string> listaMensajes;
        private Respuesta<IClienteDTO> Respuesta;
        private Respuestas<IClienteDTO> Respuestas;
        private List<IClienteDTO> listaCliente;

        public ClienteDAL(Contexto contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
            this.datos = new Cliente();
            this.listaMensajes = new List<string>();
            this.Respuesta = new Respuesta<IClienteDTO>();
            this.Respuestas = new Respuestas<IClienteDTO>();
            this.listaCliente = new List<IClienteDTO>();
        }

        public async Task<Respuesta<IClienteDTO>> ConsultarCliente(IClienteDTO cliente)
        {
            try
            {
                datos = await contexto.Cliente.FirstOrDefaultAsync(x => x.Codigo == cliente.Codigo);
                if (datos == null)
                {
                  
                    listaMensajes.Add(MensajesBase.DatoNoEncontrado);
                    Respuesta = Respuestas.Alerta(listaMensajes);
                }
                else
                {

                    listaCliente.Add(datos);
                    listaMensajes.Add(MensajesBase.ConsultaExitosa);
                    Respuesta = Respuestas.Exitosa(listaCliente, listaMensajes);
                }
            }
            catch (Exception)
            {
               
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IClienteDTO>> ConsultarListaCliente()
        {
            try
            {
                listaCliente = mapper.Map<List<IClienteDTO>>(await contexto.Cliente.ToListAsync());
                listaMensajes.Add(MensajesBase.ConsultaExitosa);
                Respuesta = Respuestas.Exitosa(listaCliente, listaMensajes);
                
            }
            catch (Exception)
            {
                
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IClienteDTO>> EditarCliente(IClienteDTO cliente)
        {
            try
            {
                contexto.Entry(mapper.Map<Cliente>(cliente)).State = EntityState.Modified;
                await contexto.SaveChangesAsync();
                listaCliente.Add(mapper.Map<Cliente>(cliente));
                listaMensajes.Add(MensajesBase.DatosEditados);
                Respuesta = Respuestas.Exitosa(listaCliente, listaMensajes);
                
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.DatosNoEditados);
                Respuesta = Respuestas.Fallida(listaMensajes);
                
            }
            return Respuesta;
        }

        public async Task<Respuesta<IClienteDTO>> EliminarCliente(IClienteDTO cliente)
        {
            try
            {
                
                int clienteId = await contexto.Cliente.Select(x => x.Codigo).FirstOrDefaultAsync(x => x == cliente.Codigo);
                
                if (clienteId == default(int))
                {
                    listaCliente.Add(cliente);
                    listaMensajes.Add(MensajesBase.DatoNoEncontrado);
                    Respuesta = Respuestas.Alerta(listaCliente, listaMensajes);
                    
                }
                else
                {
                    contexto.Cliente.Remove(new Cliente { Codigo = clienteId });
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

        public async Task<Respuesta<IClienteDTO>> GuardarCliente(IClienteDTO cliente)
        {
            try
            {
                listaCliente.Add(cliente);
                contexto.Add(mapper.Map<Cliente>(cliente));
                await contexto.SaveChangesAsync();
                listaMensajes.Add(MensajesBase.GuardadoExitoso);
                Respuesta = Respuestas.Exitosa(listaCliente, listaMensajes);
                
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