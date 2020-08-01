namespace Base.IC.DTO.EntidadesRepositorio
{
    using System;

    public interface ICompraDTO
    {
        int Codigo { get; set; }
        DateTime FechaCompra { get; set; }
        decimal Total { get; set; }
    }
}