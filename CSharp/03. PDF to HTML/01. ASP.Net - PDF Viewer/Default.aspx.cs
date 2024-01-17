using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SautinSoft;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        uplPDF.Attributes["onchange"] = "UploadFile(this)";

        if (!this.IsPostBack)
        {
            Session["page"] = 1;
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        int page = (int)Session["page"];
        page++;
        if (IsPageInRange(page))
        {
            Session["page"] = page;
            ShowPdf();
        }
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        int page = (int)Session["page"];
        page--;
        if (IsPageInRange(page))
        {
            Session["page"] = page;
            ShowPdf();
        }
    }

    protected void Upload(object sender, EventArgs e)
    {        
        lblMessage.Visible = true;
        PdfFocus f = new PdfFocus();
        f.OpenPdf(uplPDF.FileBytes);
        Session["focus"] = f;
        Session["page"] = 1;		
        ShowPdf();

    }
    protected bool IsPageInRange(int page)
    {
        if (Session["focus"] != null)
        {
            PdfFocus f = (PdfFocus)Session["focus"];

            if (page > 0 && page <= f.PageCount)
                return true;
        }
        return false;
    }

    private void ShowPdf()
    {
        if (Session["focus"] != null)
        {
            PdfFocus f = (PdfFocus)Session["focus"];
            
            if (f.PageCount > 0)
            {
                f.HtmlOptions.IncludeImageInHtml = true;
                f.EmbeddedImagesFormat = PdfFocus.eImageFormat.Png;

                int page = (int)Session["page"];

                string html = f.ToHtml(page, page);
                htmlLiteral.Text = html;
                txtPage.Text = String.Format("Page {0} of {1}", page, f.PageCount);
            }
        }
    }
}