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

public partial class StatusMenu : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Status Menu";

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			Page.Title = TXT_PAGETITLE;
			this.LblPageTitle.Text = TXT_PAGETITLE;

			ClassStatus oStat = new ClassStatus();

			this.DdlStatus.DataSource = oStat.ShowStatus();
			this.DdlStatus.DataTextField = "StatusText";
			this.DdlStatus.DataValueField = "StatusId";
			this.DdlStatus.DataBind();

			this.BtnAddStatus.Enabled = true;

			if (this.DdlStatus.Items.Count > 0)
			{
				this.DdlStatus.Enabled = true;
				this.BtnDeleteStatus.Enabled = true;
				this.BtnEditStatus.Enabled = true;

				if (Request.QueryString["StatusId"] != null)
				{
					try
					{
						this.DdlStatus.SelectedValue = Request.QueryString["StatusId"].ToString();
					}

					catch (Exception)
					{
						//	Do nothing. The Status ID doesn't exist in the dropdown listbox.
						//	This isn't an error.
					}
				}
			}
			else
			{
				this.DdlStatus.Enabled = false;
				this.BtnDeleteStatus.Enabled = false;
				this.BtnEditStatus.Enabled = false;
			}
		}
	}

	protected void BtnAddStatus_Click(object sender, EventArgs e)
	{
		Response.Redirect("StatusEdit.aspx?StatusId=0", true);
	}

	protected void BtnDeleteStatus_Click(object sender, EventArgs e)
	{
		Response.Redirect("StatusDelete.aspx?StatusId=" + this.DdlStatus.SelectedValue, true);
	}

	protected void BtnEditStatus_Click(object sender, EventArgs e)
	{
		Response.Redirect("StatusEdit.aspx?StatusId=" + this.DdlStatus.SelectedValue, true);
	}

	protected void BtnAdminMenu_Click(object sender, EventArgs e)
	{
		//	Return to main menu.

		try
		{
			Response.Redirect("AdminMenu.aspx", true);
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}
	}
}
