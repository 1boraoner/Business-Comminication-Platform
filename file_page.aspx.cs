using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using User;
using System.Web.UI.HtmlControls;
using System.Windows;
using System.Web.Services;

namespace BCOM
{
    public partial class file_page : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["database"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            MyIframe.Visible = false;

        }

        public void construct_file_table(object sender, EventArgs e) //Table Doldurur
        {

            Refresh_Table();

            SqlConnection con = new SqlConnection(strcon);

            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from File_table";
            cmd.Connection = con;

            File_table01.DataSource = cmd.ExecuteReader();
            File_table01.DataBind();


            con.Close();
        }

        public void Refresh_Table() //deletes ANONİM files if exists
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();


            string del_str = "DELETE FROM File_table WHERE contributor='Anonim'";
            SqlCommand del_cmd = new SqlCommand(del_str, con);

            del_cmd.ExecuteNonQuery();

            con.Close();
        }

        protected void Upload_file(object sender, EventArgs e) 
        {
            Save_file(); //saves file in to the directory
            Add_to_Table(); //adds the new file to current table
        }

        public void Save_file() //saves the file into the server file_system directory
        {
            try
            {
                string s_path = Server.MapPath("~/Files/");
                string file_name = FileUpload1.PostedFile.FileName;
                FileUpload1.SaveAs(s_path + file_name);
            }
            catch(Exception ex){Response.Write(ex);}
        }

        public void Add_to_Table() //inserts new element to the DB
        {
            SqlConnection con = new SqlConnection(strcon); //connection object

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            Employee emp = (Employee)Session["user"];

            string f_name = FileUpload1.PostedFile.FileName;
            int size = FileUpload1.PostedFile.ContentLength;
            string type = FileUpload1.PostedFile.ContentType;
            string poster;
            if (emp == null || string.IsNullOrEmpty(emp.Full_name))
            {
                poster = "Anonim";
            }
            else
            {
                poster = emp.Full_name;
            }
                string cmd_str = "insert into File_table(file_name,format,size,contributor) values(@f_name,@type,@size,@poster)";

                SqlCommand cmd = new SqlCommand(cmd_str, con);

                cmd.Parameters.AddWithValue("@f_name", f_name);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@poster", poster);

                cmd.ExecuteNonQuery(); //executes these codes
                con.Close();

        }

        protected void download_file(object sender, EventArgs e) //downloading an files from database
        {
            string file_path = (sender as LinkButton).CommandArgument;

            if (file_path.Contains(".pdf")){
               Response.ContentType = "application/pdf";
            }
            else if (file_path.Contains(".jpg"))
            {
                Response.ContentType = "image/jpeg";
            }
            else if (file_path.Contains(".png"))
            {
                Response.ContentType = "image/png";
            }
            else if (file_path.Contains(".docx") || file_path.Contains(".docx"))
            {
                Response.ContentType = "application/msword";
            }
            else if (file_path.Contains(".xls"))
            {
                Response.ContentType = "application/vnd.ms-excel";
            }
            else if(file_path.Contains(".pptx"))
            {
                Response.ContentType = "application/vnd.ms-powerpoint";
            }
            else if (file_path.Contains(".txt"))
            {
                Response.ContentType = "text/plain";
            }

            Response.AppendHeader("Content-Disposition", "attachment;" + "filename=" + file_path);

            const int bufferLength = 1000000;
            byte[] buffer = new Byte[bufferLength];
            int length = 0;
            Stream download = null;
            try
            {
                download = new FileStream(Server.MapPath("~/Files/" + file_path), FileMode.Open, FileAccess.Read) ;
                do
                {
                    if (Response.IsClientConnected)
                    {
                        length = download.Read(buffer, 0, bufferLength);
                        Response.OutputStream.Write(buffer, 0, length);
                        buffer = new Byte[bufferLength];
                    }
                    else
                    {
                        length = -1;
                    }
                }
                while (length > 0);
                Response.Flush();
                Response.End();
            }
            finally
            {
                if (download != null)
                    download.Close();
            }
        }

        public void preview_file(object sender, EventArgs e) //previews the file from DataBase 
        {
            string file_path ="~/Files/" + (sender as LinkButton).CommandArgument; //to reach file
            MyIframe.Attributes.Add("src", file_path);
            MyIframe.Visible = true;
        }
    }
}


