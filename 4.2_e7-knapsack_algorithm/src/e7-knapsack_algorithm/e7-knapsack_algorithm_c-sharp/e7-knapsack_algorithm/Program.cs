using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Globalization;
using System.Threading;

// e7_knapsack_algorithm

namespace e7_knapsack_algorithm
{
    /// 0-1 Knapsack in C#
    /// Recursive version
    public class Program
    {
        private static void Main(string[] args)
        {
            Action<object> write = Console.Write;
            // var stopwatch = new Stopwatch();
            // stopwatch.Start();

            // var rand = new Random();

            // Task no 1 [data]
            const int n = 4; // n => amount of objects
            const int W = 5; // W => max weight
            var items = new List<Item>();

            for (var i = 0; i < n; i++)
            {
                // items.Add(new Item { WEIGHT = rand.Next(1, 10), VALUE = rand.Next(1, 100) });
                items.Add(new Item { WEIGHT = 2, VALUE = 3 });
                items.Add(new Item { WEIGHT = 3, VALUE = 4 });
                items.Add(new Item { WEIGHT = 4, VALUE = 5 });
                items.Add(new Item { WEIGHT = 5, VALUE = 6 });
            }

            Knapsack.Init(items, W);
            Knapsack.Run();

            // stopwatch.Stop();

            Knapsack.Print(write, true);

            // Console.Write(string.Format("\n\nDuration: {0}\nPress any key to exit a program...\n", stopwatch.Elapsed.ToString()));
            Console.ReadKey();
        }
    }

    static class Knapsack
    {
        static int[][] M { get; set; } // matrix
        static int[][] P { get; set; } // picks
        static Item[] I { get; set; } // items
        public static int MaxValue { get; private set; }
        static int W { get; set; } // max weight

        public static void Init(List<Item> items, int maxWeight)
        {
            I = items.ToArray();
            W = maxWeight;

            var n = I.Length;
            M = new int[n][];
            P = new int[n][];
            for (var i = 0; i < M.Length; i++) { M[i] = new int[W + 1]; }
            for (var i = 0; i < P.Length; i++) { P[i] = new int[W + 1]; }
        }

        public static void Run()
        { MaxValue = Recursive(I.Length - 1, W, 1); }

        static int Recursive(int i, int w, int depth)
        {
            var take = 0;
            if (M[i][w] != 0) { return M[i][w]; }

            if (i == 0)
            {
                if (I[i].WEIGHT <= w)
                {
                    P[i][w] = 1;
                    M[i][w] = I[0].VALUE;
                    return I[i].VALUE;
                }

                P[i][w] = -1;
                M[i][w] = 0;
                return 0;
            }

            if (I[i].WEIGHT <= w)
            {
                take = I[i].VALUE + Recursive(i - 1, w - I[i].WEIGHT, depth + 1);
            }

            var dontTake = Recursive(i - 1, w, depth + 1);

            M[i][w] = Max(take, dontTake);

            if (take > dontTake) { P[i][w] = 1; }
            else { P[i][w] = -1; }

            return M[i][w];
        }

        public static void Print(Action<object> write, bool full)
        {
            var list = new List<Item>();
            list.AddRange(I);
            var w = W;
            var i = list.Count - 1;

            write(string.Format("=> Total Amount of Items: = {0}\n\n", list.Count));
            if (full) { list.ForEach(a => write(string.Format("{0}\n", a))); }

            write(string.Format("\nMax weight = {0}\n", W));
            write(string.Format("Max value = {0}\n", MaxValue));
            write("\nPicks were:\n");

            var valueSum = 0;
            var weightSum = 0;
            while (i >= 0 && w >= 0)
            {
                if (P[i][w] == 1)
                {
                    valueSum += list[i].VALUE;
                    weightSum += list[i].WEIGHT;
                    if (full) { write(string.Format("{0}\n", list[i])); }
                    w -= list[i].WEIGHT;
                }

                i--;
            }
            write(string.Format("\nvalue sum: {0}\nweight sum: {1}",
                valueSum, weightSum));
        }

        static int Max(int a, int b)
        { return a > b ? a : b; }
    }

    class Item
    {
        private static int _COUNTER; // counter for the object
        public int ID { get; private set; } // id of the object
        public int VALUE { get; set; } // value of the object
        public int WEIGHT { get; set; } // weight of the object
        public Item()
        { ID = ++_COUNTER; } // counter in use

        public override string ToString()
        { return string.Format("ID: {0}  Value: {1}  Weight: {2}", ID, VALUE, WEIGHT); } // output [!]
    }
}