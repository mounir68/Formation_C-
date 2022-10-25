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


        public static FileStream Créa_stream(string fichier)
        {
            return new FileStream(fichier, FileMode.Open, FileAccess.Read) ;
        }

        public static FileStream Créa_stream_w(string fichier)
        {
            return new FileStream(fichier, FileMode.Create, FileAccess.Write);
        }

        public static StreamReader créa_reader(FileStream fileStream)
        {
            return new StreamReader(fileStream);
        }

        public static StreamWriter créa_writer(FileStream fileStream)
        {
            return new StreamWriter(fileStream);
        }


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
        public static Transaction LectureTransactions(StreamReader str)
        {                                                        
            if (!str.EndOfStream)
            {
                string ligne = str.ReadLine();
                string[] sp = ligne.Split(';');
                DateTime date = DateTime.ParseExact(sp[1],"d", CultureInfo.CurrentCulture);
                double montant = double.Parse(sp[2]);
                int numtrans = int.Parse(sp[0]);
                int numcpt1 = int.Parse(sp[3]);
                int numcpt2 = int.Parse(sp[4]);
                Transaction transaction = new Transaction(numtrans ,date, montant, numcpt1, numcpt2);
                       
                       
                return transaction;
            }
            Transaction transaction1 = new Transaction(0, DateTime.Now.AddDays(1), 0, 0, 0);
            return transaction1;
                                      
        }

        public static Opération LectureOpération(StreamReader str)
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
            Opération opération1 = new Opération(DateTime.Now.AddDays(1),0, 0, 0, 0);
            return opération1;
                

        }

        public static void Ecrituretransac(StreamWriter w, string statut_transac, Transaction transaction)
        {
            string res = transaction.statut ? "OK" : "KO";
             w.WriteLine($"{transaction.Num_trans};{transaction.Date_trans};{transaction.Montant_trans};" +
             $"{transaction.Expéditeur};{transaction.Destinataire};{res}");                  
                
        }

        public static void Ecritureopé(StreamWriter w, string statut_opé, Opération opération)
        {
            
                    string res = opération.statut ? "OK" : "KO";
                    w.WriteLine($"{opération.numcpt};{opération.Date_opé};{opération.solde_initial};" +
                        $"{opération.Entrée};{opération.Sortie};{res}");

                
        }

        public static void Gestion_entree_sortie(StreamReader t, StreamReader o, StreamWriter wt, StreamWriter wo, string sortie_transac, string sortie_opé)
        {
            Transaction transaction = LectureTransactions(t);
            Opération opération = LectureOpération(o);
            DateTime date_verif = DateTime.Now.AddDays(1);
            while (transaction.Num_trans > 0|| opération.Date_opé < date_verif)
            {
                if (transaction.Date_trans < opération.Date_opé)
                {
                    transaction.Traitement_Transaction();
                    Ecrituretransac(wt, sortie_transac, transaction);
                    transaction = LectureTransactions(t);                                        
                }
                else if (transaction.Date_trans > opération.Date_opé || transaction.Date_trans == opération.Date_opé)
                {
                    opération.Traitement_Opé();
                    Ecritureopé(wo, sortie_opé, opération);
                    opération = LectureOpération(o);
                }

            }
        }
    }
}
