Option Infer On

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.Threading
Imports SautinSoft

Namespace Sample
    Friend Class Sample
        Shared Sub Main(ByVal args() As String)
            ConvertPdfToHtmlInThread()
        End Sub
        Public Class TArgument
            Public Property PdfFile() As String
            Public Property HtmlFile() As String
            Public Property PageNumber() As Integer
        End Class
        Public Shared Sub ConvertPdfToHtmlInThread()
            Dim pdfDir As String = Path.GetFullPath("..\..\..\")
            Dim pdfFiles() As String = Directory.GetFiles(pdfDir, "*.pdf")
            Dim htmlDir As New DirectoryInfo("HTML results")
            If Not htmlDir.Exists Then
                htmlDir.Create()
            End If

            Dim threads As New List(Of Thread)()
            For Each pdfFile As String In pdfFiles
                Dim targ As New TArgument() With {
                    .PdfFile = pdfFile,
                    .HtmlFile = Path.Combine(htmlDir.FullName, Path.GetFileNameWithoutExtension(pdfFile) & ".html"),
                    .PageNumber = 1
                }

                Dim t = New Thread(Sub(a) ConvertToHtml(a))
                t.Start(targ)
                threads.Add(t)
            Next pdfFile

            For Each thread In threads
                thread.Join()
            Next thread
            Console.WriteLine("Done!")
            ' Open the result for demonstration purposes.            
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(htmlDir.FullName) With {.UseShellExecute = True})

        End Sub

        Public Shared Sub ConvertToHtml(ByVal targ As Object)
            Dim targum As TArgument = DirectCast(targ, TArgument)
            Dim pdfFile As String = targum.PdfFile
            Dim page As Integer = targum.PageNumber

            Dim htmlFile As String = targum.HtmlFile
	                                ' Get your free 30-day key here: 
	                                ' https://sautinsoft.com/start-for-free/
		
            Dim f As New SautinSoft.PdfFocus()

            f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Auto
            f.HtmlOptions.IncludeImageInHtml = False
            f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile))
            f.HtmlOptions.Title = String.Format("This document was produced from {0}.", Path.GetFileName(pdfFile))
            f.HtmlOptions.ImageFileName = "picture"

            f.OpenPdf(pdfFile)

            Dim done As Boolean = False

            If f.PageCount > 0 Then
                If page >= f.PageCount Then
                    page = 1
                End If

                If f.ToHtml(htmlFile, page, page) = 0 Then
                    done = True
                End If
                f.ClosePdf()
            End If

            If done Then
                Console.WriteLine("{0}" & vbTab & " - Done!", Path.GetFileName(pdfFile))
            Else
                Console.WriteLine("{0}" & vbTab & " - Error!", Path.GetFileName(pdfFile))
            End If
        End Sub
    End Class
End Namespace
