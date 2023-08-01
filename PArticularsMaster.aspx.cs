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
    public partial class PArticularsMaster : System.Web.UI.Page
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
            dt = ESSSr.GetParticulars(param);
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

            Session["Particulars"] = null;
            Session["ID"] = null;
            Session["Rate"] = null;
            btnSubmit.Text = "Add";

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            string Particular = txtName.Text.ToUpper(System.Globalization.CultureInfo.InvariantCulture);
            decimal Rate = Convert.ToDecimal(txtContact.Text);

            if (Session["ID"] != null)
            {
                dt = ESSSr.UpdateParticulars(Convert.ToInt32(Session["ID"]), Particular, Rate, 0);
            }

            else
            {
                dt = ESSSr.InsertParticulars(Particular, Rate);
            }

            btnReset_Click(sender, e);
            fillgrid();
        }


        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ';' });
                Session["Particulars"] = commandArgs[0];
                Session["ID"] = commandArgs[1];
                Session["Rate"] = commandArgs[2];

                txtName.Text = Convert.ToString(Session["Particulars"]);
                txtContact.Text = Convert.ToString(Session["Rate"]);

                btnSubmit.Text = "Update";
            }

            if (e.CommandName == "Remove")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ';' });
                string Particular = commandArgs[0];
                string ID = commandArgs[1];
                decimal Rate = Convert.ToDecimal(commandArgs[2]);



                DataTable dt = new DataTable();

                dt = ESSSr.UpdateParticulars(Convert.ToInt32(ID), Particular, Rate, 1);
                fillgrid();
            }
        }
    }
}