using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e2_compare_to_array
{
    /// <summary>
    /// Exercise 2 solution
    /// </summary>
    class Program
    {
        /// <summary>
        /// Uses ordered generic dynamic array
        /// </summary>
        /// <param name="args">command-line arguments</param>
        static void Main(string[] args)
        {
            // [4.1]
            OrderedDynamicArray<Prostokat> tablica = new OrderedDynamicArray<Prostokat>();

            // [4.3]
            // 3x5, 1x11, 3x4
            tablica.Add(new Prostokat(3, 4));
            tablica.Add(new Prostokat(1, 11));
            tablica.Add(new Prostokat(3, 5));

            // tablica.Add(new Prostokat(2, 5));
            // tablica.Add(new Prostokat(11, 1));

            tablica.Print();

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}