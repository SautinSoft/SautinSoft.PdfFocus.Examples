Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.IO
Imports SautinSoft
Imports NSOCR_NameSpace
Imports System.Drawing.Imaging


Namespace Sample
	Public Class PdfConverter
		Friend NsOCR As NSOCRLib.NSOCRClass
		Friend CfgObj As Integer = 0
		Friend OcrObj As Integer = 0
		Friend ImgObj As Integer = 0
		Friend ScanObj As Integer = 0
		Friend SvrObj As Integer = 0
		Friend OCRCreated As Boolean = False

		''' <summary>
		''' Converts PDF to DOCX, RTF, HTML, Text with OCR engine.
		''' </summary>
		Public Sub ConvertPdfToAllWithOCR(ByVal pdfPath As String)
			' To perform OCR we'll use free OCR library by Nicomsoft.
			' https://www.nicomsoft.com/products/ocr/download/
			' The library is freeware and can be used in commercial application.
			' Also you have to insert this key:  AB2A4DD5FF2A.
			NsOCR = New NSOCRLib.NSOCRClass()
			NsOCR.Engine_SetLicenseKey("AB2A4DD5FF2A") 'required for licensed version only
			NsOCR.Engine_InitializeAdvanced(CfgObj, OcrObj, ImgObj)

			Dim f As New SautinSoft.PdfFocus()
			f.OCROptions.Method = AddressOf PerformOCRNicomsoft
			f.OCROptions.Mode = PdfFocus.COCROptions.eOCRMode.AllImages
			f.WordOptions.KeepCharScaleAndSpacing = False

			Dim pdfFile As String = pdfPath
			Dim outFile As String = String.Empty

			f.OpenPdf(pdfFile)
			If f.PageCount > 0 Then
				' To Docx.
				outFile = "Result.docx"
				f.WordOptions.Format = PdfFocus.CWordOptions.eWordDocument.Docx
				If f.ToWord(outFile) = 0 Then
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
				End If

				' To HTML.
				outFile = "Result.html"
				f.HtmlOptions.KeepCharScaleAndSpacing = False
				If f.ToHtml(outFile) = 0 Then
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
				End If
			Else
				Console.WriteLine("Error: {0}!", f.Exception.Message)
			End If
		End Sub
		Public Function PerformOCRNicomsoft(ByVal image() As Byte) As Byte()
			Dim NsOCR As NSOCRLib.NSOCRClass
			Dim CfgObj As Integer = 0
			Dim OcrObj As Integer = 0
			Dim ImgObj As Integer = 0
			Dim SvrObj As Integer = 0

			NsOCR = New NSOCRLib.NSOCRClass()
			NsOCR.Engine_SetLicenseKey("AB2A4DD5FF2A") 'required for licensed version only
			NsOCR.Engine_InitializeAdvanced(CfgObj, OcrObj, ImgObj)

			' Scale
			NsOCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "ImgAlizer/AutoScale", "0")
			NsOCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "ImgAlizer/ScaleFactor", "4.0")

			NsOCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "Languages/English", "1")

			Try
				Dim res As Integer = 0


				Dim imgArray As Array = Nothing
				Using ms As New MemoryStream(image)
					ms.Flush()
					imgArray = ms.ToArray()
				End Using
				res = NsOCR.Img_LoadFromMemory(ImgObj, imgArray, imgArray.Length)
				If res > TNSOCR.ERROR_FIRST Then
					Return Nothing
				End If

				NsOCR.Svr_Create(CfgObj, TNSOCR.SVR_FORMAT_PDF, SvrObj)
				NsOCR.Svr_NewDocument(SvrObj)

				res = NsOCR.Img_OCR(ImgObj, TNSOCR.OCRSTEP_FIRST, TNSOCR.OCRSTEP_LAST, TNSOCR.OCRFLAG_NONE)
				If res > TNSOCR.ERROR_FIRST Then
					Return Nothing
				End If




				res = NsOCR.Svr_AddPage(SvrObj, ImgObj, TNSOCR.FMT_EXACTCOPY)
				If res > TNSOCR.ERROR_FIRST Then
					Return Nothing
				End If

				Dim outPdf As Array = Nothing
				NsOCR.Svr_SaveToMemory(SvrObj, outPdf)

				Return CType(outPdf, Byte())
			Finally

			End Try
		End Function
	End Class
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			' To perform OCR we'll use free OCR library by Nicomsoft.
			' https://www.nicomsoft.com/products/ocr/download/
			' The library is freeware and can be used in commercial application.

			Dim converter As New PdfConverter()
			Dim inpFile As String = Path.GetFullPath("..\..\..\scan.pdf")
			converter.ConvertPdfToAllWithOCR(inpFile)

			' You are trying to compile this code sample and see the errors: 
			' NSOCRClass: Engine_SetLicenseKey
			' PdfFocus: OCROptions
			'
			' 1. Download Nicomsoft OCR SDK from: http://www.nicomsoft.com/files/ocr/free_NSOCR_v70_build885_full.exe
			' 2. Install it on your PC or server-side.
			' 3. Launch code sample again and enjoy! 

			' Please, read the full manual - How to use PDF Focus .Net with OCR (Readme.html)
			' IMPORTANT: PDF Focus .Net supports OCR since version 7.0
		End Sub
	End Class
End Namespace
