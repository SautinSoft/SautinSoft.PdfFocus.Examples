Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pdfFile As String = Path.GetFullPath("..\..\..\text and graphics.pdf")
        Dim wordFile As String = "Result.docx"
                                ' Get your free 100-day key here: 
                                ' https://sautinsoft.com/start-for-free/
		
        ' Convert a PDF file to a Word file
        Dim f As New SautinSoft.PdfFocus()
        f.OpenPdf(pdfFile)

        If f.PageCount > 0 Then
            ' You may choose output format between Docx and Rtf.
            f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx

            Dim result As Integer = f.ToWord(wordFile)

            ' Show the resulting Word document.
            If result = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(wordFile) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
