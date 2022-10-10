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
            return new PclData();
        }

        public double PercolationValue(int size)
        {
            bool[,] grille = new bool[size, size];
            Percolation perc = new Percolation(size);
            Random rnd = new Random();
            while (!perc.Percolate())
            {
                int x = rnd.Next(0, maxValue: size);
                int y = rnd.Next(0, maxValue: size);
                perc.Open(x, y);
            }
                
             
            return 0;
        }
    }
}
