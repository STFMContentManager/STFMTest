//	---------------------------------------------------------------------------
//	$Filename: D:\Inetpub\wwwroot\TimeRep\JobMaintenance.aspx.cs $
//	$Revision: 1.6 $
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
using System.Text;

public partial class JobMaintenance : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Job Maintenance";

	#region Page events
	protected void Page_PreInit(object sender, EventArgs e)
	{
		//	Get user ID and store in ViewState.

		ViewState["UserId"] = Page.User.Identity.Name.ToString();

		if (ViewState["UserId"].ToString() != "0")
		{
			ClassUser oUsr = new ClassUser(Convert.ToInt32(Page.User.Identity.Name.ToString()));

			if ((oUsr.Permissions & (Int32)Enum.Permissions.JobMaintenance) == 0)
			{
				//	User isn't allowed to do job maintenance.

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

			//	We can arrive on this page from a couple of different places
			//	on the web site. The calling page should have set its URL in
			//	the Session["Referer"] object. We grab that URL and save it
			//	in viewstate - that way it doesn't time out.

			ViewState["Referer"] = Session["Referer"].ToString();

			ShowProjects();

			ShowJobs(0);
			ShowJob(0);
			ViewState["JobId"] = "0";
		}
	}
	#endregion

	#region Button events
	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		ClassJob oJob = new ClassJob(Convert.ToInt32(ViewState["JobId"].ToString()));
		double HoursVal;

		if (double.TryParse(this.TxtBudgetHours.Text, out HoursVal) != true)
		{
			//	Problem with the hours figure.

			ShowTimeError("Hours are incorrectly specified!");
		}
		else
		{
			oJob.TaskId = Convert.ToInt32(this.DdlTasks.SelectedValue);
			oJob.JobRef = this.TxtJobRef.Text;
			oJob.Description = this.TxtDescription.Text;
			oJob.BudgetHours = Convert.ToDouble(this.TxtBudgetHours.Text);
			oJob.Active = this.ChkActive.Checked;
			oJob.Save(Convert.ToInt32(ViewState["JobId"].ToString()));

			ShowJobs(0);
			ShowJob(0);
			ViewState["JobId"] = "0";
			this.BtnSubmit.Text = "Submit";
		}
	}

	protected void BtnReturn_Click(object sender, EventArgs e)
	{
		BtnUpdateActive_Click(sender, e);
		Response.Redirect(ViewState["Referer"].ToString(), true);
	}
	#endregion

	protected Boolean IsTrue(string BoolStr)
	{
		if (BoolStr == "1")
			return true;
		else
			return false;
	}

	private void ShowProjects()
	{
		this.ddlProjects.Items.Clear();
		this.DdlTasks.Items.Clear();

		this.ddlProjects.Enabled = false;
		this.DdlTasks.Enabled = false;

		ClassProject oPrj = new ClassProject();
		DataSet oDs = oPrj.ShowProjects();

		if (oDs != null)
		{
			if (oDs.Tables.Count > 0)
			{
				if (oDs.Tables[0].Rows.Count > 0)
				{
					//	We have some projects.

					this.ddlProjects.Enabled = true;

					this.ddlProjects.DataSource = oDs;
					this.ddlProjects.DataTextField = "ProjectName";
					this.ddlProjects.DataValueField = "ProjectId";
					this.ddlProjects.DataBind();

					ShowTasks();
				}
			}
		}
	}

	private void ShowTasks()
	{
		this.DdlTasks.Enabled = false;

		if (this.ddlProjects.Items.Count > 0)
		{
			ClassTask oTsk = new ClassTask();
			DataSet oDs = oTsk.ShowTasksForProject(Convert.ToInt32(this.ddlProjects.SelectedValue), true);

			if (oDs != null)
			{
				if (oDs.Tables.Count > 0)
				{
					if (oDs.Tables[0].Rows.Count > 0)
					{
						//	We have some tasks.

						this.DdlTasks.Enabled = true;

						this.DdlTasks.DataSource = oDs;
						this.DdlTasks.DataTextField = "TaskName";
						this.DdlTasks.DataValueField = "TaskId";
						this.DdlTasks.DataBind();

						ShowJobs(0);
					}
				}
			}
		}
	}

	private void ShowJobs(Int32 PageNo)
	{
		this.GridJob.DataSource = null;

		if (this.DdlTasks.Items.Count > 0)
		{
			ClassJob oJob = new ClassJob();
			DataSet oDs = oJob.ShowJobsForTask(Convert.ToInt32(this.DdlTasks.SelectedValue), false);

			if (oDs != null)
			{
				if (oDs.Tables.Count > 0)
				{
					if (oDs.Tables[0].Rows.Count > 0)
					{
						this.GridJob.DataSource = oDs;

						if (this.GridJob.Rows.Count > 0)
							this.GridJob.PageIndex = PageNo;

						this.GridJob.DataBind();
					}
				}
			}
		}
	}

	private void ShowJob(Int32 JbId)
	{
		ShowTimeError("");

		ClassJob oJob = new ClassJob(JbId);

		this.TxtJobRef.Text = oJob.JobRef;
		this.TxtDescription.Text = oJob.Description;
		this.TxtBudgetHours.Text = string.Format("{0:f2}", oJob.BudgetHours);
		this.ChkActive.Checked = (oJob.Active == true);
	}

	private void ShowTimeError(string Msg)
	{
		if (Msg.Length == 0)
		{
			this.RowTimeError.Visible = false;
		}
		else
		{
			this.RowTimeError.Visible = true;
			this.LblTimeError.Text = Msg;
		}
	}

	protected void ddlProjects_Change(object sender, System.EventArgs e)
	{
		BtnUpdateActive_Click(sender, e);
		ShowTasks();
	}

	protected void DdlTasks_Change(object sender, System.EventArgs e)
	{
		BtnUpdateActive_Click(sender, e);
		ShowJobs(0);
	}

	protected void BtnUpdateActive_Click(object sender, System.EventArgs e)
	{
		for (Int32 RowNo = 0; RowNo < this.GridJob.Rows.Count; RowNo++)
		{
			GridViewRow oRow = this.GridJob.Rows[RowNo];
			Label oLbl = (Label)oRow.FindControl("LblJobId");

			if (oLbl != null)
			{
				CheckBox oChk = (CheckBox)oRow.FindControl("ChkActive");

				if (oChk != null)
				{
					ClassJob oJob = new ClassJob(Convert.ToInt32(oLbl.Text));

					oJob.Active = oChk.Checked;
					oJob.Save(oJob.JobId);
				}
			}
		}
	}

	#region GridJob Events
	protected void GridJob_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			ImageButton oBtn = (ImageButton)e.Row.FindControl("ImgTrash");

			if (oBtn != null)
			{
				oBtn.Attributes.Add("onclick",
					"javascript:return confirm('Are you sure you want to delete this job?')");
			}
		}
	}

	protected void GridJob_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		switch (e.CommandName)
		{
			case "Delete":
				ClassJob oJob = new ClassJob();

				oJob.Delete(Convert.ToInt32(e.CommandArgument));
				ShowJobs(0);
				break;

			case "Edit":
				ViewState["JobId"] = Convert.ToInt32(e.CommandArgument).ToString();
				ShowJob(Convert.ToInt32(e.CommandArgument));
				this.BtnSubmit.Text = "Update";
				break;
		}
	}

	protected void GridJob_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		//	RowDeleted....
	}

	protected void GridJob_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		//	RowDeleting....
	}

	protected void GridJob_RowEditing(object sender, GridViewEditEventArgs e)
	{
		//	RowEditing....
	}

	protected void GridJob_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		BtnUpdateActive_Click(sender, e);
		ShowJobs(e.NewPageIndex);
	}
	#endregion
}
