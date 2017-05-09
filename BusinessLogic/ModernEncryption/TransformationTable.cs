using System;
using System.Collections.Generic;
using System.Text;

namespace ModernEncryption
{
    public static class TransformationTable
    {
        public static Dictionary<int, char> transformationTable { get; set; } = new Dictionary<int, char>();

        public static void InitalizeTransformationTable()
        {
            transformationTable.Add(1, 'a');
            transformationTable.Add(2, 'b');
            transformationTable.Add(3, 'c');
            transformationTable.Add(4, 'd');
            transformationTable.Add(5, 'e');
            transformationTable.Add(6, 'f');
            transformationTable.Add(7, 'g');
            transformationTable.Add(8, 'h');
            transformationTable.Add(9, 'i');
            transformationTable.Add(10, 'j');
            transformationTable.Add(11, 'k');
            transformationTable.Add(12, 'l');
            transformationTable.Add(13, 'm');
            transformationTable.Add(14, 'n');
            transformationTable.Add(15, 'o');
            transformationTable.Add(16, 'p');
            transformationTable.Add(17, 'q');
            transformationTable.Add(18, 'r');
            transformationTable.Add(19, 's');
            transformationTable.Add(20, 't');
            transformationTable.Add(21, 'u');
            transformationTable.Add(22, 'v');
            transformationTable.Add(23, 'w');
            transformationTable.Add(24, 'x');
            transformationTable.Add(25, 'y');
            transformationTable.Add(26, 'z');
            transformationTable.Add(27, 'ß');
            transformationTable.Add(28, '.');
            transformationTable.Add(29, ',');
            transformationTable.Add(30, ' ');
            transformationTable.Add(31, '1');
            transformationTable.Add(32, '2');
            transformationTable.Add(33, '3');
            transformationTable.Add(34, '4');
            transformationTable.Add(35, '5');
            transformationTable.Add(36, '6');
            transformationTable.Add(37, '7');
            transformationTable.Add(38, '8');
            transformationTable.Add(39, '9');
            transformationTable.Add(40, '0');
        }
        

    }

}
