Imports System.IO
Imports SautinSoft
Imports System

Namespace Example
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free 100-day key:
			' https://sautinsoft.com/start-for-free/

			' Apply the key here:
			' SautinSoft.PdfFocus.SetLicense("...");

			' Note: Please rebuild the project to restore Nuget packages.
			LoadScannedPdf()
		End Sub

		''' <summary>
		''' Load a scanned PDF document with help of Tesseract OCR (free OCR library) and save the result as DOCX document.
		''' </summary>
		Private Shared Sub LoadScannedPdf()
			' Here we'll load a scanned PDF document (perform OCR) containing a text on English, Russian and Vietnamese.
			' Next save the OCR result as a new DOCX document.

			' First steps:

			' 1. Download data files for English, Russian and Vietnamese languages.
			' Please download the files: eng.traineddata, rus.traineddata and vie.traineddata.
			' From here (good and fast): https://github.com/tesseract-ocr/tessdata_fast
			' or (best and slow): https://github.com/tesseract-ocr/tessdata_best

			' 2. Copy the files: eng.traineddata, rus.traineddata and vie.traineddata to
			' the folder "tessdata" in the Project root.

			' 3. Be sure that the folder "tessdata" also contains "pdf.ttf" file.

			' Let's start:
			Dim inpFile As String = Path.GetFullPath("..\..\..\scan.pdf")
			Dim outFile As String = "Result.docx"

			Dim f As New PdfFocus()
			f.OCROptions.Mode = PdfFocus.COCROptions.eOCRMode.AllImages

			f.OpenPdf(inpFile)
			Dim result As Boolean = False
			If f.PageCount > 0 Then
				result = f.ToWord(outFile) = 0
			End If
			' Open the result for demonstration purposes.
			If result Then
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			Else
				Console.WriteLine("Conversion failed!")
			End If
		End Sub
	End Class
End Namespace
