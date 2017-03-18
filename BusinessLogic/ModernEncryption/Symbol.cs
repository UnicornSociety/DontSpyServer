using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ModernEncryption
{
    public class Symbol
    {

        private string chiffre { get; }
        public char symbol { get; }

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
            return Intervals.IntervalTable[symbol];
        }

        public void SelectRandomIntervalNumber(Interval interval)
        {
            //TODO Zufällig Zahl zwischen Start und Endwert auswählen
        }

        public void Permutation()
        {
            //TODO Eine Permutation implementieren
        }

        public string Transformation()
        {
            //TODO Rückübersetzung von Zahl in Zeichenpaar
            return "blabla";
        }

    }
}
