Imports System
Imports System.IO
Imports System.Collections

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)

			Dim pdfPath As String = Path.GetFullPath("..\..\..\Excel.pdf")
			Dim imagePath As String = "Result.png"
			' Get your free 30-day key here:   
			' https://sautinsoft.com/start-for-free/

			Dim f As New SautinSoft.PdfFocus()

			f.OpenPdf(pdfPath)

			If f.PageCount > 0 Then
				'Set color depth: Grayscale 8 bit
				f.ImageOptions.ColorDepth = SautinSoft.PdfFocus.CImageOptions.eColorDepth.Grayscale8bpp

				'Convert 1st page from PDF to image file
				If f.ToImage(imagePath, 1) = 0 Then
					' 0 - converting successfully                
					' 2 - can't create output file, check the output path
					' 3 - converting failed
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(imagePath) With {.UseShellExecute = True})
				End If
			End If
		End Sub
	End Class
End Namespace
