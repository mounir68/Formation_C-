using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class ElementaryOperations
    {
        public static void BasicOperation(int a, int b, char operation)
        {
            if (operation == '+')
                Console.WriteLine($"{a} {operation} {b} = {a + b}");
            else if (operation == '-')
                Console.WriteLine($"{a} {operation} {b} = {a - b}");
            else if (operation == '*')
                Console.WriteLine($"{a} {operation} {b} = {a * b}");
            else if (operation == '/' && b != 0)
                Console.WriteLine($"{a} {operation} {b} = {a / b}");
            else
                Console.WriteLine($"{a} {operation} {b} = Opération invalide");
        }

        public static void IntegerDivision(int a, int b)
        {
            if (b == 0)
                Console.WriteLine($"{a} / {b} = Opération invalide");

            else if (a % b == 0)
                Console.WriteLine($"{a} = {a / b} *{b}");
            else
                Console.WriteLine($"{a} = {a/b} * {b} + {a%b}");

        }

        public static void Pow(int a, int b)
        {
            int p = a;
            if (b < 0)
                Console.WriteLine($"{a} ^ {b} = Opération impossible");
            else if (b == 0)
                Console.WriteLine($"{a} ^ {b} = 1");
            else
            {
                for (int i = 1; i < b; i++)
                { p = p * a; }
                Console.WriteLine($"{a} ^ {b} = {p}");
            }
        }
    }
}
