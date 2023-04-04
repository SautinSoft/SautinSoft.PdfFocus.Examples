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

            // Convert only tables from PDF to XLS spreadsheet and skip all textual data.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            
	    	// This property is necessary only for registered version
		    //f.Serial = "XXXXXXXXXXX";

            // 'true' = Convert all data to spreadsheet (tabular and even textual).
            // 'false' = Skip textual data and convert only tabular (tables) data.
            f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = false;

            // 'true'  = Preserve original page layout.
            // 'false' = Place tables before text.
            f.ExcelOptions.PreservePageLayout = true;

            // The information includes the names for the culture, the writing system, 
            // the calendar used, the sort order of strings, and formatting for dates and numbers.
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            ci.NumberFormat.NumberDecimalSeparator = ",";
            ci.NumberFormat.NumberGroupSeparator = ".";
            f.ExcelOptions.CultureInfo = ci;

            f.OpenPdf(pathToPdf);

            if (f.PageCount > 0)
            {
                int result = f.ToExcel(pathToExcel);
                
                // Open the resulted Excel workbook.
                if (result==0)
                {
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pathToExcel) { UseShellExecute = true });                    
                }
            }
        }
    }
}
