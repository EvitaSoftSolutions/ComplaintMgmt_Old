<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    Inherits="TestWebservice.WebForm2" CodeBehind="UpdateComplaint.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/responsive.min.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-2.1.4.min.js" type="text/javascript"></script>
    <link href="css/normalize.css" rel="stylesheet" type="text/css" />
    <script src="js/responsive.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<form id="form1" runat="server">--%>
    <br />
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="container">
                <form action="#">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <legend>Resolve Complaint</legend>
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                <div class="col-sm-12">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <label for="txtCompId">
                                                Complaint ID</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtCompId" ReadOnly="true" runat="server" class="form-control" placeholder="Complaint Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-sm-3">
                                            <label for="txtConsumerNo">
                                                Consumer No</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtConsumerNo" ReadOnly="true" runat="server" class="form-control"
                                                placeholder="Consumer Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-sm-3">
                                            <label for="txtConsumerName">
                                                Consumer Name</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtConsumerName" runat="server" ReadOnly="true" class="form-control"
                                                placeholder="Consumer Name"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-sm-3">
                                            <label for="txtConsumerComplaint">
                                                Complaint</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtConsumerComplaint" runat="server" ReadOnly="true" class="form-control"
                                                placeholder="Complaint Detail"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-sm-3">
                                            <label for="txtConsumerMob">
                                                Mobile Number
                                            </label>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtConsumerMob" runat="server" ReadOnly="true" class="form-control"
                                                placeholder="Consumer Contact No."></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-sm-3">
                                            <label for="txtUserCr">
                                                Created By</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtUserCr" runat="server" ReadOnly="true" class="form-control" placeholder="User Created"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-sm-3">
                                            <label for="txtmechanic">
                                                Mechanic</label>
                                        </div>
                                        <div class="col-sm-9">
                                        <div class="input-group">
                                            <asp:DropDownList ID="ddlMachenic" BackColor="White" runat="server" class="form-control">
                                            </asp:DropDownList><span class="input-group-addon add-on"  ><span class="glyphicon glyphicon-chevron-down"></span>
                                            <%--<asp:TextBox ID="txtmechanic" ReadOnly="true" runat="server" class="form-control" placeholder="Machenic Attended"></asp:TextBox>--%>
                                        </div></div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-sm-3">
                                            <label for="txtDateCr">
                                                Date Created</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtDateCr" runat="server" ReadOnly="true" class="form-control" placeholder="Date of Complaint"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-sm-3">
                                            <label for="txtresolved">
                                                Status</label>
                                        </div>
                                        <div class="col-sm-9">
                                        <div class="input-group">
                                            <asp:DropDownList ID="ddlStatus" class="form-control" runat="server">
                                                <asp:ListItem Value="1">Resolved</asp:ListItem>
                                                <asp:ListItem Value="2">Attended</asp:ListItem>
                                                <asp:ListItem Value="3">Cancelled</asp:ListItem>
                                            </asp:DropDownList><span class="input-group-addon add-on"  ><span class="glyphicon glyphicon-chevron-down"></span>
                                        </div></div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-sm-3">
                                            <label for="txtinvoice">
                                                Invoice No</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtinvoice" onkeypress="return AllowNumbers(this, 'txtConsumerNo');"
                                                runat="server" class="form-control" placeholder="Invoice Number" MaxLength="6"
                                                TabIndex="1"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-sm-3">
                                            <label for="txtremark">
                                                Remark</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtremark" runat="server" class="form-control" placeholder="Remarks / Note"
                                                MaxLength="45" TabIndex="2"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-sm-3">
                                            <label for="txtdiscount">
                                                Discount Amount</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtdiscount" onkeypress="return AllowNumbers(this, 'txtConsumerNo');"
                                                OnTextChanged="txtdiscount_TextChanged" AutoPostBack="true" runat="server" class="form-control"
                                                placeholder="Discount Amount" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-sm-3">
                                            <label for="txttotal">
                                                Total Amount</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txttotal" runat="server" class="form-control" placeholder="Billed Amount"
                                                ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="text-center">
                                        <asp:Button ID="btnsubmit" Style="width: 20%;" class="btn btn-default" runat="server"
                                            Text="Submit" autopostback="true" BackColor="#0066CC" OnClick="btnsubmit_Click1"
                                            ForeColor="White" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="panel panel-default" style="height: 600px; overflow: scroll;" id="scrollDiv">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="row" id="divGrid">
                                            <asp:GridView ID="Gvparticulars" runat="server" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblchkbox" runat="server" Text="Add"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="SumCheckBox1" OnCheckedChanged="SumCheckBox1_CheckedChanged" AutoPostBack="true"
                                                                runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <%-- OnTextChanged="txtQuantity_TextChanged" AutoPostBack="true" --%>
                                                            <asp:TextBox ID="txtQuantity" Text="0" onkeypress="return AllowNumbers(this, 'txtConsumerNo');"
                                                                runat="server" Width="20px" OnTextChanged="txtQuantity_TextChanged" AutoPostBack="true"
                                                                MaxLength="2"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Particulars" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblParticularsID" runat="Server" Text='<%# Eval("ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="GridViewItem" />
                                                        <HeaderStyle CssClass="GridViewHeader" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Particulars" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblParticulars" runat="Server" Text='<%# Eval("particular") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="GridViewItem" />
                                                        <HeaderStyle CssClass="GridViewHeader" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rate" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRate" runat="Server" Text='<%# Eval("rate") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="GridViewItem" />
                                                        <HeaderStyle CssClass="GridViewHeader" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </form>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function OnStatusChange() {

            $("#<%=ddlStatus.ClientID %>").on("change", function () {
                var value = $("#<%=ddlStatus.ClientID %> option:selected").val();
                if (value == "1") {
                    $("#<%=txtinvoice.ClientID %>").attr("readonly", false);
                    $("#<%=txtdiscount.ClientID %>").attr("readonly", false);
                    
                    $("[id*='SumCheckBox1']").removeAttr("disabled");
                    $("[id*='txtQuantity']").prop("readonly", false);

                }
                else {
                    $("#<%=txtinvoice.ClientID %>").attr("readonly", true);
                    $("#<%=txtdiscount.ClientID %>").attr("readonly", true);

                    $("[id*='SumCheckBox1']").attr("disabled", true);
                    $("[id*='txtQuantity']").prop("readonly", true);

                    $("[id*='SumCheckBox1']").prop('checked', false);
                    $("[id*='txtQuantity']").val("0");
                    $("#<%=txttotal.ClientID %>").val("");
                }
            });

            $("#<%=ddlStatus.ClientID %>").trigger('change');
        }

        $(document).ready(function () {
            OnStatusChange();
        })
           
    </script>

    <script type="text/javascript">
        var xPos, yPos;
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            xPos = $get('scrollDiv').scrollLeft;
            yPos = $get('scrollDiv').scrollTop;
            
            OnStatusChange();
        }
        function EndRequestHandler(sender, args) {
            $get('scrollDiv').scrollLeft = xPos;
            $get('scrollDiv').scrollTop = yPos;

            OnStatusChange();
        }

    </script>
    <script type="text/javascript">
        function AllowNumbers(e, eleName) {
            var key = window.event ? event.keyCode : event.which;
            if (key != 8 && key != 0 && (key < 48 || key > 57)) {
                return false;
            }
        }
    </script>

</asp:Content>
