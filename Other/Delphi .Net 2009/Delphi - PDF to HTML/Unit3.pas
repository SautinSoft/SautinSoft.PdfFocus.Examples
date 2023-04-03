unit Unit3;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, System.ComponentModel, Borland.Vcl.StdCtrls, SautinSoft,
  Borland.Vcl.ExtDlgs, Borland.Vcl.ActnList, Borland.Vcl.ExtCtrls,
  Borland.Vcl.ComCtrls, ShellApi;

type
  TWinForm = class(TForm)
    ButtonConvert: TButton;
    ImageBox: TImage;
    OpenDialog1: TOpenDialog;
    OpenPDF: TButton;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    procedure ButtonConvertClick(Sender: TObject);
    procedure OpenPDFClick(Sender: TObject);
    procedure Label4Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  WinForm: TWinForm;
  f : SautinSoft.PdfFocus;
implementation

{$R *.nfm}

procedure TWinForm.ButtonConvertClick(Sender: TObject);
begin
  f := SautinSoft.PdfFocus.Create;

  f.OpenPdf(OpenDialog1.FileName);
  f.ToHtml('D:\Result.html');
  if f.PageCount > 0 then

  ShellExecute(Application.Handle, nil, 'D:\Result.html', nil, nil,SW_SHOWNORMAL);


end;

procedure TWinForm.Label4Click(Sender: TObject);
begin

       ShellExecute(Application.Handle, nil, 'http://www.sautinsoft.com/products/pdf-focus/order.php', nil, nil,SW_SHOWNOACTIVATE);
end;

procedure TWinForm.OpenPDFClick(Sender: TObject);
begin
 if OpenDialog1.Execute then
      Label1.SetText(OpenDialog1.FileName);
end;

end.
