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

            byte[] pdf = File.ReadAllBytes(pathToPdf);
            string xml = null;
                                  // Get your free 30-day key here:   
			 // https://sautinsoft.com/start-for-free/
			
            // Convert PDF file to XML file.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // Let's convert all data (textual and tabular) to XML.
            f.XmlOptions.ConvertNonTabularDataToSpreadsheet = true;

            f.OpenPdf(pdf);

            if (f.PageCount > 0)
            {
                xml = f.ToXml();
                
                //Show XML document in browser
                if (!String.IsNullOrEmpty(xml))
                {
                    File.WriteAllText(pathToXml,xml);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pathToXml) { UseShellExecute = true });
                }
            }
        }
    }
}
