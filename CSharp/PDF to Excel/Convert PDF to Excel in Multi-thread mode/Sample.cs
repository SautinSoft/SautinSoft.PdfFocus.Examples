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
            ConvertPdfToExcelInThread();
        }
        public class TArgument
        {
            public string PdfFile { get; set; }
            public int PageNumber { get; set; }
        }
        public static void ConvertPdfToExcelInThread()
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

                var t = new Thread((a) => ConvertToExcel(a));
                t.Start(targ);
                threads.Add(t);
            }

            foreach (var thread in threads)
                thread.Join();
            Console.WriteLine("Done!");
        }

        public static void ConvertToExcel(object targ)
        {
            TArgument targum = (TArgument)targ;
            string pdfFile = targum.PdfFile;
            int page = targum.PageNumber;

            string excelFile = Path.GetFileNameWithoutExtension(pdfFile) + ".xls";
			// Activate your license here
			// SautinSoft.PdfFocus.SetLicense("1234567890");
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // 'true' = Convert all data to spreadsheet (tabular and even textual).
            // 'false' = Skip textual data and convert only tabular (tables) data.
            f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = true;

            // 'true'  = Preserve original page layout.
            // 'false' = Place tables before text.
            f.ExcelOptions.PreservePageLayout = true;

            // The information includes the names for the culture, the writing system, 
            // the calendar used, the sort order of strings, and formatting for dates and numbers.
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            ci.NumberFormat.NumberDecimalSeparator = ",";
            ci.NumberFormat.NumberGroupSeparator = ".";
            f.ExcelOptions.CultureInfo = ci;

            f.OpenPdf(pdfFile);

            bool done = false;

            if (f.PageCount > 0)
            {
                if (page >= f.PageCount)
                    page = 1;

                if (f.ToExcel(excelFile, page, page) == 0)
                    done = true;
                f.ClosePdf();
            }

            if (done)
            {
                Console.WriteLine("{0}\t - Done!", Path.GetFileName(pdfFile));
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(excelFile) { UseShellExecute = true });
            }
            else
                Console.WriteLine("{0}\t - Error!", Path.GetFileName(pdfFile));
        }
    }
}
