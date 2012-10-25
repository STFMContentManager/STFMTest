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
using System.Net;

public partial class Login : System.Web.UI.Page
{
    const string TXT_PAGETITLE = "Login to CHRONOS";

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			Page.Title = TXT_PAGETITLE;
			this.LblPageTitle.Text = TXT_PAGETITLE;

            this.LblMessage.Text = ""; // string.Format("Version: {0}", Util.VersionNo());

			FormsAuthentication.SignOut();
			this.TxtUserName.Focus();
		}
	}

	protected void BtnAbout_Click(object sender, EventArgs e)
	{
		Response.Redirect("About.aspx", true);
	}

	protected void BtnContact_Click(object sender, EventArgs e)
	{
		Response.Redirect("Contact.aspx", true);
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		//	Submit button.

		try
		{
			if ((Util.ReadString("AdminUserName", "") == this.TxtUserName.Text) &&
				(Util.ReadString("AdminPassword", "") == this.TxtPassword.Text))
			{
				//	This is the main admin user for the application.

				FormsAuthentication.RedirectFromLoginPage("0", true);
			}

			ClassUser oUsr = new ClassUser();
			Int32 UserId = oUsr.Logon(this.TxtUserName.Text, this.TxtPassword.Text);


			if (UserId > 0)
			{
				//	We've found the user.

				FormsAuthentication.RedirectFromLoginPage(UserId.ToString(), true);
			}

			//	User not found!

			this.RowMessage.Visible = true;
			this.LblMsg.Text = "User Not Found!";
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}
	}
}
