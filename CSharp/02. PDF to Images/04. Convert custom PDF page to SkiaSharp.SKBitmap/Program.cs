using SkiaSharp;
using System;
using System.IO;

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
			
            //Convert custom PDF page to Image object
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();


            string pdfPath = Path.GetFullPath(@"..\..\..\text and graphics.pdf");
            string imagePath = "Result.jpg";

            f.OpenPdf(pdfPath);

            if (f.PageCount > 0)
            {
                //Let's convert 1st page into System.Drawing.Image object, 120 dpi
                f.ImageOptions.Dpi = 120;
                SKBitmap img = f.ToDrawingImage(1);

                //Save to file
                if (img != null)
                {
                    img.Encode(new FileStream(imagePath, FileMode.Create), SKEncodedImageFormat.Jpeg, 90);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(imagePath) { UseShellExecute = true });
                }
            }
        }
    }
}