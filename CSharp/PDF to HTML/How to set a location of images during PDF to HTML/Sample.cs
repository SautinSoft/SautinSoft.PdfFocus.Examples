using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Here you will find how to keep images in the resulting HTML document.
            string pdfFile = Path.GetFullPath(@"..\..\..\simple text.pdf");
            string htmlFile = "Result.html";

			// Activate your license here
			// SautinSoft.PdfFocus.SetLicense("1234567890");
			
            // Convert PDF file to HTML file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();


            // Way 1 (default): Images will be stored inside HTML document as base64, jpeg images.
            /*
            f.HtmlOptions.IncludeImageInHtml = true;
            // Auto - the same image format as in the source PDF;
            // 'Jpeg' to make the document size less; 
            // 'PNG' to keep the highest quality, but the highest size too.
            f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Jpeg;
            */

            // Way 2: Images will be stored as JPG files in a special folder "{pdf name}_images".
            // Images will have names "picture100.jpg", "picture101.jpg" .. "pictureN.jpg".
            // Let's set the quality for jpeg to 95 percents.
            f.HtmlOptions.ImageFolder = Path.GetDirectoryName(htmlFile);
            // Auto - the same image format as in the source PDF;
            // 'Jpeg' to make the document size less; 
            // 'PNG' to keep the highest quality, but the highest size too.
            f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Jpeg;

            f.EmbeddedJpegQuality = 95;
            f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile));
            f.HtmlOptions.ImageFileName = "picture";
            f.HtmlOptions.ImageNumStart = 100;
            f.HtmlOptions.IncludeImageInHtml = false;

            // Way 3: Images will be stored as PNG files in the same directory with the HTML file.
            // All images on each page will be combined in a single image.
            /*
            f.HtmlOptions.ImageFolder = Path.GetDirectoryName(htmlFile);
            // 'Jpeg' to make the document size less; Or 'PNG' to keep the highest quality.
            f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Png;
            f.HtmlOptions.ImageSubFolder = "";
            f.HtmlOptions.IncludeImageInHtml = false;
            */

            f.OpenPdf(pdfFile);
            if (f.PageCount > 0)
            {
                int res = f.ToHtml(htmlFile);
                // Open the result for demonstration purposes.
                if (res == 0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlFile) { UseShellExecute = true });
            }
        }
    }
}
