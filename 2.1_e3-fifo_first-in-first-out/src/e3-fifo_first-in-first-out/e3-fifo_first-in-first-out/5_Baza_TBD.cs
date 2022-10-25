using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e3_fifo_first_in_first_out
{
    struct Kontakty
    {
        public Osoba[] Osoby;
        public uint LiczbaOsob;

        public static void WprowadzKontakt(ref Kontakty kontakty)
        {
            if (kontakty.LiczbaOsob >= kontakty.Osoby.Length)
                throw new Exception("Baza jest pełna");
            Osoba.WprowadzOsobe(out kontakty.Osoby[kontakty.LiczbaOsob]);
            kontakty.LiczbaOsob++;
        }

        public static void WypiszKontakty(Kontakty kontakty)
        {
            Console.Clear();
            for (int i = 0; i < kontakty.LiczbaOsob; i++)
            {
                Console.Write("{0}. ", i + 1);
                Osoba.WypiszOsobe(kontakty.Osoby[i]);
                Console.WriteLine();
                if ((i + 1) % Console.WindowHeight == 0)
                    Console.ReadKey();
            }
            Console.ReadKey();
        }
        public static void UtworzKontakty(out Kontakty kontakty, uint liczbaKontaktow)
        {
            kontakty.Osoby = new Osoba[liczbaKontaktow];
            kontakty.LiczbaOsob = 0;
        }
    }
    /*class Program
    {

        static char Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tA - Dodaj kontakt");
            Console.WriteLine("\n\t\tB - Wypisz wszystkie kontakty");
            Console.WriteLine("\n\t\tK - Koniec");
            return Console.ReadKey(true).KeyChar;
        }
        static void Main(string[] args)
        {

            Kontakty mojeKontakty;
            Kontakty.UtworzKontakty(out mojeKontakty, 5);
            char c;
            do
            {
                c = Menu();
                switch (c)
                {
                    case 'a':
                    case 'A':
                        Kontakty.WprowadzKontakt(ref mojeKontakty);
                        break;
                    case 'b':
                    case 'B':
                        Kontakty.WypiszKontakty(mojeKontakty);
                        break;
                }
            }
            while (!(c == 'k' || c == 'K'));
        }
    }*/
}