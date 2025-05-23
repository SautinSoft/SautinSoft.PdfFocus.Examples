using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Before starting, we recommend to get a free key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
            // SautinSoft.PdfFocus.SetLicense("...");
			
            string pdfFile = Path.GetFullPath(@"..\..\..\text and graphics.pdf");
            string wordFile = "Result.docx";
			
            //Convert PDF file to Text file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            f.OpenPdf(pdfFile);

            //This property indicating whether to load embedded fonts from PDF and store them in document or skip them and use similar. Default value: Auto.
            f.PreserveEmbeddedFonts = SautinSoft.PdfFocus.ePropertyState.Enabled;

            if (f.PageCount > 0)
            {
                int result = f.ToWord(wordFile);

                //Show Text document
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(wordFile) { UseShellExecute = true });
                }
            }
        }
    }
}
