namespace API.Clases.Compra
{
    using Base.IC.DTO.EntidadesRepositorio;
    using System;

    public class CompraB : ICompraDTO
    {
        public int Codigo { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }
    }
}