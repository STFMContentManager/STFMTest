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

public partial class GroupMenu : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "User Groups";

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

			ClassUserGroup oGrp = new ClassUserGroup();

			this.DdlGroups.DataSource = oGrp.ShowUserGroups();
			this.DdlGroups.DataTextField = "UserGroupName";
			this.DdlGroups.DataValueField = "UserGroupId";
			this.DdlGroups.DataBind();

			if (Request.QueryString["UserGroupId"] != null)
			{
				try
				{
					this.DdlGroups.SelectedValue = Request.QueryString["UserGroupId"].ToString();
				}

				catch (Exception)
				{
					//	Do nothing. This isn't an error. It just means that the requested
					//	GroupId isn't in the dropdown listbox.
				}
			}

			if (this.DdlGroups.Items.Count == 0)
			{
				this.BtnDeleteGroup.Enabled = false;
				this.BtnEditGroup.Enabled = false;
				this.DdlGroups.Enabled = false;
			}
		}
	}

	protected void BtnAddGroup_Click(object sender, EventArgs e)
	{
		//	Add Group.

		Response.Redirect("GroupEdit.aspx?UserGroupId=0", true);
	}

	protected void BtnDeleteGroup_Click(object sender, EventArgs e)
	{
		//	Delete Group.

		Response.Redirect(string.Format("GroupDelete.aspx?UserGroupId={0}", Convert.ToInt32(this.DdlGroups.SelectedValue)), true);
	}

	protected void BtnEditGroup_Click(object sender, EventArgs e)
	{
		//	Edit Group.

		Response.Redirect(string.Format("GroupEdit.aspx?UserGroupId={0}", Convert.ToInt32(this.DdlGroups.SelectedValue)), true);
	}

	protected void BtnAdminMenu_Click(object sender, EventArgs e)
	{
		//	Return to main menu.

		Response.Redirect("AdminMenu.aspx", true);
	}
}
