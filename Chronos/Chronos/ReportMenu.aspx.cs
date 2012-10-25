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

public partial class ReportMenu : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Reports";

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

			ClassUser oUsr = new ClassUser(Convert.ToInt32(ViewState["UserId"].ToString()));

			if (((oUsr.Permissions & (Int32)Enum.Permissions.ManagerOnly) == 0) && (ViewState["UserId"].ToString() != "0"))
			{
				//	User isn't allowed to look at certain managerial reports.

				this.BtnBudget.Enabled = false;
				this.BtnCostCentre.Enabled = false;
			}
		}
	}

	protected void BtnProductivity_Click(object sender, EventArgs e)
	{
		Response.Redirect("ReportProfit.aspx", true);
	}

	protected void BtnReferenceReport_Click(object sender, EventArgs e)
	{
		Response.Redirect("ReportReference.aspx", true);
	}

	protected void BtnReportByTask_Click(object sender, EventArgs e)
	{
		Response.Redirect("ReportTask.aspx", true);
	}

	protected void BtnGraphUser_Click(object sender, EventArgs e)
	{
		Response.Redirect("GraphUser.aspx", true);
	}

	protected void BtnUserReport_Click(object sender, EventArgs e)
	{
		Response.Redirect("ReportUser.aspx", true);
	}

	protected void BtnBudget_Click(object sender, EventArgs e)
	{
		Response.Redirect("ReportBudget.aspx", true);
	}

	protected void BtnCostCentre_Click(object sender, EventArgs e)
	{
		Response.Redirect("ReportCostCentre.aspx", true);
	}

	protected void BtnMainMenu_Click(object sender, EventArgs e)
	{
		//	Return to main menu.

		Response.Redirect("Default.aspx", true);
	}
}
