using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Convert PDF file (specified pages) to Multipage TIFF.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // This property is necessary only for registered version.
            //f.Serial = "XXXXXXXXXXX";

            string pdfPath = @"..\..\..\simple text.pdf";
            string tiffPath = @"..\..\..\result.tif";

            f.OpenPdf(pdfPath);

            // Let's set up the page indexes to convert the 2nd, 3rd, 4th pages.
            f.ImageOptions.SelectedPages = new int[] { 1, 2, 3 };
            f.ImageOptions.ImageFormat = SautinSoft.PdfFocus.CImageOptions.ImageFormats.Tif;

            f.ToImage(tiffPath);

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tiffPath) { UseShellExecute = true });
        }
    }
}