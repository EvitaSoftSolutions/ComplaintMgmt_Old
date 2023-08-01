using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWebservice
{
    public partial class CMSAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string Username, Pwd, msg;
            TestService ESSSr = new TestService();

            Username = txtUsername.Text;
            Pwd = txtPassword.Text;
            msg = ESSSr.CMSAdminSignin(Username, Pwd);
            if (msg == "Valid")
            {
                Response.Redirect("RegAgency.aspx");
            }
            else
            {
                string strMsg = "Enter Correct Username or Passsword";
                Response.Write("<script>alert('" + strMsg + "')</script>");
                txtUsername.Text = "";
                txtPassword.Text = "";
            }

        }
    }
}