Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim remotePdfUrl As String = "https://www.sautinsoft.net/samples/simple%20text.pdf"
        Dim pathToWord As String = "Result.docx"

        'Convert URL-PDF from Internet to a Word file
        Dim f As New SautinSoft.PdfFocus()
        'this property is necessary only for registered version
        'f.Serial = "XXXXXXXXXXX"

        Dim uri As New Uri(remotePdfUrl)

        f.OpenPdf(uri)

        If f.PageCount > 0 Then
            Dim result As Integer = f.ToWord(pathToWord)

            'Show the resulting Word document
            If result = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pathToWord) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
