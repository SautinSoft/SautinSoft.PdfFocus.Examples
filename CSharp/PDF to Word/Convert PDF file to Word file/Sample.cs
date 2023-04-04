using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pdfFile = Path.GetFullPath(@"..\..\..\text and graphics.pdf");
            string wordFile = "Result.docx";

            // Convert a PDF file to a Word file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            //this property is necessary only for registered version
            //f.Serial = "XXXXXXXXXXX";

            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                // You may choose output format between Docx and Rtf.
                f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;

                int result = f.ToWord(wordFile);

                // Show the resulting Word document.
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(wordFile) { UseShellExecute = true });
                }
            }
        }
    }
}
