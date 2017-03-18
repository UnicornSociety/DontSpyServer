using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace ModernEncryption
{
    public class DataHelper
    {
        public void OutputAlert()
        {
            Debug.WriteLine("Bitte Eingabe taetigen: ");
        }

        public string DataReadIn()
        {
            string userInput;
            ///userInput = Console.ReadLine();
            userInput = "krypto";
            return userInput;
        }

        public char[] DataSplitting(string input)
        {
            var symbols = input.ToCharArray();
            return symbols;
        }


        public bool ValidateData(char[] symbols)
        {
            char[] characters40 = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ß', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '.', ' ' };
            bool helper = true;
            for (var i = 0; i < symbols.Length; i++)
            {
                if (characters40.Contains(symbols[i])){
                    continue;
                }
                else
                {
                    helper = false;
                }
            }
            return helper;
        }

        public void ErrorOutput()
        {
            Debug.WriteLine("Fehler");
        }

    }
}
