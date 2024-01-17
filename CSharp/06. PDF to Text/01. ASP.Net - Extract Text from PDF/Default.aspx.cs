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
        TextBox1.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile.FileName.Length == 0 || FileUpload1.FileBytes.Length == 0)
        {
            TextBox1.Text = "Please select PDF file at first!";
            return;
        }
                                                         // Get your free 30-day key here:   
			 // https://sautinsoft.com/start-for-free/
        SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
		
        f.OpenPdf(FileUpload1.FileBytes);

        if (f.PageCount > 0)
        {
            //Convert whole PDF to Text (extract text from PDF)
            string text = f.ToText();

            //show text
            TextBox1.Text = text;
        }
        else
        {
            TextBox1.Text = "Extracting failed!";
        }
    }
}
