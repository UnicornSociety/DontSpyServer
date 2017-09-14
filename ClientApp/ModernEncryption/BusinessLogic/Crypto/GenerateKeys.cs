using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ModernEncryption.BusinessLogic.Crypto
{
    class GenerateKeys
    {
        private int j;
        private int[] L, H;

        public String ProduceKeys(int n)

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
            return L.ToString();
        }

        public Dictionary<int, int> TableOfKeys = new Dictionary<int, int>();
    
        public Dictionary<int, int> KeyTable(int numberOfSigns, String key)
        {
            int[] intKey = new int[] {};
            for (int i=0; i< key.ToCharArray().Length;i++)
            {
                intKey[i] = (int)key[i];
            }
                for (int i = 1; i <= numberOfSigns; i++)
                {
                    TableOfKeys.Add(i, intKey[i]);
                }

        return TableOfKeys;
        }
    }
    
}
