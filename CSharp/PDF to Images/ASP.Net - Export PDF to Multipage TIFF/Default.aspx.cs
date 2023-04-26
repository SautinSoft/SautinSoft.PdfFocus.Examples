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
        Result.Text = "Converting ...";
		// Activate your license here
		// SautinSoft.PdfFocus.SetLicense("1234567890");
        SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
		
        f.OpenPdf(FileUpload1.FileBytes);

        if (f.PageCount > 0)
        {
            //Set dpi for TIFF image
            f.ImageOptions.Dpi = 120;

            //Let's whole PDF into multipage-TIFF
            byte[] tiff = f.ToMultipageTiff();

            //show image
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "image/tiff";
            Response.AddHeader("content-disposition", "attachment; filename=Result.tiff");
            Response.BinaryWrite(tiff);
            Response.Flush();
            Response.End();
        }
        else
        {
            Result.Text = "Converting failed!";
        }
    }
}
