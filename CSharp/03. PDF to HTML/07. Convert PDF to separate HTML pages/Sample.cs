using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Convert PDF to separate HTMLs.
            // Each PDF page will be converted to a single HTML document.
            string pdfFile = Path.GetFullPath(@"..\..\..\simple text.pdf");            
            DirectoryInfo htmlDir = new DirectoryInfo("htmls");
            if (!htmlDir.Exists)
                htmlDir.Create();

                                  // Get your free 100-day key here:   
			 // https://sautinsoft.com/start-for-free/            

            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            f.HtmlOptions.IncludeImageInHtml = false;
            
            // Path (must exist) to a directory to store images after converting.             
            f.HtmlOptions.ImageFolder = htmlDir.FullName;

            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                // Convert each PDF page to separate HTML document.
                // simple text.html, simple text.html ... simple text.html.
                for (int page = 1; page <= f.PageCount; page++)
                {
                    f.HtmlOptions.Title = $"Page {page}";
                    f.HtmlOptions.ImageSubFolder = String.Format("page{0}_images", page);
                    string htmlString = f.ToHtml(page, page);

                    // Save htmlString to file
                    string htmlFile = Path.Combine(htmlDir.FullName, $"Page{page}.html");
                    File.WriteAllText(htmlFile, htmlString);

                    // Let's open only 1st and last pages.
                    if (page == 1 || page == f.PageCount)
                    {
                        // Open the result for demonstration purposes.
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlFile) { UseShellExecute = true });
                    }
                }
            }
        }
    }
}
