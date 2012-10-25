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

public partial class TimeEntry : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Time Entry";

    protected void CalculateTime(object sender, EventArgs e)
    {
        CalculateHours();
        CalculateMinutes();
    }

    protected void CalculateLunchTime(object sender, EventArgs e)
    {
        CalculateLunchTime();
    }

    private void CalculateHours()
    {
        int iTimeInHour = Convert.ToInt32(ddlTimeInHours.SelectedItem.Text);
        int iTimeOutHour = Convert.ToInt32(ddlTimeOutHours.SelectedItem.Text);

        string sTimeInAMPM = ddlTimeInAMPM.SelectedItem.Text;
        string sTimeOutAMPM = ddlTimeOutAMPM.SelectedItem.Text;

        decimal Total = 0;

        if (iTimeInHour > iTimeOutHour)
        {
            if (sTimeInAMPM == sTimeOutAMPM)
            {
                Total = (iTimeOutHour + 24) - iTimeInHour;
                txtTotalHours.Text = Total.ToString();
            }
            else
            {
                Total = (iTimeOutHour + 12) - iTimeInHour;
                txtTotalHours.Text = Total.ToString();
            }
        }
        else if (iTimeInHour < iTimeOutHour)
        {
            if (sTimeInAMPM == sTimeOutAMPM)
            {
                Total = iTimeOutHour - iTimeInHour;
                txtTotalHours.Text = Total.ToString();
            }
            else
            {
                Total = (iTimeOutHour + 12) - iTimeInHour;
                txtTotalHours.Text = Total.ToString();
            }
        }
        else if (iTimeInHour == iTimeOutHour)
        {
            if (sTimeInAMPM == sTimeOutAMPM)
            {
                txtTotalHours.Text = "24";
            }
            else
            {
                txtTotalHours.Text = "12";
            }
        }

    }

    private void CalculateMinutes()
    {
        int iTimeInMinutes = Convert.ToInt32(ddlTimeInMinutes.SelectedItem.Value);
        int iTimeOutMinutes = Convert.ToInt32(ddlTimeOutMinutes.SelectedItem.Value);

        double Total = Convert.ToDouble(txtTotalHours.Text);
        double TotalMinutes = 0;

        if (iTimeInMinutes > iTimeOutMinutes)
        {
            TotalMinutes = iTimeInMinutes - iTimeOutMinutes;
            txtTotalHours.Text = Convert.ToString(Total - (TotalMinutes * .01));
        }
        else
        {
            TotalMinutes = iTimeOutMinutes - iTimeInMinutes;
            txtTotalHours.Text = Convert.ToString(Total + TotalMinutes * .01);
        }
    }

    private void CalculateLunchTime()
    {
        CalculateHours();
        CalculateMinutes();

        int iHour = Convert.ToInt32(ddlLunchHours.SelectedItem.Text);
        int iMinutes = Convert.ToInt32(ddlLunchMinutes.SelectedItem.Value);

        decimal dLunchTime;
        
        if (iMinutes > 0)
        {
            dLunchTime = Convert.ToDecimal((iHour.ToString() + "." + iMinutes.ToString()));
        }
        else
        {
            dLunchTime = iHour;
        }

        dLunchTime = Convert.ToDecimal(txtTotalHours.Text.ToString()) - dLunchTime;
        txtTotalHours.Text = dLunchTime.ToString();
    }

	#region Page events
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

			ViewState["TimeId"] = "0";
			ViewState["Interval"] = "W";
			ViewState["TotalHours"] = "0";

			ShowProjects();
			ShowStatus();
			CheckReady();

			this.LblTimeId.Text = "New";
			this.BtnSubmit.Text = "Submit";

			ViewState["GridPage"] = "20";

			ClassUser oUsr = new ClassUser(Convert.ToInt32(ViewState["UserId"].ToString()));

			if ((oUsr.Permissions & (Int32)Enum.Permissions.JobMaintenance) == 0)
			{
				//	User cannot perform job maintenance.

				this.RowJob1.Visible = false;
				this.RowJob2.Visible = false;
			}
			else
			{
				//	User can perform job maintenance.

				this.RowJob1.Visible = true;
				this.RowJob2.Visible = true;
			}

			if (ViewState["UserId"].ToString() == "0")
			{
				//	System administrator cannot enter timesheets!

				this.RowAdmin1.Visible = true;
				this.RowAdmin2.Visible = true;
			}

			Int32 PageSize;

			PageSize = Convert.ToInt32(ViewState["GridPage"].ToString());
			PageSize = (PageSize < 5) ? 5 : PageSize;
			this.GridTime.PageSize = PageSize;
			ViewState["GridPage"] = PageSize.ToString();

			this.cc2DateSelector.SetDate(DateTime.Now);
			ShowGrid(0);

			this.ddlProjects.Focus();

            EnableControls(false);
        }

		this.cc2DateSelector.DateChanged += new KazCustomControls.EventHandler(DateChanged);
		this.cc2DateSelector.IntervalChanged += new KazCustomControls.EventHandler(IntervalChanged);
	}
	#endregion

	private void DateChanged(object sender, System.EventArgs e)
	{
		ShowGrid(0);
	}

	private void IntervalChanged(object sender, System.EventArgs e)
	{
		ShowGrid(0);
	}

	#region Show members.
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

	private void ShowTime(Int32 TimeId)
	{
		ClassTime oTim = new ClassTime(TimeId);

		this.cc2DateSelector.SetDate(oTim.DateVal);

		try
		{
			this.ddlProjects.SelectedValue = oTim.ProjectId.ToString();
		}
		catch (Exception ex)
		{
            string var = ex.Message;
			//	No error.
		}

		this.ShowTasks();

		try
		{
			//this.DdlTasks.SelectedValue = oTim.TaskId.ToString();
		}
		catch (Exception)
		{
			//	No error.
		}

		try
		{
			//this.ddlStatus.SelectedValue = oTim.StatusId.ToString();
		}
		catch (Exception)
		{
			//	No error.
		}

		//this.TxtComment.Text = oTim.Comment;
		//this.TxtReference.Text = oTim.JobRef;
		this.txtTotalHours.Text = string.Format("{0:N2}", oTim.Hours);

		ViewState["TimeId"] = TimeId.ToString();

		this.LblTimeId.Text = string.Format("Update ({0})", ViewState["TimeId"].ToString());
		this.BtnSubmit.Text = "Update";

		//	User cannot modify locked records.

        if (oTim.Locked == true)
        {
            //	Locked time records cannot be re-submitted.

            EnableControls(false);
            this.BtnSubmit.Enabled = false;
        }
        else
        {
            EnableControls(true);
        }

		if (ViewState["UserId"].ToString() == "0")
		{
			//	Administrator cannot submit timesheets.

			this.BtnSubmit.Enabled = false;
		}
	}

	private void ShowGrid(Int32 PageNo)
	{
		DateTime DateStart = this.cc2DateSelector.StartDate();
		DateTime DateEnd = this.cc2DateSelector.EndDate();

		this.LblFrom.Text = DateStart.ToString("dd MMM yyyy");
		this.LblTo.Text = DateEnd.ToString("dd MMM yyyy");

		ClassReport oRep = new ClassReport();
		DataSet oDs = oRep.GetTimeSheet(Int32.Parse(ViewState["UserId"].ToString()), DateStart, DateEnd);
		double dTotal = 0;

		foreach (DataRow oDr in oDs.Tables[0].Rows)
			dTotal += double.Parse(oDr["Hours"].ToString());

		ViewState["TotalHours"] = dTotal.ToString();

		this.GridTime.DataSource = oDs;
		this.GridTime.PageIndex = (PageNo >= 0) ? PageNo : 0;
		this.GridTime.DataBind();

		if (Int32.Parse(ViewState["TimeId"].ToString()) == 0)
		{
			this.BtnSubmit.Text = "Submit";
			this.LblTimeId.Text = "New";
		}
		else
		{
			this.BtnSubmit.Text = "Update";
			this.LblTimeId.Text = string.Format("Update ({0})", Int32.Parse(ViewState["TimeId"].ToString()));
		}

		//	Time events which are locked cannot be edited or deleted.

		ClassTime oTim = new ClassTime();

		foreach (GridViewRow oRow in GridTime.Rows)
		{
			ImageButton oDel = (ImageButton)oRow.FindControl("ImgTrash");

			if (oDel != null)
			{
				oTim.Load(Int32.Parse(oDel.CommandArgument));

				if (oTim.Locked)
				{
					oDel.ToolTip = "";
					oDel.Enabled = false;
					oDel.ImageUrl = "~/Images/BlankIcon.gif";
				}
			}
		}

		ShowTimeError("");
	}

	protected string ShowHours(string Hrs)
	{
		string RetVal = string.Format("{0:F2}", Convert.ToDouble(Hrs));

		return RetVal;
	}

	private void ShowProjects()
	{
		ClassProject oPrj = new ClassProject();
		DataSet oDs = oPrj.ShowProjectsWithUserFlag(Convert.ToInt32(ViewState["UserId"].ToString()));

		//this.DdlTasks.Items.Clear();

		this.ddlProjects.Items.Clear();

		this.ddlProjects.DataSource = oDs;
		this.ddlProjects.DataTextField = "ProjectName";
		this.ddlProjects.DataValueField = "ProjectId";
		this.ddlProjects.DataBind();

		if (this.ddlProjects.Items.Count > 0)
			ShowTasks();
	}

	private void ShowTasks()
	{
		//ClassTask oTsk = new ClassTask();
		//Int32 PrjId = Convert.ToInt32(this.DdlProject.SelectedValue);

		//this.DdlTasks.Items.Clear();

		//this.DdlTasks.DataSource = oTsk.ShowTasksForProject(PrjId, true);
		//this.DdlTasks.DataTextField = "TaskName";
		//this.DdlTasks.DataValueField = "TaskId";
		//this.DdlTasks.DataBind();
	}

	private void ShowJobs(Int32 TskId)
	{
		//ClassTask oTsk = new ClassTask(Convert.ToInt32(this.DdlTasks.SelectedValue));

		//if ((oTsk.ValidationType & (Int32)Enum.ValidationType.UseDropDownListBox) != 0)
		//{
			//	We are using a dropdown listbox of possible job reference values.

			ClassJob oJob = new ClassJob();
			DataSet oDs = oJob.ShowJobsForTask(TskId, true);
			Boolean bShow = false;

			if (oDs != null)
			{
				if (oDs.Tables.Count > 0)
				{
					if (oDs.Tables[0].Rows.Count > 0)
						bShow = true;
				}
			}

			//this.DdlJobs.Items.Clear();

			if (bShow == true)
			{
				//this.DdlJobs.DataSource = oDs;
				//this.DdlJobs.DataTextField = "JobRef";
				//this.DdlJobs.DataValueField = "JobRef";
				//this.DdlJobs.DataBind();

				//this.TxtReference.Visible = false;
				//this.DdlJobs.Visible = true;
			}
			else
			{
				//	No pre-defined values exist for dropdown.
				//	User must enter a value.

				//this.TxtReference.Visible = true;
				//this.DdlJobs.Visible = false;
			}
		//}
		//else
		//{
			//	User needs to enter a value.

			//this.TxtReference.Visible = true;
			//this.DdlJobs.Visible = false;
		//}
	}

	private void ShowStatus()
	{
        //ClassStatus oStat = new ClassStatus();

        //this.ddlStatus.Items.Clear();

        //this.ddlStatus.DataSource = oStat.ShowStatus();
        //this.ddlStatus.DataTextField = "StatusText";
        //this.ddlStatus.DataValueField = "StatusId";
        //this.ddlStatus.DataBind();
	}
	#endregion

	#region Support members.
	private void CheckReady()
	{
		//	This method checks whether the project, task and Status listboxes have at least one
		//	value to select. If they don't then the user cannot submit time information.

		Boolean bOkay = false;

        //if (this.DdlProject.Items.Count > 0)
        //{
        //    if (this.DdlTasks.Items.Count > 0)
        //    {
        //        if (this.DdlStatus.Items.Count > 0)
        //            bOkay = true;
        //    }
        //}

		EnableControls(bOkay);
	}

	private void EnableControls(Boolean bOkay)
	{
		this.ddlProjects.Enabled = bOkay;
		//this.DdlTasks.Enabled = bOkay;

        this.ddlTimeInHours.Enabled = bOkay;
        this.ddlTimeInMinutes.Enabled = bOkay;
        this.ddlTimeInAMPM.Enabled = bOkay;
        this.ddlTimeOutHours.Enabled = bOkay;
        this.ddlTimeOutMinutes.Enabled = bOkay;
        this.ddlTimeOutAMPM.Enabled = bOkay;
        this.ddlLunchHours.Enabled = bOkay;
        this.ddlLunchMinutes.Enabled = bOkay;

		//this.ddlStatus.Enabled = bOkay;
		//this.TxtComment.Enabled = bOkay;
		//this.TxtReference.Enabled = bOkay;
		//this.txtTotalHours.Enabled = bOkay;
		this.BtnSubmit.Enabled = bOkay;

		ClassTime oTim = new ClassTime(Int32.Parse(ViewState["TimeId"].ToString()));

		if (oTim.Locked == true)
			this.BtnSubmit.Enabled = false;
	}

	protected void DdlProject_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		ShowTasks();
		DdlTasks_SelectedIndexChanged(sender, e);
		//this.DdlProject.Focus();
	}

	protected void DdlTasks_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		//ClassTask oTsk = new ClassTask(Convert.ToInt32(this.DdlTasks.SelectedValue));

		//if ((oTsk.ValidationType & (Int32)Enum.ValidationType.UseDropDownListBox) != 0)
		//{
			//this.TxtReference.Visible = false;
			//this.DdlJobs.Visible = true;
			//ShowJobs(Convert.ToInt32(this.DdlTasks.SelectedValue));
			DdlJobs_SelectedIndexChanged(sender, e);
		//}
		//else
		//{
			//this.TxtReference.Visible = true;
			//this.DdlJobs.Visible = false;
			ShowJobs(0);
		//}

		//this.DdlTasks.Focus();
	}

	protected void DdlJobs_SelectedIndexChanged(object sender, System.EventArgs e)
	{
        //if (this.DdlJobs.Items.Count > 0)
        //{
        //    ClassJob oJob = new ClassJob(this.DdlJobs.SelectedValue.ToString());

        //    this.TxtReference.Text = oJob.JobRef;
        //    this.TxtComment.Text = oJob.Description;
        //}

        //this.DdlJobs.Focus();
	}

	protected double GetTotal()
	{
		//	Get total hours shown in grid.

		return double.Parse(ViewState["TotalHours"].ToString());
	}
	#endregion

	#region Button events.
	protected void BtnNew_Click(object sender, EventArgs e)
	{
		//	Reset the Time ID to zero.

		ViewState["TimeId"] = "0";
		this.LblTimeId.Text = "New";
		this.BtnSubmit.Text = "Submit";
		this.BtnSubmit.Enabled = true;

        EnableControls(true);
	}

    public void ResetTime()
    {
        ddlTimeInHours.SelectedIndex = 0;
        ddlTimeInMinutes.SelectedIndex = 0;
        ddlTimeInAMPM.SelectedValue = "AM";

        ddlTimeOutHours.SelectedIndex = 0;
        ddlTimeOutMinutes.SelectedIndex = 0;
        ddlTimeOutAMPM.SelectedValue = "PM";

        ddlLunchHours.SelectedIndex = 0;
        ddlLunchMinutes.SelectedIndex = 0;
    }
	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		//ClassTask oTsk = new ClassTask(Convert.ToInt32(this.DdlTasks.SelectedValue));
		//Boolean bOkay = false;

        Boolean bOkay = true;

        //if ((oTsk.ValidationType & (Int32)Enum.ValidationType.NoValidation) != 0)
        //{
        //    //	No validation for job reference. User can enter anything
        //    //	they like.

        //    bOkay = true;
        //}
        //else if ((oTsk.ValidationType & (Int32)Enum.ValidationType.JobMustPreExist) != 0)
        //{
        //    //	Job must pre-exist and be active in tblJobs.

        //    //ClassJob oJob = new ClassJob();

        //    //if (oJob.IsJobActive(this.TxtReference.Text) == true)
        //    //{
        //    //    //	Job reference is available and is active.

        //    //    bOkay = true;
        //    //}
        //    //else
        //    //{
        //    //    //	Job reference either doesn't exist or it isn't
        //    //    //	currently active in tblJobs.

        //    //    bOkay = false;
        //    //    ShowTimeError("Job reference does not pre-exist!");
        //    //}
        //}
        //else if ((oTsk.ValidationType & (Int32)Enum.ValidationType.UseRegularExpression) != 0)
        //{
        //    //	Job reference must meet regular expression.

        //    //System.Text.RegularExpressions.Regex oReg = new System.Text.RegularExpressions.Regex(oTsk.ReferenceRegEx);

        //    //if (oReg.IsMatch(this.TxtReference.Text) == true)
        //    //{
        //    //    //	Regular expression match is okay.

        //    //    bOkay = true;
        //    //}
        //    //else
        //    //{
        //    //    //	Regular expression failed.

        //    //    bOkay = false;
        //    //    ShowTimeError("Job reference failed regular expression check!");
        //    //}
        //}
        //else if ((oTsk.ValidationType & (Int32)Enum.ValidationType.UseDropDownListBox) != 0)
        //{
        //    //	Job reference supplied via dropdown listbox.

        //    if (this.DdlJobs.Items.Count > 0)
        //    {
        //        //	The user has selected via the dropdown listbox.

        //        //this.TxtReference.Text = this.DdlJobs.SelectedValue;
        //        bOkay = true;
        //    }
        //}

		if (bOkay == true)
		{
			//	We have passed the job reference validation check (if any).

			ClassTime oTim = new ClassTime(Convert.ToInt32(ViewState["TimeId"].ToString()));
			ClassUser oUsr = new ClassUser();

			oTim.DateVal = this.cc2DateSelector.GetDate();
			oTim.UserId = Int32.Parse(ViewState["UserId"].ToString());
			oTim.ProjectId = Convert.ToInt32(this.ddlProjects.SelectedValue);
			//oTim.TaskId = oTsk.TaskId;
			//oTim.StatusId = Convert.ToInt32(this.ddlStatus.SelectedValue);
			//oTim.Comment = this.TxtComment.Text;
			//oTim.JobRef = this.TxtReference.Text;

			//	Check that hours entered is a valid number.

			System.Text.RegularExpressions.Regex oReg = new System.Text.RegularExpressions.Regex("[-+]?[0-9]*\\.?[0-9]+");

			if (!oReg.IsMatch(this.txtTotalHours.Text))
			{
				//	Regular expression for hours failed.

				ShowTimeError("The hours entered are incorrectly specified!");
			}
			else
			{
				//	Hours entered is a valid number.

				double HoursVal;

				if (double.TryParse(this.txtTotalHours.Text, out HoursVal) != true)
				{
					//	Problem with the submitted hours value.

					ShowTimeError("The hours entered are invalid!");
				}
				else
				{
					//	Hours value is okay.

					oTim.Hours = HoursVal;

					oTim.Save(Int32.Parse(ViewState["TimeId"].ToString()));

					ShowTime(oTim.TimeId);
					ShowGrid(0);

					ViewState["TimeId"] = "0";
					//this.TxtComment.Text = "";
					this.txtTotalHours.Text = "0.00";
					this.LblTimeId.Text = "New";
					this.BtnSubmit.Text = "Submit";

                    ResetTime();
                    EnableControls(false);
                    BtnSubmit.Enabled = false;
				}
			}
		}

		//this.DdlProject.Focus();
	}

	protected void BtnJobs_Click(object sender, EventArgs e)
	{
		Session["Referer"] = Request.Url.ToString();
		Response.Redirect("JobMaintenance.aspx", true);
	}

	protected void BtnMainMenu_Click(object sender, EventArgs e)
	{
		//	Return to time menu.

		Response.Redirect("Default.aspx", true);
	}

	protected void BtnIncrease_Click(object sender, EventArgs e)
	{
		Int32 PageSize;

		PageSize = Convert.ToInt32(ViewState["GridPage"].ToString());
		PageSize = (PageSize < 5) ? 5 : PageSize;
		PageSize += 5;
		ViewState["GridPage"] = PageSize.ToString();

		this.GridTime.PageSize = PageSize;
		this.BtnDecrease.Enabled = true;
		this.BtnDecrease.Visible = true;

		ShowGrid(0);
	}

	protected void BtnDecrease_Click(object sender, EventArgs e)
	{
		Int32 PageSize;

		PageSize = Convert.ToInt32(ViewState["GridPage"].ToString());
		PageSize = (PageSize < 5) ? 10 : PageSize;
		PageSize -= 5;
		ViewState["GridPage"] = PageSize.ToString();

		this.GridTime.PageSize = PageSize;

		if (PageSize < 10)
		{
			this.BtnDecrease.Enabled = false;
			this.BtnDecrease.Visible = false;
		}

		ShowGrid(0);
	}
	#endregion

	#region GridTime Events
	protected void GridTime_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			ImageButton oBtn = (ImageButton)e.Row.FindControl("ImgTrash");

			if (oBtn != null)
			{
				oBtn.Attributes.Add("onclick",
					"javascript:return confirm('Are you sure you want to delete this record?')");
			}
		}
	}

	protected void GridTime_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		switch (e.CommandName)
		{
			case "Delete":
				ClassTime oTim = new ClassTime();

				oTim.Delete(Convert.ToInt32(e.CommandArgument));				
				ShowGrid(0);
				break;

			case "Edit":
				ViewState["TimeId"] = Convert.ToInt32(e.CommandArgument).ToString();
				ShowTime(Convert.ToInt32(e.CommandArgument));
				break;
		}
	}

	protected void GridTime_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		//	RowDeleted....
	}

	protected void GridTime_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		//	RowDeleting....
	}

	protected void GridTime_RowEditing(object sender, GridViewEditEventArgs e)
	{
		//	RowEditing....
	}

	protected void GridTime_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		ShowGrid(e.NewPageIndex);
	}
	#endregion


}
