using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Before starting, we recommend to get a free 100-day key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
            // SautinSoft.PdfFocus.SetLicense("...");
			
            string pathToPdf = Path.GetFullPath(@"..\..\..\Table.pdf");
            string pathToXml = "Result.xml";

            byte[] pdf = File.ReadAllBytes(pathToPdf);
            string xml = null;
			
            // Convert PDF file to XML file.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

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
