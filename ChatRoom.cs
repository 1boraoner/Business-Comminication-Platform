using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCOM
{
    public class ChatRoom
    {
        protected
            string group_name;      //holds the group name
            string cretor_name;     //holds the name of the creator
            int chat_capacity;      //holds the capacity value
            int current_users;      //nubmer of users in the chat
            List<UserData> list_group; //list of all users in the chat

        public ChatRoom() { //default constructor
            current_users = 0; //default val;
            list_group = new List<UserData>();
        } 
        public ChatRoom(string name, string gp_name, int capacity)
        {
            cretor_name = name;
            group_name = gp_name;
            chat_capacity = capacity;
            current_users = 0; //default val;
            list_group = new List<UserData>();
        }

        public void update(UserData nnuser)
        {
            list_group.Add(nnuser); //appends new element to the list
        }
        public string Cretor_name
        {
            get
            {
                return cretor_name;
            }
            set
            {
                cretor_name = value;
            }
        }
        public string Group_name
        {

            get { return group_name; }
            set { group_name = value; }
        }
        public int Chat_capacity
        {
            get { return chat_capacity; }
            set { chat_capacity = value; }
        }
        public List<UserData> List_group
        {
            get
            {
                return list_group;
            }
            set
            {
                list_group = value;
            }
        }
        public int Current_users
        {

            get
            {
                return current_users;
            }
            set
            {
                current_users = value;
            }

        }
    }
}