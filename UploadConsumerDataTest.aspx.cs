using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;

namespace TestWebservice
{
    public partial class UploadConsumerDataTest : System.Web.UI.Page
    {
            string active, block;
            DataSet dsExcelData = new DataSet();
            DataSet dsExcelData1 = new DataSet();
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lblMeg.Text = string.Empty;
            lblErrMsg.Text = string.Empty;
            System.IO.StringWriter sw = new System.IO.StringWriter();
            try
            {
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

                            Session["ActiveConsumerView"] = dsExcelData;
                            
                            dsExcelData.Clear();
                            //lblMeg.Text = lblMeg.Text + "<br/> Records in dataset : " + dsExcelData.Tables[0].Rows.Count.ToString();

                        }
                        else if (fileExt == ".xlsx")
                        {
                            Excel.IExcelDataReader excelReader = Excel.ExcelReaderFactory.CreateOpenXmlReader(stream);
                            excelReader.IsFirstRowAsColumnNames = true;
                            dsExcelData = excelReader.AsDataSet();
                            //dsExcelData.WriteXml(sw);
                            Session["ActiveConsumerView"] = dsExcelData;
                           // Session["test1"] = "1";
                            //sw.Dispose();
                            //dsExcelData.Clear();
                            //lblMeg.Text = lblMeg.Text + "<br/> Records in dataset : " + dsExcelData.Tables[0].Rows.Count.ToString();
                            //lblMeg.Text ="Files of consumer :"+ FileName +" uploading...";
                        }
                        else
                        {
                            lblMeg.Text = "Please select valid Excel file.";
                            
                        }
                        UpdateDataBaseTable(dsExcelData.Tables[0]);
                    }
                }
                else
                {
                    lblErrMsg.Text = "User has not selected list of new consumers.";
                
                }
                //----To upload blocked consumers----

                if (FileUpload2.HasFile)
                {
                    string FileName1 = Path.GetFileName(FileUpload2.PostedFile.FileName);
                    //string Extension = Path.GetExtension(FileUpload2.PostedFile.FileName);
                    string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                    string FilePath = Server.MapPath(FolderPath + FileName1);
                    FileUpload2.SaveAs(FilePath);
                    block = FileName1.ToString();
                    //lblMeg.Text = "File uploaded : " + FilePath;

                    FileInfo fileInfo = new FileInfo(FilePath);
                    if (fileInfo.Exists)
                    {
                       // DataSet dsExcelData1 = new DataSet();
                        FileStream stream = File.Open(FilePath, FileMode.Open, FileAccess.Read);

                        string fileExt = fileInfo.Extension.ToString().Trim().ToLower();

                        if (fileExt == ".xls")
                        {
                            Excel.IExcelDataReader excelReader = Excel.ExcelReaderFactory.CreateBinaryReader(stream);
                            excelReader.IsFirstRowAsColumnNames = true;
                            dsExcelData1 = excelReader.AsDataSet();

                            Session["BlockConsumerView"] = dsExcelData1;

                            //dsExcelData1.Clear();
                           // lblMeg.Text = lblMeg.Text + "<br/> Records in dataset : " + dsExcelData1.Tables[0].Rows.Count.ToString();
                            //lblMeg.Text = lblMeg.Text + " and " + FileName1 + " uploading...";


                        }
                        else if (fileExt == ".xlsx")
                        {
                            Excel.IExcelDataReader excelReader = Excel.ExcelReaderFactory.CreateOpenXmlReader(stream);
                            excelReader.IsFirstRowAsColumnNames = true;
                            dsExcelData1 = excelReader.AsDataSet();
                           
                            Session["BlockConsumerView"] = dsExcelData1;
                            
                            //dsExcelData1.Clear();
                            // lblMeg.Text = lblMeg.Text + "<br/> Records in dataset : " + dsExcelData1.Tables[0].Rows.Count.ToString();
                        }
                        else
                        {
                            lblMeg.Text = "Please select valid Excel file.";

                        }
                    }
                }
                lblFile1Msg.ForeColor = System.Drawing.Color.Red;
                lblFile2Msg.ForeColor = System.Drawing.Color.Red;

                lblFile1Msg.Text = dsExcelData.Tables[0].Rows.Count.ToString() + " Records available in " + active;
                lblFile2Msg.Text = dsExcelData1.Tables[0].Rows.Count.ToString() + " Records available in "+ block ;

                lblMeg.Text = dsExcelData.Tables[0].Rows.Count.ToString() + " Records available in " + active + " and " + dsExcelData1.Tables[0].Rows.Count.ToString() + " Records available in " + block;
                dsExcelData1.Clear();
                dsExcelData.Clear();
                UpdateDataBaseTable(dsExcelData.Tables[0]);
                UpdateDataBaseTable1(dsExcelData1.Tables[0]);

            }
            catch (Exception ex) 
            {
                lblErrMsg.Text = ex.ToString().Trim();
            }
        
        }

        protected void UpdateDataBaseTable(DataTable dtExcelData)
        {
            try
            {

                {
                    // Create a SqlDataAdapter.
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    using (SqlConnection connection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["ESSConn"].ConnectionString))
                    {
                        // Set the UPDATE command and parameters.
                        string sqlTrunc = "TRUNCATE TABLE ConsumerMaster";
                        SqlCommand cmd = new SqlCommand(sqlTrunc, connection);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        
                        string sqlInsertCommand = "insert into ConsumerMaster (ConsumerNo, ConsumerName, ConsumerMob, ConsumerAddress)";
                        sqlInsertCommand = sqlInsertCommand + " Values(@conNo, @conName, @conMobile, @conAdd)";

                        adapter.InsertCommand = new SqlCommand(sqlInsertCommand, connection);
                        adapter.InsertCommand.Parameters.Add("@conNo", SqlDbType.NVarChar, 10, "ConsumerNumber");
                        adapter.InsertCommand.Parameters.Add("@conName", SqlDbType.NVarChar, 100, "ConsumerName");
                        adapter.InsertCommand.Parameters.Add("@conMobile", SqlDbType.NVarChar, 10, "MobileNumber");
                        adapter.InsertCommand.Parameters.Add("@conAdd", SqlDbType.NVarChar, 200, "Address");
                        adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
                        adapter.InsertCommand.CommandTimeout = 2000;

                        // Set the batch size.
                        adapter.UpdateBatchSize = 10000;

                        // Execute the update.
                        adapter.Update(dtExcelData);

                        lblinsert.Text = "<br/> Records inserted in consumer table : " + dtExcelData.Rows.Count.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                lblErrMsg.Text = ex.ToString().Trim();
            }

        }

        protected void UpdateDataBaseTable1(DataTable dtExcelData1)
        {
            try
            {
                using (SqlConnection connection = new
                     SqlConnection(ConfigurationManager.ConnectionStrings["ESSConn"].ConnectionString))
                {
                    // Create a SqlDataAdapter.
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string sqlTrunc = "TRUNCATE TABLE BLockConsumer";
                    SqlCommand cmd = new SqlCommand(sqlTrunc, connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    // Set the UPDATE command and parameters.
                    string sqlInsertCommand = "insert into BLockConsumer (ConsumerNo, ConsumerName, ConsumerMob, ConsumerAddress)";
                    sqlInsertCommand = sqlInsertCommand + " Values(@conNo, @conName, @conMobile, @conAdd)";

                    adapter.InsertCommand = new SqlCommand(sqlInsertCommand, connection);
                    adapter.InsertCommand.Parameters.Add("@conNo", SqlDbType.NVarChar, 10, "ConsumerNumber");
                    adapter.InsertCommand.Parameters.Add("@conName", SqlDbType.NVarChar, 100, "ConsumerName");
                    adapter.InsertCommand.Parameters.Add("@conMobile", SqlDbType.NVarChar, 10, "MobileNumber1");
                    adapter.InsertCommand.Parameters.Add("@conAdd", SqlDbType.NVarChar, 200, "Address");
                    adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;

                    // Set the batch size.
                    adapter.UpdateBatchSize = 10000;

                    // Execute the update.
                    adapter.Update(dtExcelData1);

                   // lblinsert.Text = "<br/> Records inserted in consumer table : " + dtExcelData1.Rows.Count.ToString();
                }
          

            }
            catch (Exception ex)
            {
                lblErrMsg.Text = ex.ToString().Trim();
            }

        }

        protected void btn_Click(object sender, EventArgs e)
        {

            if (Session["ActiveConsumerView"] != null && Session["BlockConsumerView"] != null)
            {

               dsExcelData = (DataSet)Session["ActiveConsumerView"];
               dsExcelData1 = (DataSet)Session["BlockConsumerView"];
                 
               if (dsExcelData.Tables[0].Rows.Count.ToString() != "0" && dsExcelData1.Tables[0].Rows.Count.ToString() != "0")
               {
                   UpdateDataBaseTable(dsExcelData.Tables[0]);
                   UpdateDataBaseTable1(dsExcelData1.Tables[0]);


                   // //sp execution
                   using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ESSConn"].ConnectionString))
                   {
                       SqlCommand cmd = new SqlCommand("ImportConsumer", connection);
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.CommandTimeout = 2000;
                       connection.Open();
                       cmd.ExecuteNonQuery();
                   }
               }
                            
            }   
          
        }

    }
}