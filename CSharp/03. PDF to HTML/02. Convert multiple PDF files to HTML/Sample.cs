using System;
using System.IO;
using System.Linq;
using System.Text;
using SautinSoft;

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
			
            ConvertMultiplePdfToHtmls();
            //ConvertMultiplePdfToSingleHtml();
        }

        /// <summary>
        /// Converts multiple PDF files to HTML files.
        /// </summary>
        static void ConvertMultiplePdfToHtmls()
        {
            // Directory with *.pdf files.
            string pdfDirectory = Path.GetFullPath(@"..\..\..\");
            string[] pdfFiles = Directory.GetFiles(pdfDirectory, "*.pdf");
            DirectoryInfo htmlDirectory = new DirectoryInfo(@"htmls");
            if (!htmlDirectory.Exists)
                htmlDirectory.Create();
            
			PdfFocus f = new PdfFocus();
            
            int success = 0;
            int total = 0;

            foreach (string pdfFile in pdfFiles)
            {
                Console.WriteLine("Converting {0} ...", Path.GetFileName(pdfFile));

                f.OpenPdf(pdfFile);
                total++;

                if (f.PageCount > 0)
                {
                    // Path (must exist) to a directory to store images after converting. Notice also to the property "ImageSubFolder".
                    f.HtmlOptions.ImageFolder = htmlDirectory.FullName;

                    // A folder (will be created by the component) without any drive letters, only the folder as "myfolder".
                    f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile));

                    // A template name for images
                    f.HtmlOptions.ImageFileName = "picture";

                    // Auto - the same image format as in the source PDF;
                    // 'Jpeg' to make the document size less; 
                    // 'PNG' to keep the highest quality, but the highest size too.
                    f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Auto;

                    // How to store images: Inside HTML document as base64 images or as linked separate image files.
                    f.HtmlOptions.IncludeImageInHtml = false;

                    string htmlFile = Path.GetFileNameWithoutExtension(pdfFile) + ".html";
                    string htmlFilePath = Path.Combine(htmlDirectory.FullName, htmlFile);

                    if (f.ToHtml(htmlFilePath) == 0)
                    {
                        success++;
                    }
                }
            }
            // Show results:
            Console.WriteLine("{0} of {1} files converted successfully!", success, total);

            // Open folder with HTML files after converting.
            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlDirectory.FullName) { UseShellExecute = true });
        }
        /// <summary>
        /// Converts multiple PDF files into a single HTML document.
        /// </summary>
        static void ConvertMultiplePdfToSingleHtml()
        {
            // Directory with *.pdf files.
            string pdfDirectory = Path.GetFullPath(@"..\..\..\");
            string htmlFile = "Result.html";

            string[] pdfFiles = Directory.GetFiles(pdfDirectory, "*.pdf");

            // Here we'll keep our Html document.
            StringBuilder singleHtml = new StringBuilder();
            singleHtml.Append("<html>\r\n<head>\r\n");
            singleHtml.Append(@"<meta http-equiv = ""Content-Type"" content=""text/html; charset=utf-8"" />");
            singleHtml.Append("\r\n</head>\r\n<body>");

            PdfFocus f = new PdfFocus();

            int success = 0;
            int total = 0;

            foreach (string pdfFile in pdfFiles)
            {
                Console.WriteLine("Converting {0} ...", Path.GetFileName(pdfFile));

                f.OpenPdf(pdfFile);
                total++;

                if (f.PageCount > 0)
                {
                    // How to store images: Inside HTML document as base64 images or as linked separate image files.
                    f.HtmlOptions.IncludeImageInHtml = false;

                    // Create own subfolder for each converted file to store images separately and don't mix up them.
                    f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile));

                    // A template name for images
                    f.HtmlOptions.ImageFileName = "picture";

                    // Auto - the same image format as in the source PDF;
                    // 'Jpeg' to make the document size less; 
                    // 'PNG' to keep the highest quality, but the highest size too.
                    f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Auto;

                    // Let's make our CSS inline to be able merge HTML documents without any problems.
                    f.HtmlOptions.InlineCSS = true;

                    // We need only contents of <body>...</body>.
                    f.HtmlOptions.ProduceOnlyHtmlBody = true;

                    string tempHtml = f.ToHtml();

                    if (!String.IsNullOrEmpty(tempHtml))
                    {
                        success++;
                        // Add tempHtml into a single HTML.
                        singleHtml.Append(tempHtml);
                    }
                }
            }
            singleHtml.Append("</body></html>");

            // Show results:
            File.WriteAllText(htmlFile, singleHtml.ToString());

            Console.WriteLine("{0} of {1} files converted and merged into {2}!", success, total, Path.GetFileName(htmlFile));

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlFile) { UseShellExecute = true });
        }
    }
}
