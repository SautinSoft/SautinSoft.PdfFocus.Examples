Imports System
Imports System.IO
Imports SkiaSharp

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free key:
			' https://sautinsoft.com/start-for-free/

			' Apply the key here:
			' SautinSoft.PdfFocus.SetLicense("...");

			'Convert PDF into specified Image height & width
			Dim f As New SautinSoft.PdfFocus()

			' Set initial values
			Dim pdfPath As String = Path.GetFullPath("..\..\..\Potato Beetle.pdf")
			Dim imageFolder As String = (New DirectoryInfo(Directory.GetCurrentDirectory())).CreateSubdirectory("Result").FullName
			Dim width As Integer = 1600 ' Width in Px
			Dim height As Integer = 1900 ' Height in Px

			'Set image options
			f.ImageOptions.ImageFormat = SautinSoft.PdfFocus.CImageOptions.ImageFormats.Png
			f.ImageOptions.Resize(New SKSize With {
				.Width = width,
				.Height = height
			}, False)

			f.OpenPdf(pdfPath)
			If f.PageCount > 0 Then
				' Convert all pages to PNG images
				f.ToImages(imageFolder, "Page")

				'Show image
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(imageFolder) With {.UseShellExecute = True})
			End If
		End Sub
	End Class
End Namespace
