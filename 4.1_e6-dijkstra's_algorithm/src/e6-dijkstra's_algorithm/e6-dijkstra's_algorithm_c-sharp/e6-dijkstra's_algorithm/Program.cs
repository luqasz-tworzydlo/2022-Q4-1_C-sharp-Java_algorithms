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