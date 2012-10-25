using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISIS.Controls
{
    public partial class FullInventoryReport : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ISISLogic iLogic = new ISISLogic();

            List<Project> objProjects = iLogic.GetAllProjects();

            repReports.DataSource = objProjects;
            repReports.DataBind();

            iLogic = null;
        }
    }
}