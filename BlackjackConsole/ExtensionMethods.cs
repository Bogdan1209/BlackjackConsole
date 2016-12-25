using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    static class ExtensionMethods
    {
        public static int RangeOf(this int number, int minValue, int maxValue)
        {
            if(number >= minValue && number <= maxValue)
            {
                return number;
            }
            else
            {
                throw new Exception();
            }
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
