using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ModernEncryption
{
    public class App
    {
        public void Start()
        {
            //Decryption
            Intervals.InitalizeIntervalTable();

            var dataHelper = new DataHelper();
            dataHelper.OutputAlert();
            var input = dataHelper.DataReadIn();
            var symbols = dataHelper.DataSplitting(input);
            if (dataHelper.ValidateData(symbols) == false)
            {
                dataHelper.ErrorOutput();
            }
            foreach (var symbol in symbols)
            {
                var chiffre = new Symbol(symbol);
                Debug.Write(chiffre.chiffre); 
            }

            //Encryption
            var dataHelperEncryption = new DataHelper();
            dataHelperEncryption.OutputAlert();
            var inputEncryption = dataHelperEncryption.DataReadIn();
            var oneOfChiffrePair = dataHelperEncryption.DataSplitting(inputEncryption);
            if (dataHelperEncryption.ValidateData(oneOfChiffrePair) == false)
            {
                dataHelperEncryption.ErrorOutput();
            }
            //TODO 2 aufeinanderfolgende chars im char array wieder in 1 Zahl verwandeln
            //TODO Permutation rückwärts
            //TODO Schauen in welchen Intervall die Zahl liegt
        }
    }
}
