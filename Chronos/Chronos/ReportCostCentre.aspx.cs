//	---------------------------------------------------------------------------
//	$Filename: D:\Inetpub\wwwroot\TimeRep\ReportCostCentre.aspx.cs $
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

public partial class ReportCostCentre : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Cost Report";

	#region Page events
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

			if ((oUsr.Permissions & (Int32)Enum.Permissions.ManagerOnly) == 0)
			{
				//	User isn't allowed to look at this report.

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

			ClassUser oUsr = new ClassUser(Convert.ToInt32(Page.User.Identity.Name.ToString()));

			ViewState["TotalHours"] = "0";
			this.cc2DateSelector.SetDate(DateTime.Now);
			ShowGrid();

			this.LblProductive.Text = "";
			this.LblUnproductive.Text = "";
			this.LblProductivePercent.Text = "";
		}

		this.cc2DateSelector.DateChanged += new KazCustomControls.EventHandler(DateChanged);
		this.cc2DateSelector.IntervalChanged += new KazCustomControls.EventHandler(IntervalChanged);
	}
	#endregion

	private void DateChanged(object sender, System.EventArgs e)
	{
		ShowGrid();
	}

	private void IntervalChanged(object sender, System.EventArgs e)
	{
		ShowGrid();
	}

	private void ShowGrid()
	{
		this.LblFrom.Text = this.cc2DateSelector.StartDate().ToLongDateString();
		this.LblTo.Text = this.cc2DateSelector.EndDate().ToLongDateString();
		this.LblProductive.Text = "";
		this.LblUnproductive.Text = "";
		this.LblProductivePercent.Text = "";

		ClassReport oRep = new ClassReport();
		DataSet oDs = oRep.GetCostCentre(this.cc2DateSelector.StartDate(), this.cc2DateSelector.EndDate());
		double TotalHours = 0.0;
		Boolean bOkay = false;
		double Productive = 0.0;
		double Unproductive = 0.0;

		if (oDs != null)
		{
			if (oDs.Tables.Count > 0)
			{
				if (oDs.Tables[0].Rows.Count > 0)
				{
					bOkay = true;

					foreach (DataRow oDr in oDs.Tables[0].Rows)
					{
						TotalHours += Convert.ToDouble(oDr["Hours"].ToString());

						if (oDr["IsProductive"].ToString() == "Yes")
							Productive += Convert.ToDouble(oDr["Hours"].ToString());
						else
							Unproductive += Convert.ToDouble(oDr["Hours"].ToString());
					}
				}
			}
		}

		ViewState["TotalHours"] = TotalHours.ToString();

		if (bOkay == true)
		{
			this.GridTime.DataSource = oDs;
			this.GridTime.DataBind();
		}
		else
		{
			this.GridTime.DataSource = null;
			this.GridTime.DataBind();
		}

		this.LblProductive.Text = Productive.ToString("N2");
		this.LblUnproductive.Text = Unproductive.ToString("N2");

		if ((Productive + Unproductive) != 0)
		{
			this.LblProductivePercent.Text = string.Format("{0:N2}%", (100 * Productive / (Productive + Unproductive)));
		}
	}

	protected double ShowHours(string Hours)
	{
		return Convert.ToDouble(Hours);
	}

	protected double ShowTotalHours()
	{
		return Convert.ToDouble(ViewState["TotalHours"].ToString());
	}

	private void DoExport(Boolean bToCSV)
	{
		ClassReport oRep = new ClassReport();
		DataSet oDs = oRep.GetCostCentre(this.cc2DateSelector.StartDate(), this.cc2DateSelector.EndDate());
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

			Int32[] Columns = { 0, 1, 2, 3 };

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

	protected void BtnToCSV_Click(object sender, EventArgs e)
	{
		DoExport(true);
	}

	protected void BtnToExcel_Click(object sender, EventArgs e)
	{
		DoExport(false);
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		Response.Redirect("ReportMenu.aspx", true);
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
