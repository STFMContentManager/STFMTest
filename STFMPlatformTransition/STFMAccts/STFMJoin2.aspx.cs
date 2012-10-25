using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using STFMAcctNavigate;

namespace STFM_Account_Manager_3
{
    public partial class STFMJoin2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            memtypename.Text = SetMemDesc(Request.QueryString["Mem"]);
            memrank.Text = Request.QueryString["Rank"];
            memdiscipline.Text = Request.QueryString["Disc"];
            mempos.Text = Request.QueryString["Pos"];
            memethnicity.Text = Request.QueryString["Ethnicity"];
            memdemo.Text = Request.QueryString["Rel"];
        }

        protected void ClickBackButton(object sender, EventArgs e)
        {
            string z;
            string y;

            z = Request.QueryString["Src"];
            y = Request.QueryString["Loc"];

            Navigate Nav = new Navigate();

            string dir = Nav.BackNavString(z, y);

            dir += "&Mem=" + Request.QueryString["Mem"];
            dir += "&Rank=" + Request.QueryString["Rank"] + "&Disc=" + Request.QueryString["Disc"];
            dir += "&Pos=" + Request.QueryString["Pos"] + "&Ethnicity=" + Request.QueryString["Ethnicity"];
            dir += "&Rel=" + Request.QueryString["Rel"];

            Response.Redirect(dir);
        }

        protected void ClickForwardButton(object sender, EventArgs e)
        {
            string dir = "JoinPage3.aspx?Mem=" + Request.QueryString["Mem"];
            Response.Redirect(dir);
        }

        private string SetMemDesc(string x)
        {
            switch (x)
            {
                case "1":
                    {
                        x = "Active Physician";
                        break;
                    }
                case "2":
                    {
                        x = "Active Nonphysician";
                        break;
                    }
                case "3":
                    {
                        x = "Associate";
                        break;
                    }
                case "4":
                    {
                        x = "International";
                        break;
                    }
                case "5":
                    {
                        x = "Lifetime Physician";
                        break;
                    }
                case "6":
                    {
                        x = "Lifetime Nonphysician";
                        break;
                    }
                case "7":
                    {
                        x = "Fellow-in-Training";
                        break;
                    }
                case "8":
                    {
                        x = "Resident";
                        break;
                    }
                case "9":
                    {
                        x = "Student";
                        break;
                    }
            }

            return x;
        }
    }
}