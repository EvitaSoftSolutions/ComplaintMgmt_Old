<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="Req_Search.aspx.cs" Inherits="TestWebservice.Req_Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="css/responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/datepicker.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        // When the document is ready
        $(document).ready(function () {
            $('.input-daterange').datepicker
            ({
                format: 'dd/mm/yyyy',
                todayBtn: "linked"
            });
        });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <br />
    <br />
    <br />
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
                                    Request Id.</label>
                            </div>
                            <div class="col-s-8">
                                <asp:TextBox ID="txtComplaintId" runat="server" class="form-control" placeholder="Complaint ID."></asp:TextBox>
                            </div>
                        </div>
                        <div class="row" style="padding-top: 6px;">
                            <div class="col-s-3">
                                <label for="txtConsumerNo">
                                    Consumer No.</label>
                            </div>
                            <div class="col-s-8">
                                <asp:TextBox ID="txtConsumerNo" class="form-control" placeholder="Consumer No." runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-s-6">
                    <div class="input-daterange" id="datepicker">
                        <div class="row" style="padding-top: 5px;">
                            <div class="col-s-2">
                                <label for="txtfromdate">
                                    From Date</label>
                            </div>
                            <div class="col-s-5">
                                <div class="input-group">
                                    <asp:TextBox ID="txtfromdate" class="form-control" placeholder="From Date" runat="server"></asp:TextBox>
                                   <%-- <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span>
                             --%>   </div>
                            </div>
                        </div>
                        <div class="row" style="padding-top: 5px;">
                            <div class="col-s-2">
                                <label for="txttodate">
                                    To Date</label>
                            </div>
                            <div class="col-s-5">
                                <div class="input-group">
                                    <asp:TextBox ID="txttodate" class="form-control" placeholder="To Date" runat="server"></asp:TextBox>
                                    <%--<span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span>
                                --%></div>
                            </div>
                        </div></div></div></div>
                        <div class="row" style="padding-top: 15px;">
                            <div class="text-center">
                                <asp:Button ID="btnSubmit" Style="width: 20%;" class="btn btn-default" runat="server"
                                    Text="Search" autopostback="true" BackColor="#0066CC" OnClick="btnGetByID_Click"
                                    ForeColor="White" />
                                <asp:Button ID="btnReset" Style="width: 20%;" runat="server" Text="Reset" BackColor="#0066CC"
                                    class="btn btn-default" autopostback="true" ForeColor="White" OnClick="btnReset_Click" />
                            </div>
                        </div>
                    
                
            </div>
        </div>
        <asp:GridView ID="gvList" runat="server" PageSize="5" GridLines="Both" AutoGenerateColumns="false"
            OnRowCommand="gvList_RowCommand">
            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                NextPageText="Next" PreviousPageText="Previous" />
            <Columns>
                <asp:TemplateField Visible="true" HeaderText="Complaint ID">
                    <ItemTemplate>
                        <asp:Label ID="lblClientID" runat="Server" Text='<%# Eval("EnqID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Consumer ID" Visible="true">
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="Server" Text='<%# Eval("ConsumerNo") %>' />
                    </ItemTemplate>
                    <ItemStyle CssClass="GridViewItem" />
                    <HeaderStyle CssClass="GridViewHeader" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Consumer Name" Visible="true">
                    <ItemTemplate>
                        <asp:Label ID="lblname" runat="Server" Text='<%# Eval("ConsumerName") %>' />
                    </ItemTemplate>
                    <ItemStyle CssClass="GridViewItem" />
                    <HeaderStyle CssClass="GridViewHeader" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Complaint Details" Visible="true">
                    <ItemTemplate>
                        <asp:Label ID="lbldetails" runat="Server" Text='<%# Eval("ComplaintDetails") %>' />
                    </ItemTemplate>
                    <ItemStyle CssClass="GridViewItem" />
                    <HeaderStyle CssClass="GridViewHeader" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Machenic" Visible="true">
                    <ItemTemplate>
                        <asp:Label ID="lblmachenic" runat="Server" Text='<%# Eval("Machenic") %>' />
                    </ItemTemplate>
                    <ItemStyle CssClass="GridViewItem" />
                    <HeaderStyle CssClass="GridViewHeader" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User Created" Visible="true">
                    <ItemTemplate>
                        <asp:Label ID="lblusername" runat="Server" Text='<%# Eval("Username") %>' />
                    </ItemTemplate>
                    <ItemStyle CssClass="GridViewItem" />
                    <HeaderStyle CssClass="GridViewHeader" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" Visible="true">
                    <ItemTemplate>
                        <asp:Label ID="lbldate" runat="Server" Text='<%# Eval("Complaint Date") %>' />
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
                <asp:TemplateField HeaderText="Resolve Complaints" Visible="true">
                    <ItemTemplate>
                        <asp:Button ID="btnSelect" runat="server" BackColor="#0066CC" ForeColor="White" Text="Select"
                            CommandArgument='<%#Eval("ID") %>' CommandName="Select" />
                    </ItemTemplate>
                    <ItemStyle CssClass="GridViewItem" />
                    <HeaderStyle CssClass="GridViewHeader" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Update Complaints" Visible="true">
                    <ItemTemplate>
                        <asp:Button ID="btnupdate" runat="server" BackColor="#0066CC" ForeColor="White" Text="Update"
                            CommandArgument='<%#Eval("ID") %>' CommandName="Update" />
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
    

</asp:Content>
