using System;
using System.Collections.Generic;
using System.Text;

namespace ModernEncryption
{
    public class App
    {
        public void Start()
        {
            System.Diagnostics.Debug.WriteLine("Hello World!");

            var dataHelper = new DataHelper();
            dataHelper.OutputAlert();
            var input = dataHelper.DataReadIn();
            var symbols = dataHelper.DataSplitting(input);
            if (dataHelper.ValidateData(symbols) == false)
            {
                dataHelper.ErrorOutput();
            }
            
           
			
        }
    }
}
