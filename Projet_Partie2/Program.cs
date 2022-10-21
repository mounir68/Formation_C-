using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    

    class Program
    {
        static void Main(string[] args)
        {

            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
            string fgests = path + @"\gestionnaires.csv";
            string fopérations = path + @"\opérations.csv";
            string ftransactions = path + @"\transactions.csv";
            string transac_statut = path + @"\transac_statut.csv";
            string opé_statut = path + @"\opé_statut.csv";

            EntreesSorties.LectureGests(fgests);
            EntreesSorties.Gestion_entree_sortie(ftransactions, fopérations, transac_statut, opé_statut);
            
           
        }
    }
}





