Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports System.Drawing
Imports SautinSoft

Module Sample

    Sub Main()
                                ' Get your free 30-day key here: 
                                ' https://sautinsoft.com/start-for-free/

        'Convert PDF into specified Image height & width
        Dim f As New SautinSoft.PdfFocus()

        ' Set initial values
        Dim pdfPath As String = Path.GetFullPath("..\..\..\Potato Beetle.pdf")
        Dim imageFolder As String = (New DirectoryInfo(Directory.GetCurrentDirectory())).CreateSubdirectory("Result").FullName
        Dim width As Integer = 1600 ' Width in Px
        Dim height As Integer = 1900 ' Height in Px

        'Set image options
        f.ImageOptions.ImageFormat = ImageFormat.Png
        f.ImageOptions.Resize(New Size With {.Width = width, .Height = height}, False)

        f.OpenPdf(pdfPath)
        If f.PageCount > 0 Then
            ' Convert all pages to PNG images
            f.ToImage(imageFolder, "Page")

            'Show image
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(imageFolder) With {.UseShellExecute = True})
        End If
    End Sub
End Module
