Imports System
Imports System.IO

Namespace Sample
    Friend Class Sample
        Shared Sub Main(ByVal args() As String)
            ' Activation of PDF Focus .Net after purchasing.
            Dim f As New SautinSoft.PdfFocus()

            ' Let us say, you have this key: 1234567890.
            f.Serial = "1234567890"

            Dim pdfPath As String = "..\simple text.pdf"
            Dim tiffPath As String = ".tiff"

            ' Open PDF
            f.OpenPdf(pdfPath)

            If f.PageCount > 0 Then
                ' 0 - converting successfully            
                ' 2 - can't create output file, check the output path
                ' 3 - converting failed
                f.ImageOptions.Dpi = 300
                If f.ToMultipageTiff(tiffPath) = 0 Then
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(tiffPath) With {.UseShellExecute = True})
                End If
            End If
        End Sub
    End Class
End Namespace
