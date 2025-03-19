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
            // Before starting, we recommend to get a free key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
            // SautinSoft.PdfFocus.SetLicense("...");
			
            ConvertPdfToXmlInThread();
        }
        public class TArgument
        {
            public string PdfFile { get; set; }
            public int PageNumber { get; set; }
        }
        public static void ConvertPdfToXmlInThread()
        {
            string pdfs = Path.GetFullPath(@"..\..\..\");
            string[] files = Directory.GetFiles(pdfs, "*.pdf");

            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < files.Length; i++)
            {
                TArgument targ = new TArgument()
                {
                    PdfFile = files[i],
                    PageNumber = 1
                };

                var t = new Thread((a) => ConvertToXml(a));
                t.Start(targ);
                threads.Add(t);
            }

            foreach (var thread in threads)
                thread.Join();
            Console.WriteLine("Done!");
        }

        public static void ConvertToXml(object targ)
        {
            TArgument targum = (TArgument)targ;
            string pdfFile = targum.PdfFile;
            int page = targum.PageNumber;

            string xmlFile = Path.GetFileNameWithoutExtension(pdfFile) + ".xml";
			
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            f.OpenPdf(pdfFile);

            bool done = false;

            if (f.PageCount > 0)
            {
                if (page >= f.PageCount)
                    page = 1;

                if (f.ToXml(xmlFile, page, page) == 0)
                    done = true;
                f.ClosePdf();
            }

            if (done)
            {
                Console.WriteLine("{0}\t - Done!", Path.GetFileName(pdfFile));
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(xmlFile) { UseShellExecute = true });
            }
            else
                Console.WriteLine("{0}\t - Error!", Path.GetFileName(pdfFile));
        }
    }
}
