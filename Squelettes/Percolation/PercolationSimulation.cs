using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }
        /// <summary>
        /// Fraction
        /// </summary>
        public double Fraction { get; set; }
    }

    public class PercolationSimulation
    {
        public PclData MeanPercolationValue(int size, int t)
        {
            double Fraction = 0;
            for(int i = 1; i <= t; i++)
            {
                Fraction += PercolationValue(size);
                
            }
            double Mean = Fraction / t;
            double StandardDeviation = 0;
            // Dommage de ne pas renvoyer la moyenne 
            return new PclData() { Mean = Mean};
        }

        public double PercolationValue(int size)
        {
        
            Percolation perc = new Percolation(size);
            Random rnd = new Random();
            int i = 0;
            while (!perc.Percolate())
            {
                // Il faut que tu vérifies si la case n'a pas déjà été ouverte !
                int x = rnd.Next(0, maxValue: size);
                int y = rnd.Next(0, maxValue: size);

                // Ajout de ma part !
                if (!perc.IsOpen(x, y))
                {
                    perc.Open(x, y);
                    i++;
                }
                
            }
            // Division entre des entiers tu obtiens 0.
            return (double)i / (size * size);
            //return i / (size * size); 
        }
    }
}
