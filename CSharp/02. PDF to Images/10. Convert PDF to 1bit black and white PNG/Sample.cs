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
			
            //How to convert PDF to 1-bit black and white PNG
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
	    	
            string pdfPath = Path.GetFullPath(@"..\..\..\Potato Beetle.pdf");
            string imagePath = "Result.png";

            f.OpenPdf(pdfPath);

            if (f.PageCount > 0)
            {
                //save 1st page to png file, 300 dpi
                f.ImageOptions.ImageFormat = SautinSoft.PdfFocus.CImageOptions.ImageFormats.Png;
                f.ImageOptions.Dpi = 300;
                //Make "Black and White 1-bit indexed" image
                f.ImageOptions.ColorDepth = SautinSoft.PdfFocus.CImageOptions.eColorDepth.BlackWhite1bpp;
                f.ImageOptions.SelectedPages = new int[] { 0 };

                if (f.ToImage(imagePath) == 0)
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
