<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="EnquiryListMaster.aspx.cs" Inherits="TestWebservice.EnquiryListMaster" %>
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
                        <legend>Enquiry List Master</legend>
                        <div class="row">
                            <div class="col-s-12">
                                <div style="padding-top: 5px;" class="row">
                                    <div class="col-s-4">
                                        <label for="txtName">
                                            Enquiry Type</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtComplaintType" runat="server" 
                                            style="text-transform:uppercase;" class="form-control" 
                                            placeholder="Enter Enquiry Type" MaxLength="40"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-s-12">
                                <div style="padding-top: 5px;" class="row">
                                    <div class="col-s-4">
                                        <label for="txtName">
                                            Available to New Consumer</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:CheckBox ID="chkIsForNewConsumer" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
        <div class="text-center">
            <asp:Button ID="btnSubmit"  class="btn btn-default" runat="server"
                Text="Add" autopostback="true" BackColor="#0066CC"
                ForeColor="White" onclick="btnSubmit_Click" />
            <asp:Button ID="btnReset"  runat="server" Text="Reset" BackColor="#0066CC"
                OnClick="btnReset_Click" class="btn btn-default" autopostback="true" ForeColor="White" />
        </div>
    </div>
                    </div>
                </div> </div>

                <div class="col-sm-12 col-md-offset-3">
    <div style="margin-top: 10px;" class="col-sm-6  panel panel-default">
        <div class="panel-body">
            <legend>Added Enquiry</legend>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <asp:GridView ID="grdComplaintList"  AutoGenerateColumns="False" runat="server" 
                OnRowCommand="gvList_RowCommand" data-page-size="4">
                <Columns>
                     
                    <asp:TemplateField Visible="true" HeaderText="Type">
                        <ItemTemplate>
                            <asp:Label ID="lblCompType" runat="Server" Text='<%# Eval("Enquiry") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="true" HeaderText="For New Consumer">
                        <ItemTemplate>
                           <asp:Label ID="lblforNewConsumer" runat="Server" Text='<%# Eval("IsForNewConsumer") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Update" Visible="true">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" Text="Update" runat="server" CommandName="Select" CommandArgument='<%# Eval("Enquiry")+ ";" +Eval("EnquiryListID")+ ";" +Eval("IsForNewConsumer")%>'> </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="GridViewItem" />
                        <HeaderStyle CssClass="GridViewHeader" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" Visible="true">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkRemove" Text="Delete" runat="server" CommandName="Remove" CommandArgument='<%# Eval("Enquiry")+ ";" +Eval("EnquiryListID")+ ";" +Eval("IsForNewConsumer")%>'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="GridViewItem" />
                        <HeaderStyle CssClass="GridViewHeader" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
 </div></div>
 
    
    
   <asp:Label ID="te" runat="server"></asp:Label>
   </div>
</asp:Content>
