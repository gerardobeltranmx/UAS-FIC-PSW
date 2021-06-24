using System;
namespace Proy_Consola_03
{
    public class ClientesResult
    {
        public bool estado { get; set; }
        public string Mensaje { get; set; }
        public object Datos { get; set; }

        public ClientesResult()
        {
            estado = true;
            Mensaje = "Sin Error";
            Datos = null;
        }

        public ClientesResult(bool estado, string Mensaje, object Datos)
        {
            this.estado = estado;
            this.Mensaje = Mensaje;
            this.Datos = Datos;
        }
    }
}
