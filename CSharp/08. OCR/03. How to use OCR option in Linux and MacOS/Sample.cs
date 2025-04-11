using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SautinSoft;
using System.Diagnostics;
using System.Threading;
using SkiaSharp;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
          
            LoadScannedPdf();
        }

      
        static void LoadScannedPdf()
        {
            
            string inpFile = @"/home/developer/scan.pdf";
            string outFile = @"/home/developer/scan.docx";

            PdfFocus f = new PdfFocus();
            f.OCROptions.Mode = PdfFocus.COCROptions.eOCRMode.AllImages;
            f.OCROptions.OcrResourcePath = @"/usr/share/tesseract-ocr/5/tessdata/";
            f.OCROptions.OcrLanguage = "eng";
            f.OpenPdf(inpFile);
            bool result = false;
            if (f.PageCount > 0)
            {
                result = f.ToWord(outFile) == 0;
            }
            // Open the result for demonstration purposes.
            if (result)
            {                
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
            }
            else
                Console.WriteLine("Conversion failed!");
        }
    }
}