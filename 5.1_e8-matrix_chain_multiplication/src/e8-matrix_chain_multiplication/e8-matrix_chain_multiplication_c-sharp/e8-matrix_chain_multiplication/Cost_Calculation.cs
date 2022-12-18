using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e8_matrix_chain_multiplication
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    // Łukasz Tworzydło - nr albumu: gd29623 [zadanie z ustawieniem nawiasów i mnożeniem macierzy z 05.12.2022]
    // Informatyka, grupa laboratoryjna: INiS3_PR2.2 [Algorytmy i struktury danych]
    // [ dane wejściowe (*) => rozmiar tablicy z wymiarami oraz elementy tej tablicy ]
    // [ dane wyjściowe (*) => optymalna ilość mnożeń & optymalna ilość nawiasów ]
    //
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    internal class Cost_Calculation
        // => Cost_Calculation - kalkulacja kosztu
        // [ niniejsza klasa jest klasą pomocniczą ]
    {
        public string final_label = "";
        public int final_cost = Int32.MaxValue;
    }
}
