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
        public static void Main(string[] args)
        {
            Methods();
        }
        public static void Methods()
        {
            Console.WriteLine("\nWhich version of a Matrix Chain Multiplication do you want to choose?" +
                "\n=> to choose a method no 1 write: 'ONE'" +
                "\n=> to choose a method no 2 write: 'TWO'\n");
            string SelectMethod;
            SelectMethod = Convert.ToString(Console.ReadLine());
            switch (SelectMethod)
            {
                default: Console.WriteLine("You didn't select a method... maybe a next time ;p"); Restart(); break;
                case "ONE": Console.WriteLine("\nYou have selected a 'Method no 1'"); MethodNo1(); Restart(); break;
                case "1": Console.WriteLine("\nYou have selected a 'Method no 1'"); MethodNo1(); Restart(); break;
                case "TWO": Console.WriteLine("\nYou have selected a 'Method no 2'"); MethodNo2(); Restart(); break;
                case "2": Console.WriteLine("\nYou have selected a 'Method no 2'"); MethodNo2(); Restart(); break;
            }
        }
        public static void Restart()
        {
            Console.WriteLine("\nDo you would like to restart a program?" +
                "\nWrite \"YES\" if you do... or \"NO\"\n");

            string YoN;
            YoN = Convert.ToString(Console.ReadLine());
            switch (YoN)
            {
                case "YES":
                    Methods(); break;
                case "Y":
                    Methods(); break;
                case "NO": Console.WriteLine("That's okay. See ya ;>"); break;
                case "N": Console.WriteLine("That's okay. See ya ;>"); break;
                default:
                    Console.WriteLine("You didn't write anything...;<"); break;
            }
        }
        public static void MethodNo2()
        {
            // sposób nr 1 [ do oznaczania macierzy (poprzez litery) ]
            int numberLetter = 76; // użyte do wskazania litery, od której ma zacząć
                                          // sposób nr 2 [ do oznaczania macierzy (poprzez liczby) ]
            int numberNumber = 0; // użyte do numerowania macierzy, zaczynając od 1 bądź 0
                                         // [jest to zależne od końcowej formy danej funkcji,
                                         // od miejsca ustawienia 'plusów' w funkcji]

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

            int FindOptionalCostAOrder(int[] OurChain, int OurNumber)
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

            void Matrices_Brackets(int iFirstMatrice, int jSecondMatrice, int OurNumber, int[,] MatrixBracket)
            {
                // sposób nr 1 [ do oznaczania macierzy (poprzez litery) ]
                if (iFirstMatrice == jSecondMatrice) { Console.Write(Convert.ToString((char)(numberLetter + iFirstMatrice))); return; }
                // przypisanie każdej matrycy unikalnego oznaczenia
                // 'number + i' inicjuje oznaczenie matryycy, gdzie w przypadku
                // => wartości'number = 64' zaczyna od A (czyli kolejność: A,B,C,D)
                // => wartości'number = 76' zaczyna od M (czyli kolejność: M,N,O,P)

                // sposób nr 2 A [ do oznaczania macierzy (poprzez liczby) - zaczęcie od 1, czyli 1,2,3,4 ]
                // if (iFirstMatrice == jSecondMatrice) { Console.Write($"M{++numberNumber}"); return; }

                // sposób nr 2 B [ do oznaczania macierzy (poprzez liczby) - zaczęcie od 0, czyli 0,1,2,3 ]
                // if (iFirstMatrice == jSecondMatrice) { Console.Write($"M{numberNumber++}"); return; }


                Console.Write("("); Matrices_Brackets(iFirstMatrice, MatrixBracket[iFirstMatrice, jSecondMatrice], OurNumber, MatrixBracket);
                Matrices_Brackets(MatrixBracket[iFirstMatrice, jSecondMatrice] + 1, jSecondMatrice, OurNumber, MatrixBracket); Console.Write(")");
            }
        }

        public static void MethodNo1()
        {

            // Main - nasza metoda wywoławcza
            // wywołanie naszej funkcji, metody
            // => Calculate_Cost - oblicz koszt
            Program Calculate_Cost = new Program();

            // wartości do odczytywania wymiarów
            // => Our_Array - nasza tablica [którą będziemy
            // używać do odczytywania naszych wymiarów]
            int[] Our_Array = { 2, 3, 4, 5, 2 };

            // tabelka do odczytywania wymiarów
            // | P0 | P1 | P2 | P3 | P4 |
            // | 2  | 3  | 4  | 5  | 2  |

            // znajdywanie optymalnej wartości
            // => Final_Cost - ostateczny koszt
            // => Calculate_Cost - oblicz koszt
            Cost_Calculation Final_Cost = Calculate_Cost.FindOptionalCost(Our_Array);

            // wypisywanie naszych wartości (ostateczny wynik [koszt] mnożenia naszych macierzy,
            // czyli optymalna ilość mnożeń naszych macierzy oraz optymalne rozmieszczenie nawiasów
            Console.WriteLine("\n=> Optymalna ilość mnożeń naszych macierzy: " + Final_Cost.final_cost
                + "\n\n=> Optymalne ustawienie nawiasów [macierzy]: " + Final_Cost.final_label + "\n");

            // wymuszenie wcisnięcia klawisza przez
            // użytkownika w celu wyłączenia programu
            Console.ReadKey();
        }

        public static void OptimalCost(int[][] Our_Matrices,
        string[] Matrices_Labels, int Previous_Cost, Cost_Calculation Matric_Cost)
        // OptimalCost - optymalny koszt
        // Our_Matrices - nasze macierze
        // Matrices_Labels - etykiety macierzy
        // Previous_Cost - poprzedni koszt
        // Matric_Cost - koszt matrycy
        // Matrice_l - matryca l
        // Matrice_j - matryca j
        {
            // Matrice_l => nasza matryca nr 1 [ matryca l ]
            int Matrice_l = Our_Matrices.Length;

            if (Matrice_l < 2)
            { Matric_Cost.final_cost = 0; return; }
            else if (Matrice_l == 2)
            {
                int cost = Previous_Cost + (Our_Matrices[0][0] *
                Our_Matrices[0][1] * Our_Matrices[1][1]);

                // Wyłapanie minimalnego kosztu matrycy
                // [ istotne dla całego programu (!!!) ]
                if (cost < Matric_Cost.final_cost)
                {
                    Matric_Cost.final_cost = cost;
                    Matric_Cost.final_label = "(" + Matrices_Labels[0] + Matrices_Labels[1] + ")";
                }
                return;
            }

            for (int i = 0; i < Matrice_l - 1; i++)
            {
                // Matrice_j => nasza matryca nr 2 [ matryca j ]
                int Matrice_j; int[][] Our_New_Matrix = new int[Matrice_l - 1][];

                for (int x = 0; x < Matrice_l - 1; x++) Our_New_Matrix[x] = new int[2];

                string[] Our_New_Labels = new string[Matrice_l - 1]; int subIndex = 0;

                // łączenie naszych macierzy w jedną macierz
                // przy każdej pętli przesuwa się pozycja łączenia
                // => jeśli i jest równe 0 to ( AB ) C D ...
                // => jeśli i jest równe 1 to A ( BC ) D ...
                // => jeśli i jest równe 2 to A B ( CD ) ...
                // a następnie znajdywanie kosztu łączenia dwóch macierzy
                int Our_Total_Cost = (Our_Matrices[i][0] * Our_Matrices[i][1] * Our_Matrices[i + 1][1]);

                for (Matrice_j = 0; Matrice_j < i; Matrice_j++)
                {
                    Our_New_Matrix[subIndex] = Our_Matrices[Matrice_j];
                    Our_New_Labels[subIndex++] = Matrices_Labels[Matrice_j];
                }

                // po wcześniejszym połączeniu dwóch
                // macierzy są budowane nowe macierze
                // [ z uwzględnieniem zachowania etykiet ]
                Our_New_Matrix[subIndex][0] = Our_Matrices[i][0];
                Our_New_Matrix[subIndex][1] = Our_Matrices[i + 1][1];
                Our_New_Labels[subIndex++] = "(" + Matrices_Labels[i] + Matrices_Labels[i + 1] + ")";

                for (Matrice_j = i + 2; Matrice_j < Matrice_l; Matrice_j++)
                {
                    Our_New_Matrix[subIndex] = Our_Matrices[Matrice_j];
                    Our_New_Labels[subIndex++] = Matrices_Labels[Matrice_j];
                }

                OptimalCost(Our_New_Matrix, Our_New_Labels,
                Previous_Cost + Our_Total_Cost, Matric_Cost);
            }
        }

        public Cost_Calculation FindOptionalCost(int[] Our_Array)
        {
            // FindOptionalCost - znajdź optymalny koszt
            int[][] Our_Matrices = new int[Our_Array.Length - 1][];
            string[] Matrices_Labels = new string[Our_Array.Length - 1];
            int number = 77; // użyte do wskazania litery, od której ma zacząć

            for (int i = 0; i < Our_Array.Length - 1; i++)
            {
                Our_Matrices[i] = new int[2];
                Our_Matrices[i][0] = Our_Array[i];
                Our_Matrices[i][1] = Our_Array[i + 1];
                Matrices_Labels[i] = Convert.ToString((char)(number + i));
                // przypisanie każdej matrycy unikalnego oznaczenia
                // 'number + i' inicjuje oznaczenie matryycy, gdzie w przypadku
                // => wartości'number = 65' zaczyna od A (czyli kolejność: A,B,C,D)
                // => wartości'number = 77' zaczyna od M (czyli kolejność: M,N,O,P)
            }

            Print_Matrices(Our_Matrices);

            Cost_Calculation Matric_Cost = new Cost_Calculation();
            OptimalCost(Our_Matrices, Matrices_Labels, 0, Matric_Cost);

            return Matric_Cost;
        }

        private static void Print_Matrices(int[][] Our_Matrices)
        {
            // wyświetlanie wyglądu naszych macierzy,
            // które będziemy później mnożyć
            Console.Write("=> Wygląd naszych macierzy, które będziemy mnożyć: \n" +
                "( ");
            foreach (int[] Row_s in Our_Matrices)
            {
                Console.Write("( " + string.Join(" ", Row_s) + " " + "), ");
            }
            Console.WriteLine(")\n");
        }
    }
}
