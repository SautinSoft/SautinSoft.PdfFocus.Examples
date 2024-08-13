using SkiaSharp;
using System;
using System.IO;
using Tesseract;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Before starting, we recommend to get a free 100-day key:
            // https://sautinsoft.com/start-for-free/

            // Apply the key here:
            // SautinSoft.PdfFocus.SetLicense("...");

            //Convert custom PDF page to Tiff file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();


            string pdfPath = Path.GetFullPath(@"..\..\..\simple text.pdf");
            string tiffDir = new DirectoryInfo(Directory.GetCurrentDirectory()).CreateSubdirectory("Result").FullName;

            f.OpenPdf(pdfPath);

            for (int page = 0; page < f.PageCount; page++)
            {
                f.ImageOptions.ImageFormat = SautinSoft.PdfFocus.CImageOptions.ImageFormats.Tif;
                f.ImageOptions.Dpi = 300;
                // Save each PDF page as a separate Tiff file 
                f.ImageOptions.SelectedPages = new int[] { page };
                string tiffFile = Path.Combine(tiffDir, $"Page {page + 1}.tiff");
                int result = f.ToImage(tiffFile);
            }
        }
    }
}