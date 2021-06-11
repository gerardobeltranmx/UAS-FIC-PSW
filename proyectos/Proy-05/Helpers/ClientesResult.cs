using System;
namespace Proy_05
{
    public class ClientesResult
    {
        public bool estado { get; set; }
        public string Mensaje { get; set; }
        public string JSON { get; set; }

        public ClientesResult()
        {
            estado = true;
            Mensaje = "Sin Error";
            JSON = "{}";
        }

        public ClientesResult(bool estado, string Mensaje, string JSON)
        {
            this.estado = estado;
            this.Mensaje = Mensaje;
            this.JSON = JSON;
        }
    }
}
