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

public partial class GroupEdit : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Edit User Group";

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
				Response.Redirect("GroupMenu.aspx", true);

			ClassUserGroup oGrp = new ClassUserGroup(Convert.ToInt32(Request.QueryString["UserGroupId"].ToString()));

			this.TxtGroupName.Text = oGrp.UserGroupName;

			if ((oGrp.UserGroupPermissions & (Int32)Enum.Permissions.Administration) != 0)
				this.ChkAdmin.Checked = true;
			else
				this.ChkAdmin.Checked = false;

			if ((oGrp.UserGroupPermissions & (Int32) Enum.Permissions.Project) != 0)
				this.ChkProjects.Checked = true;
			else
				this.ChkProjects.Checked = false;

			if ((oGrp.UserGroupPermissions & (Int32)Enum.Permissions.Report) != 0)
				this.ChkReports.Checked = true;
			else
				this.ChkReports.Checked = false;

			if ((oGrp.UserGroupPermissions & (Int32)Enum.Permissions.Team) != 0)
				this.ChkUsers.Checked = true;
			else
				this.ChkUsers.Checked = false;

			if ((oGrp.UserGroupPermissions & (Int32)Enum.Permissions.Lock) != 0)
				this.ChkLocks.Checked = true;
			else
				this.ChkLocks.Checked = false;

			if ((oGrp.UserGroupPermissions & (Int32)Enum.Permissions.Timesheet) != 0)
				this.ChkTimesheet.Checked = true;
			else
				this.ChkTimesheet.Checked = false;

			if ((oGrp.UserGroupPermissions & (Int32)Enum.Permissions.JobMaintenance) != 0)
				this.ChkJobAdmin.Checked = true;
			else
				this.ChkJobAdmin.Checked = false;

			if ((oGrp.UserGroupPermissions & (Int32)Enum.Permissions.ManagerOnly) != 0)
				this.ChkManager.Checked = true;
			else
				this.ChkManager.Checked = false;

			ViewState["UserGroupId"] = oGrp.UserGroupId.ToString();
		}
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		//	Submit button.

		int GroupId = 0;

		try
		{
			ClassUserGroup oGrp = new ClassUserGroup();

			oGrp.UserGroupName = this.TxtGroupName.Text;
			oGrp.UserGroupPermissions = 0;

			if (this.ChkAdmin.Checked)
				oGrp.UserGroupPermissions += (Int32)Enum.Permissions.Administration;

			if (this.ChkProjects.Checked)
				oGrp.UserGroupPermissions += (Int32)Enum.Permissions.Project;

			if (this.ChkReports.Checked)
				oGrp.UserGroupPermissions += (Int32)Enum.Permissions.Report;

			if (this.ChkUsers.Checked)
				oGrp.UserGroupPermissions += (Int32)Enum.Permissions.Team;

			if (this.ChkLocks.Checked)
				oGrp.UserGroupPermissions += (Int32)Enum.Permissions.Lock;

			if (this.ChkTimesheet.Checked)
				oGrp.UserGroupPermissions += (Int32)Enum.Permissions.Timesheet;

			if (this.ChkJobAdmin.Checked)
				oGrp.UserGroupPermissions += (Int32)Enum.Permissions.JobMaintenance;

			if (this.ChkManager.Checked)
				oGrp.UserGroupPermissions += (Int32)Enum.Permissions.ManagerOnly;

			GroupId = oGrp.Save(Convert.ToInt32(ViewState["UserGroupId"].ToString()));
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		Response.Redirect(string.Format("GroupMenu.aspx?UserGroupId={0}", GroupId), true);
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("GroupMenu.aspx?UserGroupId={0}", ViewState["UserGroupId"].ToString()), true);
	}
}
