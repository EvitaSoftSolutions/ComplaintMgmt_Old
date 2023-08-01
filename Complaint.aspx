<%@ Page Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" Inherits="TestWebservice.Complaint" CodeBehind="Complaint.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="css/footable.min.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="js/footable.min.js" type="text/javascript"></script>
    <%--<script src="js/bootstrap.min.js" type="text/javascript"></script>--%>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <br />0
                <br />
                <br />
                <form action="#">
                <div class="row">
                    <div class="col-sm-6" runat="server" id="DivConsumerInfo">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <legend>Consumer Details</legend>
                                <div class="row">
                                    <div class="col-s-12">
                                        <div class="row">
                                            <div class="col-s-3">
                                                <label for="txtName">
                                                    Consumer Type</label></div>
                                            <div class="col-s-9 radio-inline">
                                                <asp:RadioButtonList ID="rdbConsumerType" AutoPostBack="true" RepeatDirection="Horizontal"
                                                    runat="server" OnSelectedIndexChanged="rdbConsumerType_SelectedIndexChanged">
                                                    <asp:ListItem Value="1">Existing Consumer</asp:ListItem>
                                                    <asp:ListItem Value="2">New Consumer</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group">
                                                <div style="padding-top: 5px;" class="col-s-3">
                                                    <label for="txtConsumerNo">
                                                        Consumer No.</label>
                                                </div>
                                                <div class="col-sm-9" style="width: 70%; padding-left: 0px;">
                                                    <div class="input-group">
                                                        <asp:TextBox ID="txtConsumerNo" BackColor="White" onkeypress="return AllowNumbers(this, 'txtConsumerNo');"
                                                            autocomplete="off" class="form-control" placeholder="Consumer Number" runat="server"
                                                            MaxLength="15" TabIndex="1"></asp:TextBox>
                                                        <span class="input-group-btn">
                                                            <asp:Button ID="GetConsNO" BackColor="White" runat="server" Text="Go.." class="form-control"
                                                                Style="margin-left: 0px;" OnClick="btnGetCons_Click" autopostback="true" TabIndex="2" />
                                                        </span>
                                                    </div>
                                                    <div>
                                                        <sup><span id="errmsgConsumerNo" style="color: red;"></span></sup>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="padding-top: 5px;" class="row">
                                            <div class="col-s-3">
                                                <label for="txtName">
                                                    Name</label>
                                            </div>
                                            <div class="col-s-9">
                                                <asp:TextBox ID="txtName" autocomplete="off" runat="server" class="form-control"
                                                    placeholder="Consumer Name" ReadOnly="true" MaxLength="70" BackColor="White"
                                                    TabIndex="3"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row" style="padding-top: 6px;">
                                            <div class="col-s-3">
                                                <label for="txtContact">
                                                    Contact No.</label>
                                            </div>
                                            <div class="col-s-9">
                                                <asp:TextBox ID="txtContact" BackColor="White" autocomplete="off" class="form-control"
                                                    placeholder="Contact Number" runat="server" MaxLength="10" onkeypress="return AllowNumbers(this, 'txtContact');"
                                                    TabIndex="4"></asp:TextBox>
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="txtContact"
                                                    ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{10,10}$" runat="server"
                                                    ErrorMessage="Invalid mobile number [10 digits only]"></asp:RegularExpressionValidator>
                                                <sup><span id="errmsgContactNo" style="color: red;"></span></sup>
                                            </div>
                                        </div>
                                        <div class="row" style="padding-top: 6px;">
                                            <div class="col-s-3">
                                                <label for="txtName">
                                                    Address</label>
                                            </div>
                                            <div class="col-s-9">
                                                <asp:TextBox ID="txtAddress" BackColor="White" Style="resize: none;" Rows="3" runat="server"
                                                    TextMode="MultiLine" class="form-control" placeholder="Consumer Address" MaxLength="200"
                                                    TabIndex="5"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row" style="padding-top: 6px;">
                                            <div class="col-s-3">
                                                <label for="txtName">
                                                    Complaint Type</label>
                                            </div>
                                            <div class="col-s-9">
                                                <asp:RadioButtonList ID="rdbComplaintType" AutoPostBack="true" RepeatLayout="Table"
                                                    TextAlign="Right" RepeatDirection="Horizontal" runat="server" OnSelectedIndexChanged="rdbComplaintType_SelectedIndexChanged1"
                                                    RepeatColumns="3">
                                                    <asp:ListItem Value="1"> Complaints</asp:ListItem>
                                                    <asp:ListItem Value="2"> Request</asp:ListItem>
                                                    <asp:ListItem Value="3"> Enquiry</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6" runat="server" visible="false" id="DivRequest">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <legend>Request For...</legend>
                                <div class="row">
                                    <asp:GridView ID="GvRequest" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblchkbox" runat="server" Text="Select"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="Reqchkbox" runat="server" />
                                                    <span id="ReqchkboxText" style="display: none">
                                                        <%# Eval("Requests") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="RequestID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRequestID" runat="Server" Text='<%# Eval("RequestListID") %>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="GridViewItem" />
                                                <HeaderStyle CssClass="GridViewHeader" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Requests" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRequests" runat="Server" Text='<%# Eval("Requests") %>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="GridViewItem" />
                                                <HeaderStyle CssClass="GridViewHeader" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIsOpen" runat="Server" Text='<%# Eval("IsOpen") %>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="GridViewItem" />
                                                <HeaderStyle CssClass="GridViewHeader" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="row">
                                        <div class="col-s-3">
                                            <label for="txtRemark">
                                                Remarks</label>
                                        </div>
                                        <div class="col-s-9">
                                            <asp:TextBox ID="txtReqRemark" runat="server" class="form-control" placeholder="(Enter Ref. Id)"
                                                MaxLength="50"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6" visible="false" runat="server" id="DivEnquiry">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <legend>Enquiry Details</legend>
                                <div class="row">
                                    <asp:GridView ID="GvEnquiry" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblchkbox" runat="server" Text="Select"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="Enqchkbox" runat="server" />
                                                    <span id="EnquiryText" style="display: none">
                                                        <%# Eval("Enquiry")%></span> <span id="EnquiryID" style="display: none">
                                                            <%# Eval("EnquiryListID")%></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="EnquiryID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiryID" runat="Server" Text='<%# Eval("EnquiryListID") %>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="GridViewItem" />
                                                <HeaderStyle CssClass="GridViewHeader" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Enquiry" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiry" runat="Server" Text='<%# Eval("Enquiry") %>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="GridViewItem" />
                                                <HeaderStyle CssClass="GridViewHeader" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="row">
                                        <div class="col-s-3">
                                            <label for="txtRemark">
                                                Remarks</label>
                                        </div>
                                        <div class="col-s-9">
                                            <asp:TextBox ID="txtEnquiryRemark" runat="server" class="form-control" placeholder="(Enter Ref. Id)"
                                                MaxLength="50"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6" runat="server" id="DivComplaint">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <legend>Complaint Details</legend>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="row">
                                            <div class="col-sm-2">
                                                <label for="txtComplaints">
                                                    Complaint</label>
                                            </div>
                                            <div class="col-s-5">
                                                  <div class="input-group">
                                                <asp:DropDownList ID="ddlcomplaintlist" runat="server" class="form-control">
                                                </asp:DropDownList><span class="input-group-addon add-on"  ><span class="glyphicon glyphicon-chevron-down"></span>
                                            </div></div>
                                            <div class="col-s-4" style="margin-left: -4%">
                                                <asp:TextBox ID="txtComplaints" runat="server" class="form-control" placeholder="Complaint Detail"
                                                    MaxLength="50" Style="display: none;"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div style="padding-top: 5px;" class="row">
                                            <div class="col-sm-2">
                                                <label for="ddlMachenic1">
                                                    Mechanic</label>
                                            </div>
                                            <div class="col-s-4">
                                           
                                                <asp:DropDownList ID="ddlMachenic1" BackColor="White" runat="server" class="form-control"
                                                    Enabled="False">
                                                </asp:DropDownList>
                                           </div>
                                            <div class="col-s-4" style="margin-left: -4%">
                                                <asp:TextBox ID="txtMachContact" runat="server" BackColor="White" 
                                                    class="form-control" placeholder="Mechanic Contact" MaxLength="10" ForeColor="Black"></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                        <div style="padding-top: 5px;" class="row">
                                            <div class="col-s-2">
                                            </div>
                                            <div class="col-s-3">
                                                <asp:CheckBox ID="chkSMS" Enabled="false" Text="Send SMS" runat="server" />
                                                <%--<asp:CheckBox ID="chkSendSMS" Enabled="false" Text="Send SMS" runat="server" />--%>
                                            </div>
                                            <div class="col-s-3">
                                                <asp:CheckBox ID="chkCRC" Enabled="false" Text="CRC Call" runat="server" />
                                            </div>
                                        </div>
                                        <div style="padding-top: 5px;" class="row">
                                            <div class="col-sm-2">
                                                <label for="ddlMachenic1">
                                                    Note/Remark</label>
                                            </div>
                                            <div class="col-s-8">
                                                <asp:TextBox ID="txtNote" ReadOnly="true" BackColor="White" Rows="2" runat="server"
                                                    class="form-control" placeholder="Note / Remark" MaxLength="20"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="text-center">
                        <%--<button type="button"  id="btn" style="width:20% BackColor="#0066CC" ForeColor="White" "class="btn btn-default"  data-toggle="modal" data-target="#Complaintinfo">Submit</button>--%>
                        <input type="button" id="btnConfirm" style="background-color: #0066CC; width: 20%;
                            color: White" title="Submit" value="Submit" />
                        <asp:Button ID="btnSubmit" Style="width: 20%; display: none;"
                            runat="server" Text="Submit" autopostback="true" BackColor="#0066CC" ForeColor="White" />
                        <asp:Button ID="btnReset" Style="width: 20%;" runat="server" Text="Reset" BackColor="#0066CC"
                            OnClick="btnReset_Click" class="btn btn-default" autopostback="true" ForeColor="White" />
                        <asp:HiddenField ID="hdnUpdateID" runat="server" />
                    </div>
                </div>
                <div class="container">
                    <div style="margin-top: 10px;" class="panel panel-default">
                        <div class="panel-body">
                            <legend>Previous Complaints.
                                <asp:Label ID="lblcount" runat="server" Style="margin-left: 60%;" Font-Italic="True"
                                    ForeColor="#0066CC" Font-Size="Medium"></asp:Label></legend>
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                            <%-- <asp:GridView ID="grdComplaint" runat="server">
                        </asp:GridView>--%>
                            <asp:GridView ID="grdComplaint" CssClass="footable" runat="server" PageSize="10"
                                AutoGenerateColumns="false" AllowPaging="true" data-page-size="4" OnRowCommand="gvList_RowCommand"
                                OnPageIndexChanging="grdComplaint_PageIndexChanging">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" PreviousPageText="Previous" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="true">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkResolve" Text='<%# Eval("ID") %>' runat="server" CommandName="Select"
                                                CommandArgument='<%#Eval("ID") %>' ToolTip="Resolve Complaint"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="GridViewItem" />
                                        <HeaderStyle CssClass="GridViewHeader" />
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
                                    <asp:TemplateField HeaderText="Complaint" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldetails" runat="Server" Text='<%# Eval("Complaints") %>' />
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
                                            <asp:Label ID="lblusername" runat="Server" Text='<%# Eval("Created By") %>' />
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
                                            <asp:Label ID="lbltime" runat="Server" Text='<%# Eval("Status") %>' />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="GridViewItem" />
                                        <HeaderStyle CssClass="GridViewHeader" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <a href="#modalEnquiry" data-toggle="modal">Todays Enquiry </a>
                    <!-- Enquiry Modal -->
                    <div class="modal-dialog modal-lg">
                        <div class="modal fade" id="modalEnquiry" role="dialog">
                            <!-- Modal content-->
                            <div class="modal-content " style="z-index: 1041;">
                                <div class="modal-body">
                                    <a href="#close" title="Close" data-dismiss="modal" class="close">X</a>
                                    <h2>
                                        Todays Enquiries
                                        <asp:Label ID="lblEnqCount" runat="server" Style="margin-left: 60%;" Font-Italic="True"
                                            ForeColor="#0066CC" Font-Size="Medium"></asp:Label></h2>
                                    <asp:Label ID="lblMsg1" runat="server"></asp:Label>
                                    <asp:GridView ID="grdEnquiry" runat="server">
                                    </asp:GridView>
                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                        Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--Complaint Modal -->
                    <div class="modal fade" data-backdrop="static" data-keyboard="false" aria-hidden="true"
                        id="myModal" role="dialog">
                        <div class="modal-dialog" style="z-index: inherit;">
                            <!-- Modal content-->
                            <div class="modal-content ">
                                <div class="modal-body">
                                    <div class="panel panel-default">
                                        <div class="panel-body">
                                            <h3>
                                                Please confirm following details before submitting !</h3>
                                                <h4><span id="smswarning"  style=" display: none; text-decoration: blink; color: #FF0000">SMS option is not selected ! SMS will not be sent ! </span>
                                                
                                                </h4>
                                            <table class="table">
                                                <tr>
                                                    <th>
                                                        Consumer No.
                                                    </th>
                                                    <td>
                                                        <asp:Label ID="lblCNo" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        Name
                                                    </th>
                                                    <td>
                                                        <asp:Label ID="lblcName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        Contact
                                                    </th>
                                                    <td>
                                                        <asp:Label ID="lblcContact" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        Address
                                                    </th>
                                                    <td>
                                                        <asp:Label ID="lblcAddress" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <span id="spanComplaintType"></span>
                                                    </th>
                                                    <td>
                                                        <asp:Label ID="lblcComplaint" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <span id="spanMachName" style="display: none;">Mechanic</span>
                                                    </th>
                                                    <td>
                                                        <asp:Label ID="lblmachName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                        Edit</button>
                                    <asp:Button ID="submit" class="btn btn-default" BackColor="#0066CC" ForeColor="White"
                                        runat="server" Text="Submit" />
                                    <asp:Button ID="updateData" runat="server" OnClick="submit_Click" CausesValidation="false"
                                        Style="display: none" />
                                    <input type="hidden" id="hdnSubmitClickedCount" value="0" />
                                </div>
                            </div>
                        </div>  
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <script type="text/javascript">

        function OnStatusChange() {
       
            $("#<%=ddlcomplaintlist.ClientID %>").on("change", function () {
                var value = $("#<%=ddlcomplaintlist.ClientID %> option:selected").text();
                if (value == "--Select--") {
                    $("#<%=ddlMachenic1.ClientID %>").attr("disabled", "disabled");
                    $("#<%=txtComplaints.ClientID %>").css('display', 'none');
                    $("#<%=chkSMS.ClientID %>").attr("disabled", "disabled");
                    $("#<%=chkSMS.ClientID %>").attr("checked", false);
                    $("#<%=chkCRC.ClientID %>").attr("disabled", "disabled");
                    $("#<%=chkCRC.ClientID %>").attr("checked", false);
                    $("#<%=txtNote.ClientID %>").val("");
                    $("#<%=txtNote.ClientID %>").attr("readonly", true);
                    $("#<%=txtMachContact.ClientID %>").val("");
                    $("#<%=ddlMachenic1.ClientID %>").prop('selectedIndex', 0);
                 }
                else if (value == "OTHERS") {
                    $("#<%=txtComplaints.ClientID %>").val("");
                    $("#<%=txtComplaints.ClientID %>").css('display', 'block');
                    $("#<%=ddlMachenic1.ClientID %>").removeAttr("disabled");
                }
                else {
                    $("#<%=ddlMachenic1.ClientID %>").removeAttr("disabled");
                    $("#<%=txtComplaints.ClientID %>").css('display', 'none');
                }
            });

           // $("#<%=ddlcomplaintlist.ClientID %>").trigger('change');
           // $("#<%=ddlMachenic1.ClientID %>").trigger('change');

            $("#<%=ddlMachenic1.ClientID %>").on("change", function () {
                var value = $("#<%=ddlMachenic1.ClientID %> option:selected").text();

                if (value == "--Select--") {
                    $("#<%=txtMachContact.ClientID %>").val("");
                    $("#<%=chkSMS.ClientID %>").attr("disabled", "disabled");
                    $("#<%=chkSMS.ClientID %>").attr("checked", false);
                    $("#<%=chkCRC.ClientID %>").attr("disabled", "disabled");
                    $("#<%=chkCRC.ClientID %>").attr("checked", false);
                    $("#<%=txtNote.ClientID %>").val("");
                    $("#<%=txtNote.ClientID %>").attr("readonly", true);
                }
                else {
                    getmachcontact();
                    $("#<%=chkSMS.ClientID %>").attr("checked", true);
                    $("#<%=chkCRC.ClientID %>").removeAttr("disabled");
                    $("#<%=chkSMS.ClientID %>").removeAttr("disabled");
                    $("#<%=txtNote.ClientID %>").attr("readonly", false);
                }

            });

        }

        function getmachcontact() {
           $.ajax({

                type: 'POST',
                url: 'Complaint.aspx/getmachcontact',
                data: JSON.stringify({
                    Mach: $("#<%=ddlMachenic1.ClientID %>").val()
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == null) {
                        return false;
                    }
                    else {
                        $("#<%=txtMachContact.ClientID %>").val(data.d);
                        return true;
                    }
                },
                failure: function (data) {
                    alert("Falla - " + data);
                }
            });


        }

        


    </script>
    <script type="text/javascript">
        function ShowDialog() {
           
            //alert("ShowDialog");
            var valCustomerNo = $("#<%=txtConsumerNo.ClientID %>").val();
            var valCustomerName = $("#<%=txtName.ClientID %>").val();
            var valCustomerContact = $("#<%=txtContact.ClientID %>").val();
            var valCustomerAddress = $("#<%=txtAddress.ClientID %>").val();
            var valMachenicName = $("#<%=ddlMachenic1.ClientID %> option:selected").text();
            
            if (valCustomerNo.length <= 0 || valCustomerName.length <= 0 || valCustomerContact.length <= 0 || valCustomerAddress.length <= 0) {
                alert("Please Enter all Details of Consumer.");
                return false;
            }
            $("#<%=lblCNo.ClientID %>").html(valCustomerNo);
            $("#<%=lblcName.ClientID %>").html(valCustomerName);
            $("#<%=lblcContact.ClientID %>").html(valCustomerContact);
            $("#<%=lblcAddress.ClientID %>").html(valCustomerAddress);
            var checked_radio = $("#<%=rdbComplaintType.ClientID %> input:checked");
            var value = checked_radio.val();
            var text = checked_radio.closest("td").find("label").html();
            $("#spanComplaintType").text(text);
            var Counter = "0";
            var lblcComplaintText = "";

            if (value == "1") {
               
                var checksms = $("#<%=chkSMS.ClientID %>").is(":checked");
                var valMachContactno = $("#<%=txtMachContact.ClientID %>").val();
                if ($("#<%=ddlcomplaintlist.ClientID %> option:selected").text() != "OTHERS") {
                    var valCustomerComplaint = $("#<%=ddlcomplaintlist.ClientID %> option:selected").text()
                }
                else {
                    var valCustomerComplaint = $("#<%=txtComplaints.ClientID %>").val();
                }
                if (valCustomerComplaint.length <= 0 || valCustomerComplaint == "--Select--") {
                    alert("Please Enter Complaint Details.");
                    return false;
                }
                else if (valMachContactno.length <= 0) {
                    alert("Please Select Mechanic");
                    return false;
                }
                $("#<%=lblcComplaint.ClientID %>").html(valCustomerComplaint);
                $("#spanMachName").css('display', 'block');
               
                if (checksms) {
                    $("#smswarning").css('display', 'none');
                }
                else { $("#smswarning").css('display', 'block'); }

                $("#<%=lblmachName.ClientID %>").html(valMachenicName);

                lblcComplaintText = valCustomerComplaint;
            }
            else if (value == "2") {

                var chkList = $("[id*=Reqchkbox]");
                var chkListText = "";

                if (chkList.length > 0) {
                    for (var b = 0; b < chkList.length; b++) {
                        var chkID = $(chkList[b]).attr("id");
                        if ($("#" + chkID).prop("checked") == "true" || $("#" + chkID).prop("checked") == true) {
                            Counter = Counter + 1;
                            var chkText = $("#" + chkID).parent().find("#ReqchkboxText").html();
                            lblcComplaintText = lblcComplaintText.length <= 0 ? chkText : lblcComplaintText + ", " + chkText;

                        }
                    }
                }

                if (Counter <= 0) {

                    alert("Please Select Request");
                    return false;
                }
            }
            else if (value == "3") {
                var chkList = $("[id*=Enqchkbox]");
                var chkListText = "";
                if (chkList.length > 0) {
                    for (var b = 0; b < chkList.length; b++) {
                        var chkID = $(chkList[b]).attr("id");
                        if ($("#" + chkID).prop("checked") == "true" || $("#" + chkID).prop("checked") == true) {
                            Counter = Counter + 1;
                            var chkText = $("#" + chkID).parent().find("#EnquiryText").html();
                            var chkID = $("#" + chkID).parent().find("#EnquiryID").html();
                            lblcComplaintText = lblcComplaintText.length <= 0 ? chkText : lblcComplaintText + ", " + chkText;
                        }
                    }
                }
                if (Counter <= 0) {

                    alert("Please Select Enquiry");
                    return false;
                }
            }

            //display complaint type/checked text list
            $("#<%=lblcComplaint.ClientID %>").html(lblcComplaintText);

            //event.preventDefault();
            jQuery.noConflict();
            $("#myModal").modal('show');
            $('#myModal').modal({
                backdrop: 'static',
                keyboard: false
            })

        }

        function OnPopUpSubmitClick() {
            var tmpClickCount = $("#hdnSubmitClickedCount").val();
            $("#myModal").modal('hide');
            var complaintType = parseInt($("#<%=rdbComplaintType.ClientID %> :checked").val());
            
            //check duplicates for complaints only
            if (complaintType == 1) {

                if (parseInt(tmpClickCount) <= 0) {

                    $("#hdnSubmitClickedCount").val("1");
                   
                    if ($("#<%=ddlcomplaintlist.ClientID %> option:selected").text() != "OTHERS") {
                        var valCustomerComplaint = $("#<%=ddlcomplaintlist.ClientID %> option:selected").text()
                    }
                    else {
                        var valCustomerComplaint = $("#<%=txtComplaints.ClientID %>").val();
                    }

                    if ($("#<%=hdnUpdateID.ClientID %>").val() == "") {

                        $.ajax({
                            type: 'POST',
                            url: 'Complaint.aspx/CheckForDuplicateComplaint',
                            data: JSON.stringify({
                                ConNo: $("#<%=txtConsumerNo.ClientID %>").val(),
                                ConName: $("#<%=txtName.ClientID %>").val(),
                                ConContact: $("#<%=txtContact.ClientID %>").val(),
                                ConComplaint: valCustomerComplaint
                            }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",

                            success: function (data) {
                                if (data.d == null) {
                                    $("#<%=updateData.ClientID %>").trigger("click");
                                    return true;
                                }
                                else {
                                    alert("The Complaint For This Connsumer Already Exsists with Complaint ID: " + data.d);
                                    return false;
                                }
                            },
                            failure: function (data) {
                                alert("Falla - " + data);
                            }
                        });
                    }
                    else {
                        $("#<%=updateData.ClientID %>").trigger("click");
                    }
                }

            }


            else {
                $("#<%=updateData.ClientID %>").trigger("click");
            }
        }



        function InIEvent() {

            $(function () {
                $('[id*=grdComplaint]').footable();
                $('[id*=grdComplaint] tr :last').closest('table').closest('tr').find('td').show();
                $(window).resize(function () {
                    location.reload();
                });
                $('[id*=grdComplaint] tr :last').closest('table').closest('tr').on('click', function () {
                    $(this).next('tr').hide();
                });
            });

            $("#btnConfirm").click(function (e) {
                e.preventDefault();
                ShowDialog();
            });

            $("#<%=submit.ClientID %>").on("click", function (e) {
                e.preventDefault();
                OnPopUpSubmitClick();
//                window.setTimeout(function () {
//                    OnPopUpSubmitClick();
//                }, 500);
            });

            OnStatusChange();

        }


        $(document).ready(function () {
            InIEvent();
        });
        Sys.Application.add_load(InIEvent);
        
    </script>
    <script type="text/javascript">

        function AllowNumbers(e, eleName) {
            var key = window.event ? event.keyCode : event.which;
            if (key != 13 && key != 8 && key != 0 && (key < 48 || key > 57)) {
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
