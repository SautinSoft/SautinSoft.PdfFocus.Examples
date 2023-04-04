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
            ConvertPdfToPngInThread();
        }
        public class TArgument
        {
            public string PdfFile { get; set; }
            public int PageNumber { get; set; }
        }
        public static void ConvertPdfToPngInThread()
        {
            string pdfs = Path.GetFullPath(@"..\..\..");
            string[] files = Directory.GetFiles(pdfs, "*.pdf");

            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < files.Length; i++)
            {
                TArgument targ = new TArgument()
                {
                    PdfFile = files[i],
                    PageNumber = 1
                };

                var t = new Thread((a) => ConvertToPng(a));
                t.Start(targ);
                threads.Add(t);
            }

            foreach (var thread in threads)
                thread.Join();
            Console.WriteLine("Done!");
        }

        public static void ConvertToPng(object targ)
        {
            TArgument targum = (TArgument)targ;
            string pdfFile = targum.PdfFile;
            int page = targum.PageNumber;

            string pngFile = Path.GetFileNameWithoutExtension(pdfFile) + ".png";

            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
            f.ImageOptions.Dpi = 300;

            f.OpenPdf(pdfFile);

            bool done = false;

            if (f.PageCount > 0)
            {
                if (page >= f.PageCount)
                    page = 1;

                if (f.ToImage(pngFile, page) == 0)
                    done = true;
                f.ClosePdf();
            }

            if (done)
            {
                Console.WriteLine("{0}\t - Done!", Path.GetFileName(pdfFile));
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pngFile) { UseShellExecute = true });
            }
            else
                Console.WriteLine("{0}\t - Error!", Path.GetFileName(pdfFile));
        }
    }
}
