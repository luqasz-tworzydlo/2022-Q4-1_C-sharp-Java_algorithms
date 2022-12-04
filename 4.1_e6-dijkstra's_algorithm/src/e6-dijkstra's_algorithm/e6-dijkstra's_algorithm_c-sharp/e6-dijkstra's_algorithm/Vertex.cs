using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e6_dijkstra_s_algorithm
{
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