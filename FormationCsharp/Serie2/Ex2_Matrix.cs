using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public static class Matrix
    {
        public static int[,] BuildingMatrix(int[] leftVector, int[] rightVector)
        {
            int[,] matrix = new int[leftVector.Length, rightVector.Length];
            for (int i = 0; i < rightVector.Length; i++)
            {
                for (int j = 0; j < leftVector.Length ; j++)
                {
                    matrix[j, i] = rightVector[i] * leftVector[j];
                }
            }
            return matrix;
        }

        public static int[,] Addition(int[,] leftMatrix, int[,] rightMatrix)
        {
            int[,] matrix = new int[leftMatrix.GetLength(0), rightMatrix.GetLength(1)];
            for (int i = 0; i < rightMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < leftMatrix.GetLength(0); j++)
                {
                    matrix[j, i] = leftMatrix[j, i] + rightMatrix[j, i];
                }
            }

            return matrix;
        }

        public static int[,] Substraction(int[,] leftMatrix, int[,] rightMatrix)
        {
            int[,] matrix = new int[leftMatrix.GetLength(0), rightMatrix.GetLength(1)];
            for (int i = 0; i < rightMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < leftMatrix.GetLength(0); j++)
                {
                    matrix[j, i] = leftMatrix[j, i] - rightMatrix[j, i];
                }
            }

            return matrix;
        }

        public static int[,] Multiplication(int[,] leftMatrix, int[,] rightMatrix)
        {
            if (leftMatrix.GetLength(1) == rightMatrix.GetLength(0))
            {
                int[,] matrix = new int[leftMatrix.GetLength(0), rightMatrix.GetLength(1)];
                for (int i = 0 ; i < leftMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < rightMatrix.GetLength(1); j++)
                    {
                        for (int k = 0; k < leftMatrix.GetLength(1); k++ )
                        {
                            matrix[i, j] += leftMatrix[i, k] * rightMatrix[k, j];
                        }
                    }
                }
                return matrix;
            }    
            else
                return new int[0,0];
        }

        public static void DisplayMatrix(int[,] matrix)
        {
            string s = string.Empty;
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    s += matrix[i,j].ToString().PadLeft(5) + " ";
                }
                s += Environment.NewLine;
            }
            Console.WriteLine(s);
        }
    }
}
