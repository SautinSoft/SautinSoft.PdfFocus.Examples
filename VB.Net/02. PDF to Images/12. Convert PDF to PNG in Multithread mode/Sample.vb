Option Infer On

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.Threading
Imports SautinSoft

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			ConvertPdfToPngInThread()
		End Sub
		Public Class TArgument
			Public Property PdfFile() As String
			Public Property PageNumber() As Integer
		End Class
		Public Shared Sub ConvertPdfToPngInThread()
			Dim pdfs As String = Path.GetFullPath("..\..\..")
			Dim files() As String = Directory.GetFiles(pdfs, "*.pdf")

			Dim threads As New List(Of Thread)()
			For i As Integer = 0 To files.Length - 1
				Dim targ As New TArgument() With {
					.PdfFile = files(i),
					.PageNumber = 1
				}

				Dim t = New Thread(Sub(a) ConvertToPng(a))
				t.Start(targ)
				threads.Add(t)
			Next i

			For Each thread In threads
				thread.Join()
			Next thread
			Console.WriteLine("Done!")
		End Sub

		Public Shared Sub ConvertToPng(ByVal targ As Object)
			Dim targum As TArgument = DirectCast(targ, TArgument)
			Dim pdfFile As String = targum.PdfFile
			Dim page As Integer = targum.PageNumber

			Dim pngFile As String = Path.GetFileNameWithoutExtension(pdfFile) & ".png"

								  ' Get your free 30-day key here:   
			 ' https://sautinsoft.com/start-for-free/

			Dim f As New SautinSoft.PdfFocus()

			f.ImageOptions.ImageFormat = PdfFocus.CImageOptions.ImageFormats.Png
			f.ImageOptions.Dpi = 300

			f.OpenPdf(pdfFile)

			Dim done As Boolean = False

			If f.PageCount > 0 Then
				If page >= f.PageCount Then
					page = 1
				End If

				If f.ToImage(pngFile, page) = 0 Then
					done = True
				End If
				f.ClosePdf()
			End If

			If done Then
				Console.WriteLine("{0}" & vbTab & " - Done!", Path.GetFileName(pdfFile))
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pngFile) With {.UseShellExecute = True})
			Else
				Console.WriteLine("{0}" & vbTab & " - Error!", Path.GetFileName(pdfFile))
			End If
		End Sub
	End Class
End Namespace
