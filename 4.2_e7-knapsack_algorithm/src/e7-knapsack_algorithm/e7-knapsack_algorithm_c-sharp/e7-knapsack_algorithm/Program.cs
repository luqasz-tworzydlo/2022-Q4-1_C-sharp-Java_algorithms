using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace e7_knapsack_algorithm
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    // Łukasz Tworzydło - nr albumu: gd29623 [zadanie z problemu plecakowego [wersja 0-1] z 21.11.2022]
    // Informatyka, grupa laboratoryjna: INiS3_PR2.2 [Algorytmy i struktury danych]
    // knapsack [version 0-1] =>> problem plecakowy [wersja 0-1]
    //
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Program
    {
        // 0-1 Knapsack in C# =>>> Recursive version
        private static void Main(string[] args)
        {
            // stopwatch [measure the amount of time that
            // elapses between its activation and deactivation]
            /*var stopwatch = new Stopwatch();
            stopwatch.Start();*/

            RESULTS();

            /*stopwatch.Stop();
            Console.Write(string.Format("\n\nDuration: {0}\n" +
                "=> Press any key to exit a program...\n",
                stopwatch.Elapsed.ToString()));*/
            Console.ReadKey();
        }

        public static void GAP_B()
        { Console.WriteLine("\n/// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///\n"); }

        public static void RESULTS()
        {
            GAP_B(); TASK_NO_1(); GAP_B();
            TASK_NO_2(); GAP_B();
        }
        public static void TASK_NO_1()
        {
            Action<object> write = Console.Write;

            Console.WriteLine("TASK NO 1\n");

            // Task no 1 [data]
            const int n = 4; // n => amount of objects
            const int W = 5; // W => max weight
            var items = new List<Item>();

            // method no 1 [random items]
            /*var rand = new Random();
            for (var i = 0; i < n; i++)
            {
                items.Add(new Item { WEIGHT = rand.Next(1, 10), VALUE = rand.Next(1, 100) });
            }*/

            // method no 2 [specific items] (sometimes is wrong)
            /*for (var i = 0; i < n; i++)
            {
                items.Add(new Item { WEIGHT = 2, VALUE = 3 });
                items.Add(new Item { WEIGHT = 3, VALUE = 4 });
                items.Add(new Item { WEIGHT = 4, VALUE = 5 });
                items.Add(new Item { WEIGHT = 5, VALUE = 6 });
            }*/


            // method no 3 [specific items] (best method overall)
            items.AddRange(new List<Item>
                           {
                               new Item {ID = 1, WEIGHT = 2, VALUE = 3},
                               new Item {ID = 2, WEIGHT = 3, VALUE = 4},
                               new Item {ID = 3, WEIGHT = 4, VALUE = 5},
                               new Item {ID = 4, WEIGHT = 5, VALUE = 6},
                           });

            Knapsack.Init(items, W);
            Knapsack.Run();

            Knapsack.Print(write, true);
        }
        public static void TASK_NO_2()
        {
            Action<object> write = Console.Write;

            Console.WriteLine("TASK NO 2\n");

            // Task no 2 [data]
            const int n = 5; // n => amount of objects
            const int W = 7; // W => max weight
            var items = new List<Item>();
            
            items.AddRange(new List<Item>
                           {
                               new Item {ID = 1, WEIGHT = 2, VALUE = 3},
                               new Item {ID = 2, WEIGHT = 3, VALUE = 4},
                               new Item {ID = 3, WEIGHT = 4, VALUE = 5},
                               new Item {ID = 4, WEIGHT = 5, VALUE = 6},
                               new Item {ID = 5, WEIGHT = 6, VALUE = 7},
                           });

            Knapsack.Init(items, W);
            Knapsack.Run();

            Knapsack.Print(write, true);
        }
    }

    static class Knapsack
    {
        static int[][] MATRIX { get; set; } // matrix
        static int[][] PICKS { get; set; } // picks
        static Item[] ITEMS { get; set; } // items
        public static int MaxValue { get; private set; } // max value
        static int MaxWeight { get; set; } // max weight

        public static void Init(List<Item> items, int maxWeight)
        {
            ITEMS = items.ToArray();
            MaxWeight = maxWeight;

            var n = ITEMS.Length;
            MATRIX = new int[n][];
            PICKS = new int[n][];
            for (var i = 0; i < MATRIX.Length; i++) { MATRIX[i] = new int[MaxWeight + 1]; }
            for (var i = 0; i < PICKS.Length; i++) { PICKS[i] = new int[MaxWeight + 1]; }
        }

        public static void Run()
        { MaxValue = Recursive(ITEMS.Length - 1, MaxWeight, 1); }

        static int Recursive(int i, int w, int depth)
        {
            var take = 0;
            if (MATRIX[i][w] != 0) { return MATRIX[i][w]; }

            if (i == 0)
            {
                if (ITEMS[i].WEIGHT <= w)
                {
                    PICKS[i][w] = 1;
                    MATRIX[i][w] = ITEMS[0].VALUE;
                    return ITEMS[i].VALUE;
                }

                PICKS[i][w] = -1;
                MATRIX[i][w] = 0;
                return 0;
            }

            if (ITEMS[i].WEIGHT <= w)
            { take = ITEMS[i].VALUE + Recursive(i - 1, w - ITEMS[i].WEIGHT, depth + 1); }

            var dontTake = Recursive(i - 1, w, depth + 1);

            MATRIX[i][w] = Max(take, dontTake);
            
            if (take > dontTake) { PICKS[i][w] = 1; }
            else { PICKS[i][w] = -1; }

            return MATRIX[i][w];
        }

        public static void Print(Action<object> write, bool full)
        {
            var list = new List<Item>();
            list.AddRange(ITEMS);
            var w = MaxWeight;
            var i = list.Count - 1;

            // display total amount of items [objects]
            write(string.Format("=> Total Amount of Items: = {0}\n\n", list.Count));
            // display every ID with its value and weight
            if (full) { list.ForEach(a => write(string.Format("{0}\n", a))); }

            // display max weight & max value
            write(string.Format("\n=> Max weight = {0}\n", MaxWeight));
            write(string.Format("=> Max value = {0}\n", MaxValue));
            
            // display all picks
            write("\n=> Picks were:\n");
            var valueSum = 0;
            var weightSum = 0;
            while (i >= 0 && w >= 0)
            {
                if (PICKS[i][w] == 1)
                {
                    valueSum += list[i].VALUE;
                    weightSum += list[i].WEIGHT;
                    if (full) { write(string.Format("{0}\n", list[i])); }
                    w -= list[i].WEIGHT;
                }
                i--;
            }

            // display value sum & weight sum
            write(string.Format("\n=> Value sum: {0}\n=> Weight sum: {1}\n",
                valueSum, weightSum));

            write(string.Format("\n=> Answer: b_max = {0}\n", valueSum));
        }
        static int Max(int a, int b)
        { return a > b ? a : b; }
    }

    class Item
    {
        public int VALUE { get; set; } // value of the object
        public int WEIGHT { get; set; } // weight of the object

        // method no 1 (set ID values)
        public int ID { get; set; } // id of the object

        // method no 2 (auto increment ID)
        /*private static int _COUNTER; // counter for the object
        public int ID { get; private set; } // id of the object
        public Item()
        { ID = ++_COUNTER; } // counter in use*/

        public override string ToString()
        { return string.Format("ID: {0}  Value: {1}  Weight: {2}", ID, VALUE, WEIGHT); } // output [!]
    }
}