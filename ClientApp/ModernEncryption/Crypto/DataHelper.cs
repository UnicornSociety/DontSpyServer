using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace ModernEncryption.Crypto
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
            //userInput = Console.ReadLine();
            userInput = "krypto";
            return userInput;
        }


        public string DataReadInDecryption()
        {
            string userInputDecryption;
            //userInput = Console.ReadLine();
            userInputDecryption = "qwx0g8w7eiwy";
            return userInputDecryption;
        }

        public char[] DataSplitting(string input)
        {
            return input.ToCharArray();
        }

        public bool ValidateData(char[] symbols)
        {
            char[] characters40 = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ß', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '.', ' ' };
            var helper = true;
            foreach (char symbol in symbols)
            {
                if (characters40.Contains(symbol)){
                    continue;
                }
                helper = false;
            }
            return helper;
        }

        public void ErrorOutput()
        {
            Debug.WriteLine("Fehler");
        }

    }
}
