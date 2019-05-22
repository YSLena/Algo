using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace Binom
{

    // Тестирование алгоритмов

    class BinomTest
    {
        List<string> LogStrings = new List<string>();
        public StreamWriter LogFile;

        string getAlgjrithmName(int AlgoNum)
        {
            string str;
            switch (AlgoNum)
            {
                case 1:
                    str = @"""Наивыный"" алгоритм";
                    break;
                case 2:
                    str = "Улучшенный алгоритм (сокращение факториалов)";
                    break;
                case 3:
                    str = "Вынесение дробей";
                    break;
                case 31:
                    str = "Вынесение дробей, тип UInt64";
                    break;
                case 4:
                    str = "Рекусия со сложением: C(n,k) = C(n-1,k-1) + C(n-1, k)";
                    break;
                case 5:
                    str = "Рекусия с умножением: C(n,k) = n/k * C(n-1,k-1)";
                    break;
                case 6:
                    str = "Рекусия со сложением с мемоизацией результатов";
                    break;
                case 7:
                    str = "Рекусия с умножением с мемоизацией результатов";
                    break;
                case 8:
                    str = "Умножение с мемоизацией результатов без рекурсии";
                    break;
                default:
                    str = "Фигня";
                    break;
            }

            return str;
        }

        public void CalculateAndLog(int AlgoNum, int maxN)
        {
            string str, str1;
            uint n = 0;
            uint m = 0;

            LogStrings.Clear();

            str = getAlgjrithmName(AlgoNum);

            Console.WriteLine(str);
            LogStrings.Add(str);

            DateTime start = DateTime.Now;
            str = start.ToLongTimeString() + "." + start.Millisecond.ToString("d3");
            Console.WriteLine(str);
            LogStrings.Add(str);

            try
            {
                for (n = 0; n <= maxN; n++)
                {
                    str = "n=" + n.ToString("d3") + ": ";
                    //Console.Write("n= {0}: ", n.ToString("d3"));
                    for (m = 0; m <= n; m++)
                    {
                        switch (AlgoNum)
                        {
                            case 1:
                                str1 = BinomCalc.BinomNaive(n, m).ToString() + " ";
                                break;
                            case 2:
                                str1 = BinomCalc.BinomAdvanced(n, m).ToString() + " ";
                                break;
                            case 3:
                                str1 = BinomCalc.BinomFactorization(n, m).ToString() + " ";
                                break;
                            case 4:
                                str1 = BinomCalc.BinomRecursiveAdd(n, m).ToString() + " ";
                                break;
                            case 5:
                                str1 = BinomCalc.BinomRecursiveMultiplay(n, m).ToString() + " ";
                                break;
                            case 6:
                                str1 = BinomCalc.BinomRecursiveAddMemo(n, m).ToString() + " "; ;
                                break;
                            case 7:
                                str1 = BinomCalc.BinomRecursiveMultiplayMemo(n, m).ToString() + " "; ;
                                break;
                            case 8:
                                str1 = BinomCalc.BinomMultiplayMemo(n, m).ToString() + " "; ;
                                break;
                            default:
                                str1 = "Фигня";
                                break;
                        }

                        str = str + str1;
                        Console.Write(str1);
                    }
                    Console.Write(str);
                    LogStrings.Add(str);
                }
            }
            catch
            {
                str = str + "КАПЕЦ при n=" + n.ToString("d3");
                Console.WriteLine("КАПЕЦ при n= {0}: ", n.ToString("d3"));
                LogStrings.Add(str);
            }

            DateTime finish = DateTime.Now;
            str = finish.ToLongTimeString() + "." + finish.Millisecond.ToString("d3");
            Console.WriteLine(str);
            LogStrings.Add(str);

            TimeSpan delta = finish - start;

            str = delta.Hours.ToString() + " h " +
                delta.Minutes.ToString() + " m " +
                delta.Seconds.ToString() + " s " +
                delta.Milliseconds.ToString() + " ms";
            Console.WriteLine(str);
            LogStrings.Add(str);

            Console.WriteLine();
            LogStrings.Add("");

            str = "\n---------------";
            Console.WriteLine(str);
            LogStrings.Add(str);

            foreach (string s in LogStrings)
                LogFile.WriteLine(s);

            Console.WriteLine();

        }

        int[] RecursiveAlgoNum = new int[4] {4, 5, 6, 7};

        int[] MemoAlgoNum = new int[3] {6, 7, 8};


        public void CalculateOneAndLog(int AlgoNum, uint n, uint m)
        {
            LogStrings.Clear();

            string str, str1;

            str = getAlgjrithmName(AlgoNum);

            Console.WriteLine(str);
            LogStrings.Add(str);

            DateTime start = DateTime.Now;

            switch (AlgoNum)
            {
                case 1:
                    str1 = BinomCalc.BinomNaive(n, m).ToString();
                    break;
                case 2:
                    str1 = BinomCalc.BinomAdvanced(n, m).ToString();
                    break;
                case 3:
                    str1 = BinomCalc.BinomFactorization(n, m).ToString();
                    break;
                case 31:
                    str1 = BinomCalc.BinomUInt64Factorization(n, m).ToString();
                    break;
                case 4:
                    str1 = BinomCalc.BinomRecursiveAdd(n, m).ToString();
                    break;
                case 5:
                    str1 = BinomCalc.BinomRecursiveMultiplay(n, m).ToString();
                    break;
                case 6:
                    str1 = BinomCalc.BinomRecursiveAddMemo(n, m).ToString(); ;
                    break;
                case 7:
                    str1 = BinomCalc.BinomRecursiveMultiplayMemo(n, m).ToString(); ;
                    break;
                case 8:
                    str1 = BinomCalc.BinomMultiplayMemo(n, m).ToString(); ;
                    break;
                default:
                    str1 = "Фигня";
                    break;
            }

            str = "C(" + n + "," + m + ") = " + str1;
            Console.WriteLine(str);
            LogStrings.Add(str);

            DateTime finish = DateTime.Now;

            TimeSpan delta = finish - start;

            str = delta.Hours.ToString() + " h " +
                delta.Minutes.ToString() + " m " +
                delta.Seconds.ToString() + " s " +
                delta.Milliseconds.ToString() + " ms";
            Console.WriteLine(str);
            LogStrings.Add(str);

            if (RecursiveAlgoNum.Contains(AlgoNum))
            {
                str1 = "Количество вызовов: ";
                switch (AlgoNum)
                {
                    case 4:
                        str1 = str1 + BinomCalc.RecursiveAddCount.ToString();
                        break;
                    case 5:
                        str1 = str1 + BinomCalc.RecursiveMulpyCount.ToString();
                        break;
                    case 6:
                        str1 = str1 + BinomCalc.RecursiveAddMemoCount.ToString();
                        break;
                    case 7:
                        str1 = str1 + BinomCalc.RecursiveMultyMemoCount.ToString();
                        break;
                }

                Console.WriteLine(str1);
                LogStrings.Add(str1);
            }


            Console.WriteLine();
            LogStrings.Add("");


            foreach (string s in LogStrings)
                LogFile.WriteLine(s);

            Console.WriteLine();

        }

        uint[] testArr = new uint[100];

        public void GenerateTestDate()
        {
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
                testArr[i] = (uint)rand.Next(1000);
        }

        public void Calculate100AndLog(int AlgoNum, bool MemoPrecalc)
        {
            LogStrings.Clear();

            string str, str1;

            str = getAlgjrithmName(AlgoNum);

            if (MemoPrecalc && RecursiveAlgoNum.Contains(AlgoNum))
            {
                str += " с предварительным расчётом";
            }

            Console.WriteLine(str);
            LogStrings.Add(str);

            DateTime start = DateTime.Now;

            BigInteger c, CSum;

            // Предварителmный расчёт с мемоизацией
            if (MemoPrecalc)
            {
                for (uint i = 1; i <= 1000; i++)
                {
                    switch (AlgoNum)
                    {
                        case 6:
                            c = BinomCalc.BinomRecursiveAddMemo(i, i / 2); ;
                            break;
                        case 7:
                            c = BinomCalc.BinomRecursiveMultiplayMemo(i, i / 2); 
                            break;
                        case 8:
                            c = BinomCalc.BinomMultiplayMemo(i, i / 2);
                            break;
                    }
                }
            }


                for (int i = 0; i < testArr.Length; i++)
            {

                switch (AlgoNum)
                {
                    case 1:
                        c = BinomCalc.BinomNaive(testArr[i], testArr[i] / 2);
                        break;
                    case 2:
                        c = BinomCalc.BinomAdvanced(testArr[i], testArr[i] / 2);
                        break;
                    case 3:
                        c = BinomCalc.BinomFactorization(testArr[i], testArr[i] / 2);
                        break;
                    case 4:
                        c = BinomCalc.BinomRecursiveAdd(testArr[i], testArr[i] / 2);
                        break;
                    case 5:
                        c = BinomCalc.BinomRecursiveMultiplay(testArr[i], testArr[i] / 2);
                        break;
                    case 6:
                        c = BinomCalc.BinomRecursiveAddMemo(testArr[i], testArr[i] / 2);
                        break;
                    case 7:
                        c = BinomCalc.BinomRecursiveMultiplayMemo(testArr[i], testArr[i] / 2);
                        break;
                    case 8:
                        c = BinomCalc.BinomMultiplayMemo(testArr[i], testArr[i] / 2);
                        break;
                    default:
                        c = 0;
                        break;
                }
              
            }

            DateTime finish = DateTime.Now;

            TimeSpan delta = finish - start;

            str = delta.Hours.ToString() + " h " +
                delta.Minutes.ToString() + " m " +
                delta.Seconds.ToString() + " s " +
                delta.Milliseconds.ToString() + " ms";
            Console.WriteLine(str);
            LogStrings.Add(str);

            Console.WriteLine();
            LogStrings.Add("");


            foreach (string s in LogStrings)
                LogFile.WriteLine(s);

            Console.WriteLine();

        }


    }
}
