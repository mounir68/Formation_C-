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
            FileStream t = EntreesSorties.Créa_stream(ftransactions);
            FileStream o = EntreesSorties.Créa_stream(fopérations);
            FileStream st = EntreesSorties.Créa_stream_w(transac_statut);
            FileStream so = EntreesSorties.Créa_stream_w(opé_statut);
            StreamWriter wt = EntreesSorties.créa_writer(st);
            StreamWriter wo = EntreesSorties.créa_writer(so);
            StreamReader str_t = EntreesSorties.créa_reader(t);
            StreamReader str_o = EntreesSorties.créa_reader(o);

            EntreesSorties.Gestion_entree_sortie(str_t, str_o,wt, wo, transac_statut, opé_statut);
            str_t.Dispose();
            str_o.Dispose();
            wo.Dispose();
            wt.Dispose();
            t.Close();
            o.Close();
            st.Close();
            so.Close();


           

            
           
        }
    }
}





