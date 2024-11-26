Imports System
Imports System.IO

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			' Convert PDF file (specified pages) to Multipage TIFF.
			Dim f As New SautinSoft.PdfFocus()

			' This property is necessary only for registered version.
			'f.Serial = "XXXXXXXXXXX";

			Dim pdfPath As String = "..\..\..\simple text.pdf"
			Dim tiffPath As String = "..\..\..\result.tif"

			f.OpenPdf(pdfPath)

			' Let's set up the page indexes to convert the 2nd, 3rd, 4th pages.
			f.ImageOptions.SelectedPages = New Integer() { 1, 2, 3 }
			f.ImageOptions.ImageFormat = SautinSoft.PdfFocus.CImageOptions.ImageFormats.Tif

			f.ToImage(tiffPath)

			' Open the result for demonstration purposes.
			System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(tiffPath) With {.UseShellExecute = True})
		End Sub
	End Class
End Namespace
