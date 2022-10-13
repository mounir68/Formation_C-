using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie1
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

            Dictionary<int, double> comptes = LectureComptes(fcomptes);
            foreach (int item in comptes.Keys)
            {
                gestion.AjouterCompte(item, comptes[item]);
            }
            Ecrituresortie(statut,ftransactions, gestion);
        }



        public static Dictionary<int, double> LectureComptes(string input)
        {
            Dictionary<int, double> comptes = new Dictionary<int, double>();
            using (FileStream c = new FileStream(input, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader str = new StreamReader(c))
                {
                    while (!str.EndOfStream)
                    {
                        string ligne = str.ReadLine();
                        string[] sp = ligne.Split(';');
                        double solde = 0;
                        if (sp[1] != "")
                        {
                            solde = double.Parse(sp[1]);
                        }
                 
                        int numcpt = int.Parse(sp[0]);
                        if (comptes.ContainsKey(numcpt) == false)
                        {
                            comptes.Add(numcpt, solde);
                        }
                    }
                }
            }
            return comptes;
        }
        public static List<Transaction> LectureTransactions(string input)
        {
            
            List <Transaction> transactions  = new List<Transaction>();
            using (FileStream t = new FileStream(input, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader str = new StreamReader(t))
                {
                    while (!str.EndOfStream)
                    {
                        string ligne = str.ReadLine();
                        string[] sp = ligne.Split(';');
                        double montant = double.Parse(sp[1]);
                        int numtrans = int.Parse(sp[0]);
                        int numcpt1 = int.Parse(sp[2]);
                        int numcpt2 = int.Parse(sp[3]);
                        Transaction transaction = new Transaction(numtrans, montant,numcpt1,numcpt2);
                        transactions.Add(transaction);
                    }
                }
            }
            return transactions;
        }

        public static void Ecrituresortie(string statut, string ftransactions,gestion_comtpes gestion)
        {
            using (FileStream s = new FileStream(statut, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(s))
                {
                    List<Transaction> transactions = LectureTransactions(ftransactions);
                    foreach (var trans in transactions)
                    {
                        bool etat = gestion.Transaction(trans.numtrans, trans.montant, trans.numcpt1, trans.numcpt2);
                        string res = etat ? "OK" : "KO";
                        writer.WriteLine($"{trans.numtrans};{res}");
                    }
                }
            }
        }    
    }
}


    

