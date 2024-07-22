using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            ConvertPdfBytesToHtml();
            //ConvertPdfStreamToHtml();
        }

        private static void ConvertPdfBytesToHtml()
        {
            // We need files only for demonstration purposes.
            // The whole conversion process will be done in memory.
            string pdfFile = Path.GetFullPath(@"..\..\..\simple text.pdf");
            string htmlFile = "Result.html";

                                  // Get your free 100-day key here:   
			 // https://sautinsoft.com/start-for-free/
			
            // Convert PDF to HTML in memory
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();


            // Let's force the component to store images inside HTML document
            // using base-64 encoding.
            // Thus the component will not use HDD.
            f.HtmlOptions.IncludeImageInHtml = true;
            f.HtmlOptions.Title = "Simple text";            

            // Read a PDF document to byte array
            // Assume that we already have the  PDF as array of bytes.
            byte[] pdf = File.ReadAllBytes(pdfFile);

            f.OpenPdf(pdf);

            if (f.PageCount > 0)
            {
                // Convert PDF to HTML in memory
                string html = f.ToHtml();

                // Save HTML to the file only for demonstration purpose.
                if (html != null)
                {
                    File.WriteAllText(htmlFile, html);
                    // Open the result for demonstration purposes.
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlFile) { UseShellExecute = true });

                }
            }
        }
        private static void ConvertPdfStreamToHtml()
        {
            // We need files only for demonstration purposes.
            // The whole conversion process will be done in memory.
            string pdfFile = Path.GetFullPath(@"..\..\..\simple text.pdf");
            string htmlFile = "Result.html";

                                  // Get your free 100-day key here:   
			 // https://sautinsoft.com/start-for-free/
			
            // Convert PDF to HTML in memory
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();


            // Let's force the component to store images inside HTML document
            // using base-64 encoding.
            // Thus the component will not use HDD.
            f.HtmlOptions.IncludeImageInHtml = true;
            f.HtmlOptions.Title = "Simple text";

            // Assume that we have a PDF document as Stream.
            using (FileStream fs = File.OpenRead(pdfFile))
            {
                f.OpenPdf(fs);

                if (f.PageCount > 0)
                {
                    // Convert PDF to HTML to a MemoryStream.
                    using (MemoryStream msHtml = new MemoryStream())
                    {
                        int res = f.ToHtml(msHtml);
                        // Open the result for demonstration purposes.
                        if (res == 0)
                        {
                            File.WriteAllBytes(htmlFile, msHtml.ToArray());
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlFile) { UseShellExecute = true });
                        }
                    }
                }
            }
        }
    }
}
