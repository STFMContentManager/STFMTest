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

public partial class PayPal : System.Web.UI.Page
{
	const string TXT_PAGETITLE = "Voluntary Contribution";

	protected void Page_Load(object sender, EventArgs e)
    {
		Page.Title = TXT_PAGETITLE;
		this.LblPageTitle.Text = TXT_PAGETITLE;
    }
}
