<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="Pwdchange.aspx.cs" Inherits="TestWebservice.Pwdchange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/responsive.min.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-2.1.4.min.js" type="text/javascript"></script>
    <link href="css/normalize.css" rel="stylesheet" type="text/css" />
    <script src="js/responsive.min.js" type="text/javascript"></script>
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
                        <legend>Password Manager</legend>
                        <div class="row">
                            <div class="col-s-12">
                                <div style="padding-top: 5px;" class="row">
                                    <div class="col-s-4">
                                        <label for="txtUserId">
                                            User Id</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtUId" autocomplete="off" runat="server" class="form-control" placeholder="User ID"
                                            MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 6px;">
                                    <div class="col-s-4">
                                        <label for="txtPassword">
                                            Old Password</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtoldpwd" autocomplete="off" TextMode="Password" class="form-control"
                                            placeholder="Old Password" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="Divpwd" runat="server">
                                    <div class="row" style="padding-top: 6px;">
                                        <div class="col-s-4">
                                            <label for="txtPassword">
                                                New Password</label>
                                        </div>
                                        <div class="col-s-8">
                                            <asp:TextBox ID="txtnewPwd" autocomplete="off" TextMode="Password" class="form-control"
                                                placeholder="New Password" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 6px;">
                                        <div class="col-s-4">
                                            <label for="txtRepassword">
                                                Re-Type New Password</label>
                                        </div>
                                        <div class="col-s-8">
                                            <asp:TextBox ID="txtRepwd" autocomplete="off" TextMode="Password" class="form-control"
                                                placeholder="Re-Type Password" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="text-center">
                                        <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="Submit" autopostback="true"
                                            BackColor="#0066CC" ForeColor="White" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" BackColor="#0066CC" class="btn btn-default"
                                            autopostback="true" ForeColor="White" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
