using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using User;

namespace BCOM
{
    public partial class signuppage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["database"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //sign up opereation
        public void Sign_up(object sender, EventArgs e)
        {

            bool identical_id = Check_Employer_ID();
            if(!identical_id)
                Add_employee();
            else
                Response.Write("<script>alert('The Employee_Id is already being used ');</script>");
        }

        public bool Check_Employer_ID()
        {
            bool flag = false;

            SqlConnection con = new SqlConnection(strcon); //connection object

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string to_find = TextBox5.Text.Trim();
            string cmd_str = "select * from User_tabl";

            SqlCommand cmd = new SqlCommand(cmd_str, con);

            SqlDataReader dreader = cmd.ExecuteReader();
            
            string objective_id;
            while (dreader.Read())
            {
                objective_id = (string)dreader.GetValue(4);

                if (to_find == objective_id)
                {
                    flag = true;
                }
            }
            dreader.Close();
            cmd.Dispose();
            con.Close();


            return flag;
        }


        public void Add_employee()
        {
            
            Employee nemplo;
            try
            {
                string full_name = TextBox1.Text;
                string job_title = TextBox2.Text;
                string phone_num = TextBox3.Text;
                string e_mail = TextBox4.Text;
                string emplo_id = TextBox5.Text;
                string pass = TextBox6.Text;

                nemplo = new Employee(full_name, job_title, e_mail, phone_num, emplo_id, pass, false); //yeni çalışan


                SqlConnection con = new SqlConnection(strcon); //connection object

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("insert into User_tabl(full_name,job_title,email,phone_num,employee_id,password,account_status) values(@fn,@jt,@em,@ph,@emp,@pw,@acc)", con);

                cmd.Parameters.AddWithValue("@fn", nemplo.Full_name);
                cmd.Parameters.AddWithValue("@jt", nemplo.Job_title);
                cmd.Parameters.AddWithValue("@em", nemplo.Email);
                cmd.Parameters.AddWithValue("@ph", nemplo.Phone_num);
                cmd.Parameters.AddWithValue("@emp", nemplo.Employee_id);
                cmd.Parameters.AddWithValue("@pw", nemplo.Password);
                cmd.Parameters.AddWithValue("@acc", nemplo.Account_status);


                cmd.ExecuteNonQuery(); //executes these codes
                con.Close();

                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
                Response.Redirect("homepage.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
        

        
    }
}