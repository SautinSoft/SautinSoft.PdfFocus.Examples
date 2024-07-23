using System;
using System.IO;
using System.Drawing;
using SkiaSharp;

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
			
            //Convert PDF into specified Image height & width
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            
            // Set initial values
            string pdfPath = Path.GetFullPath(@"..\..\..\Potato Beetle.pdf");
            string imageFolder = new DirectoryInfo(Directory.GetCurrentDirectory()).CreateSubdirectory("Result").FullName;
            int width = 1600; // Width in Px
            int height = 1900; // Height in Px

            //Set image options
            f.ImageOptions.ImageFormat = SautinSoft.PdfFocus.CImageOptions.ImageFormats.Png;
            f.ImageOptions.Resize(new SKSize { Width = width, Height = height }, false);

            f.OpenPdf(pdfPath);
            if (f.PageCount > 0)
            {
                // Convert all pages to PNG images
                f.ToImage(imageFolder, "Page");

                //Show image
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(imageFolder) { UseShellExecute = true });
            }
        }
    }
}
