using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {
            PercolationSimulation simulation = new PercolationSimulation();
            PclData resultN = simulation.MeanPercolationValue(30, 30);
            Console.WriteLine($"N = {10} (moyenneN, relatifN, tempsN) : ({resultN.Mean:N4};{resultN.StandardDeviation:P}).");

            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }   
    }
}
