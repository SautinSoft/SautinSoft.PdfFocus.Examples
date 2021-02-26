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
            // Convert PDF file to BlackAndWhite Multipage-TIFF.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

	    	// This property is necessary only for registered version.
		    //f.Serial = "XXXXXXXXXXX";

            string pdfPath = @"..\..\simple text.pdf";
            string tiffPath = "Result.tiff";

            f.OpenPdf(pdfPath);

            if (f.PageCount > 0)
            {
                f.ImageOptions.Dpi = 200;
                f.ImageOptions.ColorDepth = SautinSoft.PdfFocus.CImageOptions.eColorDepth.BlackWhite1bpp;
                // EncoderValue.CompressionCCITT4 - also makes image black&white 1 bit
                if (f.ToMultipageTiff(tiffPath, EncoderValue.CompressionCCITT4) == 0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tiffPath) { UseShellExecute = true });
                }
            }            
        }
    }
}
