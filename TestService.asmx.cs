using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Configuration;
using System.Net;


namespace TestWebservice
{
    /// <summary>
    /// Summary description for TestService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TestService : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ESSConn"].ConnectionString);

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string Signin(string Username, string Pwd)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TRANSTYPE", "GetUser");
            cmd.Parameters.AddWithValue("@ParamUsername", Username);
            cmd.Parameters.AddWithValue("@ParamPassword", Pwd);
            cmd.CommandText = "ESSSP";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Close();

            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                DataRow row = dt.Rows[0];
                Session["UserId"] = row["UserId"].ToString();
                Session["Name"] = row["Name"].ToString();
                Session["Username"] = row["Username"].ToString();
                Session["Password"] = row["Password"].ToString();
                Session["AgencyCode"] = row["AgencyCode"].ToString();
                Session["UserType"] = row["UserType"].ToString();
                return "Valid";
            }
            else
            {
                return "Invalid";
            }

        }

        [WebMethod]
        public DataTable GetConsumerDetail(string ConsumerNo)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "GetConsumerDetail");
            cmd2.Parameters.AddWithValue("@ParamConsumerNo", ConsumerNo);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }
        [WebMethod]
        public DataTable GetMachenics(int Deleted)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "GetMachenics");
            cmd2.Parameters.AddWithValue("@ParamIsDeleted", Deleted);
            //cmd2.Parameters.AddWithValue("@ParamConsumerNo", ConsumerNo);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }


       


        [WebMethod]
        public DataTable GetUserList(int IsActive)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "GetUserList");
            cmd2.Parameters.AddWithValue("@ParamIsDeleted", IsActive);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
         }


        [WebMethod]
        public DataTable GetUserPwd(string username)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "GetUserPwd");
            cmd2.Parameters.AddWithValue("@ParamUsername", username);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }

        [WebMethod]
        public DataTable GetComplaintlist(int IsNewConsumer)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "GetComplaintlist");
            cmd2.Parameters.AddWithValue("@ParamIsNewConsumer", IsNewConsumer);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        
        }


          [WebMethod]
        public DataTable GetMachenicContact(string Name)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "GetMachenicContact");
            cmd2.Parameters.AddWithValue("@ParamMachName", Name);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }

         
        

          [WebMethod]
          public DataTable duplicatecomplaint(string ConsumerNumber,string Name, string Contact,string ComplaintDescription)
          {
              con.Open();
              //Select Member Detail
              SqlCommand cmd2 = new SqlCommand();
              cmd2.Connection = con;
              cmd2.CommandType = System.Data.CommandType.StoredProcedure;
              cmd2.Parameters.AddWithValue("@TRANSTYPE", "duplicatecomplaint");
              cmd2.Parameters.AddWithValue("@ParamConsumerNo", ConsumerNumber);
              cmd2.Parameters.AddWithValue("@ParamName", Name);
              cmd2.Parameters.AddWithValue("@ParamContactno", Contact);
              cmd2.Parameters.AddWithValue("@ParamComplaintDetails", ComplaintDescription);
              cmd2.CommandText = "ESSSP";
              SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
              DataTable dt2 = new DataTable();
              da2.Fill(dt2);
              con.Close();
              return dt2;
          
          }

        [WebMethod]
        public DataTable GetComplaintNo()
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "GetComplaintNo");
            //cmd2.Parameters.AddWithValue("@ParamConsumerNo", ConsumerNo);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }

        [WebMethod]
        public DataTable getNewTempID()
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "getNewTempID");
            //cmd2.Parameters.AddWithValue("@ParamConsumerNo", ConsumerNo);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;

        }

       

        [WebMethod]
        public void SaveNewConsumer(string NewName, string Newmobile, string Newaddress, DateTime DateCr, string Usercr)
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "SaveNewConsumer");
            cmd2.Parameters.AddWithValue("@ParamNewName", NewName);
            cmd2.Parameters.AddWithValue("@ParamNewMobile", Newmobile);
            cmd2.Parameters.AddWithValue("@ParamNewAddress", Newaddress);
            cmd2.Parameters.AddWithValue("@ParamDateCr", DateCr);
            cmd2.Parameters.AddWithValue("@paramUserCr", Usercr);
            cmd2.CommandText = "ESSSP";
            cmd2.ExecuteNonQuery();
            con.Close();

        }


        [WebMethod]
        public void SaveEnquiry(int TempConsumerID, string ConsumerNo, string Other, string UserCr, DateTime DateCr, string MakeEnquiryXml)
        {
            con.Open();
            //Save Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "SaveEnquiry");
            cmd2.Parameters.AddWithValue("@ParamtempConsumerNo", TempConsumerID);
            cmd2.Parameters.AddWithValue("@ParamConsumerNo", ConsumerNo);
            //cmd2.Parameters.AddWithValue("@ParamConnType", ConnType);
            //cmd2.Parameters.AddWithValue("@ParamRef", Ref);
            //cmd2.Parameters.AddWithValue("@ParamTransfer", Transfer);
            //cmd2.Parameters.AddWithValue("@ParamChanges", Changes);
            //cmd2.Parameters.AddWithValue("@ParamDBTL", DBTL);
            //cmd2.Parameters.AddWithValue("@ParamBlockStatus", Blockstatus);
            cmd2.Parameters.AddWithValue("@ParamOther", Other);
            cmd2.Parameters.AddWithValue("@ParamUserCr", UserCr);
            cmd2.Parameters.AddWithValue("@ParamDateCr", DateCr);
            //cmd2.Parameters.AddWithValue("@ParamTimeCr", TimeCr);
            cmd2.Parameters.AddWithValue("@XML", MakeEnquiryXml);
            cmd2.CommandText = "ESSSP";
            cmd2.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void SaveUser(string UserId, string UserName, string Contact, string password, string isActive, DateTime DateCr, string AgencyName, string AgencyCode, string UserType)
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "SaveUser");
            cmd2.Parameters.AddWithValue("@ParamUserId", UserId);
            cmd2.Parameters.AddWithValue("@ParamUsername", UserName);
            cmd2.Parameters.AddWithValue("@ParamContactno", Contact);
            cmd2.Parameters.AddWithValue("@ParamPassword", password);
            cmd2.Parameters.AddWithValue("@ParamIsActive", isActive);
            cmd2.Parameters.AddWithValue("@ParamDateCr", DateCr);
            cmd2.Parameters.AddWithValue("@paramAgency", AgencyName);
            cmd2.Parameters.AddWithValue("@ParamAgencyCode", AgencyCode);
            cmd2.Parameters.AddWithValue("@ParamUserType", UserType);

            cmd2.CommandText = "ESSSP";
            cmd2.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void SaveRequest(string ConsumerNo,string ReqRemark, string UserCr, DateTime DateCr, DateTime ResolveDate, int tempconsumerid, string MakeRequestXml)
        {
            con.Open();
            //Save Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "SaveRequest");
            //cmd2.Parameters.AddWithValue("@ParamComplaintID", ReqId);
            cmd2.Parameters.AddWithValue("@ParamConsumerNo", ConsumerNo);
            cmd2.Parameters.AddWithValue("@ParamRemark", ReqRemark);
            cmd2.Parameters.AddWithValue("@ParamUserCr", UserCr);
            cmd2.Parameters.AddWithValue("@ParamDateCr", DateCr);
            //cmd2.Parameters.AddWithValue("@ParamStatus", status);
            //cmd2.Parameters.AddWithValue("@ParamResolveBy", ResolveBy);
            cmd2.Parameters.AddWithValue("@ParamResolveDate", ResolveDate);
            cmd2.Parameters.AddWithValue("@ParamtempConsumerNo", tempconsumerid);
            cmd2.Parameters.AddWithValue("@XML", MakeRequestXml);

            cmd2.CommandText = "ESSSP";
            cmd2.ExecuteNonQuery();
            con.Close();
        }


        [WebMethod]
        public void SaveComplaints(string ConsumerNo, string ComplaintDetails, string Complaintstatus, string UserCr, DateTime DateCr, string Macenic, int compid, int tempconsumerid)
        {
            con.Open();
            //Save Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "SaveComplaints");
            cmd2.Parameters.AddWithValue("@ParamConsumerNo", ConsumerNo);
            //cmd2.Parameters.AddWithValue("@ParamContactno", Contactno);
            //cmd2.Parameters.AddWithValue("@ParamName", ConsumerName);
            cmd2.Parameters.AddWithValue("@ParamComplaintDetails", ComplaintDetails);
            cmd2.Parameters.AddWithValue("@ParamComplaintStatus", Complaintstatus);
            cmd2.Parameters.AddWithValue("@ParamUserCr", UserCr);
            cmd2.Parameters.AddWithValue("@ParamDateCr", DateCr);
            // cmd2.Parameters.AddWithValue("@ParamTimeCr", TimeCr);
            cmd2.Parameters.AddWithValue("@ParamMacenic", Macenic);
            cmd2.Parameters.AddWithValue("@ParamCompID", compid);
            cmd2.Parameters.AddWithValue("@ParamtempConsumerNo", tempconsumerid);
            cmd2.CommandText = "ESSSP";
            cmd2.ExecuteNonQuery();
            con.Close();
        }


        [WebMethod]
        public void UpdateComplaints(string pID, string ComplaintDetails, string UserCr, DateTime DateCr, string Macenic, int compid)
        {
            con.Open();
            //Save Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "UpdateComplaints");
            cmd2.Parameters.AddWithValue("@pID", pID);
            cmd2.Parameters.AddWithValue("@ParamComplaintDetails", ComplaintDetails);
            cmd2.Parameters.AddWithValue("@ParamUserCr", UserCr);
            cmd2.Parameters.AddWithValue("@ParamDateCr", DateCr);
            cmd2.Parameters.AddWithValue("@ParamMacenic", Macenic);
            cmd2.Parameters.AddWithValue("@ParamCompID", compid);
            cmd2.CommandText = "ESSSP";
            cmd2.ExecuteNonQuery();
            con.Close();
        
        
        }

      


        [WebMethod]
        public void UpdateCompStatus(string CompId)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "UpdateCompStatus");
            cmd2.Parameters.AddWithValue("@ParamComplaintID", CompId);
            cmd2.CommandText = "ESSSP";
            cmd2.ExecuteNonQuery();
            con.Close();

        }


        [WebMethod]
        public void ResolveComplaint(string ComplaintID, string InvoiceNo, DateTime AttendDate, double Total, int ResolveBy, string Remark, double Discount, string Machenic, string Status, string xml)
        {
            con.Open();
            //Save Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "ResolveComplaint");
            cmd2.Parameters.AddWithValue("@ParamComplaintID", ComplaintID);
            cmd2.Parameters.AddWithValue("@ParamInvoiceNo", InvoiceNo);
            cmd2.Parameters.AddWithValue("@ParamAttendDate", AttendDate);
            cmd2.Parameters.AddWithValue("@ParamTotal", Total);
            cmd2.Parameters.AddWithValue("@ParamResolveBy", ResolveBy);
            cmd2.Parameters.AddWithValue("@ParamAttendRemark", Remark);
            cmd2.Parameters.AddWithValue("@Paramdiscount", Discount);
            cmd2.Parameters.AddWithValue("@ParamMacenic", Machenic);
            cmd2.Parameters.AddWithValue("@ParamStatus", Status);
            cmd2.Parameters.AddWithValue("@XML", xml);


            cmd2.CommandText = "ESSSP";
            cmd2.ExecuteNonQuery();
            con.Close();
        }


        [WebMethod]
        public void SaveResolvedComp(string ComplaintID, string InvoiceNo, string ConsumerID, DateTime ComplaintDate, DateTime AttendDate, string Machenic, string ComplaintDetails, double singleBurner, double dblBurner, double trplBurner, double fourBurner, double Autometic, double SRT, double clip, double knob, double Jet, double NutBolt, double Spring, double Lockpin, double Gascock, double BurnerAluSmall, double BurnerAluBig, double sidechange, double Nozzle, double Nipple, double Pansupport, double BurnerTray, double BurnerBrassSmall, double BurnerBrassBig, double RubberLegs, double spindle, double DPR, double FreeDPR, double Total, string ResolveBy, string Remark, double Discount, int TempID,string xml)
        {
            con.Open();
            //Save Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "SaveResolvedComp");
            cmd2.Parameters.AddWithValue("@ParamComplaintID", ComplaintID);
            cmd2.Parameters.AddWithValue("@ParamInvoiceNo", InvoiceNo);
            cmd2.Parameters.AddWithValue("@ParamConsumerNo", ConsumerID);
            cmd2.Parameters.AddWithValue("@ParamComplaintDate", ComplaintDate);
            cmd2.Parameters.AddWithValue("@ParamAttendDate", AttendDate);
            cmd2.Parameters.AddWithValue("@ParamMacenic", Machenic);
            cmd2.Parameters.AddWithValue("@ParamComplaintDetails", ComplaintDetails);
            cmd2.Parameters.AddWithValue("@ParamsingleBurner", singleBurner);
            cmd2.Parameters.AddWithValue("@ParamdblBurner", dblBurner);
            cmd2.Parameters.AddWithValue("@ParamtrplBurner", trplBurner);
            cmd2.Parameters.AddWithValue("@ParamfourBurner", fourBurner);
            cmd2.Parameters.AddWithValue("@ParamAutometic", Autometic);
            cmd2.Parameters.AddWithValue("@ParamSRT", SRT);
            cmd2.Parameters.AddWithValue("@Paramclip", clip);
            cmd2.Parameters.AddWithValue("@Paramknob", knob);
            cmd2.Parameters.AddWithValue("@ParamJet", Jet);
            cmd2.Parameters.AddWithValue("@ParamNutBolt", NutBolt);
            cmd2.Parameters.AddWithValue("@ParamSpring", Spring);
            cmd2.Parameters.AddWithValue("@ParamLockpin", Lockpin);
            cmd2.Parameters.AddWithValue("@ParamGascock", Gascock);
            cmd2.Parameters.AddWithValue("@ParamBurnerAluSmall", BurnerAluSmall);
            cmd2.Parameters.AddWithValue("@ParamBurnerAluBig", BurnerAluBig);
            cmd2.Parameters.AddWithValue("@Paramsidechange", sidechange);
            cmd2.Parameters.AddWithValue("@ParamNozzle", Nozzle);
            cmd2.Parameters.AddWithValue("@ParamNipple", Nipple);
            cmd2.Parameters.AddWithValue("@ParamPansupport", Pansupport);
            cmd2.Parameters.AddWithValue("@ParamBurnerTray", BurnerTray);
            cmd2.Parameters.AddWithValue("@ParamBurnerBrassSmall", BurnerBrassSmall);
            cmd2.Parameters.AddWithValue("@ParamBurnerBrassBig", BurnerBrassBig);
            cmd2.Parameters.AddWithValue("@ParamRubberLegs", RubberLegs);
            cmd2.Parameters.AddWithValue("@Paramspindle", spindle);
            cmd2.Parameters.AddWithValue("@ParamTotal", Total);
            cmd2.Parameters.AddWithValue("@ParamResolveBy", ResolveBy);
            cmd2.Parameters.AddWithValue("@ParamAttendRemark", Remark);
            cmd2.Parameters.AddWithValue("@ParamDPR", DPR);
            cmd2.Parameters.AddWithValue("@ParamFreeDPR", FreeDPR);
            cmd2.Parameters.AddWithValue("@Paramdiscount", Discount);
            cmd2.Parameters.AddWithValue("@ParamtempConsumerNo", TempID);
            cmd2.Parameters.AddWithValue("@XML", xml);


            cmd2.CommandText = "ESSSP";
            cmd2.ExecuteNonQuery();
            con.Close();
        }




        [WebMethod]
        public DataTable ViewComplaints(string Id)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "ViewComplaints");
            cmd2.Parameters.AddWithValue("@ParamId", Id);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }

        [WebMethod]
        public DataTable ViewFilterComplaints(string Id, string CompID, string ConsumerNo, string Machenic, string Fromdate, string Todate,string Contact, string UserType)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "ViewFilterComplaints");
            cmd2.Parameters.AddWithValue("@ParamId", Id);
            cmd2.Parameters.AddWithValue("@ParamComplaintID", CompID);
            cmd2.Parameters.AddWithValue("@ParamConsumerNo", ConsumerNo);
            cmd2.Parameters.AddWithValue("@ParamMachName", Machenic);
            cmd2.Parameters.AddWithValue("@ParamFromDate", Fromdate);
            cmd2.Parameters.AddWithValue("@ParamTodate", Todate);
            cmd2.Parameters.AddWithValue("@ParamContactno", Contact);
            cmd2.Parameters.AddWithValue("@ParamUserType", UserType);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }

        [WebMethod]
        public DataTable ViewRequestReports(string Status, string UserName, string RequestType, string Fromdate, string Todate)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "ViewRequestReports");
          //  cmd2.Parameters.AddWithValue("@ParamComplaintStatus", Status);
            cmd2.Parameters.AddWithValue("@ParamUserName", UserName);
            cmd2.Parameters.AddWithValue("@ParamRequestType", RequestType);
            cmd2.Parameters.AddWithValue("@ParamFromDate", Fromdate);
            cmd2.Parameters.AddWithValue("@ParamTodate", Todate);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;

        }

        [WebMethod]
        public DataTable ViewEnquiryReports(string UserName, string Enquiry, string Fromdate, string Todate)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "ViewEnquiryReports");
            cmd2.Parameters.AddWithValue("@ParamUserName", UserName);
            cmd2.Parameters.AddWithValue("@ParamEnquiryType", Enquiry);
            cmd2.Parameters.AddWithValue("@ParamFromDate", Fromdate);
            cmd2.Parameters.AddWithValue("@ParamTodate", Todate);

            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;

        }


        [WebMethod]
        public DataTable ViewComplaintReports(string Status, string UserName, string Machenic, string ComplaintType, string Fromdate, string Todate, string UserType)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "ViewComplaintReports");
            cmd2.Parameters.AddWithValue("@ParamComplaintStatus", Status);
            cmd2.Parameters.AddWithValue("@ParamUserName", UserName);
            cmd2.Parameters.AddWithValue("@ParamMachName", Machenic);
            cmd2.Parameters.AddWithValue("@ParamComplaintDetails", ComplaintType);
            cmd2.Parameters.AddWithValue("@ParamFromDate", Fromdate);
            cmd2.Parameters.AddWithValue("@ParamTodate", Todate);
            cmd2.Parameters.AddWithValue("@ParamUserType", UserType);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;

        }

        [WebMethod]
        public DataTable GetComplaintsType()
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "GetComplaintsType");
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;


        }

       
        [WebMethod]
        public DataTable ViewMechanicReports(int ReportType, string Machenic,string Particulars, string Fromdate, string Todate)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "ViewMechanicReports");
            cmd2.Parameters.AddWithValue("@ParamMachName", Machenic);
            cmd2.Parameters.AddWithValue("@ParamParticular", Particulars);

            cmd2.Parameters.AddWithValue("@ParamFromDate", Fromdate);
            cmd2.Parameters.AddWithValue("@ParamTodate", Todate);
            cmd2.Parameters.AddWithValue("@ParamMachenicReportType", ReportType);
           

            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        
        }

        [WebMethod]
        public DataTable ViewConsComplaints(string ConsumerNo)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "ViewConsComplaints");
            cmd2.Parameters.AddWithValue("@ParamConsumerNo", ConsumerNo);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }


       
        [WebMethod]
        public DataTable ViewEnquiry(string Id)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "ViewEnquiry");
            cmd2.Parameters.AddWithValue("@ParamId", Id);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }


        [WebMethod]
        public DataTable GetComplaintDetail(string ComplaintId)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "GetComplaintDetail");
            cmd2.Parameters.AddWithValue("@ParamComplaintID", ComplaintId);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }

        [WebMethod]
        public DataTable GetParticulars(int Deleted)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "GetParticulars");
            cmd2.Parameters.AddWithValue("@ParamIsDeleted", Deleted);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }

        [WebMethod]
        public DataTable GetRequestsList(int IsNewConsumer)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "GetRequestsList");
            cmd2.Parameters.AddWithValue("@ParamIsNewConsumer", IsNewConsumer);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }

        

        [WebMethod]
        public DataTable GetEnquiryList(int IsNewConsumer)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "GetEnquiryList");
            cmd2.Parameters.AddWithValue("@ParamIsNewConsumer", IsNewConsumer);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }


        [WebMethod]
        public string CMSAdminSignin(string Username, string Pwd)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TRANSTYPE", "GetCMSUser");
            cmd.Parameters.AddWithValue("@ParamUsername", Username);
            cmd.Parameters.AddWithValue("@ParamPassword", Pwd);
            cmd.CommandText = "ESSSP";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Close();

            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                DataRow row = dt.Rows[0];
                //Session["UserId"] = row["UserId"].ToString();
                Session["Fullname"] = row["Fullname"].ToString();
                Session["Username"] = row["Username"].ToString();
                return "Valid";
            }
            else
            {
                return "Invalid";
            }

        }


        [WebMethod]
        public void RegisterAgency(string AgencyName, string Address,
                                    string City, string Taluka,
                                    string Dist, string PIN, string State,
                                    string SAPCode, string AgencyContactNo,
                                    string AlternateContactNo, string AgencyMailId,
                                    string OwnerTitle, string OwnerFName,
                                    string OwnerLName, string OwnerContactNo,
                                    string OwnerMailId, string AdminUserTitle,
                                    string AdminUserFName, string AdminUserLName,
                                    string AdminUserContactNo, string AdminUserMailId,
                                    string AdminUserDesignation, string AdminUserId,
                                    string AdminPassword, int LicenceDuration,
                                    DateTime RegistrationDate, DateTime LastRenewDate,
                                    int LastRenewDuration, DateTime LastUpdatedDate, string LastUpdatedBy)
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "RegisterAgency");
            cmd2.Parameters.AddWithValue("@ParamAgencyName", AgencyName);
            cmd2.Parameters.AddWithValue("@ParamAgencyAddress", Address);
            cmd2.Parameters.AddWithValue("@ParamCity", City);
            cmd2.Parameters.AddWithValue("@ParamTaluka", Taluka);
            cmd2.Parameters.AddWithValue("@paramDist", Dist);
            cmd2.Parameters.AddWithValue("@ParamAgencyPIN", PIN);
            cmd2.Parameters.AddWithValue("@ParamAgencyState", State);
            cmd2.Parameters.AddWithValue("@ParamAgencySAPCode", SAPCode);
            cmd2.Parameters.AddWithValue("@ParamAgencyContactNo", AgencyContactNo);
            cmd2.Parameters.AddWithValue("@ParamAgencyAlternate", AlternateContactNo);
            cmd2.Parameters.AddWithValue("@ParamAgencyMailId", AgencyMailId);

            cmd2.Parameters.AddWithValue("@ParamOwnerTitle", OwnerTitle);
            cmd2.Parameters.AddWithValue("@ParamOwnerFName", OwnerFName);
            cmd2.Parameters.AddWithValue("@ParamOwnerLName", OwnerLName);
            cmd2.Parameters.AddWithValue("@ParamOwnerContactNo", OwnerContactNo);
            cmd2.Parameters.AddWithValue("@ParamOwnerMailId", OwnerMailId);

            cmd2.Parameters.AddWithValue("@ParamAdminUserTitle", AdminUserTitle);
            cmd2.Parameters.AddWithValue("@ParamAdminUserFname", AdminUserFName);
            cmd2.Parameters.AddWithValue("@ParamAdminUserLname", AdminUserLName);
            cmd2.Parameters.AddWithValue("@ParamAdminUserContactNo", AdminUserContactNo);
            cmd2.Parameters.AddWithValue("@ParamAdminUserMailId", AdminUserMailId);
            cmd2.Parameters.AddWithValue("@ParamAdminUserDesignation", AdminUserDesignation);

            cmd2.Parameters.AddWithValue("@ParamAdminUserId", AdminUserId);
            cmd2.Parameters.AddWithValue("@ParamAdminPassword", AdminPassword);
            cmd2.Parameters.AddWithValue("@ParamLicenceDuration", LicenceDuration);
            cmd2.Parameters.AddWithValue("@ParamRegistrationDate", RegistrationDate);
            cmd2.Parameters.AddWithValue("@ParamLastRenewDate", LastRenewDate);
            cmd2.Parameters.AddWithValue("@ParamLastRenewDuration", LastRenewDuration);
            cmd2.Parameters.AddWithValue("@ParamLastUpdatedDate", LastUpdatedDate);
            cmd2.Parameters.AddWithValue("@ParamLastUpdatedBy", LastUpdatedBy);

            cmd2.CommandText = "ESSSP";
            cmd2.ExecuteNonQuery();
            con.Close();

        }
       


        [WebMethod]
        public DataTable InsertComplaintsList(string ComplaintType, int SortOrder, int IsForNewConsumer)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "InsertComplaintsList");
            //  cmd2.Parameters.AddWithValue("@ParamComplaintStatus", Status);
            cmd2.Parameters.AddWithValue("@ParamComplaints", ComplaintType);
            cmd2.Parameters.AddWithValue("@ParamSortOrder", SortOrder);
            cmd2.Parameters.AddWithValue("@ParamIsForNewConsumer", IsForNewConsumer);

            cmd2.CommandText = "MastersSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;

        }

        [WebMethod]
        public DataTable InsertEnquiryList(string ComplaintType, int IsForNewConsumer)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "InsertEnquiryList");
            //  cmd2.Parameters.AddWithValue("@ParamComplaintStatus", Status);
            cmd2.Parameters.AddWithValue("@ParamEnquiry", ComplaintType);
            cmd2.Parameters.AddWithValue("@ParamIsForNewConsumer", IsForNewConsumer);

            cmd2.CommandText = "MastersSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;

        }

        [WebMethod]
        public DataTable InsertRequestList(string ComplaintType, int IsForNewConsumer)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "InsertRequestList");
        //  cmd2.Parameters.AddWithValue("@ParamComplaintStatus", Status);
            cmd2.Parameters.AddWithValue("@ParamRequest", ComplaintType);
            cmd2.Parameters.AddWithValue("@ParamIsForNewConsumer", IsForNewConsumer);

            cmd2.CommandText = "MastersSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
         }

        [WebMethod]
        public DataTable InsertMechanic(string Name, string contact)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "InsertMechanic");
            cmd2.Parameters.AddWithValue("@ParamComplaints", Name);
            cmd2.Parameters.AddWithValue("@ParamContact", contact);

            cmd2.CommandText = "MastersSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;

        }

        [WebMethod]
        public DataTable InsertParticulars(string Particular, decimal Rate)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "InsertParticulars");
            cmd2.Parameters.AddWithValue("@ParamParticular", Particular);
            cmd2.Parameters.AddWithValue("@ParamRate", Rate);

            cmd2.CommandText = "MastersSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;

        }



        [WebMethod]
        public DataTable UpdateComplaintsList(int compid, string ComplaintType, int IsForNewConsumer)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "UpdateComplaintsList");
            cmd2.Parameters.AddWithValue("@ParamCompid", compid);
            cmd2.Parameters.AddWithValue("@ParamComplaints", ComplaintType);
            cmd2.Parameters.AddWithValue("@ParamIsForNewConsumer", IsForNewConsumer);

            cmd2.CommandText = "MastersSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
         }

        [WebMethod]
        public DataTable UpdateEnquiryList(int compid, string ComplaintType, int IsForNewConsumer)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "UpdateEnquiryList");
            cmd2.Parameters.AddWithValue("@ParamCompid", compid);
            cmd2.Parameters.AddWithValue("@ParamComplaints", ComplaintType);
            cmd2.Parameters.AddWithValue("@ParamIsForNewConsumer", IsForNewConsumer);

            cmd2.CommandText = "MastersSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }

        [WebMethod]
        public DataTable UpdateRequestsList(int compid, string ComplaintType, int IsForNewConsumer)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "UpdateRequestsList");
            cmd2.Parameters.AddWithValue("@ParamCompid", compid);
            cmd2.Parameters.AddWithValue("@ParamComplaints", ComplaintType);
            cmd2.Parameters.AddWithValue("@ParamIsForNewConsumer", IsForNewConsumer);

            cmd2.CommandText = "MastersSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }


        [WebMethod]
        public DataTable UpdateMachenic(int MachenicID, string Name, string contact , int Delete)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "UpdateMachenic");
            cmd2.Parameters.AddWithValue("@ParamCompid", MachenicID);
            cmd2.Parameters.AddWithValue("@ParamComplaints", Name);
            cmd2.Parameters.AddWithValue("@ParamContact", contact);
            cmd2.Parameters.AddWithValue("@ParamDelete", Delete);
            cmd2.CommandText = "MastersSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }

        [WebMethod]
        public DataTable UpdateParticulars(int ID, string Particular, decimal Rate, int Delete)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "UpdateParticulars");
            cmd2.Parameters.AddWithValue("@ParamCompid", ID);
            cmd2.Parameters.AddWithValue("@ParamParticular", Particular);
            cmd2.Parameters.AddWithValue("@ParamRate", Rate);
            cmd2.Parameters.AddWithValue("@ParamDelete", Delete);
            cmd2.CommandText = "MastersSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }

        [WebMethod]
        public DataTable UpdateUser(int ID, string Name,string Contact ,string UserID, string Type, int Delete)
        {
            con.Open();
            //Select Member Detail
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@TRANSTYPE", "UpdateUser");
            cmd2.Parameters.AddWithValue("@ParamID", ID);
            cmd2.Parameters.AddWithValue("@ParamUsername", Name);
            cmd2.Parameters.AddWithValue("@ParamContactno", Contact);
            cmd2.Parameters.AddWithValue("@ParamUserId", UserID);
            cmd2.Parameters.AddWithValue("@ParamUserType", Type);
            cmd2.Parameters.AddWithValue("@ParamIsDeleted", Delete);
            cmd2.CommandText = "ESSSP";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            return dt2;
        }


    }
}


