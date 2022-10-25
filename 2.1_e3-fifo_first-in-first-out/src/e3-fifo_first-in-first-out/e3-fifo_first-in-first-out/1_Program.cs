using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e3_fifo_first_in_first_out
{
    class Program
    {
        static char Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tA - Dodaj osobę do kolejki");
            Console.WriteLine("\n\t\tB - Usuń osobę z kolejki");
            Console.WriteLine("\n\t\tC - Podaj liczbę osób w kolejce");
            Console.WriteLine("\n\t\tD - Wyczyść kolejkę");
            Console.WriteLine("\n\t\tK - Koniec");
            return Console.ReadKey(true).KeyChar;

        }
        static void Main(string[] args)
        {
            Queue mojaKolejka;
            Queue.Create(out mojaKolejka, 10);
            Osoba tmp;
            char c;

            do
            {
                c = Menu();
                switch (c)
                {
                    case 'a':
                    case 'A':
                        Osoba.WprowadzOsobe(out tmp);
                        Queue.Enqueue(ref mojaKolejka, tmp);
                        break;
                    case 'b':
                    case 'B':
                        Osoba.WypiszOsobe(Queue.Dequeue(ref mojaKolejka));
                        Console.ReadKey();
                        break;
                    case 'c':
                    case 'C':
                        Console.WriteLine("Liczba osób w kolejce wynosi: {0}",
                          Queue.GetLength(mojaKolejka));
                        Console.ReadKey();
                        break;
                    case 'd':
                    case 'D':
                        Queue.Clear(ref mojaKolejka);
                        Console.WriteLine("Kolejka wyczyszczona!!!");
                        Console.ReadKey();
                        break;
                }
            }
            while (!(c == 'k' || c == 'K'));
        }
    }
}
