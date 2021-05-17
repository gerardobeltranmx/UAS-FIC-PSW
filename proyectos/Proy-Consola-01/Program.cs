using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Proy_Consola_01.Controllers;
using Proy_Consola_01.Models;

namespace Proy_Consola_01
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientesControllers ClientesOperaciones = new ClientesControllers();

            try
            {
                ClientesOperaciones.Reporte();
                ClientesOperaciones.Buscar();
               

            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);
            }




        }
    }
}
