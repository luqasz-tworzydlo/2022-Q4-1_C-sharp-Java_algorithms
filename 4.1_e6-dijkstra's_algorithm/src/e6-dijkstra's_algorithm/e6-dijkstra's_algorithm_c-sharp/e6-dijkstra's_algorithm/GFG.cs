using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e6_dijkstra_s_algorithm
{
    public class GFG
    {
        // A utility function to find the vertex with minimum distance value,
        // from the set of vertices not yet included in shortest path tree
        static int Max_Amount_of_Vertices = 5;
        int minDistance(int[] dist,
                        bool[] sptSet)
        {
            // Initialize min value
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < Max_Amount_of_Vertices; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        // A utility function to print the constructed distance array
        void printSolution(int[] dist, int n)
        {
            Console.Write("\nVertex     Distance "
                          + "from Source\n");
            for (int i = 0; i < Max_Amount_of_Vertices; i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");

            // 'to do' => ścieżka od 0 do 4 [sekwencja tych wierzchołków, od 1 do 5]
            GFG D_SPL = new GFG();
            D_SPL.InsertVertex("Zero");
            D_SPL.InsertVertex("One");
            D_SPL.InsertVertex("Two");
            D_SPL.InsertVertex("Three");
            D_SPL.InsertVertex("Four");

            D_SPL.InsertEdge("Zero", "One", 10);
            D_SPL.InsertEdge("Zero", "Four", 100);
            D_SPL.InsertEdge("Zero", "Three", 30);
            D_SPL.InsertEdge("One", "Two", 50);
            D_SPL.InsertEdge("Two", "Four", 10);
            D_SPL.InsertEdge("Three", "Two", 20);
            D_SPL.InsertEdge("Three", "Four", 60);

            D_SPL.FindPaths("Zero");
        }

        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///
        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///
        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///

        // A utility functions [ methods ] to display shortest path lenght
        // and it's path values from 0 to 4 [ 60: 0 => 3 => 2 => 4 ]
        int n, e;
        int[,] adj;
        This_Vertex[] vertexList;

        private readonly int Temporary_Value = 1, Permanent_Value = 2, Nil_Value = -1, Infinity_Value = 99999;

        public GFG()
        {
            adj = new int[Max_Amount_of_Vertices, Max_Amount_of_Vertices];
            vertexList = new This_Vertex[Max_Amount_of_Vertices];
        }


        private void dijkstra_plus(int s)
        {
            int v, c;

            for (v = 0; v < n; v++)
            {
                vertexList[v].status = Temporary_Value;
                vertexList[v].pathLength = Infinity_Value;
                vertexList[v].predecessor = Nil_Value;
            }

            vertexList[s].pathLength = 0;

            while (true)
            {
                c = TempVertexMinPathLength();
                if (c == Nil_Value) return;

                vertexList[c].status = Permanent_Value;

                for (v = 0; v < n; v++)
                {
                    if (IsAdjacent(c, v) && vertexList[v].status == Temporary_Value)
                        if (vertexList[c].pathLength + adj[c, v] < vertexList[v].pathLength)
                        {
                            vertexList[v].predecessor = c;
                            vertexList[v].pathLength = vertexList[c].pathLength + adj[c, v];
                        }
                }
            }
        }

        private int TempVertexMinPathLength()
        {
            int min = Infinity_Value, x = Nil_Value;
            for (int v = 0; v < n; v++)
            {
                if (vertexList[v].status == Temporary_Value && vertexList[v].pathLength < min)
                { min = vertexList[v].pathLength; x = v; }
            }
            return x;
        }

        public void FindPaths(String src)
        {
            int s = GetIndex(src); dijkstra_plus(s);
            Console.WriteLine("\n=> Source Vertex: " + src + "\n");

            // selected destination, v = 4; (!) change v = 4 to v = 0 if you want to see pats for each destination vertex (!)
            for (int v = 4; v < n; v++)
            {
                Console.WriteLine("=> Destination Vertex: " + vertexList[v].name);
                if (vertexList[v].pathLength == Infinity_Value)
                    Console.WriteLine("=> There is no path from " + src + " to vertex " + vertexList[v].name + "\n");
                else FindPath(s, v);
            }
        }

        private void FindPath(int s, int v)
        {
            int i, u, sd = 0, count = 0;
            int[] path = new int[n];

            while (v != s)
            {
                count++; path[count] = v;
                u = vertexList[v].predecessor;
                sd += adj[u, v]; v = u;
            }
            count++; path[count] = s;

            Console.Write("=> Shortest Path is: ");
            for (i = count; i >= 1; i--) Console.Write(path[i] + " ");
            Console.WriteLine("\n=> Shortest Path Lenght is: " + sd + "\n");
        }

        private int GetIndex(String s)
        {
            for (int i = 0; i < n; i++)
                if (s.Equals(vertexList[i].name)) return i;
            throw new System.InvalidOperationException("=> Invalid Vertex");
        }

        public void InsertVertex(String name)
        { vertexList[n++] = new This_Vertex(name); }

        private bool IsAdjacent(int u, int v)
        { return (adj[u, v] != 0); }

        public void InsertEdge(String s1, String s2, int wt)
        {
            int u = GetIndex(s1), v = GetIndex(s2);
            if (u == v) throw new System.InvalidOperationException("=> Not a valid edge");
            if (adj[u, v] != 0) Console.Write("=> Edge already present");
            else { adj[u, v] = wt; e++; }
        }

        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///
        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///
        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///

        // Function that implements Dijkstra's single source shortest path algorithm
        // for a graph represented using adjacency matrix representation
        public void dijkstra(int[,] graph, int src)
        {
            int[] dist = new int[Max_Amount_of_Vertices];
            // The output array. dist[i] will hold
            // the shortest distance from src to i

            // sptSet[i] will true if vertex i is included in shortest path
            // tree or shortest distance from src to i is finalized
            bool[] sptSet = new bool[Max_Amount_of_Vertices];

            // Initialize all distances as INFINITE and stpSet[] as false
            for (int i = 0; i < Max_Amount_of_Vertices; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            // Distance of source vertex from itself is always 0
            dist[src] = 0;

            // Find shortest path for all vertices
            for (int count = 0; count < Max_Amount_of_Vertices - 1; count++)
            {
                // Pick the minimum distance vertex from the set of vertices not yet
                // processed. u is always equal to src in first iteration.
                int u = minDistance(dist, sptSet);

                // Mark the picked vertex as processed
                sptSet[u] = true;

                // Update dist value of the adjacent vertices of the picked vertex.
                for (int v = 0; v < Max_Amount_of_Vertices; v++)
                    // Update dist[v] only if is not in sptSet, there is an edge
                    // from u to v, and total weight of path from src to v
                    // through u is smaller than current value of dist[v]
                    if (!sptSet[v] && graph[u, v] != 0 &&
                         dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    { dist[v] = dist[u] + graph[u, v]; }
            }

            // print the constructed distance array
            printSolution(dist, Max_Amount_of_Vertices);
        }
    }
}