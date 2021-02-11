using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using User;

namespace BCOM
{
    public partial class SendMail : System.Web.UI.Page
    {
        protected SmtpClient smtpClient;

        protected void Page_Load(object sender, EventArgs e)
        {
            mail_body.Visible = false;
            id1.Visible = true;
            try
            {
                Employee per = (Employee)Session["user"];

                txtFrom.Text = per.Email;

            }
            catch (Exception ex) {
                Response.Write("No e-mail specified Please enter Menually");
            }
        
        }


        protected void SendMessage_Click(object sender, EventArgs e)
        {
            Employee person = (Employee)Session["user"]; //get session user
            string str = RadioButtonList1.SelectedValue; //select of mail

            if ( str == "Gmail")
            {
                smtpClient = new SmtpClient("smtp.gmail.com", 587);
            }
            else if (str == "Yahoo")
            {
                smtpClient = new SmtpClient("smtp.mail.yahoo.com", 587);
            }
            else if (str == "Outlook")
            {
                smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);
            }
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(person.Email, txtPass.Text);//custom credientials
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mailMessage = new MailMessage(person.Email, txtTo.Text); //message object
            mailMessage.Subject = txtSubject.Text;                               //get textbox content
            mailMessage.Body = txtBody.InnerText;                                //get textbox content 

            try
            {
                smtpClient.Send(mailMessage); //send messages
                Response.Write("E-mail Sent");
            }
            catch (Exception ex)
            {
                Response.Write("An Error Has Occured");
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
                
                Response.Write("Select An Acceptable Mailing Address");
            
        }
    
        protected void Mail_Continue(object sender, EventArgs e)
        {
            id1.Visible = false;
            mail_body.Visible = true;

        }
    }
}
