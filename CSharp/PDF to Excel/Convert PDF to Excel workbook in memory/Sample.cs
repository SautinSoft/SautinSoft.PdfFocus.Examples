using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pathToPdf = Path.GetFullPath(@"..\..\..\Table.pdf");
            string pathToExcel = "Result.xls";

            // Here we have our PDF and Excel docs as byte arrays
            byte[] pdf = File.ReadAllBytes(pathToPdf);
            byte[] xls = null;

			// Activate your license here
			// SautinSoft.PdfFocus.SetLicense("1234567890");
            // Convert PDF document to Excel workbook in memory
			
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            
	    	// This property is necessary only for registered version
		    //f.Serial = "XXXXXXXXXXX";

            // The information includes the names for the culture, the writing system, 
            // the calendar used, the sort order of strings, and formatting for dates and numbers.
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            ci.NumberFormat.NumberDecimalSeparator = ",";
            ci.NumberFormat.NumberGroupSeparator = ".";
            f.ExcelOptions.CultureInfo = ci;

            f.OpenPdf(pdf);

            if (f.PageCount > 0)
            {
                xls = f.ToExcel();
                
                //Save Excel workbook to a file in order to show it
                if (xls!=null)
                {
                    File.WriteAllBytes(pathToExcel, xls);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pathToExcel) { UseShellExecute = true });
                }
            }
        }
    }
}
