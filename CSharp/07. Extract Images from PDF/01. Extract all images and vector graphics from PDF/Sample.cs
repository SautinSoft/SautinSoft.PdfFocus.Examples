using System;
using System.IO;
using System.Collections.Generic;
using SautinSoft;

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
			
            // Extract all images from PDF
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
			
            string pdfFile = Path.GetFullPath(@"..\..\..\simple text.pdf");
            string imageDir = new DirectoryInfo(Directory.GetCurrentDirectory()).CreateSubdirectory("images").FullName;

            List<PdfFocus.PdfImage> pdfImages = null;

            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                // Rasterize all vector graphics
                f.ImageExtractionOptions.RasterizeComplexGraphics = true;

                pdfImages = f.ExtractImages();

                // Show all extracted images.
                if (pdfImages != null && pdfImages.Count > 0)
                {

                    for (int i = 0; i < pdfImages.Count; i++)
                    {
                        string imageFile = Path.Combine(imageDir, String.Format("img{0}.png", i + 1));
                        pdfImages[i].Picture.Encode(new FileStream(imageFile, FileMode.Create), SkiaSharp.SKEncodedImageFormat.Png, 100);						
                    }

                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(imageDir) { UseShellExecute = true });
                }
            }
        }
    }
}
