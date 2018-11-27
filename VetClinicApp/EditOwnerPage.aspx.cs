using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class EditOwnerPage : System.Web.UI.Page
{
	public string @Pet_OwnerID;

	protected void Page_Load(object sender, EventArgs e)
	{
		string OwnerID = (string)Session["ItemID"];
		@Pet_OwnerID = OwnerID;
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
			string MySelect = "SELECT * " +
							  " FROM [VetClinic].[dbo].[PetOwner]" +
							  " WHERE [Pet_OwnerID] = " + @Pet_OwnerID + " ;";
			

			SqlConnection con = new SqlConnection(str_connection);
			SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
			DataSet ds = new DataSet();
			ada.Fill(ds);
			GridView1.DataSource = ds.Tables[0];
			GridView1.DataBind();
		}
		catch (Exception ex)
		{
			string message = "There was an error retrieving Pet Owner data" + ex;
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
		Textbox1.Text = row.Cells[2].Text;
		Textbox2.Text = row.Cells[3].Text;
		Textbox3.Text = row.Cells[4].Text;
	}

	protected void OwnerUpd_btn_Click(object sender, EventArgs e)
	{
		try
		{

			string connectionString = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
			string MyUpd = "";
			SqlConnection con = new SqlConnection(connectionString);
			MyUpd = " Update [VetClinic].[dbo].[PetOwner] " +
					" Set [FirstName] = '" + Textbox1.Text + "'" +
					" ,[LastName] = '" + Textbox2.Text + "'" +
					" ,[Mobile_No] = '" + Textbox3.Text + "'" +
					" where Pet_OwnerID = '" + @Pet_OwnerID + "' ";
			con.Open();
			SqlCommand ApptUpd = new SqlCommand(MyUpd, con);
			ApptUpd.ExecuteNonQuery();
			con.Close();
			ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Owner details updated OK')", true);
			LoadGridData();

		}
		catch (Exception ex)
		{
			string message = "There was an error updating Owner data" + ex;
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