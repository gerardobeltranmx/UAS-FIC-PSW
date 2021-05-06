using System;

namespace Control_de_Errores
{
    class Program
    {
        static void Main(string[] args)
        {

            int N, M;

            try
            {
                Console.Write("Escribe un numero: ");
                N = int.Parse(Console.ReadLine());

                M = N * 2;

                Console.WriteLine("El doble de N es {0}", M);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error: Solo se aceptan valor de {0} a {1}", int.MinValue, int.MaxValue);
            }
                
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }




        }
    }
}
