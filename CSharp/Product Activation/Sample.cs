using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Activation of PDF Focus .Net after purchasing.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // You will get own serial number after purchasing the license.
            // If you will have any questions, email us to sales@sautinsoft.com or ask at online chat https://www.sautinsoft.com.

            // Let us say, you have this key: 1234567890.            
            f.Serial = "1234567890";

            string pdfPath = @"..\..\simple text.pdf";
            string tiffPath = "Result.tiff";

            // Open PDF
            f.OpenPdf(pdfPath);

            if (f.PageCount > 0)
            {
                // 0 - converting successfully            
                // 2 - can't create output file, check the output path
                // 3 - converting failed
                f.ImageOptions.Dpi = 300;
                if (f.ToMultipageTiff(tiffPath) == 0)
                {
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tiffPath) { UseShellExecute = true });
                }
            }
        }
    }
}
