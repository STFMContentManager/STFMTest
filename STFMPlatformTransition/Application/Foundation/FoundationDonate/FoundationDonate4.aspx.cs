using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace STFMFoundationDonor
{
    public partial class STFMAcct3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Request.QueryString["Src"] == "Edit")
                {
                    DataSetPopulate(Request.QueryString["Person"]);
                }

                PopulatePage();
            }
        }

        public void clkbackbtn(object sender, EventArgs e)
        {
            Response.Redirect("FoundationDonate3.aspx");
        }

        public void clknextbtn(object sender, EventArgs e)
        {
            if (Request.QueryString["Edit"] != "1")
            {
                Response.Redirect("FoundationDonate5.aspx");                
            }
        }

        public void ConfirmEdit(object sender, EventArgs e)
        {
            LinkButton x = (LinkButton)sender;

            switch (x.ID)
            {
                case "PersonalInfoEdit":
                    {
                        Response.Redirect("FoundationDonate1.aspx?" + "&Edit=1");
                        break;
                    }
                case "Addr1Edit":
                    {
                        Response.Redirect("FoundationDonate2.aspx?" + "&Edit=1");
                        break;
                    }
                case "Addr2Edit":
                    {
                        Response.Redirect("FoundationDonate2.aspx?" + "&Edit=1");
                        break;
                    }
                case "PurchaseEdit":
                    {
                        Response.Redirect("FoundationDonate3.aspx?" + "&Edit=1");
                        break;
                    }                    
            }
        }

        //public void ddladdr1typechange(object sender, EventArgs e)
        //{
        //    ddladdr2typeselect.Items.Clear();
        //    ddladdr2typeselect = ddladdrtypealter(ddladdr1typeselect, ddladdr2typeselect);
        //}

        //public void ddladdr2typechange(object sender, EventArgs e)
        //{
        //    ddladdr1typeselect.Items.Clear();
        //    ddladdr1typeselect = ddladdrtypealter(ddladdr2typeselect, ddladdr1typeselect);
        //}

        //public DropDownList ddladdrtypealter(DropDownList y, DropDownList x)
        //{         
        //    STFMAcctData ResetDDL = new STFMAcctData();
        //    x = ResetDDL.BindMType(x);

        //    switch (y.SelectedItem.Value)
        //    {
        //        case "0":
        //            {
        //                break;
        //            }
        //        case "1":
        //            {
        //                x.Items.Remove(x.Items.FindByValue("1"));
        //                x.Items.Remove(x.Items.FindByValue("4"));
                        
        //                break;
        //            }
        //        case "2":
        //            {
        //                x.Items.Remove(x.Items.FindByValue("2"));
        //                x.Items.Remove(x.Items.FindByValue("4"));
        //                break;
        //            }
        //        case "3":
        //            {
        //                x.Items.Remove(x.Items.FindByValue("1"));
        //                x.Items.Remove(x.Items.FindByValue("2"));
        //                x.Items.Remove(x.Items.FindByValue("4"));                      
        //                x.SelectedIndex = 1;
        //                break;
        //            }
        //        case "4":
        //            {
        //                x.Items.Remove(x.Items.FindByValue("1"));
        //                x.Items.Remove(x.Items.FindByValue("2"));
        //                x.Items.Remove(x.Items.FindByValue("5"));
        //                x.SelectedIndex = 1;
        //                break;
        //            }
        //        default:
        //            {
        //                break;
        //            }
        //    }

        //    return x;
        //}

        public void PopulatePage()
        {
            STFMAcctData SetMTypeList = new STFMAcctData();
            //ddladdr1typeselect = SetMTypeList.BindMType(ddladdr1typeselect);
            //ddladdr2typeselect = SetMTypeList.BindMType(ddladdr2typeselect);
            SetMTypeList = null;

            STFMAcctData GetPlaceText = new STFMAcctData();

                MemberInfo mem = (MemberInfo)Session["PersonInfo"];

                string displayname;

                displayname = mem.NameTitle + ' ' + mem.FirstName + ' ' + mem.LastName + ' ' + mem.NameSuffix + ' ' + mem.Degree;

                lblconfname.Text = displayname;
                lblconfemail.Text = mem.EmailAddress;
                lblbday.Text = mem.Birthdate.ToShortDateString();

            if (Session["Donation"] != null)
                {

                Donation FDNOnline = (Donation)Session["Donation"];

                lblDNRAmt.Text = FDNOnline.ProductType + " $" + FDNOnline.Amount;
                if (FDNOnline.Designate == "Please use my gift where needed")
                {
                    trFDNDesignate.Visible = false;
                }
                else
                {
                    lblDNRDesignate.Text = FDNOnline.Designate;
                }

                if (FDNOnline.HonorVal != "not applicable")
                {
                    lblDNRHonor.Text = FDNOnline.HonorVal + " " + FDNOnline.HonorFname + " " + FDNOnline.HonorLname;
                }

                lblDNRCCname.Text = FDNOnline.CCName;
                lblDNRCCType.Text = FDNOnline.CCType;

                string CCNumMask = new string('x', FDNOnline.CCNumber.Length-4) + FDNOnline.CCNumber.Substring(FDNOnline.CCNumber.Length-4);

                lblDNRCCNum.Text = CCNumMask;

                }

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
                    //ddladdr1typeselect.SelectedValue = "4";
                    //ddladdr1typeselect.Enabled = false;
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