Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pdfFile As String = Path.GetFullPath("..\..\..\Potato Beetle.pdf")
        Dim textFile As String = "Result.txt"
                                ' Get your free 30-day key here: 
                                ' https://sautinsoft.com/start-for-free/
		
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
