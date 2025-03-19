Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
		' Before starting, we recommend to get a free key:
		' https://sautinsoft.com/start-for-free/

		' Apply the key here
		' SautinSoft.PdfFocus.SetLicense("...");

        Dim pathToPdf As String = Path.GetFullPath("..\..\..\Table.pdf")
        Dim pathToXml As String = "Result.xml"

        Dim pdf() As Byte = File.ReadAllBytes(pathToPdf)
        Dim xml As String = Nothing
		
        ' Convert PDF file to XML file.
        Dim f As New SautinSoft.PdfFocus()

        f.OpenPdf(pdf)

        If f.PageCount > 0 Then
            xml = f.ToXml()

            'Show XML document in browser
            If Not String.IsNullOrEmpty(xml) Then
                File.WriteAllText(pathToXml, xml)
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pathToXml) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
