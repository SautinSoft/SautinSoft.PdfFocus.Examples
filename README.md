![Nuget](https://img.shields.io/nuget/v/sautinsoft.pdffocus) ![Nuget](https://img.shields.io/nuget/dt/sautinsoft.pdffocus) 
# .NET SDK to convert PDF to ALL

![focus](https://user-images.githubusercontent.com/79837963/229720453-ce02ba06-19af-4a69-995a-351e7ac60257.png)

[SautinSoft.PdfFocus](https://sautinsoft.com/products/pdf-focus/) is .NET assembly (SDK) which gives API  to convert PDF to All formats: DOCX, RTF, HTML, XML, Text, Excel, Images.

## Quick links

+ [Developer Guide](https://sautinsoft.com/products/pdf-focus/help/net/)
+ [API Reference](https://sautinsoft.com/products/pdf-focus/help/net/api-reference/html/N_SautinSoft.htm)

## Top Features

+ [Convert PDF file to Word file.](https://sautinsoft.com/products/pdf-focus/help/net/developer-guide/convert-pdf-to-word-csharp-vb-net.php)
+ [Convert PDF file to Image file.](https://sautinsoft.com/products/pdf-focus/help/net/developer-guide/convert-pdf-to-images-csharp-vb-net.php)
+ [Convert PDF file to HTML file.](https://sautinsoft.com/products/pdf-focus/help/net/developer-guide/convert-pdf-to-html-csharp-vb-net.php)
+ [Convert PDF file to Excel file.](https://sautinsoft.com/products/pdf-focus/help/net/developer-guide/convert-pdf-to-excel-csharp-vb-net.php)
+ [Convert PDF file to XML file.](https://sautinsoft.com/products/pdf-focus/help/net/developer-guide/convert-pdf-to-xml-csharp-vb-net.php)
+ [Convert PDF file to Text file.](https://sautinsoft.com/products/pdf-focus/help/net/developer-guide/convert-pdf-to-text-csharp-vb-net.php)
+ [Convert PDF file to ALL using OCR engine.](https://sautinsoft.com/products/pdf-focus/help/net/developer-guide/convert-pdf-to-all-ocr-engine-csharp-vb-net.php)

## System Requirement

* .NET Framework 4.6.2- 4.8
* .NET 6, 8
* Windows, Linux, macOS, Android, iOS.

## Getting Started with PDF Focus .Net

Are you ready to give PDF Focus .NET a try? Simply execute `Install-Package sautinsoft.pdffocus` from Package Manager Console in Visual Studio to fetch the NuGet package. If you already have PDF Focus .NET and want to upgrade the version, please execute `Update-Package sautinsoft.pdffocus` to get the latest version.

## Convert PDF to Word

```csharp
string pdfFile = @"..\..\text and graphics.pdf";
string wordFile = Path.ChangeExtension(pdfFile, ".docx");

// Convert a PDF file to a Word file
SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            
f.OpenPdf(pdfFile);
f.ToWord(wordFile);
```
## Convert PDF to Excel

```csharp
string pdfFile = @"..\..\text and graphics.pdf";
string excelFile = Path.ChangeExtension(pdfFile, ".xlsx");

// Convert a PDF file to a Excel file
SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            
f.OpenPdf(pdfFile);
f.ToExcel(excelFile);
```

## Convert PDF to HTML

```csharp
string pdfFile = @"..\..\text and graphics.pdf";
string htmlFile = Path.ChangeExtension(pdfFile, ".html");

// Convert a PDF file to a HTML file
SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            
f.OpenPdf(pdfFile);
f.ToHTML(htmlFile);
```

## Convert PDF to JPG

```csharp
string pdfFile = @"..\..\text and graphics.pdf";
string imageFile = Path.ChangeExtension(pdfFile, ".jpg");

// Convert a PDF file to a JPG file
SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
f.ImageOptions.Dpi = 200;
         
f.OpenPdf(pdfFile);
f.ToImage(iamgeFile);
```

## Resources

+ **Website:** [www.sautinsoft.com](https://www.sautinsoft.com)
+ **Product Home:** [PDF Focus .Net](https://sautinsoft.com/products/pdf-focus/)
+ [Download SautinSoft.PDFFocus](https://sautinsoft.com/products/pdf-focus/download.php)
+ [Developer Guide](https://sautinsoft.com/products/pdf-focus/help/net/)
+ [API Reference](https://sautinsoft.com/products/pdf-focus/help/net/api-reference/html/N_SautinSoft.htm)
+ [Support Team](https://sautinsoft.com/support.php)
+ [License](https://sautinsoft.com/products/pdf-focus/help/net/getting-started/agreement.php)
