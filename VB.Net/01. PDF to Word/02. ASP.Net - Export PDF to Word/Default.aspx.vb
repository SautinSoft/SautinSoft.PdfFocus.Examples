Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO

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

        Dim rtf() As Byte = Nothing
                                ' Get your free 30-day key here: 
                                ' https://sautinsoft.com/start-for-free/
		
        Dim f As New SautinSoft.PdfFocus()

        f.OpenPdf(FileUpload1.FileBytes)

        If f.PageCount > 0 Then
            'Let's whole PDF document to Word (RTF)
            f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Rtf

            ' You may also set an output format to Docx.
            'f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;
            rtf = f.ToWord()
        End If

        'show Word/rtf
        If rtf IsNot Nothing Then
            ShowResult(rtf, "Result.rtf", "application/msword")
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
