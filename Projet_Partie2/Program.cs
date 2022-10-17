using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    struct Transaction
    {
        public int numtrans;
        public double montant;
        public int numcpt1;
        public int numcpt2;

        public Transaction(int a, double b, int c, int d)
        {
            numtrans = a;
            montant = b;
            numcpt1 = c;
            numcpt2 = d;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
            string fcomptes = path + @"\comptes.csv";
            string ftransactions = path + @"\transactions.csv";
            string statut = path + @"\statut.csv";
            gestion_comtpes gestion = new gestion_comtpes();

            Dictionary<int, double> comptes = EntreesSorties.LectureComptes(fcomptes);
            foreach (int item in comptes.Keys)
            {
                gestion.AjouterCompte(item, comptes[item]);
            }
            EntreesSorties.Ecrituresortie(statut, ftransactions, gestion);
        }
    }
}





