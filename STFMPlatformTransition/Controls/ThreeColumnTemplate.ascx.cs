using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STFMPlatformTransition
{
    public partial class ThreeColumnTemplate1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //string sCallingPage = Request.Url.AbsolutePath.Replace("/", "").Replace(".aspx", "").Replace("deepcleansing", "");

                string[] sCallingPageVal = Request.Url.AbsolutePath.Split('/');
                string sCallingPage = sCallingPageVal[sCallingPageVal.Length - 1].Replace(".aspx", "");

                if (sCallingPage != "ThreeColumnTemplate")
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

                    string sLeftColumn = "";
                    string sMiddleColumn = "";
                    string sRightColumn = "";

                    lbSaveLeftColumn.CommandArgument = "0, 0," + sCallingPage + ",";
                    lbSaveMiddleColumn.CommandArgument = "0, 0," + sCallingPage + ",";
                    lbSaveRightColumn.CommandArgument = "0, 0," + sCallingPage + ",";

                    foreach (Content c in s)
                    {
                        this.Page.Title = c.Title != "" ? c.Title : this.Page.Title;

                        switch (c.Placement.ToString())
                        {
                            case "-1":
                                {
                                    lbSaveLeftColumn.CommandArgument = c.ID.ToString() + "," + 1 + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbSaveMiddleColumn.CommandArgument = c.ID.ToString() + "," + 2 + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbSaveRightColumn.CommandArgument = c.ID.ToString() + "," + 3 + "," + c.Page.ToString() + "," + c.Section.ToString();

                                    lbPublishLeftColumn.CommandArgument = c.ID.ToString(); // +"," + 1 + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbPublishMiddleColumn.CommandArgument = c.ID.ToString(); // + "," + 2 + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbPublishRightColumn.CommandArgument = c.ID.ToString(); // + "," + 3 + "," + c.Page.ToString() + "," + c.Section.ToString();

                                    lbDeactivateLeftColumn.CommandArgument = c.ID.ToString(); // +"," + 1 + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbDeactivateMiddleColumn.CommandArgument = c.ID.ToString(); // + "," + 2 + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbDeactivateRightColumn.CommandArgument = c.ID.ToString(); // + "," + 3 + "," + c.Page.ToString() + "," + c.Section.ToString();

                                    lbRevertLeftColumn.CommandArgument = c.ID.ToString(); // +"," + 1 + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbRevertMiddleColumn.CommandArgument = c.ID.ToString(); // + "," + 2 + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbRevertRightColumn.CommandArgument = c.ID.ToString(); // + "," + 3 + "," + c.Page.ToString() + "," + c.Section.ToString();

                                    break;
                                }
                            case "1":
                                {
                                    lbSaveLeftColumn.CommandArgument = c.ID.ToString() + "," + c.Placement.ToString() + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbPublishLeftColumn.CommandArgument = c.ID.ToString(); // + "," + c.Placement.ToString() + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbDeactivateLeftColumn.CommandArgument = c.ID.ToString(); // +"," + 1 + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbRevertLeftColumn.CommandArgument = c.ID.ToString() + "," + c.Placement.ToString(); // +"," + 1 + "," + c.Page.ToString() + "," + c.Section.ToString();

                                    //string sFullPath = Request.ServerVariables["PATH_INFO"];
                                    //string[] sPathVals = sFullPath.Split('/');
                                    string sHREF = "href=\"" + sCallingPage + ".aspx" + "\"";
                                    string sHREFDefault = "<A class=\"LeftHandSideLinks\" ";
                                    string sHREFActive = "style=\"COLOR: #1D417B; font-weight:bold\" ";

                                    //sLeftColumn = c.PageContent.ToString().Trim();

                                    if ((Session["IsLoggedIn"] != null && Session["IsLoggedIn"].ToString() != "") && Session["IsLoggedIn"].ToString() == "true")
                                    {
                                        if ((Session["ViewMode"] == null || Session["ViewMode"].ToString() == "") || Session["ViewMode"].ToString() == "Preview")
                                        {
                                            sLeftColumn = c.PageContent.ToString().Trim().Replace(sHREF, " ");
                                            sLeftColumn = c.PageContent.ToString().Trim().Replace(sHREFDefault, " ");
                                            sLeftColumn = c.PageContent.ToString().Trim().Replace(sHREFActive, " ");
                                            sLeftColumn = c.PageContent.ToString().Trim().Replace("<A ", sHREFDefault);
                                            sLeftColumn = sLeftColumn.Replace(sHREF, sHREFActive); //c.PageContent.ToString().Trim().Replace(sHREF, sHREFActive);
                                            sLeftColumn = "<p style='color:#4d4d4d; text-align:left; font-family:verdana; font-size:14px; font-weight:bold; width:100%'>" + c.Section.ToString() + "</p>" + sLeftColumn;
                                        }
                                        else
                                        {
                                            sLeftColumn = c.PageContent.ToString().Trim();
                                        }
                                    }
                                    else
                                    {
                                        sLeftColumn = c.PageContent.ToString().Trim().Replace(sHREF, " ");
                                        sLeftColumn = c.PageContent.ToString().Trim().Replace(sHREFDefault, " ");
                                        sLeftColumn = c.PageContent.ToString().Trim().Replace(sHREFActive, " ");
                                        sLeftColumn = c.PageContent.ToString().Trim().Replace("<A ", sHREFDefault);
                                        sLeftColumn = sLeftColumn.Replace(sHREF, sHREFActive); //c.PageContent.ToString().Trim().Replace(sHREF, sHREFActive);
                                        sLeftColumn = "<p style='color:#4d4d4d; text-align:left; font-family:verdana; font-size:14px; font-weight:bold; width:100%'>" + c.Section.ToString() + "</p>" + sLeftColumn;
                                    }

                                    if (c.Active == 1)
                                    {
                                        lbPublishLeftColumn.Visible = false;
                                    }

                                    break;
                                }
                            case "2":
                                {
                                    lbSaveMiddleColumn.CommandArgument = c.ID.ToString() + "," + c.Placement.ToString() + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbPublishMiddleColumn.CommandArgument = c.ID.ToString(); // + "," + c.Placement.ToString() + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbDeactivateMiddleColumn.CommandArgument = c.ID.ToString(); // + "," + 2 + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbRevertMiddleColumn.CommandArgument = c.ID.ToString() + "," + c.Placement.ToString(); // + "," + 2 + "," + c.Page.ToString() + "," + c.Section.ToString();

                                    List<SectionNavigation> lstSN = Session["SectionNavigation"] as List<SectionNavigation>;
                                    
                                    /*CREATE BREADCRUMB VARIABLES*/
                                    List<string> Bcrumbs = new List<string>();
                                    string sBreadCrumbs = "<p>";

                                    //check to see if the breadcrumb session exists, and sets the bcrumb list to it if it exists
                                    if (Session["BreadCrumbs"] != null)
                                    {
                                        Bcrumbs = Session["BreadCrumbs"] as List<string>;
                                    }
                                    else
                                    {
                                        //If there is no breadcrumb session information, the apply the current section to the first item of the 
                                        //bcrumb list
                                        Bcrumbs.Add(c.Section);
                                    }

                                    //Check current section stored in breadcrumbs against the current section of the content page
                                    if (Bcrumbs[0].ToLower().Replace(" ", "") != c.Section.ToLower().Replace(" ", ""))
                                    { 
                                        //If they differ, set bcrumbs at index 0 to the current section, clear the rest of the list
                                        Bcrumbs[0]=(c.Section);
                                        for (int i = 1; i < Bcrumbs.Count; )
                                        {
                                            Bcrumbs.RemoveAt(i);
                                        }
                                    }

                                    //Checks to see if the calling page is the section head
                                    if (sCallingPage.ToLower().Replace(" ", "") != Bcrumbs[0].ToLower().Replace(" ", ""))
                                    {
                                        //Is there more in bcrumbs than just the section name?
                                        if (Bcrumbs.Count > 1)
                                        {
                                            //Loops through all the page names in the current section's navigation
                                            foreach (SectionNavigation sn in lstSN)
                                            {
                                                //If the navigation page and the calling page are the same continue
                                                if (sn.LinkURL.ToLower() == sCallingPage.ToLower())
                                                {
                                                    //Checks the calling page(which is our current navigation page) against the 
                                                    //value at index 1 of bcrumbs
                                                    if (sCallingPage.ToLower().Replace(" ", "") != Bcrumbs[1].ToLower().Replace(" ", ""))
                                                    {
                                                        //If they differ, the navigation page has been changed, the value at index 1 of bcrumbs is replaced,
                                                        //bcrumbs is emptied after that value
                                                        Bcrumbs[1] = sCallingPage;
                                                        for (int i = 2; i < Bcrumbs.Count; )
                                                        {
                                                            Bcrumbs.RemoveAt(i);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //If the calling page matches a navigation page, the assumption is made that 
                                                        //the user has navigated to a navigation page in the section.  The rest of the breadcrumbs
                                                        //are eliminated
                                                        for (int i = 2; i < Bcrumbs.Count; )
                                                        {
                                                            Bcrumbs.RemoveAt(i);
                                                        }
                                                    }
                                                }
                                            }

                                            //If the breadcrumb doesn't match the value at bcrumb[1] (if it were the navigation page, it will have
                                            //already been set to match), the calling page is appended to the end of the bcrumb list
                                            if (sCallingPage.ToLower().Replace(" ", "") != Bcrumbs[1].ToLower().Replace(" ",""))
                                            {
                                                Bcrumbs.Add(sCallingPage);
                                            }
                                        }
                                        else
                                        {
                                            //This occurs if the total number of breadcrumbs is one or fewer and the calling page is not the section page.                                                                                      
                                            Bcrumbs.Add(sCallingPage);
                                        }

                                    }
                                    //if the calling page is the section page.  breadcrumbs at 0 is made the calling page, the breadcrumbs are cleared.
                                    else
                                    {
                                        Bcrumbs[0] = c.Section;
                                        for (int i = 1; i < Bcrumbs.Count; )
                                        {
                                            Bcrumbs.RemoveAt(i);
                                        }
                                        
                                    }

                                    //Writes whatever is in bcrumbs into sBreadCrumbs for display on the content page
                                    for (int i = 0; i <= (Bcrumbs.Count - 1); i++)
                                    {
                                        sBreadCrumbs += Bcrumbs[i] + " : ";
                                    }

                                    sBreadCrumbs += "</p>";
                                    Session["BreadCrumbs"] = Bcrumbs;

                                    //NEWER CODE DELETE AS NEEDED

                                    //if(Session["BreadCrumbs"] != null)
                                    //{
                                    //    Bcrumbs = Session["BreadCrumbs"] as List<string>;

                                    //    if(Bcrumbs[0].ToLower().Replace(" ", "") != c.Section.ToLower().Replace(" ", ""))
                                    //    {
                                    //        Bcrumbs = null;
                                    //        Bcrumbs.Add(c.Section);
                                    //    }

                                    //}
                                    //else
                                    //{
                                    //    Bcrumbs.Add(c.Section);
                                    //}

                                    //Bcrumbs.Add(sCallingPage);
                                    
                                    //for(int i = 0; i <= (Bcrumbs.Count-1); i++)
                                    //{
                                    //    if(Bcrumbs[i].ToLower().Replace(" ", "") == sCallingPage.ToLower())
                                    //    {
                                    //        for(int x = (i+1); x <= (Bcrumbs.Count -1); x++)
                                    //        {
                                    //            Bcrumbs.RemoveAt(x);
                                    //        }
                                    //    }

                                    //    sBreadCrumbs += " " + Bcrumbs[i] + " :";

                                    //}

                                    //sBreadCrumbs += "</p>";

                                    //Session["BreadCrumbs"] = Bcrumbs;

                                    //ORIGINAL CODE BELOW

                                    //foreach (SectionNavigation sn in lstSN)
                                    //{
                                    //    //CHANGED TO MAKE THIS COMPARISON NOT CASE SENSITIVE
                                    //    if (sn.LinkURL.ToLower() == sCallingPage.ToLower())
                                    //    {
                                    //        sBreadCrumbs = sn.LinkURL;
                                    //    }
                                    //}

                                    //if (sBreadCrumbs == "" && (c.Section.Replace(" ", "") != sCallingPage))
                                    //{
                                    //    sBreadCrumbs = sCallingPage;
                                    //}
                                    //OLD VERSION OF THIS JP
                                    //if (sBreadCrumbs == "" && (c.Section.Replace(" ", "") != sCallingPage))
                                    //{
                                    //    if (Session["BreadCrumbs"] != null)
                                    //    {
                                    //        sBreadCrumbs = (string)Session["BreadCrumbs"];
                                    //        sBreadCrumbs = Session["BreadCrumbs"].ToString().Replace("</p>", " : ") + sCallingPage;
                                    //    }
                                    //    else
                                    //    {
                                    //        sBreadCrumbs = sCallingPage;
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    sBreadCrumbs = "<p>" + c.Section + " : " + sBreadCrumbs;
                                    ////}

                                    //sBreadCrumbs = sBreadCrumbs + "</p>";

                                    //Session["BreadCrumbs"] = 

                                    if ((Session["IsLoggedIn"] != null && Session["IsLoggedIn"].ToString() != "") && Session["IsLoggedIn"].ToString() == "true")
                                    {
                                        if ((Session["ViewMode"] == null || Session["ViewMode"].ToString() == "") || Session["ViewMode"].ToString() == "Preview")
                                        {
                                            sMiddleColumn = sBreadCrumbs + c.PageContent.ToString().Trim();
                                        }
                                        else
                                        {
                                            sMiddleColumn = c.PageContent.ToString().Trim();
                                        }
                                    }
                                    else
                                    {
                                        sMiddleColumn = sBreadCrumbs + c.PageContent.ToString().Trim();
                                    }


                                    if (c.Active == 1)
                                    {
                                        lbPublishMiddleColumn.Visible = false;
                                    }
                                    
                                    break;
                                }
                            case "3":
                                {
                                    lbSaveRightColumn.CommandArgument = c.ID.ToString() + "," + c.Placement.ToString() + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbPublishRightColumn.CommandArgument = c.ID.ToString(); // + "," + c.Placement.ToString() + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbDeactivateRightColumn.CommandArgument = c.ID.ToString(); // + "," + 3 + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    lbRevertRightColumn.CommandArgument = c.ID.ToString() + "," + c.Placement.ToString(); // + "," + 3 + "," + c.Page.ToString() + "," + c.Section.ToString();
                                    sRightColumn = c.PageContent.ToString().Trim();

                                    if (c.Active == 1)
                                    {
                                        lbPublishRightColumn.Visible = false;
                                    }

                                    break;
                                }
                        }
                    }

                    if ((Session["IsLoggedIn"] != null && Session["IsLoggedIn"].ToString() != "") && Session["IsLoggedIn"].ToString() == "true")
                    {


                        if ((Session["ViewMode"] != null && Session["ViewMode"].ToString() != "") && Session["ViewMode"].ToString() == "Normal")
                        {

                            ftbLeftColumn.Text = sLeftColumn;
                            ftbMiddleColumn.Text = sMiddleColumn;
                            ftbRightColumn.Text = sRightColumn;

                            tabDisplay.Visible = false;
                            tabCMSDisplay.Visible = true;
                        }
                        else
                        {
                            lblLeftColumn.Text = sLeftColumn;
                            lblMiddleColumn.Text = sMiddleColumn;
                            lblRightColumn.Text = sRightColumn;

                            tabDisplay.Visible = true;
                            tabCMSDisplay.Visible = false;
                        }
                    }
                    else
                    {
                        lblLeftColumn.Text = sLeftColumn;
                        lblMiddleColumn.Text = sMiddleColumn;
                        lblRightColumn.Text = sRightColumn;

                        tabDisplay.Visible = true;
                        tabCMSDisplay.Visible = false;
                    }

                }
                else
                {

                    lblLeftColumn.Text = "";
                    lblLeftColumn.Height = Unit.Pixel(500);
                    lblLeftColumn.Width = Unit.Percentage(100);
                    lblLeftColumn.BackColor = System.Drawing.Color.Blue;

                    lblMiddleColumn.Text = "";
                    lblMiddleColumn.Height = Unit.Pixel(500);
                    lblMiddleColumn.Width = Unit.Percentage(100);
                    lblMiddleColumn.BackColor = System.Drawing.Color.White;

                    lblRightColumn.Text = "";
                    lblRightColumn.Height = Unit.Pixel(500);
                    lblRightColumn.Width = Unit.Percentage(100);
                    lblRightColumn.BackColor = System.Drawing.Color.Blue;

                    ftbMiddleColumn.Text = "";
                    ftbLeftColumn.Text = "";

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
                case "lbSaveLeftColumn":
                    {
                        PlacementID = 1;
                        Content = ftbLeftColumn.Text.ToString().Trim();
                        break;
                    }

                case "lbSaveMiddleColumn":
                    {
                        PlacementID = 2;
                        Content = ftbMiddleColumn.Text.ToString().Trim();
                        break;
                    }

                case "lbSaveRightColumn":
                    {
                        PlacementID = 3;
                        Content = ftbRightColumn.Text.ToString().Trim();
                        break;
                    }
            }

            Content c = new Content();

            c.ID = ContentID;
            c.Placement = PlacementID;
            c.Page = ObjectName;
            //c.Title = ??
            c.Section = SectionName;
            c.PageContent = Content;
            c.User = Session["UserID"].ToString();
            c.TransDateTime = DateTime.Now;
            //c.Active = 1; //add check box to page to determine if user wants this content to be active or not

            lb = null;

            CMSWork cms = new CMSWork();
            cms.SavePageContent(c);
            cms = null;

            PageValues objPV = Session["CurrentPage"] as PageValues;

            string sPage = objPV.PageName + ".aspx";

            objPV = null;

            //string sPage = c.Page + ".aspx";

            c = null;

            Response.Redirect(sPage);
        }

        public void PublishContent(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            string ca = lb.CommandArgument;

            int iContentID = 0;

            if (ca != "")
            {
                iContentID = Convert.ToInt32(ca);
            }

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

        public void RevertContent(object sender, EventArgs e)
        {
            string lbCmdArgVals = ((LinkButton)sender).CommandArgument.ToString();
            string[] sCmdArgs = lbCmdArgVals.Split(',');

            
            int iContentID = Convert.ToInt32(sCmdArgs[0].ToString());
            int iPlacement = Convert.ToInt32(sCmdArgs[1].ToString());

            CMSWork cms = new CMSWork();

            string sOldContent = cms.RevertContent(iContentID);

            switch (iPlacement)
            {
                case 1:
                    ftbLeftColumn.Text = "";
                    ftbLeftColumn.Text = sOldContent;
                    break;
                case 2:
                    ftbMiddleColumn.Text = "";
                    ftbMiddleColumn.Text = sOldContent;
                    break;
                case 3:
                    ftbRightColumn.Text = "";
                    ftbRightColumn.Text = sOldContent;
                    break;
            }

            cms = null;
        }

    }
}