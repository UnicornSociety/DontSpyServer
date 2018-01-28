using System;
using System.Collections.Generic;
using ModernEncryption.Interfaces;

namespace ModernEncryption.BusinessLogic.Crypto
{
    internal class KeyHandling : IKeyHandling
    {

        public int[] ProduceKeys(int n)

        {
            int[] key = new int[n];
            int[] amountOfCiphers = new int[n];
            for (var i = 0; i < n; i++) //wegen int array der bei 0 startet hier Tabelle von 0 bis 8099
            {
                amountOfCiphers[i] = i;
            }
            for (var i = 0; i < n; i++)
            {
                var rnd = new Random(); //hier kann noch ein eigener Algorithmus hin
                var next = rnd.Next(0, n - i + 1); //da der Endwert nicht mit einbezogen wird muss +1 gerechnet werden 
                key[i] = amountOfCiphers[next];
                for (var j = next; j < n - i - 1; j++)
                    //-i deswegen, weil i schon nach vorne geschoben wurde, deshlab die letzten i keine Rolle mehr spielen
                {
                    amountOfCiphers[j] = amountOfCiphers[j + 1];
                }
            }
            return key;
        }

        
        public Dictionary<int, int> KeyTable(int[] key)
        {
            Dictionary<int, int> tableOfKeys = new Dictionary<int, int>();

            for (var i = 0; i < key.Length; i++)
            {
                tableOfKeys.Add(i, key[i]);
            }

            return tableOfKeys;
        }
    }

}