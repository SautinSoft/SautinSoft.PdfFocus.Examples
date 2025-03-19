using System.IO;
using SautinSoft;
using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Before starting, we recommend to get a free key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
            // SautinSoft.PdfFocus.SetLicense("...");
			
            // Note: Please rebuild the project to restore Nuget packages.
            LoadScannedPdf();
        }

        /// <summary>
        /// Load a scanned PDF document with help of Tesseract OCR (free OCR library) and save the result as DOCX document.
        /// </summary>
        static void LoadScannedPdf()
        {
            // Here we'll load a scanned PDF document (perform OCR) containing a text on English, Russian and Vietnamese.
            // Next save the OCR result as a new DOCX document.

            // First steps:

            // 1. Download data files for English, Russian and Vietnamese languages.
            // Please download the files: eng.traineddata, rus.traineddata and vie.traineddata.
            // From here (good and fast): https://github.com/tesseract-ocr/tessdata_fast
            // or (best and slow): https://github.com/tesseract-ocr/tessdata_best

            // 2. Copy the files: eng.traineddata, rus.traineddata and vie.traineddata to
            // the folder "tessdata" in the Project root.

            // 3. Be sure that the folder "tessdata" also contains "pdf.ttf" file.

            // Let's start:
            string inpFile = Path.GetFullPath(@"..\..\..\ARGW64125SX.pdf");
            string outFile = "Result.docx";

            PdfFocus f = new PdfFocus();
            f.OCROptions.Mode = PdfFocus.COCROptions.eOCRMode.AllImages;
            f.OCROptions.OcrResourcePath = @"..\..\..\tessdata";
            f.OCROptions.OcrLanguage = "ron";

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