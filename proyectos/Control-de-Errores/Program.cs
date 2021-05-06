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

                M = M / N;

                Console.WriteLine("M entre N es {0}", M);

            }
            catch (OverflowException )
            {
                Console.WriteLine("Error: Solo se aceptan valor de {0} a {1}", int.MinValue, int.MaxValue);
            }
            catch( FormatException )
            {
                Console.WriteLine("Solo se aceptan numeros!!!");

            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Se encontro que N es cero");
            }
                
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }




        }
    }
}
