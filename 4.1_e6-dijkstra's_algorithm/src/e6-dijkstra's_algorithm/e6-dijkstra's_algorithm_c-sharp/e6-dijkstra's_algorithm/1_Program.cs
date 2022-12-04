using e6_dijkstra_s_algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e6_dijkstra_s_algorithm
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    // Łukasz Tworzydło - nr albumu: gd29623 [zadanie z Algorytmu Dijkstry z 21.11.2022]
    // Informatyka, grupa laboratoryjna: INiS3_PR2.2 [Algorytmy i struktury danych]
    //
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[,]
            {
            {0, 10, 0, 30, 100 },
            {0, 0, 50, 0, 0 },
            {0, 0, 0, 0, 10},
            {0, 0, 20, 0, 60},
            {0, 0, 0, 0, 0}
            };

            GFG t = new GFG();
            t.dijkstra(graph, 0);

            Console.ReadKey();
        }
    }
}