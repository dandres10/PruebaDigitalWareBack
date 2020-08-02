namespace Base.IC.DTO.Consultas.Cliente
{
    public interface IClientesFiltroEdadFechaCompraSpDTO
    {
        int CodigoCliente { get; set; }
        string Nombre { get; set; }
        int Edad { get; set; }
        int Cedula { get; set; }
    }
}