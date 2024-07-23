Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
		' Before starting, we recommend to get a free 100-day key:
		' https://sautinsoft.com/start-for-free/

		' Apply the key here
		' SautinSoft.PdfFocus.SetLicense("...");

        Dim pdfFile As String = Path.GetFullPath("..\..\..\Potato Beetle.pdf")

        ' Assume that we already have PDF as byte array
        Dim pdfBytes() As Byte = File.ReadAllBytes(pdfFile)
		
        ' Extract Text from PDF only from 1st page
        Dim f As New SautinSoft.PdfFocus()

        f.OpenPdf(pdfFile)

        If f.PageCount > 0 Then
            ' Convert only 1st page
            Dim textString As String = f.ToText(1, 1)

            ' Save 'textString' to a file only for demonstration purposes.                
            Dim textFile As String = "Result.txt"
            File.WriteAllText(textFile, textString)
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(textFile) With {.UseShellExecute = True})
        End If
    End Sub
End Module
