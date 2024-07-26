using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculadora
{
    internal class Program
    {
        static List<double> numeros = new List<double>();

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    MostrarMenu();
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            PedirNumeros();
                            break;
                        case 2:
                            MostrarResultado("La media es: " + CalcularMedia(numeros));
                            break;
                        case 3:
                            MostrarResultado("La mediana es: " + CalcularMediana(numeros));
                            break;
                        case 4:
                            MostrarResultado("La desviación estándar es: " + CalcularDesviacionEstandar(numeros));
                            break;
                        case 5:
                            numeros.Clear();
                            PedirNumeros();
                            break;
                        case 6:
                            Console.WriteLine("Gracias por usar el programa! Hasta pronto");
                            return;
                        default:
                            Console.WriteLine("Opción no válida, intenta de nuevo.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Ingreso inválido. Asegúrate de ingresar un número.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("Menú de Funciones Estadísticas:");
            Console.WriteLine("1. Ingresar números");
            Console.WriteLine("2. Calcular y mostrar la media");
            Console.WriteLine("3. Calcular y mostrar la mediana");
            Console.WriteLine("4. Calcular y mostrar la desviación estándar");
            Console.WriteLine("5. Volver a pedir números");
            Console.WriteLine("6. Salir");
            Console.Write("Selecciona una opción: ");
        }

        static void PedirNumeros()
        {
            Console.Clear();
            try
            {
                Console.Write("¿Cuántos números desea ingresar? ");
                int cantidad = Convert.ToInt32(Console.ReadLine());
                numeros.Clear();

                for (int i = 0; i < cantidad; i++)
                {
                    Console.Write($"Ingrese el número {i + 1}: ");
                    numeros.Add(Convert.ToDouble(Console.ReadLine()));
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Asegúrate de ingresar números válidos.");
                PedirNumeros(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }
        static double CalcularMedia(List<double> numeros)
        {
            double suma = 0;
            int cantidad = numeros.Count;

            foreach (double numero in numeros)
            {
                suma += numero;
            }

            return suma / cantidad;
        }

        static double CalcularMediana(List<double> numeros)
        {
            numeros.Sort();
            int n = numeros.Count;
            if (n % 2 == 0)
            {
                return (numeros[n / 2 - 1] + numeros[n / 2]) / 2;
            }
            else
            {
                return numeros[n / 2];
            }
        }

        static double CalcularDesviacionEstandar(List<double> numeros)
        {
            double media = CalcularMedia(numeros);
            double sumaCuadrados = numeros.Select(n => Math.Pow(n - media, 2)).Sum();
            return Math.Sqrt(sumaCuadrados / numeros.Count);
        }

        static void MostrarResultado(string mensaje)
        {
            Console.Clear();
            Console.WriteLine(mensaje);
        }
    }
}
