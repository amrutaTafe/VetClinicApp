<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="EditApptPage.aspx.cs" Inherits="EditApptPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
   
    
<div class="Maincontent">

    <div style="margin-bottom:20px;">
    </div>  
    <div style="width:844px;">
        <asp:GridView ID="GridView2" runat="server" HorizontalAlign="Left" Height="167px" PageSize="7" Width="844px" OnRowUpdated="Grid2_UPDD_Row" OnRowUpdating="Grid2_Upd_Row" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" CellSpacing="1" AutoGenerateColumns="False">
        <Columns>
            <asp:ButtonField CommandName="Update" Text="Update" />
            <asp:BoundField DataField="Appointment_ID" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="Appointment_Date" HeaderText="Date" ReadOnly="True" />
            <asp:BoundField DataField="Appointment_Time" HeaderText="Time" ReadOnly="True" />
            <asp:TemplateField HeaderText="Vet_Comments">
            <ItemTemplate><asp:TextBox ID="Vet_Comments" runat="server"></asp:TextBox></ItemTemplate>     
            </asp:TemplateField>
            <asp:BoundField DataField="Owner" HeaderText="Owner" ReadOnly="True" />
            <asp:BoundField DataField="Mobile_No" HeaderText="Mobile_No" ReadOnly="True" />
            <asp:BoundField DataField="Street_Address" HeaderText="Street_Address" ReadOnly="True" />
            <asp:BoundField DataField="PostCode" HeaderText="PostCode" ReadOnly="True" />
            <asp:BoundField DataField="Pet Name" HeaderText="Pet Name" ReadOnly="True" />
            <asp:BoundField DataField="DOB" HeaderText="DOB" ReadOnly="True" />
            <asp:BoundField DataField="Type" HeaderText="Type" ReadOnly="True" />
            <asp:BoundField DataField="Breed" HeaderText="Breed" ReadOnly="True" />
        </Columns>   
        </asp:GridView>
    </div>

        <div style="float:left;width:844px; padding-bottom:5px;">
            <div style="float:left;">
                <asp:Label ID="Label1" runat="server" Text="Medications Selected"></asp:Label>
            </div>
            <div style="float:right;">
                <asp:Button ID="BtnAddMeds" runat="server" Text="Add Medications to Appt" OnClick="BtnAddMeds_Click" />
            </div>
        </div>

        <div style="float:left; margin-bottom:20px;">
            <asp:GridView ID="GridView5" runat="server" HorizontalAlign="Center" Width="844px" Height="0px" AutoGenerateColumns="False" CellPadding="3" Font-Bold="True" Font-Names="Arial" Font-Size="12pt" OnSelectedIndexChanged="GridView5_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField ="Medication_ID" HeaderText="Medication_ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:TemplateField HeaderText ="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="Quantity" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
               </asp:GridView>
        </div>
    
    
   <!-- <div style="margin-bottom:20px;">
        <asp:Label ID="Label2" runat="server" Text="Select Medications"></asp:Label>
    </div> -->
    <div>
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" Width="844px" HorizontalAlign="left" Height="30px">
            <Columns>
                <asp:TemplateField HeaderText ="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField ="Medication_ID" HeaderText="Medication_ID" />
                <asp:BoundField DataField ="Name" HeaderText="Name" />
            </Columns>  
        </asp:GridView>
    </div>
    <div style="padding-top:10px; padding-bottom:10px; width:844px;float:left;">
        <asp:Button ID="btnCopy" runat="server" OnClick="btnCopy_Click" Text="Copy Rows" />
    </div>
</div>

</asp:Content>

