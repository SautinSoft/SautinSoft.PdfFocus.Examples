using System;
using System.IO;
using System.Collections;

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
			
            string pdfPath = Path.GetFullPath(@"..\..\..\Excel.pdf");
            string imagePath = "Result.bmp";
			
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
	    	
            f.OpenPdf(pdfPath);

            if (f.PageCount > 0)
            {
                //Set "BMP" format for image
                f.ImageOptions.ImageFormat = SautinSoft.PdfFocus.CImageOptions.ImageFormats.Bmp;
                f.ImageOptions.Dpi = 300;

                //Convert 1st page from PDF to image file
                f.ImageOptions.PageIndex = 0;

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
