using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace STFMPlatformTransition
{
    public enum MetaDescriptor { Create = 1, Update = 2, Publish = 3, Deactivate = 4, Rename = 5, Delete = 6, RenameTitle = 7 };

    public class PageValues
    {
        private int iPageID;
        private string sPageName;
        private string sPageTitle;
        private string sSection;

        public void SetPageValues(string sCallingPage)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd;
            SqlDataReader rdr;

            string sSQL = "select id, page, title, section from contentpages where page = '" + sCallingPage + "'";
            
            cmd = new SqlCommand(sSQL, conn);
            rdr = cmd.ExecuteReader();

            rdr.Read();

            iPageID = Convert.ToInt32(rdr["ID"].ToString());
            sPageName = rdr["Page"].ToString();
            sPageTitle = rdr["Title"].ToString();
            sSection = rdr["Section"].ToString();

            conn.Close();
            rdr.Close();

            conn.Dispose();
            rdr.Dispose();

            conn = null;
            cmd = null;
            rdr = null;
        }

        public int PageID
        {
            get { return iPageID; }
            set { iPageID = value; }
        }

        public string PageName
        {
            get { return sPageName; }
            set { sPageName = value; }
        }

        public string PageTitle
        {
            get { return sPageTitle; }
            set { sPageTitle = value; }
        }

        public string Section
        {
            get { return sSection; }
            set { sSection = value; }
        }
    }

    public class SectionNavigation
    {
        private string sLinkURL;

        public string LinkURL
        {
            get { return sLinkURL; }
            set { sLinkURL = value; }
        }
    }

    public class CMSWork
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public List<Content> GetPageContent(string sCallingPage)
        {
            string sActiveContent = "";
            string sActiveContentPage = "";
            string sContentPageDateConstraints = "";

            int iPageID = 0;
            string sPage = "";
            string sTitle = "";
            string sSection = "";

            bool bGetNavigation = false;
            bool bVulcanLogin = false;

            if (HttpContext.Current.Session["IsLoggedIn"] != null && HttpContext.Current.Session["IsLoggedIn"].ToString() != "" && HttpContext.Current.Session["IsLoggedIn"].ToString() == "true")
            {
                bVulcanLogin = true;
            }

            PageValues objPV;
            string sSQL = "";

            if (HttpContext.Current.Session["CurrentPage"] != null)
            {
                objPV = HttpContext.Current.Session["CurrentPage"] as PageValues;
            }
            else
            {
                objPV = new PageValues();
                objPV.SetPageValues(sCallingPage);
            }
             
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            //SqlCommand cmd = new SqlCommand("select * from STFMContent c left outer join ContentPageDateConstraint dc on c.id = dc.contentpageid inner join ContentPages cp on c.Page = cp.Page where " + sActiveContent + sActiveContentPage + " c.Page = '" + PageName + "' and ((dc.startdate is null  or year(dc.startdate) = 1 or convert(varchar, dc.startdate, 101) <= convert(varchar, GetDate(), 101) ) and (dc.enddate is null or year(dc.enddate) = 1 or convert(varchar, dc.enddate, 101) > convert(varchar, GetDate(), 101)))", conn);
            SqlCommand cmd;
            SqlDataReader rdr;

            if (!bVulcanLogin)
            {
                sActiveContent = " and c.Active = 1";
                sActiveContentPage = " cp.Active = 1 and";
                sContentPageDateConstraints = " and ((dc.startdate <= GetDate()) and (dc.enddate > GetDate()))";
            }

            sSQL = "select cp.* from contentpages cp inner join contentpagedateconstraint dc on cp.id = dc.contentpageid where " + sActiveContentPage + " cp.page = '" + objPV.PageName + "'" + sContentPageDateConstraints;

            cmd = new SqlCommand(sSQL, conn);
            rdr = cmd.ExecuteReader();

            Content objContent = new Content();
            List<Content> lstContent = new List<Content>();

            if (rdr.Read())
            {
                iPageID = Convert.ToInt32(rdr["ID"].ToString());
                sPage = rdr["Page"].ToString();
                sTitle = rdr["Title"].ToString();
                sSection = rdr["Section"].ToString();

                if (bVulcanLogin)
                {
                    if (sPage != sSection)
                    {
                        bGetNavigation = true;
                    }
                }

                rdr.Close();
                rdr.Dispose();

                rdr = null;
                cmd = null;

                sSQL = "select * from stfmcontent c where c.contentpageid = " + iPageID + sActiveContent ;
                cmd = new SqlCommand(sSQL, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    objContent = new Content();
                    objContent.ID = Convert.ToInt32(rdr["ID"]);
                    objContent.Placement = Convert.ToInt32(rdr["Placement"]);
                    objContent.Page = sPage; // rdr["Page"].ToString().Trim();
                    objContent.Title = sTitle; // rdr["Page"].ToString().Trim();
                    objContent.Section = sSection; // rdr["Section"].ToString().Trim();
                    objContent.PageContent = rdr["Content"].ToString().Trim();
                    lstContent.Add(objContent);

                    if (sPage != sSection)
                    {
                        bGetNavigation = true;
                    }
                    else
                    {
                        if (objContent.Placement == 1)
                        {
                            SetSectionNavigation(objContent.PageContent);
                        }
                    }

                }

                cmd.Dispose();
                cmd = null;

                rdr.Close();

                if (bGetNavigation)
                {
                    sSQL = "select c.id, c.placement, cp.page, cp.title, cp.section, c.content from contentpages cp inner join stfmcontent c on cp.id = c.contentpageid where cp.page = '" + sSection.Replace(" ", "") + "' and c.placement = 1" + sActiveContent;
                    cmd = new SqlCommand(sSQL, conn);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        objContent = new Content();
                        objContent.ID = Convert.ToInt32(rdr["ID"]);
                        objContent.Placement = Convert.ToInt32(rdr["Placement"]);
                        objContent.Page = rdr["Page"].ToString().Trim();
                        objContent.Title = rdr["Title"].ToString().Trim();
                        objContent.Section = rdr["Section"].ToString().Trim();
                        objContent.PageContent = rdr["Content"].ToString().Trim();
                        lstContent.Add(objContent);
                    }

                    //string content = objContent.PageContent.Replace("<P>", "").Replace("</P>","").Replace("<A ", "").Replace("</A>", "").Replace("<","").Replace(">","").Replace("\\","").Replace("\"","").Replace("\r","").Replace("\n","");

                    SetSectionNavigation(objContent.PageContent);

                    cmd.Dispose();
                    cmd = null;

                    rdr.Close();
                }

                rdr = null;

                conn.Close();
                conn.Dispose();
                conn = null;

                objContent = null;
            }

            return lstContent;
        }

        public void SetSectionNavigation(string PageContent)
        {

            string[] content = PageContent.Split('\"');

            List<SectionNavigation> lstSN = new List<SectionNavigation>();

            foreach (string s in content)
            {
                string val = s;

                if (val.Contains(".") || val == "#")
                {
                    SectionNavigation sn = new SectionNavigation();
                    sn.LinkURL = s.Replace(".aspx", "");
                    lstSN.Add(sn);
                    sn = null;
                }
            }

            HttpContext.Current.Session["SectionNavigation"] = lstSN;
            lstSN = null;

        }
        
        public void SavePageContent(Content objContent)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction trans = conn.BeginTransaction();

            cmd.Connection = conn;
            cmd.Transaction = trans;
            cmd.CommandType = System.Data.CommandType.Text;

            string sSQL = "";
            Content CurrContent;

            try
            {
                List<Content> l = HttpContext.Current.Session["CurrentPageContent"] as List<Content>;

                CurrContent = new Content();

                foreach (Content c in l)
                {
                    if (c.ID == objContent.ID)
                    {
                        CurrContent = c;
                    }
                }

                l = null;
                
                l = new List<Content>();
                l.Add(objContent);
                
                HttpContext.Current.Session["CurrentPageContent"] = l;
                
                l = null;

                PageValues objPV = HttpContext.Current.Session["CurrentPage"] as PageValues;

                if (objContent.ID == 0)//First save for this content
                {
                    sSQL = "select section from contentpages where page = '" + objContent.Page + "'";

                    cmd.CommandText = sSQL;
                    objContent.Section = Convert.ToString(cmd.ExecuteScalar());

                    sSQL = "insert into STFMContent (ContentPageID, Placement, Content, Active) Values (" + objPV.PageID + ", '" + objContent.Placement + "', '" + objContent.PageContent.Replace("''", "'").Replace("'", "''").Replace("> <", "><") + "', '" + objContent.Active + "'); select scope_identity()";

                    cmd.CommandText = sSQL;
                    int iRowID = Convert.ToInt32(cmd.ExecuteScalar());

                    sSQL = "insert into ContentMeta (ContentID, DateCreated, CreatedBy, MetaDescriptorID) Values (" + iRowID + ", '" + objContent.TransDateTime + "', '" + objContent.User + "', '" + Convert.ToInt32(MetaDescriptor.Create) + "')";

                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    //sSQL = "update STFMContent set ContentPageID = '" + objPV.PageID + "', Placement = '" + objContent.Placement + "', Content = '" + objContent.PageContent.Replace("''", "'").Replace("'", "''") + "', Active = '" + objContent.Active + "' where id = '" + objContent.ID + "'";
                    sSQL = "update STFMContent set Content = '" + objContent.PageContent.Replace("''", "'").Replace("'", "''").Replace("> <", "><") + "' where id = " + objContent.ID;
                    
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    sSQL = "insert into ContentMeta (ContentID, DateCreated, CreatedBy, MetaDescriptorID) Values (" + objContent.ID + ", '" + objContent.TransDateTime + "', '" + objContent.User + "', '" + Convert.ToInt32(MetaDescriptor.Update) + "'); Select Scope_Identity();";

                    cmd.CommandText = sSQL;
                    int iContentMetaID = Convert.ToInt32(cmd.ExecuteScalar());

                    sSQL = "insert into STFMContentHistory (ContentMetaID, Section, Page, Placement, Content, UserID, DateCreated) Values (" + iContentMetaID + ", '" + CurrContent.Section + "', '" + CurrContent.Page + "', '" + CurrContent.Placement + "', '" + CurrContent.PageContent.Replace("''", "'").Replace("'", "''") + "', '" + CurrContent.User + "', '" + DateTime.Now + "')";

                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();
                }
                
                
                trans.Commit();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;
                CurrContent = null;

                string sLogEntry = "Oh Yes!  SUCCESS - " + DateTime.Now.ToString() + " Method: SavePageContent. " + objContent.Page + ".aspx content was successfully saved: " + DateTime.Now.ToString() + " SQL: " + sSQL;
                MakeLogEntry(sLogEntry);

            }
            catch (Exception ex)
            {
                trans.Rollback();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;
                CurrContent = null;

                string sLogEntry = "Oh No!  ERROR - " + DateTime.Now.ToString() + " Method: SavePageContent. " + objContent.Page + ".aspx failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString() + " SQL: " + sSQL;
                MakeLogEntry(sLogEntry);
            }
        }

        public string CreateContentPage(ContentPage objContentPage, Content objContent)
        {
            try
            {
                string sCreatePage = CreateContentPageMeta(objContent, objContentPage);

                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: CreateContentPage. " + objContent.Page + ".aspx successfully created: " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);

                return sCreatePage;
            }
            catch (Exception ex)
            {
                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: CreateContentPage. " + objContent.Page + ".aspx failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);

                DeleteContentPage(objContentPage.PagePathName);
                return ex.Message;
            }
        }


        private void MakeLogEntry(string sEntry)
        {
            PageValues objPV = HttpContext.Current.Session["CurrentPage"] as PageValues;

            string sLogDirectory = "";

            if (objPV != null && objPV.PageName == "Default")
            {
                sLogDirectory = HttpContext.Current.Server.MapPath("").ToString() + "\\LogFiles\\";
            }
            else
            {
                sLogDirectory = HttpContext.Current.Server.MapPath("../").ToString() + "\\LogFiles\\";
            }

            string sLogFileName = DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Year.ToString() + ".log";
            string sLogFilePath = sLogDirectory + sLogFileName;

            string sLogContent = (sEntry + "\n");
            File.AppendAllText(sLogFilePath, sLogContent);
        }


        public void DeleteContentPage(string DeletePagePathName)
        {
            try
            {
                File.Delete(DeletePagePathName);

                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: DeleteContentPage. " + DeletePagePathName + " successfully deleted: " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);
            }
            catch (Exception ex)
            {
                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: CreateContentPage. " + DeletePagePathName + " failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);
            }
        }

        private string CreateContentPageMeta(Content objContent, ContentPage objContentPage)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();
            
            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction trans = conn.BeginTransaction();

            cmd.Connection = conn;
            cmd.Transaction = trans;

            try
            {
                File.Copy(objContentPage.TemplatePathName, objContentPage.PagePathName);

                string sSQL = "";

                sSQL = "insert into ContentPages (Page, Title, Section, Active) Values ('" + objContent.Page + "', '" + objContent.Title + "', '" + objContent.Section + "', 0); select scope_identity();";

                cmd.CommandText = sSQL;
                int iRowID = Convert.ToInt32(cmd.ExecuteScalar());

                sSQL = "insert into ContentPageMeta (ContentPageID, DateCreated, CreatedBy, MetaDescriptorID) Values (" + iRowID + ", '" + DateTime.Now + "', '" + objContent.User + "', '" + Convert.ToInt32(MetaDescriptor.Create) + "')";

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                sSQL = "insert into ContentPageDateConstraint (ContentPageID, StartDate, EndDate) Values (" + iRowID + ", '" + objContent.ContentStartDate + "', '" + objContent.ContentEndDate + "')";

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                PageValues objPV = new PageValues();
                objPV.PageID = iRowID;
                objPV.PageName = objContent.Page;

                HttpContext.Current.Session["CurrentPage"] = objPV;

                objPV = null;

                trans.Commit();

                trans.Dispose();
                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;

                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: CreateContentPageMeta. " + objContentPage.PagePathName + " successfully created: " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);

                return "";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                trans.Dispose();

                conn.Close();
                conn.Dispose();

                cmd = null;
                trans = null;
                conn = null;

                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: CreateContentPage. " + objContentPage.PagePathName + " failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);

                if (!ex.Message.Contains("already exists."))
                {
                    try
                    {
                        DeleteContentPage(objContentPage.PagePathName);

                        sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: CreateContentPage=>DeleteContentPage. " + objContentPage.PagePathName + " successfully deleted: " + DateTime.Now.ToString();
                        MakeLogEntry(sLogEntry);
                    }
                    catch (Exception ex2)
                    {
                        sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: CreateContentPage=>DeleteContentPage. " + objContentPage.PagePathName + " failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                        MakeLogEntry(sLogEntry);
                    }
                }

                return ex.Message;
            }
        }

        public string ChangePageAvailability(int iContentPageID, DateTime dtStartDate, DateTime dtEndDate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction trans = conn.BeginTransaction();

            cmd.Connection = conn;
            cmd.Transaction = trans;

            try
            {
                string sSQL = "update ContentPageDateConstraint set StartDate = '" + dtStartDate + "', EndDate = '" + dtEndDate + "' where  ContentPageID = " + iContentPageID;

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                trans.Commit();

                trans.Dispose();
                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;

                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: ChangePageAvailability. Content Page ID: " + iContentPageID + " successfully changed: " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);

                return "";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                trans.Dispose();

                conn.Close();
                conn.Dispose();

                cmd = null;
                trans = null;
                conn = null;

                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: ChangePageAvailability. Content Page ID: " + iContentPageID + " failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);

                return ex.Message;
            }
        }

        public List<PageValues> FillPagesPublishedDropDown()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from ContentPages where active = 1 Order by Page ASC", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            List<PageValues> lstContent = new List<PageValues>();

            PageValues objPV = new PageValues();
            objPV.PageID = 0;
            objPV.PageName = "";
            
            lstContent.Add(objPV);

            while (rdr.Read())
            {
                objPV = new PageValues();
                objPV.PageID = Convert.ToInt32(rdr["ID"].ToString());
                objPV.PageName = rdr["Page"].ToString().Trim();
                lstContent.Add(objPV);
            }

            rdr.Close();
            conn.Close();

            conn.Dispose();
            cmd.Dispose();
            rdr.Dispose();

            conn = null;
            cmd = null;
            rdr = null;

            return lstContent;
        }

        public List<PageValues> FilterPublishedPages(string sSectionFilter)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from ContentPages where section = '" + sSectionFilter + "' and active = 1", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            List<PageValues> lstContent = new List<PageValues>();

            PageValues objPV = new PageValues();
            objPV.PageID = 0;
            objPV.PageName = "";

            lstContent.Add(objPV);

            while (rdr.Read())
            {
                objPV = new PageValues();
                objPV.PageID = Convert.ToInt32(rdr["ID"].ToString());
                objPV.PageName = rdr["Page"].ToString().Trim();
                lstContent.Add(objPV);
            }

            rdr.Close();
            conn.Close();

            conn.Dispose();
            cmd.Dispose();
            rdr.Dispose();

            conn = null;
            cmd = null;
            rdr = null;

            return lstContent;
        }

        public void PublishPage(string sPage)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction trans = conn.BeginTransaction();

            cmd.Connection = conn;
            cmd.Transaction = trans;
            cmd.CommandType = System.Data.CommandType.Text;

            string sSQL = "";

            try
            {
                sSQL = "update ContentPages set active = 1 where Page = '" + sPage + "'; select id from ContentPages where Page = '" + sPage + "';";

                cmd.CommandText = sSQL;
                int iRowID = Convert.ToInt32(cmd.ExecuteScalar());

                //sSQL = "update STFMContent set Section = '" + objContent.Section + "', Page = '" + objContent.Page + "', Placement = '" + objContent.Placement + "', Content = '" + objContent.PageContent + "', Active = '" + objContent.Active + "' where id = '" + objContent.ID + "'";

                //cmd.CommandText = sSQL;
                //cmd.ExecuteNonQuery();

                sSQL = "insert into ContentPageMeta (ContentPageID, DateCreated, CreatedBy, MetaDescriptorID) Values (" + iRowID + ", '" + DateTime.Now + "', '" + HttpContext.Current.Session["UserID"].ToString() + "', '" + Convert.ToInt32(MetaDescriptor.Publish) + "')";

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                //sSQL = "insert into STFMContentHistory (ContentMetaID, Section, Page, Placement, Content, UserID, DateCreated) Values (" + iContentMetaID + ", '" + CurrContent.Section + "', '" + CurrContent.Page + "', '" + CurrContent.Placement + "', '" + CurrContent.PageContent + "', '" + CurrContent.User + "', '" + DateTime.Now + "')";

                //cmd.CommandText = sSQL;
                //cmd.ExecuteNonQuery();

                trans.Commit();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;

                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: PublishPage. " + sPage + ".aspx successfully published: " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);
            
            }
            catch (Exception ex)
            {
                trans.Rollback();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;

                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: PublishPage. " + sPage + " failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);
            }
        }

        public void DeactivatePage(string sPage)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction trans = conn.BeginTransaction();

            cmd.Connection = conn;
            cmd.Transaction = trans;
            cmd.CommandType = System.Data.CommandType.Text;

            string sSQL = "";

            try
            {
                sSQL = "update ContentPages set active = 0 where Page = '" + sPage + "'; select id from ContentPages where Page = '" + sPage + "';";

                cmd.CommandText = sSQL;
                int iRowID = Convert.ToInt32(cmd.ExecuteScalar());

                sSQL = "insert into ContentPageMeta (ContentPageID, DateCreated, CreatedBy, MetaDescriptorID) Values (" + iRowID + ", '" + DateTime.Now + "', '" + HttpContext.Current.Session["UserID"].ToString() + "', '" + Convert.ToInt32(MetaDescriptor.Deactivate) + "')";

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                trans.Commit();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;

                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: DeactivatePage. " + sPage + " successfully deactivated: " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;

                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: DeactivatePage. " + sPage + " failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);
            }
        }

        public void RenamePage(string sPage)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction trans = conn.BeginTransaction();

            cmd.Connection = conn;
            cmd.Transaction = trans;
            cmd.CommandType = System.Data.CommandType.Text;

            PageValues objPV = null;
            string sSQL = "";

            if (HttpContext.Current.Session["CurrentPage"] != null)
            {
                objPV = HttpContext.Current.Session["CurrentPage"] as PageValues;
            }
            //else
            //{
            //    objPV = new PageValues();
            //    objPV.SetPageValues(sPage);
            //}

            //List<Content> l = HttpContext.Current.Session["CurrentPageContent"] as List<Content>;

            //Content CurrContent = new Content();

            //foreach (Content c in l)
            //{
            //    CurrContent = c;
            //}

            //l = null;

            try
            {

                //sSQL = "select id from ContentPages where Page = '" + CurrContent.Page + "'";
                //sSQL = "select id from ContentPages where id = " + objPV.PageID + "";

                //cmd.CommandText = sSQL;
                //int iRowID = Convert.ToInt32(cmd.ExecuteScalar());

                sSQL = "update ContentPages set Page = '" + sPage + "' where id = '" + objPV.PageID + "'";

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                sSQL = "insert into ContentPageMeta (ContentPageID, DateCreated, CreatedBy, MetaDescriptorID) Values (" + objPV.PageID + ", '" + DateTime.Now + "', '" + HttpContext.Current.Session["UserID"].ToString() + "', '" + Convert.ToInt32(MetaDescriptor.Rename) + "')";

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                //sSQL = "update STFMContent set contentpageid = " + iRowID + " where id = '" + CurrContent.ID + "'";

                //cmd.CommandText = sSQL;
                //cmd.ExecuteNonQuery();

                string CurrPagePathName = HttpContext.Current.Server.MapPath("../").ToString() + "Content\\" + objPV.PageName + ".aspx";
                string NewPagePathName = HttpContext.Current.Server.MapPath("../").ToString() + "Content\\" + sPage + ".aspx";

                File.Move(CurrPagePathName, NewPagePathName);

                trans.Commit();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;

                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: RenamePage. Page successfully renamed from " + objPV.PageName + " to " + sPage + ": " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);

                //CurrContent = null;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;

                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: RenamePage from " + objPV.PageName + " to " + sPage + " failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);

                //CurrContent = null;
            }
        }

        public void RenamePageTitle(string sPageTitle)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction trans = conn.BeginTransaction();

            cmd.Connection = conn;
            cmd.Transaction = trans;
            cmd.CommandType = System.Data.CommandType.Text;

            PageValues objPV = null;
            string sSQL = "";

            if (HttpContext.Current.Session["CurrentPage"] != null)
            {
                objPV = HttpContext.Current.Session["CurrentPage"] as PageValues;
            }

            try
            {

                sSQL = "update ContentPages set Title = '" + sPageTitle.Replace("'", "''") + "' where id = '" + objPV.PageID + "'";

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                sSQL = "insert into ContentPageMeta (ContentPageID, DateCreated, CreatedBy, MetaDescriptorID) Values (" + objPV.PageID + ", '" + DateTime.Now + "', '" + HttpContext.Current.Session["UserID"].ToString() + "', '" + Convert.ToInt32(MetaDescriptor.RenameTitle) + "')";

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                trans.Commit();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;

                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: RenamePageTitle. Page title successfully renamed from " + objPV.PageTitle + " to " + sPageTitle + ": " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);

            }
            catch (Exception ex)
            {
                trans.Rollback();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;

                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: RenamePageTitle from " + objPV.PageTitle + " to " + sPageTitle + " failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);

            }
        }

        public void DeletePage()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction trans = conn.BeginTransaction();

            cmd.Connection = conn;
            cmd.Transaction = trans;
            cmd.CommandType = System.Data.CommandType.Text;

            PageValues objPV = null;
            string sSQL = "";

            if (HttpContext.Current.Session["CurrentPage"] != null)
            {
                objPV = HttpContext.Current.Session["CurrentPage"] as PageValues;
            }

            try
            {

                //sSQL = "select id from ContentPages where Page = '" + CurrContent.Page + "'";

                //cmd.CommandText = sSQL;
                //int iRowID = Convert.ToInt32(cmd.ExecuteScalar());

                sSQL = "delete from ContentPages where id = " + objPV.PageID;

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                sSQL = "delete from STFMContent where contentpageid = " + objPV.PageID;

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                string CurrPagePathName = HttpContext.Current.Server.MapPath("../").ToString() + "Content\\" + objPV.PageName + ".aspx";

                File.Delete(CurrPagePathName);

                trans.Commit();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;

                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: DeletePage. Page " + objPV.PageName + " successfully deleted: " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);

                objPV = null;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;

                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: DeletePage " + objPV.PageName + " failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);

                objPV = null;
            }
        }

        public void PublishContent(int iContentID)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction trans = conn.BeginTransaction();

            cmd.Connection = conn;
            cmd.Transaction = trans;
            cmd.CommandType = System.Data.CommandType.Text;

            string sSQL = "";

            try
            {
                sSQL = "update STFMContent set active = 1 where id = " + iContentID;

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                sSQL = "insert into ContentMeta (ContentID, DateCreated, CreatedBy, MetaDescriptorID) Values (" + iContentID + ", '" + DateTime.Now + "', '" + HttpContext.Current.Session["UserID"].ToString() + "', '" + Convert.ToInt32(MetaDescriptor.Publish) + "')";

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                trans.Commit();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;

                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: PublishContent. " + iContentID + " successfully published: " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;

                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: PublishContent. " + iContentID + " failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);
            }
        }

        public void DeactivateContent(int iContentID)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction trans = conn.BeginTransaction();

            cmd.Connection = conn;
            cmd.Transaction = trans;
            cmd.CommandType = System.Data.CommandType.Text;

            string sSQL = "";
            Content objContent;

            try
            {
                sSQL = "update STFMContent set active = 0 where id = " + iContentID;

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                sSQL = "insert into ContentMeta (ContentID, DateCreated, CreatedBy, MetaDescriptorID) Values (" + iContentID + ", '" + DateTime.Now + "', '" + HttpContext.Current.Session["UserID"].ToString() + "', '" + Convert.ToInt32(MetaDescriptor.Publish) + "')";

                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();

                trans.Commit();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;
                objContent = null;

                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: DeactiveateContent. " + iContentID + " successfully deactivated: " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;
                objContent = null;

                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: DeactivateContent. " + iContentID + " failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);
            }
        }

        public string RevertContent(int iContentID)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction trans = conn.BeginTransaction();

            cmd.Connection = conn;
            cmd.Transaction = trans;
            cmd.CommandType = System.Data.CommandType.Text;

            string sSQL = "";
            Content objContent;

            try
            {
                sSQL = "select Content from STFMContentHistory where ContentMetaID = (select max(id) from contentmeta where contentid = "  + iContentID + " and metadescriptorid = 2)";

                cmd.CommandText = sSQL;
                string sOldContent = cmd.ExecuteScalar().ToString();

                trans.Commit();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;
                objContent = null;

                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: RevertContent. " + iContentID + " successfully reverted: " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);

                return sOldContent;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                trans.Dispose();

                conn.Close();

                conn.Dispose();
                cmd.Dispose();

                conn = null;
                trans = null;
                cmd = null;
                objContent = null;

                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: RevertContent. " + iContentID + " failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);

                return ex.Message;
            }
        }

        public bool IsPageActive(string sPageName)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from ContentPages where Page = '" + sPageName + "'", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            bool bActive = true;

            if (rdr.Read())
            {
                if (Convert.ToInt32(rdr["Active"].ToString()) != 1)
                {
                    bActive = false;
                }
            }

            rdr.Close();
            conn.Close();

            conn.Dispose();
            cmd.Dispose();
            rdr.Dispose();

            conn = null;
            cmd = null;
            rdr = null;

            return bActive;
        }

        public List<PageValues> FillPagesNotPublishedDropDown()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand("select ID, Page from ContentPages where active = 0 order by Page ASC", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            List<PageValues> lstContent = new List<PageValues>();

            PageValues objPV = new PageValues();
            objPV.PageID = 0;
            objPV.PageName = "";
            lstContent.Add(objPV);

            while (rdr.Read())
            {
                objPV = new PageValues();
                objPV.PageID = Convert.ToInt32(rdr["ID"].ToString());
                objPV.PageName = rdr["Page"].ToString().Trim();
                lstContent.Add(objPV);
            }

            rdr.Close();
            conn.Close();

            conn.Dispose();
            cmd.Dispose();
            rdr.Dispose();

            conn = null;
            cmd = null;
            rdr = null;

            return lstContent;
        }

        public List<PageValues> FillPagesWithDateConstraintDropDown()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand("select cp.ID, cp.Page from ContentPages cp, ContentPageDateConstraint dc where dc.ContentPageID = cp.ID and ((dc.startdate >= GetDate()) and (dc.enddate > GetDate()))", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            List<PageValues> lstContent = new List<PageValues>();

            PageValues objPV = new PageValues();
            objPV.PageID = 0;
            objPV.PageName = "";
            lstContent.Add(objPV);

            while (rdr.Read())
            {
                objPV = new PageValues();
                objPV.PageID = Convert.ToInt32(rdr["ID"].ToString());
                objPV.PageName = rdr["Page"].ToString().Trim();
                lstContent.Add(objPV);
            }

            rdr.Close();
            conn.Close();

            conn.Dispose();
            cmd.Dispose();
            rdr.Dispose();

            conn = null;
            cmd = null;
            rdr = null;

            return lstContent;
        }

    }

    public class Content
    {
        int iID = 0;
        string sSection = "";
        string sPage = "";
        string sTitle = "";
        int iPlacement = 0;
        string sContent = "";
        int iActive = 0;

        string sUser = "";

        DateTime dtTransDateTime = DateTime.Now;
        DateTime dtContentStartDate;
        DateTime dtContentEndDate;
        
        public int ID
        {
            get { return iID; }
            set { iID = value; }
        }

        public string Section
        {
            get { return sSection; }
            set { sSection = value; }
        }

        public string Page
        {
            get { return sPage; }
            set { sPage = value; }
        }

        public string Title
        {
            get { return sTitle; }
            set { sTitle = value; }
        }

        public int Placement
        {
            get { return iPlacement; }
            set { iPlacement = value; }
        }

        public string PageContent
        {
            get { return sContent; }
            set { sContent = value; }
        }

        public int Active
        {
            get { return iActive; }
            set { iActive = value; }
        }

        public string User
        {
            get { return sUser; }
            set { sUser = value; }
        }

        public DateTime TransDateTime
        {
            get { return dtTransDateTime; }
            set { dtTransDateTime = value; }
        }

        public DateTime ContentStartDate
        {
            get { return dtContentStartDate; }
            set { dtContentStartDate = value; }
        }

        public DateTime ContentEndDate
        {
            get { return dtContentEndDate; }
            set { dtContentEndDate = value; }
        }
    }

    public class ContentPage
    {
        string sTemplatePathName = "";
        string sPagePathName = "";

        public string TemplatePathName
        {
            get { return sTemplatePathName; }
            set { sTemplatePathName = value; }
        }

        public string PagePathName
        {
            get { return sPagePathName; }
            set { sPagePathName = value; }
        }
    }

    public class SearchResults
    {
        int iId = 0;
        string sSection = "";
        string sPage = "";
        string sTitle = "";
        int iPlacement = 0;
        string sContent = "";
        string sUser = "";
        DateTime dtDateCreated = DateTime.Now;
        int iActive = 0;
        string sMetaDescription = "";


        public int Id
        {
            get { return iId; }
            set { iId = value; }
        }

        public string Section
        {
            get { return sSection; }
            set { sSection = value; }
        }
        
        public string Page
        {
            get { return sPage; }
            set { sPage = value; }
        }

        public string Title
        {
            get { return sTitle; }
            set { sTitle = value; }
        }

        public int Placement
        {
            get { return iPlacement; }
            set { iPlacement = value; }
        }
        
        public string Content
        {
            get { return sContent; }
            set { sContent = value; }
        }
        
        public string User
        {
            get { return sUser; }
            set { sUser = value; }
        }
        
        public DateTime DateCreated
        {
            get { return dtDateCreated; }
            set { dtDateCreated = value; }
        }
        
        public int Active
        {
            get { return iActive; }
            set { iActive = value; }
        }

        public string MetaDescription
        {
            get { return sMetaDescription; }
            set { sMetaDescription = value; }
        }

    }
}

