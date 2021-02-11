 <%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="e_mail_page.aspx.cs" Inherits="BCOM.SendMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    
    <div id="id1" runat="server" class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                      <div class="col">
                          <h2>B-COM</h2>
                          <h4> Sign In </h4>
                      </div>
                  </div>
                  <div class="row">
                     <div class="col">
                         <div class="form-group">
                            Message sender:<asp:TextBox CssClass ="form-control" ID="txtFrom" runat="server" /><br>
                         </div>
                         <div class="form-group">
                            Password:      <asp:TextBox CssClass ="form-control" ID="txtPass" TextMode="Password" runat="server" /><br>
                         </div>
                         <div class="form-group">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                <asp:ListItem Value="Gmail" Text='<img src="images/gmail.png" width=70 height=50 alt="Gmail"/>'></asp:ListItem>
                                <asp:ListItem Value="Outlook" Text='<img src="images/outlook.png" width=70 height=50 alt="Outlook" />'></asp:ListItem>
                                <asp:ListItem Value="Yahoo" Text='<img src="images/yahoomail-1.png" width=70 height=50 alt="Yahoo"/>'></asp:ListItem>
                            </asp:RadioButtonList>
                         </div>
                         <div class="form-group">
                             <asp:Button ID="Continue" runat="server" Text="Continue" OnClick="Mail_Continue"/>
                         </div>
                    </div>
                </div>
            </div>
          </div>
        </div>
      </div>
    </div>
 
    <div id="mail_body" class="container" runat="server">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                   <div class="row">
                       <div class="col">
                           <div class="form-group">
                                Message recipient: <asp:TextBox CssClass="form-control" ID="txtTo" runat="server" /><br>
                           </div>
                           <div class="form-group">
                                Message subject: <asp:TextBox CssClass="form-control" ID="txtSubject" runat="server" /><br>
                           </div>
                           <div class="input-group">
                              <div class="input-group-prepend">
                                <span class="input-group-text">Mail Body</span>
                              </div>
                              <textarea runat="server" ID="txtBody" class="form-control" aria-label="With textarea"></textarea>
                           </div>
                       </div>
                   </div>
                   <div class="row">
                       <div class="col">
                          <asp:Button ID="Send" runat="server" Text="Send" OnClick="SendMessage_Click"/>
                       </div>
                   </div>
                </div>
            </div>
          </div>
        </div>
      </div>
 </asp:Content>
