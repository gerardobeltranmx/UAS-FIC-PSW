using System;
using System.Net;

namespace Proy_Consola_01
{
    class Program
    {
        static void Main(string[] args)
        {


            WebClient cli = new WebClient();

            cli.Headers.Add("Content-Type:application/json");
            cli.Headers.Add("Accept:application/json");

            var resultado = cli.DownloadString("https://localhost:8080/api/clientes/");

            Console.WriteLine(resultado);


        }
    }
}
