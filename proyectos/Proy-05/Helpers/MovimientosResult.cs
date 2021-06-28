using System;
namespace Proy_05
{
    public class MovimientosResult
    {
        public bool estado { get; set; }
        public string Mensaje { get; set; }
        public object Datos { get; set; }

        public MovimientosResult()
        {
            estado = true;
            Mensaje = "Sin Error";
            Datos = null;
        }

        public MovimientosResult(bool estado, string Mensaje, object Datos)
        {
            this.estado = estado;
            this.Mensaje = Mensaje;
            this.Datos = Datos;
        }
    }
}
