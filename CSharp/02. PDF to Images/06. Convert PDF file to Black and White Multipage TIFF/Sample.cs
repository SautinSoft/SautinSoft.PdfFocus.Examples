using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

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
			
            // Convert PDF file to BlackAndWhite Multipage-TIFF.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            string pdfPath = Path.GetFullPath(@"..\..\..\simple text.pdf");
            string tiffPath = "Result.tiff";

            f.OpenPdf(pdfPath);

            if (f.PageCount > 0)
            {
                f.ImageOptions.Dpi = 200;
                f.ImageOptions.ColorDepth = SautinSoft.PdfFocus.CImageOptions.eColorDepth.BlackWhite1bpp;
                // EncoderValue.CompressionCCITT4 - also makes image black&white 1 bit
                f.ImageOptions.TIFFCompressionType = SautinSoft.PdfFocus.eTIFFCompressionType.CCITTFAX4;
                
                if (f.ToMultipageTiff(tiffPath) == 0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tiffPath) { UseShellExecute = true });
                }
            }            
        }
    }
}
