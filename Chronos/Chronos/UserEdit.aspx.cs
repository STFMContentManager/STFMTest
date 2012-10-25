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

public partial class UserEdit : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "User Edit";

	protected void Page_PreInit(object sender, EventArgs e)
	{
		//	Get user ID and store in ViewState.

		ViewState["UserId"] = Page.User.Identity.Name.ToString();

		if (ViewState["UserId"].ToString() != "0")
		{
			ClassUser oUsr = new ClassUser(Convert.ToInt32(Page.User.Identity.Name.ToString()));

			if ((oUsr.Permissions & (Int32)Enum.Permissions.Team) == 0)
			{
				//	User isn't allowed to do team management.

				Response.Redirect("Default.aspx", false);
			}
		}
	}

	protected void Page_Load(object sender, EventArgs e)
    {
		if (Page.IsPostBack == false)
		{
			//	First time initialisation.

			Page.Title = TXT_PAGETITLE;
			this.LblPageTitle.Text = TXT_PAGETITLE;

			if (Request.QueryString["UserId"] == null)
				Response.Redirect("UserMenu.aspx", true);

			ViewState["UserId"] = Request.QueryString["UserId"].ToString();

			ClassTeam oTm = new ClassTeam();

			this.DdlTeam.DataSource = oTm.ShowTeams1();
			this.DdlTeam.DataTextField = "TeamName";
			this.DdlTeam.DataValueField = "TeamId";
			this.DdlTeam.DataBind();

			this.DdlTeam.Items.Insert(0, new ListItem("-- Choose team --", "0"));

			ClassUser oUsr = new ClassUser(Convert.ToInt32(Request.QueryString["UserId"]));

			this.TxtUserName.Text = oUsr.UserName;

			string TxtStr = oUsr.Password;

			if (TxtStr.Length < 8)
				TxtStr = TxtStr.PadRight(8);

			this.TxtPassword.Text = TxtStr;
			this.TxtPassword.TextMode = TextBoxMode.Password;
			this.TxtPassword.Attributes.Add("value", TxtStr);

			this.TxtSurname.Text = oUsr.Surname;
			this.TxtForename.Text = oUsr.Forename;
			this.TxtEmailAddress.Text = oUsr.EmailAddress;
			this.TxtHourlyRate.Text = string.Format("{0:f}", oUsr.HourlyRate);
			ClassUserGroup oGrp = new ClassUserGroup();

			this.DdlUserGroup.DataSource = oGrp.ShowUserGroups();
			this.DdlUserGroup.DataTextField = "UserGroupName";
			this.DdlUserGroup.DataValueField = "UserGroupId";
			this.DdlUserGroup.DataBind();

			this.DdlUserGroup.Items.Insert(0, new ListItem("-- Choose user group --", "0"));

			try
			{
				this.DdlTeam.SelectedValue = oUsr.TeamId.ToString();
			}

			catch (Exception)
			{
				//	Do nothing - we don't need to worry about a team which
				//	can't be selected.
			}

			try
			{
				this.DdlUserGroup.SelectedValue = oUsr.UserGroupId.ToString();
			}

			catch (Exception)
			{
				//	Okay to error. The supplied user group id isn't in the
				//	dropdown listbox.
			}

			ClassProject oPrj = new ClassProject();
			DataSet oDs = oPrj.ShowProjectsWithUserMap(oUsr.UserId);

			this.ClstProjects.DataSource = oDs;
			this.ClstProjects.DataTextField = "ProjectName";
			this.ClstProjects.DataValueField = "ProjectId";
			this.ClstProjects.DataBind();

			foreach (DataRow oDr in oDs.Tables[0].Rows)
			{
				if (Convert.ToInt32(oDr["Selected"].ToString()) != 0)
				{
					ListItem oChk = this.ClstProjects.Items.FindByValue(oDr["ProjectId"].ToString());

					if (oChk != null)
					{
						oChk.Selected = true;
					}
				}
			}

			this.TxtUserName.Focus();
		}
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		ClassUser oUsr = new ClassUser();

		oUsr.TeamId = Convert.ToInt32(this.DdlTeam.SelectedValue);
		oUsr.UserName = this.TxtUserName.Text;
		oUsr.Password = this.TxtPassword.Text.Trim();
		oUsr.UserGroupId = Convert.ToInt32(this.DdlUserGroup.SelectedValue);
		oUsr.Surname = this.TxtSurname.Text;
		oUsr.Forename = this.TxtForename.Text;
		oUsr.EmailAddress = this.TxtEmailAddress.Text;

		try
		{
			oUsr.HourlyRate = (float) Math.Round(Convert.ToDouble(this.TxtHourlyRate.Text), 2);
		}

		catch (Exception)
		{
			//	User has entered non-numeric text. Default the hourly rate to zero.

			oUsr.HourlyRate = 0;
		}

		oUsr.Save(Convert.ToInt32(ViewState["UserId"]));

		//	Save the assigned projects.

		ClassProject oPrj = new ClassProject();

		oPrj.DeleteMapForUser(oUsr.UserId);

		foreach (ListItem oLst in this.ClstProjects.Items)
		{
			if (oLst.Selected == true)
			{
				oPrj.MapProjectToUser(oUsr.UserId, Convert.ToInt32(oLst.Value));
			}
		}

		Response.Redirect(string.Format("UserMenu.aspx?UserId={0}", oUsr.UserId), true);
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("UserMenu.aspx?UserId={0}", ViewState["UserId"].ToString()), true);
	}
}
