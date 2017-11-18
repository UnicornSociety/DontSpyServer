using System;
using System.Collections.Generic;
using Plugin.SecureStorage;

namespace ModernEncryption.BusinessLogic.Crypto
{
    internal class GenerateKeys
    {
        private readonly int[] _l = { };
        private readonly int[] _h = { };

        public string ProduceKeys(int n)

        {
            for (var i = 0; i<n; i++)
            {
                _h[i] = i;
            }
            for (var i = 0; i < n; i++)
            {
                var rnd = new Random();//hier kann noch ein eigener Algoithmus hin
                var next = rnd.Next(1, n-1 + 1);
                _l[i] = _h[next];
                for (var j = next; j < n - i;j++)
                {
                    _h[j] = _h[j + 1];
                }
            }
            return _l.ToString();
        }

        public Dictionary<int, int> TableOfKeys = new Dictionary<int, int>();
    
        public Dictionary<int, int> KeyTable(int numberOfSigns, string key)
        {
            int[] intKey = {};
            for (var i=0; i< key.ToCharArray().Length;i++)
            {
                intKey[i] = key[i];
            }
                for (var i = 1; i <= numberOfSigns; i++)
                {
                    TableOfKeys.Add(i, intKey[i]);
                }

        return TableOfKeys;
        }

        public Dictionary<int, int> CreateKey(int n)
        {
            var key = ProduceKeys(n);
            var numberKey = 1;
            if (CrossSecureStorage.Current.HasKey("Number"))
            {
                var number = CrossSecureStorage.Current.GetValue("Number");
                numberKey = int.Parse(number);
                numberKey++;
                CrossSecureStorage.Current.SetValue("Number", numberKey.ToString());
            }
            else
            {
                CrossSecureStorage.Current.SetValue("Number", "1");
            }

            CrossSecureStorage.Current.SetValue(numberKey.ToString(), key);
            return KeyTable(n, key);
        }
    }
    
}