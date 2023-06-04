using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e11_recursive_method
{
    internal class Program
    {
        const int b1 = 1;
        const int b2 = 2;
        const int b3 = 3;
        const int b4 = 11;
        const int b5 = 21;
        static int licznikB4 = 0;
        static int licznikB5 = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Wywołanie wartości f(b5)...\n");
            int wynikB5 = f(b5);
            Console.WriteLine($"f(b5) = {wynikB5}");
            Console.WriteLine($"f(b4) zostało wywołane {licznikB4} razy");

            Console.ReadKey();
        }
        static int f(int n)
        {
            if (n == b4) licznikB4++;
            if (n == b5) licznikB5++;

            if (n < 2)
                return b1;
            else
                return f(n - 2) + b2 * f(n - 1) + (int)Math.Pow(n + b3, 2);
        }
    }
}
