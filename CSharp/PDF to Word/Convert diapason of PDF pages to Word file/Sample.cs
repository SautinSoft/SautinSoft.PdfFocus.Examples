using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pathToPdf = @"..\..\Potato Beetle.pdf";
            string pathToWord = "Result.rtf";

            // Convert diapason of PDF pages to a Word file.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            // this property is necessary only for registered version.
            //f.Serial = "XXXXXXXXXXX";

            f.OpenPdf(pathToPdf);

            if (f.PageCount > 0)
            {
                // You may set an output format to docx or rtf.
                f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Rtf;

                // Convert only pages 2 - 4 to Word.
                int result = f.ToWord(pathToWord, 2, 4);

                // Show Word document
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pathToWord) { UseShellExecute = true });
                }
            }
        }
    }
}
