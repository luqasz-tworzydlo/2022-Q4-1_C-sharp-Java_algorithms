using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e9_bubblesort_algorithm
{
    // program wykonujący obliczenia przy wykorzystaniu
    // algorytmu bąbelkowego [ czyli algorytm BubbleSort ]
    internal class Program
    {
        public static int[] Our_Array = { 5, 7, 8, 3, 1, 4, 6, 8 };
        static void Main(string[] args)
        {
            BeforeASorting();

            AfterAFirstSort();
            AfterASecondSort();
            AfterAThirdSort();

            Console.WriteLine();
            FinalResult();
            Console.ReadKey();
        }
        static void BeforeASorting()
        {
            Console.WriteLine("\n=> Our unsorted list:");
            foreach (int position in Our_Array)
                Console.Write(position + " ");
            Console.WriteLine();
        }
        static void FinalResult()
        {
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
        }
        static void AfterAFirstSort()
        {
            int qTemporary;
            for (int jValue_Right = 0; jValue_Right <= 2 - 2; jValue_Right++)
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
            Console.WriteLine("\n=> Our values after a first sort [BubbleSort]:");
            foreach (int position in Our_Array)
                Console.Write(position + " ");
        }
        static void AfterASecondSort()
        {
            int qTemporary;
            for (int jValue_Right = 0; jValue_Right <= 2 - 2; jValue_Right++)
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
            Console.WriteLine("\n=> Our values after a second sort [BubbleSort]:");
            foreach (int position in Our_Array)
                Console.Write(position + " ");
        }
        static void AfterAThirdSort()
        {
            int qTemporary;
            for (int jValue_Right = 0; jValue_Right <= 2 - 2; jValue_Right++)
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
            Console.WriteLine("\n=> Our values after a third sort [BubbleSort]:");
            foreach (int position in Our_Array)
                Console.Write(position + " ");
        }
    }
}
