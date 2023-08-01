<%@ Page Title="" Language="C#" MasterPageFile="~/RegistrationMaster.Master" AutoEventWireup="true"
    CodeBehind="RegAgency.aspx.cs" Inherits="TestWebservice.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/responsive.min.css" rel="stylesheet" type="text/css" />
    
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/normalize.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" onload="resetSelection()">
        <br />
        <form action="#">
        <div class="row">
            <div class="col-sm-12" runat="server" id="DivConsumerInfo">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <legend>Agency Information</legend>
                        <div class="row">
                            <div class="col-sm-4" style="padding: 5px;">
                                <div class="row" style="padding-top: 6px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Agency Name</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtAgencyName" class="form-control" BackColor="White" autocomplete="off"
                                            placeholder="Agency Name" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            SAP Code</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtAgencySAPCode" class="form-control" BackColor="White" autocomplete="off"
                                            placeholder="Agency SAP Code" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Address</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtAgencyAdd" Style="resize: none;" Rows="3" class="form-control"
                                            TextMode="MultiLine" BackColor="White" autocomplete="off" placeholder="Agency Address"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4" style="padding: 5px;">
                                <div class="row" style="padding-top: 6px;">
                                    <div class="col-s-4">
                                        <label for="">
                                            State</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:DropDownList ID="ddlState"  onchange="makeSubmenu(this.value)" class="form-control"
                                            runat="server">
                                            <asp:ListItem>Maharashtra</asp:ListItem>
                                            <asp:ListItem>Delhi</asp:ListItem>
                                            <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 6px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            District</label></div>
                                    <div class="col-s-8">
                                        <asp:DropDownList ID="ddlDistrict" class="form-control" runat="server">
                                            <asp:ListItem>Mumbai</asp:ListItem>
                                            <asp:ListItem>Noida</asp:ListItem>
                                            <asp:ListItem>Bhopal</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 6px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Postal Code</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtPIN" BackColor="White" class="form-control" autocomplete="off"
                                            placeholder="Postel Code" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Contact No.</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtAgencyContact" BackColor="White" class="form-control" autocomplete="off"
                                            placeholder="Agency Contact No." runat="server"></asp:TextBox></div>
                                </div>
                            </div>
                            <div class="col-sm-4" style="padding: 5px;">
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Taluka</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtTaluka" class="form-control" BackColor="White" autocomplete="off"
                                            placeholder="Taluka/Tehsil" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            City</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtCity" class="form-control" BackColor="White" autocomplete="off"
                                            placeholder="City" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Agency Email ID</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtAgencyMailId" class="form-control" BackColor="White" autocomplete="off"
                                            placeholder="Alternet Email ID" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Alternate Contact</label>
                                    </div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtAlternateAgencyContact" class="form-control" BackColor="White"
                                            autocomplete="off" placeholder="Alternet Contact No." runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12" runat="server" id="Div1">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <legend>Owners Information</legend>
                        <div class="row">
                            <div class="col-sm-4" style="padding: 5px;">
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Title</label>,</div>
                                    <div class="col-s-8">
                                        <asp:DropDownList ID="ddlOwnerTitle" class="form-control" runat="server">
                                            <asp:ListItem>Mr.</asp:ListItem>
                                            <asp:ListItem>Mrs.</asp:ListItem>
                                            <asp:ListItem>Ms.</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4" style="padding: 5px;">
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            First Name</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtOwnerFirstname" class="form-control" BackColor="White" autocomplete="off"
                                            placeholder="Owner's First Name" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Contact No.</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtOwnerContactNo" class="form-control" BackColor="White" autocomplete="off"
                                            placeholder="Owner's Contact No." runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4" style="padding: 5px;">
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Last Name</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtOwnerLastname" class="form-control" BackColor="White" autocomplete="off"
                                            placeholder="Owner's Last Name" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Email Id</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtOwnerMailId" class="form-control" BackColor="White" autocomplete="off"
                                            placeholder="Owner's Email Id" runat="server"></asp:TextBox></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12" runat="server" id="Div2">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <legend>Admin Information</legend>
                        <div class="row">
                            <div class="col-sm-4" style="padding: 5px;">
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Title</label></div>
                                    <div class="col-s-8">
                                        <asp:DropDownList ID="ddlAdminUserTitle" class="form-control" runat="server">
                                            <asp:ListItem>Mr.</asp:ListItem>
                                            <asp:ListItem>Mrs.</asp:ListItem>
                                            <asp:ListItem>Ms.</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Designation</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtAdminUserDesignation" class="form-control" BackColor="White"
                                            autocomplete="off" placeholder="Designation" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4" style="padding: 5px;">
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            First Name</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtAdminFirstName" class="form-control" BackColor="White" autocomplete="off"
                                            placeholder="Admin User First Name" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Contact No.</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtAdminUserContactNo" class="form-control" BackColor="White" autocomplete="off"
                                            placeholder="Admin User Contact No." runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4" style="padding: 5px;">
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Last Name</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtAdminLastName" class="form-control" BackColor="White" autocomplete="off"
                                            placeholder="Admin User Last Name" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-s-4">
                                        <label for="txtConsumerNo">
                                            Email Id</label></div>
                                    <div class="col-s-8">
                                        <asp:TextBox ID="txtAdminUserEmailId" class="form-control" BackColor="White" autocomplete="off"
                                            placeholder="Admin User Email Id" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12" runat="server" id="Div3">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <legend>System Information</legend>
                        <div style="padding-top: 5px;" class="col-s-3">
                            <label for="txtConsumerNo">
                                User Id</label>
                            <asp:TextBox ID="txtUserId" BackColor="White" class="form-control" autocomplete="off"
                                placeholder="Choose Admin User Id" runat="server"></asp:TextBox>
                        </div>
                        <div style="padding-top: 5px;" class="col-s-3">
                            <label for="txtConsumerNo">
                                Password</label>
                            <asp:TextBox ID="txtPassword" BackColor="White" class="form-control" autocomplete="off"
                                placeholder="Create Password" runat="server"></asp:TextBox>
                        </div>
                        <div style="padding-top: 5px;" class="col-s-3">
                            <label for="txtConsumerNo">
                                Re-Type Password</label>
                            <asp:TextBox ID="txtRetypePassword" BackColor="White" class="form-control" autocomplete="off"
                                placeholder="Re-Type Password" onkeypress="return Compare()" runat="server"></asp:TextBox>
                        </div>
                        <div style="padding-top: 5px;" class="col-s-3">
                            <label for="txtConsumerNo">
                                Licence Duration (In Months)</label>
                            <asp:TextBox ID="txtLicenceDuration" BackColor="White" class="form-control" autocomplete="off"
                                placeholder="Licence Duration (In Month)" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="text-center">
                <asp:Button ID="btnSubmit" Style="width: 20%;" class="btn btn-default" runat="server"
                    Text="Register Now" autopostback="true" BackColor="#0066CC" ForeColor="White"
                    OnClick="btnSubmit_Click" />
                <asp:Button ID="btnReset" Style="width: 20%;" runat="server" Text="Reset" BackColor="#0066CC"
                    OnClick="btnReset_Click" class="btn btn-default" autopostback="true" ForeColor="White" />
            </div>
        </div>
        <div class="col-sm-9" style="width: 70%; padding-left: 0px;">
            <div class="input-group">
                <span class="input-group-btn"></span>
            </div>
            <div>
                <sup><span id="errmsgConsumerNo" style="color: red;"></span></sup>
            </div>
        </div>
        </form>
        <script src="js/jquery.min.js" type="text/javascript"></script>
        <script type="text/javascript">

            function makeSubmenu(e, eleName) {
              
              var states = new List<string>();

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
     
    </div>
</asp:Content>
