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
			// Activate your license here
			// SautinSoft.PdfFocus.SetLicense("1234567890");
			
            //Extract Text from 2nd-3rd pages of PDF
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
           
            f.OpenPdf(pdfFile);

            if (f.PageCount > 2)
            {
                //Convert only pages 2 - 3 to Text
                int result = f.ToText(textFile, 2, 3);

                //Show Text document
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(textFile) { UseShellExecute = true });
                }
            }
        }
    }
}
