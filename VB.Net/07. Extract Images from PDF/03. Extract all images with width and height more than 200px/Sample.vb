Imports System
Imports System.IO
Imports System.Collections.Generic
Imports SautinSoft

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			  ' Get your free 30-day key here:   
			 ' https://sautinsoft.com/start-for-free/

			' Extract all images with width and height more than 200px
			Dim f As New SautinSoft.PdfFocus()

			Dim pdfFile As String = Path.GetFullPath("..\..\..\simple text.pdf")
			Dim imageDir As String = (New DirectoryInfo(Directory.GetCurrentDirectory())).CreateSubdirectory("images").FullName

			Dim pdfImages As List(Of PdfFocus.PdfImage) = Nothing

			f.OpenPdf(pdfFile)

			If f.PageCount > 0 Then
				' Specify to extract only images which have width and height
				' more than 200px
				f.ImageExtractionOptions.MinSize = New SkiaSharp.SKSize(200, 200)

				pdfImages = f.ExtractImages()

				' Show all extracted images.
				If pdfImages IsNot Nothing AndAlso pdfImages.Count > 0 Then

					For i As Integer = 0 To pdfImages.Count - 1
						Dim imageFile As String = Path.Combine(imageDir, String.Format("img{0}.png", i + 1))
						pdfImages(i).Picture.Encode(New FileStream(imageFile, FileMode.Create), SkiaSharp.SKEncodedImageFormat.Png, 100)
					Next i
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(imageDir) With {.UseShellExecute = True})
				End If
			End If
		End Sub
	End Class
End Namespace
