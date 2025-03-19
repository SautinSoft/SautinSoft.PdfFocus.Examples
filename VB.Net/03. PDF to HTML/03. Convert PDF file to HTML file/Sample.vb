Imports System
Imports System.IO
Imports SautinSoft

Namespace Sample
    Friend Class Sample
        Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free key:
			' https://sautinsoft.com/start-for-free/

			' Apply the key here
			' SautinSoft.PdfFocus.SetLicense("...");

            Dim pdfFile As String = Path.GetFullPath("..\..\..\simple text.pdf")
            Dim htmlFile As String = "Result.html"
		
            ' Convert PDF file to HTML file
            Dim f As New SautinSoft.PdfFocus()

            ' Path (must exist) to a directory to store images after converting. Notice also to the property "ImageSubFolder".
            f.HtmlOptions.ImageFolder = Path.GetDirectoryName(htmlFile)

            ' A folder (will be created by the component) without any drive letters, only the folder as "myfolder".
            f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile))

            ' Auto - the same image format as in the source PDF;
            ' 'Jpeg' to make the document size less; 
            ' 'PNG' to keep the highest quality, but the highest size too.
            f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Auto

            ' How to store images: Inside HTML document as base64 images or as linked separate image files.
            f.HtmlOptions.IncludeImageInHtml = False

            ' Set <title>...</title>
            f.HtmlOptions.Title = String.Format("This HTML was converted from {0}.", Path.GetFileName(pdfFile))

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
