using System;
using System.IO;

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
			
            // Convert whole PDF document to separate Word documents.
            // Each PDF page will be converted to a single Word document.

            // Path to a PDF file.
            string pdfPath = Path.GetFullPath(@"..\..\..\simple text.pdf");

            // Directory to store Word documents.
            string docxDir = Directory.GetCurrentDirectory();
			
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            f.OpenPdf(pdfPath);

            // Convert each PDF page to separate Word document.
            // simple text - page 1.docx, simple text- page 2.docx ... simple text - page N.doc.
            for (int page = 1; page <= f.PageCount; page++)
            {
                // You may select between Docx and Rtf formats.
                f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;

                byte [] docxBytes = f.ToWord(page, page);

                string tempName = Path.GetFileNameWithoutExtension(pdfPath) + String.Format(" - page {0}.docx", page);
                string docxPath = Path.Combine(docxDir, tempName);
                File.WriteAllBytes(docxPath, docxBytes);

                // Let's show first and last Word pages.
                if (page == 1 || page==f.PageCount)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(docxPath) { UseShellExecute = true });
            }
        }
    }
}
