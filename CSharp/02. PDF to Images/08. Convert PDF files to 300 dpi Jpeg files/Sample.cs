using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
                                  // Get your free 30-day key here:   
			 // https://sautinsoft.com/start-for-free/
			
            //Convert PDF files to 300-dpi JPG files
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            string[] pdfFiles = Directory.GetFiles(@"..\..\..\", "*.pdf");
            string folderWithJPGs = new DirectoryInfo(Directory.GetCurrentDirectory()).CreateSubdirectory("Result").FullName;

            foreach (string pdffile in pdfFiles)
            {
                f.OpenPdf(pdffile);

                if (f.PageCount > 0)
                {
                    //Set image format: Jpeg, 300 dpi
                    f.ImageOptions.Dpi = 300;
                    f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;

                    //Save all pages to jpeg files with 300 dpi
                    f.ToImage(folderWithJPGs, Path.GetFileNameWithoutExtension(pdffile));
                }
                f.ClosePdf();
            }
            //Show folder with jpegs
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(folderWithJPGs) { UseShellExecute = true });
        }
    }
}
