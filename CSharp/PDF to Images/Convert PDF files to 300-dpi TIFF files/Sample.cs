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
            //Convert PDF files to 300-dpi TIFF files
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
	    	//this property is necessary only for registered version
		    //f.Serial = "XXXXXXXXXXX";

            string[] pdfFiles = Directory.GetFiles(@"..\..\", "*.pdf");
            string folderWithTiffs = new DirectoryInfo(Directory.GetCurrentDirectory()).CreateSubdirectory("Result").FullName;

            foreach (string pdffile in pdfFiles)
            {
                f.OpenPdf(pdffile);

                if (f.PageCount > 0)
                {
                    //Set image format: TIFF, 300 dpi
                    f.ImageOptions.Dpi = 300;
                    f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Tiff;

                    //Save all pages to tiff files with 300 dpi
                    f.ToImage(folderWithTiffs, Path.GetFileNameWithoutExtension(pdffile));
                }
                f.ClosePdf();
            }
            //Show folder with tiffs
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(folderWithTiffs) { UseShellExecute = true });
        }
    }
}
