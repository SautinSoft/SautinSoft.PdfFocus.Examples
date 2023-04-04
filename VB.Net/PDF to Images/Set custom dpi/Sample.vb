Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pdfPath As String = Path.GetFullPath("..\..\..\Excel.pdf")
        Dim imagePath As String = "Result.png"

        Dim f As New SautinSoft.PdfFocus()
        'this property is necessary only for registered version
        'f.Serial = "XXXXXXXXXXX"
        f.OpenPdf(pdfPath)

        If f.PageCount > 0 Then
            'In most cases we recommend to set 200 dpi to decrease the image size and converting speed
            'Now set 300 dpi - very high quality
            f.ImageOptions.Dpi = 300

            'Convert 1st page from PDF to image file
            If f.ToImage(imagePath, 1) = 0 Then
                ' 0 - converting successfully                
                ' 2 - can't create output file, check the output path
                ' 3 - converting failed
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(imagePath) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
