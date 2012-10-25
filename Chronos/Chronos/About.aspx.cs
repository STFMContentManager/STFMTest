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

public partial class About : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "About";

	protected void Page_Load(object sender, EventArgs e)
    {
		Page.Title = TXT_PAGETITLE;
		this.LblPageTitle.Text = TXT_PAGETITLE;

		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			this.LblVersion.Text = string.Format("Version: {0}", Util.VersionNo());
		}
	}

	protected void BtnPayPal_Click(object sender, EventArgs e)
	{
		//	Transfer to PayPal contributions page.

		Response.Redirect("PayPal.aspx", true);
	}

	protected void BtnMainMenu_Click(object sender, EventArgs e)
	{
		//	Return to main menu.

		Response.Redirect("Default.aspx", true);
	}
}
