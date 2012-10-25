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

public partial class TaskDelete : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Delete Task";

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

			if (Request.QueryString["TaskId"] == null)
				Response.Redirect("TaskMenu.aspx", true);

			ViewState["ProjectId"] = Request.QueryString["ProjectId"].ToString();
			ViewState["TaskId"] = Request.QueryString["TaskId"].ToString();

			ClassTask oCat = new ClassTask(Convert.ToInt32(ViewState["TaskId"].ToString()));

			this.LblMsg.Text = oCat.TaskName;
		}
	}

	protected void BtnConfirm_Click(object sender, EventArgs e)
	{
		ClassTask oTsk = new ClassTask();

		oTsk.Delete(Convert.ToInt32(ViewState["TaskId"].ToString()));

		Response.Redirect(string.Format("TaskMenu.aspx?ProjectId={0}&TaskId=0", Convert.ToInt32(ViewState["ProjectId"].ToString())), true);
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("TaskMenu.aspx?ProjectId={0}&TaskId={1}", Convert.ToInt32(ViewState["ProjectId"].ToString()), Convert.ToInt32(ViewState["TaskId"].ToString())), true);
	}
}
