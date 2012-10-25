using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using STFMAcctNavigate;

namespace STFM_Account_Manager_3
{
    public partial class STFMAcct3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Request.QueryString["Src"] == "Update")
                {
                    linknextbutton.Enabled = false;
                    linknextbutton.Visible = false;
                    linkbackbutton.Text = "Done";
                    if(string.IsNullOrEmpty(Request.QueryString["Person"]) == false)
                    {
                    DataSetPopulate(Request.QueryString["Person"]);
                    }
                }
                PopulatePage();
            }
        }

        public void clkbackbtn(object sender, EventArgs e)
        {
            string z;
            string y;

            if (Request.QueryString["Edit"] == "1")
            {
                Response.Redirect("../STFMAccts/STFMAcct2.aspx?Src=" + Request.QueryString["Src"] + "&Loc=" + Request.QueryString["Loc"]);
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

            if (Request.QueryString["Edit"] == "1")
            {
                Response.Redirect("../STFMAccts/STFMAcct2.aspx?Src=" + Request.QueryString["Src"] + "&Loc=" + Request.QueryString["Loc"]);
            }
            z = Request.QueryString["Src"];
            y = Request.QueryString["Loc"];
            Navigate Test = new Navigate();

            Response.Redirect(Test.ForwardNavString(z, y), false);
        }

        public void ConfirmEdit(object sender, EventArgs e)
        {
            LinkButton x = (LinkButton)sender;
            string urlString = "";

            switch (x.ID)
            {
                case "PersonalInfoEdit":
                    {
                        urlString = "STFMAcct1.aspx?Src=" + Request.QueryString["Src"] + "&Loc=" + Request.QueryString["Loc"] + "&Edit=1";
                        break;
                    }
                case "Addr1Edit":
                    {
                        urlString = "STFMAcct2.aspx?Src=" + Request.QueryString["Src"] + "&Loc=" + Request.QueryString["Loc"] + "&Edit=1";
                        break;
                    }
                case "Addr2Edit":
                    {
                        urlString = "STFMAcct2.aspx?Src=" + Request.QueryString["Src"] + "&Loc=" + Request.QueryString["Loc"] + "&Edit=1";
                        break;
                    }                    
            }

            Response.Redirect(urlString);

        }

        public void ddladdr1typechange(object sender, EventArgs e)
        {
            ddladdr2typeselect.Items.Clear();
            ddladdr2typeselect = ddladdrtypealter(ddladdr1typeselect, ddladdr2typeselect);
        }

        public void ddladdr2typechange(object sender, EventArgs e)
        {
            ddladdr1typeselect.Items.Clear();
            ddladdr1typeselect = ddladdrtypealter(ddladdr2typeselect, ddladdr1typeselect);
        }

        public DropDownList ddladdrtypealter(DropDownList y, DropDownList x)
        {         
            STFMAcctData ResetDDL = new STFMAcctData();
            x = ResetDDL.BindMType(x);

            switch (y.SelectedItem.Value)
            {
                case "0":
                    {
                        break;
                    }
                case "1":
                    {
                        x.Items.Remove(x.Items.FindByValue("1"));
                        x.Items.Remove(x.Items.FindByValue("4"));
                        
                        break;
                    }
                case "2":
                    {
                        x.Items.Remove(x.Items.FindByValue("2"));
                        x.Items.Remove(x.Items.FindByValue("4"));
                        break;
                    }
                case "3":
                    {
                        x.Items.Remove(x.Items.FindByValue("1"));
                        x.Items.Remove(x.Items.FindByValue("2"));
                        x.Items.Remove(x.Items.FindByValue("4"));                      
                        x.SelectedIndex = 1;
                        break;
                    }
                case "4":
                    {
                        x.Items.Remove(x.Items.FindByValue("1"));
                        x.Items.Remove(x.Items.FindByValue("2"));
                        x.Items.Remove(x.Items.FindByValue("5"));
                        x.SelectedIndex = 1;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return x;
        }

        public void PopulatePage()
        {
            STFMAcctData SetMTypeList = new STFMAcctData();
            ddladdr1typeselect = SetMTypeList.BindMType(ddladdr1typeselect);
            ddladdr2typeselect = SetMTypeList.BindMType(ddladdr2typeselect);
            SetMTypeList = null;

            STFMAcctData GetPlaceText = new STFMAcctData();
            MemberInfo mem = (MemberInfo)Session["PersonInfo"];
            string displayname;

            displayname = mem.NameTitle + ' ' + mem.FirstName + ' ' + mem.LastName + ' ' + mem.NameSuffix + ' ' + mem.Degree;

            lblconfname.Text = displayname;
            lblconfemail.Text = mem.EmailAddress;
            lblconftxt.Text = mem.CellType.ToString();

            if (Session["Address1"] != null)
            {
                taddr1.Visible = true;
                MemAddressInfo addr1 = (MemAddressInfo)Session["Address1"];

                lbladdr1name.Text = displayname;

                if (GetPlaceText.GetCompanyText(addr1.AddressCompany) == "")
                {
                    traddr1company.Visible = false;
                    addr1.AddressCompany = null;
                }
                else
                {
                    lbladdr1company.Text = GetPlaceText.GetCompanyText(addr1.AddressCompany);
                }

                lbladdr1line1.Text = addr1.AddressLine1;
                lbladdr1line2.Text = (traddr1line2.Visible = (addr1.AddressLine2 == "" ? false : true)) == true ? addr1.AddressLine2 : null;
                lbladdr1line3.Text = (traddr1line3.Visible = (addr1.AddressLine3 == "" ? false : true)) == true ? addr1.AddressLine3 : null;

                if (addr1.AddressCountry == "236")
                {
                    lbladdr1city.Text = addr1.AddressCity + ", " + GetPlaceText.GetStateText(addr1.AddressState) + " " + addr1.AddressZip;
                }
                else
                {
                    lbladdr1city.Text = addr1.AddressCity + " " + addr1.AddressZip;
                }

                lbladdr1country.Text = GetPlaceText.GetCountryText(addr1.AddressCountry);

                if (addr1.AddressType == 4)
                {
                    ddladdr1typeselect.SelectedValue = "4";
                    ddladdr1typeselect.Enabled = false;
                }

            }
            else
            {
                taddr1.Visible = false;
            }
            if (Session["Address2"] != null)
            {
                taddr2.Visible = true;
                MemAddressInfo addr2 = (MemAddressInfo)Session["Address2"];


                lbladdr2name.Text = displayname;
                lbladdr2line1.Text = addr2.AddressLine1;
                lbladdr2line2.Text = (traddr2line2.Visible = (addr2.AddressLine2 == "" ? false : true)) == true ? addr2.AddressLine2 : null;
                lbladdr2line3.Text = (traddr2line3.Visible = (addr2.AddressLine3 == "" ? false : true)) == true ? addr2.AddressLine3 : null;

                if (addr2.AddressCountry == "236")
                {
                    lbladdr2city.Text = addr2.AddressCity + ", " + GetPlaceText.GetStateText(addr2.AddressState) + " " + addr2.AddressZip;
                }
                else
                {
                    lbladdr2city.Text = addr2.AddressCity + " " + addr2.AddressZip;
                }

                lbladdr2country.Text = GetPlaceText.GetCountryText(addr2.AddressCountry);

                if (addr2.AddressType == 4)
                {
                    ddladdr2typeselect.SelectedItem.Value = "4";
                    ddladdr2typeselect.Enabled = false;
                }

            }
            else
            {
                taddr2.Visible = false;
            }
        }

        public void DataSetPopulate(string x)
        {
            PassDB GetMember = new PassDB();
            Session["PersonInfo"] = GetMember.RetrieveMemInfo(x);
            Session["Address1"] = GetMember.RetrieveMemAddr(x, 2);
            Session["Address2"] = GetMember.RetrieveMemAddr(x, 1);
        }

    }
}