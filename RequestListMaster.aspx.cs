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
    public partial class RequestListMaster : System.Web.UI.Page
    {
        TestService ESSSr = new TestService();
        protected void Page_Load(object sender, EventArgs e)
        {
            fillgrid();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtComplaintType.Text = "";
            chkIsForNewConsumer.Checked = false;
            Session["reqid"] = null;
            Session["Requests"] = null;
            Session["IsForNewConsumer"] = null;
            btnSubmit.Text = "Add";
        }

        public void fillgrid()
        {
            int param = 10;
            DataTable dt = new DataTable();
            dt = ESSSr.GetRequestsList(param);
            if (dt.Rows.Count != 0)
            {
                grdComplaintList.DataSource = dt;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dt.Rows[i][2] = dt.Rows[i][2].ToString().Replace("0", "No");
                    dt.Rows[i][2] = dt.Rows[i][2].ToString().Replace("1", "Yes");
                }
                grdComplaintList.DataBind();
                lblMsg.Text = "";
            }
            else
            {
                lblMsg.Text = "No Records Found";

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int chkvalue = 0;
            string comptype = txtComplaintType.Text.ToUpper(System.Globalization.CultureInfo.InvariantCulture);

            if (chkIsForNewConsumer.Checked == true)
            {
                chkvalue = 1;
            }


            if (Session["reqid"] != null)
            {
                dt = ESSSr.UpdateRequestsList(Convert.ToInt32(Session["reqid"]), comptype, chkvalue);
            }

            else
            {
                dt = ESSSr.InsertRequestList(comptype, chkvalue);
            }

            btnReset_Click(sender, e);
            fillgrid();
            }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ';' });
                Session["Requests"] = commandArgs[0];   
                Session["reqid"] = commandArgs[1];
                Session["IsForNewConsumer"] = commandArgs[2];

                txtComplaintType.Text = Convert.ToString(Session["Requests"]);

                if (Convert.ToString(Session["IsForNewConsumer"]) == "0")
                {
                    chkIsForNewConsumer.Checked = false;
                }
                else
                {
                    chkIsForNewConsumer.Checked = true;
                }
                btnSubmit.Text = "Update";


                
                }

            if (e.CommandName == "Remove")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ';' });
                string Request = commandArgs[0];
                string Reqid = commandArgs[1];
                string IsForNewConsumer = commandArgs[2];

                DataTable dt = new DataTable();
                int chkvalue = 2;
                dt = ESSSr.UpdateRequestsList(Convert.ToInt32(Reqid), Request, chkvalue);
                fillgrid();
               
            }


        }
    }
}