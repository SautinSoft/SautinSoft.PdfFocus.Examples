Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        ConvertPdfToDocx()
        'ConvertPdfToRtf()
    End Sub

    Private Sub ConvertPdfToDocx()
        Dim pdfFile As String = Path.GetFullPath("..\..\..\text and graphics.pdf")
        Dim wordFile As String = "Result.docx"
                                ' Get your free 30-day key here: 
                                ' https://sautinsoft.com/start-for-free/
		
        Dim f As New SautinSoft.PdfFocus()

        f.OpenPdf(pdfFile)

        If f.PageCount > 0 Then
            f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx
            Dim result As Integer = f.ToWord(wordFile)

            ' Show the produced result.
            If result = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(wordFile) With {.UseShellExecute = True})
            End If
        End If
    End Sub
    Private Sub ConvertPdfToRtf()
        Dim pdfFile As String = Path.GetFullPath("..\..\..\text and graphics.pdf")
        Dim wordFile As String = "Result.rtf"

        Dim f As New SautinSoft.PdfFocus()

        'this property is necessary only for registered version
        'f.Serial = "XXXXXXXXXXX"

        f.OpenPdf(pdfFile)

        If f.PageCount > 0 Then
            f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Rtf
            Dim result As Integer = f.ToWord(wordFile)

            ' Show the produced result.
            If result = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(wordFile) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
