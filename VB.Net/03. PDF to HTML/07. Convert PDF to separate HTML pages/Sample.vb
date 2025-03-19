Imports System
Imports System.IO

Namespace Sample
    Friend Class Sample
        Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free key:
			' https://sautinsoft.com/start-for-free/

			' Apply the key here
			' SautinSoft.PdfFocus.SetLicense("...");

            ' Convert PDF to separate HTMLs.
            ' Each PDF page will be converted to a single HTML document.
            Dim pdfFile As String = Path.GetFullPath("..\..\..\simple text.pdf")
            Dim htmlDir As New DirectoryInfo("htmls")
            If Not htmlDir.Exists Then
                htmlDir.Create()
            End If
            Dim f As New SautinSoft.PdfFocus()

            f.HtmlOptions.IncludeImageInHtml = False

            ' Path (must exist) to a directory to store images after converting.             
            f.HtmlOptions.ImageFolder = htmlDir.FullName

            f.OpenPdf(pdfFile)

            If f.PageCount > 0 Then
                ' Convert each PDF page to separate HTML document.
                ' simple text.html, simple text.html ... simple text.html.
                For page As Integer = 1 To f.PageCount
                    f.HtmlOptions.Title = $"Page {page}"
                    f.HtmlOptions.ImageSubFolder = String.Format("page{0}_images", page)
                    Dim htmlString As String = f.ToHtml(page, page)

                    ' Save htmlString to file
                    Dim htmlFile As String = Path.Combine(htmlDir.FullName, $"Page{page}.html")
                    File.WriteAllText(htmlFile, htmlString)

                    ' Let's open only 1st and last pages.
                    If page = 1 OrElse page = f.PageCount Then
                        ' Open the result for demonstration purposes.
                        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(htmlFile) With {.UseShellExecute = True})
                    End If
                Next page
            End If
        End Sub
    End Class
End Namespace
