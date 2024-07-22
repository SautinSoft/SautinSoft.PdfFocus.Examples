Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pathToPdf As String = Path.GetFullPath("..\..\..\Table.pdf")
		Dim pathToExcel As String = "Result.xls"
                                ' Get your free 100-day key here: 
                                ' https://sautinsoft.com/start-for-free/
		
		' Convert PDF file to Excel file
		Dim f As New SautinSoft.PdfFocus()
		
		' The output result will be in XLSX (Excel modern format) or in XLS (Excel 97-2003 Workbook)
        f.ExcelOptions.Format = SautinSoft.PdfFocus.Format.Xlsx
        ' f.ExcelOptions.Format = SautinSoft.PdfFocus.Format.Xls
		
			' 'true' = Convert all data to spreadsheet (tabular and even textual).
			' 'false' = Skip textual data and convert only tabular (tables) data.
			f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = True

			' 'true'  = Preserve original page layout.
			' 'false' = Place tables before text.
			f.ExcelOptions.PreservePageLayout = True

			' The information includes the names for the culture, the writing system, 
			' the calendar used, the sort order of strings, and formatting for dates and numbers.
			Dim ci As New System.Globalization.CultureInfo("en-US")
			ci.NumberFormat.NumberDecimalSeparator = ","
			ci.NumberFormat.NumberGroupSeparator = "."
			f.ExcelOptions.CultureInfo = ci

			f.OpenPdf(pathToPdf)

			If f.PageCount > 0 Then
				Dim result As Integer = f.ToExcel(pathToExcel)

				'Open a produced Excel workbook
				If result=0 Then
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pathToExcel) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
