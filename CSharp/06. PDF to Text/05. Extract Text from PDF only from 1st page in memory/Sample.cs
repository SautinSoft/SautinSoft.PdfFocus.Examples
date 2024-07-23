using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Before starting, we recommend to get a free 100-day key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
            // SautinSoft.PdfFocus.SetLicense("...");
			
            string pdfFile = Path.GetFullPath(@"..\..\..\Potato Beetle.pdf");

            // Assume that we already have PDF as byte array
            byte[] pdfBytes = File.ReadAllBytes(pdfFile);            
			
            // Extract Text from PDF only from 1st page
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
	    	
            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                // Convert only 1st page
                string textString = f.ToText(1,1);

                // Save 'textString' to a file only for demonstration purposes.                
                string textFile = "Result.txt";
                File.WriteAllText(textFile, textString);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(textFile) { UseShellExecute = true });
            }
        }
    }
}
