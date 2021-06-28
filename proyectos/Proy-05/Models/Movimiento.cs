using System;
namespace Proy_05.Models
{
    public class Movimiento
    {
        public int id { get; set; }
        public int idcliente { get; set; }
        public string tipo { get; set; }
        public double cantidad { get; set; }

        public Movimiento(int idcliente, string tipo, double cantidad)
        {
            this.idcliente = idcliente;
            this.tipo = tipo;
            this.cantidad = cantidad;
        }

    }
}
