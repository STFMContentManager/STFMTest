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

public partial class ProjectMenu : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Projects";

	protected void Page_PreInit(object sender, EventArgs e)
	{
		//	Get user ID and store in ViewState.

		ViewState["UserId"] = Page.User.Identity.Name.ToString();

		if (ViewState["UserId"].ToString() != "0")
		{
			ClassUser oUsr = new ClassUser(Convert.ToInt32(Page.User.Identity.Name.ToString()));

			if ((oUsr.Permissions & (Int32)Enum.Permissions.Project) == 0)
			{
				//	User isn't allowed to do projects.

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

			ClassProject oPrj = new ClassProject();

			this.ddlProjects.DataSource = oPrj.ShowProjects();
			this.ddlProjects.DataTextField = "ProjectName";
			this.ddlProjects.DataValueField = "ProjectId";
			this.ddlProjects.DataBind();

			this.BtnAddProject.Enabled = true;

			if (this.ddlProjects.Items.Count > 0)
			{
				this.ddlProjects.Enabled = true;
				this.BtnDeleteProject.Enabled = true;
				this.BtnEditProject.Enabled = true;

				if (Request.QueryString["ProjectId"] != null)
				{
					try
					{
						this.ddlProjects.SelectedValue = Request.QueryString["ProjectId"].ToString();
					}

					catch (Exception)
					{
						//	Do nothing. The project ID doesn't exist in the dropdown listbox.
						//	This isn't an error.
					}
				}
			}
			else
			{
				this.ddlProjects.Enabled = false;
				this.BtnDeleteProject.Enabled = false;
				this.BtnEditProject.Enabled = false;
			}
		}
	}

	protected void BtnAddProject_Click(object sender, EventArgs e)
	{
		Response.Redirect("ProjectEdit.aspx?ProjectId=0", true);
	}

	protected void BtnDeleteProject_Click(object sender, EventArgs e)
	{
		Response.Redirect("ProjectDelete.aspx?ProjectId=" + this.ddlProjects.SelectedValue, true);
	}

	protected void BtnEditProject_Click(object sender, EventArgs e)
	{
		Response.Redirect("ProjectEdit.aspx?ProjectId=" + this.ddlProjects.SelectedValue, true);
	}

	protected void BtnAdminMenu_Click(object sender, EventArgs e)
	{
		//	Return to admin menu.

		Response.Redirect("AdminMenu.aspx", true);
	}
}
