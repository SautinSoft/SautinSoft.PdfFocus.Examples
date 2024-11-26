Imports System
Imports System.IO
Imports SautinSoft

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			Dim pdfFile As String = "..\..\..\simple text.pdf"
			Dim htmlFile As String = Path.ChangeExtension(pdfFile, ".html")

			' Convert PDF file to HTML file
			Dim f As New SautinSoft.PdfFocus()

			' Let's change all text to Verdana 8pt.
			f.HtmlOptions.SingleFontFamily = "Verdana"
			f.HtmlOptions.SingleFontSize = 8

			' After purchasing the license, please insert your serial number here to activate the component:
			'f.Serial = "XXXXXXXXXXX";

			f.OpenPdf(pdfFile)

			If f.PageCount > 0 Then
				Dim from As Integer = 1
				Dim [to] As Integer = If(3 > f.PageCount, f.PageCount, 3)

				Dim result As Integer = f.ToHtml(htmlFile, from, [to])

				' Show resulted HTML document in a browser.
				If result = 0 Then
					System.Diagnostics.Process.Start(htmlFile)
				End If
			End If
		End Sub
	End Class
End Namespace
