<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    Inherits="TestWebservice.WebForm3" CodeBehind="Resolve.aspx.cs" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link href="css/responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="css/footable.min.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui.min.js" type="text/javascript"></script>
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="js/footable.min.js" type="text/javascript"></script>
   
     <script type="text/javascript">
         $(function () {
             $('[id*=grdComplaint]').footable();
         });
    </script>
    
    <script type="text/javascript">

        function AllowNumbers(e, eleName) {
            var key = window.event ? event.keyCode : event.which;
            //console.log(key);

            //if the letter is not digit then display error and don't type anything
            if (key != 13 && key != 8 && key != 0 && (key < 48 || key > 57)) {
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
                    case "txtComplaintID":
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
  
    <style type="text/css">
        .modal
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        .loading
        {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            margin-left: 250px;
            z-index: 999;
        }
    </style>
   
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
                        <legend>Search Complaints</legend>
                        <div class="row">
                            <div class="col-s-6">
                                <div class="row">
                                    <div class="col-s-3">
                                        <label for="txtComplaintId">
                                            Complaint ID.</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtComplaintId" autocomplete="off" onkeypress="return AllowNumbers(this, 'txtComplaintID');"
                                            runat="server" class="form-control" placeholder="Complaint ID." MaxLength="10"></asp:TextBox>
                                        <sup><span id="errmsgConsumerNo" style="color: red;"></span></sup>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 6px;">
                                    <div class="col-s-3">
                                        <label for="txtConsumerNo">
                                            Consumer No.</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtConsumerNo" autocomplete="off" onkeypress="return AllowNumbers(this, 'txtContact');"
                                            class="form-control" placeholder="Consumer No."  MaxLength="15" runat="server"></asp:TextBox>
                                        <sup><span id="errmsgContactNo" style="color: red;"></span></sup>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 6px;">
                                    <div class="col-s-3">
                                        <label for="ddlMachenic">
                                            Mechanic</label>
                                    </div>
                                    <div class="col-s-8">
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddlMachenic"  runat="server" class="form-control">
                                        </asp:DropDownList><span class="input-group-addon add-on"  ><span class="glyphicon glyphicon-chevron-down"></span>
                                    </div></div>
                                </div>
                            </div>
                            <div class="col-s-6">
                              <div class="row" style="padding-top: 6px;">
                                    <div class="col-s-3">
                                     <label for="txtConsumerNo">
                                            Contact No.</label>
                                    </div>
                                    <div class="col-s-5">
                                        <asp:TextBox ID="txtContact" autocomplete="off" onkeypress="return AllowNumbers(this, 'txtContact');"
                                            class="form-control" placeholder="Contact No."  MaxLength="15" runat="server"></asp:TextBox>
                                        <sup><span id="Span1" style="color: red;"></span></sup>
                                    </div>
                                </div>

                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-s-3">
                                            <label for="txtfromdate">
                                                From Date</label>
                                        </div>
                                        <div class="col-s-5">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtfromdate"  BackColor="White" class="form-control" autocomplete="off" placeholder="From Date"
                                                    runat="server"></asp:TextBox>
                                                 <span  class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span>
                                                
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-s-3">
                                            <label for="txttodate">
                                                To Date</label>
                                        </div>
                                        <div class="col-s-5">
                                            <div class="input-group">
                                                <asp:TextBox ID="txttodate"  BackColor="White"  class="form-control" autocomplete="off" placeholder="To Date"
                                                    runat="server"></asp:TextBox>
                                                <span class="input-group-addon add-on"  ><span class="glyphicon glyphicon-calendar"></span>
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
                <asp:GridView ID="gvList" runat="server" CssClass="footable" AutoGenerateColumns="False" OnRowCommand="gvList_RowCommand">
                   <Columns>
                        <asp:TemplateField Visible="true" HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblClientID" runat="Server" Text='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Consumer No" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="Server" Text='<%# Eval("ConsumerNo") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GridViewItem" />
                            <HeaderStyle CssClass="GridViewHeader" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="Server" Text='<%# Eval("Name") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GridViewItem" />
                            <HeaderStyle CssClass="GridViewHeader" />
                        </asp:TemplateField>
                              <asp:TemplateField HeaderText="Contact" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lblcontact" runat="Server" Text='<%# Eval("Contact") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GridViewItem" />
                            <HeaderStyle CssClass="GridViewHeader" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Complaint" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lbldetails" runat="Server" Text='<%# Eval("Complaint") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GridViewItem" />
                            <HeaderStyle CssClass="GridViewHeader" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mechanic" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lblmachenic" runat="Server" Text='<%# Eval("Machenic") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GridViewItem" />
                            <HeaderStyle CssClass="GridViewHeader" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Created By" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lblusername" runat="Server" Text='<%# Eval("CreatedBy") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GridViewItem" />
                            <HeaderStyle CssClass="GridViewHeader" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Created On" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lbldate" runat="Server" Text='<%# Eval("Created On") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GridViewItem" />
                            <HeaderStyle CssClass="GridViewHeader" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lbltime" runat="Server" Text='<%# Eval("Time") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GridViewItem" />
                            <HeaderStyle CssClass="GridViewHeader" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Status" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="Server" Text='<%# Eval("ComplaintStatus") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GridViewItem" />
                            <HeaderStyle CssClass="GridViewHeader" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Resolve" Visible="true">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkResolve" Text="Resolve" runat="server" CommandName="Select" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle CssClass="GridViewItem" />
                            <HeaderStyle CssClass="GridViewHeader" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Update" Visible="true">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkUpdate" Text="Update" runat="server" CommandName="Update" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle CssClass="GridViewItem" />
                            <HeaderStyle CssClass="GridViewHeader" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table cellpadding="0" cellspacing="0" class="GridViewEmpty">
                            <tr>
                                <td class="Title" style="width: 10%">
                                    <asp:Literal ID="Literal6" runat="server" Text="No record found." />
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <br />
                <asp:Label ID="te" runat="server"></asp:Label>
                </form>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
