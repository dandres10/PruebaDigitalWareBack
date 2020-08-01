namespace Base.IC.ClasesTransversales

{
    using Base.IC.Enumeraciones;
    using System.Collections.Generic;

    public class RespuestaValidacion
    {
        public RespuestaValidacion()
        {
            Mensajes = new List<string>();
        }

        public bool Resultado { get; set; }

        public List<string> Mensajes { get; set; }
        public TipoNotificacion TipoNotificacion { get; set; }
    }
}