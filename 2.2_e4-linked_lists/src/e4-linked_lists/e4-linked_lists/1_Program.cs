using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e4_linked_lists
{
    /// <summary>
    /// Tests the linked lists
    /// </summary>
    class Program
    {
        /// <summary>
        /// Tests the linked lists
        /// </summary>
        /// <param name="args">command-line arguments</param>
        static void Main(string[] args)
        {
            // 1
            UnsortedLinkedList<int> lista = new UnsortedLinkedList<int>();

            lista.Add(100);
            lista.Add(200);
            lista.Add(300);
            //lista.Remove(200);
            lista.Remove(100);
            // Console.WriteLine(lista);

            // metoda, któr dokładniej wypisuje informacje o węzłach
            // metoda PrintList wypisze o każdym węźle jego value, next, previous

            lista.PrintList();

            //TestUnsortedLinkedList.RunTestCases();
            //TestSortedLinkedList.RunTestCases();

            Console.ReadKey();
        }
    }
}
