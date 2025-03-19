Imports System
Imports System.IO

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free key:
			' https://sautinsoft.com/start-for-free/

			' Apply the key here:
			' SautinSoft.PdfFocus.SetLicense("...");

		   ' Convert PDF 1st page to PNG file.
			Dim f As New SautinSoft.PdfFocus()

			Dim pdfPath As String = Path.GetFullPath("..\..\..\Excel.pdf")
			Dim imagePath As String = "Result.png"

			f.OpenPdf(pdfPath)

			If f.PageCount > 0 Then
				'save 1st page to png file, 300 dpi
				f.ImageOptions.ImageFormat = SautinSoft.PdfFocus.CImageOptions.ImageFormats.Png
				f.ImageOptions.Dpi = 300
				f.ImageOptions.SelectedPages = New Integer() { 0 }

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
