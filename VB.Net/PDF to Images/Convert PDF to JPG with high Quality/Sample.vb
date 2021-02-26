Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        ' Convert PDF to JPG with high Quality
        Dim f As New SautinSoft.PdfFocus()

        ' This property is necessary only for registered version
        ' f.Serial = "XXXXXXXXXXX"
        Dim pdfFile As String = "..\simple text.pdf"
        Dim jpegDir As String = (New DirectoryInfo(Directory.GetCurrentDirectory())).CreateSubdirectory("Result").FullName

        f.OpenPdf(pdfFile)

        If f.PageCount > 0 Then
            ' Set image properties: Jpeg, 200 dpi
            f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
            f.ImageOptions.Dpi = 200

            ' Set 95 as JPEG quality
            f.ImageOptions.JpegQuality = 95

            'Save all PDF pages to image folder, each file will have name Page 1.jpg, Page 2.jpg, Page N.jpg
            For page As Integer = 1 To f.PageCount
                Dim jpegFile As String = Path.Combine(jpegDir, String.Format("Page {0}.jpg", page))

                ' 0 - converted successfully                
                ' 2 - can't create output file, check the output path
                ' 3 - conversion failed
                Dim result As Integer = f.ToImage(jpegFile, page)

                ' Show only 1st page
                If page = 1 AndAlso result = 0 Then
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(jpegFile) With {.UseShellExecute = True})
                End If
            Next page
        End If
    End Sub
End Module
