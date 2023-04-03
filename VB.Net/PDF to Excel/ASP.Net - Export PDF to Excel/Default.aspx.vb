Imports System

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Result.Text = ""
	End Sub
	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		If FileUpload1.PostedFile.FileName.Length = 0 OrElse FileUpload1.FileBytes.Length = 0 Then
			Result.Text = "Please select PDF file at first!"
			Return
		End If
		Dim excel() As Byte = Nothing

		Dim f As New SautinSoft.PdfFocus()
		'this property is necessary only for registered version
		'f.Serial = "XXXXXXXXXXX";
		f.OpenPdf(FileUpload1.FileBytes)
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

		If f.PageCount > 0 Then

			excel = f.ToExcel()
		End If

		'show Excel
		If excel IsNot Nothing Then
			ShowResult(excel, "Result.xls", "application/msexcel")
		Else
			Result.Text = "Converting failed!"
		End If
	End Sub
	Private Sub ShowResult(ByVal data() As Byte, ByVal fileName As String, ByVal contentType As String)
		Response.Buffer = True
		Response.Clear()
		Response.ContentType = contentType
		Response.AddHeader("content-disposition", "inline; filename=""" & fileName & """")
		Response.BinaryWrite(data)
		Response.Flush()
		Response.End()
	End Sub
End Class