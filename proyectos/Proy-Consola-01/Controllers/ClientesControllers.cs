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
        string URL = "https://localhost:58647/api/clientes/";
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
            Console.Write("Numero : ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nombre : ");
            string nombre = Console.ReadLine();
            Console.Write("Edad:   ");
            int edad = int.Parse(Console.ReadLine());
            Persona Nuevo = new Persona(id, nombre, edad);
            Conecta();
               
            // envia los datos del nuevo cliente a la Web API
            ClientesResultados respuesta = JsonConvert.DeserializeObject<ClientesResultados>(
                                                cli.UploadString(URL, "POST",
                                                JsonConvert.SerializeObject(Nuevo)));
            if (respuesta.estado == true)
                Console.WriteLine("Cliente Registrado con exito!!!");
            else 
                Console.WriteLine(respuesta.MensajeError);
        }

        public void Reporte()
        {
            Conecta();


            ClientesResultados respuesta = JsonConvert.DeserializeObject<ClientesResultados>(
                                                cli.DownloadString(URL));

            if (respuesta.estado == true)
            {
                List<Persona> Clientes = JsonConvert.DeserializeObject<List<Persona>>(respuesta.JSON);

                foreach (Persona c in Clientes)
                    Console.WriteLine("{0} {1} {2}", c.id, c.nombre, c.edad);
            }
            else
                Console.WriteLine(respuesta.MensajeError);
        }

        public void Buscar()
        {
            Conecta();

            
            Console.Write("Numero de Cliente: ");
            int num = int.Parse(Console.ReadLine());

            ClientesResultados respuesta = JsonConvert.DeserializeObject<ClientesResultados>(
                                                        cli.DownloadString(URL + num.ToString()));

            if (respuesta.estado==true)
            {
                Persona c = JsonConvert.DeserializeObject<Persona>(respuesta.JSON);
                Console.WriteLine("Id     : {0} ", c.id);
                Console.WriteLine("Nombre : {0} ", c.nombre);
                Console.WriteLine("Edad   : {0} ", c.edad);
            }
            else
                Console.WriteLine(respuesta.MensajeError);

        }




    }
}
