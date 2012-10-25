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

public partial class TaskEdit : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Edit Task";

	protected void Page_PreInit(object sender, EventArgs e)
	{
		//	Get user ID and store in ViewState.

		ViewState["UserId"] = Page.User.Identity.Name.ToString();

		if (ViewState["UserId"].ToString() != "0")
		{
			ClassUser oUsr = new ClassUser(Convert.ToInt32(Page.User.Identity.Name.ToString()));

			if ((oUsr.Permissions & (Int32)Enum.Permissions.Timesheet) == 0)
			{
				//	User isn't allowed to do timesheets.

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

			if (Request.QueryString["TaskId"] == null)
				Response.Redirect("TaskMenu.aspx?ProjectId=" + Request.QueryString["ProjectId"].ToString(), true);

			ViewState["ProjectId"] = Request.QueryString["ProjectId"].ToString();
			ViewState["TaskId"] = Request.QueryString["TaskId"].ToString();

			int ProjectId = Convert.ToInt32(ViewState["ProjectId"].ToString());
			int TaskId = Convert.ToInt32(ViewState["TaskId"].ToString());

			ClassProject oPrj = new ClassProject(ProjectId);
			ClassTask oTsk = new ClassTask(TaskId);

			this.LblProject.Text = oPrj.ProjectName;
			this.TxtTaskName.Text = oTsk.TaskName;
			this.TxtCostCentre.Text = oTsk.CostCentre;
			this.DdlProductive.SelectedValue = (oTsk.IsProductive == true) ? "1" : "0";
			this.DdlActive.SelectedValue = (oTsk.Active == true) ? "1" : "0";
			this.TxtReferenceRegEx.Text = oTsk.ReferenceRegEx;
			this.TxtDescription.Text = oTsk.Description;
			this.DdlValidationType.SelectedValue = oTsk.ValidationType.ToString();

			this.TxtTaskName.Focus();
		}
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		//	Submit button.

		int TaskId = Convert.ToInt32(ViewState["TaskId"].ToString());

		try
		{
			ClassTask oTsk = new ClassTask();
			oTsk.ProjectId = Convert.ToInt32(ViewState["ProjectId"].ToString());
			oTsk.TaskName = this.TxtTaskName.Text;
			oTsk.CostCentre = this.TxtCostCentre.Text;
			oTsk.IsProductive = (this.DdlProductive.SelectedValue == "0") ? false : true;
			oTsk.Active = (this.DdlActive.SelectedValue == "0") ? false : true;
			oTsk.ReferenceRegEx = this.TxtReferenceRegEx.Text;
			oTsk.Description = this.TxtDescription.Text;
			oTsk.ValidationType = Convert.ToInt16(this.DdlValidationType.SelectedValue);
			TaskId = oTsk.Save(TaskId);
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		Response.Redirect(string.Format("TaskMenu.aspx?ProjectId={0}&TaskId={1}", Convert.ToInt32(ViewState["ProjectId"].ToString()), TaskId), true);
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("TaskMenu.aspx?ProjectId={0}&TaskId={1}", Convert.ToInt32(ViewState["ProjectId"].ToString()), Convert.ToInt32(ViewState["TaskId"].ToString())), true);
	}
}
