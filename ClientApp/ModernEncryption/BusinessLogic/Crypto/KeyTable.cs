using System;
using System.Collections.Generic;
using System.Text;

namespace ModernEncryption.BusinessLogic.Crypto
{


    class KeyTable
    {
        int numberOfSigns = 1600;
        private int[] key = GenerateKeys.ProduceKeys(1600);
        public static Dictionary<int, int> TableOfKeys = new Dictionary<int, int>();

        public void InitializeTableOfKeys()
        {
            for (int i = 1; i <= numberOfSigns; i++)
            {
                TableOfKeys.Add(i, key[i]);
            }

        }
    }
}
