using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STFMPlatformTransition
{
    public partial class TwoColumnTemplate1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string sCallingPage = Request.Url.AbsolutePath.Replace("/", "").Replace(".aspx", "");

                //lbSaveHeaderLinks.CommandArgument = "0,0," + sCallingPage;
                lbSaveLeftColumn.CommandArgument = "0,0," + sCallingPage;

                if (sCallingPage != "TwoColumnTemplate")
                {
                    CMSWork cms = new CMSWork();
                    List<Content> s = cms.GetPageContent(sCallingPage);
                    cms = null;

                    string sHeaderLinks = "";
                    string sLeftColumn = "";
                    string sRightColumn = "";

                    foreach (Content c in s)
                    {
                        switch (c.Placement.ToString())
                        {
                            case "0":
                                {
                                    //lbSaveHeaderLinks.CommandArgument = c.ID.ToString() + "," + c.Placement.ToString() + "," + c.Page.ToString();
                                    sHeaderLinks = c.PageContent.ToString().Trim();
                                    break;
                                }
                            case "1":
                                {
                                    lbSaveLeftColumn.CommandArgument = c.ID.ToString() + "," + c.Placement.ToString() + "," + c.Page.ToString();
                                    sLeftColumn = c.PageContent.ToString().Trim();
                                    break;
                                }
                            case "3":
                                {
                                    lbSaveLeftColumn.CommandArgument = c.ID.ToString() + "," + c.Placement.ToString() + "," + c.Page.ToString();
                                    sRightColumn = c.PageContent.ToString().Trim();
                                    break;
                                }
                        }
                    }

                    if ((Session["IsLoggedIn"] != null && Session["IsLoggedIn"].ToString() != "") && Session["IsLoggedIn"].ToString() == "true")
                    {

                        //ftbHeaderLinks.Text = sHeaderLinks;
                        ftbLeftColumn.Text = sLeftColumn;
                        ftbRightColumn.Text = sRightColumn;

                        tabDisplay.Visible = false;
                        tabCMSDisplay.Visible = true;
                    }
                    else
                    {
                        //lblHeaderLinks.Text = sHeaderLinks;
                        lblLeftColumn.Text = sLeftColumn;
                        lblRightColumn.Text = sRightColumn;

                        tabDisplay.Visible = true;
                        tabCMSDisplay.Visible = false;
                    }

                }
                else
                {
                    //lblHeaderLinks.Text = "";

                    lblLeftColumn.Text = "";
                    lblLeftColumn.Height = Unit.Pixel(500);
                    lblLeftColumn.Width = Unit.Percentage(100);
                    lblLeftColumn.BackColor = System.Drawing.Color.Blue;

                    lblRightColumn.Text = "";
                    lblRightColumn.Height = Unit.Pixel(500);
                    lblRightColumn.Width = Unit.Percentage(100);
                    lblRightColumn.BackColor = System.Drawing.Color.Blue;

                    //ftbHeaderLinks.Text = "";
                    ftbLeftColumn.Text = "";
                    ftbRightColumn.Text = "";

                    tabDisplay.Visible = true;
                    tabCMSDisplay.Visible = false;
                }
            }

        }

        public void SaveContent(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;

            string[] SaveValues = lb.CommandArgument.Split(',');

            int ContentID = Convert.ToInt32(SaveValues[0].ToString());
            int PlacementID = Convert.ToInt32(SaveValues[1].ToString());
            string ObjectName = SaveValues[2].ToString();
            string Content = "";

            switch (ObjectName)
            {
                //case "HeaderLinks":
                //    {
                //        Content = ftbHeaderLinks.Text.ToString().Trim();
                //        break;
                //    }

                case "AboutUs":
                    {
                        switch (PlacementID)
                        {
                            case 1:
                                {
                                    Content = ftbLeftColumn.Text.ToString().Trim();
                                    break;
                                }
                            case 3:
                                {
                                    Content = ftbRightColumn.Text.ToString().Trim();
                                    break;
                                }
                        }

                        break;
                    }
            }

            Content c = new Content();

            c.ID = ContentID;
            c.Placement = PlacementID;
            c.Page = ObjectName;
            c.PageContent = Content;

            lb = null;

            CMSWork cms = new CMSWork();
            cms.SavePageContent(c);
            cms = null;

            c = null;
        }
    }
}