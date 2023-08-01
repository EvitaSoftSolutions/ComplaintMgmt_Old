﻿using System;
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
    public partial class Complaint_Reports : System.Web.UI.Page
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
                GetMachenics();
                GetComplaintsType();
                ddlMachenic.Text = "";
                resetall();
                fillgrid();
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


        public void GetComplaintsType()
        {
            try
            {
                DataTable dt = new DataTable();
                TestService ESSSr = new TestService();
                dt = ESSSr.GetComplaintsType();
                ddlComplaintType.DataSource = dt;
                ddlComplaintType.DataTextField = "ComplaintDetails";
                ddlComplaintType.DataBind();
                ddlComplaintType.Items.Insert(0, "--ALL--");
                ddlComplaintType.Text = "";
            }
            catch
            {
            }
        }

        public void resetall()
        {
            ddlComplaintType.SelectedIndex = 0;
            ddlMachenic.SelectedIndex = 0;
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

            try
            {
                DataTable dt = new DataTable();
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

                dt = ESSSr.ViewComplaintReports(ddlstatus.SelectedValue == "--ALL--" ? "" : ddlstatus.SelectedValue, ddlUser.SelectedItem.Text == "--ALL--" ? "" : ddlUser.SelectedItem.Text, ddlMachenic.SelectedItem.Text == "--ALL--" ? "" : ddlMachenic.SelectedItem.Text, ddlComplaintType.SelectedItem.Text == "--ALL--" ? "" : ddlComplaintType.SelectedItem.Text, fromDate, toDate, UserType);
                lblcount.Text = "Total Records: " + Convert.ToString(dt.Rows.Count);
                if (dt.Rows.Count != 0)
                {
                    
                    
                   for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        if (dt.Rows[i][1].ToString().Trim() == "0")
                        {
                            dt.Rows[i][1] = dt.Rows[i][1].ToString().Replace("0", "New Consumer");
                        }
                    }
                   
                    lblMsg.Text = "";


                    ReportViewer1.Visible = true;

                    if (ddlstatus.SelectedIndex == 0)
                    {
                        this.ReportViewer1.Reset();
                        this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/AllComplaints.rdlc");
                        ds.Name = "AllComplaints";
                        ds.Value = dt;

                    }
                    else if (ddlstatus.SelectedIndex == 1)
                    {
                        this.ReportViewer1.Reset();
                        this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Resolved.rdlc");

                        ds.Name = "ResolvedDataSet";
                        ds.Value = dt;
                    }
                    else if (ddlstatus.SelectedIndex == 2)
                    {
                        this.ReportViewer1.Reset();
                        this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/PendingReport.rdlc");
                        ds.Name = "PendingDataset";
                        ds.Value = dt;
                    }
                    else if (ddlstatus.SelectedIndex == 3)
                    {
                        this.ReportViewer1.Reset();
                        this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/AttendedComplaints.rdlc");
                        ds.Name = "PendingDataSet";
                        ds.Value = dt;
                    }
                    else if (ddlstatus.SelectedIndex == 4)
                    {
                        this.ReportViewer1.Reset();
                        this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/CancelledComplaints.rdlc");
                        ds.Name = "PendingDataSet";
                        ds.Value = dt;
                    }
                    // ReportDataSource ds = new ReportDataSource("AllComplaints", dt);
                    this.ReportViewer1.LocalReport.DataSources.Add(ds);
                    this.ReportViewer1.LocalReport.Refresh();
                    //dt.Clear();

                }
                else
                {
                    ReportViewer1.Visible = false;
                    lblMsg.Text = "No Records Found";
                }
            }
            catch
            {
            }
            finally
            {
               // dt
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