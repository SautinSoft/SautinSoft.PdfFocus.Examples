using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Result.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile.FileName.Length == 0 || FileUpload1.FileBytes.Length == 0)
        {
            Result.Text = "Please select PDF file at first!";
            return;
        }
        
        SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
		//this property is necessary only for registered version
		//f.Serial = "XXXXXXXXXXX";
		
        f.OpenPdf(FileUpload1.FileBytes);

        if (f.PageCount > 0)
        {
            //set image properties
            f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
            f.ImageOptions.Dpi = 200;

            //Let's convert whole PDF document
            ArrayList pages = f.ToImage();

            //Show images
            if (pages.Count > 0)
            {
                int width = 3;
                int imgWidth = 300;

                HtmlGenericControl divContainer = new HtmlGenericControl("div");
                divContainer.Attributes.Add("class", "container");
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "col-12 pt-2");
                divContainer.Controls.Add(div);

                HtmlTable table = new HtmlTable();
                table.Attributes.Add("class", "table");
                table.Border = 1;
                table.CellPadding = 3;
                table.CellSpacing = 3;

                HtmlTableRow row;
                HtmlTableCell cell;
                HtmlImage img;
                
                string imagePath = Server.MapPath("~");
                string imageName = "Page";

                row = new HtmlTableRow();
                int count = 0;
                foreach (byte[] page in pages)
                {
                    count++;
                    string src = imageName + count.ToString() + ".png";
                    File.WriteAllBytes(Path.Combine(imagePath, src), page);

                    cell = new HtmlTableCell();
                    cell.Style.Add("vertical-align","top");
                    img = new HtmlImage();

                    img.Src = src;
                    img.Width = imgWidth;
                    cell.InnerHtml = "<div align=\"center\">Page" + count.ToString() + "</div>";
                    
                    cell.Controls.Add(img);
                    row.Cells.Add(cell);

                    if (count % width == 0)
                    {
                        table.Rows.Add(row);
                        row = new HtmlTableRow();
                    }
                }
                table.Rows.Add(row);
                div.Controls.Add(table);
                this.Controls.Add(divContainer);
            }
   
        }
        else
        {
            Result.Text = "Converting failed!";
        }
    }
}
