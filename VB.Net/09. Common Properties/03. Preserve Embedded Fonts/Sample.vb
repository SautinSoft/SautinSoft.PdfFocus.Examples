Imports System
Imports System.IO

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free key:
			' https://sautinsoft.com/start-for-free/

			' Apply the key here
			' SautinSoft.PdfFocus.SetLicense("...");

			Dim pdfFile As String = Path.GetFullPath("..\..\..\text and graphics.pdf")
			Dim wordFile As String = "Result.docx"
			
			'Convert PDF file to Text file
			Dim f As New SautinSoft.PdfFocus()

			f.OpenPdf(pdfFile)

			'This property indicating whether to load embedded fonts from PDF and store them in document or skip them and use similar. Default value: Auto.
			f.PreserveEmbeddedFonts = SautinSoft.PdfFocus.ePropertyState.Enabled

			If f.PageCount > 0 Then
				Dim result As Integer = f.ToWord(wordFile)

				'Show Text document
				If result = 0 Then
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(wordFile) With {.UseShellExecute = True})
				End If
			End If
		End Sub
	End Class
End Namespace
