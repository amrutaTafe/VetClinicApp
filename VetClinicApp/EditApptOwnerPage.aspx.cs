using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class EditApptOwnerPage : System.Web.UI.Page
{
	public string @ApptID;

	protected void Page_Load(object sender, EventArgs e)
	{
		string Apptid = (string)Session["ItemID"];
		ApptID = Apptid;
		{
			if (!IsPostBack)
				LoadGridData();
		}
	}
	private void LoadGridData()
	{

		try
		{

			string str_connection = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
			string MySelect = " SELECT [Appointment_ID],[Vet_ID],[Pet_ID],[payment],[paid],convert(varchar(10),[Appointment_Date], 111) as 'Appointment_Date',[Appointment_Time],[Vet_Comments] " +
							  " FROM [VetClinic].[dbo].[Appointment] " +
							  " WHERE [Appointment_ID] = " + ApptID + " ;";
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
		Textbox1.Text = row.Cells[4].Text;
		Textbox2.Text = row.Cells[6].Text;
		Textbox3.Text = row.Cells[7].Text;
	}

	protected void ApptUpd_btn_Click(object sender, EventArgs e)
	{
		try
		{

			string connectionString = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
			string MyUpd = "";
			SqlConnection con = new SqlConnection(connectionString);
			MyUpd = " Update [VetClinic].[dbo].[Appointment] " +
					" Set [Appointment_Date] = '" + Textbox2.Text + "'" +
					" ,[Appointment_Time] = '" + Textbox3.Text + "'" +
					" ,[Payment] = '" + Textbox1.Text + "'" +
					" where Appointment_ID = '" + ApptID + "' ";
			con.Open();
			SqlCommand ApptUpd = new SqlCommand(MyUpd, con);
			ApptUpd.ExecuteNonQuery();
			con.Close();
			ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Appointment details updated OK')", true);
			LoadGridData();
			
		}
		catch (Exception ex)
		{
			string message = "There was an error updating Appointment data" + ex;
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