Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
								  ' Get your free 30-day key here:   
			 ' https://sautinsoft.com/start-for-free/

			' Convert PDF file to BlackAndWhite Multipage-TIFF.
			Dim f As New SautinSoft.PdfFocus()

			Dim pdfPath As String = Path.GetFullPath("..\..\..\simple text.pdf")
			Dim tiffPath As String = "Result.tiff"

			f.OpenPdf(pdfPath)

			If f.PageCount > 0 Then
				f.ImageOptions.Dpi = 200
				f.ImageOptions.ColorDepth = SautinSoft.PdfFocus.CImageOptions.eColorDepth.BlackWhite1bpp
				' EncoderValue.CompressionCCITT4 - also makes image black&white 1 bit
				f.ImageOptions.TIFFCompressionType = SautinSoft.PdfFocus.eTIFFCompressionType.CCITTFAX4

				If f.ToMultipageTiff(tiffPath) = 0 Then
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(tiffPath) With {.UseShellExecute = True})
				End If
			End If
		End Sub
	End Class
End Namespace