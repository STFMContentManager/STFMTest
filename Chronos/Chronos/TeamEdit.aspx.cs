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

public partial class TeamEdit : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Edit Team";

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

			if (Request.QueryString["TeamId"] == null)
				Response.Redirect("TeamMenu.aspx", true);

			ClassTeam oTm = new ClassTeam(Convert.ToInt32(Request.QueryString["TeamId"].ToString()));

			this.TxtTeamName.Text = oTm.TeamName;
			ViewState["TeamId"] = oTm.TeamId.ToString();
		}
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		//	Submit button.

		int TeamId = 0;

		try
		{
			ClassTeam oTm = new ClassTeam();

			oTm.TeamName = this.TxtTeamName.Text;
			TeamId = oTm.Save(Convert.ToInt32(ViewState["TeamId"].ToString()));
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		Response.Redirect(string.Format("TeamMenu.aspx?TeamId={0}", TeamId), true);
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("TeamMenu.aspx", true);
	}
}
