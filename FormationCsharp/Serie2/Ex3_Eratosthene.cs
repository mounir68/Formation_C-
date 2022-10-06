using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public static class Eratosthene
    {
        public static int[] EratosthenesSieve(int n)
        {
            bool[] nombres = new bool[n+1];
            nombres[0] = true;
            nombres[1] = true;
            int k = 1;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (nombres[i] == false)
                {
                    for (int j = i; j < n + 1; j += i)
                    {
                        if (nombres[j] == false && i != j)
                        {
                            nombres[j] = true;
                            k++;
                        }
                    }
                }
            }
            int[] primaires = new int[n-k];
            int a = 0;
            for (int i = 0; i < n + 1; i++)
            {
                if (nombres[i] == false)
                {
                 primaires[a] = i;
                 a++;
                }
            }
            return primaires;
        }
    }
}
