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
            String qstring = "Select Vol, Num, PublishDate FROM FMIssue WHERE ID =" + x;
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

            return x;
        }
    }
}