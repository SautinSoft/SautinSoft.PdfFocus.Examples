using System;
using System.IO;
using System.Collections;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {

            string pdfPath = Path.GetFullPath(@"..\..\..\Excel.pdf");
            string imagePath = "Result.png";
			// Activate your license here
			// SautinSoft.PdfFocus.SetLicense("1234567890");
			
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
	    	
            f.OpenPdf(pdfPath);

            if (f.PageCount > 0)
            {
                //In most cases we recommend to set 200 dpi to decrease the image size and converting speed
                //Now set 300 dpi - very high quality
                f.ImageOptions.Dpi = 300;

                //Convert 1st page from PDF to image file
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
