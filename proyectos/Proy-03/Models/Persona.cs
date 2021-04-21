using System;
namespace Proy_03.Models
{
    public class Persona
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }


        public Persona(int id, string nombre, int edad)
        {
            this.id = id;
            this.nombre = nombre;
            this.edad = edad;
        }
    }
}
