using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e2_compare_to_array
// [4.2]
{
    class Prostokat : IComparable
    {
        // [4.4]
        private int szerokosc;
        private int wysokosc;

        public Prostokat(int v1, int v2)
        {
            this.szerokosc = v1;
            this.wysokosc = v2;
        }

        // https://docs.microsoft.com/en-us/dotnet/api/system.icomparable.compareto?redirectedfrom=MSDN&view=netcore-3.1#System_IComparable_CompareTo_System_Object_

        public int CompareTo(object obj)
        {
            /*if (obj == null) return 1;

            Prostokat otherProstokat = obj as Prostokat;
            if (otherProstokat != null)
            {
                // TODO
                // pole1 - pole biezacego prostokata
                // pole2 - pole prostokata, ktory przychodzi jako parametr (obj, czyli 
                // jesli pole 1 > pole 2 to return 1
                // jesli pole 1 < pole 2 to return -1
                // w przeciwnym wypadku return 0
            }*/

            // [C1]
            Prostokat prostokat = obj as Prostokat;
            int pole_1 = this.szerokosc * this.wysokosc;
            int pole_2 = prostokat.szerokosc * prostokat.wysokosc;

            if (pole_1 > pole_2) return 1;
            else if (pole_1 < pole_2) return -1;
            else return 0;

            /*// [C1]
            Prostokat prostokat = obj as Prostokat;
            int to_pole = this.szerokosc * this.wysokosc;
            int wejście_pole = prostokat.szerokosc * prostokat.wysokosc;

            if (to_pole == wejście_pole) return 0;
            if (to_pole > wejście_pole) return 1;
            // if (to_pole < wejście_pole) return -1;
            else return -1;*/

            // [B]
            // return Convert.ToInt32(to_pole == wejście_pole);

            // [A]
            // throw new NotImplementedException();
        }
        public override string ToString()
        {
            return String.Format("=> Mamy prostokąt o wymiarach {0} x {1}", szerokosc, wysokosc);
        }
    }
}