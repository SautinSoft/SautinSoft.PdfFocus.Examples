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

        Dim pathToPdf As String = Path.GetFullPath("..\..\..\Table.pdf")
        Dim pathToExcel As String = "Result.xlsx"

        ' Here we have our PDF and Excel docs as byte arrays
        Dim pdf() As Byte = File.ReadAllBytes(pathToPdf)
        Dim xls() As Byte = Nothing
		
        ' Convert PDF document to Excel workbook in memory
        Dim f As New SautinSoft.PdfFocus()

		' The output result will be in XLSX (Excel modern format) or in XLS (Excel 97-2003 Workbook)
        f.ExcelOptions.Format = SautinSoft.PdfFocus.Format.Xlsx
        ' f.ExcelOptions.Format = SautinSoft.PdfFocus.Format.Xls

        ' The information includes the names for the culture, the writing system, 
        ' the calendar used, the sort order of strings, and formatting for dates and numbers.
        Dim ci As New System.Globalization.CultureInfo("en-US")
        ci.NumberFormat.NumberDecimalSeparator = ","
        ci.NumberFormat.NumberGroupSeparator = "."
        f.ExcelOptions.CultureInfo = ci

        f.OpenPdf(pdf)

        If f.PageCount > 0 Then
            xls = f.ToExcel()

            'Save Excel workbook to a file in order to show it
            If xls IsNot Nothing Then
                File.WriteAllBytes(pathToExcel, xls)
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pathToExcel) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
