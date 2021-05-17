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
            WebClient cli = new WebClient();
            cli.Headers.Add("Content-Type:application/json");
            cli.Headers.Add("Accept:application/json");

            var resultado = cli.DownloadString("https://localhost:8080/api/clientes");

            resultado = (string)JsonConvert.DeserializeObject(resultado);

            List<Persona> Clientes = JsonConvert.DeserializeObject<List<Persona>>(resultado);

            foreach (Persona c in Clientes)
                Console.WriteLine("{0} {1} {2}", c.id, c.nombre, c.edad);
        }

        public void Buscar()
        {
            Console.Write("Numero de Cliente: ");
            int num = int.Parse(Console.ReadLine());

            WebClient cli = new WebClient();
            cli.Headers.Add("Content-Type:application/json");
            cli.Headers.Add("Accept:application/json");
            var resultado = cli.DownloadString("https://localhost:8080/api/clientes/" + num.ToString());
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
