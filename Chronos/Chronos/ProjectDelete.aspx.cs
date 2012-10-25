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

public partial class ProjectDelete : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Delete Project";

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

			if (Request.QueryString["ProjectId"] == null)
				Response.Redirect("ProjectMenu.aspx", true);

			ViewState["ProjectId"] = Request.QueryString["ProjectId"].ToString();

			ClassProject oPrj = new ClassProject(Convert.ToInt32(ViewState["ProjectId"].ToString()));

			this.LblMsg.Text = string.Format("Confirm delete project <b>{0}</b>", oPrj.ProjectName);
		}
	}

	protected void BtnConfirm_Click(object sender, EventArgs e)
	{
		ClassProject oPrj = new ClassProject();

		oPrj.Delete(Convert.ToInt32(ViewState["ProjectId"].ToString()));
		Response.Redirect("ProjectMenu.aspx", true);
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("ProjectMenu.aspx", true);
	}
}
