Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports System.Threading
Imports SautinSoft

Module Sample

    Sub Main()
        ConvertPdfToPngInThread()
    End Sub
    Public Class TArgument
        Public Property PdfFile() As String
        Public Property PageNumber() As Integer
    End Class
    Public Sub ConvertPdfToPngInThread()
        Dim pdfs As String = Path.GetFullPath("..\..\..")
        Dim files() As String = Directory.GetFiles(pdfs, "*.pdf")

        Dim threads As New List(Of Thread)()
        For i As Integer = 0 To files.Length - 1
            Dim targ As New TArgument() With {
                    .PdfFile = files(i),
                    .PageNumber = 1
                }

            Dim t = New Thread(Sub(a) ConvertToPng(a))
            t.Start(targ)
            threads.Add(t)
        Next i

        For Each t As Thread In threads
            t.Join()
        Next t
        Console.WriteLine("Done!")
    End Sub

    Public Sub ConvertToPng(ByVal targ As Object)
        Dim targum As TArgument = DirectCast(targ, TArgument)
        Dim pdfFile As String = targum.PdfFile
        Dim page As Integer = targum.PageNumber

        Dim pngFile As String = Path.GetFileNameWithoutExtension(pdfFile) + ".png"
		' Activate your license here
		' SautinSoft.PdfFocus.SetLicense("1234567890")
		
        Dim f As New SautinSoft.PdfFocus()

        f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
        f.ImageOptions.Dpi = 300

        f.OpenPdf(pdfFile)

        Dim done As Boolean = False

        If f.PageCount > 0 Then
            If page >= f.PageCount Then
                page = 1
            End If

            If f.ToImage(pngFile, page) = 0 Then
                done = True
            End If
            f.ClosePdf()
        End If

        If done Then
            Console.WriteLine("{0}" & ControlChars.Tab & " - Done!", Path.GetFileName(pdfFile))
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pngFile) With {.UseShellExecute = True})
        Else
            Console.WriteLine("{0}" & ControlChars.Tab & " - Error!", Path.GetFileName(pdfFile))
        End If
    End Sub
End Module