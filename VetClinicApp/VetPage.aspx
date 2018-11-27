<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="VetPage.aspx.cs" Inherits="VetPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    
    <div class="Maincontent">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>  
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="10pt" Font-Underline="True" Text="Select an Appointment for edit"></asp:Label>
        <br />
    </div>
    <div style="width:844px; margin-top:20px;">
        <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" Height="50px" Width="844px" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="7" AllowPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" >
            <Columns>
                <asp:ButtonField CommandName="Select" Text="Select" />
            </Columns>
        </asp:GridView>
    </div>

    <div style="margin-top:20px; margin-bottom:20px;">
        <asp:Button ID="Button2" runat="server" Text="Search" OnClick="Button2_Click" />
        &nbsp;<asp:Label ID="Label1" runat="server" Font-Size="12px" Font-Names="Tahoma" Text="Date From(YYYY-MM-DD)"></asp:Label>
        &nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        &nbsp;<asp:Label ID="Label2" runat="server" Font-Size="12px" Font-Names="Tahoma" Text="Date To"></asp:Label>
        &nbsp;<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </div>

</div>  
    
</asp:Content>

