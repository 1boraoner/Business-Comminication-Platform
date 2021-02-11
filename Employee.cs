using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace User
{
    
    public class Employee
    {
        protected
        string full_name;   //name of the user
        string job_title;   //job title of the user
        string email;       //the email address of the user
        string phone_num;   //phone number of the user
        string employee_id; //login id of the user
        string password;    //account password of the user
        bool account_status;//account status indicating the online or offline status

        public Employee() { } //default constructor

        public Employee(string fn, string jt, string em,string ph,string emp, string pw, bool acs)
        {
            full_name = fn;
            job_title = jt;
            email = em;
            phone_num = ph;
            employee_id = emp;
            password = pw;
            account_status = acs;

        }

        public string Full_name
        {
            get
            {
                return full_name;
            }
            set
            {
                full_name = value;
            }
        }
        public string Job_title
        {
            get
            {
                return job_title;
            }
            set
            {
                job_title = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Phone_num
        {
            get
            {
                return phone_num;
            }
            set
            {
                phone_num = value;
            }
        }
        public string Employee_id
        {
            get
            {
                return employee_id;
            }
            set
            {
                employee_id = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public bool Account_status
        {
            get
            {
                return account_status;
            }
            set
            {
                account_status = value;
            }
        }
    }
}