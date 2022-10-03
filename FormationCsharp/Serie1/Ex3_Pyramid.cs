using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Pyramid
    {
        public static void PyramidConstruction(int n, bool isSmooth)
        {
            if (isSmooth)
            {
                if (n == 1)
                {
                    Console.WriteLine("*");

                }
                else
                {
                    for (int j=0; j < n; j++)
                    {
                        for (int i = 0; i < n - j + 1; i++)
                        {
                            Console.Write(" ");
                        }
                        for (int k = 0;  k< (2*j)-1; k++)
                        {
                            Console.Write("+");
                        }
                        Console.Write('\n');
                    }


                }
            }
            else
            {
                if (n == 1)
                {
                    Console.WriteLine("*");

                }
                else
                {
                    for (int j = 0; j <= n; j++)
                    {
                        if (j % 2 == 0)
                        {
                            for (int i = 0; i < n - j + 1; i++)
                            {
                                Console.Write(" ");
                            }
                            for (int k = 0; k < (2 * j) - 1; k++)
                            {
                                Console.Write("-");
                            }
                            Console.Write('\n');
                        }
                        else
                        {
                            for (int i = 0; i < n - j + 1; i++)
                            {
                                Console.Write(" ");
                            }
                            for (int k = 0; k < (2 * j) - 1; k++)
                            {
                                Console.Write("+");
                            }
                            Console.Write('\n');
                        }

                    }
                }

            }
        }   
    }
}
