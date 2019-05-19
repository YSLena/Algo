using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Binom
{
    static class BinomCalc
    {
        // Вычисление биномиального коэффициента

        // Наивная реализация - вычисление по формуле в лоб - до n=20
        public static BigInteger BinomNaive(uint n, uint k)
        {
            if (k > n)
                return 0;

            BigInteger res = 1;

            checked
            {

                for (uint i = 1; i <= n; i++)
                    res *= i;

                for (uint j = 1; j <= k; j++)
                    res /= j;

                for (uint k1 = 1; k1 <= n - k; k1++)
                    res /= k1;
            }

            return res;
        }

        // Очевидное улучшение: сокращение k! в числителе и знаменателе - до n=29
        public static BigInteger BinomAdvanced(uint n, uint k)
        {
            if (k > n)
                return 0;

            // На основе свойства симметричности C(n,k)=C(n,n-k)
            // выбираем большее значение k, которое выгодноее сокращать
            uint m = Math.Max(k, n - k);

            if (m == n - 1)
                return n;

            if (m == n)
                return 1;

            BigInteger res = 1;
            
            checked
            {

                for (uint i = m+1; i <= n; i++)
                    res *= i;
               
                for (uint j = 1; j <= n - m; j++)
                    res /= j;
            }

            return res;
        }

        // На основе свойства вынесения, представляем C(n,k) как произведение дробей - до n= 62
        public static BigInteger BinomFactorization(uint n, uint k)
        {
            if (k > n)
                return 0;

            uint m = Math.Max(k, n - k);

            if (m == n - 1)
                return n;

            if (m == n)
                return 1;

            BigInteger res = 1;

            checked
            {
                for (uint i = 1; i <= n - m; i++)
                    /* Последовательность операций важна. 
                     * Если деление выполниться перед умножением, будет отброшен хвост */
                    res = (res * (m + i)) / i;
            }

            return res;
        }

        public static BigInteger BinomRecursiveAdd(uint n, uint k)
        {
            if (k > n)
                return 0;

            uint m = Math.Max(k, n - k);

            if (m == n - 1)
                return n;

            if (m == n)
                return 1;

            BigInteger res = 1;

            checked
            {
                res = BinomRecursiveAdd(n - 1, m - 1) + BinomRecursiveAdd(n - 1, m);
            }

            return res;
        }

        public static BigInteger BinomRecursiveMultiplay(uint n, uint k)
        {
            if (k > n)
                return 0;

            uint m = Math.Max(k, n - k);

            if (m == n - 1)
                return n;

            if (m == n)
                return 1;

            BigInteger res = 1;

            checked
            {
                res = (BinomRecursiveMultiplay(n - 1, m - 1) * n) / m;
            }

            return res;
        }

        static List<BigInteger[]> BimomMemo = new List<BigInteger[]>();

        public static void ClearMemo()
        {
            BimomMemo.Clear();
        }

        public static BigInteger BinomRecursiveAddMemo(uint n, uint k)
        {
            if (k > n)
                return 0;

            //Выбираем меньшее значение, чтобы хранить только половину данных
            uint m = Math.Min(k, n - k);

            if (m == 1)
                return n;

            if (m == 0)
                return 1;

            // в первых 3 строках хранить нечего
            while (BimomMemo.Count < n-3)
                BimomMemo.Add(new BigInteger[(BimomMemo.Count / 2) + 1]);

            int i = (int)(n - 4);
            int j = (int)(m - 2);

            if (BimomMemo[i][j] != 0)
                return BimomMemo[i][j];

            BigInteger res = 1;

            checked
            {
                res = BinomRecursiveAddMemo(n - 1, m - 1) + BinomRecursiveAddMemo(n - 1, m);
            }

            BimomMemo[i][j] = res;
            return res;
        }

        public static BigInteger BinomRecursiveMultiplayMemo(uint n, uint k)
        {
            if (k > n)
                return 0;

            //Выбираем меньшее значение, чтобы хранить только половину данных
            uint m = Math.Min(k, n - k);

            if (m == 1)
                return n;

            if (m == 0)
                return 1;

            // в первых 3 строках хранить нечего
            while (BimomMemo.Count < n - 3)
                BimomMemo.Add(new BigInteger[(BimomMemo.Count / 2) + 1]);

            int i = (int)(n - 4);
            int j = (int)(m - 2);

            if (BimomMemo[i][j] != 0)
                return BimomMemo[i][j];

            BigInteger res = 1;

            checked
            {
                res = (BinomRecursiveMultiplayMemo(n - 1, m - 1) * n) / m;
            }

            BimomMemo[i][j] = res;
            return res;
        }

    }


}
