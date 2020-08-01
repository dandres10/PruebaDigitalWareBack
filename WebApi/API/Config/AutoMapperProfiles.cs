namespace API.Config
{
    using API.Clases.Cliente;
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
        }
    }
}