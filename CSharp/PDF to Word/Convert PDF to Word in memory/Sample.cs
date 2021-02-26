using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            ConvertPdfToDocxBytes();
            //ConvertPdfToRtfStream();
        }

        private static void ConvertPdfToDocxBytes()
        {
            string pdfFile = @"..\..\simple text.pdf";

            // Assume that we already have a PDF document as array of bytes.
            byte[] pdf = File.ReadAllBytes(pdfFile);
            byte[] docx = null;

            // Convert PDF to word in memory
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            //this property is necessary only for registered version
            //f.Serial = "XXXXXXXXXXX";

            f.OpenPdf(pdf);

            if (f.PageCount > 0)
            {
                // Convert pdf to word in memory.
                docx = f.ToWord();

                // Save word document to a file only for demonstration purposes.
                if (docx != null)
                {
                    //3. Save to DOCX document to a file for demonstration purposes.
                    string wordFile = "Result.docx";
                    File.WriteAllBytes(wordFile, docx);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(wordFile) { UseShellExecute = true });
                }
            }
        }
        private static void ConvertPdfToRtfStream()
        {
            string pdfFile = @"..\..\simple text.pdf";
            MemoryStream rtfStream = new MemoryStream();
            // Convert PDF to word in memory
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            //this property is necessary only for registered version
            //f.Serial = "XXXXXXXXXXX";

            // Assume that we already have a PDF document as stream.
            using (FileStream pdfStream = new FileStream(pdfFile, FileMode.Open, FileAccess.Read))
            {
                f.OpenPdf(pdfStream);

                if (f.PageCount > 0)
                {
                    f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Rtf;
                    int res = f.ToWord(rtfStream);

                    // Save rtfStream to a file for demonstration purposes.
                    if (res == 0)
                    {
                        string rtfFile = "Result.rtf";
                        File.WriteAllBytes(rtfFile, rtfStream.ToArray());
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(rtfFile) { UseShellExecute = true });
                    }
                }
            }
        }
    }
}
