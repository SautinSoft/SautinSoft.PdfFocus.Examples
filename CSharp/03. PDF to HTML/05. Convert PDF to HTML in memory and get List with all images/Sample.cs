using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using SkiaSharp;

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
            List<SKBitmap> imgCollection = new List<SKBitmap>();
			
            // Convert PDF to HTML in memory
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();


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
                    foreach (SKBitmap img in imgCollection)
                    {
                        Console.WriteLine("\t {0,4} x {1,4} px", img.Width, img.Height);
                        string imageFileName = Path.Combine(imgDir.FullName, String.Format($"pict{count}.jpg"));
                        FileStream file = new FileStream(imageFileName, FileMode.Create);
                        img.Encode(file, SKEncodedImageFormat.Jpeg, 100);
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
