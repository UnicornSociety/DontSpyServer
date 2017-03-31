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



        }
    }
}
