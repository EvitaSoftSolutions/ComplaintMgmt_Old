<%@ Page Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="UploadConsumerDataTest.aspx.cs" Inherits="TestWebservice.UploadConsumerDataTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-offset-3">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <legend>Upload Consumer Information</legend>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:Label ID="Label4" runat="server" Text="Select List Of Active Consumers">
                            </asp:Label><asp:FileUpload ID="FileUpload1" runat="server" Width="227px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required"
                                ControlToValidate="FileUpload1" runat="server" Display="Dynamic" ForeColor="Red" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.xls|.xlsx)$"
                                ControlToValidate="FileUpload1" runat="server" ForeColor="Red" ErrorMessage="Please select a valid Excel File file."
                                Display="Dynamic" />
                            <asp:Label ID="lblFile1Msg" runat="server" Text=""></asp:Label><br />
                            <br />
                            <asp:Label ID="Label6" runat="server" Text="Select List Of Blocked Consumers"></asp:Label>
                            <asp:FileUpload ID="FileUpload2" runat="server" Width="227px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Required"
                                ControlToValidate="FileUpload2" runat="server" Display="Dynamic" ForeColor="Red" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.xls|.xlsx)$"
                                ControlToValidate="FileUpload2" runat="server" ForeColor="Red" ErrorMessage="Please select a valid Excel File file."
                                Display="Dynamic" />
                            <asp:Label ID="lblFile2Msg" runat="server" Text=""></asp:Label><br />
                            <br />
                            <asp:Button ID="btnUpload" runat="server" Text="Get Records From  File" OnClick="btnUpload_Click" />
                            <br />
                            <br />
                            <asp:Button ID="btn" runat="server" Text="Update Consumer Data" OnClientClick="return confirm('Are you sure you wish to Update Database?');"
                                OnClick="btn_Click" />
                            <br/><br/><br/>
                                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                            <br/>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <asp:Label ID="lblMeg" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
        <asp:Label ID="lblErrMsg" runat="server"></asp:Label>
        <asp:Label ID="lblinsert" runat="server"></asp:Label>
    </div>
    
</asp:Content>
