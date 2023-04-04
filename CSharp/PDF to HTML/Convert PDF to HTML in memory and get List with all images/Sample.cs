using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            ConvertPdfBytesToHtml();
        }

        private static void ConvertPdfBytesToHtml()
        {
            // We need files only for demonstration purposes.
            // The whole conversion process will be done in memory.
            string pdfFile = Path.GetFullPath(@"..\..\..\simple text.pdf");
            string htmlFile = "Result.htm";

            // This is the list with extracted images.
            // It will be filled by images after the conversion.
            List<Image> imgCollection = new List<Image>();

            // Convert PDF to HTML in memory
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // This property is necessary only for licensed version.
            //f.Serial = "XXXXXXXXXXX";

            // Let's force the component to store images inside HTML document
            // using base-64 encoding.
            // Thus the component will not use HDD.
            f.HtmlOptions.IncludeImageInHtml = true;
            f.HtmlOptions.Title = "Simple text";
            

            // Read a PDF document to byte array.
            // Assume that we already have the  PDF as array of bytes.
            byte[] pdf = File.ReadAllBytes(pdfFile);

            f.OpenPdf(pdf);

            if (f.PageCount > 0)
            {
                // Convert PDF to HTML in memory
                string htmlString = f.ToHtml(1, f.PageCount, imgCollection);

                // Save HTML to a file only for the demonstration purpose.
                if (htmlString != null)
                {
                    // Show info about images and save them
                    Console.WriteLine("After converting we've got {0} image(s):", imgCollection.Count);
                    DirectoryInfo imgDir = new DirectoryInfo("Extracted Images");
                    if (!imgDir.Exists)
                        imgDir.Create();

                    int count = 1;
                    foreach (Image img in imgCollection)
                    {
                        Console.WriteLine("\t {0,4} x {1,4} px", img.Width, img.Height);
                        string imageFileName = Path.Combine(imgDir.FullName, String.Format($"pict{count}.jpg"));
                        img.Save(imageFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        count++;
                    }
                    // Open the result for demonstration purposes.
                    File.WriteAllText(htmlFile, htmlString);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlFile) { UseShellExecute = true });
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(imgDir.FullName) { UseShellExecute = true });
                }
            }
        }
    }
}
