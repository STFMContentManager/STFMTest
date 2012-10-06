using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STFMFoundationDonor
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Donation"] != null)
            {
                PopulatePage((Donation)Session["Donation"]);
            }
        }

        protected void clicknextbutton(object sender, EventArgs e)
        {
            Session["Donation"]=FDNDonor();

            if(Request.QueryString["Edit"] != "1")
            {
            Response.Redirect("FoundationDonate4.aspx");
            }
            if(Request.QueryString["Edit"]=="1")
            {
                Response.Redirect("FoundationDonate4.aspx");
            }
        }

        private Donation FDNDonor()
        {
            Donation Online = new Donation();

            RadioButton RBGroup;
            RBGroup = GetSelectedRadioButton(Form.Controls, "DnrAmt");

            if (RBGroup.ID == "rbother")
            {
                Online.Amount = Convert.ToInt16(tbAMTother.Text);
                Online.ProductType = "Other Donation Amount";
            }
            else
            {
                Online = SetProduct(RBGroup.ID);
            }

            RBGroup = null;

            Online.Designate = rbldesignate.SelectedItem.Text;
            Online.HonorVal = rblmemoryof.SelectedItem.Text;
            Online.HonorFname = tbfname.Text;
            Online.HonorLname = tblname.Text;

            Online.CCType = ddlpaymenttype.SelectedItem.Text;
            Online.CCNumber = tbccNumber.Text;
            Online.CCName = tbccName.Text;

            Online.CCExpMonth = Convert.ToInt16(ddlexpmonth.SelectedValue);
            Online.CCExpYear = Convert.ToInt16(ddlexpyear.SelectedValue);

            RBGroup = GetSelectedRadioButton(Form.Controls, "paytype");

            if (RBGroup.ID == rbChargeAboveAmt.ID)
            {
                Online.PayNow = true;
            }
            else
            {
                Online.PayNow = false;
                Online.ExtendedAmt = Convert.ToInt16(tbMonthlyAmt.Text);
                Online.ExtendedLength = Convert.ToInt16(tbMontlyTime.Text);
            }

            return Online;
        }

        private RadioButton GetSelectedRadioButton(string groupName)
        {
            return GetSelectedRadioButton(Controls, groupName);
        }

        private RadioButton GetSelectedRadioButton(ControlCollection controls, string groupName)
        {
            RadioButton retval = null;

            if (controls != null)
            {
                foreach (Control control in controls)
                {
                    if (control is RadioButton)
                    {
                        RadioButton radioButton = (RadioButton)control;

                        if (radioButton.GroupName == groupName && radioButton.Checked)
                        {
                            retval = radioButton;
                            break;
                        }
                    }

                    if (retval == null)
                    {
                        retval = GetSelectedRadioButton(control.Controls, groupName);
                    }
                }
            }

            return retval;
        }

        private Donation SetProduct(string id)
        {
            Donation RetrvProduct = new Donation();

            switch (id)
            {
                case "rbdirectors":
                    {
                        RetrvProduct.ProductType = "Director's Club";
                        RetrvProduct.Amount = 250;
                        break;
                    }
                case "rbtrustee":
                    {
                        RetrvProduct.ProductType = "Trustee's Club";
                        RetrvProduct.Amount = 500;
                        break;
                    }
                case "rbmentor":
                    {
                        RetrvProduct.ProductType = "Mentor's Club";
                        RetrvProduct.Amount = 100;
                        break;
                    }
                case "rbpresident":
                    {
                        RetrvProduct.ProductType = "President's Club";
                        RetrvProduct.Amount = 1000;
                        break;
                    }
            }

          

            return RetrvProduct;

        }

        private void PopulatePage(Donation x)
        {
            rbldesignate.SelectedValue = rbldesignate.Items.FindByText(x.Designate).Value;
            rblmemoryof.SelectedValue = rblmemoryof.Items.FindByText(x.HonorVal).Value;

            tbfname.Text = x.HonorFname;
            tblname.Text = x.HonorLname;

            switch (x.Amount)
            {
                case 500:
                    {
                        rbtrustee.Checked = true;
                        break;
                    }
                case 250:
                    {
                        rbdirectors.Checked = true;
                        break;
                    }
                case 1000:
                    {
                        rbpresident.Checked = true;
                        break;
                    }
                case 100:
                    {
                        rbmentor.Checked = true;
                        break;
                    }
                default:
                    {
                        rbother.Checked = true;
                        tbAMTother.Text = x.Amount.ToString();
                        break;
                    }
            }

            if (x.PayNow == true)
            {
                rbChargeAboveAmt.Checked = true;
            }
            else
            {
                rbChargeMonthly.Checked = true;
                tbMonthlyAmt.Text = x.ExtendedAmt.ToString();
                tbMontlyTime.Text = x.ExtendedLength.ToString();
            }

            x = null;
        }

    }
}