//	---------------------------------------------------------------------------
//	$Filename$
//	$Revision$
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
using System.Text;

public partial class Contact : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Administrator Message";

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

			if (Request.UrlReferrer != null)
			{
				ViewState["Referer"] = Request.UrlReferrer.ToString();
			}
			else
			{
				ViewState["Referer"] = "Default.aspx";
			}

			Int32 UserId;

			Int32.TryParse(ViewState["UserId"].ToString(), out UserId);

			ClassUser oUsr = new ClassUser(UserId);

			this.TxtUserName.Text = string.Format("{0} {1}", oUsr.Forename, oUsr.Surname);
			this.TxtEmail.Text = oUsr.EmailAddress;

			this.TxtUserName.Focus();
		}
	}
	#endregion

	#region Button events
	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		System.Text.RegularExpressions.Regex oReg = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,4})$");

		if (oReg.IsMatch(this.TxtEmail.Text) == true)
		{
			//	Email address given by the user appears to be valid.

			ClassSmtp oSmtp = new ClassSmtp();
			string AdminEmail = Util.ReadString("AdminEmail", "");
			StringBuilder oStr = new StringBuilder("");

			oStr.Append("<table>");
			oStr.Append("<tr>");
			oStr.Append("<td>");
			oStr.Append("User name:");
			oStr.Append("</td>");
			oStr.Append("<td>");
			oStr.Append(this.TxtUserName.Text);
			oStr.Append("</td>");
			oStr.Append("</tr>");
			oStr.Append("<tr>");
			oStr.Append("<td>");
			oStr.Append("Telephone:");
			oStr.Append("</td>");
			oStr.Append("<td>");
			oStr.Append(this.TxtTelephone.Text);
			oStr.Append("</td>");
			oStr.Append("</tr>");
			oStr.Append("<tr>");
			oStr.Append("<td>");
			oStr.Append("Email:");
			oStr.Append("</td>");
			oStr.Append("<td>");
			oStr.Append(this.TxtEmail.Text);
			oStr.Append("</td>");
			oStr.Append("</tr>");
			oStr.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
			oStr.Append("<tr>");
			oStr.Append("<td>");
			oStr.Append("Subject:");
			oStr.Append("</td>");
			oStr.Append("<td>");
			oStr.Append(this.TxtSubject.Text);
			oStr.Append("</td>");
			oStr.Append("</tr>");
			oStr.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
			oStr.Append(string.Format("<tr><td colspan='2'>{0}</td></tr>", this.TxtBody.Text));
			oStr.Append("</table>");

			oSmtp.SendEmail(AdminEmail, "Message from TimeRep", oStr.ToString(), true);

			//	Having sent the email we provide a message to the user that the request
			//	has been completed.

			this.BtnCancel.Text = "Return";
			this.BtnSubmit.Enabled = false;
			this.TxtUserName.Enabled = false;
			this.TxtTelephone.Enabled = false;
			this.TxtEmail.Enabled = false;
			this.TxtSubject.Enabled = false;
			this.TxtBody.Enabled = false;
			this.RowMsg1.Visible = true;
			this.RowMsg2.Visible = true;
			this.LblMsg.Text = "Message has been sent!";
		}
		else
		{
			//	The email address given by the user is invalid.

			this.RowMsg1.Visible = true;
			this.RowMsg2.Visible = true;
			this.LblMsg.Text = "Invalid email address given - message not sent!";
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect(ViewState["Referer"].ToString(), true);
	}
	#endregion
}
