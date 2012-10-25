using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FMHubAdmin;
using System.Data;

namespace STFMPlatformTransition.Controls
{
    public partial class FMJournal : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RetrieveFM Display_Issue = new RetrieveFM();
            DataSet FM_Issue = new DataSet();
            FM_Issue = Display_Issue.GetIssue(Request.QueryString["IssueID"].ToString());
                       
            string WriteTOC = "";
            //DateTime GetMonth = ;

            WriteTOC += "<p class='IssueHead'>" + Convert.ToDateTime(FM_Issue.Tables[0].Rows[0][1]).ToString("MMMM yyyy") + "</br>";
            WriteTOC += "Volume " + FM_Issue.Tables[0].Rows[0][2] + " Issue " + FM_Issue.Tables[0].Rows[0][3] + "</p>";            

            for (int i = 0; i < FM_Issue.Tables[1].Rows.Count; i++)
            {
                if ((i > 0 && FM_Issue.Tables[1].Rows[i][3].ToString() != FM_Issue.Tables[1].Rows[i - 1][3].ToString()) || i == 0)
                {
                    WriteTOC += "<p class='articletype'>" + FM_Issue.Tables[1].Rows[i][3].ToString().ToUpper() + "</p>";
                }

                //WriteTOC += "<p>" + FM_Issue.Tables[0].Rows[i][3] + "</p>";
                WriteTOC += "<p class='title'>" + FM_Issue.Tables[1].Rows[i][1] + "</p>";

                DataRow[] Authors = FM_Issue.Tables[2].Select("ArticleID = " + FM_Issue.Tables[1].Rows[i][0]);

                WriteTOC += "<p class='author'>";
                for (int x = 0; x < Authors.Length; x++)
                {
                    WriteTOC += Authors[x][3] + " ";
                    if (string.IsNullOrEmpty(Authors[x][7].ToString()) == false) { WriteTOC += Authors[x][7] + " "; }

                    if (x != (Authors.Length - 1))
                    {
                        WriteTOC += Authors[x][4] + ", ";
                    }
                    else
                    {
                        WriteTOC += Authors[x][4] + "</p>";
                    }
                }

                WriteTOC += "<p><a id='Abstract-" + FM_Issue.Tables[1].Rows[i][0] + "' href='#'>Show Abstract</a> | ";

                string filepath = Server.MapPath("") + "\\FMPDFS\\";
                filepath += FM_Issue.Tables[1].Rows[i][6].ToString();
                WriteTOC += "<a href='"+"FMPDFS/" + FM_Issue.Tables[1].Rows[i][6].ToString()+"'>PDF</a></p>";
                WriteTOC += "<div id='div-" + FM_Issue.Tables[1].Rows[i][0] + "' style='display:none;'>" + FM_Issue.Tables[1].Rows[i][5] + "</div>";
            }

            FM_TOC_Display.Text = WriteTOC;
            
        }

    }
        
}