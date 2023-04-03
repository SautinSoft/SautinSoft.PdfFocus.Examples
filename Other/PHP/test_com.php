<?php

try
{
	$f = new COM("SautinSoft.PdfFocus");
	echo "Successfully created a COM object of PDF Focus .Net!\n";
}
catch (Exception $e)
{
	die ('Component is not registered!');
}

/* Convert PDF file to DOCX file */

$f->OpenPdf_3("d:\\simple text.pdf");
if ($f->PageCount>0)
{
	$f->ToWord_2("d:\\simple text.docx");
	echo "Converted successfully!";
}

?>
