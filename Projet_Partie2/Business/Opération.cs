using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    public class Opération
    {
        public readonly DateTime Date_opé;
        public readonly int Entrée;
        public readonly int Sortie;
        public readonly double solde_initial;
        public readonly int numcpt;
        public bool statut;
  
        public Opération(DateTime date_opé, int entrée, int sortie, double solde_initial, int numcpt)
        {
            Date_opé = date_opé;
            Entrée = entrée;
            Sortie = sortie;        
            this.solde_initial = solde_initial;
            this.numcpt = numcpt;
        }

        public bool Traitement_Opé()
        {
            Dictionary<int, Gestionnaire> gestionnaires = Banque._gests;
            if (Entrée != 0 && Sortie == 0)
            {
                
                 if (gestionnaires.ContainsKey(Entrée))
                 {
                    
                    statut = gestionnaires[Entrée].CreerCompte(numcpt, solde_initial);
                    return statut;
                 }

                statut = false;
                return statut;
            }

            if (Entrée == 0 && Sortie != 0)
            {

                if (gestionnaires.ContainsKey(Sortie))
                {
                    statut =  gestionnaires[Sortie].ClotureCompte(numcpt);
                    return statut;
                }

                statut = false;
                return statut;
            }

            else if (Entrée != 0 && Sortie != 0 && Sortie != Entrée)
            {
                statut = Banque.Cession_Compte(Entrée, Sortie, numcpt, solde_initial);
                return statut;
            }

            statut = false;
            return statut;
        }

    }
}
