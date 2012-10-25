//	---------------------------------------------------------------------------
//	$Filename: D:\Inetpub\wwwroot\TimeRep\Template.aspx.cs $
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

public partial class Template : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Welcome!";

	protected void Page_Load(object sender, EventArgs e)
    {
		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			Page.Title = TXT_PAGETITLE;
			this.LblPageTitle.Text = TXT_PAGETITLE;
		}
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		//	Submit button.

		try
		{

		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}
	}
}
