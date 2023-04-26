Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
		Dim inpFile As String = Path.GetFullPath("..\..\..\Potato Beetle.pdf")
		Dim outFile As String = "Result.rtf"
		' Activate your license here
		' SautinSoft.PdfFocus.SetLicense("1234567890")
		
		Dim f As New SautinSoft.PdfFocus()
		f.OpenPdf(inpFile)

		If f.PageCount > 0 Then
			' You may set an output format to docx or rtf.
			f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Rtf

			' Specify to convert these pages: 2 - 4  and 6.

			' Way 1:
			f.RenderPagesString = "2-4, 6"

			' Way 2 (do the same as Way 1):
			f.RenderPages = New Integer()() {
					New Integer() {2, 4},
					New Integer() {6, 6}
				}

			Dim result As Integer = f.ToWord(outFile)

			' Open the result.
			If result = 0 Then
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			End If
		End If
	End Sub
End Module
