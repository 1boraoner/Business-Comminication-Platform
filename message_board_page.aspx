<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="message_board_page.aspx.cs" Inherits="BCOM.message_board_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />  <br />
    <br />
    <br />
    <br />
    <br />
    

    <h3>MESSAGE BOARD</h3>
    <div>
        <asp:GridView class="table table-striped table-bordered" ID="msg_board" runat="server" AutoGenerateColumns="false" CellPadding="10" CellSpacing="10" Gridlines="Horizontal" Width="98%" Height="200px">
            <Columns>
                <asp:TemplateField HeaderText="Message Topic/Context">
                    <ItemTemplate>
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col lg-10">
                                    <asp:Label ID="Mess_topic" runat="server" Font-Size="Large" Font-Bold="true" Text='<%# Eval("topic") %>'></asp:Label> 
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    &nbsp;|
                                    <asp:Label ID="Mess_content" runat="server" Font-size="Large" Text='<%# Eval("message_content") %>'></asp:Label>
                                    &nbsp;|
                                    <br />
                                    <br />
                                    <br />

                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Date/Contributor">
                    <ItemTemplate>
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="Mess_cont" runat="server" Font-Size="Large" Text='<%# Eval("contributor") %>'></asp:Label> 
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="Mess_date" runat="server" Font-Size="Medium" Text='<%# Eval("post_date") %>'></asp:Label>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>           
                <asp:BoundField DataField="message_id" HeaderText="Message_id" />
                <asp:TemplateField HeaderText="del_row">
                        <ItemTemplate>
                            <asp:LinkButton ID="Del_button" Text="Delete" runat="server" CommandArgument='<%# Eval("message_id") %>' OnClick="Delete_message"/>
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <div class="container">
        <div class="row">
            <div class="col mx-auto">
                Message Topic:<br />

                <asp:TextBox ID="topic_box" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col">
                Message:
                <textarea id="message_box" runat="server" aria-label="With textarea" class="form-control"></textarea>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col">
                <asp:Button ID="Post" runat="server" text="Post Message" OnClick="post_1" />
            </div>
        </div>
    </div>



</asp:Content>
