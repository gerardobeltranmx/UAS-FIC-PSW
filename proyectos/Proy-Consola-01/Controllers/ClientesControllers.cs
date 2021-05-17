using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Proy_Consola_01.Models;

namespace Proy_Consola_01.Controllers
{
    public class ClientesControllers
    {

        public void Reporte()
        {
            Console.WriteLine("Reporte de Clientes");
            WebClient cli = new WebClient();
            cli.Headers.Add("Content-Type:application/json");
            cli.Headers.Add("Accept:application/json");

            var resultado = cli.DownloadString("https://localhost:44382/api/clientes");

            resultado = (string)JsonConvert.DeserializeObject(resultado);

            List<Persona> Clientes = JsonConvert.DeserializeObject<List<Persona>>(resultado);

            Console.WriteLine("{0,4} {1,-25} {2,7}", "Id", "Nombre", "Edad");
            Console.WriteLine("======================================");
            foreach (Persona c in Clientes)
                Console.WriteLine("{0,4} {1,-30} {2,4}", c.id, c.nombre, c.edad);

            Console.WriteLine("======================================");

        }

        public void Buscar()
        {
            Console.WriteLine("Buscador de Clientes");
            Console.Write("Numero: ");
            int num = int.Parse(Console.ReadLine());

            WebClient cli = new WebClient();
            cli.Headers.Add("Content-Type:application/json");
            cli.Headers.Add("Accept:application/json");
            var resultado = cli.DownloadString("https://localhost:44382/api/clientes/" + num.ToString());
            resultado = (string)JsonConvert.DeserializeObject(resultado);

            Persona c = JsonConvert.DeserializeObject<Persona>(resultado);

            if (c != null)
            {
                Console.WriteLine("Id     : {0} ", c.id);
                Console.WriteLine("Nombre : {0} ", c.nombre);
                Console.WriteLine("Edad   : {0} ", c.edad);

            }
            else
                Console.WriteLine("Cliente NO existe!!!");

        }


    }
}
