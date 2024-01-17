using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pdfFile = Path.GetFullPath(@"..\..\..\text and graphics.pdf");
            string wordFile = "Result.docx";
			
                                  // Get your free 30-day key here:   
			 // https://sautinsoft.com/start-for-free/
			
            //Convert PDF file to Text file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            
            f.OpenPdf(pdfFile);
            
            if (f.PageCount > 0)
            {
                int result = f.ToWord(wordFile);

                //Show Text document
                if (result == 0)
                {
                    Console.WriteLine("You are using the PDF Focus .Net v:");
                    Console.WriteLine(f.Version);
                    Console.ReadKey();
                }
            }
        }
    }
}
