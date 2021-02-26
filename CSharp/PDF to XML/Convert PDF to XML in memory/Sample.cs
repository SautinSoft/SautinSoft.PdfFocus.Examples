using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pathToPdf = @"..\..\Table.pdf";
            string pathToXml = "Result.xml";

            byte[] pdf = File.ReadAllBytes(pathToPdf);
            string xml = null;

            // Convert PDF file to XML file.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // This property is necessary only for registered version.
            //f.Serial = "XXXXXXXXXXX";

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
