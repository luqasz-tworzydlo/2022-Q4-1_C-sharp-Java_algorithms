using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e3_fifo_first_in_first_out
{
    public struct Stack
    {
        public Osoba[] Czarownice;
        public uint Index;

        public static void Create(out Stack s, uint liczbaElementow)
        {
            s.Index = 0;
            s.Czarownice = new Osoba[liczbaElementow];
        }

        public static bool IsFull(Stack s)
        {
            return s.Czarownice.Length == s.Index;
        }

        public static void Push(ref Stack s, Osoba os)
        {
            if (Stack.IsFull(s))
                throw new InvalidOperationException("Stos jest pe�ny!!!");
            s.Czarownice[s.Index] = os;
            s.Index++;
        }

        public static bool IsEmpty(Stack s)
        {
            return s.Index == 0;
        }

        //        public static Osoba Pop(ref Stack s)
        //        {
        ////TODO
        //        }

        public static void Clear(ref Stack s)
        {
            Stack.Create(out s, (uint)s.Czarownice.Length);
        }

        public static Osoba Peek(Stack s)
        {
            if (Stack.IsEmpty(s))
                throw new InvalidOperationException("Stos jest pusty!!!");
            return s.Czarownice[s.Index - 1];
        }

        public static uint GetLength(Stack s)
        {
            return s.Index;
        }

    }
}