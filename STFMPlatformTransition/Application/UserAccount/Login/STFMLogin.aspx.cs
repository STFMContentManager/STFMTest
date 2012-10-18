using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using STFMAcctNavigate;
using STFMAccounts;

namespace STFM_Account_Login
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
           InfoVal ChkPWord = new InfoVal();

            if (ChkPWord.ValidateString(tbusername.Text) != 0 || ChkPWord.ValidateString(tbpassword.Text) != 0)
            {
                PWerror.Visible = true;
                PWerror.Text = "Please complete all fields";
            }
            //else
            //{
            //    string z;
            //    string y;

            //    SQLParamSet();

            //    if (Request.QueryString["Edit"] == "1")
            //    {
            //        Response.Redirect("../STFMAccts/STFMAcct2.aspx?Src=" + Request.QueryString["Src"] + "&Loc=" + Request.QueryString["Loc"]);
            //    }
            //    z = Request.QueryString["Src"];
            //    y = Request.QueryString["Loc"];
            //    Navigate Test = new Navigate();
            //    Session.Abandon();
            //    Response.Redirect(Test.ForwardNavString(z, y), false);
            //}
 
        }

        public void SQLParamSet()
        {

                linknextbutton.Enabled = false;
                PassDB DataCollector = new PassDB();

                List<MemAddressInfo> AllAddr = new List<MemAddressInfo>();
                if (Session["Address1"] != null) { AllAddr.Add((MemAddressInfo)Session["Address1"]); }
                if (Session["Address2"] != null) { AllAddr.Add((MemAddressInfo)Session["Address2"]); }


                MemberInfo mem = new MemberInfo();
                mem = (MemberInfo)(Session["PersonInfo"]);

                SqlParameter[] MemParams = {
                    new SqlParameter("SQLPrefix", mem.NameTitle),
                    new SqlParameter("SQLFname", mem.FirstName),
                    (mem.MiddleName == "" ? new SqlParameter("SQLMname", DBNull.Value) : new SqlParameter("SQLMname", mem.MiddleName)),
                    new SqlParameter("SQLLname", mem.LastName),
                    (mem.NameSuffix == "" ? new SqlParameter("SQLsuffix", DBNull.Value) : new SqlParameter("SQLsuffix", mem.NameSuffix)),
                    new SqlParameter("SQLBday", mem.Birthdate)
                    };

                int rowid = DataCollector.SQLReturnData(MemParams, "NameTest");

                SqlParameter[] CellPhoneParams = {
                    new SqlParameter("PersonID", rowid),
                    new SqlParameter("PhoneNum", mem.Cellphone),
                    new SqlParameter("CountryCode", AllAddr[0].AddressCountry),
                    new SqlParameter("PhoneTypeCode", mem.CellType)
                    };

                DataCollector.SQLReturnVoid(CellPhoneParams, "InsertPhone");

                SqlParameter[] EmailParams = 
                    {
                        new SqlParameter("PersonID", rowid),
                        new SqlParameter("EmailAddress", mem.EmailAddress)
                    };

                DataCollector.SQLReturnVoid(EmailParams, "EmailInsert");

                foreach (MemAddressInfo x in AllAddr)
                {
                    DBInsertAddr(rowid, x, DataCollector);
                }

                //for (int i = 0; i < AllAddr.Count; i++)
                //{

                //}
                
        }

        public void DBInsertAddr(int identity, MemAddressInfo addr, PassDB AddrCollector)
        {
            int PhoneLoc = 0;

            if(addr.AddressLoc == 2)
            {
                PhoneLoc = 4;
            }
            if(addr.AddressLoc == 1)
            {
                PhoneLoc = 3;
            }
            
            SqlParameter[] AddrParams = 
                {
                    new SqlParameter("PersonID", identity),
                    new SqlParameter("AddressLine1", addr.AddressLine1),
                    (addr.AddressLine2 == null ? new SqlParameter("AddressLine2", DBNull.Value) : new SqlParameter("AddressLine2", addr.AddressLine2)),
                    (addr.AddressLine3 == null ? new SqlParameter("AddressLine3", DBNull.Value) : new SqlParameter("AddressLine3", addr.AddressLine3)),
                    new SqlParameter("City", addr.AddressCity),
                    //new SqlParameter("States", Convert.ToInt16(addr.AddressState)),
                    (Convert.ToInt16(addr.AddressState) < 1 || Convert.ToInt16(addr.AddressState) > 65 ? 
                        new SqlParameter("States", DBNull.Value) : new SqlParameter("States", addr.AddressState)),
                    new SqlParameter("Zip", addr.AddressZip),
                    new SqlParameter("CountryID", Convert.ToInt16(addr.AddressCountry)),
                    new SqlParameter("MailingTypeCode", Convert.ToInt16(addr.AddressType)),
                    new SqlParameter("LocationTypeCode", Convert.ToInt16(addr.AddressLoc))
                };

            AddrCollector.SQLReturnVoid(AddrParams, "AddressInsert");

            if(addr.AddressLoc == 2 && addr.AddressCompany != null)
            {
                SqlParameter[] CompanyParams = 
                {
                    new SqlParameter("PersonID", identity),
                    new SqlParameter("CompanyID", addr.AddressCompany)
                };

                AddrCollector.SQLReturnVoid(CompanyParams, "InsertCompany");
            }

            SqlParameter[] TelParams = 
            {
                new SqlParameter("PersonID", identity),
                new SqlParameter("PhoneNum", addr.AddressPhone),
                new SqlParameter("CountryCode", addr.AddressCountry),
                new SqlParameter("PhoneTypeCode", PhoneLoc)
            };

            AddrCollector.SQLReturnVoid(TelParams, "InsertPhone");

            if (addr.AddressFax != "")
            {
                SqlParameter[] FaxParams = 
                {
                    new SqlParameter("PersonID", identity),
                    new SqlParameter("PhoneNum", addr.AddressPhone),
                    new SqlParameter("CountryCode", addr.AddressCountry),
                    new SqlParameter("PhoneTypeCode", 5)
                };

                AddrCollector.SQLReturnVoid(FaxParams, "InsertPhone");
            }

        }

    }
}