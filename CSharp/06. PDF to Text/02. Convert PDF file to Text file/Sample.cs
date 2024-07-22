using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pdfFile = Path.GetFullPath(@"..\..\..\Potato Beetle.pdf");
            string textFile = "Result.txt";
                                  // Get your free 100-day key here:   
			 // https://sautinsoft.com/start-for-free/
			
            //Convert PDF file to Text file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            
            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                int result = f.ToText(textFile);

                //Show Text document
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(textFile) { UseShellExecute = true });
                }
            }
        }
    }
}
