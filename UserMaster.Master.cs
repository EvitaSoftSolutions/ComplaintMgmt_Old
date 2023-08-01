using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TestWebservice
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        TestService ESSSr = new TestService();
        string  Id, UserType;

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Session["Name"] == null)
            {
                Response.Redirect("~/login");
            }
            else
            {
                lbluid.Text = "Hi.." + Session["Name"].ToString();
            }
        }


       
    }
}