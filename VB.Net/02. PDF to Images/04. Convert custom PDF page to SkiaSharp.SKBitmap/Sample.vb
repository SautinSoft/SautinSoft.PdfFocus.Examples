Imports SkiaSharp
Imports System
Imports System.IO

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			' Get your free 30-day key here:   
			' https://sautinsoft.com/start-for-free/

			'Convert custom PDF page to Image object
			Dim f As New SautinSoft.PdfFocus()


			Dim pdfPath As String = Path.GetFullPath("..\..\..\text and graphics.pdf")
			Dim imagePath As String = "Result.jpg"

			f.OpenPdf(pdfPath)

			If f.PageCount > 0 Then
				'Let's convert 1st page into System.Drawing.Image object, 120 dpi
				f.ImageOptions.Dpi = 120
				Dim img As SkiaSharp.SKBitmap = f.ToDrawingImage(1)

				'Save to file
				If img IsNot Nothing Then
					img.Encode(New FileStream(imagePath, FileMode.Create), SKEncodedImageFormat.Jpeg, 90)
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(imagePath) With {.UseShellExecute = True})
				End If
			End If
		End Sub
	End Class
End Namespace
