using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using User;

namespace BCOM
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public Employee current_user {
            get
            {
                return current_user;
            }
            set
            {
                current_user = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty((string)Session["role"]))
            {
                
                LinkButton1.Visible = true; //Login dir
                LinkButton2.Visible = true; //Signup dir
                LinkButton9.Visible = true; //Admin dir

                LinkButton3.Visible = false; // Hello
                LinkButton4.Visible = false; //Logout
                LinkButton5.Visible = false; //Dropdown Element
                LinkButton6.Visible = false; //Dropdown Element
                LinkButton7.Visible = false; //Dropdown Element
                LinkButton8.Visible = false; //Dropdown Element
                drop1.Visible = false; // DropDownList
            }
            
            if ((string)Session["role"]=="employee")
            {
                LinkButton1.Visible = false; //Login dir
                LinkButton2.Visible = false; //Signup dir
                LinkButton9.Visible = false;

                LinkButton3.Visible = true; // Hello
                LinkButton4.Visible = true; //Logout
                LinkButton5.Visible = true; //Dropdown Element
                LinkButton6.Visible = true; //Dropdown Element
                LinkButton7.Visible = true; //Dropdown Element
                LinkButton8.Visible = true; //Dropdown Element
                drop1.Visible = true; //Drop Down List

                Employee current_user = (Employee)Session["user"];
                LinkButton3.Text = "Hello " + current_user.Full_name;
            }

            if ((string)Session["role"] == "admin")
            {
                LinkButton1.Visible = false; //Login dir
                LinkButton2.Visible = false; //Signup dir
                LinkButton9.Visible = false;

                LinkButton3.Visible = true; // Hello
                LinkButton4.Visible = true; //Logout
                LinkButton5.Visible = true; //Dropdown Element
                LinkButton6.Visible = true; //Dropdown Element
                LinkButton7.Visible = true; //Dropdown Element
                LinkButton8.Visible = true; //Dropdown Element
                drop1.Visible = true; //Drop Down List

                Employee admin = (Employee)Session["user"];
                LinkButton3.Text = "Hello " + "Admin";
            }
        }
        //                Employee admin = (Employee)Session["user"];

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginpage.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("signuppage.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_home_page.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session["user"] = "";
            Session["role"] = "";


            LinkButton1.Visible = true; //Login dir
            LinkButton2.Visible = true; //Signup dir

            LinkButton3.Visible = false; // Hello
            LinkButton4.Visible = false; //Logout
            LinkButton5.Visible = false; //Dropdown Element
            LinkButton6.Visible = false; //Dropdown Element
            LinkButton7.Visible = false; //Dropdown Element
            LinkButton8.Visible = false; //Dropdown Element

            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("chatroompage.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("e_mail_page.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("file_page.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("message_board_page.aspx");
        }
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_login.aspx");
        }
    }
}