Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        ConvertPdfToDocxBytes()
        'ConvertPdfToRtfStream()
    End Sub
    Private Sub ConvertPdfToDocxBytes()
        Dim pdfFile As String = Path.GetFullPath("..\..\..\simple text.pdf")

        ' Assume that we already have a PDF document as array of bytes.
        Dim pdf() As Byte = File.ReadAllBytes(pdfFile)
        Dim docx() As Byte = Nothing
		' Activate your license here
		' SautinSoft.PdfFocus.SetLicense("1234567890")
		
        ' Convert PDF to word in memory
        Dim f As New SautinSoft.PdfFocus()


        f.OpenPdf(pdf)

        If f.PageCount > 0 Then
            ' Convert pdf to word in memory.
            docx = f.ToWord()

            ' Save word document to a file only for demonstration purposes.
            If docx IsNot Nothing Then
                '3. Save to DOCX document to a file for demonstration purposes.
                Dim wordFile As String = "Result.docx"
                File.WriteAllBytes(wordFile, docx)
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(wordFile) With {.UseShellExecute = True})
            End If
        End If
    End Sub
    Private Sub ConvertPdfToRtfStream()
        Dim pdfFile As String = Path.GetFullPath("..\..\..\simple text.pdf")
        Dim rtfStream As New MemoryStream()
        ' Convert PDF to word in memory
        Dim f As New SautinSoft.PdfFocus()
        'this property is necessary only for registered version
        'f.Serial = "XXXXXXXXXXX"

        ' Assume that we already have a PDF document as stream.
        Using pdfStream As New FileStream(pdfFile, FileMode.Open, FileAccess.Read)
            f.OpenPdf(pdfStream)

            If f.PageCount > 0 Then
                f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Rtf
                Dim res As Integer = f.ToWord(rtfStream)

                ' Save rtfStream to a file for demonstration purposes.
                If res = 0 Then
                    Dim rtfFile As String = "Result.rtf"
                    File.WriteAllBytes(rtfFile, rtfStream.ToArray())
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(rtfFile) With {.UseShellExecute = True})
                End If
            End If
        End Using
    End Sub
End Module
