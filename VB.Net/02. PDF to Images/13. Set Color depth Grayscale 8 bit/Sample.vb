Imports System
Imports System.IO
Imports System.Collections

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free 100-day key:
			' https://sautinsoft.com/start-for-free/

			' Apply the key here:
			' SautinSoft.PdfFocus.SetLicense("...");

			Dim pdfPath As String = Path.GetFullPath("..\..\..\Excel.pdf")
			Dim imagePath As String = "Result.png"

			Dim f As New SautinSoft.PdfFocus()

			f.OpenPdf(pdfPath)

			If f.PageCount > 0 Then
				'Set color depth: Grayscale 8 bit
				f.ImageOptions.ColorDepth = SautinSoft.PdfFocus.CImageOptions.eColorDepth.Grayscale8bpp

				'Convert 1st page from PDF to image file
				f.ImageOptions.PageIndex = 0

				If f.ToImage(imagePath) = 0 Then
					' 0 - converting successfully                
					' 2 - can't create output file, check the output path
					' 3 - converting failed
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(imagePath) With {.UseShellExecute = True})
				End If
			End If
		End Sub
	End Class
End Namespace
