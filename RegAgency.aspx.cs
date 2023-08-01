using System;
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

namespace TestWebservice
{
    public partial class WebForm1 : System.Web.UI.Page
    {
       string strMsg, Id, UserType, complaint;
       TestService ESSSr = new TestService();
       DateTime now = DateTime.Now;
   
        protected void Page_Load(object sender, EventArgs e)
        {

              if (Session["UserId"] != null)
            {
                Id = Session["UserId"].ToString();
                UserType = Session["UserType"].ToString();
            }

        }

        protected void btnGetCons_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string DateCr = DateTime.Now.ToString();
                
                ESSSr.RegisterAgency(txtAgencyName.Text, txtAgencyAdd.Text,txtCity.Text, txtTaluka.Text, ddlDistrict.Text, 
                                    txtPIN.Text, ddlState.Text, txtAgencySAPCode.Text, txtAgencyContact.Text,
                                    txtAlternateAgencyContact.Text, txtAgencyMailId.Text, ddlOwnerTitle.Text, txtOwnerFirstname.Text, txtOwnerLastname.Text,
                                    txtOwnerContactNo.Text, txtOwnerMailId.Text, ddlAdminUserTitle.Text, txtAdminFirstName.Text, txtAdminLastName.Text,
                                    txtAdminUserContactNo.Text, txtAdminUserEmailId.Text, txtAdminUserDesignation.Text, txtUserId.Text, txtPassword.Text, Int32.Parse(txtLicenceDuration.Text), Convert.ToDateTime(DateCr), Convert.ToDateTime(DateCr), Int32.Parse(txtLicenceDuration.Text), Convert.ToDateTime(DateCr), Id );
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }



        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}