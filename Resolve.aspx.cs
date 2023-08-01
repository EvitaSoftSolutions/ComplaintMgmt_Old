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
using System.Globalization;
using System.IO;

namespace TestWebservice
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        TestService ESSSr = new TestService();
        string strMsg, Id, UserType;
        int x = 0;
        string ComplaintId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GetMachenics();
                ddlMachenic.Text = "";
                fillgrid();
               
                btnSubmit.Focus();
            }

            if (Session["UserId"] != null)
            {
                Id = Session["UserId"].ToString();
                UserType = Session["UserType"].ToString();
            }
            if (Id == null)
            {
                Response.Redirect("~/login");
            }
           

          }

        //protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvList.PageIndex = e.NewPageIndex;
        //    fillgrid();
        //}

        

        public void fillgrid()
        {
            DataTable dt = new DataTable();
            gvList.DataSource = null;
            gvList.DataBind();
            lblMsg.Text = "";

            string fromDate;
            string toDate;
            DateTime ResultFrom;
            DateTime ResultTo;
            if (txtfromdate.Text.Trim() != "" && txttodate.Text.Trim() != "")
            {
                ResultFrom = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ResultTo = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                fromDate = ResultFrom.ToString("yyyy-MM-dd");
                toDate = ResultTo.ToString("yyyy-MM-dd");
            }
            else
            {
                fromDate = "";
                toDate = "";
            }

            dt = ESSSr.ViewFilterComplaints(Id, txtComplaintId.Text, txtConsumerNo.Text, ddlMachenic.SelectedItem.Text.Trim() == "--Select--" ? "" : ddlMachenic.SelectedItem.Text.Trim(), fromDate, toDate, txtContact.Text, UserType);
        lblcount.Text = "Total Records: "+ Convert.ToString(dt.Rows.Count);   
            if (dt.Rows.Count != 0)
            {
                gvList.DataSource = dt;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (dt.Rows[i][1].ToString().Trim() == "0")
                    {
                        dt.Rows[i][1] = dt.Rows[i][1].ToString().Replace("0", "New Consumer");
                    }
                }
                gvList.DataBind();
                
                

                //Attribute to show the Plus Minus Button.
                gvList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                gvList.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                gvList.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                gvList.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                gvList.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
                gvList.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
                gvList.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";
                gvList.HeaderRow.Cells[8].Attributes["data-hide"] = "phone";


                //Adds THEAD and TBODY to GridView.
                gvList.HeaderRow.TableSection = TableRowSection.TableHeader;

                lblMsg.Text = "";
            }
            else
            {
                lblMsg.Text = "No Records Found";
            }
        }

        
       
        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                te.Text = Convert.ToString(e.CommandArgument.ToString());
                int pID = Convert.ToInt32(e.CommandArgument);
                // either put ID in session and check 
                Session["cID"] = Convert.ToString(te.Text);
                Response.Redirect("~/Resolve");
            }
            if (e.CommandName == "Update")
            {
                te.Text = Convert.ToString(e.CommandArgument.ToString());
                int pID = Convert.ToInt32(e.CommandArgument);
                // either put ID in session and check 
                Session["compID"] = Convert.ToString(te.Text);
                Response.Redirect("~/Complaint");
            }
        }


        public void GetMachenics()
        {
            try
            {
                int param = 0;
                DataTable dt = new DataTable();
                TestService ESSSr = new TestService();
                dt = ESSSr.GetMachenics(param);
                ddlMachenic.DataSource = dt;
                ddlMachenic.DataTextField = "name";
                ddlMachenic.DataValueField = "MachenicID";
                ddlMachenic.DataBind();
                ddlMachenic.Items.Insert(0, "--Select--");
                ddlMachenic.Text = "";
            }
            catch
            {
            }
        }

       
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtComplaintId.Text = "";
            txtConsumerNo.Text = "";
            txtfromdate.Text = "";
            txttodate.Text = "";
            ddlMachenic.SelectedIndex = 0;
            txtContact.Text = "";

        }


 

        protected void btnSubmit_Click(object sender, EventArgs e)
        { 
            fillgrid();

        }



    }
}