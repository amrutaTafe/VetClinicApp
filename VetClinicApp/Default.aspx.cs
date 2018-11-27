using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		
	}

	protected void LogonBtn_Click(object sender, EventArgs e)
	{
		int count; count = 0;
		try
		{

			string str_connection = "Data Source = DESKTOP-DE1TOR3; Initial Catalog = VetClinic; Integrated Security = True";
			string sql = "SELECT count([Email])FROM[VetClinic].[dbo].[Vet]" +
						 " where[Email] = '" + TextBox1.Text + "' and [Password] = '" + TextBox2.Text + "' ;" ;

			using (var connection = new SqlConnection(str_connection))
			using (var Command = new SqlCommand(sql, connection))
			{
				connection.Open();
				using (var reader = Command.ExecuteReader())
				{
					if (reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
		}
		catch (Exception ex)
		{
			string logonmessage = "There was a problem with logging on - Contact Admin" + ex;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("<script type = 'text/javascript'>");
			sb.Append("window.onload=function(){");
			sb.Append("alert('");
			sb.Append(logonmessage);
			sb.Append("')};");
			sb.Append("</script>");
			ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
		}

		{
			string message = "";
			if (count == 1)
			{
				message = "Login successful";
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				sb.Append("<script type = 'text/javascript'>");
				sb.Append("window.onload=function(){");
				sb.Append("alert('");
				sb.Append(message);
				sb.Append("')};");
				sb.Append("</script>");
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
				Session["VetMailId"] = TextBox1.Text;
				//checked to see if its the business owner
				if (TextBox1.Text == "admin@gmail.com")
				{
					Response.Redirect("OwnerPage.aspx");
				}
				else
				{
					Response.Redirect("VetPage.aspx");
				}
				
				Response.Redirect("VetPage.aspx");
			}
			else
			{
				message = "Login Unsuccessful";
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
}