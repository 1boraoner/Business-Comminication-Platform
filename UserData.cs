using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BCOM
{
    public class UserData
    {
        protected

        string groupName; //holds the group name that user joins
        string user_name; //holds the user name
        string user_Id;   //holds the connection id of the user
        bool active;      //state of the user whether user is in chat
        DateTime connection_date; //time of user's connection

        public UserData(){ }    //Default Constructor
        public UserData(string a,string b, bool c, DateTime d, string e ="null")
        {
            groupName = e; 
            user_name = a;
            user_Id = b;
            active = c;
            connection_date = d;
        }
        public string GroupName
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
            }
        }
        public string User_name{
            get
            {
                return user_name;
            }
            set
            {
                user_name = value;
            }
        }
        public string User_Id{
            get
            {
                return user_Id;
            }
            set
            {
                user_Id = value;
            }
        }
        public bool Active{
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }
        public DateTime Connection_date{
            get
            {
                return connection_date;
            }
            set
            {
                connection_date = value;
            }
        }
    }
}