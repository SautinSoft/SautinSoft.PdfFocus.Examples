using System.IO;
using SautinSoft;
using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
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
            string inpFile = Path.GetFullPath(@"..\..\..\scan.pdf");
            string outFile = "Result.docx";

            PdfFocus f = new PdfFocus();
            f.OCROptions.Mode = PdfFocus.COCROptions.eOCRMode.AllImages;
            f.OCROptions.Method += PerformOCRTesseract;

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
        public static byte[] PerformOCRTesseract(byte[] image)
        {
            // Specify that Tesseract use three 3 languages: English, Russian and Vietnamese.
            //string tesseractLanguages = "rus+eng+vie";
            string tesseractLanguages = "eng";

            // A path to a folder which contains languages data files and font file "pdf.ttf".
            // Language data files can be found here:
            // Good and fast: https://github.com/tesseract-ocr/tessdata_fast
            // or
            // Best and slow: https://github.com/tesseract-ocr/tessdata_best
            // Also this folder must have write permissions.
            string tesseractData = Path.GetFullPath(@"..\..\..\tessdata\");

            // A path for a temporary PDF file (because Tesseract returns OCR result as PDF document)
            string tempFile = Path.Combine(tesseractData, Path.GetRandomFileName());

            bool skipImages = true;

            try
            {
                using (Tesseract.IResultRenderer renderer = Tesseract.PdfResultRenderer.CreatePdfRenderer(tempFile, tesseractData, skipImages))
                {
                    using (renderer.BeginDocument("Serachablepdf"))
                    {
                        using (Tesseract.TesseractEngine engine = new Tesseract.TesseractEngine(tesseractData, tesseractLanguages, Tesseract.EngineMode.Default))
                        {
                            engine.DefaultPageSegMode = Tesseract.PageSegMode.Auto;
                            using (MemoryStream msImg = new MemoryStream(image))
                            {
                                System.Drawing.Image imgWithText = System.Drawing.Image.FromStream(msImg);
                                for (int i = 0; i < imgWithText.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page); i++)
                                {
                                    imgWithText.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, i);
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        imgWithText.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                        byte[] imgBytes = ms.ToArray();
                                        using (Tesseract.Pix img = Tesseract.Pix.LoadFromMemory(imgBytes))
                                        {
                                            using (var page = engine.Process(img, "Serachablepdf"))
                                            {
                                                renderer.AddPage(page);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return File.ReadAllBytes(tempFile + ".pdf");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Please be sure that you have Language data files (*.traineddata) in your folder \"tessdata\"");
                Console.WriteLine("The Language data files can be download from here: https://github.com/tesseract-ocr/tessdata_fast");
                Console.ReadKey();
                throw new Exception("Error Tesseract: " + e.Message);
            }
            finally
            {
                if (File.Exists(tempFile + ".pdf"))
                    File.Delete(tempFile + ".pdf");
            }
        }

    }
}