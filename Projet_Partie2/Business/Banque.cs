using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    public class Banque
    {
        
        private static Dictionary<int, string> _gests;
        public static List<Gestionnaire> gestionnaires;
        

        private bool num_gest_ok(int num_gest)
        {
            return num_gest > 0 && !_gests.ContainsKey(num_gest);
        }

        private bool type_ok(string type)
        {
            return type == "Particulier" || type == "Entreprise";
        }

        private bool nb_trans_ok(int nb)
        {
            return nb > 0;
        }

        public void création_gestionnaire(int num, string type, int nb)
        {
            Gestionnaire gestionnaire = new Gestionnaire(num, type, nb);
            if (num_gest_ok(num) && type_ok(type) && nb_trans_ok(nb))
            {
                gestionnaires.Add(gestionnaire);
                _gests.Add(num, type);
            }
        }
    }
}
