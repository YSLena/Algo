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

            string path = Path.Combine(Environment.CurrentDirectory, "Log.txt");
            StreamWriter LogFile = new StreamWriter(path, false);
            string str;
            List<string> LogStrings = new List<string>();

            LogStrings.Clear();
            str = "BinomNaive";
            Console.WriteLine(str);
            LogStrings.Add(str);
            try
            {
                for (n = 0; n < 100; n++)
                {
                    str = "n=" + n.ToString("d3")+ ": ";
                    Console.Write("n= {0}: ", n.ToString("d3"));
                    for (m = 0; m <= n; m++)
                    {
                        str = str + BinomCalc.BinomNaive(n, m).ToString() + " ";
                        Console.Write(str);
                    }
                    Console.WriteLine();
                    LogStrings.Add(str);
                }
            }
            catch
            {
                str = str = "Капец при n=" + n.ToString("d3");
                Console.WriteLine("Капец при n= {0}: ", n.ToString("d3"));
                LogStrings.Add(str);
            }

            str = "\n\r---------------";
            Console.WriteLine(str);
            LogStrings.Add(str);

            foreach (string s in LogStrings)
                LogFile.WriteLine(s);

            Console.WriteLine();
            
            /***********************************/

            LogStrings.Clear();
            str = "BinomAdvanced";
            Console.WriteLine(str);
            LogStrings.Add(str);
            try
            {
                for (n = 0; n < 100; n++)
                {
                    str = "n=" + n.ToString("d3") + ": ";
                    Console.Write("n= {0}: ", n.ToString("d3"));
                    for (m = 0; m <= n; m++)
                    {
                        str = str + BinomCalc.BinomAdvanced(n, m).ToString() + " ";
                        Console.Write(str);
                    }
                    Console.WriteLine();
                    LogStrings.Add(str);
                }
            }
            catch
            {
                str = str = "Капец при n=" + n.ToString("d3");
                Console.WriteLine("Капец при n= {0}: ", n.ToString("d3"));
                LogStrings.Add(str);
            }

            str = "\n\r---------------";
            Console.WriteLine(str);
            LogStrings.Add(str);

            foreach (string s in LogStrings)
                LogFile.WriteLine(s);

            Console.WriteLine();
            LogFile.WriteLine();

            /***********************************/


            LogStrings.Clear();
            str = "BinomFactorization";
            Console.WriteLine(str);
            LogStrings.Add(str);
            try
            {
                for (n = 0; n < 100; n++)
                {
                    str = "n=" + n.ToString("d3") + ": ";
                    Console.Write("n= {0}: ", n.ToString("d3"));
                    for (m = 0; m <= n; m++)
                    {
                        str = str + BinomCalc.BinomFactorization(n, m).ToString() + " ";
                        Console.Write(str);
                    }
                    Console.WriteLine();
                    LogStrings.Add(str);
                }
            }
            catch
            {
                str = str = "Капец при n=" + n.ToString("d3");
                Console.WriteLine("Капец при n= {0}: ", n.ToString("d3"));
                LogStrings.Add(str);
            }

            str = "\n\r---------------";
            Console.WriteLine(str);
            LogStrings.Add(str);

            foreach (string s in LogStrings)
                LogFile.WriteLine(s);

            Console.WriteLine();
            LogFile.WriteLine();

            /***********************************/

            LogFile.Dispose();

            Console.ReadLine();
        }
    }
}
