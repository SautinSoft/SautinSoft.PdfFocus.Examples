using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
			// Activate your license here
			// SautinSoft.PdfFocus.SetLicense("1234567890");
            string pdfFile = Path.GetFullPath(@"..\..\..\Example.pdf");
            string wordFile = "Result.docx";

            //Convert PDF file to Text file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            
            //Set a password for password-protected PDF documents. You need to set this option before "f.OpenPdf"
            f.Password = "123456789";

            f.OpenPdf(pdfFile);
            
            if (f.PageCount > 0)
            {
                int result = f.ToWord(wordFile);

                //Show Text document
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(wordFile) { UseShellExecute = true });
                }
            }
        }
    }
}
