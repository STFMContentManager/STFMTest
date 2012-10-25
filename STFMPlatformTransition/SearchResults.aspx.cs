using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STFMPlatformTransition
{
    public partial class SearchResults1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SearchResults"] != null && Session["SearchResults"].ToString() != "")
            {
                List<SearchResults> lSearchResults = new List<SearchResults>();
                lSearchResults = Session["SearchResults"] as List<SearchResults>;

                dgSearchResults.DataSource = lSearchResults;
                dgSearchResults.DataBind();

                lSearchResults = null;
            }
        }
    }
}