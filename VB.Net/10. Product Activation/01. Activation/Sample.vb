Imports System
Imports System.IO
Imports SautinSoft

Namespace Sample
    Friend Class Sample
        Shared Sub Main(ByVal args() As String)

            ' You will get own serial number after purchasing the license.
            ' If you will have any questions, email us to sales@sautinsoft.com or ask at online chat https://www.sautinsoft.com.

            ' Let us say, you have this key: 1234567890.            
            PdfFocus.SetLicense("1234567890")
            ' Activation of PDF Focus .Net after purchasing.

            Dim f As New SautinSoft.PdfFocus()

            Dim pdfPath As String = Path.GetFullPath("..\..\..\simple text.pdf")
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
