using e6_dijkstra_s_algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e6_dijkstra_s_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
            //                          { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
            //                          { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
            //                          { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
            //                          { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
            //                          { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
            //                          { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
            //                          { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
            //                          { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

            int[,] graph = new int[,] {
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