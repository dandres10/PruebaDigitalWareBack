namespace Base.Negocio.BO
{
    using Base.IC.DTO.EntidadesRepositorio;
    using System;

    public class CompraBO : ICompraDTO
    {
        public int Codigo { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }
    }
}