using System;
using System.Collections.Generic;
using ModernEncryption.Interfaces;

namespace ModernEncryption.BusinessLogic.Crypto
{
    internal class KeyHandling : IKeyHandling
    {
        private int[] _l = new int[1600];
        private int[] _h = new int[1600];

        public int[] ProduceKeys(int n)

        {
            for (var i = 0; i < n; i++)
            {
                _h[i] = i;
            }
            for (var i = 0; i < n; i++)
            {
                var rnd = new Random(); //hier kann noch ein eigener Algorithmus hin
                var next = rnd.Next(0, n - 2 + 1);
                _l[i] = _h[next];
                for (var j = next; j < n - i-1; j++)
                {
                    _h[j] = _h[j+1];
                }
            }
            return _l;
        }

        public Dictionary<int, int> TableOfKeys = new Dictionary<int, int>();

        public Dictionary<int, int> KeyTable(int[] key)
        {
            for (var i = 1; i <= key.Length; i++)
            {
                TableOfKeys.Add(i, key[i]);
            }

            return TableOfKeys;
        }

        public Dictionary<int, int> CreateKey(int n)
        {
            var key = ProduceKeys(n);
            return KeyTable(key);
        }
    }

}