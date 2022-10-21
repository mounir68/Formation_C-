using System.Collections.Generic;
using System.IO;
using System;
using System.Globalization;

namespace Projet_Partie2
{
    static class EntreesSorties
    {
        
        private static int nb_comptes;
        private static int nb_transac;
        private static int nb_reusite;
        private static int nb_echec;
        private static double tot_reussite;
        private static Dictionary<int, double> frais_gestions;
        
        public static void LectureGests(string input)
        {
            using (FileStream g = new FileStream(input, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader str = new StreamReader(g))
                {
                    while (!str.EndOfStream)
                    {
                        string ligne = str.ReadLine();
                        string[] sp = ligne.Split(';');                        
                        int numgest = int.Parse(sp[0]);
                        int nbtransac = int.Parse(sp[2]);
                        string type = sp[1];
                        Banque.Création_gestionnaire(numgest, type, nbtransac);
                    }
                }
            }
            
        }
        public static Transaction LectureTransactions(string input)
        {
            
            
            using (FileStream t = new FileStream(input, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader str = new StreamReader(t))
                {
                    if (!str.EndOfStream)
                    {
                        string ligne = str.ReadLine();
                        string[] sp = ligne.Split(';');
                        DateTime date = DateTime.ParseExact(sp[1],"d", CultureInfo.InvariantCulture);
                        double montant = double.Parse(sp[2]);
                        int numtrans = int.Parse(sp[0]);
                        int numcpt1 = int.Parse(sp[3]);
                        int numcpt2 = int.Parse(sp[4]);
                        Transaction transaction = new Transaction(numtrans ,date, montant, numcpt1, numcpt2);
                       
                       
                        return transaction;
                    }
                    Transaction transaction1 = new Transaction(0, DateTime.Parse("11/11/2222") , 0, 0, 0);
                    return transaction1;
                }
            }
            
        }

        public static Opération LectureOpération(string input)
        {

            
            using (FileStream o = new FileStream(input, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader str = new StreamReader(o))
                {
                    if (!str.EndOfStream)
                    {
                        string ligne = str.ReadLine();
                        string[] sp = ligne.Split(';');
                        DateTime date = DateTime.ParseExact(sp[1], "d", CultureInfo.CurrentCulture);
                        double montant = 0;
                        if (sp[2] != "")
                        {
                            montant = double.Parse(sp[2]);
                        }                                                
                        int numcpt = int.Parse(sp[0]);
                        int numgest1 = 0;
                        int numgest2 = 0;
                        if (sp[3] != "")
                        {
                            numgest1 = int.Parse(sp[3]);
                        }
                        if (sp[4] != "")
                        {
                            numgest2 = int.Parse(sp[4]);
                        }
                        Opération opération = new  Opération(date, numgest1, numgest2, montant, numcpt);
                        
                        return opération;
                    }
                    Opération opération1 = new Opération(DateTime.Parse("11/11/2222"),0, 0, 0, 0);
                    return opération1;
                }
            }

        }

        public static void Ecrituretransac(string statut_transac, Transaction transaction)
        {
            using (FileStream et = new FileStream(statut_transac, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(et))
                {                                                            
                    string res = transaction.statut ? "OK" : "KO";
                    writer.WriteLine($"{transaction.Num_trans};{transaction.Date_trans};{transaction.Montant_trans};" +
                        $"{transaction.Expéditeur};{transaction.Destinataire};{res}");
                    
                }
            }
        }

        public static void Ecritureopé(string statut_opé, Opération opération)
        {
            using (FileStream et = new FileStream(statut_opé, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(et))
                {
                    string res = opération.statut ? "OK" : "KO";
                    writer.WriteLine($"{opération.numcpt};{opération.Date_opé};{opération.solde_initial};" +
                        $"{opération.Entrée};{opération.Sortie};{res}");

                }
            }
        }

        public static void Gestion_entree_sortie(string entrée_transac, string entrée_opé, string sortie_transac, string sortie_opé)
        {
            Transaction transaction = LectureTransactions(entrée_transac);
            Opération opération = LectureOpération(entrée_opé);
            DateTime date_verif = new DateTime(11 / 11 / 2222);
            while (transaction.Num_trans != 0 && opération.Date_opé != date_verif)
            {
                if (transaction.Date_trans < opération.Date_opé)
                {
                    transaction.Traitement_Transaction();
                    Ecrituretransac(sortie_transac, transaction);
                    transaction = LectureTransactions(entrée_transac);                                        
                }
                else if (transaction.Date_trans > opération.Date_opé || transaction.Date_trans == opération.Date_opé)
                {
                    opération.Traitement_Opé();
                    Ecritureopé(sortie_opé, opération);
                    opération = LectureOpération(entrée_opé);
                }

            }
        }
    }
}
