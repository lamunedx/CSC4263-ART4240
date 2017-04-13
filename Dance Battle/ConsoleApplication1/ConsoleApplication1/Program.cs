using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Mahdi\Documents\GitHub\CSC4263-ART4240\Dance Battle\Assets\brainPower.txt");
            List<double> doubles = new List<double>();
            for (int i = 0; i< lines.Length; i++)
            {
                double x = Convert.ToDouble(lines[i]);
                if (!doubles.Contains(x))
                {
                    doubles.Add(x);
                }

            }
            doubles.Sort();
            foreach (double number in doubles)
            {
                Console.WriteLine(number);
            }
        }
    }
}
