using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace STFMFoundationDonor
{
    public partial class STFMAcct2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbaddr1line1.BackColor = System.Drawing.Color.White;
            tbaddr1city.BackColor = System.Drawing.Color.White;
            tbaddr1zip.BackColor = System.Drawing.Color.White;
            ddladdr1country.BackColor = System.Drawing.Color.White;
            tbaddr1telephone.BackColor = System.Drawing.Color.White;
            ddladdr1company.BackColor = System.Drawing.Color.White;
            ddladdr1state.BackColor = System.Drawing.Color.White;
            tbaddr2line1.BackColor = System.Drawing.Color.White;
            tbaddr2city.BackColor = System.Drawing.Color.White;
            tbaddr2zip.BackColor = System.Drawing.Color.White;
            ddladdr2country.BackColor = System.Drawing.Color.White;
            tbaddr2telephone.BackColor = System.Drawing.Color.White;
            ddladdr2state.BackColor = System.Drawing.Color.White;

            if (Page.IsPostBack == false)
            {
                MemAddressInfo Addr1 = new MemAddressInfo();

                Addr1 = (MemAddressInfo)(Session["AddressInfo"]);

                DropdownSetup(Addr1.AddressState, Addr1.AddressCountry);

                Addr1 = null;
                
                if(Session["Address1"] != null)
                {
                    MemAddressInfo Address1 = new MemAddressInfo();
                    Address1 = (MemAddressInfo)Session["Address1"];
                    PopulateFields(Address1, 1);
                    Address1 = null;
                    Session.Remove("Address1");
                }

                if(Session["Address2"] != null)
                {
                    MemAddressInfo Address2 = new MemAddressInfo();
                    Address2 = (MemAddressInfo)Session["Address2"];
                    PopulateFields(Address2, 2);
                    Address2 = null;
                    Session.Remove("Address2");
                }

            }

        }

        public void clkbackbtn(object x, EventArgs e)
        {

            if (Request.QueryString["Edit"] != "1")
            {
                Response.Redirect("FoundationDonate1.aspx");
            }
            if (Request.QueryString["Edit"] == "1")
            {
                Response.Redirect("FoundationDonate4.aspx");
            }
        }
        public void clknextbtn(object x, EventArgs e)
        {        
            if (ValidateAddress() == true)
            {
                if (Request.QueryString["Edit"] != "1")
                {
                    Response.Redirect("FoundationDonate3.aspx");
                }
            }
            if (Request.QueryString["Edit"] == "1")
            {
                Response.Redirect("FoundationDonate4.aspx");
            }
        }

        public void ddlCountry_addr1Change(object x, EventArgs e)
        {
            ddladdr1state = CountryDDlChange(ddladdr1state,ddladdr1country);
        }

        public void ddlCountry_addr2Change(object x, EventArgs e)
        {
            ddladdr2state = CountryDDlChange(ddladdr2state,ddladdr2country);
        }

        public void ddlState_Change(object x, EventArgs e)
        {
            if(Convert.ToInt16(ddladdr1state.SelectedItem.Value) != 0 && Convert.ToInt16(ddladdr1state.SelectedItem.Value) != 66)
            {
                STFMAcctData BindStateDDL = new STFMAcctData();
                ddladdr1company = BindStateDDL.BindCompany(ddladdr1company, ddladdr1state.SelectedValue);
            }
        }

        public DropDownList CountryDDlChange(DropDownList x, DropDownList y)
        {
            if (Convert.ToInt16(y.SelectedItem.Value) == 236)
            {
                x.Enabled = true;
                x.SelectedIndex = 0;
            }
            else
            {
                x.Enabled = false;
                x.SelectedIndex = 66;
            }

            return x;
        }
        
        /*This is the whole system that assigns control values to variables, verifies them
         * and does any marking for errors.  If this returns a true value, then the page advances 
         * to the next site in the Acct system
         */
        public bool ValidateAddress()
        {
            //Infoval is method in the STFMAcctValidator class that will check the addresses
            InfoVal ConfirmAddr = new InfoVal();

            //Declaring both the potential address vars
            MemAddressInfo Addr1 = new MemAddressInfo();
            MemAddressInfo Addr2 = new MemAddressInfo();

            //We only bother to verify an address if the user has filled in at least one of the 
            //address lines for either address option.  Otherwise Addr1 remains empty
            if (tbaddr1line1.Text != "" || tbaddr1line2.Text != "" || tbaddr1line3.Text != "")
            {                
                Addr1.AddressLine1 = tbaddr1line1.Text.ToString();
                Addr1.AddressLine2 = tbaddr1line2.Text.ToString();
                Addr1.AddressLine3 = tbaddr1line3.Text.ToString();

                Addr1.AddressCompany = ddladdr1company.SelectedValue;
                Addr1.AddressCity = tbaddr1city.Text.ToString();
                Addr1.AddressZip = tbaddr1zip.Text.ToString();
                Addr1.AddressState = ddladdr1state.SelectedIndex.ToString();
                Addr1.AddressCountry = ddladdr1country.SelectedValue;
                Addr1.AddressPhone = tbaddr1telephone.Text.ToString();
                Addr1.AddressFax = tbaddr1fax.Text.ToString();
                Addr1.AddressLoc = 2;
            }
            else
            {
                //If Addr1 is deemed undefined, Addr2's address type (billing, mailing, or both)
                //is set to both since it will be the only address
                Addr2.AddressType = 4;
            }

            //Does the same process for the home address as was done above for the business address
            if (tbaddr2line1.Text != "" || tbaddr2line2.Text != "" || tbaddr2line3.Text != "")
            {
                Addr2.AddressLine1 = tbaddr2line1.Text.ToString();
                Addr2.AddressLine2 = tbaddr2line2.Text.ToString();
                Addr2.AddressLine3 = tbaddr2line3.Text.ToString();

                Addr2.AddressCity = tbaddr2city.Text.ToString();
                Addr2.AddressZip = tbaddr2zip.Text.ToString();
                Addr2.AddressState = ddladdr2state.SelectedValue;
                Addr2.AddressCountry = ddladdr2country.SelectedValue;
                Addr2.AddressPhone = tbaddr2telephone.Text.ToString();
                Addr2.AddressFax = tbaddr2fax.Text.ToString();
                Addr2.AddressLoc = 1;
            }
            else
            {
                Addr1.AddressType = 4;
            }

            //Checks to see if both addresses are empty.
            //An AddressLoc value of 0 means that neither address was filled in and
            //assigned to Addr1 or Addr2
            if (Addr1.AddressLoc == 0 && Addr2.AddressLoc == 0)
            {
                return false;
            }
            else
            {
                if (ConfirmAddr.AddressValidate(Addr1) == "ok" && ConfirmAddr.AddressValidate(Addr2) == "ok")
                {
                    if (Addr1.AddressLoc != 0) { Session["Address1"] = Addr1; }
                    if (Addr2.AddressLoc != 0) { Session["Address2"] = Addr2; }
                    
                    Addr1 = null;
                    Addr2 = null;
                    return true;
                }
                else
                {
                    if (Addr1.AddressLoc != 0)
                    {
                        tbaddr1line1.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                        tbaddr1city.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                        tbaddr1zip.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                        ddladdr1country.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                        tbaddr1telephone.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                        ddladdr1company.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);

                        if (ddladdr1country.SelectedItem.Value == "236")
                        {
                            ddladdr1state.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                        }

                    }
                    if (Addr2.AddressLoc != 0)
                    {
                        tbaddr2line1.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                        tbaddr2city.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                        tbaddr2zip.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                        ddladdr2country.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                        tbaddr2telephone.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);

                        if (ddladdr2country.SelectedItem.Value == "236")
                        {
                            ddladdr2state.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                        }

                    }
                    return false;
                }
            }

        }

        public void DropdownSetup(string StateVal, string CountryVal)
        {
            //Populates the states list dropdown list

            STFMAcctData BindDDL = new STFMAcctData();

            ddladdr1state = BindDDL.BindState(ddladdr1state);
            ddladdr2state = BindDDL.BindState(ddladdr2state);

            ddladdr1state.SelectedValue = StateVal;
            ddladdr2state.SelectedValue = StateVal;

            ddladdr1country = BindDDL.BindCountry(ddladdr1country);
            ddladdr2country = BindDDL.BindCountry(ddladdr2country);

            ddladdr2country.SelectedValue = CountryVal;
            ddladdr1country.SelectedValue = CountryVal;

            ddladdr1company = BindDDL.BindCompany(ddladdr1company, StateVal);

            BindDDL = null;

            if (CountryVal != "236")
            {
                ddladdr1state.Enabled = false;
                ddladdr2state.Enabled = false;
            }
           
        }

        public void PopulateFields(MemAddressInfo addr, int x)
        {
            switch (x)
            {
                case 1:
                    {
                        tbaddr1line1.Text = addr.AddressLine1;
                        tbaddr1line2.Text = addr.AddressLine2;
                        tbaddr1line3.Text = addr.AddressLine3;

                        ddladdr1company.SelectedValue = addr.AddressCompany;
                        tbaddr1city.Text = addr.AddressCity;
                        tbaddr1zip.Text = addr.AddressZip;
                        ddladdr1state.SelectedValue = addr.AddressState;
                        ddladdr1country.SelectedValue = addr.AddressCountry;
                        tbaddr1telephone.Text = addr.AddressPhone;
                        tbaddr1fax.Text = addr.AddressFax;
                        break;
                    }
                case 2:
                    {
                        tbaddr2line1.Text = addr.AddressLine1;
                        tbaddr2line2.Text = addr.AddressLine2;
                        tbaddr2line3.Text = addr.AddressLine3;

                        tbaddr2city.Text = addr.AddressCity;
                        tbaddr2zip.Text = addr.AddressZip;
                        ddladdr2state.SelectedValue = addr.AddressState;
                        ddladdr2country.SelectedValue = addr.AddressCountry;
                        tbaddr2telephone.Text = addr.AddressPhone;
                        tbaddr2fax.Text = addr.AddressFax;
                        break;
                    }
            }
        }

    }


}