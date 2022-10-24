using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e1_indexes_array
{
    /// <summary>
    /// Exercise 1 solution
    /// </summary>
    class Program
    {
        /// <summary>
        /// Tests LastIndexOf and AllIndexesOf methods
        /// </summary>
        /// <param name="args">command-line arguments</param>
        static void Main(string[] args)
        {
            // build test dynamic array

            /*// [1.1] tablica 5 elementowa
            UnorderedIntDynamicArray tablica = new UnorderedIntDynamicArray();
            tablica.Add(1);
            tablica.Add(2);
            tablica.Add(3);
            tablica.Add(1);
            tablica.Add(10);
            // [1.2]
            tablica.Remove(3); // usuniecie wartosci 3 i przeniesienie ostatniej na miejsce usunietej
            Console.WriteLine(tablica);*/

            // test LastIndexOf with one item in dynamic array

            /*// [2.2] użycie metody z wykorzystaniem tablicy LastIndexOf
            UnorderedIntDynamicArray tablica = new UnorderedIntDynamicArray();
            tablica.Add(1);
            tablica.Add(2);
            tablica.Add(3);
            tablica.Add(1);
            tablica.Add(10);
            tablica.Remove(3);
            Console.WriteLine(tablica);

            Console.WriteLine(tablica.LastIndexOf(10));*/

            // test LastIndexOf with multiple items in the dynamic array

            /*// [2.3] powtarzanie sie z liczby
            UnorderedIntDynamicArray tablica = new UnorderedIntDynamicArray();
            tablica.Add(1);
            tablica.Add(2);
            tablica.Add(3);
            tablica.Add(1);
            tablica.Add(10);
            tablica.Remove(3);
            Console.WriteLine(tablica);

            Console.WriteLine(tablica.LastIndexOf(1));*/

            // test LastIndexOf with item not in dynamic array

            /*// [2.4] test z nieznana liczba
            UnorderedIntDynamicArray tablica = new UnorderedIntDynamicArray();
            tablica.Add(1);
            tablica.Add(2);
            tablica.Add(3);
            tablica.Add(1);
            tablica.Add(10);
            tablica.Remove(3);
            Console.WriteLine(tablica);

            Console.WriteLine(tablica.LastIndexOf(5));*/

            // test AllIndexesOf with one item in dynamic array

            /*// [3.2]
            UnorderedIntDynamicArray tablica = new UnorderedIntDynamicArray();
            tablica.Add(1);
            tablica.Add(2);
            tablica.Add(3);
            tablica.Add(1);
            tablica.Add(10);
            tablica.Remove(3);
            Console.WriteLine(tablica);

            Console.Write(tablica.AllIndexesOf(2));*/

            // test AllIndexesOf with multiple items in dynamic array

            // [3.3]
            UnorderedIntDynamicArray tablica = new UnorderedIntDynamicArray();
            tablica.Add(1);
            tablica.Add(2);
            tablica.Add(3);
            tablica.Add(1);
            tablica.Add(10);
            tablica.Remove(3);
            Console.WriteLine(tablica);

            Console.Write(tablica.AllIndexesOf(1));

            // test AllIndexesOf with item not in dynamic array

            /*// [3.4]
            UnorderedIntDynamicArray tablica = new UnorderedIntDynamicArray();
            tablica.Add(1);
            tablica.Add(2);
            tablica.Add(3);
            tablica.Add(1);
            tablica.Add(10);
            tablica.Remove(3);
            Console.WriteLine(tablica);

            Console.Write(tablica.AllIndexesOf(5));*/

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}