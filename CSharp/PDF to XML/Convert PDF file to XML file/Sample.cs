using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pathToPdf = Path.GetFullPath(@"..\..\..\Table.pdf");
            string pathToXml = "Result.xml";
			// Activate your license here
			// SautinSoft.PdfFocus.SetLicense("1234567890");
			
            // Convert PDF file to XML file.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();


            // Let's convert only tables to XML and skip all textual data.
            f.XmlOptions.ConvertNonTabularDataToSpreadsheet = false;

            f.OpenPdf(pathToPdf);

            if (f.PageCount > 0)
            {
                int result = f.ToXml(pathToXml);
                
                //Show XML document in browser
                if (result==0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pathToXml) { UseShellExecute = true });
                }
            }
        }
    }
}
