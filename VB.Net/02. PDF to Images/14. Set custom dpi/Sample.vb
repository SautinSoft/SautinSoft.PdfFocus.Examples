Imports System
Imports System.IO
Imports System.Collections

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)

			Dim pdfPath As String = Path.GetFullPath("..\..\..\Excel.pdf")
			Dim imagePath As String = "Result.png"
								  ' Get your free 100-day key here:   
			 ' https://sautinsoft.com/start-for-free/

			Dim f As New SautinSoft.PdfFocus()

			f.OpenPdf(pdfPath)

			If f.PageCount > 0 Then
				'In most cases we recommend to set 200 dpi to decrease the image size and converting speed
				'Now set 300 dpi - very high quality
				f.ImageOptions.Dpi = 300

				'Convert 1st page from PDF to image file
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
