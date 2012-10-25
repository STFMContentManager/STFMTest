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

public partial class Configuration : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Configuration";

	protected void Page_Load(object sender, EventArgs e)
    {
		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			Page.Title = TXT_PAGETITLE;
			this.LblPageTitle.Text = TXT_PAGETITLE;

			try
			{
				this.DdlSendMethod.SelectedValue = Util.AttributeLoad("SendMethod", "");
			}

			catch (Exception)
			{
				//	This is not an error - it just means that the
				//	send method isn't available in the drop down
				//	listbox.
			}

			this.TxtCompanyName.Text = Util.AttributeLoad("CompanyName", "Your Co");
			this.TxtFrom.Text = Util.AttributeLoad("FromEmail", "");
			this.TxtSmtpServer.Text = Util.AttributeLoad("SmtpServer", "");
			this.TxtPortNo.Text = Util.AttributeLoad("SmtpPortNo", "25");
			this.TxtUserName.Text = Util.AttributeLoad("SmtpUserName", "");
			this.TxtUserName.TextMode = TextBoxMode.Password;

			string TxtStr = Util.AttributeLoad("SmtpUserName", "");

			if (TxtStr.Length < 8)
				TxtStr = TxtStr.PadRight(8);

			this.TxtUserName.Text = TxtStr;
			this.TxtUserName.TextMode = TextBoxMode.Password;
			this.TxtUserName.Attributes.Add("value", TxtStr);

			TxtStr = Util.AttributeLoad("SmtpPassword", "");

			if (TxtStr.Length < 8)
				TxtStr = TxtStr.PadRight(8);

			this.TxtPassword.Text = TxtStr;
			this.TxtPassword.TextMode = TextBoxMode.Password;
			this.TxtPassword.Attributes.Add("value", TxtStr);

			this.TxtCompanyName.Focus();
		}
	}

	private void ShowMessage(string Msg)
	{
		//	Show message.

		try
		{
			this.TblMessage.Visible = true;
			this.LblMsg.Text = Msg;
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		//	Submit button.

		Util.AttributeSave("CompanyName", this.TxtCompanyName.Text);
		Util.AttributeSave("SendMethod", this.DdlSendMethod.SelectedValue);
		Util.AttributeSave("FromEmail", this.TxtFrom.Text);
		Util.AttributeSave("SmtpServer", this.TxtSmtpServer.Text);
		Util.AttributeSave("SmtpPortNo", this.TxtPortNo.Text);
		Util.AttributeSave("SmtpUserName", this.TxtUserName.Text);
		Util.AttributeSave("SmtpPassword", this.TxtPassword.Text);

		ShowMessage("Parameters Saved!");
		this.BtnSubmit.Enabled = false;
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("Default.aspx", true);
	}
}
