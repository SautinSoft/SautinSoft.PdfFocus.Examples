using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Before starting, we recommend to get a free key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
            // SautinSoft.PdfFocus.SetLicense("...");
			
            string pathToPdf = Path.GetFullPath(@"..\..\..\Table.pdf");
            string pathToExcel = "Result.xlsx";

            // Here we have our PDF and Excel docs as byte arrays
            byte[] pdf = File.ReadAllBytes(pathToPdf);
            byte[] xls = null;
			
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
			
			 // The output result will be in XLSX (Excel modern format) or in XLS (Excel 97-2003 Workbook)
            f.ExcelOptions.Format = SautinSoft.PdfFocus.Format.Xlsx;
            // f.ExcelOptions.Format = SautinSoft.PdfFocus.Format.Xls;
            
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
