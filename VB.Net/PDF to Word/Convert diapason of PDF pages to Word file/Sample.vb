Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pathToPdf As String = "..\Potato Beetle.pdf"
        Dim pathToWord As String = "Result.rtf"

        ' Convert diapason of PDF pages to a Word file.
        Dim f As New SautinSoft.PdfFocus()
        ' this property is necessary only for registered version.
        'f.Serial = "XXXXXXXXXXX"

        f.OpenPdf(pathToPdf)

        If f.PageCount > 0 Then
            ' You may set an output format to docx or rtf.
            f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Rtf

            ' Convert only pages 2 - 4 to Word.
            Dim result As Integer = f.ToWord(pathToWord, 2, 4)

            ' Show Word document
            If result = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pathToWord) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
