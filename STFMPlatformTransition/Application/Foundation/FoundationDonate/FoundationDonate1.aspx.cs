using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using STFMAccounts;

namespace STFMFoundationDonor
{


    public partial class STFMAcct1 : System.Web.UI.Page
    {
        //Pageload sets the data values to the objects tied to the database
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                DropdownSetup();
                if (Session["PersonInfo"] != null)
                {
                    PopulateFields((MemberInfo)Session["PersonInfo"]);
                }
            }
        }

        //Next Button ONCLICK
        public void clknextbtn(object x, EventArgs e)
        {
            if (VerifyInfo() == true)
            {
                if (Request.QueryString["Edit"] != "1")
                {
                    Response.Redirect("FoundationDonate2.aspx");
                }
                if (Request.QueryString["Edit"] == "1")
                {
                    Response.Redirect("FoundationDonate4.aspx");
                }

            }
        }

        public void clkbackbtn(object x, EventArgs e)
        {
            if (Request.QueryString["Edit"] != "1")
            {
                Response.Redirect("http://www.stfm.org/fnd");
            }
            if (Request.QueryString["Edit"] == "1")
            {
                Response.Redirect("FoundationDonate4.aspx");
            }
        }

        public void MainCountryChange(object x, EventArgs e)
        {
            if (Convert.ToInt16(ddlMainCountry.SelectedItem.Value) == 236)
            {
                ddlworkstate.Enabled = true;
                ddlworkstate.SelectedIndex = 0;
            }
            else
            {
                ddlworkstate.Enabled = false;
                ddlworkstate.SelectedIndex = 66;
            }
        }

        public bool VerifyInfo()
        {

            MemberInfo mem = new MemberInfo();
            MemAddressInfo Address1 = new MemAddressInfo();

            int day = Convert.ToInt16(ddlDay.SelectedItem.Text);
            int year = Convert.ToInt16(ddlYear.SelectedItem.Value);
            int month = (Convert.ToInt16(ddlMonth.SelectedIndex) + 1);

            DateTime Bday = new DateTime(year, month, day);
            mem.Birthdate = Bday;            

            mem.NameTitle = ddltitle.SelectedItem.Text;
            mem.FirstName = tbfname.Text.ToString().Trim();
            mem.MiddleName = tbmname.Text.ToString().Trim();
            mem.LastName = tblname.Text.ToString().Trim();
            mem.NameSuffix = tbsuffix.Text.ToString().Trim();
            mem.Degree = tbdegree.Text.ToString().Trim();
            mem.EmailAddress = tbemail.Text.ToString().Trim();
            //mem.Birthdate = tbbirthdate.Text.ToString().Trim();
            mem.Cellphone = tbcellphone.Text.ToString().Trim();
            
            if (mem.Cellphone != null)
            {
                if (rbltextmsg.SelectedValue == "" || rbltextmsg.SelectedValue == "2")
                {
                    mem.CellType = 1;
                }
                else
                {
                    mem.CellType = 2;
                }

            }

            Address1.AddressCountry = ddlMainCountry.SelectedValue;
            Address1.AddressState = ddlworkstate.SelectedItem.Value;

            InfoVal Page1Validate = new InfoVal();

            if (Page1Validate.PersonValidate(mem) != "ok" || Page1Validate.ValidateCountryPage1(Address1) != "ok")
            {
                mem = null;
                Address1 = null;

                ddltitle.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                tbfname.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                tblname.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                //tbbirthdate.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                tbemail.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                ddlMainCountry.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                ddlworkstate.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);

                return false;
            }
            else
            {
                Session["PersonInfo"] = mem;
                Session["AddressInfo"] = Address1;

                mem = null;
                Address1 = null;
                return true;
            }
        }
        

        //SETS UP THE DROPDOWNS FOR THE SITE WITH STUFF FROM THE DATASOURCE
        public void DropdownSetup()
        {
            //Populates the states list dropdown list
            STFMAcctData StatesData = new STFMAcctData();

            ddlworkstate.DataSource = StatesData.StateDropDown();
            ddlworkstate.DataTextField = "nametext";
            ddlworkstate.DataValueField = "ID";
            ddlworkstate.DataBind();

            ddlworkstate.Items.Insert(0, "Select One");
            //ddlworkstate.Items.Insert(66, "Non-US");

            //Populates the country list dropdown list
            STFMAcctData CountryData = new STFMAcctData();

            ddlMainCountry.DataSource = CountryData.CountryDropDown();
            ddlMainCountry.DataTextField = "CountryName";
            ddlMainCountry.DataValueField = "ID";
            ddlMainCountry.DataBind();

            ddlMainCountry.Items.Insert(0, "Select One");


            for (int i = DateTime.Now.Year; i > 1900; i--)
            {
                ListItem item = new ListItem(i.ToString());
                ddlYear.Items.Add(item);
            }

            for (int i = 1; i <= 31; i++)
            {
                ListItem item = new ListItem(i.ToString());
                ddlDay.Items.Add(item);
            }

            ddlMonth.Items.Insert(0, "Jan");
            ddlMonth.Items.Insert(1, "Feb");
            ddlMonth.Items.Insert(2, "March");
            ddlMonth.Items.Insert(3, "April");
            ddlMonth.Items.Insert(4, "May");
            ddlMonth.Items.Insert(5, "June");
            ddlMonth.Items.Insert(6, "July");
            ddlMonth.Items.Insert(7, "Aug");
            ddlMonth.Items.Insert(8, "Sept");
            ddlMonth.Items.Insert(9, "Oct");
            ddlMonth.Items.Insert(10, "Nov");
            ddlMonth.Items.Insert(11, "Dec");
            
        }

        public void PopulateFields(MemberInfo mem)
        {
            ddltitle.SelectedValue = ddltitle.Items.FindByText(mem.NameTitle).Value;
            tbfname.Text = mem.FirstName;
            tbmname.Text = mem.MiddleName;
            tblname.Text = mem.LastName;
            tbsuffix.Text = mem.NameSuffix;
            tbdegree.Text = mem.Degree;
            tbemail.Text = mem.EmailAddress;
            //tbbirthdate.Text = mem.Birthdate;
            tbcellphone.Text = mem.Cellphone;
            ddlDay.SelectedValue = mem.Birthdate.Day.ToString();
            ddlMonth.SelectedIndex = (mem.Birthdate.Month - 1);
            ddlYear.SelectedValue = mem.Birthdate.Year.ToString();
        }

        public DropDownList BdaySetup(int Field)
        {
            DropDownList BdayFields = new DropDownList();

            for (int i = DateTime.Now.Year; i > 1900; i--)
            {
                ListItem item = new ListItem(i.ToString());
                BdayFields.Items.Add(item);
            }

            return BdayFields;
        }

    }
}