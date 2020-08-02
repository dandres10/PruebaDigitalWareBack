namespace Base.Datos.Clases.DAL
{
    using AutoMapper;
    using Base.Datos.Clases.DO.Consultas;
    using Base.Datos.Contexto;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.Acciones.Entidades;
    using Base.IC.ClasesTransversales;
    using Base.IC.DTO.Consultas.Producto;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.RecursosTexto;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductoDAL : IProductoAccion
    {
        private readonly Contexto contexto;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private Producto datos;
        private List<string> listaMensajes;
        private Respuesta<IProductoDTO> Respuesta;
        private Respuestas<IProductoDTO> Respuestas;
        private List<IProductoDTO> listaProducto;

        public ProductoDAL(Contexto contexto, IMapper mapper, IConfiguration configuration)
        {
            this.contexto = contexto;
            this.mapper = mapper;
            this.configuration = configuration;
            this.datos = new Producto();
            this.listaMensajes = new List<string>();
            this.Respuesta = new Respuesta<IProductoDTO>();
            this.Respuestas = new Respuestas<IProductoDTO>();
            this.listaProducto = new List<IProductoDTO>();
        }

        public async Task<Respuesta<IProductoDTO>> ConsultarProducto(IProductoDTO producto)
        {
            try
            {
                datos = await contexto.Producto.FirstOrDefaultAsync(x => x.Codigo == producto.Codigo);
                if (datos == null)
                {
                    listaMensajes.Add(MensajesBase.DatoNoEncontrado);
                    Respuesta = Respuestas.Alerta(listaMensajes);
                }
                else
                {
                    listaProducto.Add(datos);
                    listaMensajes.Add(MensajesBase.ConsultaExitosa);
                    Respuesta = Respuestas.Exitosa(listaProducto, listaMensajes);
                }
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IProductoDTO>> ConsultarListaProducto()
        {
            try
            {
                listaProducto = mapper.Map<List<IProductoDTO>>(await contexto.Producto.ToListAsync());
                listaMensajes.Add(MensajesBase.ConsultaExitosa);
                Respuesta = Respuestas.Exitosa(listaProducto, listaMensajes);
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IProductoDTO>> EditarProducto(IProductoDTO producto)
        {
            try
            {
                contexto.Entry(mapper.Map<Producto>(producto)).State = EntityState.Modified;
                await contexto.SaveChangesAsync();
                listaProducto.Add(mapper.Map<Producto>(producto));
                listaMensajes.Add(MensajesBase.DatosEditados);
                Respuesta = Respuestas.Exitosa(listaProducto, listaMensajes);
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.DatosNoEditados);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IProductoDTO>> EliminarProducto(IProductoDTO producto)
        {
            try
            {
                int compraId = await contexto.Producto.Select(x => x.Codigo).FirstOrDefaultAsync(x => x == producto.Codigo);

                if (compraId == default(int))
                {
                    listaProducto.Add(producto);
                    listaMensajes.Add(MensajesBase.DatoNoEncontrado);
                    Respuesta = Respuestas.Alerta(listaProducto, listaMensajes);
                }
                else
                {
                    contexto.Producto.Remove(new Producto { Codigo = compraId });
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

        public async Task<Respuesta<IProductoDTO>> GuardarProducto(IProductoDTO producto)
        {
            try
            {
                listaProducto.Add(producto);
                contexto.Add(mapper.Map<Producto>(producto));
                await contexto.SaveChangesAsync();
                listaMensajes.Add(MensajesBase.GuardadoExitoso);
                Respuesta = Respuestas.Exitosa(listaProducto, listaMensajes);
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.GuardadoFallido);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }

            return Respuesta;
        }

        public async Task<Respuesta<IProductosCantidadMinimaPermitidaSpDTO>> ProductosCantidadMinimaPermitida(int cantidadMinima)
        {
            Respuesta<IProductosCantidadMinimaPermitidaSpDTO> RespuestaConsulta = new Respuesta<IProductosCantidadMinimaPermitidaSpDTO>();
            Respuestas<IProductosCantidadMinimaPermitidaSpDTO> RespuestasConsulta = new Respuestas<IProductosCantidadMinimaPermitidaSpDTO>();
            using (SqlConnection sql = new SqlConnection(configuration.GetConnectionString("AppConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ListaProductosCantidadMinimaPermitida", sql))
                {
                    List<ProductosCantidadMinimaPermitidaSpDO> productosCantidadMinimaPermitidaSpDOs = new List<ProductosCantidadMinimaPermitidaSpDO>();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@cantidad", cantidadMinima));
                    await sql.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            productosCantidadMinimaPermitidaSpDOs.Add(MapperProductosCantidadMinimaPermitida(reader));
                        }
                        
                    }
                    listaMensajes.Add(MensajesBase.ConsultaExitosa);
                    RespuestaConsulta = RespuestasConsulta.Exitosa(mapper.Map<List<IProductosCantidadMinimaPermitidaSpDTO>>(productosCantidadMinimaPermitidaSpDOs), listaMensajes);

                    return RespuestaConsulta;
                }
            }
        }

        private ProductosCantidadMinimaPermitidaSpDO MapperProductosCantidadMinimaPermitida(SqlDataReader reader)
        {
            return new ProductosCantidadMinimaPermitidaSpDO
            {
                CodigoProducto = (int)reader["CodigoProducto"],
                Cantidad = (int)reader["Cantidad"],
                Nombre = reader["Nombre"].ToString(),
                Precio = Convert.ToDecimal(reader["Precio"])
            };
        }
    }
}