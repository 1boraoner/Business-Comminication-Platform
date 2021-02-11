using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using User;
using System.Windows;


namespace BCOM
{
    public partial class    loginpage : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["database"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }   

        protected void Login(object sender, EventArgs e)
        {
            if (TextBox1.Text.Equals(""))
            {
                MessageBox.Show("You Must Enter A Valid Member ID");
            }
            
            else
            {
                Employee log_emp;
                try
                {
                    SqlConnection con = new SqlConnection(strcon); //connection object

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    string obj_id = TextBox1.Text.Trim();
                    string obj_pw = TextBox2.Text.Trim();

                    string cmd_str = "select * from User_tabl";

                    SqlCommand cmd = new SqlCommand(cmd_str, con);

                    cmd.Parameters.AddWithValue("@to_find", obj_id);

                    SqlDataReader dreader = cmd.ExecuteReader();

                    string x;
                    while (dreader.Read())
                    {
                        x = (string)dreader.GetValue(4);

                        if (obj_id == x)
                        {
                            if((string)dreader.GetValue(5) == obj_pw)
                            {
                                log_emp = new Employee((string)dreader.GetValue(0), (string)dreader.GetValue(1), (string)dreader.GetValue(2),
                                (string)dreader.GetValue(3), (string)dreader.GetValue(4), (string)dreader.GetValue(5), false);

                                Session["user"] = log_emp; //preserve the user object
                                Session["role"] = "employee";

                                Response.Redirect("user_home_page.aspx");
                            }
                            else
                            {
                                MessageBox.Show("Wrong Password");

                            }

                        }
                    }
                    dreader.Close();
                    cmd.Dispose();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
            
        }
    }
}