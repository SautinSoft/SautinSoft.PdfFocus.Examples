using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Here we'll show you two modes of converting PDF to HTML:
            // PDF Focus .Net offers you the Fixed and Flowing modes by your choice.

            // HTML-Fixed (default) is better to use for rendering, because it completely 
            // repeats the PDF layout with the structure of pages. 
            // The markup of such documents is very complex and have a lot of tags styled by (x,y) coords.

            // HTML-Flowing is better for further processing by a human: editing and combining. 
            // The markup of such documents is much simple inside and has the flowing structure. 
            // It's very simple for understanding by a human. 
            // But the resulting HTML document doesn't look exactly the same as input PDF pixel by pixel.

            string pdfFile = Path.GetFullPath(@"..\..\..\License.pdf");
            string htmlFileFixed = "Fixed.html";
            string htmlFileFlowing = "Flowing.html";
			
                                  // Get your free 100-day key here:   
			 // https://sautinsoft.com/start-for-free/
			
            // Convert PDF file to HTML (Fixed and Flowing) file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // How to store images: Inside HTML document as base64 images or as linked separate image files.
            f.HtmlOptions.IncludeImageInHtml = true;

            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                // The HTML-Fixed mode.
                f.HtmlOptions.Title = "Fixed";
                f.HtmlOptions.RenderMode = PdfFocus.CHtmlOptions.eHtmlRenderMode.Fixed;
                if (f.ToHtml(htmlFileFixed)==0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlFileFixed) { UseShellExecute = true });

                // The HTML-Flowing mode.
                f.HtmlOptions.Title = "Flowing";
                f.HtmlOptions.RenderMode = PdfFocus.CHtmlOptions.eHtmlRenderMode.Flowing;
                // Switch off character scaling and spacing to prevent 
                // adding of extra tags dividing the text by parts.
                f.HtmlOptions.KeepCharScaleAndSpacing = false;                

                if (f.ToHtml(htmlFileFlowing) == 0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlFileFlowing) { UseShellExecute = true });
            }
        }
    }
}
