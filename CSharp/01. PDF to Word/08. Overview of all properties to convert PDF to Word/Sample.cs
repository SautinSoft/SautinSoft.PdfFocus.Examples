using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pdfFile = Path.GetFullPath(@"..\..\..\simple text.pdf");
            string wordFile = "Result.docx";
             // Get your free 100-day key here:   
			 // https://sautinsoft.com/start-for-free/
			
            // In this sample you will find a short overview of all properties of WordOptions.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            
            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                // You may choose output format between Docx and Rtf.
                f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;

                // As you may know all text in PDF positioned by (x,y) coordinates.
                // In a Word document all text is placed inside paragraphs.
                // Flowing     - The most useful and common type of Word document for editing. The resulting Word document looks as if it was typed by human.
                //               The document layout created without using text boxes.
                //
                // Exact       - The most precise and fastest mode. The resulting Word document looks exact as PDF pixel by pixel (x,y).
                //               The document layout created by using text boxes, this gives a monumental accuracy for  PDF to Word conversion.
                //
                // Continuous  - The document layout created by using text boxes grouped in blocks.
                //               A golden mean between Flowing and Exact.
                f.WordOptions.RenderMode = SautinSoft.PdfFocus.CWordOptions.eRenderMode.Flowing;

                // As you may know PDF format doesn't have such concept as tables.
                // It's true, all tables in PDF represented using graphical lines.
                // true - parse all graphic lines to detect and recreate tables.
                // false - leave all graphic lines as is.
                f.WordOptions.DetectTables = true;

                // As you may know PDF contains embedded fonts with own symbol widths.
                // But the resulting Word document will have fonts installed at your system.
                // Sometimes their have different symbol width.
                // true - scale width of symbols to make it the same as in PDF.
                // false - don't scale width of symbols and use width of installed fonts.
                f.WordOptions.KeepCharScaleAndSpacing = false;

                // Sometimes a PDF document can contain a picture with a scanned text. 
                // Besides of this, this document can contain invisible text over this picture.
                // In case you need to get only that text and skip picture, you may set 'PreserveImages' to false and
                // set this property to true:
                f.WordOptions.ShowInvisibleText = true;
                //f.PreserveImages = false;

                int result = f.ToWord(wordFile);

                // Show the resulting Word document.
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(wordFile) { UseShellExecute = true });
                }
            }
        }
    }
}
