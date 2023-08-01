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
using System.Text;

namespace TestWebservice
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        TestService ESSSr = new TestService();
        string strMsg, Id,Username;
        int x = 0 ;
        string ComplaintId;
        int TempConsumerID;
protected void Page_Load(object sender, EventArgs e)
        {

            Page.MaintainScrollPositionOnPostBack = true;

            if (Session["UserId"] != null)
            {
                Id = Session["UserId"].ToString();
            }
            if (Id == null)
            {
                Response.Redirect("~/login");
            }
            
            Username = Session["Username"].ToString();
            
            if (!Page.IsPostBack)
            {
                string pID = Convert.ToString(Session["cid"]);
                if (!string.IsNullOrEmpty(pID))
                {
                    int patientID = Convert.ToInt32(pID);
                    txtCompId.Text = Session["cid"].ToString(); ;

                    //Call Stored procedure which will insert this record with this ID
                    // to another table
                }
                fillParticulars();
                GetDetails();
                GetMachenics();
               
            }
           
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnsubmit);
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
                ddlMachenic.Text = "";
            }
            catch
            {
            }
        }
private string MakeCODetailsXml()
        {
            StringBuilder sbCODetails = new StringBuilder();
            string xmlCO = string.Empty;
            sbCODetails.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>");
            sbCODetails.Append("<ROOT>");

            foreach (GridViewRow gvr in this.Gvparticulars.Rows)
            {
                if (((CheckBox)gvr.FindControl("SumCheckBox1")).Checked == true)
                {
                    sbCODetails.Append("<CO ID='" + ReplaceSpecialCharacters(((Label)gvr.FindControl("lblParticularsID")).Text) + "'");
                    sbCODetails.Append(" QTY='" + (((TextBox)gvr.FindControl("txtQuantity")).Text.Trim() == "" ? "1" : ((TextBox)gvr.FindControl("txtQuantity")).Text) + "'");
                    sbCODetails.Append(" RATE='" + ReplaceSpecialCharacters(((Label)gvr.FindControl("lblRate")).Text) + "'/>");
                }
            }

            sbCODetails.Append("</ROOT>");

            xmlCO = sbCODetails.ToString();

            return xmlCO;
        }
protected string ReplaceSpecialCharacters(string inputString)
        {
            inputString = inputString.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&#39;").
                    Replace("\"", "&quot;");

            return inputString;
        }
public void fillParticulars()
        {
            int param = 0;
            DataTable dt = new DataTable();
            dt = ESSSr.GetParticulars(param);

            if (dt.Rows.Count != 0)
            {
                Gvparticulars.DataSource = dt;

                Gvparticulars.DataBind();
            }

        }
private void GetDetails()
        {

            // int ConsumerNo;
            string UserName = txtCompId.Text;
            //string UserName = Session["ConsumerNo"].ToString();
            DataTable dt = new DataTable();
            TestService ESSSr = new TestService();
            dt = ESSSr.GetComplaintDetail(UserName);
            DataRow row = dt.Rows[0];
            txtCompId.Text = row["ComplaintID"].ToString();
            txtConsumerNo.Text = row["ConsumerNo"].ToString();
            txtConsumerName.Text = row["ConsumerName"].ToString();
            txtConsumerComplaint.Text = row["ComplaintDetails"].ToString();
            txtConsumerMob.Text = row["ConsumerMob"].ToString();
            ddlMachenic.SelectedValue = row["MachenicID"].ToString();
            txtUserCr.Text = row["Username"].ToString();
            txtDateCr.Text = row["Complaint Date"].ToString();
            TempConsumerID = Int32.Parse(row["TempID"].ToString());

        }
protected void btnget_Click(object sender, EventArgs e)
        {
            GetDetails();
        }
protected void SumCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                double totAmt = 0;

                foreach (GridViewRow gvr in Gvparticulars.Rows)
                {
                    TextBox txtQty = (TextBox)gvr.FindControl("txtQuantity");
                    CheckBox chkSelect = (CheckBox)gvr.FindControl("SumCheckBox1");
                    Label lblRate = (Label)gvr.FindControl("lblRate");
                    //Label lblTot = (Label)chkSelect.NamingContainer.FindControl("tot");
                    if (chkSelect.Checked == true)
                    {
                        if (txtQty.Text.ToString().Trim() == "0") {
                            txtQty.Text = "1";
                        }
                    }
                     else
                    {
                        txtQty.Text = "0";
                    }
                    double rate = Convert.ToDouble(lblRate.Text);
                    double qty = txtQty.Text == "" ? 1 : Convert.ToDouble(txtQty.Text);

                    if (chkSelect.Checked == true)
                    {
                       
                        totAmt += rate * qty;
                    }
                   
                }

                txttotal.Text = Convert.ToString(totAmt);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double totAmt = 0;

                foreach (GridViewRow gvr in Gvparticulars.Rows)
                {
                    TextBox txtQty = (TextBox)gvr.FindControl("txtQuantity");
                    CheckBox chkSelect = (CheckBox)gvr.FindControl("SumCheckBox1");
                    Label lblRate = (Label)gvr.FindControl("lblRate");
                    //Label lblTot = (Label)chkSelect.NamingContainer.FindControl("tot");
                    double rate = Convert.ToDouble(lblRate.Text);
                    double qty = txtQty.Text == "" ? 1 : Convert.ToDouble(txtQty.Text);

                    if (chkSelect.Checked == true)
                    {
                        totAmt += rate * qty;
                    }
                }

                txttotal.Text = Convert.ToString(totAmt);
                
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }


        }
public void btnsubmit_Click1(object sender, EventArgs e)
        {
                if (txtremark.Text=="" && (ddlStatus.SelectedItem.Value == "2" || ddlStatus.SelectedItem.Value == "3"))
            {
                strMsg = "Remark Should Not Be Blank";
                Response.Write("<script>alert('" + strMsg + "')</script>");
                return;
            }
            
                if (txtinvoice.Text.Trim() == "" && txttotal.Text.Trim() != "") 
            { 
                 if (txtinvoice.Text.Trim() == "" && txttotal.Text.Trim() != "0")
             
                {
                        strMsg = "Invoice Number Should Not Be Blank";
                        Response.Write("<script>alert('" + strMsg + "')</script>");
                        return;
                }
                
            }

            
            
            string Today = DateTime.Now.ToString();
            TestService ESSSr = new TestService();
            DataTable dt = new DataTable();
            
            dt.Columns.Add(new System.Data.DataColumn("Qty", typeof(String)));

            ESSSr.ResolveComplaint(txtCompId.Text.Trim(), txtinvoice.Text.Trim() == "" ? "-" : txtinvoice.Text.Trim(), Convert.ToDateTime(Today), Convert.ToDouble(txttotal.Text == "" ? 0 : Convert.ToDouble(txttotal.Text)), Convert.ToInt32(Id), txtremark.Text, Convert.ToDouble(txtdiscount.Text.Trim() == "" ? 0 : Convert.ToDouble(txtdiscount.Text.Trim())),ddlMachenic.SelectedValue, ddlStatus.SelectedItem.Text, MakeCODetailsXml());
 
              sendSMS();


              if (ddlStatus.SelectedItem.Value == "1")
              {
                Session["cid"] = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Complaint Resolved Successfully');window.location ='Search';", true);
              }
              else if (ddlStatus.SelectedItem.Value == "2")
              {
                Session["cid"] = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Complaint Marked As Attended By Machenic');window.location ='Search';", true);
            }
              else if (ddlStatus.SelectedItem.Value == "3")
              {
                Session["cid"] = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Complaint Cancelled Successfully');window.location ='Search';", true);
            }
      
        }
public void sendSMS()
        {
            WebClient client = new WebClient();
            string cust, custmessage;
            cust = txtConsumerMob.Text;
            var temp_Id = "1707162453926225913";
            if ((txttotal.Text == "" || txttotal.Text == "0") && ddlStatus.SelectedItem.Value == "1")
            {
                custmessage = "Dear Customer, Your Complaint no." + txtCompId.Text + " has been resolved successfully." + Environment.NewLine + "Thank You." + Environment.NewLine + "Anita Gas Service";
                string baseURLcust = "http://88.99.209.80/http-tokenkeyapi.php?authentic-key=stFVRYXooMby6D63&senderid=AGSBPC&route=2&number=" + cust + "&message=" + custmessage+"&templateid="+temp_Id;
                //string baseURLcust = "http://www.weberleads.in/http-tokenkeyapi.php?authentic-key=3535416e6974616761733836361595828831&senderid=AGSBPC&route=2&number=" + cust + "&message=" + custmessage + "&templateid=" + temp_Id;
               // string baseURLcust = "http://www.weberleads.in/http-tokenkeyapi.php?authentic-key=3535416e6974616761733836361595828831&senderid=AGSBPC&route=2&number=" + cust + "&message=" + custmessage + "&templateid=" + temp_Id;
               // string baseURLcust = "https://www.hellotext.live/vb/apikey.php?apikey=stFVRYXooMby6D63&senderid=AGSBPC&templateid=" + temp_Id + "&number=" + cust + "&message=" + custmessage;
                //string baseURLcust = "https://www.hellotext.live/vb/apikey.php?apikey=stFVRYXooMby6D63&senderid=AGSBPC&templateid=" + temp_Id + "&number=" + cust + "&message=" + custmessage;

                //string baseURLcust = "http://ocs-sms.com/submitsms.jsp?user=bpclag1&key=b5c6686c0bXX&mobile=+91"
                //                        + cust + "&message=" + custmessage
                //                        + "&senderid=AGSBPC&accusage=1";
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                client.OpenRead(baseURLcust);
            }
            else if (txttotal.Text != "" && ddlStatus.SelectedItem.Value == "1")
            {
                {
                    var temp_Id1 = "1707162453842926782";
                    custmessage = "Dear Customer, Your Complaint no." + txtCompId.Text + " has been resolved successfully." + Environment.NewLine + "Your Bill No." + txtinvoice.Text + Environment.NewLine + "Bill Amount Recieved Rs." + txttotal.Text + ".00" + Environment.NewLine + "Thank You." + Environment.NewLine + "Anita Gas Service";
                    string baseURLcust = "http://88.99.209.80/http-tokenkeyapi.php?authentic-key=stFVRYXooMby6D63&senderid=AGSBPC&route=2&number=" + cust + "&message=" + custmessage + "&templateid=" + temp_Id1;
                    //string baseURLcust = "http://www.weberleads.in/http-tokenkeyapi.php?authentic-key=3535416e6974616761733836361595828831&senderid=AGSBPC&route=2&number=" + cust + "&message=" + custmessage + "&templateid=" + temp_Id1;
                    //string baseURLcust = "http://88.99.209.80/http-tokenkeyapi.php?authentic-key=stFVRYXooMby6D63&senderid=AGSBPC&route=2&number=" + temp_Id1 + "&number=" + cust + "&message=" + custmessage;

                    //string baseURLcust = "http://ocs-sms.com/submitsms.jsp?user=bpclag1&key=b5c6686c0bXX&mobile=+91"
                    //                        + cust + "&message=" + custmessage
                    //                        + "&senderid=AGSBPC&accusage=1";
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    client.OpenRead(baseURLcust);
                }


            }
        }
protected void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double total = 0;
                total = double.Parse(txttotal.Text) - double.Parse(txtdiscount.Text);
                txttotal.Text = total.ToString();
            }
            catch (Exception ex)
            {
            }
        }

}}