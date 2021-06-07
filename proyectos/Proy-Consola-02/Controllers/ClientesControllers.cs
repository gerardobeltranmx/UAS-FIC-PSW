using System;
using Proy_Consola_02.Db;
using Proy_Consola_02.Models;

namespace Proy_Consola_02.Controllers
{
    public class ClientesControllers
    {
        public ClientesControllers()
        {
        }
        public void Nuevo()
        {
            Console.WriteLine("Nuevo Cliente");
            string nombre;
            int edad;
            Datos db = new Datos();
            Console.Write("Nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Edad: ");
            edad = int.Parse(Console.ReadLine());
            Cliente NuevoCliente = new Cliente(nombre, edad);
            db.Clientes.Add(NuevoCliente);
            db.SaveChanges();
        }


        public void Reporte()
        {
            Console.WriteLine("Reporte de Clientes");

            try
            {
                Datos db = new Datos();
                var ListaClientes = db.Clientes;
                foreach (Cliente c in ListaClientes)
                {
                    Console.WriteLine("{0} {1} {2}", c.id, c.nombre, c.edad);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void Buscar()
        {
            Console.WriteLine("Buscar Cliente");

            int id;
            Datos db = new Datos();
            Console.Write("Numero: ");
            id = int.Parse(Console.ReadLine());
            Cliente BuscarCliente = db.Clientes.Find(id);
            if (BuscarCliente != null)
            {
                Console.WriteLine("Nombre: {0}: ", BuscarCliente.nombre);
                Console.WriteLine("Edad : {0}: ", BuscarCliente.edad);
            }
            else
                Console.WriteLine("Cliente no encontrado");
        }
    }
}
