using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Convert PDF to JPG with high Quality
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // This property is necessary only for registered version
            // f.Serial = "XXXXXXXXXXX";
            string pdfFile = @"..\..\simple text.pdf";
            string jpegDir = new DirectoryInfo(Directory.GetCurrentDirectory()).CreateSubdirectory("Result").FullName;

            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                // Set image properties: Jpeg, 200 dpi
                f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                f.ImageOptions.Dpi = 200;

                // Set 95 as JPEG quality
                f.ImageOptions.JpegQuality = 95;

                //Save all PDF pages to image folder, each file will have name Page 1.jpg, Page 2.jpg, Page N.jpg
                for (int page = 1; page <= f.PageCount; page++)
                {
                    string jpegFile = Path.Combine(jpegDir, String.Format("Page {0}.jpg", page));

                    // 0 - converted successfully                
                    // 2 - can't create output file, check the output path
                    // 3 - conversion failed
                    int result = f.ToImage(jpegFile, page);

                    // Show only 1st page
                    if (page == 1 && result == 0)
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(jpegFile) { UseShellExecute = true });
                }
            }
        }
    }
}
