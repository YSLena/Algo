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
            tester.LogFile.WriteLine("ТЕСТ 1. Расчёт всех значений n = 0...20");
            tester.LogFile.WriteLine();
            /***********************************/

            BinomCalc.ClearMemo();

            for (int num = 1; num<=8; num++)
            {
                tester.CalculateAndLog(num, 20);
            }

            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("-------------------------------------------------------------------------------------");
            tester.LogFile.WriteLine();

            tester.LogFile.WriteLine("ТЕСТ 2. Расчёт значения C(10,5)");
            tester.LogFile.WriteLine();

            for (int num = 1; num <= 8; num++)
            {
                tester.CalculateOneAndLog(num, 10, 5);
            }

            BinomCalc.ClearMemo();

            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("-------------------------------------------------------------------------------------");
            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("ТЕСТ 3. Расчёт значения C(30,15)");
            tester.LogFile.WriteLine();

            for (int num = 1; num <= 8; num++)
            {
                tester.CalculateOneAndLog(num, 30, 15);
            }

            BinomCalc.ClearMemo();

            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("-------------------------------------------------------------------------------------");
            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("ТЕСТ 3. Расчёт значения C(100,50)");
            tester.LogFile.WriteLine();

            for (int num = 1; num <= 8; num++)
            {
                if (num == 4)
                    continue;
                tester.CalculateOneAndLog(num, 100, 50);
            }

            BinomCalc.ClearMemo();

            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("-------------------------------------------------------------------------------------");
            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("ТЕСТ 4. Расчёт 100 случайных значений");
            tester.LogFile.WriteLine();

            tester.GenerateTestDate();

            for (int num = 1; num <= 8; num++)
            {
                if (num == 4)
                    continue;
                tester.Calculate100AndLog(num, 100, 50);
            }


            tester.LogFile.Dispose();

            Console.ReadLine();
        }
    }
}
