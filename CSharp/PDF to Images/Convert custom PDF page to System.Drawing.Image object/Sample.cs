using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            //Convert custom PDF page to Image object
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
	    	//this property is necessary only for registered version
		    //f.Serial = "XXXXXXXXXXX";

            string pdfPath = Path.GetFullPath(@"..\..\..\Excel.pdf");
            string imagePath = "Result.png";

            f.OpenPdf(pdfPath);

            if (f.PageCount > 0)
            {
                //Let's convert 1st page into System.Drawing.Image object, 120 dpi
                f.ImageOptions.Dpi = 120;
                System.Drawing.Image img = f.ToDrawingImage(1);

                //Save to file
                if (img != null)
                {
                    img.Save(imagePath);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(imagePath) { UseShellExecute = true });
                }
            }
        }
    }
}
