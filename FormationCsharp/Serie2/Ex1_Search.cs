using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public static class Search
    {
        public static int LinearSearch(int[] tableau, int valeur)
        {
            for (int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] == valeur)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int BinarySearch(int[] tableau, int valeur)
        {
            int g = 0;
            int d = tableau.Length;
            int i ;
            while(d-g != 1)
            {
                i = (d + g) / 2;
                if (tableau[i] == valeur)
                    return i;
                else if (tableau[i] > valeur)
                    d = i;

                else
                    g = i;
                if ((d - g == 1) && tableau[i - 1] == valeur)
                    return i - 1;
            }
            return -1;
        }

    }


}


