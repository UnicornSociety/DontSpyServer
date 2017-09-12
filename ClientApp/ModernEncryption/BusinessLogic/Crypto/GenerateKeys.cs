using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ModernEncryption.BusinessLogic.Crypto
{
    static class GenerateKeys
    {
        private static int j;
        private static int[] L, H;

        public static int[] ProduceKeys(int n)
        {
            for (var i = 0; i<n; i++)
            {
                H[i] = i;
            }
            for (var i = 0; i < n; i++)
            {
                var rnd = new Random();//hier muss noch ein eigener Algoithmus hin
                var next = rnd.Next(1, n-1 + 1);
                L[i] = H[next];
                for (var j = next; j < n - i;j++)
                {
                    H[j] = H[j + 1];
                }
            }
            return L;
        }

        
    }
}
