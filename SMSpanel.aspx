<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="SMSpanel.aspx.cs" Inherits="TestWebservice.SMSpanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="css/responsive.min.css" rel="stylesheet" type="text/css" />
  <script src="js/jquery.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

      <div class="container">
       <br />
        <br />
        <br />
        <div class="row">
          
            <div class="col-sm-6 col-md-offset-3">
                <div class="panel panel-default">
                    <div class="panel-body">
                    <div class="row">
                    <div class="col-s-6">
                     <legend>SMS Panel</legend></div>
                        <div class="col-s-6" style="margin-top: -3%;">
                     <h4 style="color: #0066CC"><asp:Label ID="lblbalsms" runat="server"></asp:Label></h4></div>
                     </div>
                     <div class="col-s-12">
                        <asp:TextBox ID="txtSMSText" class="form-control" runat="server" MaxLength="1000" Rows="8" Style="resize:none; Width: 97%;" TextMode="MultiLine"
                            placeholder="Type Your Message In This Text Area" ToolTip="Type Your Message In This Text Area"></asp:TextBox>
                            </div>

                            <div class="col-s-3">
                        <span id="spanSMSLength">Characters : </span>
                        </div><div class="col-s-3">
                        <span id="spanSMSMsgCount">Messages : </span>
                          </div><div class="col-s-3"> <asp:RadioButton class="radio-inline" ID="RbtNormal" runat="server" GroupName="TextType" Text="English" Checked="true"/></div>
                        <div class="col-s-3"><asp:RadioButton ID="RbtUnicode" class="radio-inline" runat="server" GroupName="TextType" Text="Unicode" /></div>
                      
                       <div class="col-s-8">
                        <asp:RadioButtonList ID="rbtSMSType" class="radio-inline"  RepeatDirection="Horizontal" runat="server" RepeatColumns="3">
                            <asp:ListItem Value="1"> Single SMS...</asp:ListItem>
                            <asp:ListItem Value="2"> Bulk SMS</asp:ListItem> 
                        </asp:RadioButtonList></div>

                        
                        <div id="divSingleSMS" runat="server">
                            <legend>Send Single SMS</legend>
                            <asp:Label ID="Label1" runat="server" Text="Mobile No."></asp:Label>
                            <asp:TextBox ID="txtMobNo" MaxLength="10" style="width: 50%;" runat="server" onkeypress="return AllowNumbers(this, 'txtMobNo');"></asp:TextBox>
                            
                            <asp:Button ID="btnSingleSMS" class="form-control"  onclick="btnSingleSMS_Click" autopostback="true"  BackColor="#0066CC" ForeColor="White" runat="server" Text="Send SMS"  />
                           
                             <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="txtMobNo"
                                                    ID="RegularExpressionValidator3" 
                                ValidationExpression="^[\s\S]{10,10}$" runat="server"
                                                    ErrorMessage="Invalid mobile number [10 digits only]" ></asp:RegularExpressionValidator>
                                                    <sup>
                            <span id="errmsgContactNo" style="color: red; font-size: medium; font-family: 'Times New Roman', Times, serif;" "></span></sup>
                           </div>
                        <div id="divBulkSMS" runat="server" style="display:none" >
                            <legend>Send Bulk SMS</legend>
                          <asp:FileUpload ID="FileUpload1"  runat="server" Width="227px" />
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.xls|.xlsx)$"
                                ControlToValidate="FileUpload1" runat="server" ForeColor="Red" ErrorMessage="Please select a valid Excel File ." Display="Dynamic" />
                            <asp:Button ID="btnUpload" class="form-control" autopostback="true" BackColor="#0066CC" ForeColor="White" runat="server" Text="Upload File and Send SMS" onclick="btnUpload_Click" />
                            
                        </div>
                   <div>
                       
                        <asp:Label ID="lblErrMsg" runat="server"></asp:Label>
                        </div>      
                    
        
    
</div></div></div></div></div>

 <script type="text/javascript">

     function Clear() {
         var uploadControl = document.getElementById('<%=FileUpload1.ClientID%>');
         uploadControl.value = "";
     }

     function OnStatusChange() {

         $("#<%=rbtSMSType.ClientID %>").on("change", function () {

             var value = $("#<%=rbtSMSType.ClientID %>").find(":checked").val();
             var MobileNo = $("#<%=txtMobNo.ClientID %>").val();
             var SMStext = $("#<%=txtSMSText.ClientID %>").val();


             if (value == "1") {


                 $("#<%=divSingleSMS.ClientID %>").css('display', 'block');
                 $("#<%=divBulkSMS.ClientID %>").css('display', 'none');
                 $("#<%=lblErrMsg.ClientID %>").val("");
                 Clear();
             }
             else {
                 $("#<%=divSingleSMS.ClientID %>").css('display', 'none');
                 $("#<%=divBulkSMS.ClientID %>").css('display', 'block');
                 $("#<%=lblErrMsg.ClientID %>").val("");
                 $("#<%=txtMobNo.ClientID %>").val("");
             }
         });

         // $("#<%=rbtSMSType.ClientID %>").trigger('change');
     }

     $(document).ready(function () {
         OnStatusChange();
     })
           
    </script>
    <script type="text/javascript">

        function AllowNumbers(e, eleName) {
            var key = window.event ? event.keyCode : event.which;
            //if the letter is not digit then display error and don't type anything
            if (key != 13 && key != 8 && key != 0 && (key < 48 || key > 57)) {
                //display error message
                switch (eleName) {
                    case "txtMobNo":
                        $("#errmsgContactNo").html("Digits Only").show().delay(1000).fadeOut("slow");
                        break;
                    default:
                        $("#errmsgContactNo").hide();
                        break;
                }
                return false;
            }
        }

        function SetSMSCharsAndMessagesText() {
            //get the limit from maxlength attribute  
            var limit = parseInt($("#<%=txtSMSText.ClientID%>").attr('maxlength'));

            //get the sms text length
            var smsLength = $("#<%=txtSMSText.ClientID%>").val().toString().length;

            //check if there are more characters then allowed  
            if (smsLength > limit) {
                //and if there are use substr to get the text before the limit  
                var new_text = $("#<%=txtSMSText.ClientID%>").val().toString().substr(0, limit);

                //and change the current text with the new text  
                $("#<%=txtSMSText.ClientID%>").val(new_text);
            }

            //set length of sms
            $("#spanSMSLength").html("Character : " + smsLength.toString());

            //set count of sms message depends on sms text
            var smsMsgCount = 0;
            if ($('#<%=RbtUnicode.ClientID%>').is(':checked')) {

                smsMsgCount = parseInt(smsLength) / 70;
            }
            else {
                smsMsgCount = parseInt(smsLength) / 160;
            }

            var decimalPosition = smsMsgCount.toString().indexOf(".");
            if (decimalPosition > 0) {
                var tmp = smsMsgCount.toString().substr(0, decimalPosition);
                smsMsgCount = parseInt(tmp) + 1;
            }

            //set message count text
            $("#spanSMSMsgCount").html("Messages : " + smsMsgCount.toString());

        }

        $(function () {

            //set maximum length of sms text
            $("#<%=txtSMSText.ClientID%>").attr('maxlength', '1000');

            $("#<%=txtSMSText.ClientID%>").on("keyup", function () {
                SetSMSCharsAndMessagesText();
            });

            $("#<%=RbtNormal.ClientID%>").on("click", function () {
                SetSMSCharsAndMessagesText();
            });

            $("#<%=RbtUnicode.ClientID%>").on("click", function () {
                SetSMSCharsAndMessagesText();
            });
        });
        
    </script>

</asp:Content>
