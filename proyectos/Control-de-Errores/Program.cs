using System;

namespace Control_de_Errores
{
    class Program
    {
        static void Main(string[] args)
        {

            int N, M;

            int[] datos = new int[10];

            

            try
            {
                Console.Write("Escribe un numero: ");
                N = int.Parse(Console.ReadLine());

                M = N * 2;

                datos[0] = M;
                datos[7] = N;


                Console.WriteLine("El doble de N es {0}", M);

                M = M / N;

                Console.WriteLine("M entre N es {0}", M);

                Circulo llanta = new Circulo(5);

                Console.WriteLine("{0}", llanta.Area());

                Console.WriteLine("{0}", llanta.Perimetro());



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
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Numero de indice incorrecto");
            }
            catch (CirculoException)
            {
                Console.WriteLine("Solo valores positivos para el radio");
            }
                
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }
    }


    class Circulo
    {
        double radio;

        public Circulo(double radio)
        {
            if (radio >= 0)
                this.radio = radio;
            else
                throw new CirculoException();
         }

        public double Area()
        {
            return Math.PI * Math.Pow(radio, 2);
        }
        public double Perimetro()
        {
            return 2 * Math.PI * radio;
        }

    }

    class CirculoException : ApplicationException
    {
        public CirculoException() : base("Radio fuera de rango...")
        {
        }
    }

}
