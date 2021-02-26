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
            f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
            f.ImageOptions.Dpi = 200

            'Let's convert whole PDF document
            Dim pages As ArrayList = f.ToImage()

			'Show images
			If pages.Count > 0 Then
				Dim width As Integer = 3
				Dim imgWidth As Integer = 300

				Dim divContainer As New HtmlGenericControl("div")
				divContainer.Attributes.Add("class", "container")
				Dim div As New HtmlGenericControl("div")
				div.Attributes.Add("class", "col-12 pt-2")
				divContainer.Controls.Add(div)

				Dim table As New HtmlTable()
				table.Attributes.Add("class", "table")
				table.Border = 1
				table.CellPadding = 3
				table.CellSpacing = 3

				Dim row As HtmlTableRow
				Dim cell As HtmlTableCell
				Dim img As HtmlImage

				Dim imagePath As String = Server.MapPath("~")
				Dim imageName As String = "Page"

				row = New HtmlTableRow()
				Dim count As Integer = 0
				For Each page As Byte() In pages
					count += 1
					Dim src As String = imageName & count.ToString() & ".png"
					File.WriteAllBytes(Path.Combine(imagePath, src), page)

					cell = New HtmlTableCell()
					cell.Style.Add("vertical-align", "top")
					img = New HtmlImage()

					img.Src = src
					img.Width = imgWidth
					cell.InnerHtml = "<div align=""center"">Page" & count.ToString() & "</div>"

					cell.Controls.Add(img)
					row.Cells.Add(cell)

					If count Mod width = 0 Then
						table.Rows.Add(row)
						row = New HtmlTableRow()
					End If
				Next page
				table.Rows.Add(row)
				div.Controls.Add(table)
				Me.Controls.Add(divContainer)
			End If
		Else
			Result.Text = "Converting failed!"
        End If
    End Sub
End Class
