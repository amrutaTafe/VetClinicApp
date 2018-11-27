using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class EditApptPage : System.Web.UI.Page
{
	public string apptid;

	protected void Page_Load(object sender, EventArgs e)
	{
		if(!IsPostBack)
		{
			LoadGridData();
			LoadMeds();
		}
	}
	private void LoadGridData()
	{
		apptid = (string)Session["ApptID"];


		try
		{

			string str_connection = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
			string MySelect = " SELECT [Appointment_ID],[Appointment_Date],[Appointment_Time],[Vet_Comments],[Owner],t1.[Mobile_No],t1.[Street_Address],t1.[Postcode],[Pet Name],[DOB],[Type],[Breed] FROM [VetClinic].dbo.[Vet_Appoinment_data] as t1, [VetClinic].[dbo].[vet] as t2 " +
							  " WHERE t1.Vet_ID = t2.Vet_ID AND t1.[Appointment_ID] = '" + apptid + "';";

			SqlConnection con = new SqlConnection(str_connection);
			SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
			DataSet ds = new DataSet();
			ada.Fill(ds);
			GridView2.DataSource = ds.Tables[0];
			GridView2.DataBind();
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
	private void LoadMeds()
	{
		try
		{
			string str_connection = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
			string MySelect2 = " SELECT [Medication_ID],[Name] " +
							   "FROM [VetClinic].dbo.[Medication] ";						   

			SqlConnection con2 = new SqlConnection(str_connection);
			SqlDataAdapter ada = new SqlDataAdapter(MySelect2, con2);
			DataSet ds2 = new DataSet();
			ada.Fill(ds2);
			GridView4.DataSource = ds2.Tables[0];
			GridView4.DataBind();
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


	protected void btnCopy_Click(object sender, EventArgs e)
	{
		DataTable dt = new DataTable();
		dt.Columns.Add("Medication_ID");
		dt.Columns.Add("Name");

		foreach (GridViewRow row in GridView4.Rows)
			if (((CheckBox)row.Cells[0].FindControl("cbSelect")).Checked)
				dt.Rows.Add(row.Cells[1].Text, row.Cells[2].Text);

		GridView5.DataSource = dt;
		GridView5.DataBind();
		LoadGridData();
	}

	/*protected void btn_updateComts_Click(object sender, EventArgs e)
	{
		string connectionString = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
		//string connectionString = "Data Source = MSSQLSERVER016; Initial Catalog = VetClinic; Integrated Security = True";

		int rowIndex;
		//string comtxt;

		comtxt = GridView2.Rows[rowIndex].FindControl("TextBox2");
		SqlConnection con = new SqlConnection(connectionString);

		try
		{
			// SqlDataDapter ada = new SqlDataAdapter(MyInsert, con);
			string MyUpd = "Update Appointment " +
						   " Set vet_Comments = '" + GridView2.Rows[rowIndex].FindControl("TextBox2") + "'; ";  //row.Cells[4].Text + "' " ;";

			con.Open();
			SqlCommand ApptUpd = new SqlCommand(MyUpd, con);
			ApptUpd.ExecuteNonQuery();
		}
		catch(SqlException ex)
		{
			string script1 = "< script type = 'text/javascript'>alert('{0}');</script>";
			this.ClientScript.RegisterStartupScript(this.GetType(), "alert", string.Format(script1, ex.Message));
			Session["ErrMsg"] = ex.Message.ToString();
			//Response.Redirect("AbortOrder.aspx");
		}
		LoadGridData();
		//con.close(); 
	} */

	protected void BtnAddMeds_Click(object sender, EventArgs e)
	{
		apptid = (string)Session["ApptID"];
		try
		{
			string connectionString = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
			string MyInsert = "";
			SqlConnection con = new SqlConnection(connectionString);
			for(int j = 0; j < GridView5.Rows.Count; j++)
			{
				int Qty = Convert.ToInt16(((TextBox)GridView5.Rows[j].Cells[2].FindControl("Quantity")).Text);
				MyInsert = "Insert into[VetClinic].[dbo].[Appointment_Medication] " +
						   " (Appointment_ID, Medication_ID, Quantity ) " +
						   " values (" + apptid + "," + Convert.ToInt16(GridView5.Rows[j].Cells[0].Text) + "," + Qty + "); ";

				con.Open();
				SqlCommand ApptUpd = new SqlCommand(MyInsert, con);
				ApptUpd.ExecuteNonQuery();
			}
			ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Medications added OK')", true);
		}
		catch (Exception ex)
		{
			string message = "There was an error adding Medications" + ex;
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

	protected void Grid2_Upd_Row(object sender, GridViewUpdateEventArgs e)
	{		
	try
		{ 		
			string connectionString = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
			SqlConnection con = new SqlConnection(connectionString);

			GridViewRow row = GridView2.SelectedRow;
			apptid = row.Cells[1].Text;

			string MyUpdate = "";			
			MyUpdate = " Update[dbo].[Appointment] " +
					   " Set Vet_Comments = '" + ((TextBox)GridView2.SelectedRow.Cells[4].FindControl("Vet_Comments")).Text + "'" +
					   " WHERE Appointment_ID = " + apptid + ";";
				con.Open();
				SqlCommand AppUpd = new SqlCommand(MyUpdate, con);
				AppUpd.ExecuteNonQuery();
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Appointment Comments Updated OK')", true);			
		}
		catch (Exception ex)
		{
			string message = "There was an error updateing the appointment comments" + ex;
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


	protected void Grid2_UPDD_Row(object sender, GridViewUpdatedEventArgs e)
	{

	}

	protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
	{

	}

	protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
	{

	}
}
