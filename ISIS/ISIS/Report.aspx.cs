using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISIS
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GoHome(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void ManageProjects(object sender, EventArgs e)
        {
            Response.Redirect("ManageProjects.aspx");
        }
    }
}