using System;
using System.Collections.Generic;
using System.Linq;

namespace Projet_Partie2
{
    public class Gestionnaire
    {
        public int num_gest;
        public string type;
        public int nb_transac;
       
        

        public  Dictionary<int, Compte_bancaire> _comptes = new Dictionary<int, Compte_bancaire>();
        public  List<Compte_bancaire> Comptes = new List<Compte_bancaire>();
        public static Dictionary<int, int> comptes_gests = new Dictionary<int, int>();
        //public Dictionary<int,List<double>> _retraits;

        public Gestionnaire(int num_gest, string type, int nb_transac)
        {
            this.num_gest = num_gest;
            this.type = type;
            this.nb_transac = nb_transac;
            Comptes = new List<Compte_bancaire>();
        }

        private bool Numcptok_nv(int numcpt)
        {
            return numcpt > 0 &&  !_comptes.ContainsKey(numcpt);
        }

        private bool Numcptok_exist(int numcpt)
        {
            
            foreach (Compte_bancaire cpt in Comptes)
            {
                if (cpt.num_cpt == numcpt)
                {
                    return true;
                }
            }
            return false;
        }

        private bool Soldeok(double solde)
        {
            return solde >= 0;
        }

        public bool CreerCompte(int numcpt, double solde = 0)
        {
            if (Numcptok_nv(numcpt) && Soldeok(solde))
            {
                Compte_bancaire compte = new Compte_bancaire(numcpt, solde, nb_transac);
                _comptes.Add(numcpt, compte);
                //_retraits.Add(numcpt,new List<double>(){});
                Comptes.Add(compte);
                comptes_gests.Add(numcpt, num_gest);

                return true;
            }
            return false;
        }

        public bool ClotureCompte(int numcpt)
        {
            if (Numcptok_exist(numcpt))
            {
                _comptes.Remove(numcpt);
                comptes_gests.Remove(numcpt);
                //_retraits.Remove(numcpt);
                foreach(Compte_bancaire cpt in Comptes)
                {
                    if (cpt.num_cpt == numcpt)
                    {
                        Comptes.Remove(cpt);
                    }
                }
                return true;
            }
            return false;
        }
               
    }

}
