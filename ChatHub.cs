using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections.Concurrent;
using System.Threading;



using User;
using BCOM;
using System.ComponentModel.Design;
using System.Windows;

namespace BCOM
{
    public class ChatHub : Hub
    {
        private static int number_user = 0; //used as an offset in declearing user name

        private static ConcurrentDictionary<string, UserData> group_users = new ConcurrentDictionary<string, UserData>();

        private static ConcurrentDictionary<string, ChatRoom> group_infos = new ConcurrentDictionary<string, ChatRoom>();

        public override Task OnConnected()
        {
            Interlocked.Increment(ref number_user);
 
            var newUser = new UserData();
            newUser.User_name = "user" + number_user;
            newUser.Active = true;
            newUser.Connection_date = DateTime.Now;
            newUser.User_Id = Context.ConnectionId;

            group_users[Context.ConnectionId] = newUser;
            return base.OnConnected();
        } //start connections

        public void Create_Group(string group)
        {
            group_infos[group] = new ChatRoom();
        } //create the group obejects and store in dict.
        
        public async Task Join(string groupName)
        {
            if(group_infos[groupName].Chat_capacity == group_infos[groupName].Current_users)
            {
                await Clients.Caller.alert("Room is Full");
            }
            else
            {
                bool flag = group_users.Any(b => (b.Value != null && b.Value.GroupName == groupName));
                if (flag)
                {
                    Create_Group(groupName);
                }
                UserData user = group_users[Context.ConnectionId];
                user.GroupName = groupName;
                group_users[Context.ConnectionId] = user;

                ChatRoom nn = new ChatRoom();
                nn = group_infos[groupName];

                if (nn.Current_users == 0)
                {
                    nn.Cretor_name = user.User_name;
                    nn.Group_name = groupName;
                    nn.Current_users++;
                    nn.List_group.Add(user);
                }
                else
                {
                    nn.List_group.Add(user);
                    nn.Current_users++;
                }
                group_infos[groupName] = nn;
                await Groups.Add(Context.ConnectionId, groupName);
            }
        } //join group by the group name

        public void Advance(string a)
        {

            bool flag = true;
            if (group_infos[a].Current_users == group_infos[a].Chat_capacity)
            {
                flag = false;
            }
            Clients.Caller.advance_2(flag);
        } //after user selects the group, advance the user to the next page 

        public async Task New_comer()
        {

            foreach(KeyValuePair<string,ChatRoom> rooms in group_infos)
            {
                if(rooms.Key == "")
                {
                    continue;
                }
                ChatRoom x = rooms.Value;

                foreach (var users in x.List_group)
                {

                    await Clients.All.add_users(users.User_name);

                }
                int cC = x.Chat_capacity;
                await Clients.Caller.add_group(rooms.Key, cC);

            }

        } //adds new user to the group

        public async Task Set_capacity(string gpname, int num =2) //sets capacity for chat_room
        {
            ChatRoom a = new ChatRoom();
            group_infos[gpname] = a;
            a.Chat_capacity = num;
            a = group_infos[gpname];

            await Clients.All.add_group(gpname,a.Chat_capacity);
        }

        public void Set_name(string name) //sets user_name
        {
            UserData user = group_users[Context.ConnectionId];
            user.User_name = name;
            group_users[Context.ConnectionId] = user;
            
        } 

        public async Task Group_only(string message) //chat purpose
        {
            UserData user = group_users[Context.ConnectionId];
            string gnp = user.GroupName;
            string name = user.User_name;

            await Clients.OthersInGroup(gnp).broad(name,message);
            await Clients.Caller.self(name,message);
        }

        public void Create_room(string gp_name)
        {
            Clients.All.add_group(gp_name,group_infos[gp_name].Chat_capacity);

        } //creates the room object with given name

    }
}