using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STFM_Account_Manager_3
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void FMHub(object sender, EventArgs e)
        {
            Response.Redirect("/Application/FMHub/FMHubAdmin.aspx");
        }

        public void CreateAcct(object sender, EventArgs e)
        {
            Response.Redirect("STFMAcct1.aspx?" + "Src=" + Server.UrlEncode("Create") +"&"+ "Loc=" + Server.UrlEncode("Step1"));
        }

        public void PasswordRecover(object sender, EventArgs e)
        {
            Response.Redirect("/Application/UserAccount/PasswordFind/PasswordRecover.aspx");
        }

        public void PasswordChange(object sender, EventArgs e)
        {
            Response.Redirect("/Application/UserAccount/PasswordChange/PasswordChange.aspx");
        }

        public void MembershipDirectory(object sender, EventArgs e)
        {
            Response.Redirect("../MemberDirectorySearch.aspx");
        }

        public void addr(object sender, EventArgs e)
        {
            MemAddressInfo test = new MemAddressInfo();
            test.AddressCountry = "236";
            test.AddressState = "15";
            Session["AddressInfo"] = test;
            Response.Redirect("STFMAcct2.aspx?" + "Src=" + Server.UrlEncode("Create") + "&" + "Loc=" + Server.UrlEncode("Step2"));
        }

        //public void AcctUpdateTest(object sender, EventArgs e)
        //{
        //    Response.Redirect("STFMAcct3.aspx?" + "Src=" + Server.UrlEncode("Update") + "&" + "Loc=" + Server.UrlEncode("Step1") + "&" + "Person=" + Server.UrlEncode("100064"));
        //}

        public void AcctUpdateTest(object sender, EventArgs e)
        {
            string x = "100064";

            PassDB GetMember = new PassDB();
            Session["PersonInfo"] = GetMember.RetrieveMemInfo(x);
            Session["Address1"] = GetMember.RetrieveMemAddr(x, 2);
            Session["Address2"] = GetMember.RetrieveMemAddr(x, 1);

            MemberInfo mem = new MemberInfo();
            MemAddressInfo addr = new MemAddressInfo();

            mem = (MemberInfo)Session["PersonInfo"];
            addr = (MemAddressInfo)Session["Address1"];

            mem.PrimaryState = addr.AddressState;
            mem.PrimaryCountry = addr.AddressCountry;

            Session["PersonInfo"] = mem;
            mem = null;
            addr = null;

            Response.Redirect("STFMAcct1.aspx?" + "Src=" + Server.UrlEncode("Create") + "&" + "Loc=" + Server.UrlEncode("Step1"));
        }

        public void testdb(object sender, EventArgs e)
        {
            MemberInfo TestMem = new MemberInfo();
            MemAddressInfo TestAddr1 = new MemAddressInfo();
            MemAddressInfo TestAddr2 = new MemAddressInfo();

            TestMem.FirstName = "Oliver";
            TestMem.MiddleName = "Wendell";
            TestMem.LastName = "Holmes";
            TestMem.NameTitle = "Dr.";
            TestMem.NameSuffix = "Jr.";
            TestMem.EmailAddress = "owholmes@supremecourt.gov";
            TestMem.CellType = 1;
            TestMem.Cellphone = "816-509-3597";
            DateTime bday = new DateTime(2012, 5, 23);
            TestMem.Birthdate = bday;

            TestAddr1.AddressCompany = "1576";
            TestAddr1.AddressLine1 = "Federal Office Building";
            TestAddr1.AddressLine2 = "555 K Street";
            TestAddr1.AddressLine3 = "Suite 5B";
            TestAddr1.AddressCity = "Washington";
            TestAddr1.AddressState = "66";
            TestAddr1.AddressCountry = "250";
            TestAddr1.AddressZip = "000001";
            TestAddr1.AddressLoc = 2;
            TestAddr1.AddressType = 4;
            TestAddr1.AddressFax = "913-906-6000";
            TestAddr1.AddressPhone = "913-906-6556";

            TestAddr2.AddressLine1 = "55 Biloxi Street";
            TestAddr2.AddressCity = "Washington";
            TestAddr2.AddressState = "10";
            TestAddr2.AddressCountry = "236";
            TestAddr2.AddressZip = "000001";
            TestAddr2.AddressLoc = 1;
            TestAddr2.AddressType = 4;
            TestAddr1.AddressFax = "816-906-6000";
            TestAddr1.AddressPhone = "816-906-6556";

            Session["Address1"] = TestAddr1;
            Session["Address2"] = TestAddr2;
            Session["PersonInfo"] = TestMem;

            TestMem = null;
            TestAddr1 = null;
            TestAddr2 = null;

            Response.Redirect("STFMAcct4.aspx?Src=Create&Loc=Step4");

        }

        public void NoAcctSTFMJoin(object sender, EventArgs e)
        {
            Response.Redirect("STFMAcct1.aspx?" + "Src=" + Server.UrlEncode("NewMem") + "&" + "Loc=" + Server.UrlEncode("Step1"));
        }

        public void JoinPage(object sender, EventArgs e)
        {
            Response.Redirect("STFMJoin1.aspx?" + "Src=" + "NewMem" + "&" + "Loc=" + "Step5");
        }
        public void Foundation(object sender, EventArgs e)
        {
            Response.Redirect("/Application/Foundation/FoundationDonate/FoundationDonate1.aspx");
        }
        public void Advocacy(object sender, EventArgs e)
        {
            Response.Redirect("/Application/Advocacy/AdvocacyContact/Default.aspx");
        }
    }
}