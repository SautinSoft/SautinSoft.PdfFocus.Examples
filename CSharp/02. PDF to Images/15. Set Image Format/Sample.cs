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
            string imagePath = "Result.gif";
                                  // Get your free 30-day key here:   
			 // https://sautinsoft.com/start-for-free/
			
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
	    	
            f.OpenPdf(pdfPath);

            if (f.PageCount > 0)
            {
                //Set "GIF" format for image
                f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Gif;
                
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
