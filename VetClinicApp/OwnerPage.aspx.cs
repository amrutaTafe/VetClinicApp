using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OwnerPage : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		{
			if (!IsPostBack)
				LoadGridData();
		}
	}

	private void LoadGridData()
	{
		TextBox1.Text = (string)Session["VetMailId"];

		try
		{

			string str_connection = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
			string MySelect = " SELECT [Appointment_ID],convert(varchar(10),[Appointment_Date], 111) as 'Appointment_Date',[Appointment_Time],[Vet_Comments],[Owner],t1.[Mobile_No],t1.[Street_Address],t1.[Postcode],[Pet Name],[DOB],[Type],[Breed]" +
							  " FROM [VetClinic].dbo.[Vet_Appoinment_data] as t1, [VetClinic].[dbo].[vet] as t2 " +
							  " where[Appointment_Date] >= CAST(GETDATE() AS DATE)" +
							  " AND t1.Vet_ID = t2.Vet_ID " +
							   " order by [Appointment_Date]; ";
			SqlConnection con = new SqlConnection(str_connection);
			SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
			DataSet ds = new DataSet();
			ada.Fill(ds);
			GridView1.DataSource = ds.Tables[0];
			GridView1.DataBind();
		}
		catch (Exception ex)
		{
			string message = "There was an error retrieving appointment data" + ex;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("<script type = 'text/javascript'>");
			sb.Append("window.onload=function(){");
			sb.Append("alert('");
			sb.Append(message);
			sb.Append("')};");
			sb.Append("</script>");
			ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
		}
	}

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		GridViewRow row = GridView1.SelectedRow;
		string ItemID = row.Cells[1].Text;
		Session["ItemID"] = ItemID;
		if(DropDownList1.Text == "Pet_Owner")
		{
			Response.Redirect("EditOwnerPage.aspx");
		}
		else if(DropDownList1.Text == "Pet")
		{
			Response.Redirect("EditPetPage.aspx");
		}
		else
		{
			Response.Redirect("EditApptOwnerPage.aspx");
		}
	}



	protected void btn_Cashflows_Click(object sender, EventArgs e)
	{

	}

	//Appt search button
	protected void btn_srchbyDate_Click(object sender, EventArgs e)
	{
		if (IsPostBack)
		{
			try
			{

				string str_connection = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
				string MySelect2 = " SELECT [Appointment_ID],convert(varchar(10),[Appointment_Date], 111) as 'Appointment_Date',[Appointment_Time],[Vet_Comments],[Owner],t1.[Mobile_No],t1.[Street_Address],t1.[Postcode],[Pet Name],[DOB],[Type],[Breed]" +
								   " FROM [VetClinic].dbo.[Vet_Appoinment_data] as t1, [VetClinic].[dbo].[vet] as t2 " +
								   " where[Appointment_Date] between '" + TextBox2.Text + "' and '" + TextBox3.Text + "'" +
								   " and t1.Vet_ID = t2.Vet_ID " +
								   " order by [Appointment_Date]; ";
				SqlConnection con = new SqlConnection(str_connection);
				SqlDataAdapter ada = new SqlDataAdapter(MySelect2, con);
				DataSet ds2 = new DataSet();
				ada.Fill(ds2);
				GridView1.DataSource = ds2.Tables[0];
				GridView1.DataBind();

			}
			catch (Exception ex)
			{
				string message = "There was an error retrieving appointment data" + ex;
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				sb.Append("<script type = 'text/javascript'>");
				sb.Append("window.onload=function(){");
				sb.Append("alert('");
				sb.Append(message);
				sb.Append("')};");
				sb.Append("</script>");
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
			}
		}
	}

	//Button Pet owner Search
	protected void btnSearch_Click(object sender, EventArgs e)
		
	{
		TextBox1.Text = (string)Session["VetMailId"];

		try
		{

			string str_connection = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
			string MySelect =  " SELECT * " +
							   " FROM [VetClinic].dbo.[PetOwner] " +
							   " where[LastName] like '%" + Textbox_Search.Text + "%' " +
							   " order by [LastName]; ";
			SqlConnection con = new SqlConnection(str_connection);
			SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
			DataSet ds = new DataSet();
			ada.Fill(ds);
			GridView1.DataSource = ds.Tables[0];
			GridView1.DataBind();

		}
		catch (Exception ex)
		{
			string message = "There was an error retrieving Owner data" + ex;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("<script type = 'text/javascript'>");
			sb.Append("window.onload=function(){");
			sb.Append("alert('");
			sb.Append(message);
			sb.Append("')};");
			sb.Append("</script>");
			ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
		}
	}
	//Button Pet Search
	protected void Btn_SrchPet_Click(object sender, EventArgs e)
	{
		TextBox1.Text = (string)Session["VetMailId"];

		try
		{

			string str_connection = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
			string MySelect = " SELECT * " +
							   " FROM [VetClinic].dbo.[Pet] " +
							   " where[Name] like '%" + PetTextBox.Text + "%' " +
							   " order by [Name]; ";

			SqlConnection con = new SqlConnection(str_connection);
			SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
			DataSet ds = new DataSet();
			ada.Fill(ds);
			GridView1.DataSource = ds.Tables[0];
			GridView1.DataBind();

		}
		catch (Exception ex)
		{
			string message = "There was an error retrieving Pet data" + ex;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("<script type = 'text/javascript'>");
			sb.Append("window.onload=function(){");
			sb.Append("alert('");
			sb.Append(message);
			sb.Append("')};");
			sb.Append("</script>");
			ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
		}

	}
}