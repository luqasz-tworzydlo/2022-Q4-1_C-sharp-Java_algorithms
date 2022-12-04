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
    internal class This_Vertex
    {
        public String name;
        public int
            status,
            predecessor,
            pathLength;

        public This_Vertex(String name)
        {
            this.name = name;
        }
    }
}