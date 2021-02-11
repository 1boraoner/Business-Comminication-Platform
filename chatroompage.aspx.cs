using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using User;

namespace BCOM
{
    public partial class chatroompage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
                Employee User = (Employee)Session["user"];
                HiddenField1.Value = User.Full_name;
                
            
        }

        protected void HiddenField1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        protected void HiddenField2_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}