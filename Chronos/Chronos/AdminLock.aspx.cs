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

public partial class AdminLock : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Timesheet Lock";

	protected void Page_PreInit(object sender, EventArgs e)
	{
		//	Get user ID and store in ViewState.

		ViewState["UserId"] = Page.User.Identity.Name.ToString();

		if (ViewState["UserId"].ToString() != "0")
		{
			ClassUser oUsr = new ClassUser(Convert.ToInt32(Page.User.Identity.Name.ToString()));

			if ((oUsr.Permissions & (Int32)Enum.Permissions.Lock) == 0)
			{
				//	User isn't allowed to lock/unlock timesheets.

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

			this.BtnLock.Attributes.Add("onclick", "confirm('Are you sure you want to LOCK the timesheets?');");
			this.BtnUnlock.Attributes.Add("onclick", "confirm('Are you sure you want to UNLOCK the timesheets?');");

			ShowUsers();
		}

		this.cc2DateSelector.DateChanged += new KazCustomControls.EventHandler(DateChanged);
		this.cc2DateSelector.IntervalChanged += new KazCustomControls.EventHandler(IntervalChanged);
	}

	private void DateChanged(object sender, System.EventArgs e)
	{
		ShowUsers();
	}

	private void IntervalChanged(object sender, System.EventArgs e)
	{
		ShowUsers();
	}

	private void ShowUsers()
	{
		ClassUser oUsr = new ClassUser();

		this.GridUsers.DataSource = oUsr.ShowUsers();
		this.GridUsers.DataBind();
	}

	private void LockAndUnlock(Boolean SetLock)
	{
		ClassTime oTim = new ClassTime();
		DateTime DateStart = this.cc2DateSelector.StartDate();
		DateTime DateEnd = this.cc2DateSelector.EndDate();

		foreach (GridViewRow oRow in GridUsers.Rows)
		{
			Label oLbl = (Label) oRow.FindControl("LblUserId");

			if (oLbl != null)
			{
				CheckBox oChk = (CheckBox) oRow.FindControl("ChkLock");

				if (oChk != null)
				{
					if (oChk.Checked)
						oTim.LockAndUnlock(SetLock, Convert.ToInt32(oLbl.Text), DateStart, DateEnd);
				}
			}
		}
	}

	protected void BtnLock_Click(object sender, EventArgs e)
	{
		LockAndUnlock(true);
	}

	protected void BtnUnlock_Click(object sender, EventArgs e)
	{
		LockAndUnlock(false);
	}

	protected void BtnAdminMenu_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminMenu.aspx", true);
	}

	#region GridUsers Events
	protected void GridUsers_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
		}
	}

	protected void GridUsers_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void GridUsers_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		//	RowDeleted....
	}

	protected void GridUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		//	RowDeleting....
	}

	protected void GridUsers_RowEditing(object sender, GridViewEditEventArgs e)
	{
		//	RowEditing....
	}
	#endregion
}
