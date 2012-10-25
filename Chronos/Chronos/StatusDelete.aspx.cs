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

public partial class StatusDelete : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Delete Status";

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			Page.Title = TXT_PAGETITLE;
			this.LblPageTitle.Text = TXT_PAGETITLE;

			if (Request.QueryString["StatusId"] == null)
				Response.Redirect("StatusMenu.aspx", true);

			ViewState["StatusId"] = Request.QueryString["StatusId"].ToString();

			ClassStatus oSt = new ClassStatus(Convert.ToInt32(ViewState["StatusId"].ToString()));

			this.LblMsg.Text = oSt.StatusText;
		}
	}

	protected void BtnConfirm_Click(object sender, EventArgs e)
	{
		ClassStatus oStat = new ClassStatus();

		oStat.Delete(Convert.ToInt32(ViewState["StatusId"].ToString()));
		Response.Redirect("StatusMenu.aspx", true);
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("StatusMenu.aspx", true);
	}
}
