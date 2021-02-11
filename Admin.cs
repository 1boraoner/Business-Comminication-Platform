using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using User;

namespace BCOM
{
    public class Admin : Employee
    {
        /*
        private
        string admin_name;  //name of the admin
        string email;       //the email address of the admin
        string admin_id;    //admin id
        string username;    //login name of the admin
        string password;    //account password of the admin
        */

        private int unique_key;


        public Admin(int uni, string fn, string jt, string em, string ph, string emp, string pw, bool acs) : base(fn, jt, em, ph, emp, pw, acs)
        {
            unique_key = uni;
        }

    }
    
}