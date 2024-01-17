Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pdfPath As String = Path.GetFullPath("..\..\..\Excel.pdf")
        Dim imagePath As String = "Result.gif"
                                ' Get your free 30-day key here: 
                                ' https://sautinsoft.com/start-for-free/
		
        Dim f As New SautinSoft.PdfFocus()

        f.OpenPdf(pdfPath)

        If f.PageCount > 0 Then
            'Set "GIF" format for image
            f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Gif

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
