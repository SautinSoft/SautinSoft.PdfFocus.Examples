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
            //Convert PDF file to Multipage TIFF file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
	    	//this property is necessary only for registered version
		    //f.Serial = "XXXXXXXXXXX";

            string pdfPath = @"..\..\simple text.pdf";
            string tiffPath = "Result.tiff";

            f.OpenPdf(pdfPath);

            if (f.PageCount > 0)
            {
                f.ImageOptions.Dpi = 200;
                if (f.ToMultipageTiff(tiffPath) == 0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tiffPath) { UseShellExecute = true });
                }
            }            
        }
    }
}
