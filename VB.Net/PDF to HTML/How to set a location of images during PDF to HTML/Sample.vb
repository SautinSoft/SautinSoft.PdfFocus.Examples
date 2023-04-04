Imports System
Imports System.IO
Imports SautinSoft

Namespace Sample
    Friend Class Sample
        Shared Sub Main(ByVal args() As String)
            ' Here you will find how to keep images in the resulting HTML document.
            Dim pdfFile As String = Path.GetFullPath("..\..\..\simple text.pdf")
            Dim htmlFile As String = "Result.html"

            ' Convert PDF file to HTML file
            Dim f As New SautinSoft.PdfFocus()

            ' After purchasing the license, please insert your serial number here to activate the component:
            'f.Serial = "XXXXXXXXXXX"

            ' Way 1 (default): Images will be stored inside HTML document as base64, jpeg images.
            'f.HtmlOptions.IncludeImageInHtml = True
            ' Auto - the same image format as in the source PDF;
            ' 'Jpeg' to make the document size less; 
            ' 'PNG' to keep the highest quality, but the highest size too.
            'f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Auto


            ' Way 2: Images will be stored as JPG files in a special folder "{pdf name}_images".
            ' Images will have names "picture100.jpg", "picture101.jpg" .. "pictureN.jpg".
            ' Let's set the quality for jpeg to 95 percents.
            f.HtmlOptions.ImageFolder = Path.GetDirectoryName(htmlFile)
            ' 'Jpeg' to make the document size less; Or 'PNG' to keep the highest quality.
            f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Jpeg
            f.EmbeddedJpegQuality = 95
            f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile))
            f.HtmlOptions.ImageFileName = "picture"
            f.HtmlOptions.ImageNumStart = 100
            f.HtmlOptions.IncludeImageInHtml = False

            ' Way 3: Images will be stored as PNG files in the same directory with the HTML file.
            ' All images on each page will be combined in a single image.            '            
            'f.HtmlOptions.ImageFolder = Path.GetDirectoryName(htmlFile)
            ' 'Jpeg' to make the document size less; Or 'PNG' to keep the highest quality.
            'f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Png
            'f.HtmlOptions.ImageSubFolder = ""
            'f.HtmlOptions.IncludeImageInHtml = False

            f.OpenPdf(pdfFile)
            If f.PageCount > 0 Then
                Dim res As Integer = f.ToHtml(htmlFile)
                ' Open the result for demonstration purposes.
                If res = 0 Then
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(htmlFile) With {.UseShellExecute = True})
                End If
            End If
        End Sub
    End Class
End Namespace
