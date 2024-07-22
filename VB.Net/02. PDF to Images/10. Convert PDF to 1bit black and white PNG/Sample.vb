Imports System
Imports System.IO

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
								  ' Get your free 100-day key here:   
			 ' https://sautinsoft.com/start-for-free/

			'How to convert PDF to 1-bit black and white PNG
			Dim f As New SautinSoft.PdfFocus()

			Dim pdfPath As String = Path.GetFullPath("..\..\..\Potato Beetle.pdf")
			Dim imagePath As String = "Result.png"

			f.OpenPdf(pdfPath)

			If f.PageCount > 0 Then
				'save 1st page to png file, 200 dpi
				f.ImageOptions.ImageFormat = SautinSoft.PdfFocus.CImageOptions.ImageFormats.Png
				f.ImageOptions.Dpi = 200
				'Make "Black and White 1-bit indexed" image
				f.ImageOptions.ColorDepth = SautinSoft.PdfFocus.CImageOptions.eColorDepth.BlackWhite1bpp

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
