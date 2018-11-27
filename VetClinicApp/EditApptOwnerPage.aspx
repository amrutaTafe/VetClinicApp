<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="EditApptOwnerPage.aspx.cs" Inherits="EditApptOwnerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <div style="width:844px; margin-top:20px; margin-bottom:20px;">
<asp:GridView ID="GridView1" runat="server" Width="844px" CellSpacing="3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:ButtonField CommandName="Select" Text="Select" />
    </Columns>
</asp:GridView>
        

    <div style="float:left; width:844px; margin-top:20px; margin-bottom:20px;">
        <table style="width:250px;">
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Payment"></asp:Label></td>
                <td><asp:TextBox ID="Textbox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="Appointment Date"></asp:Label></td>
                <td><asp:TextBox ID="Textbox2" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label3" runat="server" Text="Appointment Time"></asp:Label></td>
                <td><asp:TextBox ID="Textbox3" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="ApptUpd_btn" runat="server" Text="Update" OnClick="ApptUpd_btn_Click" /></td>
            </tr>
        </table>
    </div>         
    
</asp:Content>

