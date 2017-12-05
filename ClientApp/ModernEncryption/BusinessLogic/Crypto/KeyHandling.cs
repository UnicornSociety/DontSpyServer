using System;
using System.Collections.Generic;
using ModernEncryption.Interfaces;

namespace ModernEncryption.BusinessLogic.Crypto
{
    internal class KeyHandling : IKeyHandling
    {
        private readonly int[] _l = { };
        private readonly int[] _h = { };

        public string ProduceKeys(int n)

        {
            for (var i = 0; i < n; i++)
            {
                _h[i] = i;
            }
            for (var i = 0; i < n; i++)
            {
                var rnd = new Random(); //hier kann noch ein eigener Algoithmus hin
                var next = rnd.Next(1, n - 1 + 1);
                _l[i] = _h[next];
                for (var j = next; j < n - i; j++)
                {
                    _h[j] = _h[j + 1];
                }
            }
            return _l.ToString();
        }

        public Dictionary<int, int> TableOfKeys = new Dictionary<int, int>();

        public Dictionary<int, int> KeyTable(string key)
        {
            int[] intKey = { };
            for (var i = 0; i < key.ToCharArray().Length; i++)
            {
                intKey[i] = key[i];
            }
            for (var i = 1; i <= key.Length; i++)
            {
                TableOfKeys.Add(i, intKey[i]);
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