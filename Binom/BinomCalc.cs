using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binom
{
    static class BinomCalc
    {
        // Вычисление биномиального коэффициента

        // Наивная реализация - вычисление по формуле в лоб - до n=20
        public static ulong BinomNaive(uint n, uint k)
        {
            if (k > n)
                return 0;
            /*
            if (k == 1)
                return n;

            if (k == n)
                return 1;
                */
            ulong res = 1;

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
        public static ulong BinomAdvanced(uint n, uint k)
        {
            if (k > n)
                return 0;

            if (k == 1)
                return n;

            if (k == n)
                return 1;

            ulong res = 1;


            // На основе свойства симметричности C(n,k)=C(n,n-k)
            // выбираем большее значение k, которое выгодноее сокращать
            uint m = Math.Max(k, n-k);
            
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
        public static ulong BinomFactorization(uint n, uint k)
        {
            if (k > n)
                return 0;

            if (k == 1)
                return n;

            if (k == n)
                return 1;

            ulong res = 1;

            uint m = Math.Max(k, n - k);

            checked
            {
                for (uint i = 1; i <= n - m; i++)
                    /* Надо явно указывать последовательность операций скобками, 
                     * иначе деление может выполниться перед умножением и будет отброшен хвост */
                    res = (res * (m + i)) / i;
            }

            return res;
        }

        public static ulong BinomRecursiveAdd(uint n, uint k)
        {
            if (k > n)
                return 0;

            if (k == 1)
                return n;

            if (k == n)
                return 1;

            ulong res = 1;

            uint m = Math.Max(k, n - k);

            checked
            {
                res = BinomRecursiveAdd(n - 1, m - 1) + BinomRecursiveAdd(n - 1, m);
            }

            return res;
        }

    }


}
