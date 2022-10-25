using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e3_fifo_first_in_first_out
{
    public struct Queue
    {
        public Osoba[] Kolejka;
        public int First;
        public int Last;

        public static void Create(out Queue q, int liczbaElementow)
        {
            q.First = q.Last = -1;
            q.Kolejka = new Osoba[liczbaElementow];
        }

        public static bool IsFull(Queue q)
        {
            return ((q.First == 0 && q.Last == q.Kolejka.Length - 1) || q.First == q.Last + 1);
        }

        public static void Enqueue(ref Queue q, Osoba os)
        {
            // Jeśli kolejka jest pełna (użyj funkcji IsFull) to wyrzuć wyjątek InvalidOperationException("Kolejka jest pełna");
            if (Queue.IsFull(q))
            {
                throw new InvalidOperationException("Kolejka jest pełna");
            }

            // Jeśli indeks osoby na końcu kolejki(q.Last) jest równy indeksowi końca tablicy(9) to…
            if (q.Last == q.Kolejka.Length - 1)
            {
                q.Last = 0;
                q.Kolejka[q.Last] = os;
            }

            // Jeśli indeks osoby na końcu kolejki(q.Last) jest równy -1
            if (q.Last == -1)
            {
                // q.Kolejka[0] = os;
                q.First = 0;
                q.Last = 0;
                q.Kolejka[q.Last] = os;
            }
            else
            {
                // Jeśli indeks osoby na końcu kolejki(q.Last) jest mniejszy niż indeks końca tablicy(9) to…
                if (q.Last < q.Kolejka.Length - 1)
                {
                    q.Last++;
                    q.Kolejka[q.Last] = os;
                }
            }

        }

        public static bool IsEmpty(Queue q)
        {
            return q.First == -1;
        }

        public static Osoba Dequeue(ref Queue q)
        {
            // Osoba tmp;
            // TODO

            // a) kolejka pusta
            if (Queue.IsEmpty(q))
                throw new InvalidOperationException("Kolejka jest pusta");
            Osoba tmp = Queue.Peek(q);

            // b) kolejka ma 1 klienta, wsk. można użyć metody Queue.GetLength(q) [kolejka ma jeden element]
            if (Queue.GetLength(q) == 1) Queue.Clear(ref q);

            // c) kolejka ma więcej niż 1 klienta [kolejka ma więcej niż jeden element]
            // c1) pierwszy klient stoi na końcu tablicy
            // * np. (q.First == q.Kolejka.Lenght-1)
            else if (q.First == q.Kolejka.Length - 1) q.First = 0;
            // c2) pierwszy klient nie stoi na końcu tablicy
            else if (q.First < q.Kolejka.Length - 1) q.First++;

            return tmp;
        }

        public static void Clear(ref Queue q)
        {
            Queue.Create(out q, q.Kolejka.Length);
        }

        public static Osoba Peek(Queue q)
        {
            if (Queue.IsEmpty(q))
                throw new InvalidOperationException("Kolejka jest pusta");
            return q.Kolejka[q.First];
        }

        public static int GetLength(Queue q)
        {
            if (q.First == -1)
                return 0;
            if (q.First <= q.Last)
                return q.Last - q.First + 1;
            return q.Kolejka.Length - q.First + q.Last + 1;
        }
    }
}