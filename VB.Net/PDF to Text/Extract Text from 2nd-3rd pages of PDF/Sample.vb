Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pdfFile As String = "..\Potato Beetle.pdf"
        Dim textFile As String = "Result.txt"

        'Extract Text from 2nd-3rd pages of PDF
        Dim f As New SautinSoft.PdfFocus()
        'this property is necessary only for registered version
        'f.Serial = "XXXXXXXXXXX"

        f.OpenPdf(pdfFile)

        If f.PageCount > 2 Then
            'Convert only pages 2 - 3 to Text
            Dim result As Integer = f.ToText(textFile, 2, 3)

            'Show Text document
            If result = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(textFile) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
