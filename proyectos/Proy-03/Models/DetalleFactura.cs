using System;
namespace Proy_03.Models
{
    public class DetalleFactura
    {
        public int id { get; set; }
        public int idFactura { get; set; }
        public int  idProducto { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }

        public DetalleFactura(int id, int idFactura, int idProducto, int cantidad, double precio)
        {
            this.id = id;
            this.idFactura = idFactura;
            this.idProducto = idProducto;
            this.cantidad = cantidad;
            this.precio = precio;
        }
    }
}
