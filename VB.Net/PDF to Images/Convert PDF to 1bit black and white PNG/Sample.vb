Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
		' Activate your license here
		' SautinSoft.PdfFocus.SetLicense("1234567890")

        'How to convert PDF to 1-bit black and white PNG
        Dim f As New SautinSoft.PdfFocus()

        Dim pdfPath As String = Path.GetFullPath("..\..\..\Potato Beetle.pdf")
        Dim imagePath As String = "Result.png"

        f.OpenPdf(pdfPath)

        If f.PageCount > 0 Then
            'save 1st page to png file, 200 dpi
            f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
            f.ImageOptions.Dpi = 200
            'Make "Black and White 1-bit indexed" image
            f.ImageOptions.ColorDepth = SautinSoft.PdfFocus.CImageOptions.eColorDepth.BlackWhite1bpp

            If f.ToImage(imagePath, 1) = 0 Then
                ' 0 - converting successfully                
                ' 2 - can't create output file, check the output path
                ' 3 - converting failed
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(imagePath) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module