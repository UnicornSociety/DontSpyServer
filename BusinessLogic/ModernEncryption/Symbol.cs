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
            chiffre = Transformation(randomNumber);
        }

        //public int KeyDataReadIn()
        // {
            //int keyInput = Console.ReadLine();
            //int keyInput;
            //keyInput = 3;
            //return keyInput;
        //}

        public int ValueOfKeyDataReadIn()
        {
            //int valueInput = Console.ReadLine();
            int valueInput;
            valueInput = 3;
            return valueInput;
        }

        public static Dictionary<int, int> KeyTable  = new Dictionary<int, int>();
        public void Value(int valueInput)
        {
            KeyTable.Add(4, 21);
            KeyTable.Add(10, 22);
            KeyTable.Add(11, 23);
            KeyTable.Add(17, 24);
            KeyTable.Add(12, 25);
            KeyTable.Add(5, 26);
            KeyTable.Add(1, 27);
            KeyTable.Add(9, 28);
            KeyTable.Add(7, 29);
            KeyTable.Add(18, 30);
            KeyTable.Add(6, 31);
            KeyTable.Add(3, 32);
            KeyTable.Add(15, 33);
            KeyTable.Add(19, 34);
            KeyTable.Add(14, 35);
            KeyTable.Add(16, 36);
            KeyTable.Add(8, 37);
            KeyTable.Add(2, 38);
            KeyTable.Add(13, 39);
            KeyTable.Add(20, 40);
            KeyTable.Add(21, 4);
            KeyTable.Add(22, 10);
            KeyTable.Add(23, 11);
            KeyTable.Add(24, 17);
            KeyTable.Add(25, 12);
            KeyTable.Add(26, 5);
            KeyTable.Add(27, 1);
            KeyTable.Add(28, 9);
            KeyTable.Add(29, 7);
            KeyTable.Add(30, 18);
            KeyTable.Add(31, 6);
            KeyTable.Add(32, 3);
            KeyTable.Add(33, 15);
            KeyTable.Add(34, 19);
            KeyTable.Add(35, 14);
            KeyTable.Add(36, 16);
            KeyTable.Add(37, 8);
            KeyTable.Add(38, 2);
            KeyTable.Add(39, 13);
            KeyTable.Add(40, 20);
            KeyTable.Add(41, 71);
            KeyTable.Add(42, 72);
            KeyTable.Add(43, 73);
            KeyTable.Add(44, 74);
            KeyTable.Add(45, 75);
            KeyTable.Add(46, 76);
            KeyTable.Add(47, 77);
            KeyTable.Add(48, 78);
            KeyTable.Add(49, 79);
            KeyTable.Add(50, 80);
            KeyTable.Add(51, 81);
            KeyTable.Add(52, 82);
            KeyTable.Add(53, 83);
            KeyTable.Add(54, 84);
            KeyTable.Add(55, 85);
            KeyTable.Add(56, 86);
            KeyTable.Add(57, 87);
            KeyTable.Add(58, 88);
            KeyTable.Add(59, 89);
            KeyTable.Add(60, 90);
            KeyTable.Add(61, 91);
            KeyTable.Add(62, 92);
            KeyTable.Add(63, 93);
            KeyTable.Add(64, 94);
            KeyTable.Add(65, 95);
            KeyTable.Add(66, 96);
            KeyTable.Add(67, 97);
            KeyTable.Add(68, 98);
            KeyTable.Add(69, 99);
            KeyTable.Add(70, 100);
            KeyTable.Add(71, 41);
            KeyTable.Add(72, 42);
            KeyTable.Add(73, 43);
            KeyTable.Add(74, 44);
            KeyTable.Add(75, 45);
            KeyTable.Add(76, 46);
            KeyTable.Add(77, 47);
            KeyTable.Add(78, 48);
            KeyTable.Add(79, 49);
            KeyTable.Add(80, 50);
            KeyTable.Add(81, 51);
            KeyTable.Add(82, 52);
            KeyTable.Add(83, 53);
            KeyTable.Add(84, 54);
            KeyTable.Add(85, 55);
            KeyTable.Add(86, 56);
            KeyTable.Add(87, 57);
            KeyTable.Add(88, 58);
            KeyTable.Add(89, 59);
            KeyTable.Add(90, 60);
            KeyTable.Add(91, 61);
            KeyTable.Add(92, 62);
            KeyTable.Add(93, 63);
            KeyTable.Add(94, 64);
            KeyTable.Add(95, 65);
            KeyTable.Add(96, 66);
            KeyTable.Add(97, 67);
            KeyTable.Add(98, 68);
            KeyTable.Add(99, 69);
            KeyTable.Add(100, 70);

            //foreach (KeyValuePair<int, int> key in KeyTable)
            //{
                //int valuePair = valueInput;
            //}
            //TODO: Variablen key und value definieren
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

        //Encryption
        public int Permutation(int randomNumber)
        {
            if (KeyTable.ContainsKey(randomNumber))
            {
                KeyTable[randomNumber] = randomNumber;
                //return randomNumber;
            }
            return 1; //Platzhalter
        }

        //Decryption
        public int BackPermutation(int value)
        {
            if (KeyTable.ContainsKey(value))
            {
                KeyTable[value] = value;
                //return value; 
            }
            return 1; //Platzhalter
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
