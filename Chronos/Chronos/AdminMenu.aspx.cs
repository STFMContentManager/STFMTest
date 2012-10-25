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

public partial class AdminMenu : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Administration";

	protected void Page_PreInit(object sender, EventArgs e)
	{
		//	Get user ID and store in ViewState.

		ViewState["UserId"] = Page.User.Identity.Name.ToString();

		if (ViewState["UserId"].ToString() != "0")
		{
			ClassUser oUsr = new ClassUser(Convert.ToInt32(Page.User.Identity.Name.ToString()));

			if ((oUsr.Permissions & (Int32)Enum.Permissions.Administration) == 0)
			{
				//	User isn't allowed to do configuration.

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

			DoEnable();
		}
	}

	private void DoEnable()
	{
		if (ViewState["UserId"].ToString() == "0")
		{
			//	Super admin has access to everything.
		}
		else
		{
			// Other users are configured according to their user group permissions.

			ClassUser oUsr = new ClassUser(Convert.ToInt32(ViewState["UserId"].ToString()));

			this.BtnGroups.Enabled = false;
			this.BtnStatus.Enabled = false;

			if ((oUsr.Permissions & (Int32)Enum.Permissions.Project) == 0)
				this.BtnProjectAdmin.Enabled = false;

			if ((oUsr.Permissions & (Int32)Enum.Permissions.Team) == 0)
				this.BtnTeams.Enabled = false;

			if ((oUsr.Permissions & (Int32)Enum.Permissions.JobMaintenance) == 0)
				this.BtnJobs.Enabled = false;

			if ((oUsr.Permissions & (Int32)Enum.Permissions.Lock) == 0)
				this.BtnAdminLock.Enabled = false;
		}
	}

	protected void BtnGroupAdmin_Click(object sender, EventArgs e)
	{
		//	User group admin.

		Response.Redirect("GroupMenu.aspx", true);
	}

	protected void BtnTeamAdmin_Click(object sender, EventArgs e)
	{
		//	Team administration.

		Response.Redirect("TeamMenu.aspx", true);
	}

	protected void BtnUserAdmin_Click(object sender, EventArgs e)
	{
		Response.Redirect("UserMenu.aspx", true);
	}

	protected void BtnProjectAdmin_Click(object sender, EventArgs e)
	{
		//	Project administration.

		Response.Redirect("ProjectMenu.aspx", true);
	}

	protected void BtnJobs_Click(object sender, EventArgs e)
	{
		Session["Referer"] = Request.Url.ToString();
		Response.Redirect("JobMaintenance.aspx", true);
	}

	protected void BtnStatusAdmin_Click(object sender, EventArgs e)
	{
		//	Status administration.

		Response.Redirect("StatusMenu.aspx", true);
	}

	protected void BtnAdminLock_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminLock.aspx", true);
	}

	protected void BtnMainMenu_Click(object sender, EventArgs e)
	{
		Response.Redirect("Default.aspx", true);
	}
}
