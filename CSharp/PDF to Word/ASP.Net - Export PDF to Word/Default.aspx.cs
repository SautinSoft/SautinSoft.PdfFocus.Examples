using System;

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
        byte[] rtf = null;

        SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
        //this property is necessary only for registered version
        //f.Serial = "XXXXXXXXXXX";
        f.OpenPdf(FileUpload1.FileBytes);

        if (f.PageCount > 0)
        {
            //Let's whole PDF document to Word (RTF)
            f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Rtf;

            // You may also set an output format to Docx.
            //f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;
            rtf = f.ToWord();
        }

        //show Word/rtf
        if (rtf != null)
        {
            ShowResult(rtf, "Result.rtf", "application/msword");
        }
        else
        {
            Result.Text = "Converting failed!";
        }
    }
    private void ShowResult(byte[] data, string fileName, string contentType)
    {
        Response.Buffer = true;
        Response.Clear();
        Response.ContentType = contentType;
        Response.AddHeader("content-disposition", "inline; filename=\"" + fileName + "\"");
        Response.BinaryWrite(data);
        Response.Flush();
        Response.End();
    }
}
