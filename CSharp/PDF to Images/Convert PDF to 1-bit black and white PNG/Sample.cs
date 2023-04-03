using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            //How to convert PDF to 1-bit black and white PNG
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
	    	//this property is necessary only for registered version
		    //f.Serial = "XXXXXXXXXXX";

            string pdfPath = @"..\..\simple text.pdf";
            string imagePath = "Result.png";

            f.OpenPdf(pdfPath);

            if (f.PageCount > 0)
            {
                //save 1st page to png file, 200 dpi
                f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
                f.ImageOptions.Dpi = 200;
                //Make "Black and White 1-bit indexed" image
                f.ImageOptions.ColorDepth = SautinSoft.PdfFocus.CImageOptions.eColorDepth.BlackWhite1bpp;

                if (f.ToImage(imagePath, 1) == 0)
                {
                    // 0 - converting successfully                
                    // 2 - can't create output file, check the output path
                    // 3 - converting failed
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(imagePath) { UseShellExecute = true });
                }
            }
        }
    }
}
