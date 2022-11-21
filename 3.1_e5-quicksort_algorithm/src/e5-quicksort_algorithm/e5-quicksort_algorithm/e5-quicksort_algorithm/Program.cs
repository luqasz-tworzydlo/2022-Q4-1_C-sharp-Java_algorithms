using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e5_quicksort_algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // nieposortowana tablica
            // [do posortowania przy użyciu quicksort]
            int[] tablica = { 6, 5, 4, 3, 2, 1, 9, 8, 7 };

            Console.WriteLine("Pierwotny wygląd tablicy to: ");
            foreach (var element in tablica)
            {
                Console.WriteLine("=> " + tablica);
            }

            Quick_Sort(tablica, 0, tablica.Length - 1);
            Console.WriteLine("\nPosegregowana tablica przy użyciu" +
                "\nsortowania szybkiego [czyli quicksort]:");
            foreach (var element_sort in tablica)
            {
                Console.WriteLine("=> " + tablica);
            }

            Console.ReadKey();
        }
        static void Quick_Sort(int[] a, int p, int r)
        {
            // a => tablica do posortowania
            // p => początkowy indeks [od lewej]
            // r => ostatni indeks [od prawej]
            if (p < r)
            {
                int q = Partition(a, p, r);
                // q => to jest pivot
                if (q > 1) // jeśli pivot jest większy od 1
                {
                    Quick_Sort(a, p, q - 1);
                }
                if (q + 1 < r) // jeśli pivot + 1 jest mniejszy od prawej strony
                {
                    Quick_Sort(a, q + 1, r);
                }
            }
        }
        static int Partition(int[] a, int p, int r)
        {
            int x = a[p]; // pivot = tablica[lewa]
            while (true)
            {
                while (a[p] < x)
                { p++; }
                while (a[r] > x)
                { r--; }

                if (p < r)
                {
                    if (a[p] == a[r])
                        return r;

                    int t = a[p]; // t => tymczasowe
                    a[p] = a[r];
                    a[r] = t;
                }
                else
                {
                    return r;
                }
            }
        }
    }
}