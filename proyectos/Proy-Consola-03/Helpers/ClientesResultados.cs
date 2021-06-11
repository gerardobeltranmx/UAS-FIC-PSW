using System;
namespace Proy_Consola_03
{
    public class ClientesResultados
    {
        public bool estado { get; set; }
        public string JSON { get; set; }
        public string MensajeError { get; set; }

        public ClientesResultados()
        {
            this.estado = true;
            this.JSON = "{}";
            this.MensajeError = "Sin Error"; 
        }
        public ClientesResultados(bool estado, string JSON, string MensajeError )
        {
            this.estado = estado;
            this.JSON = JSON;
            this.MensajeError = MensajeError;
        }
    }
}
