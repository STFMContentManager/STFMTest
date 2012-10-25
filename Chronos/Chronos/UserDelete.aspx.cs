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

public partial class UserDelete : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Delete User";

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

			if (Request.QueryString["UserId"] == null)
				Response.Redirect("UserMenu.aspx", true);

			ViewState["UserId"] = Request.QueryString["UserId"].ToString();

			ClassUser oUsr = new ClassUser(Convert.ToInt32(ViewState["UserId"].ToString()));

			this.LblMsg.Text = oUsr.UserName;
		}
	}

	protected void BtnConfirm_Click(object sender, EventArgs e)
	{
		ClassUser oUsr = new ClassUser();

		oUsr.Delete(Convert.ToInt32(ViewState["UserId"].ToString()));

		Response.Redirect("UserMenu.aspx", true);
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("UserMenu.aspx", true);
	}
}
