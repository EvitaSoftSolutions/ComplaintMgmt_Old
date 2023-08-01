<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="Enquiry_Reports.aspx.cs" Inherits="TestWebservice.Enquiry_Reports" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="css/responsive.min.css" rel="stylesheet" type="text/css" />
   
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui.min.js" type="text/javascript"></script>
     <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
   



     <script type="text/javascript">

         function AllowNumbers(e, eleName) {
             var key = window.event ? event.keyCode : event.which;
             //console.log(key);

             //if the letter is not digit then display error and don't type anything
             if (key != 8 && key != 0 && (key < 48 || key > 57)) {
                 //display error message

                 switch (eleName) {
                     case "txtConsumerNo":
                         $("#errmsgContactNo").hide();
                         $("#errmsgConsumerNo").html("Digits Only").show().delay(1000).fadeOut("slow");
                         break;
                     case "txtContact":
                         $("#errmsgConsumerNo").hide();
                         $("#errmsgContactNo").html("Digits Only").show().delay(1000).fadeOut("slow");
                         break;
                     default:
                         $("#errmsgConsumerNo").hide();
                         $("#errmsgContactNo").hide();
                         break;
                 }

                 return false;
             }
         }



         
    </script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript">

        //attach datepicker to textboxes
        function InIEvent() {

            $("#<%=txtfromdate.ClientID %>").datepicker({
                numberOfMonths: 1,

                onSelect: function (selected) {
                    var dt = new Date(selected);
                    dt.setDate(dt.getDate() );
                    $("#<%=txttodate.ClientID %>").datepicker("option", "minDate", dt);
                    $("#<%=txtfromdate.ClientID %>").datepicker("option", "dateFormat", "dd/mm/yy");
                }
            });
            $("#<%=txttodate.ClientID %>").datepicker({
                numberOfMonths: 1,

                onSelect: function (selected) {
                    var dt = new Date(selected);
                    dt.setDate(dt.getDate() );
                    $("#<%=txtfromdate.ClientID %>").datepicker("option", "maxDate", dt);
                    $("#<%=txttodate.ClientID %>").datepicker("option", "dateFormat", "dd/mm/yy");
                }
            });

            $("#divLoader").css("display", "none");
        }

        function BeginRequestHandler() {
            $("#divLoader").css("display", "block");
        }

        //set datepicker when page loads
        $(document).ready(InIEvent);

        //set datepicker when update panel request ends
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <form id="Form1" action="#" method="post" class="form-horizontal">
                <div class="panel panel-default" style="padding: 10px;">
                    <div class="panel-body">
                        <legend>Enquiry Reports</legend>
                        <div class="row">
                            <div class="col-s-6">
                                 <div class="row" style="padding-top: 6px;">
                                    <div class="col-s-3">
                                        <label for="ddlUser">
                                            Users </label>
                                    </div>
                                    <div class="col-s-8"><div class="input-group">
                                        <asp:DropDownList ID="ddlUser"  runat="server" class="form-control">
                                        </asp:DropDownList><span class="input-group-addon add-on"  ><span class="glyphicon glyphicon-chevron-down"></span>
                                    </div></div>
                                </div>
                                 <div class="row" style="padding-top: 6px;">
                                    <div class="col-s-3">
                                        <label for="ddlEnquiry">
                                            Enquiry Type </label>
                                    </div>
                                    <div class="col-s-8"><div class="input-group">
                                        <asp:DropDownList ID="ddlEnquiry"  runat="server" class="form-control">
                                        </asp:DropDownList><span class="input-group-addon add-on"  ><span class="glyphicon glyphicon-chevron-down"></span>
                                    </div></div>
                                </div>
                                 </div>
                            <div class="col-s-6">
                             
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-s-2">
                                            <label for="txtfromdate">
                                                From Date</label>
                                        </div>
                                        <div class="col-s-5">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtfromdate"  class="form-control" autocomplete="off" placeholder="From Date"
                                                    runat="server"></asp:TextBox>
                                                 <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span>
                                                
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-s-2">
                                            <label for="txttodate">
                                                To Date</label>
                                        </div>
                                        <div class="col-s-5">
                                            <div class="input-group">
                                                <asp:TextBox ID="txttodate" class="form-control" autocomplete="off" placeholder="To Date"
                                                    runat="server"></asp:TextBox>
                                                <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span>
                                                </div>
                                        </div>
                                    </div>
                                
                            </div>
                        </div>
                        <div class="row" style="padding-top: 15px;">
                            <div class="text-center">
                                <asp:Button ID="btnSubmit" Style="width: 20%;" class="btn btn-default" runat="server"
                                    Text="Search" autopostback="true" BackColor="#0066CC" ForeColor="White" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnReset" Style="width: 20%;" runat="server" Text="Reset" BackColor="#0066CC"
                                    class="btn btn-default" autopostback="true" ForeColor="White" OnClick="btnReset_Click" />
                             <asp:Label ID="lblcount" Style="margin-left: 10%;"  runat="server" Font-Italic="True" ForeColor="#0066CC" Font-Size="Medium"></asp:Label>
                           
                            </div>
                        </div>
                    </div>
                </div>

                <div id="divLoader" class="loading" align="center">
                Loading. Please wait.<br />
                <br />
                <img src="img/fancybox_loading.gif" alt="Loading" />
            </div>

                <asp:GridView ID="gvList" Visible="false" runat="server">
                </asp:GridView>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <br />
                <asp:Label ID="te" runat="server"></asp:Label>
                </form>
            
            <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Width="100%" ShowBackButton="False" ShowCredentialPrompts="False" ShowDocumentMapButton="False" ShowParameterPrompts="False" ShowPrintButton="False" ShowToolBar="True">
            </rsweb:ReportViewer>
        </div></ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
