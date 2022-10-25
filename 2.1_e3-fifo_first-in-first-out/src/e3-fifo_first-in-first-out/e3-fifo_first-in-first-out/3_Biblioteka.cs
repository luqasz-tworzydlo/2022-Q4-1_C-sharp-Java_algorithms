using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e3_fifo_first_in_first_out
{
    public struct Data
    {
        public int Rok;
        public byte Miesiac;
        public byte Dzien;

        public static void WprowadzDate(out Data d)
        {
            Console.Write("Podaj rok: ");
            d.Rok = Convert.ToInt32(Console.ReadLine());
            do
            {
                Console.Write("Podaj miesiąc: ");
                d.Miesiac = Convert.ToByte(Console.ReadLine());
            }
            while (d.Miesiac < 1 || d.Miesiac > 12);
            bool flaga = true;
            do
            {
                Console.Write("Podaj dzień: ");
                d.Dzien = Convert.ToByte(Console.ReadLine());
                if (d.Dzien >= 1 && d.Dzien <= 31)
                {
                    switch (d.Miesiac)
                    {
                        case 2:
                            if (d.Dzien < 29)
                                flaga = false;
                            break;
                        case 4:
                        case 6:
                        case 9:
                        case 11:
                            if (d.Dzien <= 30)
                                flaga = false;
                            break;
                        default:
                            flaga = false;
                            break;
                    }
                }

            }
            while (flaga);
        }

        public static void WypiszDate(Data d)
        {
            Console.Write("{0}-{1}-{2}", d.Dzien, d.Miesiac, d.Rok);
        }
    }

    public struct Osoba
    {
        public string Imie;
        public string Nazwisko;
        public Data DataUrodzenia;

        public static void WprowadzOsobe(out Osoba os)
        {
            Console.Write("Podaj imie: ");
            os.Imie = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            os.Nazwisko = Console.ReadLine();
            Data.WprowadzDate(out os.DataUrodzenia);
        }

        public static void WypiszOsobe(Osoba os)
        {
            Console.Write("Pan(i) {0} {1}, urodzony(a): ", os.Imie, os.Nazwisko);
            Data.WypiszDate(os.DataUrodzenia);
        }
    }
}
