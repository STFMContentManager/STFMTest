using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;

namespace STFMPlatformTransition
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.Title = "STFM Site!";
            
            if (Session["IsLoggedIn"] != null && Session["IsLoggedIn"].ToString() != "" && Session["IsLoggedIn"].ToString() == "true")
            {
                tabVulcan.Visible = true;

                CMSWork cms = new CMSWork();

                string[] sCallingPageVal = Request.Url.AbsolutePath.Split('/');
                string sCallingPage = sCallingPageVal[sCallingPageVal.Length - 1].Replace(".aspx", "");

                if (cms.IsPageActive(sCallingPage))
                {
                    lbPublish.Visible = false;
                    lbDeactivate.Visible = true;
                }
                else
                {
                    lbPublish.Visible = true;
                    lbDeactivate.Visible = false;
                }

                cms = null;

                if (Session["ViewMode"] != null && Session["ViewMode"].ToString() != "" && Session["ViewMode"].ToString() == "Normal")
                {
                    lbMakeChanges.Enabled = false;
                    lbViewChanges.Enabled = true;
                }
                else if (Session["ViewMode"] != null && Session["ViewMode"].ToString() != "" && Session["ViewMode"].ToString() == "Preview")
                {
                    lbMakeChanges.Enabled = true;
                    lbViewChanges.Enabled = false;
                }
            }
            else
            {
                tabVulcan.Visible = false;

                SiteHeader.Visible = true;
                SiteFooter.Visible = true;
            }

        }

        protected void PublishPage(object sender, EventArgs e)
        {
            string sCallingPage = Session["CallingPage"].ToString();

            CMSWork cms = new CMSWork();
            cms.PublishPage(sCallingPage);
            cms = null;

            Response.Redirect("~/vulcan/forge.aspx");
        }

        protected void DeactivatePage(object sender, EventArgs e)
        {
            string sCallingPage = Session["CallingPage"].ToString();

            CMSWork cms = new CMSWork();
            cms.DeactivatePage(sCallingPage);
            cms = null;

            Response.Redirect("~/vulcan/forge.aspx");
        }

        protected void RenamePage(object sender, EventArgs e)
        {
            string sPageNewName = txtPageNewName.Text.Trim();

            CMSWork cms = new CMSWork();
            cms.RenamePage(sPageNewName);
            cms = null;

            Response.Redirect("~/vulcan/forge.aspx");
        }

        protected void RenamePageTitle(object sender, EventArgs e)
        {
            string sPageNewTitle = txtPageNewTitle.Text.Trim();

            CMSWork cms = new CMSWork();
            cms.RenamePageTitle(sPageNewTitle);
            cms = null;

            Response.Redirect("~/vulcan/forge.aspx");
        }

        protected void DeletePage(object sender, EventArgs e)
        {
            //string sPageToDelete = Session["CallingPage"].ToString();

            CMSWork cms = new CMSWork();
            cms.DeletePage();
            cms = null;

            Response.Redirect("~/vulcan/forge.aspx");
        }

        public void Logout(object sender, EventArgs e)
        {
            Session.Clear();
            Session["IsLoggedIn"] = "false";
            Session["ViewMode"] = "Normal";
            Response.Redirect("~/Default.aspx");
        }

        public void ViewChanges(object sender, EventArgs e)
        {
            string sCallingPage = Session["CallingPage"].ToString() + ".aspx";
            Session["ViewMode"] = "Preview";

            lbMakeChanges.Visible = true;
            lbViewChanges.Visible = false;

            Response.Redirect(sCallingPage);
        }

        public void MakeChanges(object sender, EventArgs e)
        {
            string sCallingPage = Session["CallingPage"].ToString() + ".aspx";
            Session["ViewMode"] = "Normal";

            lbMakeChanges.Visible = false;
            lbViewChanges.Visible = true;

            Response.Redirect(sCallingPage);
        }

        public void LogIn(object sender, EventArgs e)
        {
            // merge password and salt together
            string sHashWithSalt = "richards719C29AF-1517-61B2-2928B60BFECB44EE";
            // convert this merged value to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(sHashWithSalt);

            // use hash algorithm to compute the hash
            System.Security.Cryptography.HashAlgorithm algorithm = new System.Security.Cryptography.SHA256Managed();
            // convert merged bytes to a hash as byte array
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // return the has as a base 64 encoded string
            String sHashedPassword = Convert.ToBase64String(hash);
        }

    }
}
