using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Proy_Consola_01.Models;

namespace Proy_Consola_01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                WebClient cli = new WebClient();




                cli.Headers.Add("Content-Type:application/json");
                cli.Headers.Add("Accept:application/json");

                var resultado = cli.DownloadString("https://localhost:8080/api/clientes");

                resultado = (string) JsonConvert.DeserializeObject(resultado);

                List<Persona> Clientes = JsonConvert.DeserializeObject<List<Persona>>(resultado);

                foreach (Persona c in Clientes)
                    Console.WriteLine("{0} {1} {2}", c.id, c.nombre, c.edad);

            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);
            }




        }
    }
}
