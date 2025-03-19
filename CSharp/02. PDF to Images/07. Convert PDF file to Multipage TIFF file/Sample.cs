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
			
            //Convert PDF file to Multipage TIFF file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
	    	
            string pdfPath = Path.GetFullPath(@"..\..\..\simple text.pdf");
            string tiffPath = "Result.tiff";

            f.OpenPdf(pdfPath);

            if (f.PageCount > 0)
            {                
                f.ImageOptions.ImageFormat = SautinSoft.PdfFocus.CImageOptions.ImageFormats.Tif;
                f.ImageOptions.Dpi = 300;

                if (f.ToImage(tiffPath) == 0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tiffPath) { UseShellExecute = true });
                }
            }            
        }
    }
}
