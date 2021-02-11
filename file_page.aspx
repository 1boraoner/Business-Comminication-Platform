<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="file_page.aspx.cs" Inherits="BCOM.file_page" %>
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
    &nbsp;<p>Select a File to Upload --><asp:FileUpload ID="FileUpload1" runat="server" type="" />&nbsp;<asp:LinkButton id="Upload" class="file-upload btn btn-primary" runat="server" OnClick="Upload_file">Upload</asp:LinkButton>

    </p>
    
    <div class="row">
        <div class="col">
            <asp:Button id="click" runat="server" ClientIDMode="Static"  OnClick="construct_file_table" Text="Refresh Table" />
            <asp:GridView ID="File_table01" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="file_name" HeaderText="File Name" />
                    <asp:BoundField DataField="format" HeaderText="Format" />
                    <asp:BoundField DataField="size" HeaderText="Size" />
                    <asp:BoundField DataField="contributor" HeaderText="Contributor" />
                    <asp:TemplateField >
                        <ItemTemplate>
                            <asp:LinkButton ID="Download" Text="Dowload" runat="server" CommandArgument='<%# Eval("file_name") %>' OnClick="download_file"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField >
                        <ItemTemplate>
                            <asp:LinkButton id="Preview" Text="Preview" runat="server" CommandArgument='<%# Eval("file_name") %>' OnClick="preview_file" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>      
        
        <div class="col">
          <iframe id="MyIframe" runat="server"  width="800" height="600" /> 
        </div>
    </div>
    <p>&nbsp;</p>
   
    </asp:Content>
