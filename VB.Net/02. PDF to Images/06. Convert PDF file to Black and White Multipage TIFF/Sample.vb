Imports System
Imports System.IO

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free key:
			' https://sautinsoft.com/start-for-free/

			' Apply the key here:
			' SautinSoft.PdfFocus.SetLicense("...");

			' Convert PDF file to BlackAndWhite Multipage-TIFF.
			Dim f As New SautinSoft.PdfFocus()

			Dim pdfPath As String = Path.GetFullPath("..\..\..\simple text.pdf")
			Dim tiffPath As String = "Result.tiff"

			f.OpenPdf(pdfPath)

			If f.PageCount > 0 Then
				f.ImageOptions.ImageFormat = SautinSoft.PdfFocus.CImageOptions.ImageFormats.Tif
				f.ImageOptions.Dpi = 300
				f.ImageOptions.ColorDepth = SautinSoft.PdfFocus.CImageOptions.eColorDepth.BlackWhite1bpp

				If f.ToImage(tiffPath) = 0 Then
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(tiffPath) With {.UseShellExecute = True})
				End If
			End If
		End Sub
	End Class
End Namespace
