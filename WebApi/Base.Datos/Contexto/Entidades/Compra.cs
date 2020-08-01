namespace Base.Datos.Contexto.Entidades
{
    using System;

    public partial class Compra
    {
        public int Codigo { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }
    }
}