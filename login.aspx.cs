using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestWebservice.ServiceRef;
using System.Text;

namespace TestWebservice
{
    public partial class Login : System.Web.UI.Page
    { 
        string Username, Pwd, msg,UserContact,User_Name  ;
        TestService ESSSr = new TestService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {   Username = txtUsername.Text;
            Pwd = txtPassword.Text;
            msg = ESSSr.Signin(Username, Pwd);
            if (msg == "Valid")
            {
                Response.Redirect("~/Complaint");
                
            }
            else
            {
                string strMsg = "Enter Correct Username or Passsword";
                Response.Write("<script>alert('" + strMsg + "')</script>");
                txtUsername.Text = "";
                txtPassword.Text = "";
            }}

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string strMsg;
            Username = txtfgtUname.Text;
            DataTable dt = new DataTable();
            TestService ESSSr = new TestService();
            dt = ESSSr.GetUserPwd(Username);
            if (dt.Rows.Count == 0)
            {
                strMsg = "UserName Does not Exist.. Please Enter Correct UserName.";
                Response.Write("<script>alert('" + strMsg + "')</script>");
                return;
            }
            DataRow row = dt.Rows[0];
            Pwd = row["Password"].ToString();
            UserContact = row["UserMob"].ToString();
            User_Name = row["Name"].ToString();
            WebClient client = new WebClient();
            string PasswordMsg;
            var temp_Id = "";
            PasswordMsg = "Dear " + User_Name + Environment.NewLine + "Your Password is- "+Pwd + Environment.NewLine + "Kindly do not share it with anyone" + Environment.NewLine + "Thank You." + Environment.NewLine + "Support Team.";
            string baseURLcust = "http://www.weberleads.in/http-tokenkeyapi.php?authentic-key=3535416e6974616761733836361595828831&senderid=AGSBPC&route=2&number=" + UserContact + "&message=" + PasswordMsg + "&templateid=" + temp_Id;

            //string baseURLcust = "http://ocs-sms.com/submitsms.jsp?user=bpclag1&key=b5c6686c0bXX&mobile=+91" + UserContact + "&message=" + PasswordMsg + "&senderid=AGSBPC&accusage=1";
            client.OpenRead(baseURLcust);
            strMsg = "The password has been sent successfully to the registered mobile number.";
            Response.Write("<script>alert('" + strMsg + "')</script>");
            txtfgtUname.Text = "";
            Pwd = "";
            UserContact = "";
            User_Name = "";
         }

        

      

    }
}