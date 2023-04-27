Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
		' Activate your license here
		' SautinSoft.PdfFocus.SetLicense("1234567890")
		
        'Convert custom PDF page to Image object
        Dim f As New SautinSoft.PdfFocus()

        Dim pdfPath As String = Path.GetFullPath("..\..\..\Excel.pdf")
        Dim imagePath As String = "Result.png"

        f.OpenPdf(pdfPath)

        If f.PageCount > 0 Then
            'Let's convert 1st page into System.Drawing.Image object, 120 dpi
            f.ImageOptions.Dpi = 120
            Dim img As System.Drawing.Image = f.ToDrawingImage(1)

            'Save to file
            If img IsNot Nothing Then
                img.Save(imagePath)
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(imagePath) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
