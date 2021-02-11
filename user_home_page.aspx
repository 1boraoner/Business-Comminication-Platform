<%@ Page Title="" Language="C#" MasterPageFile="~/SecondMaster.Master" AutoEventWireup="true" CodeBehind="user_home_page.aspx.cs" Inherits="BCOM.user_home_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    
    
    
    <script src="/scripts/jquery-3.5.1.min.js"></script>
    <script src="/scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src="signalr/hubs"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <br />
        <br />
        <br />
        <br />

      <!-- Main jumbotron for a primary marketing message or call to action -->
      <div class="jumbotron">
        <div class="container">
          <h1 class="display-3" id="welcome_text">Welcome!</h1>
          <p><a class="btn btn-primary btn-lg" href="#" role="button">Learn more »</a></p>
        </div>
      </div>

      <div class="container">
        <!-- Example row of columns -->
        <div class="row">
          <div class="col-md-4">
            <h2>Chat Rooms</h2>
            <p>You can Create Or Join a Chat Room to Communicate with peers</p>
            <!-- <p><asp:LinkButton class="btn btn-secondary"  ID="Linkbutton1" runat="server" OnClick="Linkbutton1_Click"> Let's Chat </asp:LinkButton></p>
             -->
              <button id="button_show" type="button" class="btn btn-secondary" data-toggle="modal" data-target="#myModal">
                 Launch demo modal
             </button>

           <!-- Modal -->
            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">Available Chat ROOMS</h4>
                        </div>
                        <div class="modal-body">       
                            <input id="Text1" type="text" /><input id="Button1" type="button" value="Create A Room" />
                            <div>
                                <input type='checkbox' data-toggle='collapse' data-target='#collapsediv1'> You can Enter Chat Capacity
                            </div>
                            <div id='collapsediv1' class='collapse div1'>
                                <input id="Text3" type="text" value="2"/>
                            </div>
                            <div id="room_div">
                                <ol id="room_names">

                                </ol>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary">Save changes</button>
                        </div>
                    </div>
                </div>
            </div>
          
          </div>
          <div class="col-md-4">
            <h2>Message Board</h2>
            <p>Check The Message Board for any news or posts </p>
            <p><asp:LinkButton class="btn btn-secondary open"  ID="open" runat="server" OnClick="Linkbutton2_Click">See What's Up</asp:LinkButton></p>
          </div>
          <div class="col-md-4">
            <h2>Files</h2>
            <p>Check for Files shared in DataBase</p>
            <p><asp:LinkButton class="btn btn-secondary"  ID="Linkbutton3" runat="server" OnClick="Linkbutton3_Click"> Upload / Download / Preview Files</asp:LinkButton></p>
          </div>
        </div>

        <hr>

      </div> <!-- /container -->
   
       <script type="text/javascript">


           $(function () {


               var proxy = $.connection.chatHub;

               $("#Button1").click(function () {

                   var chat_name = $("#Text1").val();
                   $("#Text1").val("").focus();

                   var capa = $("#Text3").val();

                   proxy.server.create_Group(chat_name); //değiş#1

                   proxy.server.set_capacity(chat_name, capa); //değiş#2
               });

               $("#button_show").click(function () {

                   $("#room_names").remove();
                   $("#room_div").append("<ol id='room_names'> </ol>");

                   proxy.server.new_comer();

               });

               proxy.client.alert = function (str) {

                   alert(str);
               };

               var iter = 0;
               var double_arr =[];
               var arr = [];
               var index = 0;
               proxy.client.add_users = function (user) {

                   arr[index] = user;
                   index++;
               };

               var room = 0;
               proxy.client.add_group = function (group_name,capa) {


                   $("#room_names").append("<li id='room"+room + "'><button class ='btn btn-default' id='chat1' type='button' value='" + group_name + "'>" + group_name + " Capacity = " + capa + "</button></li><br/>");

                   double_arr[iter] = arr;
                   double_arr[iter].forEach(element => $("#room" + room + "").append("<p>" + element + "</p>"));

                   $("button[id='chat1']").on('click', function () {

                       var chat_name = $(this).val();

                       localStorage.setItem('chat_room_name', chat_name);

                       //var capa = $("#Text3").val();
                       //localStorage.setItem('chat_capacity', capa);

                       //proxy.server.create_group(chat_name);
                       //proxy.server.set_capacity(chat_name, capa);

                       //location.href = "chatroompage.aspx";

                      proxy.server.advance(chat_name);
                   });    

                   iter++;
                   index = 0;
                   arr = [];
                   room++;

               };

               


               proxy.client.advance_2 = function (flag) {
                   if (flag == 0) {
                       alert("You Dont Try");
                   } else {
                       location.href = "chatroompage.aspx";
                   }
               };

               



               $.connection.hub.start().done(function () {

                   

               });
           });
       </script>

</asp:Content>
