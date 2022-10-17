using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    public class Compte_bancaire
    {
        public readonly int num_cpt;
        protected readonly DateTime date_ouverture;
        protected readonly DateTime date_cloture;
        protected readonly DateTime date_cession;
        protected readonly DateTime date_réception;
        protected double solde_initial;
        protected const int _environnement = 0;
        protected const int _plafond = 1000;
        protected static Dictionary<int, List<double>> _retraits;
        protected static Dictionary<int, double> _comptes;

        public Compte_bancaire(int num_cpt, double solde_initial)
        {
            this.num_cpt = num_cpt;
            this.solde_initial = solde_initial;
        }

        protected bool Numcptok(int numcpt)
        {
            return numcpt > 0 && !_comptes.ContainsKey(numcpt);
        }
        protected bool Soldeok(double solde)
        {
            return solde >= 0;
        }

        public bool AjouterCompte(int numcpt, double solde = 0)
        {
            if (Numcptok(numcpt) && Soldeok(solde))
            {
                gest.Add(numcpt, solde);
                _retraits.Add(numcpt, new List<double>() { });

                return true;
            }
            return false;
        }

        private bool Sommeok(double somme, int numcpt)
        {
            if (numcpt != _environnement)
            {
                return somme > 0 && somme < gest[numcpt];
            }
            else
                return somme > 0;

        }

        private bool Tnumgestok(int numcpt)
        {
            return gest.ContainsKey(numcpt);

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
            if (numcpt1 == _environnement && Tnumgestok(numcpt2) && Sommeok(somme, numcpt1))
            {
                gest[numcpt2] += somme;
                return true;
            }
            // Retrait
            else if (Tnumgestok(numcpt1) && numcpt2 == _environnement)
            {
                if (Plafondok(numcpt1, somme) && Sommeok(somme, numcpt1))
                {
                    gest[numcpt1] -= somme;
                    _retraits[numcpt1].Add(somme);
                    return true;
                }
                else return false;
            }
            // Opération intercomptes
            else if (Tnumgestok(numcpt1) && Tnumgestok(numcpt2))
            {
                if (Plafondok(numcpt1, somme) && Sommeok(somme, numcpt1))
                {
                    gest[numcpt1] -= somme;
                    gest[numcpt2] += somme;
                    _retraits[numcpt1].Add(somme);
                    return true;
                }
                else return false;
            }
            return false;
        }
    }
}
}
