Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
		' Before starting, we recommend to get a free key:
		' https://sautinsoft.com/start-for-free/

		' Apply the key here
		' SautinSoft.PdfFocus.SetLicense("...");

        Dim pdfFile As String = Path.GetFullPath("..\..\..\Potato Beetle.pdf")
        Dim textFile As String = "Result.txt"
		
        'Convert PDF file to Text file
        Dim f As New SautinSoft.PdfFocus()

        f.OpenPdf(pdfFile)

        If f.PageCount > 0 Then
            Dim result As Integer = f.ToText(textFile)

            'Show Text document
            If result = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(textFile) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
