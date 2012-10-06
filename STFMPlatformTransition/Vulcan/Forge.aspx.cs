using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace STFMPlatformTransition
{
    public partial class ControlPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                if (Session["IsLoggedIn"] != null && Session["IsLoggedIn"].ToString() == "true")
                {
                    CMSWork cms = new CMSWork();
                    List<PageValues> l = cms.FillPagesPublishedDropDown();

                    ddlPagesPublished.DataSource = l;
                    ddlPagesPublished.DataValueField = "PageID";
                    ddlPagesPublished.DataTextField = "PageName";
                    ddlPagesPublished.DataBind();

                    l = cms.FillPagesNotPublishedDropDown();

                    ddlPagesNotPublished.DataSource = l;
                    ddlPagesNotPublished.DataValueField = "PageID";
                    ddlPagesNotPublished.DataTextField = "PageName";
                    ddlPagesNotPublished.DataBind();

                    l = cms.FillPagesWithDateConstraintDropDown();

                    ddlContentPagesWithDateConstraint.DataSource = l;
                    ddlContentPagesWithDateConstraint.DataValueField = "PageID";
                    ddlContentPagesWithDateConstraint.DataTextField = "PageName";
                    ddlContentPagesWithDateConstraint.DataBind();
                    cms = null;

                    Session["IsLoggedIn"] = "true";

                    ViewForge();
                }
                else
                {
                    Response.Redirect("/Vulcan/");
                }
            }
        }

        protected void ViewForge()
        {
            tabForge.Visible = true;
            calContentEndDate.TodaysDate = DateTime.Now.AddMonths(1);
        }

        protected void ViewPage(object sender, EventArgs e)
        {
            tabForge.Visible = false;

            DropDownList ddl = (DropDownList)sender;
            int PageID = Convert.ToInt32(ddl.SelectedValue);
            string PageName = ddl.SelectedItem.Text.ToString() + ".aspx";
            ddl = null;

            PageValues objPV = new PageValues();
            objPV.PageID = PageID;
            objPV.PageName = PageName.Replace(".aspx", "");

            Session["CurrentPage"] = objPV;

            if (PageName == "Default.aspx")
            {
                PageName = "../" + PageName; //this is the home page
            }
            else
            {
                PageName = "../Content/" + PageName; //this is a content page
            }

            ddl = null;

            Response.Redirect(PageName);
        }

        protected void ViewTemplate(object sender, EventArgs e)
        {
            tabForge.Visible = false;

            DropDownList ddl = (DropDownList)sender;
            string PageName = "../Templates/" + ddl.SelectedItem.Value + ".aspx";
            ddl = null;

            Response.Redirect(PageName);
        }

        protected void AddPage(object sender, EventArgs e)
        {
            string TemplateName = ddlAddPageTemplate.SelectedValue.ToString(); //Server.MapPath("../").ToString() + "Templates\\" + ddlAddPageTemplate.SelectedValue.ToString() + ".aspx";
            string PageName = txtPageName.Text.ToString().Trim().Replace(" ", "");
            string PageTitle = txtPageTitle.Text.ToString();
            string SectionName = rblSection.SelectedValue;

            string PagePathName = Server.MapPath("../").ToString() + "Content\\" + PageName + ".aspx";
            string TemplatePathName = Server.MapPath("../").ToString() + "Templates\\" + ddlAddPageTemplate.SelectedValue.ToString() + ".aspx";
            
            string PageRedirectName = "../Content/" + PageName + ".aspx";

            string sValidatePageDataResults = ValidatePageData(TemplateName, PageName, PageTitle, SectionName, PagePathName, TemplatePathName);
            
            if (sValidatePageDataResults != "")
            {
                lblMessage.Text = sValidatePageDataResults;
                return;
            }

            Response.Redirect(PageRedirectName);
        }

        protected void ChangePageAvailability(object sender, EventArgs e)
        {
            int iContentPageID = Convert.ToInt32(ddlContentPagesWithDateConstraint.SelectedValue.ToString());
            DateTime ContentStartDate = calChangePageStartDate.SelectedDate.Year == 1 ? DateTime.Now.AddDays(-1) : calChangePageStartDate.SelectedDate;
            DateTime ContentEndDate = calChangePageEndDate.SelectedDate.Year == 1 ? DateTime.Now.AddYears(100) : calChangePageEndDate.SelectedDate;

            CMSWork cms = new CMSWork();
            cms.ChangePageAvailability(iContentPageID, ContentStartDate, ContentEndDate);
            cms = null;
        }

        private string ValidatePageData(string VTemplateName, string VPageName, string VPageTitle, string VSectionName, string VPagePathName, string VTemplatePathName)
        {
            if (VTemplateName == "")
            {
                return "You Must Choose a Template to Use";
            }
            else if (VPageName == "")
            {
                return "You Must Provide a Page Name";
            }
            else if (VPageTitle == "")
            {
                return "You Must Provide a Page Title";
            }
            else if (VSectionName == "")
            {
                return "You Must Chose a Section";
            }
            else if (VPagePathName == "")
            {
                return "File System Location for new File Could not be Verified";
            }
            else if (VTemplatePathName == "")
            {
                return "Template Location for new File Could not be Verified";
            }
            else
            {
                return FillContentObjects(VTemplateName, VPageName, VPageTitle, VSectionName, VPagePathName, VTemplatePathName);
            }
        }

        private string FillContentObjects(string CTemplateName, string CPageName, string CPageTitle, string CSectionName, string CPagePathName, string CTemplatePathName)
        {
            CMSWork cms = new CMSWork();
            Content objContent = new Content();
            ContentPage objContentPage = new ContentPage();

            string retVal = "";

            try
            {
                //Fill Content Object
                objContent.Page = CPageName;
                objContent.Title = CPageTitle;
                objContent.Section = CSectionName;
                objContent.Placement = -1;
                objContent.Active = 0;
                objContent.User = Session["UserID"].ToString();

                objContent.ContentStartDate = calContentStartDate.SelectedDate.Year == 1 ? DateTime.Now.AddDays(-1) : calContentStartDate.SelectedDate;
                objContent.ContentEndDate = calContentEndDate.SelectedDate.Year == 1 ? DateTime.Now.AddYears(100) : calContentStartDate.SelectedDate;

                //Fill Content Page Object
                objContentPage.TemplatePathName = CTemplatePathName;
                objContentPage.PagePathName = CPagePathName;

                retVal = cms.CreateContentPage(objContentPage, objContent);

                cms = null;
                objContent = null;

                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: FillContentObject. " + User + " successfully completed: " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);
                
                return retVal;
            }
            catch (Exception ex)
            {
                cms.DeleteContentPage(CPagePathName);

                cms = null;
                objContent = null;

                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: FillContentObject. " + User + " failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);

                return ex.Message;
            }
        }

        protected void FindPage(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn;
                conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
                conn.Open();

                string strSql = "";

                strSql = "select c.id, c.placement, c.active, cp.section, cp.page, cp.title, cm.CreatedBy, cm.DateCreated, md.Description from contentpages cp left outer join stfmcontent c on cp.id = c.contentpageid left outer join contentmeta cm on c.id = cm.contentid left outer join MetaDescriptors md on cm.metadescriptorid = md.id where " + rblSearchOptions.SelectedValue.ToString() + " like '%" + txtSearch.Text.Trim() + "%' order by c.id desc";

                SqlCommand cmd = new SqlCommand(strSql, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                List<SearchResults> lSearch = new List<SearchResults>();
                Session["SearchResults"] = "";

                while (dr.Read())
                {
                    SearchResults sr = new SearchResults();

                    sr.Id = Convert.ToInt32(dr["Id"].ToString());
                    sr.Section = dr["Section"].ToString();
                    sr.Page = dr["Page"].ToString();
                    sr.Title = dr["Title"].ToString();
                    sr.Placement = Convert.ToInt32(dr["Placement"].ToString());
                    sr.Content = sr.Page == "Default" ? "<a href=" + sr.Page + ".aspx target=_blank>" + sr.Page + ".aspx</a>" : "<a href=/Content/" + sr.Page + ".aspx target=_blank>" + sr.Page + ".aspx</a>";
                    sr.User = dr["CreatedBy"].ToString();
                    sr.DateCreated = Convert.ToDateTime(dr["DateCreated"].ToString());
                    sr.Active = dr["Active"].ToString() == "True" ? 1 : 0;
                    sr.MetaDescription = dr["Description"].ToString();

                    lSearch.Add(sr);

                    sr = null;

                    Session["SearchResults"] = lSearch;

                }

                lSearch = null;

                cmd = null;
                dr.Close();
                dr = null;

                conn.Close();
                conn = null;

                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: FindPage. Successfully completed: " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);

            }
            catch (Exception ex)
            {
                lblSearchMessage.Text = ex.Message.ToString();

                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: FindPage. Failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);
            }

            if (Session["SearchResults"] != null && Session["SearchResults"].ToString() != "")
            {
                Session["ViewMode"] = "Preview";
                Response.Redirect("../SearchResults.aspx");
            }
            else
            {
                lblSearchMessage.Text = "No results found";
            }

        }

        public void Logout(object sender, EventArgs e)
        {
            Session.Clear();
            Session["IsLoggedIn"] = "false";
            Session["ViewMode"] = "Normal";
            Response.Redirect("~/Default.aspx");
        }

        private void MakeLogEntry(string sEntry)
        {
            string sLogDirectory = HttpContext.Current.Server.MapPath("../") + "\\LogFiles\\";
            string sLogFileName = DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Year.ToString() + ".log";
            string sLogFilePath = sLogDirectory + sLogFileName;

            string sLogContent = (sEntry + "\n");
            System.IO.File.AppendAllText(sLogFilePath, sLogContent);
        }

        public void FilterPublishedPages(object sender, EventArgs e)
        {
            RadioButtonList rbl = (RadioButtonList)sender;

            string sSectionFilter = rbl.SelectedValue.ToString();

            CMSWork cms = new CMSWork();
            List<PageValues> l = cms.FilterPublishedPages(sSectionFilter);

            ddlPagesPublished.DataSource = l;
            ddlPagesPublished.DataValueField = "PageID";
            ddlPagesPublished.DataTextField = "PageName";
            ddlPagesPublished.DataBind();

            cms = null;
            l = null;
            rbl = null;
        }

    }
}