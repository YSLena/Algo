using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Binom
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n = 0;
            uint m = 0;

            string path = Environment.CurrentDirectory + "Log.txt";
            StreamWriter LogFile = new StreamWriter(path);
            LogFile.WriteLine("rryr");

            Console.WriteLine("Binom1");
            try
            {
                for (n = 0; n < 100; n++)
                {
                    Console.Write("n= {0}: ", n.ToString("d3"));
                    for (m = 0; m <= n; m++)
                        Console.Write(BinomCalc.BinomNaive(n, m).ToString() + " ");
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Капец при n= {0}: ", n.ToString("d3"));
            }
            Console.WriteLine("---------------");
            Console.WriteLine();

            Console.WriteLine("Binom2");
            try
            {
                for (n = 0; n < 100; n++)
                {
                    Console.Write("n= {0}: ", n.ToString("d3"));
                    for (m = 0; m <= n; m++)
                        Console.Write(BinomCalc.BinomAdvanced(n, m).ToString() + " ");
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Капец при n= {0}: ", n.ToString("d3"));
            }
            Console.WriteLine("---------------");


            Console.WriteLine("Binom3");
            try
            {
                for (n = 0; n < 100; n++)
                {
                    Console.Write("n= {0}: ", n.ToString("d3"));
                    for (m = 0; m <= n; m++)
                        Console.Write(BinomCalc.BinomFactorization(n, m).ToString() + " ");
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Капец при n= {0}: ", n.ToString("d3"));
            }
            Console.WriteLine("---------------");

            Console.ReadLine();
        }
    }
}
