using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using STFMDBAccess;
using FMHubAdmin;
using System.IO;

namespace STFMPlatformTransition.Controls
{
    public partial class FMHubAdmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["Admin"]) == true)
            {
                if (string.IsNullOrEmpty(Request.QueryString["Step"]) == true)
                {
                    PageSetup("1");
                }
                else
                {
                    PageSetup(Request.QueryString["Step"]);
                }
            }
            else
            {
                pnlAddArticles.Visible = true;
                pnlEditArticle.Visible = true;
                pnlIssueEntry.Visible = true;
                pnlAddAuthor.Visible = true;
            }
        }

        /*
         * All this does is retrieve the step value from the query string
         * and then gives that to the FMNavWork function where... work..
         * gets.. done.
         * 
         * After it receives the query string, it redirects the page and 
         * the page setup sets the page for the next step.
         */ 
        protected void FMHubNav(object sender, EventArgs e)
        {
            string Qry = Request.QueryString["Step"];
                       
            Qry = FMNavWork(Qry);

            Response.Redirect("FMHubAdmin.aspx" + Qry);
        }

        /*Here is where the database work gets done and the 
        query string gets written and returned to FMHubNav*/
        private string FMNavWork(string x)
        {
            //Handles writing the issue to the database
            
            if (string.IsNullOrEmpty(x) == true)
            {


                DateTime pubdate = new DateTime(Convert.ToInt16(tbyear.Text), Convert.ToInt16(MonthDDL.SelectedValue), 1);
                PassDB Issue = new PassDB();
                SqlParameter[] IssueParams =
                {
                    new SqlParameter("PubDate", pubdate),
                    new SqlParameter("Vol", Convert.ToInt16(tbvolume.Text)),
                    new SqlParameter("Num", Convert.ToInt16(tbissue.Text))
                };
                               
                return "?Step=2" + "&IssueID=" + Issue.SQLReturnData(IssueParams, "FMAddIssue").ToString();
            }

            if (Request.QueryString["Step"] == "3")
            {
                x = "2";                
            }

            if (Request.QueryString["Step"] == "4")
            {
                PassDB GetIssue = new PassDB();
                string qstring = "Select IssueID FROM FMArticle WHERE ID =";
                qstring += Request.QueryString["ArticleID"];
                return "?Step=2&IssueID=" + GetIssue.SQLReturnData(qstring);
            }

            return "?Step=" + x + "&IssueID=" + Request.QueryString["IssueID"];
        }

        //This takes the user to the add article interface
        protected void AddArticle(object sender, EventArgs e)
        {
            Response.Redirect("FMHubAdmin.aspx?Step=3&IssueID=" + Request.QueryString["IssueID"]);
        }

        protected void InsertAndClearArticle(object sender, EventArgs e)
        {
            ArticleToDB();
        }

        protected void InsertAndClearAuthor(object sender, EventArgs e)
        {
            AuthorToDB();
            AuthorList();
        }

        public void PageSetup(string x)
        {
            switch (x)
            {
                case "1":
                    {
                        pnlIssueEntry.Visible = true;
                        lbnNavigate.Text = "Next";
                        break;
                    }
                case "2":
                    {
                        RetrieveFM Get_Issue = new RetrieveFM();
                        lblArticleHead.Text = Get_Issue.RetrieveIssue(Request.QueryString["IssueID"]);

                        DataSet LoadArticles = new DataSet();
                        LoadArticles = Get_Issue.RetrieveArticle(Request.QueryString["IssueID"]);

                        if (LoadArticles.Tables[0].Rows.Count != 0)
                        {                           
                            dgArticleList.DataSource = LoadArticles;
                            dgArticleList.DataBind();
                        }                        

                        pnlAddArticles.Visible = true;
                        lbnNavigate.Text = "Finish Issue";
                        break;
                    }
                case "3":
                    {
                        pnlEditArticle.Visible = true;
                        lbnNavigate.Text = "Return to Issue";
                        break;
                    }
                case "4":
                    {
                        RetrieveFM GetTitle = new RetrieveFM();
                        AuthorList();
                        //DataSet LoadAuthors = new DataSet();
                        //LoadAuthors = GetTitle.RetrieveAuthor(Request.QueryString["ArticleID"]);
                        //if (LoadAuthors.Tables[0].Rows.Count != 0)
                        //{
                        //    dgAuthorList.DataSource = LoadAuthors;
                        //    dgAuthorList.DataBind();
                        //}

                        lblAuthorHeader.Text = GetTitle.RetrieveTitle(Request.QueryString["ArticleID"]);
                        pnlAddAuthor.Visible = true;
                        lbnNavigate.Text = "Return to Issue";
                        break;
                    }
            }
        }

        private void ArticleToDB()
        {
            PassDB Article = new PassDB();
            SqlParameter[] ArticleParams = 
                {
                    new SqlParameter("IssueID", Convert.ToInt16(Request.QueryString["IssueID"])),
                    new SqlParameter("Title", tbTitle.Text),
                    new SqlParameter("Subject", tbsubject.Text),
                    new SqlParameter("Start", Convert.ToInt16(tbStart.Text)),
                    new SqlParameter("End", Convert.ToInt16(tbEnd.Text)),
                    new SqlParameter("Abstract", tbAbstract.Text)
                };

            Article.SQLReturnVoid(ArticleParams, "FMAddArticle");

            int length = 0;
            //FileStream ArticleFile;

            length = inptArticle.PostedFile.ContentLength;
            byte[] ArticleDoc = new byte[length];
            inptArticle.PostedFile.InputStream.Read(ArticleDoc, 0, length);
            string[] ArticleDocFileNameVals = inptArticle.Value.Split('\\');
            string ArticleFileName = ArticleDocFileNameVals[ArticleDocFileNameVals.Length - 1].ToString();

            HttpPostedFile ArticlePDF;

            if (inptArticle.Value.ToString().Trim() != "")
            {
                ArticlePDF = inptArticle.PostedFile;
                ArticlePDF.SaveAs(Server.MapPath("~/" + ArticlePDF));
            }

            tbTitle.Text = "";
            tbsubject.Text = "";
            tbStart.Text = "";
            tbEnd.Text = "";
            tbAbstract.Text = "";
            inptArticle.Value = "";
        }

        private void AuthorToDB()
        {
            PassDB Author = new PassDB();
            SqlParameter[] AuthorParams = 
            {
                new SqlParameter("ArticleID", Convert.ToInt16(Request.QueryString["ArticleID"])),
                new SqlParameter("Fname", tbfname.Text),
                new SqlParameter("MName", tbmname.Text),
                new SqlParameter("Lname", tblname.Text),
                new SqlParameter("Org", tborganization.Text)
            };

            Author.SQLReturnVoid(AuthorParams, "FMAddAuthor");
            tbfname.Text = "";
            tbmname.Text = "";
            tblname.Text = "";
            tborganization.Text = "";
        }

        private void AuthorList()
        {
            RetrieveFM GetAuthors = new RetrieveFM();

            DataSet LoadAuthors = new DataSet();
            LoadAuthors = GetAuthors.RetrieveAuthor(Request.QueryString["ArticleID"]);
            if (LoadAuthors.Tables[0].Rows.Count != 0)
            {
                dgAuthorList.DataSource = LoadAuthors;
                dgAuthorList.DataBind();
            }
        }
    }
}