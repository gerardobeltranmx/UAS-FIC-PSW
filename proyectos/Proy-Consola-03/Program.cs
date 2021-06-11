using System;
using Proy_Consola_03.Controllers;

namespace Proy_Consola_03
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientesControllers ClientesOperaciones = new ClientesControllers();

            ConsoleKey op = 0;
            
            do
            {
                Console.Clear();
                Console.WriteLine("Menu ");
                Console.WriteLine("(N)uevo");
                Console.WriteLine("(R)eporte");
                Console.WriteLine("(B)uscar");
                Console.WriteLine("(A)ctualizar");
                Console.WriteLine("(E)liminar");
                Console.WriteLine("(S)alir");

                Console.Write("Seleccione una opción: ");
                op = Console.ReadKey(false).Key;
                Console.Clear();

                try
                {
                    switch (op)
                    {
                        case ConsoleKey.N:
                           ClientesOperaciones.Nuevo();
                            break;
                        case ConsoleKey.R:
                            ClientesOperaciones.Reporte();
                            break;

                        case ConsoleKey.B:
                            ClientesOperaciones.Buscar();
                            break;
                        case ConsoleKey.A:
                        //    ClientesOperaciones.Actualizar();
                            break;
                        case ConsoleKey.E:
                          // ClientesOperaciones.Eliminar();
                            break;


                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Pulse una tecla para continuar");
                Console.ReadKey(false);

            } while (op != ConsoleKey.S);



        }
    }
}
