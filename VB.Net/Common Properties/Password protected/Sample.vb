Imports System
Imports System.IO

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			Dim pdfFile As String = Path.GetFullPath("..\..\..\Example.pdf")
			Dim wordFile As String = "Result.docx"
			' Activate your license here
			' SautinSoft.PdfFocus.SetLicense("1234567890")
			
			'Convert PDF file to Text file
			Dim f As New SautinSoft.PdfFocus()


			'Set a password for password-protected PDF documents. You need to set this option before "f.OpenPdf"
			f.Password = "123456789"

			f.OpenPdf(pdfFile)

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