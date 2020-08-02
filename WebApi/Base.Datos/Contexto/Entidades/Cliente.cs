using System;
using System.Collections.Generic;

namespace Base.Datos.Contexto.Entidades
{
    public partial class Cliente
    {
        public Cliente()
        {
            ProductoCompraCliente = new HashSet<ProductoCompraCliente>();
        }

        public int Codigo { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Cedula { get; set; }

        public virtual ICollection<ProductoCompraCliente> ProductoCompraCliente { get; set; }
    }
}
