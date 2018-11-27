using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class VetPage : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
			LoadGridData();
	}

	private void LoadGridData()
	{
		TextBox1.Text = (string)Session["VetMailId"];

		try
		{

			string str_connection = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
			
			string MySelect = " SELECT Appointment_ID, [Appointment_Date],[Appointment_Time],[Vet_Comments],[Owner],t1.[Mobile_No],t1.[Street_Address],t1.[Postcode],[Pet Name],[DOB],[Type],[Breed] " +
							  " FROM [VetClinic].dbo.[Vet_Appoinment_data] as t1, [VetClinic].[dbo].[vet] as t2 " +
							  " WHERE [Appointment_Date] >= CAST(GETDATE() AS DATE) " +
							  " AND t1.Vet_ID = t2.Vet_ID AND t2.Email = '" + TextBox1.Text + "' " +
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

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		LoadGridData();
	}

	//Search Button
	protected void Button2_Click(object sender, EventArgs e)
	{
		if (IsPostBack)
		{
			try
			{

				string str_connection = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
				string MySelect2 = " SELECT Appointment_ID, [Appointment_Date],[Appointment_Time],[Vet_Comments],[Owner],t1.[Mobile_No],t1.[Street_Address],t1.[Postcode],[Pet Name],[DOB],[Type],[Breed]" +
								   " FROM [VetClinic].dbo.[Vet_Appoinment_data] as t1, [VetClinic].[dbo].[vet] as t2 " +
								   " where[Appointment_Date] between '" + TextBox2.Text + "' and '" + TextBox3.Text + "'" +
								   " and t1.Vet_ID = t2.Vet_ID and t2.Email = '" + TextBox1.Text + "' " +
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

	public string ApptID;	

	protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
	{
		GridViewRow row = GridView1.SelectedRow;
		ApptID = row.Cells[1].Text;
		Session["ApptID"] = ApptID; // convert.ToString(ApptID);
		Response.Redirect("EditApptPage.aspx");
		
	}
}