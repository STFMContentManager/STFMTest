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

public partial class ProjectEdit : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Edit Project";

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
		Page.Title = TXT_PAGETITLE;
		this.LblPageTitle.Text = TXT_PAGETITLE;

		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			if (Request.QueryString["ProjectId"] == null)
				Response.Redirect("ProjectMenu.aspx", true);

			ClassProject oPrj = new ClassProject(Convert.ToInt32(Request.QueryString["ProjectId"].ToString()));

			this.TxtProjectName.Text = oPrj.ProjectName;
			this.TxtCostCentre.Text = oPrj.CostCentre;

			ViewState["ProjectId"] = oPrj.ProjectId.ToString();

			if (oPrj.ProjectId == 0)
			{
				//	User cannot edit tasks unless the project has been created.

				this.BtnTaskAdmin.Enabled = false;
			}

			this.TxtProjectName.Focus();
		}
	}

	protected void BtnTaskAdmin_Click(object sender, EventArgs e)
	{
		//	Task administration.

		Response.Redirect("TaskMenu.aspx?ProjectId=" + ViewState["ProjectId"].ToString(), true);
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		//	Submit button.

		int ProjectId = 0;

		try
		{
			ClassProject oPrj = new ClassProject();

			oPrj.ProjectName = this.TxtProjectName.Text;
			oPrj.CostCentre = this.TxtCostCentre.Text;
			ProjectId = oPrj.Save(Convert.ToInt32(ViewState["ProjectId"].ToString()));
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		Response.Redirect(string.Format("ProjectMenu.aspx?ProjectId={0}", ProjectId), true);
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("ProjectMenu.aspx", true);
	}
}
