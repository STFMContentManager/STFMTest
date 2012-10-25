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

public partial class StatusEdit : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Edit Status";

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			Page.Title = TXT_PAGETITLE;
			this.LblPageTitle.Text = TXT_PAGETITLE;

			if (Request.QueryString["StatusId"] == null)
				Response.Redirect("StatusMenu.aspx", true);

			ClassStatus oCat = new ClassStatus(Convert.ToInt32(Request.QueryString["StatusId"].ToString()));

			this.TxtStatusText.Text = oCat.StatusText;
			this.TxtSortOrder.Text = oCat.SortOrder.ToString();

			ViewState["StatusId"] = oCat.StatusId.ToString();
		}
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		//	Submit button.

		int StatusId = 0;

		try
		{
			ClassStatus oCat = new ClassStatus();
			Int16 SortOrder = 0;

			oCat.StatusText = this.TxtStatusText.Text;
			Int16.TryParse(this.TxtSortOrder.Text, out SortOrder);
			oCat.SortOrder = SortOrder;

			StatusId = oCat.Save(Convert.ToInt32(ViewState["StatusId"].ToString()));
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		Response.Redirect(string.Format("StatusMenu.aspx?StatusId={0}", StatusId), true);
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("StatusMenu.aspx", true);
	}
}
