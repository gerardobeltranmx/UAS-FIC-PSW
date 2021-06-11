using System;
namespace Proy_Consola_03.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }

        public Cliente(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }
    }
}
