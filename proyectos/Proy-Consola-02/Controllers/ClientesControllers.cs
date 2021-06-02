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

        public void Reporte()
        {
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


    }
}
