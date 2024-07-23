using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
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
			
            ConvertPdfToHtmlInThread();
        }
        public class TArgument
        {
            public string PdfFile { get; set; }
            public string HtmlFile { get; set; }
            public int PageNumber { get; set; }
        }
        public static void ConvertPdfToHtmlInThread()
        {
            string pdfDir = Path.GetFullPath(@"..\..\..\");
            string[] pdfFiles = Directory.GetFiles(pdfDir, "*.pdf");
            DirectoryInfo htmlDir = new DirectoryInfo("HTML results");
            if (!htmlDir.Exists)
                htmlDir.Create();

            List<Thread> threads = new List<Thread>();
            foreach (string pdfFile in pdfFiles)
            {
                TArgument targ = new TArgument()
                {
                    PdfFile = pdfFile,
                    HtmlFile = Path.Combine(htmlDir.FullName, Path.GetFileNameWithoutExtension(pdfFile) + ".html"),
                    PageNumber = 1
                };

                var t = new Thread((a) => ConvertToHtml(a));
                t.Start(targ);
                threads.Add(t);
            }

            foreach (var thread in threads)
                thread.Join();
            Console.WriteLine("Done!");
            // Open the result for demonstration purposes.            
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlDir.FullName) { UseShellExecute = true });

        }

        public static void ConvertToHtml(object targ)
        {
            TArgument targum = (TArgument)targ;
            string pdfFile = targum.PdfFile;
            int page = targum.PageNumber;

            string htmlFile = targum.HtmlFile;
		
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Auto;
            f.HtmlOptions.IncludeImageInHtml = false;
            f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile));
            f.HtmlOptions.Title = String.Format("This document was produced from {0}.", Path.GetFileName(pdfFile));
            f.HtmlOptions.ImageFileName = "picture";

            f.OpenPdf(pdfFile);

            bool done = false;

            if (f.PageCount > 0)
            {
                if (page >= f.PageCount)
                    page = 1;

                if (f.ToHtml(htmlFile, page, page) == 0)
                    done = true;
                f.ClosePdf();
            }

            if (done)
                Console.WriteLine("{0}\t - Done!", Path.GetFileName(pdfFile));
            else
                Console.WriteLine("{0}\t - Error!", Path.GetFileName(pdfFile));
        }
    }
}
