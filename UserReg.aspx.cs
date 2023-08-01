using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using TestWebservice.ServiceRef;
using System.Web.Services;
using System.Net;


namespace TestWebservice
{
    public partial class UserReg : System.Web.UI.Page
    {
        TestService ESSSr = new TestService();      
        string strMsg, Id, UserType   ;
        int  x = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Id = Session["UserId"].ToString();
            UserType = Session["UserType"].ToString();
            if (!Page.IsPostBack)
            {

                if (Id == "")
                {
                    Response.Redirect("~/login");
                }


                if (UserType != "Admin")
                {
                    Response.Redirect("~/Complaint");
                    
                }

                fillgrid();

            }


        }

        public void fillgrid()
        {
            int param = 1;
            DataTable dt = new DataTable();
            dt = ESSSr.GetUserList(param);
            if (dt.Rows.Count != 0)
            {
                grdUserList.DataSource = dt;

                grdUserList.DataBind();
                lblMsg.Text = "";
            }
            else
            {
                lblMsg.Text = "No Records Found";

            }
        }

       
        protected void Button1_Click1(object sender, EventArgs e)
        {

            try
            {

                if (Session["UserListId"] != null)
                {
                    ESSSr.UpdateUser(Convert.ToInt32(Session["UserListId"]), txtName.Text,txtContact.Text,txtUserId.Text, ddlStaffCat.Text, 1);
                    ResetAll();
                    return;
                    
                }

                string DateCr = DateTime.Now.ToString();
                if (txtPassword.Text=="")
                {
                    string strMsg = "Please add Password";
                    Response.Write("<script>alert('" + strMsg + "')</script>");
                
                }
                if (txtPassword.Text != txtRepassword.Text)
                {
                    string strMsg = "Passwords don't match. Try again?";
                    Response.Write("<script>alert('" + strMsg + "')</script>");
                }
                else
                {
                    ESSSr.SaveUser(txtUserId.Text, txtName.Text,txtContact.Text, txtPassword.Text, "1", Convert.ToDateTime(DateCr), "Anita Gas Service", "", ddlStaffCat.Text);
                    strMsg = "User Created Successfully";
                    Response.Write("<script>alert('" + strMsg + "')</script>");
                }
                ResetAll();
            }
            catch
            {

            }
        }


        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ';' });
                Session["UserListId"] = commandArgs[0];
                Session["User_Name"] = commandArgs[1];
                Session["UserMob"] = commandArgs[2];
                Session["Username"] = commandArgs[3];
                Session["UserListType"] = commandArgs[4];


                txtName.Text = Convert.ToString(Session["User_Name"]);
                txtContact.Text = Convert.ToString(Session["UserMob"]);
                txtUserId.Text = Convert.ToString(Session["Username"]);
                ddlStaffCat.Text = Convert.ToString(Session["UserListType"]);

                btnSubmit.Text = "Update";
                Divpwd.Visible = false;
            }

            if (e.CommandName == "Remove")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ';' });
                string UserId = commandArgs[0];
                string Name = commandArgs[1];
                string UserContact= commandArgs[2];
                string Username = commandArgs[3];
                string UserListType = commandArgs[4];


                DataTable dt = new DataTable();

                dt = ESSSr.UpdateUser(Convert.ToInt32(UserId), Name, UserContact, Username, UserListType, 0);
                fillgrid();
            }
        }



        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
            
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
        public void ResetAll()
        {
            try
            {
                ddlStaffCat.SelectedIndex = 0;
                txtName.Text = "";
                txtUserId.Text = "";
                txtPassword.Text = "";
                txtRepassword.Text = "";
                txtContact.Text = "";
                Session["UserListId"] = null;
                Session["User_Name"] = null;
                Session["Username"] = null;
                Session["UserListType"] = null;
                Session["UserMob"] = null;
                Divpwd.Visible = true;
                fillgrid();
            }
            catch
            {
            }
        }
}
}