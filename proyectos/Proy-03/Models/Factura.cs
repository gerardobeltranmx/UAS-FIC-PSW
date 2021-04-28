using System;
namespace Proy_03.Models
{
    public class Factura
    {
        public int id { get; set; }
        public int idCliente { get; set; }
        public double SubTotal { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }

        public Factura(int id, int idCliente, double SubTotal, double IVA, double Total)
        {
            this.id = id;
            this.idCliente = idCliente;
            this.SubTotal = SubTotal;
            this.Total = Total;
        }
    }
}
