using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using Microsoft.Reporting.WebForms;

namespace TestWebservice
{
    public partial class Repors_Home : System.Web.UI.Page
        
    {
        string strMsg, Id, UserType;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ESSConn"].ConnectionString);
        //string msg;
        string Adate = DateTime.Now.Day.ToString();
        string AMonth = DateTime.Now.Month.ToString();
        string AYear = DateTime.Now.Year.ToString();
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
          //  Response.Redirect("ReportViewer.aspx");


            string Id = Session["Username"].ToString();
            string UserType = Session["UserType"].ToString();
            string query;
            try
            {
                if (UserType == "Admin")
                {

                    query = "SELECT * from ComplaintsView order by DateCr Desc";// where Username=" + Id;
                    //query = "SELECT * from ResolvedComplaints";// where Username=" + Id;

                }
                else
                {
                    query = "SELECT * from ComplaintsView where Username='" + Id + "'";
                }
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt1 = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt1);
                this.ReportViewer1.Reset();
                this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
                ReportDataSource ds = new ReportDataSource("DataSet1", dt1);
                this.ReportViewer1.LocalReport.DataSources.Add(ds);
                this.ReportViewer1.LocalReport.Refresh();
                con.Close();
             //   ReportViewer2.Visible = false;
              //  ReportViewer1.Visible = true;
            }
            catch
            {

            }

        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

            string Id = Session["Username"].ToString();
            string UserType = Session["UserType"].ToString();
            string query;
            try
            {
                if (UserType == "Admin")
                {

                    query = "SELECT * from OnlyComplaints where ComplaintStatus='Open'";// where Username=" + Id;

                }
                else
                {
                    query = "SELECT * from OnlyComplaints where ComplaintStatus='Open' and Username='" + Id + "'";
                }
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt2 = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt2);
                this.ReportViewer1.Reset();
                this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/PendingComplaints.rdlc");
                ReportDataSource ds = new ReportDataSource("DataSet1", dt2);
                this.ReportViewer1.LocalReport.DataSources.Add(ds);
                this.ReportViewer1.LocalReport.Refresh();
                con.Close();
              //  ReportViewer1.Visible = false;
              //  ReportViewer2.Visible = true;
            }
            catch
            {

            }
            
         
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            string Id = Session["Username"].ToString();
            string UserType = Session["UserType"].ToString();
            string query;
            try
            {
                if (UserType == "Admin")
                {

                    query = "SELECT * from ComplaintsView where InvoiceNo != '' Order by Machenic";// where Username=" + Id;

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt2);
                    this.ReportViewer1.Reset();
                    this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/MachanicCollection.rdlc");
                    ReportDataSource ds = new ReportDataSource("DataSet1", dt2);
                    this.ReportViewer1.LocalReport.DataSources.Add(ds);
                    this.ReportViewer1.LocalReport.Refresh();
                    con.Close();

                }
                else
                {
                    string strMsg = "You dont have Athority kindly Contact to your Admin !";
                    Response.Write("<script>alert('" + strMsg + "')</script>");
                    
                }
               
                //  ReportViewer1.Visible = false;
                //  ReportViewer2.Visible = true;
            }
            catch
            {

            }
            
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            string Id = Session["Username"].ToString();
            string UserType = Session["UserType"].ToString();
            string query;
            try
            {
                if (UserType == "Admin")
                {

                    query = "SELECT [Machenic]," +
		"Sum(CONVERT(DECIMAL(18,0),SurakshaSRT)) as SurakshaSRT,"+
		"Sum(CONVERT(DECIMAL(18,0),Clip)) as Clip," +
		"Sum(CONVERT(DECIMAL(18,0),Knob)) as Knob," +
		"Sum(CONVERT(DECIMAL(18,0),Jet)) as Jet," +
	 	"Sum(CONVERT(DECIMAL(18,0),NutBolt)) as NutBolt," +
	  "Sum(CONVERT(DECIMAL(18,0),LockPin)) as LockPin," +
      "Sum(CONVERT(DECIMAL(18,0),GasCock)) as GasCock," +
      "Sum(CONVERT(DECIMAL(18,0),BurnerAluSmall)) as BurnerAluSmall," +
      "Sum(CONVERT(DECIMAL(18,0),BurnerAluBig)) as BurnerAluBig," +
      "Sum(CONVERT(DECIMAL(18,0),SideChange)) as SideChange," +
      "Sum(CONVERT(DECIMAL(18,0),Nozzle)) as Nozzle," +
      "Sum(CONVERT(DECIMAL(18,0),Nipple)) as Nipple," +
      "Sum(CONVERT(DECIMAL(18,0),PanSupport)) as PanSupport," +
      "Sum(CONVERT(DECIMAL(18,0),BurnerTray)) as BurnerTray," +
      "Sum(CONVERT(DECIMAL(18,0),BurnerBrassSmall)) as BurnerBrassSmall," +
      "Sum(CONVERT(DECIMAL(18,0),BurnerBrassBig)) as BurnerBrassBig," +
      "Sum(CONVERT(DECIMAL(18,0),RubberLegs)) as RubberLegs," +
      "Sum(CONVERT(DECIMAL(18,0),spindle)) as spindle," +
      "Sum(CONVERT(DECIMAL(18,0),DPR)) as DPR," +
      "Sum(CONVERT(DECIMAL(18,0),FreeDPR)) as FreeDPR " +
      "FROM [DataSQL].[dbo].[ComplaintsView] group by Machenic";
      // where Username=" + Id;

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt2);
                    this.ReportViewer1.Reset();
                    this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/machenicStock.rdlc");
                    ReportDataSource ds = new ReportDataSource("DataSet1", dt2);
                    this.ReportViewer1.LocalReport.DataSources.Add(ds);
                    this.ReportViewer1.LocalReport.Refresh();
                    con.Close();

                }
                else
                {
                    string strMsg = "You dont have Athority kindly Contact to your Admin !";
                    Response.Write("<script>alert('" + strMsg + "')</script>");

                }

                //  ReportViewer1.Visible = false;
                //  ReportViewer2.Visible = true;
            }
            catch
            {

            }

        }

            


        
    }
}