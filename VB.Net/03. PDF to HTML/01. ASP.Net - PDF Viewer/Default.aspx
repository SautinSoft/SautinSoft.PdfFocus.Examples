<%@ Page Language="VB" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="style.css" media="all"/>
</head>
<body>
    <div class="container flex-grow pt-4 h-100">
    <div class="col-12">
    <form class="panel-body" id="form1" runat="server">
        <div class="panel">
            <div class="form-row">
    <div class="form-group col-lg-8 col-md-6 col-sm-12">
        <div class="input-group mb-3" lang="en">
            <asp:FileUpload ID="uplPDF" runat="server" type="file" CssClass="custom-file-input custom-file-input-lg" accept=".pdf"/>
                <label class="custom-file-label" for="uplPDF">Select PDF file...</label>
                <br />
            <asp:Label ID="lblMessage" runat="server" Text="File uploaded successfully." ForeColor="Green" Visible="false" />
            <asp:Button CssClass="btn btn-primary" ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none" />
        </div>
    </div>
    <div class="form-group col-lg-4 col-md-6 col-sm-12">
           <div class="input-group">
        <asp:Button CssClass="btn btn-secondary" ID="btnPrev" runat="server" Text="Prev" OnClick="btnPrev_Click" />&nbsp
        <asp:TextBox ID="txtPage" runat="server" type="text" Cssclass="form-control" aria-describedby="inputGroup-sizing-default"></asp:TextBox>&nbsp;
        <asp:Button CssClass="btn btn-secondary" ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
            </div>
            
    </div>
        </div>
        </div>
        <div class="form-row h-100">
            <div class="form-group col-lg-1 col-md-1 col-sm-1">
                <div class="position-fixed ">
                    <div class="row"><div class="py-2" style="width:37px"><input class="btn btn-secondary rounded-circle" style="width:37px" type="button" value="+" id="zoom-in" /></div></div>
                    <div class="row"><div class="py-2" style="width:37px"><input class="btn btn-secondary rounded-circle" style="width:37px" type="button" value="-" id="zoom-out" /></div></div>
                 </div>
            </div>
            <div class="form-group col-lg-11 col-md-11 col-sm-11">
                <div id="page-window">
                    <asp:Literal ID="htmlLiteral" runat="server" />
                </div>
            </div>
        </div>
    </form>
    </div>
</div>
<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>
<script type="text/javascript">
    $('.custom-file-input').on('change', function () {
        let fileName = $(this).val().split('\\').pop();
        $(this).next('.custom-file-label').addClass("selected").html(fileName);
});</script>
    <script>
        $(document).ready(function () {

            var zoom = 1.0;
            var zoomStep = 0.05;
            var margin = 0;
            var marginStep = 25;

            $('#zoom-in').click(function () {
                margin += marginStep;
                $('#page-window').css({ transform: 'scale(' + (zoom += zoomStep) + ')' });
                var w = $('#page-window').css("width");

                $('#page-window').css({ "margin-left": (margin) });
                $('#page-window').css({ "margin-top": (margin) });
            })
            $('#zoom-out').click(function () {

                margin -= marginStep;

                $('#page-window').css({ transform: 'scale(' + (zoom -= zoomStep) + ')' });
                $('#page-window').css({ "margin-left": margin });
                $('#page-window').css({ "margin-top": margin });


            })
        });
    </script>
    <script type="text/javascript">
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUpload.ClientID %>").click();
            }
        }
    </script>
</body>
</html>
