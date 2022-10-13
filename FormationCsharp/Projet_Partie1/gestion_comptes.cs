using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie1
{
    public class gestion_comtpes
    {
        private readonly Dictionary<int, double> _comptes;
        private Dictionary<int,List<double>> _retraits;
        public gestion_comtpes()
        {
            _comptes = new Dictionary<int, double>();
             _retraits = new Dictionary<int, List<double>>();
        }
        private bool numcptok(int numcpt)
        {
            return numcpt > 0 &&  !_comptes.ContainsKey(numcpt);
        }
        private bool soldeok(double solde)
        {
            return solde >= 0;
        }
        
        public bool AjouterCompte(int numcpt, double solde = 0)
        {
            if (numcptok(numcpt) && soldeok(solde))
            {
                _comptes.Add(numcpt, solde);
                _retraits.Add(numcpt,new List<double>(){ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0});

                return true;
            }
            return false;
        }

        private bool sommeok(double somme, int numcpt)
        {
            if (numcpt != 0)
            {
                return somme > 0 && somme < _comptes[numcpt];
            }
            else
                return somme > 0;
            
        }

        private bool tnumcptok(int numcpt)
        {
            return _comptes.ContainsKey(numcpt);

        }

        private bool plafondok(int numcpt, double sommetrans)
        {
            List<double> dernretraits =  _retraits[numcpt].Skip(_retraits[numcpt].Count - 10).ToList();
            double somme = dernretraits.Sum() + sommetrans;
            return somme <= 1000;
        }

        public bool Transaction(int numtrans, double somme, int numcpt1, int numcpt2)
        {
            if (numcpt1 == 0 && tnumcptok(numcpt2) && sommeok(somme, numcpt1))
            {
                _comptes[numcpt2] += somme;
                return true;
            }
            else if ( tnumcptok(numcpt1) && numcpt2 == 0 )
            {
                if (plafondok(numcpt1, somme) && sommeok(somme, numcpt1))
                {
                    _comptes[numcpt1] -= somme;
                    _retraits[numcpt1].Add(somme);
                    return true;
                }
                else return false;
            }
            else if (tnumcptok(numcpt1) && tnumcptok(numcpt2))
            {
                if (plafondok(numcpt1 , somme) &&  sommeok(somme, numcpt1))
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
