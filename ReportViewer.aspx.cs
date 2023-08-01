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
using System.Drawing;
using Microsoft.Reporting.WebForms;

namespace TestWebservice
{
    public partial class ReportViewer : System.Web.UI.Page
    {

        TestService ESSSr = new TestService();
        string strMsg,Id, UserType;
        int x = 0;
        string ComplaintId;
        string UserName;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ESSConn"].ConnectionString);
        //string msg;
        string Adate = DateTime.Now.Day.ToString();
        string AMonth = DateTime.Now.Month.ToString();
        string AYear = DateTime.Now.Year.ToString();
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string Id = Session["Username"].ToString();
                string UserType = Session["UserType"].ToString();
                string query;
                try
                {
                    if (UserType == "Admin")
                    {
                       
                         query = "SELECT * from ComplaintsView";// where Username=" + Id;
                      
                    }
                    else
                    {
                        query = "SELECT * from ComplaintsView where Username='"+ Id + "'";
                    }
                    fillgrid();

                }
                catch
                {

                }
            }
        }


        public void fillgrid()
        {
            DataTable dt = new DataTable();
            dt = ESSSr.ViewComplaints(Id);
            if (dt.Rows.Count != 0)
            {
                
                //SqlCommand cmd = new SqlCommand(query, con);
                //DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(dt);
                this.ReportViewer1.Reset();
                this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
                ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                this.ReportViewer1.LocalReport.DataSources.Add(ds);
                this.ReportViewer1.LocalReport.Refresh();
               // con.Close();
            }
            else
            {
                //lblMsg.Text = "No Records Found";
            }
        }
    }
}