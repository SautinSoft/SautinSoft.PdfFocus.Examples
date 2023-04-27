Option Infer On

Imports System.IO
Imports SautinSoft
Imports System

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
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
			Dim inpFile As String = "..\..\..\scan.pdf"
			Dim outFile As String = "Result.docx"

			Dim f As New PdfFocus()
			f.OCROptions.Mode = PdfFocus.COCROptions.eOCRMode.AllImages
			f.OCROptions.Method = AddressOf PerformOCRTesseract

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
		Public Shared Function PerformOCRTesseract(ByVal image() As Byte) As Byte()
			' Specify that Tesseract use three 3 languages: English, Russian and Vietnamese.
			'string tesseractLanguages = "rus+eng+vie";
			Dim tesseractLanguages As String = "eng"

			' A path to a folder which contains languages data files and font file "pdf.ttf".
			' Language data files can be found here:
			' Good and fast: https://github.com/tesseract-ocr/tessdata_fast
			' or
			' Best and slow: https://github.com/tesseract-ocr/tessdata_best
			' Also this folder must have write permissions.
			Dim tesseractData As String = Path.GetFullPath("..\..\tessdata\")

			' A path for a temporary PDF file (because Tesseract returns OCR result as PDF document)
			Dim tempFile As String = Path.Combine(tesseractData, Path.GetRandomFileName())

			Dim skipImages As Boolean = True

			Try
				Using renderer As Tesseract.IResultRenderer = Tesseract.PdfResultRenderer.CreatePdfRenderer(tempFile, tesseractData, skipImages)
					Using renderer.BeginDocument("Serachablepdf")
						Using engine As New Tesseract.TesseractEngine(tesseractData, tesseractLanguages, Tesseract.EngineMode.Default)
							engine.DefaultPageSegMode = Tesseract.PageSegMode.Auto
							Using msImg As New MemoryStream(image)
								Dim imgWithText As System.Drawing.Image = System.Drawing.Image.FromStream(msImg)
								Dim i As Integer = 0
								Do While i < imgWithText.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page)
									imgWithText.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, i)
									Using ms As New MemoryStream()
										imgWithText.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
										Dim imgBytes() As Byte = ms.ToArray()
										Using img As Tesseract.Pix = Tesseract.Pix.LoadFromMemory(imgBytes)
											Using page = engine.Process(img, "Serachablepdf")
												renderer.AddPage(page)
											End Using
										End Using
									End Using
									i += 1
								Loop
							End Using
						End Using
					End Using
				End Using

				Return File.ReadAllBytes(tempFile & ".pdf")
			Catch e As Exception
				Console.WriteLine()
				Console.WriteLine("Please be sure that you have Language data files (*.traineddata) in your folder ""tessdata""")
				Console.WriteLine("The Language data files can be download from here: https://github.com/tesseract-ocr/tessdata_fast")
				Console.ReadKey()
				Throw New Exception("Error Tesseract: " & e.Message)
			Finally
				If File.Exists(tempFile & ".pdf") Then
					File.Delete(tempFile & ".pdf")
				End If
			End Try
		End Function
	End Class
End Namespace