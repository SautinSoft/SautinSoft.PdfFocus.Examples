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

        Dim remotePdfUrl As String = "https://sautinsoft.com/products/pdf-focus/help/net/developer-guide/data/files/parkmap.pdf"
        Dim pathToWord As String = "Result.docx"

        'Convert URL-PDF from Internet to a Word file
        Dim f As New SautinSoft.PdfFocus()

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
