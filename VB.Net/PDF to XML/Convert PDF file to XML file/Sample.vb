Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pathToPdf As String = Path.GetFullPath("..\..\..\Table.pdf")
        Dim pathToXml As String = "Result.xml"
		' Activate your license here
		' SautinSoft.PdfFocus.SetLicense("1234567890")
		
        ' Convert PDF file to XML file.
        Dim f As New SautinSoft.PdfFocus()

        ' Let's convert only tables to XML and skip all textual data.
        f.XmlOptions.ConvertNonTabularDataToSpreadsheet = False

        f.OpenPdf(pathToPdf)

        If f.PageCount > 0 Then
            Dim result As Integer = f.ToXml(pathToXml)

            'Show XML document in browser
            If result = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pathToXml) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
