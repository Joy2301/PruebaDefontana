using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace prueba2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Ordenamiento();
            // FormatearNumeros();
            // GenerarAleatorios();
        }

        /*3.1.- En base al siguiente listado:
        var lista = new List<int>{15, 16, 14, 19,1, 20, 4, 13, 5, 23, 3, 7, 18, 12, 8, 11, 10, 9, 3, 6, 32, 11, 14, 7, 5, 2, 3, 4, 5, 2, 7, 8, 5, 9, 1, 5, 20, 11, 13, 6, 13, 17, 19, 4, 8, 7, 9, 6, 16, 12, 11, 5, 9};
        Implementa un ordenamiento, desde el valor más pequeño al más alto, con cualquier algoritmo implementado por ti (sin usar Sort(), OrderBy(), o métodos similares).*/
        static void Ordenamiento()
        {
            Console.WriteLine("Ejercicio 3.1");
            List<int> lista = new List<int> { 15, 16, 14, 19, 1, 20, 4, 13, 5, 23, 3, 7, 18, 12, 8, 11, 10, 9, 3, 6, 32, 11, 14, 7, 5, 2, 3, 4, 5, 2, 7, 8, 5, 9, 1, 5, 20, 11, 13, 6, 13, 17, 19, 4, 8, 7, 9, 6, 16, 12, 11, 5, 9 };

            int n = lista.Count;
            bool intercambio;

            for (int i = 0; i < n - 1; i++)
            {
                intercambio = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (lista[j] > lista[j + 1])
                    {
                        int temp = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = temp;
                        intercambio = true;
                    }
                }
                if (!intercambio) break;
            }

            // Imprimir la lista ordenada
            Console.WriteLine("Lista ordenada:");
            foreach (var num in lista)
            {
                Console.WriteLine(num);
            }


            Console.WriteLine("...");
            Console.WriteLine("Final del Ejercicio");
            Console.WriteLine("...");
            Console.WriteLine("");
        }


        //     1-1.- Genera una función para formatear números enteros positivos como pesos chilenos. Debes testear la función con estos 4 casos:
        // - 1000 => $1.000
        // - 1500230 => $1.500.230
        // - 500 => $500
        // - 234150 => $234.150
        static void FormatearNumeros()
        {
            Console.WriteLine("Ejercicio 1.1");
            List<int> lista = new List<int> { 1000, 1500230, 500, 234150 };
            NumberFormatInfo formato = new CultureInfo("es-AR").NumberFormat;

            formato.CurrencyGroupSeparator = ".";
            formato.NumberDecimalSeparator = ",";
            foreach (var item in lista)
            {
                Console.WriteLine(item.ToString("C0", formato));
            }

            Console.WriteLine("...");
            Console.WriteLine("Final del Ejercicio");
            Console.WriteLine("...");
            Console.WriteLine("");
        }




        static void GenerarAleatorios()
        {
            Console.WriteLine("Ejercicio 2.1, 2.2 y 2.3");
            //2-1.- Genera una lista de 10.000.000 números enteros aleatorios entre -100.000 y 100.000
            List<int> lista = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i <= 9999999; i++)
            {
                // var value = rnd.Next(-100000, 100001);
                // Console.WriteLine($"valor {value}");
                lista.Add(rnd.Next(-100000, 100000));
            }


            //2-2.- Imprime en distintas líneas por consola los siguientes datos:
            //     - El valor más alto en la lista.
            //     - El valor más bajo en la lista.
            //     - El promedio de todos los valores en la lista.
            //     - La cantidad de veces que se obtuvo el valor 0.

            var ListaMod = new
            {
                Maximo = lista.Max(),
                Minimo = lista.Min(),
                Promedio = lista.Average(),
                CantidadCeros = lista.Count(n => n == 0)
            };

            // 2-3: Obtener los 5 valores más repetidos
            var Top5 = lista.GroupBy(n => n)
                                     .Select(g => new { Numero = g.Key, Conteo = g.Count() })
                                     .OrderByDescending(g => g.Conteo)
                                     .Take(5)
                                     .ToList();

            // Imprimir resultados
            Console.WriteLine($"Valor más alto: {ListaMod.Maximo}");
            Console.WriteLine($"Valor más bajo: {ListaMod.Minimo}");
            Console.WriteLine($"Promedio: {ListaMod.Promedio}");
            Console.WriteLine($"Cantidad de veces que se obtuvo 0: {ListaMod.CantidadCeros}");

            Console.WriteLine("\nTop 5 valores más repetidos:");
            foreach (var item in Top5)
            {
                Console.WriteLine($"Número: {item.Numero}, Repeticiones: {item.Conteo}");
            }
            Console.WriteLine("...");
            Console.WriteLine("Final del Ejercicio");
            Console.WriteLine("...");
            Console.WriteLine("");
        }
    }

}