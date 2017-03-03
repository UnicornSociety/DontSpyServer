using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ModernEncryption
{
    public class DataHelper
    {
        public void OutputAlert()
        {
            Debug.WriteLine("Bitte Ausgabe taetigen: ");
        }

        public string DataReadIn()
        {
            // TODO: Zeichenfolge von Konsole einlesen
            return "";
        }

        public char[] DataSplitting(string input)
        {
            // TODO: toCharArray();
            return new char[]{ 'd', 'd'};
        }


        public bool ValidateData(char[] symbols)
        {
            // TODO: Check Zeichen auf Validierung

            return true;
        }

        public void ErrorOutput()
        {
            Debug.WriteLine("Fehler");
        }

    }
}
