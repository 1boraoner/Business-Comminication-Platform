using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BCOM
{
    public partial class user_home_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Linkbutton1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("chatroompage.aspx");
        }

        protected void Linkbutton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("message_board_page.aspx");

        }

        protected void Linkbutton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("file_page.aspx");

        }
    }
}