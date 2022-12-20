using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e9_bubblesort_algorithm
{
    // program wykonujący obliczenia przy wykorzystaniu
    // algorytmu bąbelkowego [ czyli algorytm BubbleSort ]
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] Our_Array = { 5, 7, 8, 3, 1, 4, 6, 8 };
            int qTemporary;
            for (int jValue_Right = 0; jValue_Right <= Our_Array.Length - 2; jValue_Right++)
            {
                for (int iValue_Left = 0; iValue_Left <= Our_Array.Length - 2; iValue_Left++)
                {
                    if (Our_Array[iValue_Left] > Our_Array[iValue_Left + 1])
                    {
                        qTemporary = Our_Array[iValue_Left + 1];
                        Our_Array[iValue_Left + 1] = Our_Array[iValue_Left];
                        Our_Array[iValue_Left] = qTemporary;
                    }
                }
            }
            Console.WriteLine("\n=> Our sorted list [using BubbleSort]:");
            foreach (int position in Our_Array)
                Console.Write(position + " ");

            Console.ReadKey();
        }
    }
}
