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

        // Рекурсивные алгоритмы
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

        // 3 одинаковых коллекции для 3 алгоритмов
        static List<BigInteger[]> BimomMemo1 = new List<BigInteger[]>();
        static List<BigInteger[]> BimomMemo2 = new List<BigInteger[]>();
        static List<BigInteger[]> BimomMemo3 = new List<BigInteger[]>();

        public static void ClearMemo()
        {
            BimomMemo1.Clear();
            BimomMemo2.Clear();
            BimomMemo3.Clear();
        }

        // Рекурсивное сложение с сохранением результатов
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
            while (BimomMemo1.Count < n-3)
                BimomMemo1.Add(new BigInteger[(BimomMemo1.Count / 2) + 1]);

            int i = (int)(n - 4);
            int j = (int)(m - 2);

            // Уже считали?
            if (BimomMemo1[i][j] != 0)
                return BimomMemo1[i][j];

            BigInteger res = 1;

            checked
            {
                res = BinomRecursiveAddMemo(n - 1, m - 1) + BinomRecursiveAddMemo(n - 1, m);
            }

            // Сохраняем результат и возвращаем его
            BimomMemo1[i][j] = res;
            return res;
        }

        // Рекурсивное перемножение дробей с сохранением результатов
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
            while (BimomMemo2.Count < n - 3)
                BimomMemo2.Add(new BigInteger[(BimomMemo2.Count / 2) + 1]);

            int i = (int)(n - 4);
            int j = (int)(m - 2);

            if (BimomMemo2[i][j] != 0)
                return BimomMemo2[i][j];

            BigInteger res = 1;

            checked
            {
                res = (BinomRecursiveMultiplayMemo(n - 1, m - 1) * n) / m;
            }

            BimomMemo2[i][j] = res;
            return res;
        }

        // Перемножение дробей с сохранением результатов без рекурсии
        public static BigInteger BinomMultiplayMemo(uint n, uint k)
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
            while (BimomMemo3.Count < n - 3)
                BimomMemo3.Add(new BigInteger[(BimomMemo3.Count / 2) + 1]);

            int i = (int)(n - 4);
            int j = (int)(m - 2);

            // Проверяем, рассчитывалось ли значение раньше
            if (BimomMemo3[i][j] != 0)
                return BimomMemo3[i][j];

            int ii = i;
            int jj = j;

            // Ищем предыдущее известное значение
            while ((jj > 0) && (BimomMemo3[ii][jj] == 0))
            {
                ii--;
                jj--;
            }

            BigInteger res = BimomMemo3[ii][jj];

            if (res == 0)
            {
                // Если значения нет в массиве "берём" известное значение выше по диагонали от искомого, т.е. С(n-k+1, 1) 
                // при этом индексы выходят за пределы массива, т.к. это значение не сохранялось
                res = n - m + 1;
                ii--;
                jj--;
            }

            checked
            {
                while (jj < j)
                {
                    ii++;
                    jj++;
                    res = (res * (ii+4)) / (jj+2);
                    BimomMemo3[ii][jj] = res;
                }
            }

            return res;
        }

    }


}
