using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Exercice I - Recherche d'un élément
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Exercice I - Recherche d'un élément");
            Console.WriteLine("-----------------------------------");

            int[] arr = { 1, -5, 10, -3, 0, 4, 2, -7 , 8};
            int val = -7;
            Console.WriteLine(Search.LinearSearch(arr, val));
            Array.Sort(arr);
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n" + Search.BinarySearch(arr, val));
            #endregion

            #region Exercice II - Bases du calcul matriciel
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Exercice II - Bases du calcul matriciel");
            Console.WriteLine("---------------------------------------");

            int[] u = { 1, 2, 3 };
            int[] v = { -1, -4, 0 };
            int[,] matrice = Matrix.BuildingMatrix(u, v);
            Matrix.DisplayMatrix(matrice);

            int[,] matriceGauche = new int[,] { { 1, 2 },  { 4, 6 }, { -1, 8 } };


            int[,] matriceDroite = new int[,]
            {
                 { -1, 5 },
                { -4, 0 },
                 { 0, 2 }
            };

            Console.WriteLine("Addition");
            Matrix.DisplayMatrix(Matrix.Addition(matriceGauche, matriceDroite));
            Console.WriteLine("Soustraction");
            Matrix.DisplayMatrix(Matrix.Substraction(matriceGauche, matriceDroite));
            matriceDroite = new int[,]
            {
                { -1, 5, 0 },
                { -4, 0, 1 }
            };
            Console.WriteLine("Multiplication");
            Matrix.DisplayMatrix(Matrix.Multiplication(matriceGauche, matriceDroite));
            #endregion

            #region Exercice III - Crible d'Eratosthène
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Exercice III - Crible d'Eratosthène");
            Console.WriteLine("-----------------------------------");

            int[] res = Eratosthene.EratosthenesSieve(101);
            foreach (int nbr in res)
            {
                if (nbr != int.MinValue)
                {
                    Console.WriteLine(nbr);
                }
            }
            #endregion

            /*#region Exercice IV - Questionnaire à choix multiple
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Exercice IV - Questionnaire à choix multiple");
            Console.WriteLine("--------------------------------------------");

            Qcm[] qcms = new Qcm[3]
            {
                new Qcm
                {
                    Question = "Quelle est l'année du sacre de Charlemagne ?",
                    Answers = new string[]
                    {
                        "476",
                        "800",
                        "1066",
                        "1789",
                    },
                    Solution = 1,
                    Weight = 1,
                },
                new Qcm
                {
                    Question = "Quel est le nom du président de la République en 2021 ?",
                    Answers = new string[]
                    {
                        "Chirac",
                        "De Gaulle",
                        "Macron",
                    },
                    Solution = 2,
                    Weight = 1,
                },
                new Qcm
                {
                    Question = "Quel est le nom du président de la République en 2021 ?",
                    Answers = new string[]
                    {
                        "Chirac",
                        "De Gaulle",
                        "Macron",
                    },
                    Solution = 2,
                    Weight = -1,
                }
            };
            Quiz.AskQuestions(qcms);
            #endregion*/

            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
