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
using Microsoft.VisualBasic.FileIO;
using System.Web.UI.WebControls.WebParts;
using System.IO;

namespace TestWebservice
{
    public partial class SMSpanel : System.Web.UI.Page
    {
        string active, block;
        DataSet dsExcelData = new DataSet();
        ArrayList requests;
        WebClient client = new WebClient();
        StringBuilder req = new StringBuilder();
        string contact, custmessage, baseURLcust;
        protected void Page_Load(object sender, EventArgs e)
        {
            rbtSMSType.SelectedValue = "1";
            WebClient wc = new WebClient();
            //string urlData = (wc.DownloadString("http://ocs-sms.com/getbalance.jsp?user=bpclag1&key=b5c6686c0bXX&accusage=1")).Trim();
            string urlData = (wc.DownloadString("http://www.weberleads.in/http-token-credit.php?authentic-key=3535416e6974616761733836361595828831&route_id=2")).Trim();
            lblbalsms.Text = "SMS " + urlData; 

            //decimal dec = decimal.Parse(urlData);
            //lblbalsms.Text = "Balance SMS: " + dec.ToString("0.#");
            if (!IsPostBack)
            { }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
           lblErrMsg.Text = "";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            try
            {
                if (txtSMSText.Text == "")
                {
                    string strMsg = "Please Enter SMS Text";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + strMsg + "')", true);
                    return;

                }
                if (FileUpload1.HasFile)
                {
                    string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                    string FilePath = Server.MapPath(FolderPath + FileName);
                    FileUpload1.SaveAs(FilePath);
                    active = FileName.ToString();

                    // lblMeg.Text = "File uploaded : " + FilePath;

                    FileInfo fileInfo = new FileInfo(FilePath);
                    if (fileInfo.Exists)
                    {
                        //DataSet dsExcelData = new DataSet();
                        FileStream stream = File.Open(FilePath, FileMode.Open, FileAccess.Read);

                        string fileExt = fileInfo.Extension.ToString().Trim().ToLower();

                        if (fileExt == ".xls")
                        {
                            Excel.IExcelDataReader excelReader = Excel.ExcelReaderFactory.CreateBinaryReader(stream);

                            excelReader.IsFirstRowAsColumnNames = true;
                            dsExcelData = excelReader.AsDataSet();

                            Session["BulkSMS"] = dsExcelData;

                            dsExcelData.Clear();
                           
                        }
                        else if (fileExt == ".xlsx")
                        {
                            Excel.IExcelDataReader excelReader = Excel.ExcelReaderFactory.CreateOpenXmlReader(stream);
                            excelReader.IsFirstRowAsColumnNames = true;
                            dsExcelData = excelReader.AsDataSet();
                            Session["BulkSMS"] = dsExcelData;

                        }
                       
                        custmessage = txtSMSText.Text;
                        //------------------------------------


                        //---------------------------------------
                        for (int i = 0; i < dsExcelData.Tables[0].Rows.Count; i++)
                        {
                            contact = dsExcelData.Tables[0].Rows[i]["Mobile Number"].ToString();

                            if (RbtUnicode.Checked == true)
                            {
                                //    baseURLcust = "http://ocs-sms.com/submitsms.jsp?user=bpclag1&key=b5c6686c0bXX&mobile=+91" + contact + "&message=" + custmessage + "&senderid=BPCLAG&accusage=1&unicode=1";
                                baseURLcust = "http://www.weberleads.in/http-tokenkeyapi.php?authentic-key=3535416e6974616761733836361595828831&senderid=AGSBPC&route=2&unicode=2&number=" + contact + "&message" + custmessage;

                            }
                            else
                            {
                                baseURLcust = "http://www.weberleads.in/http-tokenkeyapi.php?authentic-key=3535416e6974616761733836361595828831&senderid=AGSBPC&route=2&number=" + contact + "&message=" + custmessage;
                                //baseURLcust = "http://ocs-sms.com/submitsms.jsp?user=bpclag1&key=b5c6686c0bXX&mobile=+91" + contact + "&message=" + custmessage + "&senderid=AGSBPC&accusage=1";
                            }
                            client.OpenRead(baseURLcust);
                        }
                    }
                }
                else
                {
                    string strMsg = "Please Select Excel File";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + strMsg + "')", true);
                    return;

                }

            }
            catch (Exception ex)
            {
                lblErrMsg.Text = ex.ToString().Trim();
            }
        }

        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            return dTable;
        }

        protected void btnSingleSMS_Click(object sender, EventArgs e)
        {if (txtSMSText.Text=="")
            {
                string strMsg = "Please Enter SMS Text";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + strMsg + "')", true);
                return;
                
            }
        else    if (txtMobNo.Text == "")
            {
                string strMsg = "Please Enter Mobile Number";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + strMsg + "')", true);
                return;
               
            }
            else
            {
                 //sendSMS();
                Reset();
            }
        }

        public void sendSMS()
        {

            contact = txtMobNo.Text;
            custmessage = txtSMSText.Text;
            if (RbtUnicode.Checked == true)
            {
                //    baseURLcust = "http://ocs-sms.com/submitsms.jsp?user=bpclag1&key=b5c6686c0bXX&mobile=+91" + contact + "&message=" + custmessage + "&senderid=AGSBPC&accusage=1&unicode=1";
                baseURLcust = "http://www.weberleads.in/http-tokenkeyapi.php?authentic-key=3535416e6974616761733836361595828831&senderid=AGSBPC&route=2&unicode=2&number=" + contact + "&message" + custmessage;

            }
            else
            {
                baseURLcust = "http://www.weberleads.in/http-tokenkeyapi.php?authentic-key=3535416e6974616761733836361595828831&senderid=AGSBPC&route=2&number=" + contact + "&message=" + custmessage;
                //baseURLcust = "http://ocs-sms.com/submitsms.jsp?user=bpclag1&key=b5c6686c0bXX&mobile=+91" + contact + "&message=" + custmessage + "&senderid=AGSBPC&accusage=1";
            }
            client.OpenRead(baseURLcust);
        }

        public void Reset()
        {
            txtSMSText.Text = "";
            txtMobNo.Text = "";
            RbtNormal.Checked = true;
            rbtSMSType.SelectedValue = "1";
        }




    }
}