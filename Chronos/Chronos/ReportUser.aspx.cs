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

public partial class ReportUser : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "User Report";

	protected void Page_PreInit(object sender, EventArgs e)
	{
		//	Get user ID and store in ViewState.

		ViewState["UserId"] = Page.User.Identity.Name.ToString();

		if (ViewState["UserId"].ToString() != "0")
		{
			ClassUser oUsr = new ClassUser(Convert.ToInt32(Page.User.Identity.Name.ToString()));

			if ((oUsr.Permissions & (Int32)Enum.Permissions.Report) == 0)
			{
				//	User isn't allowed to look at reports.

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

			ViewState["TotalHours"] = "0";

			this.RowError1.Visible = false;
			this.RowError2.Visible = false;

			this.cc2DateSelector.SetDate(DateTime.Now);
			ShowUsers();
			ShowGrid();
		}
		
		this.cc2DateSelector.DateChanged += new KazCustomControls.EventHandler(DateChanged);
		this.cc2DateSelector.IntervalChanged += new KazCustomControls.EventHandler(IntervalChanged);
	}

	private void DateChanged(object sender, System.EventArgs e)
	{
		ShowGrid();
	}

	private void IntervalChanged(object sender, System.EventArgs e)
	{
		ShowGrid();
	}

	private DataSet GetGridData()
	{
		DataSet oDs;
		DateTime DateStart = this.cc2DateSelector.StartDate();
		DateTime DateEnd = this.cc2DateSelector.EndDate();

		try
		{
			ClassReport oRep = new ClassReport();

			oDs = oRep.GetTimeSheet(Int32.Parse(this.DdlUsers.SelectedValue.ToString()), DateStart, DateEnd);
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			oDs = null;
		}

		return oDs;
	}

	private void ShowGrid()
	{
		DataSet oDs = GetGridData();
		double dTotal = 0;

		this.LblFrom.Text = this.cc2DateSelector.StartDate().ToString("d MMMM yyyy");
		this.LblTo.Text = this.cc2DateSelector.EndDate().ToString("d MMMM yyyy");

		if (oDs != null)
		{
			if (oDs.Tables.Count > 0)
			{
				if (oDs.Tables[0].Rows.Count > 0)
				{
					foreach (DataRow oDr in oDs.Tables[0].Rows)
					{
						dTotal += double.Parse(oDr["Hours"].ToString());
					}
				}
			}
		}

		ViewState["TotalHours"] = dTotal.ToString();

		this.GridTime.DataSource = oDs;
		this.GridTime.DataBind();

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
	}

	private void ShowUsers()
	{
		ClassUser oUsr = new ClassUser(Convert.ToInt32(ViewState["UserId"].ToString()));
		DataSet oDs;

		if ((oUsr.Permissions & (Int32)Enum.Permissions.ManagerOnly) == 0)
		{
			//	This user is restricted to seeing only their own data.

			if (ViewState["UserId"].ToString() != "0")
			{
				oDs = oUsr.ShowUsers2(oUsr.UserId);
			}
			else
			{
				//	Except this is the superuser, who can see everything.

				oDs = oUsr.ShowUsers1();
			}
		}
		else
		{
			//	This user is allowed to access data for multiple users.

			oDs = oUsr.ShowUsers1();
		}

		this.DdlUsers.DataSource = oDs;
		this.DdlUsers.DataTextField = "UserName";
		this.DdlUsers.DataValueField = "UserId";
		this.DdlUsers.DataBind();
	}

	protected string ShowHours(string Hrs)
	{
		string RetVal = string.Format("{0:F2}", Convert.ToDouble(Hrs));

		return RetVal;
	}

	protected double GetTotal()
	{
		//	Get total hours shown in grid.

		return double.Parse(ViewState["TotalHours"].ToString());
	}

	private void DoExport(Boolean bToCSV)
	{
		ClassReport oRep = new ClassReport();
		DataSet oDs = GetGridData();
		Boolean bOkay = false;

		this.RowError1.Visible = false;
		this.RowError2.Visible = false;

		if (oDs != null)
		{
			if (oDs.Tables.Count > 0)
			{
				if (oDs.Tables[0].Rows.Count > 0)
				{
					bOkay = true;
				}
			}
		}

		if (bOkay == true)
		{
			RKLib.ExportData.Export oExp = new RKLib.ExportData.Export("Web");

			Int32[] Columns = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			if (bToCSV == true)
			{
				//	Export to CSV file.

				oExp.ExportDetails(oDs.Tables[0], Columns, RKLib.ExportData.Export.ExportFormat.CSV, "Report.csv");
			}
			else
			{
				//	Export to Microsoft Excel.

				oExp.ExportDetails(oDs.Tables[0], Columns, RKLib.ExportData.Export.ExportFormat.Excel, "Report.xls");
			}
		}
		else
		{
			this.RowError1.Visible = true;
			this.RowError2.Visible = true;
			this.LblMsg.Text = "No Data Found!";
		}
	}

	protected void BtnExcel_Click(object sender, EventArgs e)
	{
		DoExport(false);
	}

	protected void BtnCSV_Click(object sender, EventArgs e)
	{
		DoExport(true);
	}

	protected void BtnReportMenu_Click(object sender, EventArgs e)
	{
		Response.Redirect("ReportMenu.aspx", true);
	}

	protected void DdlUsers_SelectedIndexChanged(object sender, EventArgs e)
	{
		ShowGrid();
	}

	#region GridTime Events
	protected void GridTime_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}

	protected void GridTime_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void GridTime_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
	}

	protected void GridTime_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
	}

	protected void GridTime_RowEditing(object sender, GridViewEditEventArgs e)
	{
	}
	#endregion
}
