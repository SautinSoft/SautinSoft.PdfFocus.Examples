using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pdfFile = Path.GetFullPath(@"..\..\..\simple text.pdf");
            string htmlFile = "Result.html";
			
                                  // Get your free 30-day key here:   
			 // https://sautinsoft.com/start-for-free/
			
            // Convert PDF file to HTML file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // Path (must exist) to a directory to store images after converting. Notice also to the property "ImageSubFolder".
            f.HtmlOptions.ImageFolder = Path.GetDirectoryName(htmlFile);

            // A folder (will be created by the component) without any drive letters, only the folder as "myfolder".
            f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile));

            // Auto - the same image format as in the source PDF;
            // 'Jpeg' to make the document size less; 
            // 'PNG' to keep the highest quality, but the highest size too.
            f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Auto;

            // How to store images: Inside HTML document as base64 images or as linked separate image files.
            f.HtmlOptions.IncludeImageInHtml = false;

            // Set <title>...</title>
            f.HtmlOptions.Title = String.Format("This HTML was converted from {0}.", Path.GetFileName(pdfFile));

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
