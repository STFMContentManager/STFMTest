using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FMHubAdmin
{
    public class RetrieveFM
    {
        SqlConnection GetFM = new SqlConnection(ConfigurationManager.AppSettings["ISISConnection"].ToString());

        public string RetrieveIssue(string x)
        {
            string issueinfo = "";

            GetFM.Open();
            string qstring = "Select Vol, Num, PublishDate FROM FMIssue WHERE ID =" + x;
            qstring += " Order By PublishDate";
            SqlDataAdapter IssueQry = new SqlDataAdapter(qstring, GetFM);
            DataSet FMIssue = new DataSet("This_Issue");
            IssueQry.Fill(FMIssue, "This_Issue");

            //issueinfo = 
            issueinfo = "Family Medicine Journal Volume " + FMIssue.Tables[0].Rows[0].Field<int>("Vol").ToString();
            issueinfo += " Issue " + FMIssue.Tables[0].Rows[0].Field<int>("Num").ToString();
            issueinfo += " " + FMIssue.Tables[0].Rows[0].Field<DateTime>("PublishDate").Month;
            issueinfo += "/" + FMIssue.Tables[0].Rows[0].Field<DateTime>("PublishDate").Year;

            GetFM.Close();

            return issueinfo;
        }

        public DataSet RetrieveArticle(string x)
        {
            GetFM.Open();
            string qstring = "Select Title as 'Added Articles', ID FROM FMArticle "; 
            qstring += "Where IssueID =" + x;
            qstring += " ORDER BY StartPage";
            SqlDataAdapter ArticleQry = new SqlDataAdapter(qstring, GetFM);
            DataSet FMArticle = new DataSet("Articles");
            ArticleQry.Fill(FMArticle, "Articles");

            GetFM.Close();

            return FMArticle;
        }

        public DataSet RetrieveAuthor(string x)
        {
            GetFM.Open();
            string qstring = "Select FName + ' ' + MName + ' ' + LName + ', ' + Organization as AuthorName FROM FMAuthor ";
            qstring += "Where ArticleID =" + x;
            qstring += " ORDER BY PublishOrder";
            SqlDataAdapter AuthorQry = new SqlDataAdapter(qstring, GetFM);
            DataSet FMAuthors = new DataSet("Authors");
            AuthorQry.Fill(FMAuthors, "Authors");

            GetFM.Close();

            return FMAuthors;
        }

        public string RetrieveTitle(string x)
        {
            GetFM.Open();

            string qstring = "Select Title FROM FMArticle WHERE ID =" + x;

            SqlCommand TitleCom = new SqlCommand(qstring, GetFM);
            TitleCom.CommandType = System.Data.CommandType.Text;

            x = TitleCom.ExecuteScalar().ToString();

            GetFM.Close();

            return x;
        }

        public DataSet GetIssue(string x)
        {
            GetFM.Open();
            string qstring = "";

            qstring = "SELECT ID, PublishDate, Vol, Num, PDFPath FROM FMIssue Where ID =" + x;
            SqlDataAdapter Get_Issue = new SqlDataAdapter(qstring, GetFM);
            DataSet Get_DisplayIssue = new DataSet("Issue");
            Get_Issue.Fill(Get_DisplayIssue, "Issue");

            Get_Issue.Dispose();

            qstring = "SELECT FMArticle.ID,Title, IssueID, [Subject], StartPage, Abstract, PDFPath + '\\' + FilePDF as FilePath, EndPage";
            qstring += " FROM FMArticle INNER JOIN FMIssue ON FMIssue.ID = FMArticle.IssueID";
            qstring += " WHERE IssueID=" + x;
            qstring += " Order By StartPage";

            SqlDataAdapter Get_Article = new SqlDataAdapter(qstring, GetFM);
            Get_DisplayIssue.Tables.Add("Article");
            Get_Article.Fill(Get_DisplayIssue, "Article");

            Get_Article.Dispose();

            qstring = "SELECT IssueID, FMAuthor.ID as AuthorID, ArticleID,FName, LName, PublishOrder, StartPage, MName";
            qstring += " FROM FMArticle INNER JOIN FMAuthor ON FMArticle.ID = FMAuthor.ArticleID WHERE IssueID=" + x;
            qstring += " ORDER BY StartPage, PublishOrder";

            SqlDataAdapter Get_Authors = new SqlDataAdapter(qstring, GetFM);
            Get_DisplayIssue.Tables.Add("Authors");
            Get_Authors.Fill(Get_DisplayIssue, "Authors");

            Get_Authors.Dispose();

            GetFM.Close();
                        
            return Get_DisplayIssue;
        }
        public DataSet Main_DisplayIssue()
        {
            GetFM.Open();
            string qstring = "Select Top 10 ID,'Vol. ' + Cast(Vol as varchar) + ' No. ' + Cast(Num as varchar) as Title, ";
            qstring += "DATENAME(month, PublishDate) + ' ' + cast(datepart(yy, PublishDate) as varchar) as PublishDate";
            qstring += " FROM FMIssue WHERE Published = 1 Order By PublishDate";
            SqlDataAdapter IssueQry = new SqlDataAdapter(qstring, GetFM);
            DataSet FMIssue = new DataSet("This_Issue");
            IssueQry.Fill(FMIssue, "This_Issue");

            GetFM.Close();

            return FMIssue;
        }

    }
}