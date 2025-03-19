Imports SkiaSharp
Imports System
Imports System.IO

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free key:
			' https://sautinsoft.com/start-for-free/

			' Apply the key here:
			' SautinSoft.PdfFocus.SetLicense("...");

			'Convert custom PDF page to Image object
			Dim f As New SautinSoft.PdfFocus()


			Dim pdfPath As String = Path.GetFullPath("..\..\..\parkmap.pdf")
			Dim imagePath As String = "Result.jpg"

			f.OpenPdf(pdfPath)

			If f.PageCount > 0 Then
				'Let's convert 1st page into SKBitmap object, 300 dpi
				f.ImageOptions.Dpi = 300
				f.ImageOptions.SelectedPages = New Integer() { 0 }
				Dim img As SkiaSharp.SKBitmap = f.ToSKBitmap()

				'Save to file
				If img IsNot Nothing Then
					img.Encode(New FileStream(imagePath, FileMode.Create), SKEncodedImageFormat.Jpeg, 90)
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(imagePath) With {.UseShellExecute = True})
				End If
			End If
		End Sub
	End Class
End Namespace
