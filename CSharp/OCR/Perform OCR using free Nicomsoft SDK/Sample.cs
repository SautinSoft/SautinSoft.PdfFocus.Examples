using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SautinSoft;
using NSOCR_NameSpace;
using System.Drawing.Imaging;


namespace Sample
{
    public class PdfConverter
    {
        internal NSOCRLib.NSOCRClass NsOCR;
        internal int CfgObj = 0;
        internal int OcrObj = 0;
        internal int ImgObj = 0;
        internal int ScanObj = 0;
        internal int SvrObj = 0;
        internal bool OCRCreated = false;

        /// <summary>
        /// Converts PDF to DOCX, RTF, HTML, Text with OCR engine.
        /// </summary>
        public void ConvertPdfToAllWithOCR(string pdfPath)
        {
            // To perform OCR we'll use free OCR library by Nicomsoft.
            // https://www.nicomsoft.com/products/ocr/download/
            // The library is freeware and can be used in commercial application.
            // Also you have to insert this key:  AB2A4DD5FF2A.
            NsOCR = new NSOCRLib.NSOCRClass();
            NsOCR.Engine_SetLicenseKey("AB2A4DD5FF2A"); //required for licensed version only
            NsOCR.Engine_InitializeAdvanced(out CfgObj, out OcrObj, out ImgObj);

            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            f.OCROptions.Method += PerformOCRNicomsoft;
            f.OCROptions.Mode = PdfFocus.COCROptions.eOCRMode.AllImages;
            f.WordOptions.KeepCharScaleAndSpacing = false;

            string pdfFile = pdfPath;
            string outFile = String.Empty;

            f.OpenPdf(pdfFile);
            if (f.PageCount > 0)
            {
                // To Docx.
                outFile = "Result.docx";
                f.WordOptions.Format = PdfFocus.CWordOptions.eWordDocument.Docx;
                if (f.ToWord(outFile) == 0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });

                // To HTML.
                outFile = "Result.html";
                f.HtmlOptions.KeepCharScaleAndSpacing = false;
                if (f.ToHtml(outFile) == 0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
            }
            else
            {
                Console.WriteLine("Error: {0}!", f.Exception.Message);
                Console.ReadLine();
            }
        }
        public static byte[] PerformOCRNicomsoft(byte[] image)
        {
            NSOCRLib.NSOCRClass NsOCR;
            int CfgObj = 0;
            int OcrObj = 0;
            int ImgObj = 0;
            int SvrObj = 0;

            NsOCR = new NSOCRLib.NSOCRClass();
            NsOCR.Engine_SetLicenseKey("AB2A4DD5FF2A"); //required for licensed version only
            NsOCR.Engine_InitializeAdvanced(out CfgObj, out OcrObj, out ImgObj);

            // Scale
            NsOCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "ImgAlizer/AutoScale", "0");
            NsOCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "ImgAlizer/ScaleFactor", "4.0");

            NsOCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "Languages/English", "1");

            try
            {
                int res = 0;


                Array imgArray = null;
                using (MemoryStream ms = new MemoryStream(image))
                {
                    ms.Flush();
                    imgArray = ms.ToArray();
                }
                res = NsOCR.Img_LoadFromMemory(ImgObj, ref imgArray, imgArray.Length);
                if (res > TNSOCR.ERROR_FIRST)
                    return null;

                NsOCR.Svr_Create(CfgObj, TNSOCR.SVR_FORMAT_PDF, out SvrObj);
                NsOCR.Svr_NewDocument(SvrObj);

                res = NsOCR.Img_OCR(ImgObj, TNSOCR.OCRSTEP_FIRST, TNSOCR.OCRSTEP_LAST, TNSOCR.OCRFLAG_NONE);
                if (res > TNSOCR.ERROR_FIRST)
                    return null;




                res = NsOCR.Svr_AddPage(SvrObj, ImgObj, TNSOCR.FMT_EXACTCOPY);
                if (res > TNSOCR.ERROR_FIRST) return null;

                Array outPdf = null;
                NsOCR.Svr_SaveToMemory(SvrObj, out outPdf);

                return (byte[])outPdf;
            }
            finally
            {

            }
        }
    }
    class Sample
    {
        static void Main(string[] args)
        {
            // To perform OCR we'll use free OCR library by Nicomsoft.
            // https://www.nicomsoft.com/products/ocr/download/
            // The library is freeware and can be used in commercial application.

            PdfConverter converter = new PdfConverter();
            string inpFile = Path.GetFullPath(@"..\..\scan.pdf");
            converter.ConvertPdfToAllWithOCR(inpFile);

            // You are trying to compile this code sample and see the errors: 
            // NSOCRClass: Engine_SetLicenseKey
            // PdfFocus: OCROptions
            //
            // 1. Download Nicomsoft OCR SDK from: http://www.nicomsoft.com/files/ocr/free_NSOCR_v70_build885_full.exe
            // 2. Install it on your PC or server-side.
            // 3. Launch code sample again and enjoy! 

            // Please, read the full manual - How to use PDF Focus .Net with OCR (Readme.html)
            // IMPORTANT: PDF Focus .Net supports OCR since version 7.0
        }
    }
}
