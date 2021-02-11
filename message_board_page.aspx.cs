using Microsoft.AspNet.SignalR.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using User;

namespace BCOM
{
    public partial class message_board_page : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string) Session["role"] != "admin") {

                msg_board.Columns[2].Visible = false;
                msg_board.Columns[3].Visible = false;

            }
            else
            {
                 msg_board.Columns[2].Visible = true;
                 msg_board.Columns[3].Visible = true;
            }
            using (SqlConnection con = new SqlConnection(strcon)) {
                con.Open();
                SqlDataAdapter data_ad = new SqlDataAdapter("SELECT * FROM Message_Board_tabl", con);
                DataTable dt = new DataTable();
                data_ad.Fill(dt);
                msg_board.DataSource = dt;
                msg_board.DataBind();
            
            }
        }

        protected void post_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            Employee m_user = (Employee)Session["user"];
            string cont = m_user.Full_name;
            string mess = message_box.InnerText;
            string topic = topic_box.Text.Trim();
            DateTime date = DateTime.UtcNow;
            Random rnd = new Random();
            int mess_id = rnd.Next(1,1000000); //generates a msg_id from randomized number
            string cmd = "INSERT into Message_Board_tabl(message_content, contributor, post_date,message_id,topic) " +
                "           values(@message_content, @contributor, @post_date,@message_id,@topic)";
            
            SqlCommand table_cmd = new SqlCommand(cmd, con);
            table_cmd.Parameters.AddWithValue("@message_content", mess);
            table_cmd.Parameters.AddWithValue("@contributor", cont);
            table_cmd.Parameters.AddWithValue("@post_date",date);
            table_cmd.Parameters.AddWithValue("@message_id",mess_id);
            table_cmd.Parameters.AddWithValue("@topic",topic);
            table_cmd.ExecuteNonQuery(); //executes these codes
            con.Close();
        }

        protected void Delete_message(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            int  msg_id = int.Parse((string)(sender as LinkButton).CommandArgument);
            string cmd = "DELETE FROM Message_Board_tabl WHERE message_id =" + msg_id;
            SqlCommand sql_cmd = new SqlCommand(cmd, con);
            sql_cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}