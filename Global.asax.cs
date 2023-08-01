using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace TestWebservice
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RegisterRoutes(RouteTable.Routes);
        }

        static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("login", "login", "~/login.aspx");
            routes.MapPageRoute("Complaint", "Complaint", "~/Complaint.aspx");
            routes.MapPageRoute("Resolve", "Resolve", "~/UpdateComplaint.aspx");
            routes.MapPageRoute("Search", "Search", "~/Resolve.aspx");
            routes.MapPageRoute("Complaint_Reports", "Complaint_Reports", "~/Complaint_Reports.aspx");
            routes.MapPageRoute("Enquiry_Reports", "Enquiry_Reports", "~/Enquiry_Reports.aspx");
            routes.MapPageRoute("Request_Reports", "Request_Reports", "~/Request_Reports.aspx");
            routes.MapPageRoute("Machenic_Reports", "Machenic_Reports", "~/Machenic_Reports.aspx");

            routes.MapPageRoute("Users", "Users", "~/UserReg.aspx");
            routes.MapPageRoute("Upload_Consumer", "Upload_Consumer", "~/UploadConsumerDataTest.aspx");
            routes.MapPageRoute("Complaint_Master", "Complaint_Master", "~/ComplaintListMaster.aspx");
            routes.MapPageRoute("Enquiry_Master", "Enquiry_Master", "~/EnquiryListMaster.aspx");
            routes.MapPageRoute("Request_Master", "Request_Master", "~/RequestListMaster.aspx");
            routes.MapPageRoute("Machenic_Master", "Machenic_Master", "~/MachenicMaster.aspx");
            routes.MapPageRoute("Particulars_Master", "Particulars_Master", "~/PArticularsMaster.aspx");
            routes.MapPageRoute("SMS", "SMS", "~/SMSpanel.aspx");

            routes.MapPageRoute("Register", "Register", "~/CMSAdmin.aspx");
            routes.MapPageRoute("Home", "Home", "~/index.aspx");
        }


        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}