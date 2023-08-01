using System;
using System.Collections;
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
using System.IO;
using System.Web.Script.Serialization;
using TestWebservice;
using static System.Net.Mime.MediaTypeNames;
using AjaxControlToolkit.HtmlEditor.ToolbarButtons;


namespace TestWebservice
{
    public partial class Complaint : System.Web.UI.Page
    {
        TestService ESSSr = new TestService();
        ArrayList requests;
        ArrayList OpenRequest;
        string strMsg, Id, UserType, complaint, ComplaintId, Reqname, ReqId, pID, UserName, DuplicateCompID, isDuplicate;
        int x = 0;
        int y = 0;
        int TempConsumerID = 0;
        string DateCr = DateTime.Now.ToString();

        //--------------------------Rahul Singh 25 Nov 2021---------------------------------------------//
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ESSConn"].ToString());
        //SqlConnection con = null;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        SqlTransaction transaction;
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
            txtMachContact.Attributes.Add("readonly", "readonly");
            if (!IsPostBack)
            {
                GetComplaintlist(0);
                GetMachenics();
                fillgrid();
                fillgridEnquiry();
                rdbConsumerType.SelectedIndex = 0;
                rdbComplaintType.SelectedIndex = 0;


                hdnUpdateID.Value = Convert.ToString(Session["compID"]);
                if (hdnUpdateID.Value != "")
                {
                    GetDetails();
                    Session["compID"] = null;
                }
            }
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnSubmit);
            scriptManager.RegisterPostBackControl(this.GetConsNO);
            //scriptManager.RegisterPostBackControl(this.GetDetails());

        }
        private void GetDetails()
        {
            try
            {
                rdbComplaintType.SelectedIndex = 0;
                txtConsumerNo.ReadOnly = true;
                GetConsNO.Visible = false;
                rdbConsumerType.Enabled = false;
                rdbComplaintType.Enabled = false;

                // int ConsumerNo;
                //string UserName = compid;
                //string UserName = Session["ConsumerNo"].ToString();
                DataTable dt = new DataTable();
                TestService ESSSr = new TestService();
                dt = ESSSr.GetComplaintDetail(hdnUpdateID.Value);
                if (dt.Rows.Count == 0)
                {
                    strMsg = "Consumer Doesnot Exist.. Please Update Consumer List.";
                    Response.Write("<script>alert('" + strMsg + "')</script>");
                    return;
                }
                DataRow row = dt.Rows[0];
                // txtCompId.Text = row["ID"].ToString();
                if (row["ConsumerNo"].ToString().Trim() == "0")
                {
                    GetComplaintlist(1);
                    rdbConsumerType.SelectedIndex = 1;

                    txtConsumerNo.ReadOnly = true;
                    GetConsNO.Visible = false;
                }
                else
                {
                    rdbConsumerType.SelectedIndex = 0;
                }

                if (row["ConsumerNo"].ToString().Trim() == "0")
                {
                    txtConsumerNo.Text = "New Consumer";
                }
                else
                {
                    txtConsumerNo.Text = row["ConsumerNo"].ToString();
                }
                txtName.Text = row["ConsumerName"].ToString();
                txtComplaints.Text = row["ComplaintDetails"].ToString();
                txtContact.Text = row["ConsumerMob"].ToString();
                ddlcomplaintlist.SelectedValue = row["ComplaintListID"].ToString();
                ddlMachenic1.SelectedValue = row["MachenicID"].ToString();
                txtAddress.Text = row["ConsumerAddress"].ToString();
                txtMachContact.Text = row["MachContact"].ToString();
                if (row["ComplaintListID"].ToString().Trim() == "17")
                {

                    txtComplaints.Attributes.Add("style", "display:block");
                    txtComplaints.Text = row["ComplaintDetails"].ToString().Trim();
                }
                else
                {
                    txtComplaints.Attributes.Add("style", "display:none");
                }

                ddlMachenic1.Enabled = true;
                chkSMS.Enabled = true;
                chkSMS.Checked = true;
                chkCRC.Enabled = true;
                txtNote.ReadOnly = false;
            }
            catch (Exception ex)
            {
                strMsg = ex.Message.ToString();
                Response.Write("<script>alert('" + strMsg + "')</script>");

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + strMsg+ "')", true);

            }
        }
        public void FillEnquiryList(int IsNewConsumer)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = ESSSr.GetEnquiryList(IsNewConsumer);

                if (dt.Rows.Count != 0)
                {
                    GvEnquiry.DataSource = dt;

                    GvEnquiry.DataBind();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }

        }
        public void FillRequestsList(int IsNewConsumer)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ESSSr.GetRequestsList(IsNewConsumer);

                if (dt.Rows.Count != 0)
                {
                    GvRequest.DataSource = dt;

                    GvRequest.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
        private void GetUserDetail()
        {
            try
            {
                // int ConsumerNo;
                UserName = txtConsumerNo.Text;
                //string UserName = Session["ConsumerNo"].ToString();
                DataTable dt = new DataTable();
                TestService ESSSr = new TestService();
                dt = ESSSr.GetConsumerDetail(UserName);
                if (dt.Rows.Count == 0)
                {
                    strMsg = "Consumer Does Not Exsist. Please Update Consumer List";
                    Response.Write("<script>alert('" + strMsg + "')</script>");
                    ResetAll();
                    return;
                }
                DataRow row = dt.Rows[0];
                txtConsumerNo.Text = row["ConsumerNo"].ToString();
                txtName.Text = row["ConsumerName"].ToString();
                txtAddress.Text = row["ConsumerAddress"].ToString();
                txtContact.Text = row["ConsumerMob"].ToString();
                rdbComplaintType.Focus();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
        protected void btnGetCons_Click(object sender, EventArgs e)
        {
            try
            {
                int n;
                bool isNumeric = int.TryParse(txtConsumerNo.Text, out n);
                if (isNumeric == true)
                {
                    GetUserDetail();
                    fillConsgrid();
                    Resethalf();
                }
                else
                {
                    txtConsumerNo.Text = "";
                    strMsg = "Please Input Consumer Number Properly";
                    Response.Write("<script>alert('" + strMsg + "')</script>");
                    //this.Page_Load(sender,e);
                    ResetConsumerDetails();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

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
                ddlMachenic1.DataSource = dt;
                ddlMachenic1.DataTextField = "name";
                ddlMachenic1.DataValueField = "MachenicID";
                ddlMachenic1.DataBind();
                ddlMachenic1.Items.Insert(0, "--Select--");
                ddlMachenic1.Text = "";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
        public void GetComplaintlist(int IsNewConsumer)
        {
            try
            {
                DataTable dt = new DataTable();
                TestService ESSSr = new TestService();
                dt = ESSSr.GetComplaintlist(IsNewConsumer);
                ddlcomplaintlist.DataSource = dt;
                ddlcomplaintlist.DataTextField = "complaints";
                ddlcomplaintlist.DataValueField = "compid";
                ddlcomplaintlist.DataBind();
                ddlcomplaintlist.Items.Insert(0, "--Select--");
                //ddlcomplaintlist.SelectedIndex = 0;
                //ddlcomplaintlist.Text = "";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
        public void GetComplaintNo()
        {
            try
            {
                //string name = ddlMachenic1.SelectedItem.Text;
                DataTable dt = new DataTable();
                TestService ESSSr = new TestService();
                dt = ESSSr.GetComplaintNo();
                DataRow row = dt.Rows[0];
                ComplaintId = row["ID"].ToString();

                x = Int32.Parse(ComplaintId);
                // x = x + 1;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }
        public void getNewTempID()
        {
            try
            {
                //string name = ddlMachenic1.SelectedItem.Text;
                DataTable dt = new DataTable();
                TestService ESSSr = new TestService();
                dt = ESSSr.getNewTempID();
                DataRow row = dt.Rows[0];
                TempConsumerID = Int32.Parse(row["ID"].ToString());
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }

        }
        private string MakeEnquiryXml()
        {

            StringBuilder sbCODetails = new StringBuilder();
            string xmlCO = string.Empty;
            sbCODetails.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>");
            sbCODetails.Append("<ROOT>");

            foreach (GridViewRow gvr in this.GvEnquiry.Rows)
            {
                if (((CheckBox)gvr.FindControl("Enqchkbox")).Checked == true)
                {
                    sbCODetails.Append("<CO ID='" + ReplaceSpecialCharacters(((Label)gvr.FindControl("lblEnquiryID")).Text) + "'/>");
                }
            }

            sbCODetails.Append("</ROOT>");

            xmlCO = sbCODetails.ToString();

            return xmlCO;
        }
        private string MakeRequestXml()
        {
            StringBuilder sbCODetails = new StringBuilder();
            requests = new ArrayList();
            OpenRequest = new ArrayList();
            string xmlCO = string.Empty;
            sbCODetails.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>");
            sbCODetails.Append("<ROOT>");

            foreach (GridViewRow gvr in this.GvRequest.Rows)
            {
                if (((CheckBox)gvr.FindControl("Reqchkbox")).Checked == true)
                {
                    sbCODetails.Append("<CO ID='" + ReplaceSpecialCharacters(((Label)gvr.FindControl("lblRequestID")).Text) + "'/>");
                    if (((Label)gvr.FindControl("lblIsOpen")).Text == "1")
                    {
                        OpenRequest.Add(((Label)gvr.FindControl("lblRequests")).Text);
                    }
                    else
                    {
                        requests.Add(((Label)gvr.FindControl("lblRequests")).Text);
                    }
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
        public void SaveNewConsumer()
        {
            try
            {
                txtConsumerNo.Text = "0";
                ESSSr.SaveNewConsumer(txtName.Text.Trim(), txtContact.Text.Trim(), txtAddress.Text, Convert.ToDateTime(DateCr), Id);
                getNewTempID();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
        public void ResetConsumerDetails()
        {
            txtConsumerNo.Text = "";
            txtName.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
        }
        public void ResetAll()
        {
            try
            {
                hdnUpdateID.Value = "";
                rdbConsumerType.SelectedIndex = 0;
                rdbConsumerType.Enabled = true;
                txtConsumerNo.ReadOnly = false;
                rdbComplaintType.Enabled = true;
                GetConsNO.Visible = true;
                ResetConsumerDetails();
                rdbComplaintType.SelectedIndex = 0;

                DivComplaint.Visible = true;
                DivEnquiry.Visible = false;
                DivRequest.Visible = false;
                ddlMachenic1.Enabled = false;
                txtName.ReadOnly = true;

                Resethalf();


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
        public void Resethalf()
        {
            try
            {
                GetComplaintlist(0);
                ddlMachenic1.SelectedIndex = 0;
                //txtComplaints.Visible = false;
                txtComplaints.Text = "";
                ddlcomplaintlist.SelectedIndex = 0;
                txtMachContact.Text = "";
                chkSMS.Checked = false;
                chkSMS.Enabled = false;
                chkCRC.Checked = false;
                chkCRC.Enabled = false;
                txtNote.Text = "";
                txtNote.ReadOnly = true;


                txtConsumerNo.Focus();
                txtReqRemark.Text = "";
                txtEnquiryRemark.Text = "";

                foreach (GridViewRow row in GvEnquiry.Rows)
                {
                    CheckBox chkcheck = (CheckBox)row.FindControl("Enqchkbox");
                    chkcheck.Checked = false;
                }

                foreach (GridViewRow row in GvRequest.Rows)
                {
                    CheckBox chkcheck = (CheckBox)row.FindControl("Reqchkbox");
                    chkcheck.Checked = false;
                }



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
        public void fillgrid()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ESSSr.ViewComplaints(Id);
                lblcount.Text = "Total Records: " + Convert.ToString(dt.Rows.Count);

                if (dt.Rows.Count != 0)
                {
                    grdComplaint.DataSource = dt;
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        if (dt.Rows[i][1].ToString().Trim() == "0")
                        {
                            dt.Rows[i][1] = dt.Rows[i][1].ToString().Replace("0", "New Consumer");
                        }
                    }
                    grdComplaint.DataBind();

                    //Attribute to show the Plus Minus Button.
                    grdComplaint.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    grdComplaint.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                    grdComplaint.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                    grdComplaint.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                    grdComplaint.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
                    grdComplaint.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
                    grdComplaint.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";
                    grdComplaint.HeaderRow.Cells[8].Attributes["data-hide"] = "phone";


                    //Adds THEAD and TBODY to GridView.
                    grdComplaint.HeaderRow.TableSection = TableRowSection.TableHeader;

                    lblMsg.Text = "";
                }
                else
                {
                    lblMsg.Text = "No Records Found";

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
        public void fillConsgrid()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ESSSr.ViewConsComplaints(UserName);
                lblcount.Text = "Total Records: " + Convert.ToString(dt.Rows.Count);
                if (dt.Rows.Count != 0)
                {
                    grdComplaint.DataSource = dt;

                    grdComplaint.DataBind();
                    lblMsg.Text = "";

                }
                else
                {
                    lblMsg.Text = "No Records Found";
                    this.grdComplaint.DataSource = null;
                    grdComplaint.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
        public void fillgridEnquiry()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ESSSr.ViewEnquiry(Id);
                lblEnqCount.Text = "Total Records: " + Convert.ToString(dt.Rows.Count);
                if (dt.Rows.Count != 0)
                {
                    grdEnquiry.DataSource = dt;
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        if (dt.Rows[i][1].ToString().Trim() == "0")
                        {
                            dt.Rows[i][1] = dt.Rows[i][1].ToString().Replace("0", "New Consumer");
                        }
                    }
                    grdEnquiry.DataBind();



                    lblMsg1.Text = "";
                }
                else
                {
                    lblMsg1.Text = "No Records Found of Enquiry";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
        public void sendSMS()
        {
            WebClient client = new WebClient();
            WebClient client1 = new WebClient();
            string mach, cust, machmessage, custmessage, ConsumerNumber;
            //var tmp_Id = "1707163352489877565";
            var tmp_Id = "1707167842874740462";
            mach = txtMachContact.Text;
            ConsumerNumber = txtConsumerNo.Text == "0" ? "New" : txtConsumerNo.Text;
            string splitadd = txtAddress.Text;
            int lastSpaceIndex = splitadd.LastIndexOf(' ');
            var Address1 = "";
            var Address2 = "";
            if (lastSpaceIndex >= 0)
            {
                string fulladdr = splitadd.Substring(0, lastSpaceIndex);
                if(fulladdr.Length<=60)
                {
                    Address1=fulladdr.Substring(0,30);
                    Address2 = fulladdr.Substring(30, fulladdr.Length-30);
                }
                else
                {
                    Address1 = fulladdr.Substring(0,60);
                    Address2 = fulladdr.Substring(60,fulladdr.Length-60);
                    if(Address2.Length>30)
                    {
                        Address2 = "N/A";
                    }
                }
            }

            //var add1=
            //Dear technician, Consumer No -{#var#} Name-{#var#} Add 1-{#var#} {#var#} Add 2 -{#var#} \n Mob-{#var#} Problem-{#var#} Thank You, -Anita Gas Service
            //Dear Consumer, your Complaint has been logged successfully. Complaint Id.-{#var#} Our mechanic Mr.{#var#} will attend your complaint soon Thank You. -Anita Gas Service

            if (chkCRC.Checked == true)
            {
                    //machmessage = chkCRC.Text + Environment.NewLine + "Dear technician Consmr.No-" + ConsumerNumber + Environment.NewLine + txtName.Text + Environment.NewLine + txtAddress.Text + Environment.NewLine + "Mob-" + txtContact.Text + Environment.NewLine + "Problm-" + complaint + Environment.NewLine + txtNote.Text + Environment.NewLine + " Thank You." + Environment.NewLine + "Anita Gas Service";
                    // machmessage = "Dear technician Consmr.No-" + ConsumerNumber + Environment.NewLine + "Name-" + txtName.Text + Environment.NewLine + "Add-" + txtAddress.Text + Environment.NewLine + "Mob-" + txtContact.Text + Environment.NewLine + "Problm-" + complaint + Environment.NewLine + "CRC Call" + Environment.NewLine + " Thank You." + Environment.NewLine + "Anita Gas Service";
                   // machmessage = "Dear technician Consmr.No-" + ConsumerNumber + Environment.NewLine + "Name-" + txtName.Text + Environment.NewLine + "Add-" + txtAddress.Text + Environment.NewLine + "Mob-" + txtContact.Text + Environment.NewLine + "Problm-" + complaint + Environment.NewLine + "CRC Call" + Environment.NewLine + " Thank You." + Environment.NewLine + "Anita Gas Service";
                machmessage = "Dear technician, Consumer No -" + ConsumerNumber + " Name-" + txtName.Text + " Add 1-" + Address1 + " Add 2 -" + Address2 + Environment.NewLine + " Mob-" + txtContact.Text + " Problem-" + complaint +" CRC Call" + " Thank You, -Anita Gas Service";
            }
            else
            {
                    // machmessage = "Dear technician Consmr.No-" + ConsumerNumber + Environment.NewLine + "Name-" + txtName.Text + Environment.NewLine + "Add-" + txtAddress.Text + Environment.NewLine + "Mob-" + txtContact.Text + Environment.NewLine + "Problm-" + complaint + Environment.NewLine + txtNote.Text + Environment.NewLine + " Thank You." + Environment.NewLine + "Anita Gas Service";
                    machmessage = "Dear technician, Consumer No -" + ConsumerNumber + " Name-" + txtName.Text + " Add 1-" + Address1 + " Add 2 -" + Address2 + Environment.NewLine + " Mob-" + txtContact.Text + " Problem-" + complaint+ " Thank You, -Anita Gas Service";
                }
            cust = txtContact.Text;
            //var tmp_Id1 = "1707162453864136154";
            var tmp_Id1 = "1707167750068606800";
                custmessage = "Dear Consumer, your Complaint has been logged successfully. Complaint Id.-" + x + " Our mechanic Mr." + ddlMachenic1.SelectedItem.Text + " will attend your complaint soon Thank You. -Anita Gas Service";
                //string baseURLmach = "http://www.hellotext.live/vb/apikey.php?apikey=stFVRYXooMby6D63&senderid=AGSBPC&route=2&number=" + mach + "&message=" + machmessage + "&templateid=" + tmp_Id;
                // ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                //string baseURLmach = "https://www.hellotext.live/vb/apikey.php?apikey=stFVRYXooMby6D63&senderid=AGSBPC&templateid=" + tmp_Id + "&number=" + mach + "&message=" + machmessage;
                //client.OpenRead(baseURLmach);
                //https://www.hellotext.live/vb/http-customize.php?apikey=XXXXXXXXXXXXXXXXXXXX&senderid=XXXXXX&number=XXXXXXXXXX,XXXXXXXXXX,XXXXXXXXXX&message=meesage1^meesage2^meesage3&templateid=tid1^tid2^tid3
                //string baseURLmach = "https://www.hellotext.live/vb/http-customize.php?apikey=stFVRYXooMby6D63&senderid=AGSBPC&number="+mach+","+cust+"&message="+machmessage+"^"+custmessage+"&templateid="+tmp_Id+"^"+tmp_Id1+"";
                // string baseURLmach = "https://www.hellotext.live/vb/http-customize.php?apikey=stFVRYXooMby6D63&senderid=AGSBPC&number=" + mach + "," + cust + "&message=" + machmessage + "^" + custmessage + "&templateid=" + tmp_Id + "^" + tmp_Id1 + "";
                string baseURLmach = "http://88.99.209.80/http-tokenkeyapi.php?authentic-key=stFVRYXooMby6D63&senderid=AGSBPC&route=2&number=" + mach + "&message=" + machmessage + "&templateid=" + tmp_Id;
            client.OpenRead(baseURLmach);
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            ////string baseURLcust = "https://www.hellotext.live/vb/apikey.php?apikey=stFVRYXooMby6D63&senderid=AGSBPC&templateid=" + tmp_Id1 + "&number=" + cust + "&message=" + custmessage;
            string baseURLcust = "http://88.99.209.80/http-tokenkeyapi.php?authentic-key=stFVRYXooMby6D63&senderid=AGSBPC&route=2&number=" + cust + "&message=" + custmessage + "&templateid=" + tmp_Id1;
            client1.OpenRead(baseURLcust);
            //GetTokenId(mach);
        }

        
        public void sendRequestSMS()
        {
            WebClient client = new WebClient();
            StringBuilder req = new StringBuilder();
            string cust, custmessage;
            cust = txtContact.Text;
            var tmp_Id = "1707169036513078095";
            foreach (var item in requests)
            {
                req.Append(item);
                req.Append(",");
            }
            custmessage = "Dear Consumer, Your Request for " + req.ToString() + " has been proceessed successfully." + Environment.NewLine + " Thank You." + Environment.NewLine + "Anita Gas Service";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            //string baseURLcust = "https://www.hellotext.live/vb/apikey.php?apikey=stFVRYXooMby6D63&senderid=AGSBPC&templateid=" + tmp_Id + "&number=" + cust + "&message=" + custmessage;
            string baseURLcust = "http://88.99.209.80/http-tokenkeyapi.php?authentic-key=stFVRYXooMby6D63&senderid=AGSBPC&route=2&number=" + cust + "&message=" + custmessage + "&templateid=" + tmp_Id;
            client.OpenRead(baseURLcust);
        }
        public void sendRequestSMS1()
        {
            WebClient client = new WebClient();
            StringBuilder req = new StringBuilder();
            string cust, custmessage;
            cust = txtContact.Text;
            var tmp_Id = "1707162436947543948";
            foreach (var item in OpenRequest)
            {
                req.Append(item);
                req.Append(",");
            }
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            custmessage = "Dear Consumer, Your Request for " + req.ToString() + " has been logged successfully, Your Request will be updated soon." + Environment.NewLine + " Thank You." + Environment.NewLine + "Anita Gas Service";
            string baseURLcust = "http://88.99.209.80/http-tokenkeyapi.php?authentic-key=stFVRYXooMby6D63&senderid=AGSBPC&route=2&number=" + cust + "&message=" + custmessage + "&templateid=" + tmp_Id;
            client.OpenRead(baseURLcust);
        }

        public void GetTokenId(string MobileNo)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ESSConn"].ToString());
            cmd = new SqlCommand("CMS_USPGetTokenId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            con.Open();
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            da.Dispose();
            string tokenId=ds.Tables[0].Rows[0]["TokenID"].ToString();

            //----------------------------------
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ESSConn"].ToString());
            cmd = new SqlCommand("USP_Notification", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            con.Open();
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            da.Dispose();
            notification noification = new notification();
            if (dt.Rows.Count == 1)
                {
               
                noification.body_content=dt.Rows[0]["body_content"].ToString();
                noification.notification_generated_date=dt.Rows[0]["notification_generated_date"].ToString();
                noification.title=dt.Rows[0]["title"].ToString();
                noification.notification_id=Convert.ToInt32(dt.Rows[0]["notification_id"]);
            }
           
            SendNotification(tokenId,noification);
        }


        //-----------------------------Rahul Singh 24 Nov 2021-----------------------------------------------------//
        public string SendNotification(string tokenID, notification noification)
        {
            //  "AAAATTJmEzM:APA91bE6CHYjCiJbzxgxxPSXSZ1vYWShkdmoDzILp0r2l3-BDAqysMFX7hTtcalyXz5F365x6--Rp7mWh0ddgMqYas8p54J5n0EGsXbLtXWBy49nafHPYyc92UZJykI4CGau2bp0xfZi";
            //string serverKey = "AAAAA8vUzh4:APA91bE97Jo41Q0fXs7SlsbMTmTjYhHPVgd2-A3M-NxEbhvM2svDCuYUoldjUvQV-o13g8_w2ol7s91fn0XtVFor8pfEZflp1eaw5xUlLKIFuv2COSmL6w8zURMvSpzmmGgIKuhOUgAM";
            string serverKey = "AAAAFRJl6pI:APA91bEDlRSyfhxZaAHUvuuyZ1hqgra_-6S0Gkiekryv_ODmh9G5EEobwERVylNWDh7B4gA2d0SMyCs9p9anRqr6t9_KXojNrEYV_TvjBz85twayChNdhqRX6VdLoxoXdf4aaJyh281V";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add("Authorization:key=" + serverKey);
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //   string json = "{\"to\": \"AAAATTJmEzM:APA91bE6CHYjCiJbzxgxxPSXSZ1vYWShkdmoDzILp0r2l3-BDAqysMFX7hTtcalyXz5F365x6--Rp7mWh0ddgMqYas8p54J5n0EGsXbLtXWBy49nafHPYyc92UZJykI4CGau2bp0xfZi\",\"data\": {\"message\": \"This is a Firebase Cloud Messaging Topic Message!\",}}";
                CustomNotificationReq notification = new CustomNotificationReq();
                notification.title = noification.title;
                notification.body = noification.body_content;
                notification data = new notification();
                data = noification;
                var notifi = new
                {
                    to = tokenID,
                    notification,
                    data
                };
                var serializer = new JavaScriptSerializer();
                var jsonData = serializer.Serialize(notifi);
                streamWriter.Write(jsonData);
                streamWriter.Flush();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd().ToString();
            }
        }

        //---------------------------------------------------------------------------------------------------------------------
        protected void grdComplaint_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdComplaint.PageIndex = e.NewPageIndex;
            fillgrid();
        }
        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    string te;
                    te = Convert.ToString(e.CommandArgument.ToString());
                    int pID = Convert.ToInt32(e.CommandArgument);
                    // either put ID in session and check 
                    Session["cID"] = Convert.ToString(te);
                    Response.Redirect("UpdateComplaint.aspx");
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
        protected void rdbConsumerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbConsumerType.SelectedValue == "1")
                {
                    ResetAll();
                    GetComplaintlist(0);

                    txtName.ReadOnly = true;
                    txtConsumerNo.ReadOnly = false;
                    GetConsNO.Visible = true;
                    ddlcomplaintlist.SelectedIndex = 0;

                }

                if (rdbConsumerType.SelectedValue == "2")
                {
                    ResetAll();
                    GetComplaintlist(1);
                    txtName.ReadOnly = false;
                    txtConsumerNo.Text = "New Consumer";
                    txtConsumerNo.ReadOnly = true;
                    GetConsNO.Visible = false;
                    txtName.Focus();
                    ddlcomplaintlist.SelectedIndex = 0;
                    rdbConsumerType.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
        protected void rdbComplaintType_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                if (rdbComplaintType.SelectedValue == "1")
                {
                    DivComplaint.Visible = true;
                    DivEnquiry.Visible = false;
                    DivRequest.Visible = false;
                    if (rdbConsumerType.SelectedIndex == 1)
                    {
                        GetComplaintlist(1);
                    }
                    else
                    {
                        GetComplaintlist(0);
                    }
                    Resethalf();
                }

                if (rdbComplaintType.SelectedValue == "2")
                {
                    DivComplaint.Visible = false;
                    DivEnquiry.Visible = false;
                    DivRequest.Visible = true;
                    Resethalf();
                    if (rdbConsumerType.SelectedIndex == 1)
                    {
                        FillRequestsList(1);
                    }
                    else
                    {
                        FillRequestsList(0);
                    }
                }

                if (rdbComplaintType.SelectedValue == "3")
                {
                    DivComplaint.Visible = false;
                    DivEnquiry.Visible = true;
                    DivRequest.Visible = false;
                    Resethalf();
                    if (rdbConsumerType.SelectedIndex == 1)
                    {
                        FillEnquiryList(1);
                    }
                    else
                    {
                        FillEnquiryList(0);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }


        }
        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbComplaintType.SelectedIndex == 0)
                {
                    if (ddlcomplaintlist.SelectedItem.Text == "OTHERS")
                    { complaint = txtComplaints.Text; }
                    else
                    {
                        txtComplaints.Text = ddlcomplaintlist.SelectedItem.Text;
                        complaint = txtComplaints.Text;
                    }
                    if (hdnUpdateID.Value != null && hdnUpdateID.Value != "")
                    {
                        ESSSr.UpdateComplaints(hdnUpdateID.Value, txtComplaints.Text, Id, Convert.ToDateTime(DateCr), ddlMachenic1.SelectedValue == "--Select--" ? "" : ddlMachenic1.SelectedValue, Convert.ToInt32(ddlcomplaintlist.SelectedValue));

                        GetComplaintNo();
                        if (chkSMS.Checked == true)
                        {
                            sendSMS();
                        }
                        strMsg = "Complaint Updated Successfully";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + strMsg + "')", true);
                        hdnUpdateID.Value = "";
                        ResetAll();
                        fillgrid();

                        return;
                    }
                    if (rdbConsumerType.SelectedIndex == 1)
                    {
                        SaveNewConsumer();
                    }

                    ESSSr.SaveComplaints(txtConsumerNo.Text.Trim(), complaint, "Open", Id, Convert.ToDateTime(DateCr), ddlMachenic1.SelectedValue == "--Select--" ? "" : ddlMachenic1.SelectedValue, Convert.ToInt32(ddlcomplaintlist.SelectedValue), TempConsumerID);
                    GetComplaintNo();
                    if (chkSMS.Checked == true)
                    {
                        sendSMS();
                    }
                    strMsg = "Complaint saved Successfully";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + strMsg + "')", true);
                    ResetAll();
                    fillgrid();

                    return;

                }


                if (rdbComplaintType.SelectedIndex == 1)
                {
                    if (rdbConsumerType.SelectedIndex == 1)
                    {
                        SaveNewConsumer();
                    }
                    ESSSr.SaveRequest(txtConsumerNo.Text.Trim(), txtReqRemark.Text, Id, Convert.ToDateTime(DateCr), Convert.ToDateTime(DateCr), TempConsumerID, MakeRequestXml());
                    strMsg = "Request saved Successfully";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + strMsg + "')", true);
                    if (requests.Count > 0)
                    {
                        sendRequestSMS();
                    }
                    if (OpenRequest.Count > 0)
                    {
                        sendRequestSMS1();
                    }

                    ResetAll();
                    return;
                }


                if (rdbComplaintType.SelectedIndex == 2)
                {
                    if (rdbConsumerType.SelectedIndex == 1)
                    {
                        SaveNewConsumer();
                    }
                    ESSSr.SaveEnquiry(TempConsumerID, txtConsumerNo.Text.Trim(), txtEnquiryRemark.Text, Id, Convert.ToDateTime(DateCr), MakeEnquiryXml());
                    strMsg = "Enquiry saved Successfully";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + strMsg + "')", true);

                    //Response.Write("<script>alert('" + strMsg + "')</script>");
                    ResetAll();
                    fillgridEnquiry();
                    return;

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message.ToString() + "')", true);

            }
            finally
            {
            }
        }
        [WebMethod]
        public static string CheckForDuplicateComplaint(string ConNo, string ConName, string ConContact, string ConComplaint)
        {
            string isDuplicate = null;
            try
            {
                DataTable dt = new DataTable();
                TestService ESSSr = new TestService();
                dt = ESSSr.duplicatecomplaint(ConNo, ConName, ConContact, ConComplaint);
                if (dt.Rows.Count != 0)
                {
                    DataRow row = dt.Rows[0];
                    isDuplicate = row["ComplaintID"].ToString();

                }

                dt = null;
                ESSSr.Dispose();
            }
            catch (Exception ex)
            {

            }

            return isDuplicate;


        }
        [WebMethod]
        public static string getmachcontact(string Mach)
        {
            string MachencContact = null;
            try
            {
                string name = Mach;
                DataTable dt = new DataTable();
                TestService ESSSr = new TestService();
                dt = ESSSr.GetMachenicContact(name);

                if (dt.Rows.Count != 0)
                {
                    DataRow row = dt.Rows[0];
                    MachencContact = row["contact"].ToString();

                }

                dt = null;
                ESSSr.Dispose();
            }
            catch (Exception ex)
            {

            }

            return MachencContact;


        }




    }

}

