Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.Drawing

Namespace Sample
    Friend Class Sample
        Shared Sub Main(ByVal args() As String)
            ConvertPdfBytesToHtml()
        End Sub

        Private Shared Sub ConvertPdfBytesToHtml()
            ' We need files only for demonstration purposes.
            ' The whole conversion process will be done in memory.
            Dim pdfFile As String = Path.GetFullPath("..\..\..\simple text.pdf")
            Dim htmlFile As String = "Result.htm"

            ' This is the list with extracted images.
            ' It will be filled by images after the conversion.
            Dim imgCollection As New List(Of Image)()
	                                ' Get your free 100-day key here: 
	                                ' https://sautinsoft.com/start-for-free/
		
            ' Convert PDF to HTML in memory
            Dim f As New SautinSoft.PdfFocus()
            ' Let's force the component to store images inside HTML document
            ' using base-64 encoding.
            ' Thus the component will not use HDD.
            f.HtmlOptions.IncludeImageInHtml = True
            f.HtmlOptions.Title = "Simple text"

            ' Read a PDF document to byte array.
            ' Assume that we already have the  PDF as array of bytes.
            Dim pdf() As Byte = File.ReadAllBytes(pdfFile)

            f.OpenPdf(pdf)

            If f.PageCount > 0 Then
                ' Convert PDF to HTML in memory
                Dim htmlString As String = f.ToHtml(1, f.PageCount, imgCollection)

                ' Save HTML to a file only for the demonstration purpose.
                If htmlString IsNot Nothing Then
                    ' Show info about images and save them
                    Console.WriteLine("After converting we've got {0} image(s):", imgCollection.Count)
                    Dim imgDir As New DirectoryInfo("Extracted Images")
                    If Not imgDir.Exists Then
                        imgDir.Create()
                    End If

                    Dim count As Integer = 1
                    For Each img As Image In imgCollection
                        Console.WriteLine(vbTab & " {0,4} x {1,4} px", img.Width, img.Height)
                        Dim imageFileName As String = Path.Combine(imgDir.FullName, String.Format($"pict{count}.jpg"))
                        img.Save(imageFileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                        count += 1
                    Next img
                    ' Open the result for demonstration purposes.
                    File.WriteAllText(htmlFile, htmlString)
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(htmlFile) With {.UseShellExecute = True})
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(imgDir.FullName) With {.UseShellExecute = True})
                End If
            End If
        End Sub
    End Class
End Namespace
