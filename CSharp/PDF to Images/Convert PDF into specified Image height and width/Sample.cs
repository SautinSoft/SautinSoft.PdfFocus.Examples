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
            //Convert PDF into specified Image height & width
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            //this property is necessary only for registered version
            //f.Serial = "XXXXXXXXXXX";

            // Set initial values
            string pdfPath = Path.GetFullPath(@"..\..\..\Potato Beetle.pdf");
            string imageFolder = new DirectoryInfo(Directory.GetCurrentDirectory()).CreateSubdirectory("Result").FullName;
            int width = 1600; // Width in Px
            int height = 1900; // Height in Px

            //Set image options
            f.ImageOptions.ImageFormat = ImageFormat.Png;
            f.ImageOptions.Resize(new Size { Width = width, Height = height }, false);

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
