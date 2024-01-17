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
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If FileUpload1.PostedFile.FileName.Length = 0 OrElse FileUpload1.FileBytes.Length = 0 Then
            Result.Text = "Please select PDF file at first!"
            Return
        End If
                                ' Get your free 30-day key here: 
                                ' https://sautinsoft.com/start-for-free/
		
        Dim f As New SautinSoft.PdfFocus()


        f.OpenPdf(FileUpload1.FileBytes)

        If f.PageCount > 0 Then
            'Set dpi for TIFF image
            f.ImageOptions.Dpi = 120

            'Let's whole PDF into multipage-TIFF
            Dim tiff() As Byte = f.ToMultipageTiff()

            'show image
            Response.Buffer = True
            Response.Clear()
            Response.ContentType = "image/tiff"
            Response.AddHeader("content-disposition", "attachment; filename=Result.tiff")
            Response.BinaryWrite(tiff)
            Response.Flush()
            Response.End()
        Else
            Result.Text = "Converting failed!"
        End If
    End Sub
End Class
