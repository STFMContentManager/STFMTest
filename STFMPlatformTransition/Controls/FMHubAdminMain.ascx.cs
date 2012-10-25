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
            FM_Published.DataSource = PublishedDisplay.Main_DisplayIssue(1).Tables[0];
            FM_Published.DataBind();

            PublishedDisplay = null;

            RetrieveFM Not_PublishedDisplay = new RetrieveFM();
            FM_Unpublished.DataSource = Not_PublishedDisplay.Main_DisplayIssue(0).Tables[0];
            FM_Unpublished.DataBind();
        }

        protected void Edit_FM(object sender, EventArgs e)
        {
            LinkButton EditFMIssue = new LinkButton();
            EditFMIssue = (LinkButton)sender;

            Response.Redirect("FMHubAdmin.aspx?Step=2&IssueID=" + EditFMIssue.CssClass.ToString());
        }
        //private string DeleteItem(string x, LinkButton y)
        //{

        //}


    }
}