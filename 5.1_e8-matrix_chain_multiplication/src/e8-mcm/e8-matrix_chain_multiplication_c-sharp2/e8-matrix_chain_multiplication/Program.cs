using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e8_matrix_chain_multiplication
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    // Łukasz Tworzydło - nr albumu: gd29623 [zadanie z ustawieniem nawiasów i mnożeniem macierzy z 05.12.2022]
    // Informatyka, grupa laboratoryjna: INiS3_PR2.2 [Algorytmy i struktury danych]
    // [ dane wejściowe (*) => rozmiar tablicy z wymiarami oraz elementy tej tablicy ]
    // [ dane wyjściowe (*) => optymalna ilość mnożeń & optymalna ilość nawiasów ]
    //
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    internal class Program
    {
        static int number = 76; // użyte do wskazania litery, od której ma zacząć
        public static void Main()
        {
            // wartości do odczytywania wymiarów
            // => Our_Array - nasza tablica [którą będziemy
            // używać do odczytywania naszych wymiarów]
            int[] Our_Array = new int[] { 2, 3, 4, 5, 2 }; 
            int Matrix_Size = Our_Array.Length;

            // tabelka do odczytywania wymiarów
            // | P0 | P1 | P2 | P3 | P4 |
            // | 2  | 3  | 4  | 5  | 2  |

            Console.WriteLine("\n=> Optymalna ilość mnożeń naszych macierzy: " + FindOptionalCostAOrder(Our_Array, Matrix_Size));

            Console.ReadKey();
        }

        static int FindOptionalCostAOrder(int[] OurChain, int OurNumber)
        {
            int[,] Our_Matrices = new int[OurNumber, OurNumber];
            int[,] Matrix_Bracket = new int[OurNumber, OurNumber];
            int iFirstMatrice, jSecondMatrice, kOperations, lDifference, qValue;

            for (iFirstMatrice = 1; iFirstMatrice < OurNumber; iFirstMatrice++)
                Our_Matrices[iFirstMatrice, iFirstMatrice] = 0;

            for (lDifference = 2; lDifference < OurNumber; lDifference++)
            {
                for (iFirstMatrice = 1; iFirstMatrice < OurNumber - lDifference + 1; iFirstMatrice++)
                {
                    jSecondMatrice = iFirstMatrice + lDifference - 1;
                    if (jSecondMatrice == OurNumber) continue;
                    Our_Matrices[iFirstMatrice, jSecondMatrice] = int.MaxValue;

                    for (kOperations = iFirstMatrice; kOperations <= jSecondMatrice - 1; kOperations++)
                    {
                        qValue = Our_Matrices[iFirstMatrice, kOperations] + Our_Matrices[kOperations + 1, jSecondMatrice] + OurChain[iFirstMatrice - 1] * OurChain[kOperations] * OurChain[jSecondMatrice];
                        if (qValue < Our_Matrices[iFirstMatrice, jSecondMatrice]) { Our_Matrices[iFirstMatrice, jSecondMatrice] = qValue; Matrix_Bracket[iFirstMatrice, jSecondMatrice] = kOperations; }
                    }
                }
            }

            Console.Write("\n=> Optymalne ustawienie nawiasów [macierzy]:");
            Matrices_Brackets(1, OurNumber - 1, OurNumber, Matrix_Bracket);
            Console.WriteLine(""); return Our_Matrices[1, OurNumber - 1];
        }

        static void Matrices_Brackets(int iFirstMatrice, int jSecondMatrice, int OurNumber, int[,] MatrixBracket)
        {
            if (iFirstMatrice == jSecondMatrice) { Console.Write(Convert.ToString((char)(number + iFirstMatrice))); return; }
            // przypisanie każdej matrycy unikalnego oznaczenia
            // 'number + i' inicjuje oznaczenie matryycy, gdzie w przypadku
            // => wartości'number = 64' zaczyna od A (czyli kolejność: A,B,C,D)
            // => wartości'number = 76' zaczyna od M (czyli kolejność: M,N,O,P)

            Console.Write("("); Matrices_Brackets(iFirstMatrice, MatrixBracket[iFirstMatrice, jSecondMatrice], OurNumber, MatrixBracket);
            Matrices_Brackets(MatrixBracket[iFirstMatrice, jSecondMatrice] + 1, jSecondMatrice, OurNumber, MatrixBracket); Console.Write(")");
        }
    }
}
