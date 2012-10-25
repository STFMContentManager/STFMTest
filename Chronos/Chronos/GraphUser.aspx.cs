//	---------------------------------------------------------------------------
//	$Filename: D:\Inetpub\wwwroot\TimeRep\GraphUser.aspx.cs $
//	$Revision: 1.5 $
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
using System.Drawing;
using ZedGraph;
using ZedGraph.Web;
using System.Text;

public partial class GraphUser : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "User Productivity";

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
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			ShowTeams();
			ShowUsers();
			ShowGraph();
		}

		this.cc2DateSelector.DateChanged += new KazCustomControls.EventHandler(DateChanged);
		this.cc2DateSelector.IntervalChanged += new KazCustomControls.EventHandler(IntervalChanged);
		Page.Title = TXT_PAGETITLE;
		this.LblPageTitle.Text = TXT_PAGETITLE;
	}
	#endregion

	private void DateChanged(object sender, System.EventArgs e)
	{
		ShowGraph();
	}

	private void IntervalChanged(object sender, System.EventArgs e)
	{
		ShowGraph();
	}

	private void ShowTeams()
	{
		ClassUser oUsr = new ClassUser(Convert.ToInt32(ViewState["UserId"].ToString()));
		ClassTeam oTm = new ClassTeam();
		DataSet oDs;
		Boolean bManager = false;

		if (((oUsr.Permissions & (Int32)Enum.Permissions.ManagerOnly) == 0) || (ViewState["UserId"].ToString() == "0"))
		{
			bManager = true;
		}

		if (bManager == false)
		{
			//	This user is only allowed to access their own team.

			oDs = oTm.ShowTeams2(oUsr.TeamId);
		}
		else
		{
			//	This user has access to all teams.

			oDs = oTm.ShowTeams1();
		}

		this.DdlTeams.DataSource = oDs;
		this.DdlTeams.DataTextField = "TeamName";
		this.DdlTeams.DataValueField = "TeamId";
		this.DdlTeams.DataBind();
	}

	private void ShowUsers()
	{
		ClassUser oUsr = new ClassUser(Convert.ToInt32(ViewState["UserId"].ToString()));
		DataSet oDs;
		Boolean bManager = false;

		if (((oUsr.Permissions & (Int32)Enum.Permissions.ManagerOnly) != 0) || (ViewState["UserId"].ToString() == "0"))
		{
			//	Access to management reports allowed.

			bManager = true;
		}

		if (bManager == false)
		{
			//	This user is restricted to seeing only their own data.

			oDs = oUsr.ShowUsers2(oUsr.UserId);
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

		if (bManager == true)
		{
			//	Access to multiple users allows this user to select all users.

			this.DdlUsers.Items.Insert(0, new ListItem("All users", "0"));
		}
	}

	private void ShowGraph()
	{
		this.ZedGraphWeb.RenderGraph += new ZedGraph.Web.ZedGraphWebControlEventHandler(this.OnRenderGraph);
	}

	private void OnRenderGraph(ZedGraph.Web.ZedGraphWeb z, System.Drawing.Graphics g, ZedGraph.MasterPane masterPane)
	{
		// Get the GraphPane so we can work with it

		GraphPane myPane = masterPane[0];

		// Set the title and axis labels

		myPane.Title.Text = "";
		myPane.YAxis.Title.Text = "User";
		myPane.XAxis.Title.Text = "Productivity %";

		//	Get productivity for team users.

		DateTime DateStart = this.cc2DateSelector.StartDate();
		DateTime DateEnd = this.cc2DateSelector.EndDate();

		myPane.Title.Text = string.Format("{0} - {1}", ClassTimeAndDate.DateToString(DateStart), ClassTimeAndDate.DateToString(DateEnd));

		ClassReport oRep = new ClassReport();
		DataSet oDs = oRep.GetTeamProductivity(Convert.ToInt32(this.DdlTeams.SelectedValue), Convert.ToInt32(this.DdlUsers.SelectedValue), DateStart, DateEnd);
		Int32 RowNo = 0;

		string[] labels = new string[oDs.Tables[0].Rows.Count];
		double[] values = new double[oDs.Tables[0].Rows.Count];

		for (RowNo = 0; RowNo < oDs.Tables[0].Rows.Count; RowNo++)
		{
			labels[RowNo] = oDs.Tables[0].Rows[RowNo]["UserName"].ToString();
			values[RowNo] = Convert.ToDouble(oDs.Tables[0].Rows[RowNo]["Productivity"].ToString());
		}

		myPane.YAxis.Scale.TextLabels = labels;
		myPane.YAxis.Type = AxisType.Text;

		myPane.XAxis.Scale.Min = 0;
		myPane.XAxis.Scale.Max = 120.0;
		myPane.XAxis.MajorTic.Size = 10.0F;
		myPane.XAxis.MajorTic.IsInside = false;
		myPane.XAxis.MajorGrid.IsVisible = true;
		myPane.XAxis.MinorTic.Size = 5.0F;
		myPane.XAxis.MinorTic.IsInside = false;

		//	Legend.

		BarItem myCurve = myPane.AddBar("Productivity", values, null, Color.Red);

		//	Chart background.

		myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 45.0F);

		myPane.BarSettings.Base = BarBase.Y;

		masterPane.AxisChange(g);
		BarItem.CreateBarLabels(myPane, false, "f0");

		Page.Title = TXT_PAGETITLE;
		this.LblPageTitle.Text = TXT_PAGETITLE;
	}

	protected void DdlTeams_IndexChanged(object sender, EventArgs e)
	{
		ShowUsers();
		ShowGraph();
	}

	protected void DdlUsers_IndexChanged(object sender, EventArgs e)
	{
		ShowGraph();
	}

	#region Button events
	protected void BtnReportMenu_Click(object sender, EventArgs e)
	{
		Response.Redirect("~/ReportMenu.aspx", true);
	}
	#endregion
}
