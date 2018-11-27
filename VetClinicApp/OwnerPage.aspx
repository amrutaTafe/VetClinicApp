<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="OwnerPage.aspx.cs" Inherits="OwnerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 57px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    
    <div style="width:844px; margin-bottom:20px;">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>  
    
    <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True">
        <Columns>
            <asp:ButtonField CommandName="Select" Text="Select" />
        </Columns>
    </asp:GridView>
    <br />
    
    &nbsp;
    <br />
    <br />
    <asp:Button ID="btn_Cashflows" runat="server" OnClick="btn_Cashflows_Click" Text="Cash Flows" />
    <br />
    <br />
    <br />
    <table style="width:281px; align-content:center">
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Select item type"></asp:Label></td>
            <td><asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Appointment</asp:ListItem>
                <asp:ListItem>Pet_Owner</asp:ListItem>
                <asp:ListItem>Pet</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="auto-style1"><asp:TextBox ID="Textbox_Search" runat="server"></asp:TextBox></td>
            <td class="auto-style1"><asp:Button ID="btnSearch" runat="server" Text="Search Client" OnClick="btnSearch_Click" /></td>          
        </tr>
        <tr>
            <td><asp:TextBox ID="PetTextBox" runat="server"></asp:TextBox></td>
            <td><asp:Button ID="Btn_SrchPet" runat="server" Text="Search Pet" OnClick="Btn_SrchPet_Click" Width="99px" /></td>
        </tr>
    </table>

<br />
<asp:Label ID="Label2" runat="server" Text="Date Form (YYYY-MM-DD)"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="Label3" runat="server" Text="Date to"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btn_srchbyDate" runat="server" Text="Search Appointment by Date" OnClick="btn_srchbyDate_Click" />
<br />
<br />
    <br />
    
</asp:Content>

