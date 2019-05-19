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
            BinomTest tester = new BinomTest();

            string path = Path.Combine(Environment.CurrentDirectory, "Log.txt");
            tester.LogFile = new StreamWriter(path, false);

            /***********************************/

            tester.CalculateAndLog(1);

            tester.CalculateAndLog(2);

            tester.CalculateAndLog(3);

            
            tester.CalculateAndLog(4);
            
            tester.CalculateAndLog(5);

            tester.CalculateAndLog(6);

            BinomCalc.ClearMemo();
            tester.CalculateAndLog(7);

            tester.LogFile.Dispose();

            Console.ReadLine();
        }
    }
}
