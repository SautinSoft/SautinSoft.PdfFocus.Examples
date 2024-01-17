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
        byte[] excel = null;
                                  // Get your free 30-day key here:   
			 // https://sautinsoft.com/start-for-free/
        SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
        
        f.OpenPdf(FileUpload1.FileBytes);
        f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = true;

        // 'true'  = Preserve original page layout.
        // 'false' = Place tables before text.
        f.ExcelOptions.PreservePageLayout = true;

        // The information includes the names for the culture, the writing system, 
        // the calendar used, the sort order of strings, and formatting for dates and numbers.
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
        ci.NumberFormat.NumberDecimalSeparator = ",";
        ci.NumberFormat.NumberGroupSeparator = ".";
        f.ExcelOptions.CultureInfo = ci;

        if (f.PageCount > 0)
        {
           
            excel = f.ToExcel();
        }

        //show Excel
        if (excel != null)
        {
            ShowResult(excel, "Result.xls", "application/msexcel");
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
