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
            //Encryption
            Intervals.InitalizeIntervalTable();
            TransformationTable.InitalizeTransformationTable();

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
                //Debug.WriteLine(chiffre.Chiffre); 
            }

            //Decryption
            var dataHelperDecryption = new DataHelper();
            dataHelperDecryption.OutputAlert();
            var inputDecryption = dataHelperDecryption.DataReadInDecryption();
            var oneOfChiffrePair = dataHelperDecryption.DataSplitting(inputDecryption);
            if (dataHelperDecryption.ValidateData(oneOfChiffrePair) == false)
            {
                dataHelperDecryption.ErrorOutput();
            }
            var transformationSteps = new Decryption();
            var listOfAllIntegers = transformationSteps.BackTransformation(oneOfChiffrePair);
            //TODO Permutation rückwärts dafür andere Permutation benötigt
            var plaintext = transformationSteps.NumberToLetter(listOfAllIntegers);
        }
    }
}
