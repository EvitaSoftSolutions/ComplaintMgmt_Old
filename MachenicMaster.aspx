﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="MachenicMaster.aspx.cs" Inherits="TestWebservice.MachenicMaster" %>
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
                        <legend>Mechanic Master</legend>
                        <div class="row">
                            <div class="col-s-12">
                                <div style="padding-top: 5px;" class="row">
                                    <div class="col-s-4">
                                        <label for="txtName">
                                            Mechanic Name</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtName" runat="server" 
                                            style="text-transform:uppercase;" class="form-control" 
                                            placeholder="Enter Mechanic Name" MaxLength="40"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-s-12">
                                <div style="padding-top: 5px;" class="row">
                                    <div class="col-s-4">
                                        <label for="txtName">
                                            Mechanic Contact</label>
                                    </div>
                                     <div class="col-s-8">
                                        <asp:TextBox ID="txtContact" runat="server" 
                                            style="text-transform:uppercase;" class="form-control" 
                                            placeholder="Enter Mechanic Contact" MaxLength="40"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-top:6px;">
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
            <legend>Added Mechanics</legend>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <asp:GridView ID="grdComplaintList"  AutoGenerateColumns="False" runat="server"  OnRowCommand="gvList_RowCommand" data-page-size="4">
                <Columns>
                    
                    <asp:TemplateField Visible="true" HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCompType" runat="Server"  Text='<%# Eval("Name") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="true" HeaderText="Contact">
                        <ItemTemplate>
                           <%-- <asp:CheckBox ID="chkforNewConsumer"  runat="server" />--%>
                            <asp:Label ID="lblforNewConsumer" runat="Server" Text='<%# Eval("contact") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Update" Visible="true">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" Text="Update" runat="server" CommandName="Select" CommandArgument='<%# Eval("Name")+ ";" +Eval("MachenicID")+ ";" +Eval("contact")%>'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="GridViewItem" />
                        <HeaderStyle CssClass="GridViewHeader" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" Visible="true">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkRemove" Text="Delete" runat="server" CommandName="Remove" CommandArgument='<%# Eval("Name")+ ";" +Eval("MachenicID")+ ";" +Eval("contact")%>'></asp:LinkButton>
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
