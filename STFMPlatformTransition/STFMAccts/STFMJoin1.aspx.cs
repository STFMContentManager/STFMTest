using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using STFMAcctNavigate;

namespace STFM_Account_Manager_3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Request.QueryString["Mem"]) != true)
            {
                if (Page.IsPostBack == false)
                {
                    populatefields();
                }
            }
        }

        public void clkbackbtn(object sender, EventArgs e)
        {
            string z;
            string y;

            if (Request.QueryString["Edit"] == "1")
            {
                Response.Redirect("/STFMAcct3.aspx?Src=" + Request.QueryString["Src"] + "&Loc=" + Request.QueryString["Loc"]);
            }    
            z = Request.QueryString["Src"];
            y = Request.QueryString["Loc"];
            Navigate Test = new Navigate();

            Response.Redirect(Test.BackNavString(z, y), false);
        }

        public void clknextbtn(object sender, EventArgs e)
        {

            string z;
            string y;
            string memval = "0";
            int i = 0;

            if (Request.QueryString["Edit"] == "1")
            {
                Response.Redirect("/STFMAcct3.aspx?Src=" + Request.QueryString["Src"] + "&Loc=" + Request.QueryString["Loc"]);
            }
            z = Request.QueryString["Src"];
            y = Request.QueryString["Loc"];

            Navigate Test = new Navigate();

            RadioButtonList[] rblholder = new RadioButtonList[3];
            rblholder[0] = rblmemtype1;
            rblholder[1] = rblmemtype2;
            rblholder[2] = rblmemtype3;

            while (memval == "0")
            {
                //!! This try catch is temporary and for testing purposes only.  Put some real validation 
                //in at some point !!
                try
                {
                    memval = SetMemType(rblholder[i]);
                }
                catch
                {
                    memval = "1";
                }
                i++;
            }


                                    
            string step2url = Test.ForwardNavString(z, y);
            step2url += "&Mem=" + Server.UrlEncode(memval) + "&Pos=" + Server.UrlEncode(ddlPosition.SelectedItem.Text);
            step2url += "&Rank=" + Server.UrlEncode(ddlrank.SelectedItem.Text) + "&Disc=" + Server.UrlEncode(ddldiscipline.SelectedItem.Text);
            step2url += "&Rel=" + Server.UrlEncode(rblethnicity.SelectedItem.Text) + "&Ethnicity=" + Server.UrlEncode(ddlethnicity.SelectedItem.Text);

            z = null;
            y = null;
            rblholder = null;
            memval = null;

            Response.Redirect(step2url, false);
        }

        protected void SetMemList(object sender, EventArgs e)
        {
            RadioButtonList rbl = (RadioButtonList)sender;
            int selectedval = Convert.ToInt16(rbl.SelectedItem.Value);

            rblmemtype1.ClearSelection();
            rblmemtype2.ClearSelection();
            rblmemtype3.ClearSelection();

            if (selectedval >= 0 && selectedval < 5)
            {
                rblmemtype1.SelectedValue = selectedval.ToString();
            }
            if (selectedval >= 5 && selectedval < 7)
            {
                rblmemtype2.SelectedValue = selectedval.ToString();
            }
            if (selectedval > 6 && selectedval < 10)
            {
                rblmemtype3.SelectedValue = selectedval.ToString();
            }
        }

        private string SetMemType(RadioButtonList x)
        {
            string rblvalue;

            if (x.SelectedValue == "")
            {
                rblvalue = "0";
            }
            else
            {
                rblvalue = x.SelectedValue.ToString();
            }

            return rblvalue;
        }
        private void populatefields()
        {
            int MemType = Convert.ToInt16(Request.QueryString["Mem"]);

            if (MemType > 0 && MemType < 5)
            {
                rblmemtype1.SelectedValue = MemType.ToString();
            }
            if (MemType > 4 && MemType < 7)
            {
                rblmemtype2.SelectedValue = MemType.ToString();
            }
            if (MemType > 6 && MemType < 10)
            {
                rblmemtype3.SelectedValue = MemType.ToString();
            }

            ddldiscipline.SelectedValue = ddldiscipline.Items.FindByText(Request.QueryString["Disc"]).Value;
            ddlPosition.SelectedValue = ddlPosition.Items.FindByText(Request.QueryString["Pos"]).Value;
            ddlethnicity.SelectedValue = ddlethnicity.Items.FindByText(Request.QueryString["Ethnicity"]).Value;
            rblethnicity.SelectedValue = rblethnicity.Items.FindByText(Request.QueryString["Rel"]).Value;
            ddlrank.SelectedValue = ddlrank.Items.FindByText(Request.QueryString["Rank"]).Value;
        }
    }
}