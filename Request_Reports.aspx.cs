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
using System.Drawing;
using Microsoft.Reporting.WebForms;


namespace TestWebservice
{
    public partial class Request_Reports : System.Web.UI.Page
    {
        TestService ESSSr = new TestService();
        string strMsg, Id, UserType;
        int x = 0;
        string ComplaintId;
        ReportDataSource ds = new ReportDataSource();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserList();
                //FillRequestType();
                FillRequestsList();
                resetall();
                //txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");
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

        public void FillRequestsList()
        {
            try
            {
                int param = 10;
                DataTable dt = new DataTable();
                TestService ESSSr = new TestService();
                dt = ESSSr.GetRequestsList(param);
                ddlRequestType.DataSource = dt;
                ddlRequestType.DataTextField = "Requests";
                ddlRequestType.DataValueField = "RequestListID";
                ddlRequestType.DataBind();
                ddlRequestType.Items.Insert(0, "--ALL--");
                ddlRequestType.Text = "";
            }
            catch
            {
            }

        }

        public void resetall()
        {
           
            ddlstatus.SelectedIndex = 0;
            ddlUser.SelectedIndex = 0;
            txtfromdate.Text = "";
            txttodate.Text = "";

        }

     
        public void GetUserList()
        {
            try
            {
                int param = 1;
                DataTable dt = new DataTable();
                TestService ESSSr = new TestService();
                dt = ESSSr.GetUserList(param);
                ddlUser.DataSource = dt;
                ddlUser.DataTextField = "Name";
                ddlUser.DataValueField = "UserId";
                ddlUser.DataBind();
                ddlUser.Items.Insert(0, "--ALL--");
                ddlUser.Text = "";
            }
            catch
            {
            }
        }

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

            dt = ESSSr.ViewRequestReports(ddlstatus.SelectedValue == "--ALL--" ? "" : ddlstatus.SelectedValue, ddlUser.SelectedItem.Text == "--ALL--" ? "" : ddlUser.SelectedItem.Text, ddlRequestType.SelectedItem.Text == "--ALL--" ? "" : ddlRequestType.SelectedItem.Text, fromDate, toDate);
           lblcount.Text = "Total Records: " + Convert.ToString(dt.Rows.Count);
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
                
                lblMsg.Text = "";


                ReportViewer1.Visible = true;

                this.ReportViewer1.Reset();
                this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/RequiestReport.rdlc");
                ds.Name = "RequestDataset";
                ds.Value = dt;
                this.ReportViewer1.LocalReport.DataSources.Add(ds);
                this.ReportViewer1.LocalReport.Refresh();


            }
            else
            {
                lblMsg.Text = "No Records Found";
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            fillgrid();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            resetall();
            fillgrid();
        }

    }
}