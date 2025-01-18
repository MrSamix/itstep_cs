using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Delegate
{
    static class Task1
    {
        static public Predicate<int> IsEven = e => e % 2 == 0;
        static public Predicate<int> IsOdd = e => e % 2 != 0;
        static public Predicate<int> IsPrime = e =>
        {
            if (e <= 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(e); i++)
            {
                if (e % i == 0)
                {
                    return false;
                }
            }
            return true;
        };

        static public Predicate<int> IsFibonachi = e =>
        {
            int a = 0, b = 1, c = 0;
            while (c < e)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c == e;
        };

        public static int[] ShowEven(this int[] ints)
        {
            int[] result = new int[0];
            foreach (int i in ints)
            {
                if (IsEven(i))
                {
                    Array.Resize(ref result, result.Length + 1);
                    result [result.Length - 1] = i;
                }
            }
            return result;
        }

        public static int[] ShowOdd(this int[] ints)
        {
            int[] result = new int[0];
            foreach (int i in ints)
            {
                if (IsOdd(i))
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = i;
                }
            }
            return result;
        }


        public static int[] ShowPrime(this int[] ints)
        {
            int[] result = new int[0];
            foreach (int i in ints)
            {
                if (IsPrime(i))
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = i;
                }
            }
            return result;
        }

        public static int[] ShowFibonachi(this int[] ints)
        {
            int[] result = new int[0];
            foreach (int i in ints)
            {
                if (IsFibonachi(i))
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = i;
                }
            }
            return result;
        }

    }
}
