Imports System
Imports System.IO

Namespace Sample
    Friend Class Sample
        Shared Sub Main(ByVal args() As String)
            ConvertPdfBytesToHtml()
            'ConvertPdfStreamToHtml()
        End Sub

        Private Shared Sub ConvertPdfBytesToHtml()
            ' We need files only for demonstration purposes.
            ' The whole conversion process will be done in memory.
            Dim pdfFile As String = Path.GetFullPath("..\..\..\simple text.pdf")
            Dim htmlFile As String = "Result.html"

            ' Convert PDF to HTML in memory
            Dim f As New SautinSoft.PdfFocus()

            ' This property is necessary only for licensed version.
            'f.Serial = "XXXXXXXXXXX"

            ' Let's force the component to store images inside HTML document
            ' using base-64 encoding.
            ' Thus the component will not use HDD.
            f.HtmlOptions.IncludeImageInHtml = True
            f.HtmlOptions.Title = "Simple text"

            ' Read a PDF document to byte array
            ' Assume that we already have the  PDF as array of bytes.
            Dim pdf() As Byte = File.ReadAllBytes(pdfFile)

            f.OpenPdf(pdf)

            If f.PageCount > 0 Then
                ' Convert PDF to HTML in memory
                Dim html As String = f.ToHtml()

                ' Save HTML to the file only for demonstration purpose.
                If html IsNot Nothing Then
                    File.WriteAllText(htmlFile, html)
                    ' Open the result for demonstration purposes.
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(htmlFile) With {.UseShellExecute = True})

                End If
            End If
        End Sub
        Private Shared Sub ConvertPdfStreamToHtml()
            ' We need files only for demonstration purposes.
            ' The whole conversion process will be done in memory.
            Dim pdfFile As String = Path.GetFullPath("..\..\..\simple text.pdf")
            Dim htmlFile As String = "Result.html"

            ' Convert PDF to HTML in memory
            Dim f As New SautinSoft.PdfFocus()

            ' This property is necessary only for licensed version.
            'f.Serial = "XXXXXXXXXXX"

            ' Let's force the component to store images inside HTML document
            ' using base-64 encoding.
            ' Thus the component will not use HDD.
            f.HtmlOptions.IncludeImageInHtml = True
            f.HtmlOptions.Title = "Simple text"

            ' Assume that we have a PDF document as Stream.
            Using fs As FileStream = File.OpenRead(pdfFile)
                f.OpenPdf(fs)

                If f.PageCount > 0 Then
                    ' Convert PDF to HTML to a MemoryStream.
                    Using msHtml As New MemoryStream()
                        Dim res As Integer = f.ToHtml(msHtml)
                        ' Open the result for demonstration purposes.
                        If res = 0 Then
                            File.WriteAllBytes(htmlFile, msHtml.ToArray())
                            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(htmlFile) With {.UseShellExecute = True})
                        End If
                    End Using
                End If
            End Using
        End Sub
    End Class
End Namespace
