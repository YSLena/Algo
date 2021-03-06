﻿using System;
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
            Console.WriteLine("ТЕСТ 1. Расчёт всех значений n = 0...20\n");
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
            Console.WriteLine("\nТЕСТ 2. Расчёт значения C(10,5)\n");
            tester.LogFile.WriteLine();

            for (int num = 1; num <= 8; num++)
            {
                tester.CalculateOneAndLog(num, 10, 5);
            }

            //BinomCalc.ClearMemo();
            BinomCalc.RecursiveCountReset();

            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("-------------------------------------------------------------------------------------");
            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("ТЕСТ 3. Расчёт значения C(30,15) без очистки мемо");
            Console.WriteLine("\nТЕСТ 3. Расчёт значения C(30,15)\n");
            tester.LogFile.WriteLine();

            for (int num = 1; num <= 8; num++)
            {
                tester.CalculateOneAndLog(num, 30, 15);
            }

            //BinomCalc.ClearMemo();
            BinomCalc.RecursiveCountReset();

            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("-------------------------------------------------------------------------------------");
            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("ТЕСТ 4. Расчёт значения C(100,50) без очистки мемо");
            Console.WriteLine("\nТЕСТ 3. Расчёт значения C(100,50)\n");
            tester.LogFile.WriteLine();

            for (int num = 1; num <= 8; num++)
            {
                if (num == 4)
                    continue;
                tester.CalculateOneAndLog(num, 100, 50);
            }

            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("-------------------------------------------------------------------------------------");
            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("ТЕСТ 5. Расчёт значения C(62,31) с разными типами результата");
            Console.WriteLine("\nТЕСТ 4. Расчёт значения C(62,31) с разными типами результата\n");
            tester.CalculateOneAndLog(3, 62, 31);
            tester.CalculateOneAndLog(31, 62, 31);
            tester.LogFile.WriteLine();


            BinomCalc.ClearMemo();
            BinomCalc.RecursiveCountReset();

            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("-------------------------------------------------------------------------------------");
            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("ТЕСТ 6. Расчёт 100 случайных значений, мемо очищались");
            Console.WriteLine("\nТЕСТ 5. Расчёт 100 случайных значений, мемо очищались\n");
            tester.LogFile.WriteLine();

            tester.GenerateTestDate();

            for (int num = 1; num <= 8; num++)
            {
                if (num == 4)
                    continue;
                tester.Calculate100AndLog(num, false);
            }

            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("Полный предварительный расчёт");
            Console.WriteLine("\nПолный предварительный расчёт\n");
            tester.LogFile.WriteLine();

            BinomCalc.ClearMemo();

            for (int num = 6; num <= 8; num++)
            {
                tester.Calculate100AndLog(num, true);
            }

            tester.LogFile.WriteLine();
            tester.LogFile.WriteLine("Повторный расчёт без очистки мемо");
            Console.WriteLine("\nПовторный расчёт без очистки мемо\n");
            tester.LogFile.WriteLine();

            for (int num = 6; num <= 8; num++)
            {
                tester.Calculate100AndLog(num, false);
            }

            tester.LogFile.Dispose();

            Console.WriteLine("Усё!");
            Console.ReadLine();
        }
    }
}
