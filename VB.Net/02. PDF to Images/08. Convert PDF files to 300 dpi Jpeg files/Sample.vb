Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free 100-day key:
			' https://sautinsoft.com/start-for-free/

			' Apply the key here
			' SautinSoft.PdfFocus.SetLicense("...");

			Dim f As New SautinSoft.PdfFocus()

			Dim pdfFiles() As String = Directory.GetFiles("..\..\..\", "*.pdf")
			Dim folderWithJPGs As String = (New DirectoryInfo(Directory.GetCurrentDirectory())).CreateSubdirectory("Result").FullName

			For Each pdffile As String In pdfFiles
				f.OpenPdf(pdffile)

				If f.PageCount > 0 Then
					'Set image format: Jpeg, 300 dpi
					f.ImageOptions.Dpi = 300
					f.ImageOptions.ImageFormat = SautinSoft.PdfFocus.CImageOptions.ImageFormats.Jpeg

					'Save all pages to jpeg files with 300 dpi
					f.ToImage(folderWithJPGs, Path.GetFileNameWithoutExtension(pdffile))
				End If
				f.ClosePdf()
			Next pdffile
			'Show folder with jpegs
			System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(folderWithJPGs) With {.UseShellExecute = True})
		End Sub
	End Class
End Namespace
