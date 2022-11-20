using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e5_quicksort_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // nieposortowana tablica
            // [do posortowania przy użyciu quicksort]
            int[] tablica = new int[] { 6, 5, 4, 3, 2, 1, 9, 8, 7 };

            Console.WriteLine("=> Pierwotny wygląd tablicy to: ");
            foreach (var element in tablica)
            {
                Console.Write(" " + element);
            }

            Quick_Sort(tablica, 0, tablica.Length - 1);

            Console.WriteLine("\n=> Posegregowana tablica przy użyciu" +
                "\nsortowania szybkiego [czyli quicksort]:");

            foreach (var element_nowy in tablica)
            {
                Console.Write(" " + element_nowy);
            }

            Console.ReadKey();
        }

        private static void Quick_Sort(int[] a, int p, int r)
        {
            if (p < r)
            {
                // a => tablica do posortowania
                // p => początkowy indeks [od lewej]
                // r => ostatni indeks [od prawej]
                int q = Partition(a, p, r);
                // q => to jest pivot

                if (q > 1) // jeśli pivot jest większy od
                {
                    Quick_Sort(a, p, q - 1);
                }
                if (q + 1 < r) // jeśli pivot + 1 jest mniejszy od prawej strony
                {
                    Quick_Sort(a, q + 1, r);
                }
            }
        }

        private static int Partition(int[] a, int p, int r)
        {
            int q = a[p];
            // q => to jest pivot

            while (true)
            {
                while (a[p] < q)
                { p++; }

                while (a[r] > q)
                { r--; }

                if (p < r)
                {
                    if (a[p] == a[r]) return r;

                    int swap = a[p];
                    a[p] = a[r];
                    a[r] = swap;
                }
                else
                {
                    return r;
                }
            }
        }
    }
}