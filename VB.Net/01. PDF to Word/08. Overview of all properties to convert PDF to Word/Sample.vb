Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pdfFile As String = Path.GetFullPath("..\..\..\simple text.pdf")
        Dim wordFile As String = "Result.docx"
                                ' Get your free 100-day key here: 
                                ' https://sautinsoft.com/start-for-free/
		
        ' In this sample you will find a short overview of all properties of WordOptions.
        Dim f As New SautinSoft.PdfFocus()

        f.OpenPdf(pdfFile)

        If f.PageCount > 0 Then
            ' You may choose output format between Docx and Rtf.
            f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx

            ' As you may know all text in PDF positioned by (x,y) coordinates.
            ' In a Word document all text is placed inside paragraphs.
            ' Flowing     - The most useful and common type of Word document for editing. The resulting Word document looks as if it was typed by human.
            '               The document layout created without using text boxes.
            '
            ' Exact       - The most precise and fastest mode. The resulting Word document looks exact as PDF pixel by pixel (x,y).
            '               The document layout created by using text boxes, this gives a monumental accuracy for  PDF to Word conversion.
            '
            ' Continuous  - The document layout created by using text boxes grouped in blocks.
            '               A golden mean between Flowing and Exact.
            f.WordOptions.RenderMode = SautinSoft.PdfFocus.CWordOptions.eRenderMode.Flowing

            ' As you may know PDF format doesn't have such concept as tables.
            ' It's true, all tables in PDF represented using graphical lines.
            ' true - parse all graphic lines to detect and recreate tables.
            ' false - leave all graphic lines as is.
            f.WordOptions.DetectTables = True

            ' As you may know PDF contains embedded fonts with own symbol widths.
            ' But the resulting Word document will have fonts installed at your system.
            ' Sometimes their have different symbol width.
            ' true - scale width of symbols to make it the same as in PDF.
            ' false - don't scale width of symbols and use width of installed fonts.
            f.WordOptions.KeepCharScaleAndSpacing = False

            ' Sometimes a PDF document can contain a picture with a scanned text. 
            ' Besides of this, this document can contain invisible text over this picture.
            ' In case you need to get only that text and skip picture, you may set 'PreserveImages' to false and
            ' set this property to true:
            f.WordOptions.ShowInvisibleText = True
            'f.PreserveImages = false;

            Dim result As Integer = f.ToWord(wordFile)

            ' Show the resulting Word document.
            If result = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(wordFile) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
