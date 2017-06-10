using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernEncryption.Crypto;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent ();
		    MainPage = new View.AddChatPage();
            //cryptoTest();
        }

        // TODO: Temporary
	    public void cryptoTest()
	    {
	        //Encryption
	        Intervals.InitalizeIntervalTable();
	        TransformationTable.InitalizeTransformationTable();
	        TransformationTable.InitializeKeyTable();

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
	            //Debug.WriteLine("Verschlüsselter Buchstabe");
	            Debug.Write(chiffre.Chiffre);
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
	        var counter = 0;
	        foreach (var value in listOfAllIntegers)
	        {
	            listOfAllIntegers[counter] = transformationSteps.BackPermutation(value);
	            counter++;
	        }
	        var plaintext = transformationSteps.NumberToLetter(listOfAllIntegers);
        }

	    protected override void OnStart()
	    {
	        // Handle when your app starts
	    }

	    protected override void OnSleep()
	    {
	        // Handle when your app sleeps
	    }

	    protected override void OnResume()
	    {
	        // Handle when your app resumes
	    }
    }
}
