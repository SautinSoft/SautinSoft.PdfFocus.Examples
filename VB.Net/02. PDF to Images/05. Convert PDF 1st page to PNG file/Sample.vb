Imports System
Imports System.IO

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
								  ' Get your free 100-day key here:   
			 ' https://sautinsoft.com/start-for-free/          

		   ' Convert PDF 1st page to PNG file.
			Dim f As New SautinSoft.PdfFocus()

			Dim pdfPath As String = Path.GetFullPath("..\..\..\Excel.pdf")
			Dim imagePath As String = "Result.png"

			f.OpenPdf(pdfPath)

			If f.PageCount > 0 Then
				'save 1st page to png file, 120 dpi
				f.ImageOptions.ImageFormat = SautinSoft.PdfFocus.CImageOptions.ImageFormats.Png
				f.ImageOptions.Dpi = 120
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
