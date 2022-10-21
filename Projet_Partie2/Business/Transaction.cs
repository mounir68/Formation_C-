using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    
    
    public class Transaction
    {
        public int Num_trans;
        public DateTime Date_trans;
        public double Montant_trans;
        public int Expéditeur;
        public int Destinataire;
        public bool statut;

        public Transaction(int num_trans, DateTime date_trans, double montant_trans, int expéditeur, int destinataire)
        {
            Num_trans = num_trans;
            Date_trans = date_trans;
            Montant_trans = montant_trans;
            Expéditeur = expéditeur;
            Destinataire = destinataire;
        }

        public bool Traitement_Transaction()
        {
            Dictionary<int, int> comptes_gest = new Dictionary<int, int>();
            comptes_gest = Gestionnaire.comptes_gests;
            Dictionary<int, Gestionnaire> gests = new Dictionary<int, Gestionnaire>(Banque._gests);
            
           
            
            // Dépôt
            if (Expéditeur == 0 && Destinataire != 0 && comptes_gest.ContainsKey(Destinataire))
            {
                Gestionnaire gestionnaire = gests[comptes_gest[Destinataire]];
                Compte_bancaire compte = gestionnaire._comptes[Destinataire];
                compte.Depot(Montant_trans);
                statut = true;

                return statut;
            }
            // Retrait
            else if (Expéditeur != 0 && Destinataire == 0 && comptes_gest.ContainsKey(Expéditeur))
            {
                Gestionnaire gestionnaire = gests[comptes_gest[Destinataire]];
                Compte_bancaire compte = gestionnaire._comptes[Destinataire];
                compte.Retrait(Montant_trans, Date_trans);
                statut = true;

                return statut;

            }
            // Opération intercomptes
            else if (Expéditeur != 0 && Destinataire != 0 && comptes_gest.ContainsKey(Destinataire) && comptes_gest.ContainsKey(Expéditeur))
            {
                Gestionnaire gestionnaire_exp = gests[comptes_gest[Expéditeur]];
                Gestionnaire gestionnaire_dest = gests[comptes_gest[Destinataire]];
                Compte_bancaire compte_exp = gestionnaire_exp._comptes[Expéditeur];
                Compte_bancaire compte_dest = gestionnaire_exp._comptes[Destinataire];

                if (Expéditeur != Destinataire && gestionnaire_exp.type == "Particulier")
                {
                    Montant_trans += (Montant_trans * 0.01);
                }
                else if (Expéditeur != Destinataire && gestionnaire_exp.type == "Entreprise")
                {
                    Montant_trans += 10;
                }
                compte_exp.Retrait(Montant_trans, Date_trans);
                statut = true;

                return statut;
            }
            statut = false;
            return statut;
        }
    }
}
