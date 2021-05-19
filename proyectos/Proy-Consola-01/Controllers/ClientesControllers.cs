using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Proy_Consola_01.Models;

namespace Proy_Consola_01.Controllers
{
    public class ClientesControllers
    {
        WebClient cli;

        public void Conecta()
        {
            // Objeto de conexion con la Web API
            cli = new WebClient();
            cli.Headers.Add("Content-Type:application/json");
            cli.Headers.Add("Accept:application/json");
        }
        public void Nuevo()
        {

            Conecta();

            Console.WriteLine("Nuevo Cliente");

            Console.Write("Id     : ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nombre : ");
            string nombre = Console.ReadLine();

            Console.Write("Edad:   ");
            int edad = int.Parse(Console.ReadLine());

            Persona Nuevo = new Persona(id, nombre, edad);

            
            // envia los datos del nuevo cliente a la Web API
            var resultado = cli.UploadString("https://localhost:8080/api/clientes", "POST",
                                               JsonConvert.SerializeObject(Nuevo));

            Console.WriteLine("Cliente Registrado con exito!!!");



        }

        public void Reporte()
        {
            Conecta();


            var resultado = cli.DownloadString("https://localhost:8080/api/clientes");

            resultado = (string)JsonConvert.DeserializeObject(resultado);

            List<Persona> Clientes = JsonConvert.DeserializeObject<List<Persona>>(resultado);

            foreach (Persona c in Clientes)
                Console.WriteLine("{0} {1} {2}", c.id, c.nombre, c.edad);
        }

        public void Buscar()
        {
            Conecta();

            Console.Write("Numero de Cliente: ");
            int num = int.Parse(Console.ReadLine());

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
