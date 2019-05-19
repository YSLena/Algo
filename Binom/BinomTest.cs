using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Binom
{
    class BinomTest
    {
        List<string> LogStrings = new List<string>();
        public StreamWriter LogFile;

        public void CalculateAndLog(int AlgoNum)
        {
            string str, str1;
            uint n = 0;
            uint m = 0;

            LogStrings.Clear();

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
                default:
                    str = "Фигня";
                    break;
            }

            Console.WriteLine(str);
            LogStrings.Add(str);

            DateTime start = DateTime.Now;
            str = start.ToLongTimeString()+"."+start.Millisecond.ToString("d3");
            Console.WriteLine(str);
            LogStrings.Add(str);

            try
            {
                for (n = 0; n <= 230; n++)
                {
                    str = "n=" + n.ToString("d3") + ": ";
                    Console.Write("n= {0}: ", n.ToString("d3"));
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
                            default:
                                str1 = "Фигня";
                                break;
                        }

                        str = str + str1;
                        Console.Write(str1);
                    }
                    Console.WriteLine();
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

    }
}
