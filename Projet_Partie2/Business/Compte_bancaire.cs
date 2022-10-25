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
        public double solde;
        protected const int _plafond = 1000;
        private int nb_transac;
        private List<double> _retraits = new List<double>();
        private List<KeyValuePair<DateTime, double>> _dates_retraits = new List<KeyValuePair<DateTime, double>>();
        

        public Compte_bancaire(int num_cpt, double solde_initial, int nb_transac)
        {
            this.num_cpt = num_cpt;
            solde = solde_initial;
            this.nb_transac = nb_transac;
        }

        
       
        private bool Somme_depot_ok(double somme)
        {
            return somme > 0;                 

        }

        private bool Somme_debit_ok(double somme)
        {
            return somme > 0 && somme < solde;

        } 

            
        private bool Plafondok(double sommetrans)
        {
            // Je prends les 10 derniers transactions (ou les transactions si moins de 10)
            List<double> dernretraits = _retraits.Skip(Math.Max(0, _retraits.Count - nb_transac)).ToList();
            double somme = dernretraits.Sum() + sommetrans;
            return somme <= _plafond;
        }

        private bool Plafond_dates_ok(double somme, DateTime date)
        {
            double retraits_semaine =
            _dates_retraits.Where(x => x.Key >= date.AddDays(-7)).Sum(x => x.Value);
            retraits_semaine += somme;
            return retraits_semaine <= _plafond;
        }

        public bool Depot(double somme)
        {
            // Dépôt
            if (Somme_depot_ok(somme))
            {
                solde += somme;
                return true;
            }
            return false;
        }

        public bool Retrait(double somme, DateTime date)
        {
                        
            if (Plafondok(somme) && Plafond_dates_ok(somme, date) && Somme_debit_ok(somme))
            {
                solde -= somme;
                _retraits.Add(somme);
                KeyValuePair<DateTime, double> transac = new KeyValuePair<DateTime, double>(date, somme);
                _dates_retraits.Add(transac);
                return true;
            }
            else return false;
            
        }
        
    }
}

