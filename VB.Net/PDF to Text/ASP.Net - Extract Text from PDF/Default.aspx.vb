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
        TextBox1.Text = ""
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        If FileUpload1.PostedFile.FileName.Length = 0 OrElse FileUpload1.FileBytes.Length = 0 Then
            TextBox1.Text = "Please select PDF file at first!"
            Return
        End If

        Dim f As New SautinSoft.PdfFocus()
	    'this property is necessary only for registered version
		'f.Serial = "XXXXXXXXXXX"

        f.OpenPdf(FileUpload1.FileBytes)

        If f.PageCount > 0 Then
            'Convert whole PDF to Text (extract text from PDF)
            Dim text As String = f.ToText()

            'show text
            TextBox1.Text = Text

        Else
            TextBox1.Text = "Converting failed!"
        End If
    End Sub
End Class
