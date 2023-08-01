<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMSAdmin.aspx.cs" Inherits="TestWebservice.CMSAdmin" %>

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
                    
                    <li><a href="index.aspx">Home</a> </li>
                    <li  class="active"><a class="active" href="CMSAdmin.aspx">Register Agency</a> </li>
                   <%-- <li><a href="index.aspx#about-us">About Us</a> </li>
                    <li><a href="index.aspx#contact">Contact Us</a> </li>--%>
                    <li><a href="login.aspx">Login</a> </li>
                </ul>
            </div>
           
        </div>
    </div>

    <div class="container">

    


    <div class="col-lg-offset-3 col-lg-6 col-lg-offset-3 col-xs-offset-0 col-xs-12 col-xs-offset-0 padding-top50" style="border-radius: 4px; margin-top: 136px;background:rgba(255, 255, 255, 0.62);">
    <div class="registrationform">

        <h1 style="color:#337ab7!important;">CMS Admin Login Panel</h1>
        <div class="form-group"><asp:TextBox ID="txtUsername" placeholder="UserName" runat="server" class="form-control" style="color:#006a9c; border: 1px solid #006a9c;"></asp:TextBox></div>
        <div class="form-group"><asp:TextBox ID="txtPassword" placeholder="Password" style="color:#006a9c; border: 1px solid #006a9c;" TextMode="Password" runat="server" class="form-control"></asp:TextBox></div>
        <div class="form-group" text="left"><asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="Submit" 
            onclick="btnSubmit_Click"/>
           <%-- <a href="#forget-password" data-target="#pwdModal" data-toggle="modal">Forget password?</a>--%>
            </div>
    
    </div>
    </div>
    </div>
    </form>

    <%--<div id="pwdModal" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header brick">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        X</button>
                    <h3 class="text-center">
                        Forget password?</h3>
                </div>
                <div class="modal-body">
                    <div class="col-md-12">
                        <div class="panel">
                            <div class="panel-body">
                                <div class="text-center">
                                    <p>
                                        If you have forgotten your password you can reset it here.</p>
                                    <div class="panel-body">
                                        <fieldset>
                                            <div class="form-group">
                                                <input class="form-control input-lg" placeholder="E-mail Address" name="email" type="email">
                                            </div>
                                            <input class="btn btn-lg btn-danger btn-block" value="Send My Password" type="submit">
                                        </fieldset>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix">
                </div>
            </div>
        </div>
    </div>--%>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/jquery.flexslider-min.js"></script>
    <script src="js/jquery.fancybox.pack.js"></script>
    <script src="js/retina.min.js"></script>
    <script src="js/modernizr.js"></script>
    <script src="js/main.js"></script>
</body>
</html>
