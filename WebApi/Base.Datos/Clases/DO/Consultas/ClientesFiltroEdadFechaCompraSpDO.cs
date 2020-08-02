namespace Base.Datos.Clases.DO.Consultas
{
    using Base.IC.DTO.Consultas.Cliente;

    public class ClientesFiltroEdadFechaCompraSpDO : IClientesFiltroEdadFechaCompraSpDTO
    {
        public int CodigoCliente { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int Cedula { get; set; }
    }
}