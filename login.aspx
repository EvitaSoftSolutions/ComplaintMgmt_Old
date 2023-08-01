<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="login.aspx.cs" Inherits="TestWebservice.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html class="full" xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <!-- Custom CSS -->
    <link href="css/the-big-picture.css" rel="stylesheet"/>
    <link href="css/font-icon.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="css/responsive.css" rel="stylesheet" type="text/css" />
    <!-- ============ Google fonts ============ -->
    <link href='http://fonts.googleapis.com/css?family=EB+Garamond' rel='stylesheet'
        type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,600,700,300,800'
        rel='stylesheet' type='text/css' />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css"/>


</head>
<body>
    <form id="form1" role="form" runat="server">
    <div>

    <div id="custom-bootstrap-menu" class="navbar navbar-default " role="navigation">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand" href="#">EvitaSoftSolution</a>
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-menubuilder">
                    <span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span
                        class="icon-bar"></span><span class="icon-bar"></span>
                </button>
            </div>
           
            <div class="collapse navbar-collapse navbar-menubuilder">
                <ul class="nav navbar-nav navbar-right">
                    
                    <li><a href= '<%=ResolveUrl("~/Home") %>'>Home</a> </li>
                    <li><a href= '<%=ResolveUrl("~/Register") %>'>Register Agency</a> </li>
                    <li class="active"><a class="active" href="login.aspx"><span class="glyphicon glyphicon-log-in"></span>  Login</a> </li>
                </ul>
            </div>
           
        </div>
    </div>

    <div class="container">
    <div class="col-lg-offset-3 col-lg-6 col-lg-offset-3 col-xs-offset-0 col-xs-12 col-xs-offset-0 padding-top50" style="border-radius: 4px; margin-top: 136px;background:rgba(255, 255, 255, 0.62);">
    <div class="registrationform">
    <div class="form-group">
    <asp:DropDownList ID="ddlAgencyName" class="form-control" runat="server" 
                            placeholder="agency" required style="color:#006a9c;  border: 1px solid #006a9c;">
                        <asp:ListItem Value="001">Anita Gas Service</asp:ListItem>
                    </asp:DropDownList></div>
        <div class="form-group"><asp:TextBox ID="txtUsername" placeholder="UserName" runat="server" class="form-control" style="color:#006a9c; border: 1px solid #006a9c;"></asp:TextBox></div>
        <div class="form-group"><asp:TextBox ID="txtPassword" placeholder="Password"  TextMode="Password" runat="server" class="form-control" style="color:#006a9c;border: 1px solid #006a9c;"></asp:TextBox></div>
        <div class="form-group" text="left"><asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="Submit" 
            onclick="btnSubmit_Click"/>
            <a href="#forget-password" data-target="#modalresetpwd" data-toggle="modal" style="color:#337ab7!important;">Forget password?</a>
            </div>
    
    </div>
    </div>
    </div>
    <div id="modalresetpwd" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog" style="z-index: inherit; top:10%;">
            <div class="modal-content">
                
                <div class="modal-body">
                <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="text-center">
                          <h3><i class="fa fa-lock fa-4x"></i></h3>
                          <h2 class="text-center">Forgot Password?</h2>
                          <p>You can reset your password here.</p>
                           <p>Note : Your Password Will Be Sent To Your Registered Mobile Number.</p> 
                            <div class="panel-body">
                              <fieldset>
                                <div class="form-group">
                                <div class="input-group">
                                 <span class="input-group-addon"><i class="glyphicon glyphicon-user "></i></span>
                                <asp:TextBox ID="txtfgtUname" placeholder="UserName" runat="server" 
                                        class="form-control" style="color:#006a9c; border: 1px solid #006a9c;" 
                                        MaxLength="30"></asp:TextBox></div>
                                </div>
                             
                              <div class="form-group">
                                  <asp:Button class="btn btn-lg btn-primary btn-block" ID="Button1" 
                                      runat="server" Text="Send My Password" onclick="Button1_Click" />
                                   </div>
                                </fieldset>
                              
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                <div class="clearfix">
                </div>
            </div>
        </div>
    </div>
    </form>
<script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    
</body>
</html>
