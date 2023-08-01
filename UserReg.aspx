<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" Inherits="TestWebservice.UserReg" Codebehind="UserReg.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="css/responsive.min.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-2.1.4.min.js" type="text/javascript"></script>
    <link href="css/normalize.css" rel="stylesheet" type="text/css" />
    <script src="js/responsive.min.js" type="text/javascript"></script>
    <style>
        .modalDialog
        {
            position: fixed;
            font-family: Arial, Helvetica, sans-serif;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            background: rgba(0,0,0,0.8);
            z-index: 99999;
            opacity: 0;
            -webkit-transition: opacity 400ms ease-in;
            -moz-transition: opacity 400ms ease-in;
            transition: opacity 400ms ease-in;
            pointer-events: none;
        }
        
        
        .modalDialog:target
        {
            opacity: 1;
            pointer-events: auto;
        }
        
        .modalDialog > div
        {
            width: 1100px;
            height: 600px;
            overflow: scroll;
            position: relative;
            margin: 3% auto;
            padding: 5px 20px 13px 20px;
            border-radius: 10px;
            background: #fff;
            background: -moz-linear-gradient(#fff, #999);
            background: -o-linear-gradient(#fff, #999);
        }
        
        
        .close
        {
            background: #606061;
            color: #FFFFFF;
            line-height: 25px;
            position: absolute;
            right: 0px;
            text-align: center;
            top: 0px;
            width: 24px;
            text-decoration: none;
            font-weight: bold;
            -webkit-border-radius: 12px;
            -moz-border-radius: 12px;
            border-radius: 12px;
            -moz-box-shadow: 1px 1px 3px #000;
            -webkit-box-shadow: 1px 1px 3px #000;
            box-shadow: 1px 1px 3px #000;
        }
        
        .close:hover
        {
            background: #00d9ff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
        <br />
        <br />
        <br />
        <form action="#">
        <div class="row">
     <div class="col-sm-12 col-md-offset-3">

    <div style="margin-top: 10px;" class="col-sm-6  panel panel-default">
                    <div class="panel-body">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    
                        <legend>New User Registration</legend>
                        <div class="row">
                            <div class="col-s-12">
                             <div class="row">
                                    <div class="col-s-4">
                                        <label for="ddlConnection">
                                            Select Staff Category</label>
                                    </div>
                                    <div class="col-s-8"><div class="input-group">
                                        <asp:DropDownList ID="ddlStaffCat" class="form-control" runat="server" placeholder="Selct Staff Category">
                                            <asp:ListItem>Staff</asp:ListItem>
                                            <asp:ListItem>Admin</asp:ListItem>
                                            <asp:ListItem>Accounts</asp:ListItem>
                                            <asp:ListItem>Deliveryperson</asp:ListItem>
                                            <asp:ListItem>Mechanic</asp:ListItem>
                                            <asp:ListItem>Cashier</asp:ListItem>
                                        </asp:DropDownList><span class="input-group-addon add-on"  ><span class="glyphicon glyphicon-chevron-down"></span>
                                    </div></div>
                                </div>
                            
                                 <div style="padding-top:5px;" class="row">
                                    <div class="col-s-4">
                                        <label for="txtName">
                                            Full Name</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Full Name of User" MaxLength="30"></asp:TextBox>
                                    </div>
                                </div>
                                  <div style="padding-top:5px;" class="row">
                                    <div class="col-s-4">
                                        <label for="txtName">
                                            Contact no.</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtContact" BackColor="White" autocomplete="off" class="form-control"
                                                    placeholder="Contact Number Of User" runat="server" MaxLength="10" onkeypress="return AllowNumbers(this, 'txtContact');"
                                                    TabIndex="4"></asp:TextBox>
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="txtContact"
                                                    ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{10,10}$" runat="server"
                                                    ErrorMessage="Invalid mobile number [10 digits only]"></asp:RegularExpressionValidator>
                                                <sup><span id="errmsgContactNo" style="color: red;"></span></sup>
                                    </div>
                                </div>
                                <div style="padding-top:5px;" class="row">
                                    <div class="col-s-4">
                                        <label for="txtUserId">
                                            User Id</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtUserId" runat="server" class="form-control" placeholder="User ID" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="Divpwd" runat="server">
                                <div class="row" style="padding-top: 6px;">
                                    <div class="col-s-4">
                                        <label for="txtPassword">
                                            Password</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtPassword" TextMode="Password" class="form-control" placeholder="Password" 
                                            runat="server" ontextchanged="txtPassword_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 6px;">
                                    <div class="col-s-4">
                                        <label for="txtRepassword">
                                            Re-Type Password</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtRepassword" TextMode="Password" class="form-control" 
                                            placeholder="Re-Type Password" runat="server" ></asp:TextBox>
                                    </div>
                                </div></div>
                     <div class="row">
            <div class="text-center">
                <asp:Button ID="btnSubmit"  class="btn btn-default" runat="server"
                    OnClick="Button1_Click1" Text="Submit" autopostback="true" BackColor="#0066CC"
                    ForeColor="White" />
                <asp:Button ID="btnReset"  runat="server" Text="Reset" BackColor="#0066CC"
                    OnClick="btnReset_Click" class="btn btn-default" autopostback="true" ForeColor="White" />
            </div>
        </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-offset-3">
    <div style="margin-top: 10px;" class="col-sm-6  panel panel-default">
        <div class="panel-body">
            <legend>Active Users</legend>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <asp:GridView ID="grdUserList"  AutoGenerateColumns="False" runat="server" 
                OnRowCommand="gvList_RowCommand" data-page-size="4">
                <Columns>
                     
                    <asp:TemplateField Visible="true" HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="Server" Text='<%# Eval("Name") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="true" HeaderText="Contact No.">
                        <ItemTemplate>
                            <asp:Label ID="lblContact" runat="Server" Text='<%# Eval("UserMob") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField Visible="true" HeaderText="UserID">
                        <ItemTemplate>
                           <asp:Label ID="lblUsername" runat="Server" Text='<%# Eval("Username") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField Visible="true" HeaderText="Type">
                        <ItemTemplate>
                           <asp:Label ID="lblUserType" runat="Server" Text='<%# Eval("UserType") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField Visible="true" HeaderText="Registered On">
                        <ItemTemplate>
                           <asp:Label ID="lblDateCr" runat="Server" Text='<%# Eval("DateCr") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Update" Visible="true">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" Text="Update" runat="server" CommandName="Select" CommandArgument='<%# Eval("UserId")+ ";" +Eval("Name")+ ";" +Eval("UserMob")+ ";" +Eval("Username")+ ";" +Eval("UserType")%>'> </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="GridViewItem" />
                        <HeaderStyle CssClass="GridViewHeader" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" Visible="true">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkRemove" Text="Delete" runat="server" CommandName="Remove" CommandArgument='<%# Eval("UserId")+ ";" +Eval("Name")+ ";" +Eval("UserMob")+ ";" +Eval("Username")+ ";" +Eval("UserType")%>'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="GridViewItem" />
                        <HeaderStyle CssClass="GridViewHeader" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
 </div></div>
   </div>
     <script type="text/javascript">
            function AllowNumbers(e, eleName) {
            var key = window.event ? event.keyCode : event.which;
            if (key != 13 && key != 8 && key != 0 && (key < 48 || key > 57)) {
                return false;
            } 
        }


        $("#<%=btnSubmit.ClientID %>").on("click", function () {

            var valCustomerName = $("#<%=txtName.ClientID %>").val().toString();
            var valCustomerContact = $("#<%=txtContact.ClientID %>").val().toString();
            var valCustomerAddress = $("#<%=txtUserId.ClientID %>").val().toString();
            if (valCustomerName.length <= 0 || valCustomerContact.length <= 0 || valCustomerAddress.length <= 0) {
                alert("Please Enter Complete User's Details");
                return false;
            }
            else {
                return true;
            }
        });


</script>
            
</asp:Content>
