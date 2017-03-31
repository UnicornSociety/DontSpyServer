using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using static ModernEncryption.Intervals;

namespace ModernEncryption
{
    public class Symbol
    {
        public Dictionary<int, char> TransformationTable { get; set; } = new Dictionary<int, char>();
        public char symbol { get; }
        public String chiffre { get;  set; }


        public Symbol(char symbol)
        {
            this.symbol = symbol;
            var interval = IntervalAssignment();
            var randomNumber = SelectRandomIntervalNumber(interval);
            Debug.WriteLine(randomNumber);
            randomNumber = Permutation(randomNumber);
            chiffre = Transformation(randomNumber);
        }

        public Interval IntervalAssignment()
        {
            return IntervalTable[symbol];
        }

        public int SelectRandomIntervalNumber(Interval interval)
        {
            Random rnd = new Random();
            return rnd.Next(interval.Start, interval.End +1);
        }

        public int Permutation(int randomNumber)
        {
            return (randomNumber * 20 - 9) % 1600;
        }

        public string Transformation(int randomNumber)
        {
            TransformationTable.Add(1, 'a');
            TransformationTable.Add(2, 'b');
            TransformationTable.Add(3, 'c');
            TransformationTable.Add(4, 'd');
            TransformationTable.Add(5, 'e');
            TransformationTable.Add(6, 'f');
            TransformationTable.Add(7, 'g');
            TransformationTable.Add(8, 'h');
            TransformationTable.Add(9, 'i');
            TransformationTable.Add(10, 'j');
            TransformationTable.Add(11, 'k');
            TransformationTable.Add(12, 'l');
            TransformationTable.Add(13, 'm');
            TransformationTable.Add(14, 'n');
            TransformationTable.Add(15, 'o');
            TransformationTable.Add(16, 'p');
            TransformationTable.Add(17, 'q');
            TransformationTable.Add(18, 'r');
            TransformationTable.Add(19, 's');
            TransformationTable.Add(20, 't');
            TransformationTable.Add(21, 'u');
            TransformationTable.Add(22, 'v');
            TransformationTable.Add(23, 'w');
            TransformationTable.Add(24, 'x');
            TransformationTable.Add(25, 'y');
            TransformationTable.Add(26, 'z');
            TransformationTable.Add(27, 'ß');
            TransformationTable.Add(28, '.');
            TransformationTable.Add(29, ',');
            TransformationTable.Add(30, ' ');
            TransformationTable.Add(31, '1');
            TransformationTable.Add(32, '2');
            TransformationTable.Add(33, '3');
            TransformationTable.Add(34, '4');
            TransformationTable.Add(35, '5');
            TransformationTable.Add(36, '6');
            TransformationTable.Add(37, '7');
            TransformationTable.Add(38, '8');
            TransformationTable.Add(39, '9');
            TransformationTable.Add(40, '0');
            //TODO Rückübersetzung von Zahl in Zeichenpaar

            var keyA = (randomNumber - 1) / 40 + 1;
            var keyB = (randomNumber - 1) % 40 + 1;
            char chiffreSplit1 = TransformationTable[keyA];
            char chiffreSplit2 = TransformationTable[keyB];
            return ""+ chiffreSplit1 + chiffreSplit2;
        }

    }
}
