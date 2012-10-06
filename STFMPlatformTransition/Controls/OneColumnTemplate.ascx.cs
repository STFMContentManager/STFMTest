using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STFMPlatformTransition
{
    public partial class OneColumnTemplate1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //string sCallingPage = Request.Url.AbsolutePath.Replace("/", "").Replace(".aspx", "").Replace("deepcleansing", "");

                string[] sCallingPageVal = Request.Url.AbsolutePath.Split('/');
                string sCallingPage = sCallingPageVal[sCallingPageVal.Length - 1].Replace(".aspx", "");

                if (sCallingPage != "OneColumnTemplate")
                {
                    CMSWork cms = new CMSWork();
                    List<Content> s = cms.GetPageContent(sCallingPage);

                    if (Session["IsLoggedIn"] == null || Session["IsLoggedIn"].ToString() == "" || Session["IsLoggedIn"].ToString() == "false")
                    {
                        if (s.Count <= 0)
                        {
                            s = null;
                            Response.Redirect("~/PageUnavailable.aspx");
                        }
                    }

                    Session["CurrentPageContent"] = s;

                    Session["CallingPage"] = sCallingPage;

                    cms = null;

                    string sMiddleColumn = "";

                    lbSaveMiddleColumn.CommandArgument = "0," + 2 + "," + sCallingPage + "," + sCallingPage;

                    foreach (Content c in s)
                    {
                        switch (c.Placement.ToString())
                        {
                            case "2":
                                {
                                    lbSaveMiddleColumn.CommandArgument = c.ID.ToString() + "," + c.Placement.ToString() + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbPublishMiddleColumn.CommandArgument = c.ID.ToString(); // + "," + c.Placement.ToString() + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbDeactivateMiddleColumn.CommandArgument = c.ID.ToString(); // + "," + 2 + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    sMiddleColumn = c.PageContent.ToString().Trim();

                                    if (c.Active == 1)
                                    {
                                        lbPublishMiddleColumn.Visible = false;
                                    }

                                    break;
                                }
                        }
                    }

                    if ((Session["IsLoggedIn"] != null && Session["IsLoggedIn"].ToString() != "") && Session["IsLoggedIn"].ToString() == "true")
                    {


                        if ((Session["ViewMode"] != null && Session["ViewMode"].ToString() != "") && Session["ViewMode"].ToString() == "Normal")
                        {

                            ftbMiddleColumn.Text = sMiddleColumn;

                            tabDisplay.Visible = false;
                            tabCMSDisplay.Visible = true;
                        }
                        else
                        {
                            lblMiddleColumn.Text = sMiddleColumn;

                            tabDisplay.Visible = true;
                            tabCMSDisplay.Visible = false;
                        }
                    }
                    else
                    {
                        lblMiddleColumn.Text = sMiddleColumn;

                        tabDisplay.Visible = true;
                        tabCMSDisplay.Visible = false;
                    }

                }
                else
                {

                    lblMiddleColumn.Text = "";
                    lblMiddleColumn.Height = Unit.Pixel(500);
                    lblMiddleColumn.Width = Unit.Percentage(100);
                    lblMiddleColumn.BackColor = System.Drawing.Color.White;

                    ftbMiddleColumn.Text = "";

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
            string SectionName = SaveValues[3].ToString();
            string Content = "";

            switch (lb.ID.ToString())
            {
                case "lbSaveMiddleColumn":
                    {
                        PlacementID = 2;
                        Content = ftbMiddleColumn.Text.ToString().Trim();
                        break;
                    }
            }

            Content c = new Content();

            c.ID = ContentID;
            c.Placement = PlacementID;
            c.Page = ObjectName;
            c.Section = SectionName;
            c.PageContent = Content;
            c.User = Session["UserID"].ToString();
            c.TransDateTime = DateTime.Now;
            //c.Active = 1; //add check box to page to determine if user wants this content to be active or not

            lb = null;

            CMSWork cms = new CMSWork();
            cms.SavePageContent(c);
            cms = null;

            string sPage = c.Page + ".aspx";

            c = null;

            Response.Redirect(sPage);
        }

        public void PublishContent(object sender, EventArgs e)
        {
            int iContentID = Convert.ToInt32(((LinkButton)sender).CommandArgument);

            CMSWork cms = new CMSWork();
            cms.PublishContent(iContentID);
            cms = null;
        }

        public void DeactivateContent(object sender, EventArgs e)
        {
            int iContentID = Convert.ToInt32(((LinkButton)sender).CommandArgument);

            CMSWork cms = new CMSWork();
            cms.DeactivateContent(iContentID);
            cms = null;
        }
    }
}