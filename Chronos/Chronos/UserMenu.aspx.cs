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

public partial class UserMenu : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Users";

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

			ClassUser oUsr = new ClassUser();

			this.BtnAddUser.Enabled = true;
			this.BtnDeleteUser.Enabled = false;
			this.BtnEditUser.Enabled = false;

			this.DdlUsers.DataSource = oUsr.ShowUsers();
			this.DdlUsers.DataTextField = "UserName";
			this.DdlUsers.DataValueField = "UserId";
			this.DdlUsers.DataBind();

			if (this.DdlUsers.Items.Count > 0)
			{
				int UsrId;

				if (Request.QueryString["UserId"] != null)
					UsrId = Convert.ToInt32(Request.QueryString["UserId"]);
				else
					UsrId = 0;

				try
				{
					this.DdlUsers.SelectedValue = UsrId.ToString();
				}

				catch (Exception)
				{
					//	Okay to error here. It just means that the user ID doesn't
					//	exist in the dropdown listbox.
				}

				this.BtnDeleteUser.Enabled = true;
				this.BtnEditUser.Enabled = true;
			}
		}
	}

	protected void BtnAddUser_Click(object sender, EventArgs e)
	{
		Response.Redirect("UserEdit.aspx?UserId=0", true);
	}

	protected void BtnEditUser_Click(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("UserEdit.aspx?UserId={0}", this.DdlUsers.SelectedValue), true);
	}

	protected void BtnDeleteUser_Click(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("UserDelete.aspx?UserId={0}", this.DdlUsers.SelectedValue), true);
	}

	protected void BtnAdminMenu_Click(object sender, EventArgs e)
	{
		//	Return to main menu.

		Response.Redirect("AdminMenu.aspx", true);
	}
}
