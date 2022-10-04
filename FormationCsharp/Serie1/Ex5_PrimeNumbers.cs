using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class PrimeNumbers
    {
        static bool IsPrime(int valeur)
        {
            int i = 0;
            for (int j=1; j<=valeur; j++)
            {
                if (valeur % j == 0)
                {
                    i++;
                }
                else
                    continue;
            }
            if (i == 2)
                return true;
            else
                return false;
        }

        public static void DisplayPrimes()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (IsPrime(i))
                    Console.WriteLine(i);
                else
                    continue;

            }
        }
    }
}
