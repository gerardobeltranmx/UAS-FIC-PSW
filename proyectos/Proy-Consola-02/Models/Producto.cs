using System;
namespace Proy_Consola_02.Models
{
    public class Producto
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int existencia { get; set; }

        public Producto(int id, string descripcion, decimal precio, int existencia)
        {
        }
    }
}
