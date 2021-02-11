<%@ Page Title="" Language="C#" MasterPageFile="~/SecondMaster.Master" AutoEventWireup="true" CodeBehind="chatroompage.aspx.cs" Inherits="BCOM.chatroompage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
 
    <script src="/scripts/jquery-3.5.1.min.js"></script>
    <script src="/scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src="signalr/hubs"></script>
   
    

    
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <br />
   <br />
   <br />
   <br />
   <br />
   <br />

    <div class="container border border-primary" >
        <div class="row">
            <div class="col-2 border border-dark">
                <span id="grup_name"> Online Chatters</span>
                <div >
                    <ul id="contact_list">
                    </ul>
                </div>
            </div>
            <div class="col-10">
                <label><img src="images/live_chat.jpeg" width="70" height="70" /><p > Live Chat Layer</p> </label>
                <div class="border min-vh-100">
                    <ul id="mess_chat" class="list-group list-unstyled">
                     </ul>
                </div>
                <div class="input-group input-group-lg">
                  <div class="input-group-prepend">
                    <button id="button2" type="button" value="Send">
                        <span class="input-group-text" id="inputGroup-sizing-lg">
                            <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-chat-left-dots-fill" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd" d="M0 2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2H4.414a1 1 0 0 0-.707.293L.854 15.146A.5.5 0 0 1 0 14.793V2zm5 4a1 1 0 1 1-2 0 1 1 0 0 1 2 0zm4 0a1 1 0 1 1-2 0 1 1 0 0 1 2 0zm3 1a1 1 0 1 0 0-2 1 1 0 0 0 0 2z"/>
                            </svg>
                        </span>
                    </button>
                      
                  </div>
                    
                  <input id="Text2" type="text" placeholder="Write your message..." class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg">
                </div>
            </div>
        </div>
    </div>
  
    
    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hidden_grpname" runat="server" ClientIDMode="Static" />  

    <script type="text/javascript">
        $(function () {

            var proxy = $.connection.chatHub;   //a proxy is generated between server and clients
            /******Client Side Functions******/
            proxy.client.broad = function (name, mess) {    //Sent messages are recived, and for others users the color of the message differ
                $("#mess_chat").append("<li class='list-group-item list-group-item-warning'<div class='float-left'>" + name + " : " + mess + "<div/></li>");
            };
            proxy.client.self = function (name, mess) {     //the owner of the message sees his/her own message different
                $("#mess_chat").append("<li class='list-group-item list-group-item-primary'><div class='float-right'>"+ name + " : " + mess + "</div></li>");
            };
            proxy.client.alert = function (str) {           //alert function
                alert(str);
            };
            proxy.client.change_cont = function (str) { 
                $("#contact_list").clear();
                $("#contact_list").append("<li>" + name + "</li>");
            };

            /******Server Side Functions******/
            $("#button2").click(function () {
                var message = $("#Text2").val();
               proxy.server.group_only(message);                        //calls Group_only() from server
            });
            $.connection.hub.start().done(function () {
                var gp_name = localStorage.getItem('chat_room_name');
                proxy.server.join(gp_name);                             //calls Join() from server functions

                var name = $("#HiddenField1").val();
                proxy.server.set_name(name);                            //invokes Set_name() from server
                proxy.server.new_comer(name);                           //calls New_comer() from server
                $("#grup_name").append("<p>" + gp_name + "</p>");
                $("#hidden_grpname").val(gp_name);
                localStorage.clear();
            });
        });
    </script>

    
</asp:Content>
