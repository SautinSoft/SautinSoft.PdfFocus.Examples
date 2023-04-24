Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        'Convert PDF files to 300-dpi JPG files
        Dim f As New SautinSoft.PdfFocus()
        'this property is necessary only for registered version
        'f.Serial = "XXXXXXXXXXX"

        Dim pdfFiles() As String = Directory.GetFiles("..\..\..\", "*.pdf")
        Dim folderWithJPGs As String = (New DirectoryInfo(Directory.GetCurrentDirectory())).CreateSubdirectory("Result").FullName

        For Each pdffile As String In pdfFiles
            f.OpenPdf(pdffile)

            If f.PageCount > 0 Then
                'Set image format: JPG, 300 dpi
                f.ImageOptions.Dpi = 300
                f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg

                'Save all pages to jpg files with 300 dpi
                f.ToImage(folderWithJPGs, Path.GetFileNameWithoutExtension(pdffile))
            End If
            f.ClosePdf()
        Next pdffile
        'Show folder with jpegs
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(folderWithJPGs) With {.UseShellExecute = True})
    End Sub
End Module
