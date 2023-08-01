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
    public partial class Machenic_Reports : System.Web.UI.Page
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
                GetParticulars();
                GetMachenics();
                ddlMachenic.Text = "";
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


        public void FillGrid()
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

            dt = ESSSr.ViewMechanicReports(ddlReportType.SelectedIndex == 0 ? 0 : 1, ddlMachenic.SelectedItem.Text == "--ALL--" ? "" : ddlMachenic.SelectedItem.Text, ddlParticulars.SelectedItem.Text == "--ALL--" ? "" : ddlParticulars.SelectedItem.Text, fromDate, toDate);
            lblcount.Text = "Total Records: " + Convert.ToString(dt.Rows.Count);
            if (dt.Rows.Count != 0)
            {
                gvList.DataSource = dt;

                gvList.DataBind();
                
                lblMsg.Text = "";


                ReportViewer1.Visible = true;

                if (ddlReportType.SelectedIndex == 0)
                {
                    this.ReportViewer1.Reset();
                    this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/MachanicCollection.rdlc");
                    ds.Name = "MachenicCollectionDataset";
                    ds.Value = dt;

                }
                else if (ddlReportType.SelectedIndex == 1)
                {
                    this.ReportViewer1.Reset();
                    this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/StockUsed.rdlc");

                    ds.Name = "StockUsed";
                    ds.Value = dt;
                }
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
            FillGrid();

            
        }

        public void resetall()
        {

            ddlMachenic.SelectedIndex = 0;
            ddlReportType.SelectedIndex = 0;
            txtfromdate.Text = "";
            txttodate.Text = "";
            ddlParticulars.SelectedIndex = 0;
            DivParticulars.Visible = false;
 
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            resetall();
            FillGrid();
            
        }


        public void GetParticulars()
        {
            try
            {
                int param = 0;
                DataTable dt = new DataTable();
                TestService ESSSr = new TestService();
                dt = ESSSr.GetParticulars(param);
                ddlParticulars.DataSource = dt;
                ddlParticulars.DataTextField = "particular";
                ddlParticulars.DataValueField = "ID";
                ddlParticulars.DataBind();
                ddlParticulars.Items.Insert(0, "--ALL--");
                ddlParticulars.Text = "";
            }
            catch
            {
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
                ddlMachenic.Items.Insert(0, "--ALL--");
                ddlMachenic.Text = "";
            }
            catch
            {
            }
        }

        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReportType.SelectedIndex==1)
            {
                DivParticulars.Visible = true;
            }
            if (ddlReportType.SelectedIndex == 0)
            {
                DivParticulars.Visible = false;
            }
        }
    
    }
}