using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using static ModernEncryption.Intervals;

namespace ModernEncryption
{
    public class Symbol
    {

        public char symbol { get; }
        public int start { get; }
        public int end { get; }
        public int chiffre { get;  set; }

        public Symbol(char symbol)
        {
            this.symbol = symbol;
            var interval = IntervalAssignment();
            SelectRandomIntervalNumber(interval);
            Permutation();
            Transformation();
        }

        public Interval IntervalAssignment()
        {
            return IntervalTable[symbol];
        }

        public void SelectRandomIntervalNumber(Interval interval)
        {
            Random rnd = new Random();
            var chiffre = rnd.Next(start, end +1);
        }

        public void Permutation()
        {
            chiffre = (chiffre * 20 - 9) % 1600;
        }

        public string Transformation()
        {
            //TODO Rückübersetzung von Zahl in Zeichenpaar

            // chiffre = (chiffre -  1) / 40;
            // int A = chiffre - 1 % 40;
            // int B = chiffre - 1 - 40 * A;
            if (Interval.ContainsValue(chiffre - 1 / 40))
            {
                return IntervalTable[TKey ];
            }
            if (Interval.ContainsValue(chiffre - 1 % 40))
            {
                return IntervalTable[TKey];
            }



             return "blabla"; 
        }

    }
}
