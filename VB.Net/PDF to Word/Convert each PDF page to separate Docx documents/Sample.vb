Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        ' Convert whole PDF document to separate Word documents.
        ' Each PDF page will be converted to a single Word document.

        ' Path to a PDF file.
        Dim pdfPath As String = Path.GetFullPath("..\simple text.pdf")

        ' Directory to store Word documents.
        Dim docxDir As String = Directory.GetCurrentDirectory()

        Dim f As New SautinSoft.PdfFocus()

        f.OpenPdf(pdfPath)

        ' Convert each PDF page to separate Word document.
        ' simple text - page 1.docx, simple text- page 2.docx ... simple text - page N.doc.
        For page As Integer = 1 To f.PageCount

            ' You may select between Docx and Rtf formats.
            f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx

            Dim docxBytes() As Byte = f.ToWord(page, page)

            Dim tempName As String = Path.GetFileNameWithoutExtension(pdfPath) & String.Format(" - page {0}.docx", page)
            Dim docxPath As String = Path.Combine(docxDir, tempName)
            File.WriteAllBytes(docxPath, docxBytes)

            ' Let's show first and last Word pages.
            If page = 1 OrElse page = f.PageCount Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(docxPath) With {.UseShellExecute = True})
            End If
        Next page
    End Sub
End Module
