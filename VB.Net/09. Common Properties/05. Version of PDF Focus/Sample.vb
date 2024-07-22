Imports System
Imports System.IO

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			Dim pdfFile As String = Path.GetFullPath("..\..\..\text and graphics.pdf")
			Dim wordFile As String = "Result.docx"
	                                ' Get your free 100-day key here: 
	                                ' https://sautinsoft.com/start-for-free/
			
			'Convert PDF file to Text file
			Dim f As New SautinSoft.PdfFocus()

			f.OpenPdf(pdfFile)

			If f.PageCount > 0 Then
				Dim result As Integer = f.ToWord(wordFile)

				'Show Text document
				If result = 0 Then
					Console.WriteLine("You are using the PDF Focus .Net v:")
					Console.WriteLine(f.Version)
					Console.ReadKey()
				End If
			End If
		End Sub
	End Class
End Namespace