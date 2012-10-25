using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STFMPlatformTransition.Controls
{
    public partial class MemberDirectorySearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShowSearchResults(object sender, EventArgs e)
        {
            tabResults.Visible = true;
            tabMain.Visible = false;
        }
    }
}