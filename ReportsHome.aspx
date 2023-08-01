<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" Inherits="TestWebservice.Repors_Home" Codebehind="ReportsHome.aspx.cs" %>



<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br />
    <div class="container">

     <div class="panel panel-default">
                            <div class="panel-body">
                                <legend>All Reports</legend>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    
    <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" 
    Width="100px" AlternateText="Resolved Complaints" 
        onclick="ImageButton1_Click" />

        <asp:ImageButton ID="ImageButton2" runat="server" Height="50px" 
    Width="100px" AlternateText="Pending Complaints" onclick="ImageButton2_Click"/>

    
        <asp:ImageButton ID="ImageButton3" runat="server" Height="50px" 
    Width="100px" AlternateText="Machanic Collection" 
        onclick="ImageButton3_Click" />

        
    
        <asp:ImageButton ID="ImageButton4" runat="server" Height="50px" 
    Width="100px" AlternateText="Machanic Stock Details" 
        onclick="ImageButton4_Click"/>
    
    </div></div>
    
  
    
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" ShowBackButton="False" 
        ShowCredentialPrompts="False" ShowDocumentMapButton="False" 
        ShowPageNavigationControls="False" ShowParameterPrompts="False" 
        ShowPrintButton="False" ShowPromptAreaButton="False" ShowRefreshButton="False" 
        ShowZoomControl="False" WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt" Width="100%">
       
    </rsweb:ReportViewer>
    
    </div>
    </asp:Content>
