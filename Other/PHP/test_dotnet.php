<?php

try
{
	$f = new DOTNET("SautinSoft.PdfFocus, Version=6.1.1.30, Culture=neutral, PublicKeyToken=0b79b934109b3e9e","SautinSoft.PdfFocus");
	echo "Successfully created an object of PDF Focus .Net!\n";
}
catch (Exception $e)
{
	die ('Component not registered!');
}

/* Convert PDF file to DOCX file */

$f->OpenPdf_3("d:\\simple text.pdf");
if ($f->PageCount>0)
{
	$f->ToWord_2("d:\\simple text.docx");
	echo "Converted successfully!";
}

?>