using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Diagnostics;

public partial class TeamMenu : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Teams";

	protected void Page_PreInit(object sender, EventArgs e)
	{
		//	Get user ID and store in ViewState.

		ViewState["UserId"] = Page.User.Identity.Name.ToString();

		if (ViewState["UserId"].ToString() != "0")
		{
			ClassUser oUsr = new ClassUser(Convert.ToInt32(Page.User.Identity.Name.ToString()));

			if ((oUsr.Permissions & (Int32)Enum.Permissions.Team) == 0)
			{
				//	User isn't allowed to do team management.

				Response.Redirect("Default.aspx", false);
			}
		}
	}

	protected void Page_Load(object sender, EventArgs e)
    {
		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			Page.Title = TXT_PAGETITLE;
			this.LblPageTitle.Text = TXT_PAGETITLE;

			ClassTeam oTm = new ClassTeam();

			this.BtnAddTeam.Enabled = true;
			this.BtnDeleteTeam.Enabled = false;
			this.BtnEditTeam.Enabled = false;
			this.DdlTeams.Enabled = false;

			this.DdlTeams.DataSource = oTm.ShowTeams1();
			this.DdlTeams.DataTextField = "TeamName";
			this.DdlTeams.DataValueField = "TeamId";
			this.DdlTeams.DataBind();

			if (this.DdlTeams.Items.Count > 0)
			{
				int UsrId;

				if (Request.QueryString["TeamId"] != null)
					UsrId = Convert.ToInt32(Request.QueryString["TeamId"]);
				else
					UsrId = 0;

				try
				{
					this.DdlTeams.SelectedValue = UsrId.ToString();
				}

				catch (Exception)
				{
					//	Okay to error here. It just means that the Team ID doesn't
					//	exist in the dropdown listbox.
				}

				this.BtnDeleteTeam.Enabled = true;
				this.BtnEditTeam.Enabled = true;
				this.DdlTeams.Enabled = true;
			}
		}
	}

	protected void BtnAddTeam_Click(object sender, EventArgs e)
	{
		Response.Redirect("TeamEdit.aspx?TeamId=0", true);
	}

	protected void BtnEditTeam_Click(object sender, EventArgs e)
	{
		Response.Redirect("TeamEdit.aspx?TeamId=" + this.DdlTeams.SelectedValue, true);
	}

	protected void BtnDeleteTeam_Click(object sender, EventArgs e)
	{
		Response.Redirect("TeamDelete.aspx?TeamId=" + this.DdlTeams.SelectedValue, true);
	}

	protected void BtnAdminMenu_Click(object sender, EventArgs e)
	{
		//	Return to main menu.

		Response.Redirect("AdminMenu.aspx", true);
	}
}
