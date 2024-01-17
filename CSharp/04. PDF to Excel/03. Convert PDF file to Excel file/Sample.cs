using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pathToPdf = Path.GetFullPath(@"..\..\..\Table.pdf");
            string pathToExcel = "Result.xlsx";
                                  // Get your free 30-day key here:   
			 // https://sautinsoft.com/start-for-free/
            
			// Convert PDF file to Excel file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
			// The output result will be in XLSX (Excel modern format) or in XLS (Excel 97-2003 Workbook)
            f.ExcelOptions.Format = SautinSoft.PdfFocus.Format.Xlsx;
            // f.ExcelOptions.Format = SautinSoft.PdfFocus.Format.Xls;
           
		   // 'true' = Convert all data to spreadsheet (tabular and even textual).
            // 'false' = Skip textual data and convert only tabular (tables) data.
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

            f.OpenPdf(pathToPdf);

            if (f.PageCount > 0)
            {
                int result = f.ToExcel(pathToExcel);
                
                //Open a produced Excel workbook
                if (result==0)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pathToExcel) { UseShellExecute = true });
                }
            }
        }
    }
}
