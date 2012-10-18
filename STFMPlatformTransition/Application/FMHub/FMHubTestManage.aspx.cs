using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using FMHubAdmin;

namespace STFMPlatformTransition.Application.FMHub
{
    public partial class FMHubTestManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void XMLIssue(object sender, EventArgs e)
        {
            

            DataSet XMLIssue = new DataSet();
            
            RetrieveFM FM_Get = new RetrieveFM();
            XMLIssue = FM_Get.GetIssue("33");

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;

            string filepath = Server.MapPath("") + "//FMPDFs//" + XMLIssue.Tables[0].Rows[0][4] + "//";
            filepath += "fammedvol" + XMLIssue.Tables[0].Rows[0][2].ToString() + "issue" + XMLIssue.Tables[0].Rows[0][3].ToString() + ".xml";

            using (XmlWriter FM_Issue = XmlWriter.Create(filepath,settings))
            {
                FM_Issue.WriteStartDocument();

                FM_Issue.WriteDocType("ArticleSet", "-//NLM//DTD PubMed 2.0//EN", "http://www.ncbi.nlm.nih.gov:80/entrez/query/static/PubMed.dtd", null);

                FM_Issue.WriteStartElement("ArticleSet");

                for (int i = 0; i < XMLIssue.Tables[1].Rows.Count; i++)
                {
                    FM_Issue.WriteStartElement("Article");
                    FM_Issue.WriteStartElement("Journal");
                        FM_Issue.WriteElementString("PublisherName", "Society of Teachers of Family Medicine");
                        FM_Issue.WriteElementString("JournalTitle", "Fam Med");
                        FM_Issue.WriteElementString("Issn", "0742-3225");
                        FM_Issue.WriteElementString("Volume", XMLIssue.Tables[0].Rows[0][2].ToString().Trim());
                        FM_Issue.WriteElementString("Issue", XMLIssue.Tables[0].Rows[0][3].ToString().Trim());

                        FM_Issue.WriteStartElement("PubDate");
                            FM_Issue.WriteElementString("Year", Convert.ToDateTime(XMLIssue.Tables[0].Rows[0][1]).Year.ToString());
                            FM_Issue.WriteElementString("Month", Convert.ToDateTime(XMLIssue.Tables[0].Rows[0][1]).Month.ToString());
                        FM_Issue.WriteEndElement();//End PubDate Element
                        
                    
                    FM_Issue.WriteEndElement(); //End Journal Element

                        FM_Issue.WriteElementString("ArticleTitle", XMLIssue.Tables[1].Rows[i][1].ToString());
                        FM_Issue.WriteElementString("FirstPage", XMLIssue.Tables[1].Rows[i][4].ToString());
                        FM_Issue.WriteElementString("LastPage", XMLIssue.Tables[1].Rows[i][7].ToString());
                        FM_Issue.WriteElementString("Language", "EN");

                        DataRow[] Authors = XMLIssue.Tables[2].Select("ArticleID = " + XMLIssue.Tables[1].Rows[i][0]);

                        FM_Issue.WriteStartElement("AuthorList");

                        for (int x = 0; x < Authors.Length; x++)
                        {
                            FM_Issue.WriteStartElement("Author");

                            FM_Issue.WriteElementString("FirstName", Authors[x][3].ToString());
                            FM_Issue.WriteElementString("LastName", Authors[x][4].ToString());

                            if (x == 0)
                            {
                                FM_Issue.WriteElementString("Affiliation", "FIX THIS LATER"); //YO, this this later <-
                            }

                            FM_Issue.WriteEndElement();
                        }

                        FM_Issue.WriteEndElement();
                        Authors = null;

                    FM_Issue.WriteElementString("Abstract", XMLIssue.Tables[1].Rows[i][5].ToString());
                                                

                    FM_Issue.WriteEndElement(); //End Article Element
                }

                FM_Issue.WriteEndElement();//End ArticleSet Element
                FM_Issue.WriteEndDocument();

            }
        }

    }
}