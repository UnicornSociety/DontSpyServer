using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static ModernEncryption.Crypto.Intervals;

namespace ModernEncryption.Crypto
{
    public class Symbol
    {
        public char symbol { get; }
        public string Chiffre { get;  set; }
 
        public Symbol(char symbol)
        {
            this.symbol = symbol;
            var interval = IntervalAssignment();
            var randomNumber = SelectRandomIntervalNumber(interval);
            //Debug.WriteLine(randomNumber);
            var chiffre = Permutation(randomNumber);
            //Debug.WriteLine(chiffre);
            Chiffre = Transformation(chiffre);
        }

        public Interval IntervalAssignment()
        {
            return IntervalTable[symbol];
        }

        public int SelectRandomIntervalNumber(Interval interval)
        {
            Random rnd = new Random();
            return rnd.Next(interval.Start, interval.End + 1);
        }

        public string Transformation(int randomNumber)
        {

            //TODO Rückübersetzung von Zahl in Zeichenpaar

            var keyA = (randomNumber - 1) / 40 + 1;
            var keyB = (randomNumber - 1) % 40 + 1;
            char chiffreSplit1 = TransformationTable.transformationTable[keyA];
            char chiffreSplit2 = TransformationTable.transformationTable[keyB];
            return "" + chiffreSplit1 + chiffreSplit2;
        }

        /*public int KeyDataReadIn()
         {
            int keyInput = Console.ReadLine();
            int keyInput;
           /keyInput = 3;
            return keyInput;
        }*/

        /*public int ValueOfKeyDataReadIn()
        {
            int valueInput = Console.ReadLine();
            int valueInput;
            valueInput = 3;
            return valueInput;
        }*/

        
        

        //Encryption
        public int Permutation(int randomNumber)
        {
            
            if (TransformationTable.KeyTable.ContainsKey(randomNumber))
                {
                    randomNumber = TransformationTable.KeyTable[randomNumber];
                }
            return randomNumber;
        }

            //Decryption
            /*public int BackPermutation(int value)
            {
               if (KeyTable.ContainsValue(value))
               {
                   value = KeyTable.FirstOrDefault(x => x.Value == value).Key;
               }
                return value;
        }*/





    }
}
