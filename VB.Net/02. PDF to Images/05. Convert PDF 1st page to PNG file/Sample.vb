Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
                                ' Get your free 30-day key here: 
                                ' https://sautinsoft.com/start-for-free/
		
        'Convert PDF 1st page to PNG file
        Dim f As New SautinSoft.PdfFocus()
        Dim pdfPath As String = Path.GetFullPath("..\..\..\Excel.pdf")
        Dim imagePath As String = "Result.png"

        f.OpenPdf(pdfPath)

        If f.PageCount > 0 Then
            'save 1st page to png file, 120 dpi
            f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
            f.ImageOptions.Dpi = 120
            If f.ToImage(imagePath, 1) = 0 Then
                ' 0 - converting successfully                
                ' 2 - can't create output file, check the output path
                ' 3 - converting failed
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(imagePath) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
