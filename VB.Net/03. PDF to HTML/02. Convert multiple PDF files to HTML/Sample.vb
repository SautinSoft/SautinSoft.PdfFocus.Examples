Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Linq
Imports System.Text
Imports SautinSoft

Namespace Sample
    Friend Class Sample
        Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free key:
			' https://sautinsoft.com/start-for-free/

			' Apply the key here
			' SautinSoft.PdfFocus.SetLicense("...");

            'ConvertMultiplePdfToHtmls()
            ConvertMultiplePdfToSingleHtml()
        End Sub

        ''' <summary>
        ''' Converts multiple PDF files to HTML files.
        ''' </summary>
        Private Shared Sub ConvertMultiplePdfToHtmls()
            ' Directory with *.pdf files.
            Dim pdfDirectory As String = Path.GetFullPath("..\..\..\")
            Dim pdfFiles() As String = Directory.GetFiles(pdfDirectory, "*.pdf")
            Dim htmlDirectory As New DirectoryInfo("htmls")
            If Not htmlDirectory.Exists Then
                htmlDirectory.Create()
            End If
		
            Dim f As New PdfFocus()

            Dim success As Integer = 0
            Dim total As Integer = 0

            For Each pdfFile As String In pdfFiles
                Console.WriteLine("Converting {0} ...", Path.GetFileName(pdfFile))

                f.OpenPdf(pdfFile)
                total += 1

                If f.PageCount > 0 Then
                    ' Path (must exist) to a directory to store images after converting. Notice also to the property "ImageSubFolder".
                    f.HtmlOptions.ImageFolder = htmlDirectory.FullName

                    ' A folder (will be created by the component) without any drive letters, only the folder as "myfolder".
                    f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile))

                    ' A template name for images
                    f.HtmlOptions.ImageFileName = "picture"

                    ' Auto - the same image format as in the source PDF;
                    ' 'Jpeg' to make the document size less; 
                    ' 'PNG' to keep the highest quality, but the highest size too.
                    f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Auto

                    ' How to store images: Inside HTML document as base64 images or as linked separate image files.
                    f.HtmlOptions.IncludeImageInHtml = False

                    Dim htmlFile As String = Path.GetFileNameWithoutExtension(pdfFile) & ".html"
                    Dim htmlFilePath As String = Path.Combine(htmlDirectory.FullName, htmlFile)

                    If f.ToHtml(htmlFilePath) = 0 Then
                        success += 1
                    End If
                End If
            Next pdfFile
            ' Show results:
            Console.WriteLine("{0} of {1} files converted successfully!", success, total)

            ' Open folder with HTML files after converting.
            ' Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(htmlDirectory.FullName) With {.UseShellExecute = True})
        End Sub
        ''' <summary>
        ''' Converts multiple PDF files into a single HTML document.
        ''' </summary>
        Private Shared Sub ConvertMultiplePdfToSingleHtml()
            ' Directory with *.pdf files.
            Dim pdfDirectory As String = Path.GetFullPath("..\")
            Dim htmlFile As String = "Result.html"

            Dim pdfFiles() As String = Directory.GetFiles(pdfDirectory, "*.pdf")

            ' Here we'll keep our Html document.
            Dim singleHtml As New StringBuilder()
            singleHtml.Append("<html>" & vbCrLf & "<head>" & vbCrLf)
            singleHtml.Append("<meta http-equiv = ""Content-Type"" content=""text/html; charset=utf-8"" />")
            singleHtml.Append(vbCrLf & "</head>" & vbCrLf & "<body>")
		
            Dim f As New PdfFocus()

            Dim success As Integer = 0
            Dim total As Integer = 0

            For Each pdfFile As String In pdfFiles
                Console.WriteLine("Converting {0} ...", Path.GetFileName(pdfFile))

                f.OpenPdf(pdfFile)
                total += 1

                If f.PageCount > 0 Then
                    ' How to store images: Inside HTML document as base64 images or as linked separate image files.
                    f.HtmlOptions.IncludeImageInHtml = False

                    ' Create own subfolder for each converted file to store images separately and don't mix up them.
                    f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile))

                    ' A template name for images
                    f.HtmlOptions.ImageFileName = "picture"

                    ' Auto - the same image format as in the source PDF;
                    ' 'Jpeg' to make the document size less; 
                    ' 'PNG' to keep the highest quality, but the highest size too.
                    f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Auto

                    ' Let's make our CSS inline to be able merge HTML documents without any problems.
                    f.HtmlOptions.InlineCSS = True

                    ' We need only contents of <body>...</body>.
                    f.HtmlOptions.ProduceOnlyHtmlBody = True

                    Dim tempHtml As String = f.ToHtml()

                    If Not String.IsNullOrEmpty(tempHtml) Then
                        success += 1
                        ' Add tempHtml into a single HTML.
                        singleHtml.Append(tempHtml)
                    End If
                End If
            Next pdfFile
            singleHtml.Append("</body></html>")

            ' Show results:
            File.WriteAllText(htmlFile, singleHtml.ToString())

            Console.WriteLine("{0} of {1} files converted and merged into {2}!", success, total, Path.GetFileName(htmlFile))

            ' Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(htmlFile) With {.UseShellExecute = True})
        End Sub
    End Class
End Namespace
