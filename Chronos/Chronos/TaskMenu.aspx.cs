//	---------------------------------------------------------------------------
//	$Filename: D:\Inetpub\wwwroot\TimeRep\TaskMenu.aspx.cs $
//	$Revision: 1.3 $
//	---------------------------------------------------------------------------
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

public partial class TaskMenu : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Tasks";

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
		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			Page.Title = TXT_PAGETITLE;
			this.LblPageTitle.Text = TXT_PAGETITLE;

			if (Request.QueryString["ProjectId"] == null)
				Response.Redirect("ProjectMenu.aspx", true);

			ViewState["ProjectId"] = Request.QueryString["ProjectId"].ToString();

			int ProjectId = (int) Convert.ToInt32(ViewState["ProjectId"].ToString());

			ClassProject oPrj = new ClassProject(ProjectId);
			ClassTask oTsk = new ClassTask();

			this.LblProject.Text = oPrj.ProjectName;

			this.DdlTasks.DataSource = oTsk.ShowTasksForProject(ProjectId, false);
			this.DdlTasks.DataTextField = "TaskName";
			this.DdlTasks.DataValueField = "TaskId";
			this.DdlTasks.DataBind();

			if (Request.QueryString["TaskId"] != null)
			{
				try
				{
					this.DdlTasks.SelectedValue = Request.QueryString["TaskId"].ToString();
				}

				catch (Exception)
				{
					//	Do nothing. This isn't an error. It just means that the requested
					//	TaskId isn't in the dropdown listbox.
				}
			}

			if (this.DdlTasks.Items.Count == 0)
			{
				this.BtnDeleteTask.Enabled = false;
				this.BtnEditTask.Enabled = false;
				this.DdlTasks.Enabled = false;
			}
		}
	}

	protected void BtnAddTask_Click(object sender, EventArgs e)
	{
		//	Add task.

		Response.Redirect(string.Format("TaskEdit.aspx?ProjectId={0}&TaskId=0", Convert.ToInt32(ViewState["ProjectId"].ToString())), true);
	}

	protected void BtnDeleteTask_Click(object sender, EventArgs e)
	{
		//	Delete task.

		Response.Redirect(string.Format("TaskDelete.aspx?ProjectId={0}&TaskId={1}", Convert.ToInt32(ViewState["ProjectId"].ToString()), Convert.ToInt32(this.DdlTasks.SelectedValue)), true);
	}

	protected void BtnEditTask_Click(object sender, EventArgs e)
	{
		//	Edit task.

		Response.Redirect(string.Format("TaskEdit.aspx?ProjectId={0}&TaskId={1}", Convert.ToInt32(ViewState["ProjectId"].ToString()), Convert.ToInt32(this.DdlTasks.SelectedValue)), true);
	}

	protected void BtnProjectEdit_Click(object sender, EventArgs e)
	{
		//	Return to ProjectEdit.aspx.

		Response.Redirect("ProjectEdit.aspx?ProjectId=" + ViewState["ProjectId"].ToString(), true);
	}
}
