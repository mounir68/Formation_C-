using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Factorial
    {
        public static int Factorial_(int n)
        {
            int f = 0;
            for (int i= 1;i<= n; i++)
            {
                f = f * i;
                if (f == 0)
                    f = 1;
            } 
            return f;
        }

        public static int FactorialRecursive(int n)
        {
            if (n == 0)
                return 1;
            else
            {
                return (FactorialRecursive(n-1) * n);
            }
            
        }
    }
}
