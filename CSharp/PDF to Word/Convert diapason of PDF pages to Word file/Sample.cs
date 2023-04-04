using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string inpFile = Path.GetFullPath(@"..\..\..\Potato Beetle.pdf");
            string outFile = "Result.rtf";
            
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            // this property is necessary only for registered version.
            //f.Serial = "XXXXXXXXXXX";

            f.OpenPdf(inpFile);

            if (f.PageCount > 0)
            {
                // You may set an output format to docx or rtf.
                f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Rtf;

                // Specify to convert these pages: 2 - 4  and 6.

                // Way 1:
                f.RenderPagesString = "2-4, 6";

                // Way 2 (do the same as Way 1):
                f.RenderPages = new int[][] {new int[] {2, 4},
                                             new int[] {6, 6}};

                int result = f.ToWord(outFile);

                // Open the result.
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
                }
            }
        }
    }
}
