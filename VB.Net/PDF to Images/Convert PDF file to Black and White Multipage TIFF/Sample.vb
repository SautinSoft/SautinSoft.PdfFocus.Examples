Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
		' Activate your license here
		' SautinSoft.PdfFocus.SetLicense("1234567890")
		
        ' Convert PDF file to BlackAndWhite Multipage-TIFF.
        Dim f As New SautinSoft.PdfFocus()

        Dim pdfPath As String = Path.GetFullPath("..\..\..\Excel.pdf")
        Dim tiffPath As String = "Result.tiff"

        f.OpenPdf(pdfPath)

        If f.PageCount > 0 Then
            f.ImageOptions.Dpi = 200
            f.ImageOptions.ColorDepth = SautinSoft.PdfFocus.CImageOptions.eColorDepth.BlackWhite1bpp
            ' EncoderValue.CompressionCCITT4 - also makes image black&white 1 bit
            f.ImageOptions.TIFFCompressionType = PdfFocus.eTIFFCompressionType.CCITTFAX4

            If f.ToMultipageTiff(tiffPath) = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(tiffPath) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
