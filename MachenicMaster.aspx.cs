using System;
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
    public partial class MachenicMaster : System.Web.UI.Page
    {
        TestService ESSSr = new TestService();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            fillgrid();
        }

        public void fillgrid()
        {   
            int param = 0;
            DataTable dt = new DataTable();
            dt = ESSSr.GetMachenics(param);
            if (dt.Rows.Count != 0)
            {
                grdComplaintList.DataSource = dt;

                grdComplaintList.DataBind();
                lblMsg.Text = "";
            }
            else
            {
                lblMsg.Text = "No Records Found";

            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtContact.Text = "";
            txtName.Text = "";
           
            Session["Name"] = null;
            Session["MachenicID"] = null;
            Session["contact"] = null;
            btnSubmit.Text = "Add";

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
             DataTable dt = new DataTable();
                
                string Name = txtName.Text.ToUpper(System.Globalization.CultureInfo.InvariantCulture);
                string Contact = txtContact.Text;
                
                if (Session["MachenicID"] != null)
                {
                    dt = ESSSr.UpdateMachenic(Convert.ToInt32(Session["MachenicID"]), Name, Contact , 0);
                }

                else
                {
                    dt = ESSSr.InsertMechanic(Name, Contact);
                }
                      
                 btnReset_Click(sender, e);
                 fillgrid();
                }
        

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ';' });
                Session["Name"] = commandArgs[0];
                Session["MachenicID"] = commandArgs[1];
                Session["contact"] = commandArgs[2];

                txtName.Text = Convert.ToString(Session["Name"]);
                txtContact.Text = Convert.ToString(Session["contact"]);
                
                btnSubmit.Text = "Update";
             }

            if (e.CommandName == "Remove")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ';' });
                string Name = commandArgs[0];
                string MachenicID = commandArgs[1];
                string contact = commandArgs[2];

                

                DataTable dt = new DataTable();
           
                dt = ESSSr.UpdateMachenic(Convert.ToInt32(MachenicID), Name, contact,1);
                fillgrid();
            }
        }



    }
}