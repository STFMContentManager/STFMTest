//	---------------------------------------------------------------------------
//	$Filename: D:\Inetpub\wwwroot\TimeRep\Default.aspx.cs $
//	$Revision: 1.6 $
//	---------------------------------------------------------------------------
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
using System.Text.RegularExpressions;

public partial class _Default : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Welcome";

	protected void Page_PreInit(object sender, EventArgs e)
	{
		//	Get user ID and store in ViewState.

		ViewState["UserId"] = Page.User.Identity.Name.ToString();

		if (ViewState["UserId"].ToString() == "0")
		{
			//	Super Admin.

			ViewState["UserName"] = "Administrator";
		}
		else
		{
			ClassUser oUsr = new ClassUser(Convert.ToInt32(ViewState["UserId"].ToString()));

			if (Util.ReadString("PasswordRegExp", "").Length > 0)
			{
				//	User has to supply a password which meets a regular expression check.

				Regex oReg = new Regex(Util.ReadString("PasswordRegExp", ""));

				if (oReg.IsMatch(oUsr.Password) == false)
				{
					//	Users password does not meet the regular expression
					//	check that the system admin defined in web.config.
					//	Send the user to the user admin page to force them
					//	to change their password.

					//Response.Redirect("UserAdmin.aspx", true);
				}

				ViewState["UserName"] = string.Format("{0} {1}", oUsr.Forename, oUsr.Surname);
			}
		}
	}

    protected void Page_Load(object sender, EventArgs e)
    {
		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			Page.Title = TXT_PAGETITLE;
			this.LblPageTitle.Text = string.Format("{0} {1}", TXT_PAGETITLE, ViewState["UserName"].ToString());

			this.LblCompanyName.Text = Util.AttributeLoad("CompanyName", "Society of Teachers of Family Medicine");
			this.LblVersion.Text = string.Format("Version: {0}", Util.VersionNo());

			DoEnable();
		}
    }

	private void DoEnable()
	{
		if (ViewState["UserId"].ToString() == "0")
		{
			//	Super admin has access to everything except user administration.

			this.RowUserAdmin1.Visible = false;
			this.RowUserAdmin2.Visible = false;
		}
		else
		{
			// Other users are configured according to their user group permissions.

			ClassUser oUsr = new ClassUser(Convert.ToInt32(ViewState["UserId"].ToString()));

			if ((oUsr.Permissions & (Int32)Enum.Permissions.Administration) == 0)
			{
				this.RowConfig1.Visible = false;
				this.RowConfig2.Visible = false;
				this.BtnConfig.Enabled = false;

				this.RowAdmin1.Visible = false;
				this.RowAdmin2.Visible = false;
				this.BtnAdminMenu.Enabled = false;
			}

			if ((oUsr.Permissions & (Int32)Enum.Permissions.Timesheet) == 0)
			{
				this.RowTime1.Visible = false;
				this.RowTime2.Visible = false;
				this.BtnTime.Enabled = false;
			}

			if ((oUsr.Permissions & (Int32)Enum.Permissions.Report) == 0)
			{
				this.RowReports1.Visible = false;
				this.RowReports2.Visible = false;
				this.BtnReports.Enabled = false;
			}
		}
	}

	protected void BtnConfig_Click(object sender, EventArgs e)
	{
		Response.Redirect("Configuration.aspx", true);
	}

	protected void BtnAdmin_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminMenu.aspx", true);
	}

	protected void BtnTime_Click(object sender, EventArgs e)
	{
		Response.Redirect("TimeEntry.aspx", true);
	}

	protected void BtnReports_Click(object sender, EventArgs e)
	{
		Response.Redirect("ReportMenu.aspx", true);
	}

	protected void BtnUserAdmin_Click(object sender, EventArgs e)
	{
		Response.Redirect("UserAdmin.aspx", true);
	}

	protected void BtnAbout_Click(object sender, EventArgs e)
	{
		Response.Redirect("About.aspx", true);
	}

	protected void BtnContact_Click(object sender, EventArgs e)
	{
		Response.Redirect("Contact.aspx", true);
	}

	protected void BtnLogoff_Click(object sender, EventArgs e)
	{
		//	Log off.

		FormsAuthentication.SignOut();
		Response.Redirect("Default.aspx", true);
	}
}
