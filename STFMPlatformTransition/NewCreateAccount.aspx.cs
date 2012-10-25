using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcctSys
{
    public partial class AcctCreate : System.Web.UI.Page
    {
        protected void Page_Load(object x, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                PageSetup(0);
                tbaddr2.Visible = false;
            }
        }

        public void clkbackbtn(object x, EventArgs e)
        {
            Button backbtn = (Button)x;
            string backcmd = backbtn.CommandArgument.ToString();
            int backnum = 0;
            backnum = Convert.ToInt32(backcmd) - 1;

            PageSetup(backnum);
        }

        public void clknextbtn(object x, EventArgs e)
        {
            Button nextbtn = (Button)x;
            string nextcmd = nextbtn.CommandArgument.ToString();
            int nextnum = 0;
            nextnum = Convert.ToInt32(nextcmd) + 1;

            PageSetup(nextnum);
        }

        public void addr1typechange(object x, EventArgs e)
        {
            if (rbladdr1type.SelectedIndex == 1)
            {
                addr1company.Visible = true;
            }
            else
            {
                addr1company.Visible = false;
            }
        }

        public void addr2typechange(object x, EventArgs e)
        {
            if (rbladdr2type.SelectedIndex == 1)
            {
                addr2company.Visible = true;
            }
            else
            {
                addr2company.Visible = false;
            }
        }

        public void rbladdrselect(object x, EventArgs e)
        {
            if (rbladdr2.SelectedValue == "1" || rbladdr2.SelectedValue == "")
            {
                tbaddr2.Visible = false;
            }
            else
            {
                tbaddr2.Visible = true;
                //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#anchormailaddr';", true);
            }

            lmailerror.Text = "";
        }

        public void PageSetup(int x)
        {
            MemberInfo mem = new MemberInfo();
            InfoVal val = new InfoVal();
            bool fail = false;
            AcctCreate1.Visible = false;
            AcctCreate2.Visible = false;
            AcctCreate3.Visible = false;
            AcctCreate4.Visible = false;

            switch (x)
            {



                case -1:
                    {
                        Page.Response.Redirect("http://www.stfm.org");
                        break;
                    }
                case 0:
                    {

                        AcctCreate1.Visible = true;
                        break;
                    }
                case 1:
                    {

                        mem.NameTitle = ddltitle.SelectedValue.ToString();
                        mem.FirstName = tbfname.Text.ToString().Trim();
                        mem.MiddleName = tbmname.Text.ToString().Trim();
                        mem.LastName = tblname.Text.ToString().Trim();
                        mem.NameSuffix = tbsuffix.Text.ToString().Trim();
                        mem.Degree = tbdegree.Text.ToString().Trim();
                        mem.Emailaddress = tbemail.Text.ToString().Trim();
                        mem.Birthdate = tbbirthdate.Text.ToString().Trim();


                        if (val.Validate(mem, 1) != "ok")
                        {
                            trowerror.Visible = true;
                            cellerror.Text = "Required information missing!  Please complete all the highlighted fields below";
                            x = x - 1;
                            ddltitle.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                            tbfname.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                            tblname.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                            tbbirthdate.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                            tbemail.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                            AcctCreate1.Visible = true;

                            if (val.ValidateEmail(mem.Emailaddress) == 1)
                            {
                                cellerror.Text = "Required information missing!  Please complete all the highlighted fields below. <b>A valid email address is required.</b>";
                            }

                            mem = null;
                            break;
                        }
                        else
                        {
                            Session["MemberInfo"] = mem;

                            mem = null;
                        }

                        ddltitle.BackColor = System.Drawing.Color.White;
                        tbfname.BackColor = System.Drawing.Color.White;
                        tblname.BackColor = System.Drawing.Color.White;
                        tbbirthdate.BackColor = System.Drawing.Color.White;
                        tbemail.BackColor = System.Drawing.Color.White;
                        trowerror.Visible = false;
                        AcctCreate2.Visible = true;
                        break;
                    }
                case 2:
                    {

                        if (rbladdr2.SelectedValue == "")
                        {
                            lmailerror.Text = "Please select an option regarding your mailing address below.";
                            AcctCreate2.Visible = true;
                            x = x - 1;
                            break;
                        }
                        else
                        {

                            tbaddr2line1.BackColor = System.Drawing.Color.White;
                            tbaddr2city.BackColor = System.Drawing.Color.White;
                            ddladdr2state.BackColor = System.Drawing.Color.White;
                            tbaddr2zip.BackColor = System.Drawing.Color.White;
                            tbaddr2telephone.BackColor = System.Drawing.Color.White;
                            ddladdr1state.BackColor = System.Drawing.Color.White;
                            ddladdr1company.BackColor = System.Drawing.Color.White;
                            ddladdr2country.BackColor = System.Drawing.Color.White;
                            tbaddr1line1.BackColor = System.Drawing.Color.White;
                            tbaddr1city.BackColor = System.Drawing.Color.White;
                            ddladdr1state.BackColor = System.Drawing.Color.White;
                            tbaddr1zip.BackColor = System.Drawing.Color.White;
                            tbaddr1telephone.BackColor = System.Drawing.Color.White;
                            ddladdr1state.BackColor = System.Drawing.Color.White;
                            ddladdr1company.BackColor = System.Drawing.Color.White;
                            ddladdr1country.BackColor = System.Drawing.Color.White;

                            mem.Address1Company = Convert.ToInt16(ddladdr1company.SelectedValue);
                            mem.Address1Line1 = tbaddr1line1.Text.ToString().Trim();
                            mem.Address1City = tbaddr1city.Text.ToString().Trim();
                            mem.Address1State = Convert.ToInt16(ddladdr1state.SelectedValue);
                            mem.Address1Zip = tbaddr1zip.Text.ToString().Trim();
                            mem.Address1Country = Convert.ToInt16(ddladdr1country.SelectedValue);
                            mem.Address1Type = rbladdr1type.SelectedIndex;
                            mem.Address1Tel = tbaddr1telephone.Text.ToString().Trim();

                            if (Convert.ToInt16(rbladdr2.SelectedValue) == 2)
                            {
                                mem.Address2Company = Convert.ToInt16(ddladdr2company.SelectedValue);
                                mem.Address2Line1 = tbaddr2line1.Text.ToString().Trim();
                                mem.Address2City = tbaddr2city.Text.ToString().Trim();
                                mem.Address2State = Convert.ToInt16(ddladdr2state.SelectedValue);
                                mem.Address2Zip = tbaddr2zip.Text.ToString().Trim();
                                mem.Address2Country = Convert.ToInt16(ddladdr2country.SelectedValue);
                                mem.Address2Type = rbladdr2type.SelectedIndex;
                                mem.Address2Phone = tbaddr2telephone.Text.ToString().Trim();
                            }

                            if (Convert.ToInt16(rbladdr2.SelectedValue) == 2 && val.Validate(mem, 3) != "ok")
                            {
                                tbaddr2line1.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                                tbaddr2city.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                                ddladdr2state.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                                tbaddr2zip.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                                tbaddr2telephone.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                                if (ddladdr2country.SelectedIndex == 1) { ddladdr2state.BackColor = System.Drawing.Color.FromArgb(255, 255, 38); }
                                if (rbladdr2type.SelectedIndex == 1) { ddladdr2company.BackColor = System.Drawing.Color.FromArgb(255, 255, 38); }
                                ddladdr2country.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);

                                fail = true;
                            }

                            if (val.Validate(mem, 2) != "ok")
                            {
                                tbaddr1line1.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                                tbaddr1city.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                                ddladdr1state.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                                tbaddr1zip.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                                tbaddr1telephone.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);
                                if (ddladdr1country.SelectedIndex == 1) { ddladdr1state.BackColor = System.Drawing.Color.FromArgb(255, 255, 38); }
                                if (rbladdr1type.SelectedIndex == 1) { ddladdr1company.BackColor = System.Drawing.Color.FromArgb(255, 255, 38); }
                                ddladdr1country.BackColor = System.Drawing.Color.FromArgb(255, 255, 38);

                                fail = true;
                            }
                        }

                        if (fail == true)
                        {
                            BillAddrError.Visible = true;
                            BillAddrError.Text = "Please complete all highlighted fields.";
                            AcctCreate2.Visible = true;
                            mem = null;

                            x = x - 1;
                        }

                        else
                        {
                            AcctCreate3.Visible = true;

                            lblconfname.Text = ddltitle.SelectedItem.ToString() + ' ' + tbfname.Text + ' ' + tbmname.Text + ' ' + tblname.Text + ' ' + tbsuffix.Text + ' ' + tbdegree.Text;
                            lbladdr1name.Text = lblconfname.Text;
                            lbladdr2name.Text = lblconfname.Text;
                            lblconfemail.Text = tbemail.Text;
                            //lblconftxt.Text = rbltextmsg.SelectedItem.Text.ToString();

                            if (rbladdr1type.SelectedIndex == 1) { traddr1company.Visible = true; lbladdr1company.Text = ddladdr1company.SelectedItem.Text.ToString(); }
                            else { traddr1company.Visible = false; }

                            lbladdr1line1.Text = tbaddr1line1.Text;
                            lbladdr1line2.Text = tbaddr1line2.Text;
                            lbladdr1city.Text = tbaddr1city.Text;
                            lbladdr1state.Text = ddladdr1state.SelectedItem.Text.ToString().Substring(0, 2);
                            lbladdr1zip.Text = tbaddr1zip.Text;
                            lbladdr1country.Text = ddladdr1country.SelectedItem.Text.ToString();
                            lbladdr1phone.Text = val.ValidatePhone(tbaddr1telephone.Text.ToString().Trim());
                            lbladdr1fax.Text = tbaddr1fax.Text;

                            if (Convert.ToInt16(rbladdr2.SelectedValue) == 1)
                            {

                                if (rbladdr1type.SelectedIndex == 1) { traddr2company.Visible = true; lbladdr2company.Text = lbladdr1company.Text; }
                                else { traddr2company.Visible = false; }

                                lbladdr2line1.Text = lbladdr1line1.Text;
                                lbladdr2line2.Text = lbladdr1line2.Text;
                                lbladdr2city.Text = tbaddr1city.Text;
                                lbladdr2state.Text = lbladdr1state.Text;
                                lbladdr2zip.Text = lbladdr1zip.Text;
                                lbladdr2country.Text = lbladdr1country.Text;
                                lbladdr2phone.Text = lbladdr1phone.Text;
                                lbladdr2fax.Text = lbladdr1fax.Text;
                            }
                            else
                            {
                                if (rbladdr2type.SelectedIndex == 2) { traddr2company.Visible = true; lbladdr2company.Text = ddladdr2company.SelectedItem.Text.ToString(); }
                                else { traddr2company.Visible = false; }

                                lbladdr2line1.Text = tbaddr2line1.Text;
                                lbladdr2line2.Text = tbaddr2line2.Text;
                                lbladdr2city.Text = tbaddr2city.Text;
                                lbladdr2state.Text = ddladdr2state.SelectedItem.Text.ToString().Substring(0, 2);
                                lbladdr2zip.Text = tbaddr2zip.Text;
                                lbladdr2country.Text = ddladdr2country.SelectedItem.Text.ToString();
                                lbladdr2phone.Text = val.ValidatePhone(tbaddr2telephone.Text.ToString().Trim());
                                lbladdr2fax.Text = tbaddr2fax.Text;

                            }


                            //lblconfemail.Text = tbemail.Text;
                            //lblconftxt.Text = tbcellphone.Text;


                        }
                        break;
                    }
                case 3:
                    {
                        AcctCreate4.Visible = true;
                        break;
                    }
                case 4:
                    {
                        if (val.ValidateString(tbusername.Text) == 1 || val.ValidateString(tbpassword.Text) == 1 || val.ValidateString(tbpasswordconf.Text) == 1)
                        {
                            AcctCreate4.Visible = true;
                            PWerror.Visible = true;
                            PWerror.Text = "Please complete all fields";
                            x = x - 1;
                        }
                        break;
                    }
            }

            backbutton.CommandArgument = x.ToString();
            nextbutton.CommandArgument = x.ToString();

        }
    }
}