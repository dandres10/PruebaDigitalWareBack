namespace API.Clases.Cliente
{
    using Base.IC.DTO.Consultas.Cliente;
    using System;

    public class RequestClientesFiltroEdadFechaCompraSpB : IRequestClientesFiltroEdadFechaCompraSpDTO
    {
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }
        public int edadNoMayor { get; set; }
    }
}