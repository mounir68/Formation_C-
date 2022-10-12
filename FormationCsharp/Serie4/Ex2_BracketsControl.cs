using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_IV
{
    public static class BracketsControl
    {
        public static bool BracketsControls(string sentence)
        {
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == '(')
                {
                    for (int j = i; j < sentence.Length; j++)
                    {
                        if( sentence[j] == ')')
                        {
                            break;
                        }
                        if (j == sentence.Length - 1) 
                            return false;
                    }
                }
                if (sentence[i] == '{')
                {
                    for (int j = i; j < sentence.Length; j++)
                    {
                        if (sentence[j] == '}')
                        {
                            break;
                        }
                        if (j == sentence.Length - 1)
                            return false;
                    }
                }
                if (sentence[i] == '[')
                {
                    for (int j = i; j < sentence.Length; j++)
                    {
                        if (sentence[j] == ']')
                        {
                            break;
                        }
                        if (j == sentence.Length - 1)
                            return false;
                    }
                }
            }

            return true;
        }
    }
}
