using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    public class Banque
    {
        
        public static Dictionary<int, Gestionnaire> _gests = new Dictionary<int, Gestionnaire>();
        public static List<Gestionnaire> gestionnaires = new List<Gestionnaire>();
        

        static bool Num_gest_ok(int num_gest)
        {
            return num_gest > 0 && !_gests.ContainsKey(num_gest);
        }

        static bool Num_gest_exist(int num_gest)
        {
            return _gests.ContainsKey(num_gest);
        }

        static bool Type_ok(string type)
        {
            return type == "Particulier" || type == "Entreprise";
        }

        static bool Nb_trans_ok(int nb)
        {
            return nb > 0;
        }

        public static void  Création_gestionnaire(int num, string type, int nb)
        {
            Gestionnaire gestionnaire = new Gestionnaire(num, type, nb);
            if (Num_gest_ok(num) && Type_ok(type) && Nb_trans_ok(nb))
            {
                gestionnaires.Add(gestionnaire);
                _gests.Add(num, gestionnaire);
            }
        }

        public static bool Cession_Compte(int gest1, int gest2, int cpt, double solde)
        {
            if (Num_gest_exist(gest1) && Num_gest_exist(gest2))
            {
                return (_gests[gest1].ClotureCompte(cpt) && _gests[gest2].CreerCompte(cpt, solde));
            }
            else return false;
        }
    }
}
