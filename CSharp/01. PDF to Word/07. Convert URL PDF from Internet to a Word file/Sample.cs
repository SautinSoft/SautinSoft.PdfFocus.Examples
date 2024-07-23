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

            string remotePdfUrl = @"https://sautinsoft.com/products/pdf-focus/help/net/developer-guide/data/files/parkmap.pdf";
            string pathToWord = @"Result.docx";

            //Convert URL-PDF from Internet to a Word file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            Uri uri = new Uri(remotePdfUrl);

            f.OpenPdf(uri);

            if (f.PageCount > 0)
            {
                int result = f.ToWord(pathToWord);

                //Show the resulting Word document
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pathToWord) { UseShellExecute = true });
                }
            }
        }
    }
}
