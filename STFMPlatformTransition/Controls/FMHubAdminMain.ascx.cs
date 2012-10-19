using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FMHubAdmin;
using STFMDBAccess;
using System.Data.SqlClient;


namespace STFMPlatformTransition.Controls
{
    public partial class FMHubAdminMain : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadRepeater();
        }
        protected void Delete_FM(object sender, EventArgs e)
        {
            LinkButton DeleteButton = new LinkButton();
            DeleteButton = (LinkButton)sender;

            string var = DeleteButton.CssClass;

            PassDB DeleteIssue = new PassDB();

            SqlParameter[] DeleteCommand = 
            {
                new SqlParameter("IssueID", DeleteButton.CssClass)
            };

            DeleteIssue.SQLReturnVoid(DeleteCommand, "FMDeleteIssue");
            LoadRepeater();
            
        }
        protected void View_FM(object sender, EventArgs e)
        {
            LinkButton ViewFMIssue = new LinkButton();
            ViewFMIssue = (LinkButton)sender;

            Response.Redirect("FMJournal.aspx?IssueID=" + ViewFMIssue.CssClass.ToString());

            ViewFMIssue.Dispose();
        }

        protected void LoadRepeater()
        {
            RetrieveFM PublishedDisplay = new RetrieveFM();
            FM_Published.DataSource = PublishedDisplay.Main_DisplayIssue().Tables[0];
            FM_Published.DataBind();
        }
        //private string DeleteItem(string x, LinkButton y)
        //{

        //}


    }
}