namespace Base.IC.DTO.Consultas.Cliente
{
    using System;

    public interface IRequestClientesFiltroEdadFechaCompraSpDTO
    {
        DateTime fechaInicial { get; set; }
        DateTime fechaFinal { get; set; }
        int edadNoMayor { get; set; }
    }
}