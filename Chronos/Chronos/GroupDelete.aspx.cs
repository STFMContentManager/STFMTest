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

public partial class GroupDelete : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Delete User Group";

	protected void Page_PreInit(object sender, EventArgs e)
	{
		//	Get user ID and store in ViewState.

		ViewState["UserId"] = Page.User.Identity.Name.ToString();

		if (ViewState["UserId"].ToString() != "0")
		{
			//	Only super-admin is allowed to define user groups. All other
			//	users can't do this.

			Response.Redirect("Default.aspx", false);
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			Page.Title = TXT_PAGETITLE;
			this.LblPageTitle.Text = TXT_PAGETITLE;

			if (Request.QueryString["UserGroupId"] == null)
				Response.Redirect("UserGroupMenu.aspx", true);

			ViewState["UserGroupId"] = Request.QueryString["UserGroupId"].ToString();

			ClassUserGroup oGrp = new ClassUserGroup(Convert.ToInt32(ViewState["UserGroupId"].ToString()));

			this.LblMsg.Text = oGrp.UserGroupName;
		}
	}

	protected void BtnConfirm_Click(object sender, EventArgs e)
	{
		ClassUserGroup oGrp = new ClassUserGroup();

		oGrp.Delete(Convert.ToInt32(ViewState["UserGroupId"].ToString()));
		Response.Redirect("GroupMenu.aspx?UserGroupId=0", true);
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("GroupMenu.aspx?UserGroupId={0}", Convert.ToInt32(ViewState["UserGroupId"].ToString())), true);
	}
}
