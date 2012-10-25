//	---------------------------------------------------------------------------
//	$Filename: D:\Inetpub\wwwroot\TimeRep\ReportBudget.aspx.cs $
//	$Revision: 1.2 $
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

public partial class ReportBudget : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Budget Report";

	#region Page events
	protected void Page_PreInit(object sender, EventArgs e)
	{
		//	Page pre-initialisation.
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			Page.Title = TXT_PAGETITLE;
			this.LblPageTitle.Text = TXT_PAGETITLE;

			this.RowError1.Visible = false;
			this.RowError2.Visible = false;

			ShowProjects();
			ShowGrid();
		}
	}
	#endregion

	private void ShowGrid()
	{
		DataSet oDs = GetGridData();
		double dTotal1 = 0;
		double dTotal2 = 0;

		foreach (DataRow oDr in oDs.Tables[0].Rows)
		{
			dTotal1 += double.Parse(oDr["Budget"].ToString());
			dTotal2 += double.Parse(oDr["Actual"].ToString());
		}

		ViewState["Budget"] = dTotal1.ToString();
		ViewState["Actual"] = dTotal2.ToString();

		this.GridTime.DataSource = oDs;
		this.GridTime.DataBind();
	}

	private DataSet GetGridData()
	{
		DataSet oDs;

		try
		{
			ClassReport oRep = new ClassReport();

			oDs = oRep.GetBudgetReport(Int32.Parse(this.ddlProjects.SelectedValue.ToString()));
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			oDs = null;
		}

		return oDs;
	}

	private void ShowProjects()
	{
		ClassProject oPrj = new ClassProject();

		this.ddlProjects.DataSource = oPrj.ShowProjects();
		this.ddlProjects.DataTextField = "ProjectName";
		this.ddlProjects.DataValueField = "ProjectId";
		this.ddlProjects.DataBind();
	}

	protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
	{
		ShowGrid();
	}

	protected double ShowHours(string Hours)
	{
		string RetVal = string.Format("{0:F2}", Hours);

		return Convert.ToDouble(Hours);
	}

	protected double GetTotalActual()
	{
		try
		{
			return Convert.ToDouble(ViewState["Actual"].ToString());
		}

		catch (Exception)
		{
			return 0.00;
		}
	}

	protected double GetTotalBudget()
	{
		try
		{
			return Convert.ToDouble(ViewState["Budget"].ToString());
		}

		catch (Exception)
		{
			return 0.00;
		}
	}

	protected double GetTotalOverspend()
	{
		try
		{
			return Convert.ToDouble(ViewState["Actual"].ToString()) - Convert.ToDouble(ViewState["Budget"].ToString());
		}

		catch (Exception)
		{
			return 0.00;
		}
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

			Int32[] Columns = { 0, 1, 2, 3, 4 };

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

	protected void BtnExportToCSV_Click(object sender, EventArgs e)
	{
		DoExport(true);
	}

	protected void BtnExportToExcel_Click(object sender, EventArgs e)
	{
		DoExport(false);
	}

	#region Button events
	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		Response.Redirect("ReportMenu.aspx", true);
	}
	#endregion

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
