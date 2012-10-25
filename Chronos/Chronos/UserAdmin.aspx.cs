//	---------------------------------------------------------------------------
//	$Filename: D:\Inetpub\wwwroot\TimeRep\UserAdmin.aspx.cs $
//	$Revision: 1.3 $
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
using System.Text.RegularExpressions;

public partial class UserAdmin : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "User Administration";

	#region Page events
	protected void Page_PreInit(object sender, EventArgs e)
	{
		//	Get user ID and store in ViewState.

		ViewState["UserId"] = Page.User.Identity.Name.ToString();
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			Page.Title = TXT_PAGETITLE;
			this.LblPageTitle.Text = TXT_PAGETITLE;

			ClassUser oUsr = new ClassUser(Convert.ToInt32(ViewState["UserId"].ToString()));

			this.TxtSurname.Text = oUsr.Surname;
			this.TxtForename.Text = oUsr.Forename;
			this.TxtEmail.Text = oUsr.EmailAddress;

			this.TxtSurname.Focus();
		}
	}
	#endregion

	#region Button events
	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		ClassUser oUsr = new ClassUser(Convert.ToInt32(ViewState["UserId"].ToString()));

		if (this.TxtOld.Text.Length > 0)
		{
			//	User has entered their old password.

			if (this.TxtOld.Text.Trim() != oUsr.Password)
			{
				//	Old passwords don't match.

				this.LblMsg.Text = "Old Password Does Not Match!";
			}
			else if (this.TxtNew1.Text.Trim() != this.TxtNew2.Text.Trim())
			{
				//	Both copies of new password are different.

				this.LblMsg.Text = "New Passwords Do Not Match!";
			}
			else
			{
				Boolean bOkay = true;

				//if (Util.ReadString("PasswordRegExp", "").Length > 0)
				//{
				//	//	User has to supply a password which meets a regular expression check.
                //
				//	Regex oReg = new Regex(Util.ReadString("PasswordRegExp", ""));
                //
				//	bOkay = oReg.IsMatch(this.TxtNew1.Text);
				//}

				if (bOkay == true)
				{
					oUsr.Surname = this.TxtSurname.Text;
					oUsr.Forename = this.TxtForename.Text;
					oUsr.Password = this.TxtNew1.Text.Trim();
					oUsr.EmailAddress = this.TxtEmail.Text;
					oUsr.Save(oUsr.UserId);
					this.LblMsg.Text = "Updates Applied!";
				}
				else
				{
					this.LblMsg.Text = "Password Fails Regular Expression Check!";
				}
			}
		}
		else
		{
			//	User did not enter their old password, so change the email address.

			oUsr.Surname = this.TxtSurname.Text;
			oUsr.Forename = this.TxtForename.Text;
			oUsr.EmailAddress = this.TxtEmail.Text;
			oUsr.Save(oUsr.UserId);

			this.LblMsg.Text = "Updates Applied!";
		}

		this.RowMsg1.Visible = true;
		this.RowMsg2.Visible = true;
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("Default.aspx", true);
	}
	#endregion
}
