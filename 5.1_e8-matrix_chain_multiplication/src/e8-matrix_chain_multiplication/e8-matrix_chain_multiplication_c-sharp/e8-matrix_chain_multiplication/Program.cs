using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e8_matrix_chain_multiplication
{
    public class Cost // => Cost - koszt
    {
        public string label = "";
        public int cost = Int32.MaxValue;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Main - nasza metoda wywoławcza
            // wywołanie naszej funkcji, metody
            // => Calculate_Cost - oblicz koszt
            Program Calculate_Cost = new Program();

            // wartości do odczytywania wymiarów
            // => Our_Array - nasza tablica [którą będziemy
            // używać do odczytywania naszych wymiarów]
            int[] Our_Array = { 2, 3, 4, 5, 2 };

            // znajdywanie optymalnej wartości
            // => Final_Cost - ostateczny koszt
            // => Calculate_Cost - oblicz koszt
            Cost Final_Cost = Calculate_Cost.FindOptionalCost(Our_Array);

            // wypisywanie naszych wartości
            Console.WriteLine("=> Kategoria: \n" + Final_Cost.label
                + "=> Koszt: \n" + Final_Cost.cost + "\n");

            // wymuszenie wcisnięcia klawisza przez
            // użytkownika w celu wyłączenia programu
            Console.ReadKey();
        }

        public static void OptimalCost(int[][] Our_Matrices,
        string[] Matrices_Labels, int Previous_Cost, Cost Matric_Cost)
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
            {
                Matric_Cost.cost = 0; return;
            }
            else if (Matrice_l == 2)
            {
                int cost = Previous_Cost + (Our_Matrices[0][0] *
                Our_Matrices[0][1] * Our_Matrices[1][1]);

                // Wyłapanie minimalnego kosztu matrycy
                // [ istotne dla całego programu (!!!) ]
                if (cost < Matric_Cost.cost)
                {
                    Matric_Cost.cost = cost;
                    Matric_Cost.label = "(" + Matrices_Labels[0] + Matrices_Labels[1] + ")";
                }
                return;
            }

            // redukcja - wykorzystanie rekurencji
            for (int i = 0; i < Matrice_l - 1; i++)
            {
                // Matrice_j => nasza matryca nr 2 [ matryca j ]
                int Matrice_j; int[][] newMatrix = new int[Matrice_l - 1][];

                for (int x = 0; x < Matrice_l - 1; x++) newMatrix[x] = new int[2];

                string[] newLabels = new string[Matrice_l - 1]; int subIndex = 0;

                // łączenie dwóch macierzy w jedną macierz
                // przy każdej pętli przesuwa się pozycja łączenia
                // => jeśli i jest równe 0 to ( AB ) C D ...
                // => jeśli i jest równe 1 to A ( BC ) D ...
                // => jeśli i jest równe 2 to A B ( CD ) ...
                // a następnie znajdywanie kosztu łączenia dwóch macierzy
                int cost = (Our_Matrices[i][0] * Our_Matrices[i][1] * Our_Matrices[i + 1][1]);

                for (Matrice_j = 0; Matrice_j < i; Matrice_j++)
                {
                    newMatrix[subIndex] = Our_Matrices[Matrice_j];
                    newLabels[subIndex++] = Matrices_Labels[Matrice_j];
                }

                // po wcześniejszym połączeniu dwóch
                // macierzy są budowane nowe macierze
                // [ z uwzględnieniem zachowania etykiet ]
                newMatrix[subIndex][0] = Our_Matrices[i][0];
                newMatrix[subIndex][1] = Our_Matrices[i + 1][1];
                newLabels[subIndex++] = "(" + Matrices_Labels[i] + Matrices_Labels[i + 1] + ")";

                for (Matrice_j = i + 2; Matrice_j < Matrice_l; Matrice_j++)
                {
                    newMatrix[subIndex] = Our_Matrices[Matrice_j];
                    newLabels[subIndex++] = Matrices_Labels[Matrice_j];
                }

                OptimalCost(newMatrix, newLabels,
                Previous_Cost + cost, Matric_Cost);
            }
        }

        private static void PrintMatrix(int[][] matrices)
        {
            // wyświetlanie naszej macierzy
            Console.Write("matrices = \n[");
            foreach (int[] row in matrices)
            {
                Console.Write("[ " + string.Join(" ", row) + " " + "], ");
            }
            Console.WriteLine("]");
        }

        public Cost FindOptionalCost(int[] arr)
        {
            // FindOptionalCost - znajdź optymalny koszt
            int[][] matrices = new int[arr.Length - 1][];
            string[] labels = new string[arr.Length - 1];

            for (int i = 0; i < arr.Length - 1; i++)
            {
                matrices[i] = new int[2];
                matrices[i][0] = arr[i];
                matrices[i][1] = arr[i + 1];
                labels[i] = Convert.ToString((char)(65 + i));
            }
            // PrintMatrix(matrices);

            Cost Cost = new Cost();
            OptimalCost(matrices, labels, 0, Cost);

            return Cost;
        }
    }
}
