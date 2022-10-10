using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_III
{
    public static class ClassCouncil
    {
        public static void SchoolMeans(string input, string output)
        {
            Dictionary<string, List<float>> data = new Dictionary<string, List<float>>();
            
            using (FileStream classe = new FileStream(input, FileMode.Open, FileAccess.Read))
            {

                using (StreamReader str = new StreamReader(classe))
                {
                    
                    
                    
                    while (!str.EndOfStream)
                    {
                        string ligne = str.ReadLine();
                        string[] sp = ligne.Split(';');
                        string matière = sp[1];
                        var notes = new List<float> { 0, 0 };
                        float note;
                        bool ok = float.TryParse(sp[2], out note);
                        if (ok)
                        {
                            if (data.ContainsKey(matière) == false)
                            {
                                data.Add(matière, notes);
                            }
                            data[matière][0] += note;
                            data[matière][1]++;

                        }
                        else
                        {
                            Console.WriteLine("Note non convertible");
                        }
                    }
                                      
                }
                
            }
            float moyenne;
            Dictionary<string, float> moyennes = new Dictionary<string, float>();
            foreach (var item in data.Keys)
            {
                float n = data[item][1];
                float s = data[item][0];
                moyenne = s / n;
                moyennes[item] = moyenne;
            }
            using (FileStream moy = new FileStream(output, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(moy))
                {
                    foreach (var item in moyennes.Keys)
                    {
                        writer.WriteLine($"{item};{moyennes[item]:N1}");
                    }
                    
                }
            }
        }
    }
}
