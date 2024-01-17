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
Imports SautinSoft

Partial Public Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        uplPDF.Attributes("onchange") = "UploadFile(this)"

        If Not Me.IsPostBack Then
            Session("page") = 1
        End If
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim page As Integer = CInt(Fix(Session("page")))
        page += 1
        If IsPageInRange(page) Then
            Session("page") = page
            ShowPdf()
        End If
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim page As Integer = CInt(Fix(Session("page")))
        page -= 1
        If IsPageInRange(page) Then
            Session("page") = page
            ShowPdf()
        End If
    End Sub

    Protected Sub Upload(ByVal sender As Object, ByVal e As EventArgs)
        lblMessage.Visible = True
        Dim f As New PdfFocus()
        f.OpenPdf(uplPDF.FileBytes)
        Session("focus") = f
        Session("page") = 1
        ShowPdf()

    End Sub
    Protected Function IsPageInRange(ByVal page As Integer) As Boolean
        If Session("focus") IsNot Nothing Then
            Dim f As PdfFocus = CType(Session("focus"), PdfFocus)

            If page > 0 AndAlso page <= f.PageCount Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub ShowPdf()
        If Session("focus") IsNot Nothing Then
            Dim f As PdfFocus = CType(Session("focus"), PdfFocus)

            If f.PageCount > 0 Then
                f.HtmlOptions.IncludeImageInHtml = True
                f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Png

                Dim page As Integer = CInt(Fix(Session("page")))
                Dim html As String = f.ToHtml(page, page)
                htmlLiteral.Text = html
                txtPage.Text = String.Format("Page {0} of {1}", page, f.PageCount)
            End If
        End If
    End Sub
End Class
