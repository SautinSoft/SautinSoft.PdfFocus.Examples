Imports System
Imports System.IO
Imports SautinSoft

Namespace Sample
    Friend Class Sample
        Shared Sub Main(ByVal args() As String)
            ' Here we'll show you two modes of converting PDF to HTML:
            ' PDF Focus .Net offers you the Fixed and Flowing modes by your choice.

            ' HTML-Fixed (default) is better to use for rendering, because it completely 
            ' repeats the PDF layout with the structure of pages. 
            ' The markup of such documents is very complex and have a lot of tags styled by (x,y) coords.

            ' HTML-Flowing is better for further processing by a human: editing and combining. 
            ' The markup of such documents is much simple inside and has the flowing structure. 
            ' It's very simple for understanding by a human. 
            ' But the resulting HTML document doesn't look exactly the same as input PDF pixel by pixel.

            Dim pdfFile As String = Path.GetFullPath("..\..\..\License.pdf")
            Dim htmlFileFixed As String = "Fixed.html"
            Dim htmlFileFlowing As String = "Flowing.html"
	                                ' Get your free 30-day key here: 
	                                ' https://sautinsoft.com/start-for-free/
		
            ' Convert PDF file to HTML (Fixed and Flowing) file
            Dim f As New SautinSoft.PdfFocus()

            ' How to store images: Inside HTML document as base64 images or as linked separate image files.
            f.HtmlOptions.IncludeImageInHtml = True

            f.OpenPdf(pdfFile)

            If f.PageCount > 0 Then
                ' The HTML-Fixed mode.
                f.HtmlOptions.Title = "Fixed"
                f.HtmlOptions.RenderMode = PdfFocus.CHtmlOptions.eHtmlRenderMode.Fixed
                If f.ToHtml(htmlFileFixed) = 0 Then
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(htmlFileFixed) With {.UseShellExecute = True})
                End If

                ' The HTML-Flowing mode.
                f.HtmlOptions.Title = "Flowing"
                f.HtmlOptions.RenderMode = PdfFocus.CHtmlOptions.eHtmlRenderMode.Flowing
                ' Switch off character scaling and spacing to prevent 
                ' adding of extra tags dividing the text by parts.
                f.HtmlOptions.KeepCharScaleAndSpacing = False

                If f.ToHtml(htmlFileFlowing) = 0 Then
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(htmlFileFlowing) With {.UseShellExecute = True})
                End If
            End If
        End Sub
    End Class
End Namespace
