using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace TechnicalAssessment
{
    public partial class UploadFile : System.Web.UI.Page
    {

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        string builder1;

        protected void Page_Load(object sender, EventArgs e)
        {
            builder1 = "datasource=remotemysql.com;port=3306;username=phKxA8OSDn;password=roup8hs4Pa;database=phKxA8OSDn";
            
            Label1.Text = "Not Connected..";

            try
            {
                MySqlConnection connection = new MySqlConnection(builder1);

                connection.Open();
                Label1.Text = "Please select the a file to upload from below";

                connection.Close();
            }
            catch (Exception)
            {
                Label1.Text = "Not Connected..";
                throw;
            }
        }

       
            
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            MyData myData = new MyData();

            if (FileUpload1.HasFile)
            {
                string filepath = Server.MapPath("~/File/") + FileUpload1.FileName;

                FileUpload1.SaveAs(filepath);
                myData.readFromFile(filepath);

                Label2.Text = "Read all data";
            }
            else
            {
                Label1.Text = "Please select a file";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(builder1);

                conn.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from myTable", conn);
                MySqlDataAdapter daptAd = new MySqlDataAdapter(cmd);
                System.Data.DataTable reader = new System.Data.DataTable();// = cmd.ExecuteNonQuery();

                daptAd.Fill(reader);
                

                GridView1.DataSource = reader;
                GridView1.DataBind();


                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }


        
    }
}