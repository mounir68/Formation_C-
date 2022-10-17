using System;
using System.Collections.Generic;
using System.Linq;

namespace Projet_Partie2
{
    public class Gestionnaire
    {
        protected int num_gest;
        protected string type;
        protected int nb_transac;
        private const int _environnement = 0;
        

        private readonly Dictionary<int, double> _comptes;
        public  List<Compte_bancaire> Comptes;
        public Dictionary<int,List<double>> _retraits;

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
                Compte_bancaire compte = new Compte_bancaire(numcpt, solde);
                _comptes.Add(numcpt, solde);
                _retraits.Add(numcpt,new List<double>(){});
                Comptes.Add(compte);


                return true;
            }
            return false;
        }

        public bool ClotureCompte(int numcpt)
        {
            if (Numcptok_exist(numcpt))
            {
                _comptes.Remove(numcpt);
                _retraits.Remove(numcpt);
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

        private bool Sommeok(double somme, int numcpt)
        {
            if (numcpt != _environnement)
            {
                return somme > 0 && somme < _comptes[numcpt];
            }
            else
                return somme > 0;
            
        }

        private bool Tnumcptok(int numcpt)
        {
            return _comptes.ContainsKey(numcpt);

        }

        private bool Plafondok(int numcpt, double sommetrans)
        {
            // Je prends les 10 derniers transactions (ou les transactions si moins de 10)
            List<double> dernretraits = _retraits[numcpt].Skip(Math.Max(0, _retraits[numcpt].Count - 10)).ToList();
            double somme = dernretraits.Sum() + sommetrans;
            return somme <= _plafond;
        }

        public bool Transaction(int numtrans, double somme, int numcpt1, int numcpt2)
        {
            // Dépôt
            if (numcpt1 == _environnement && Tnumcptok(numcpt2) && Sommeok(somme, numcpt1))
            {
                _comptes[numcpt2] += somme;
                return true;
            }
            // Retrait
            else if ( Tnumcptok(numcpt1) && numcpt2 == _environnement )
            {
                if (Plafondok(numcpt1, somme) && Sommeok(somme, numcpt1))
                {
                    _comptes[numcpt1] -= somme;
                    _retraits[numcpt1].Add(somme);
                    return true;
                }
                else return false;
            }
            // Opération intercomptes
            else if (Tnumcptok(numcpt1) && Tnumcptok(numcpt2))
            {
                if (Plafondok(numcpt1 , somme) &&  Sommeok(somme, numcpt1))
                {
                    _comptes[numcpt1] -= somme;
                    _comptes[numcpt2] += somme;
                    _retraits[numcpt1].Add(somme);
                    return true;
                }
                else return false;
            }
            return false;
        }
    }

}
