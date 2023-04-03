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

        Dim f As New SautinSoft.PdfFocus()
        'this property is necessary only for registered version
        'f.Serial = "XXXXXXXXXXX"

        f.OpenPdf(FileUpload1.FileBytes)

        If f.PageCount > 0 Then

            'set image properties
            f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
            f.ImageOptions.Dpi = 200
            'Let's convert 1st page from PDF document
            Dim image() As Byte = f.ToImage(1)

            'show image
            Response.Buffer = True
            Response.Clear()
            Response.ContentType = "image/jpeg"
            Response.AddHeader("content-disposition", "attachment; filename=Page1.jpg")
            Response.BinaryWrite(image)
            Response.Flush()
            Response.End()
        Else
            Result.Text = "Converting failed!"
        End If
    End Sub
End Class
