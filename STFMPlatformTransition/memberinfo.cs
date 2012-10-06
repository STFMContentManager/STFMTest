using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcctSys
{
    public class MemberInfo
    {
        string NTitle = "";
        string NSuffix = "";
        string CellNumber = "";
        string FName = "";
        string MName = "";
        string LName = "";
        string TelNumber = "";
        string Email = "";
        string Bdate = "";
        string NDegree = "";

        int Addr1Company = 0;
        string Addr1L1 = "";
        string Addr1L2 = "";
        string Addr1City = "";
        int Addr1State = 0;
        string Addr1zip = "";
        int Addr1Country = 0;
        string Addr1Tel = "";
        string Addr1fax = "";
        int Addr1type = 0;

        string Addr2L1 = "";
        string Addr2L2 = "";
        string Addr2City = "";
        int Addr2State = 0;
        string Addr2zip = "";
        int Addr2Country = 0;
        string Addr2Tel = "";
        string Addr2fax = "";
        int Addr2type = 0;
        int Addr2Company = 0;

        public int Address2Company
        {
            get { return Addr2Company; }
            set { Addr2Company = value; }
        }

        public int Address2Type
        {
            get { return Addr2type; }
            set { Addr2type = value; }
        }

        public string Address2Fax
        {
            get { return Addr2fax; }
            set { Addr2fax = value; }
        }

        public string Address2Phone
        {
            get { return Addr2Tel; }
            set { Addr2Tel = value; }
        }

        public int Address2Country
        {
            get { return Addr2Country; }
            set { Addr2Country = value; }
        }

        public string Address2Zip
        {
            get { return Addr2zip; }
            set { Addr2zip = value; }
        }

        public int Address2State
        {
            get { return Addr2State; }
            set { Addr2State = value; }
        }

        public string Address2City
        {
            get { return Addr2City; }
            set { Addr2City = value; }
        }

        public string Address2Line2
        {
            get { return Addr2L2; }
            set { Addr2L2 = value; }
        }

        public string Address2Line1
        {
            get { return Addr2L1; }
            set { Addr2L1 = value; }
        }

        public int Address1Type
        {
            get { return Addr1type; }
            set { Addr1type = value; }
        }

        public int Address1Company
        {
            get { return Addr1Company; }
            set { Addr1Company = value; }
        }

        public string Address1Zip
        {
            get { return Addr1zip; }
            set { Addr1zip = value; }
        }

        public int Address1Country
        {
            get { return Addr1Country; }
            set { Addr1Country = value; }
        }

        public string Address1Fax
        {
            get { return Addr1fax; }
            set { Addr1fax = value; }
        }

        public string Address1Tel
        {
            get { return Addr1Tel; }
            set { Addr1Tel = value; }
        }

        public int Address1State
        {
            get { return Addr1State; }
            set { Addr1State = value; }
        }

        public string Address1City
        {
            get { return Addr1City; }
            set { Addr1City = value; }
        }

        public string Address1Line2
        {
            get { return Addr1L2; }
            set { Addr1L2 = value; }
        }

        public string Address1Line1
        {
            get { return Addr1L1; }
            set { Addr1L1 = value; }
        }

        public string Degree
        {
            get { return NDegree; }
            set { NDegree = value; }
        }

        public string FirstName
        {
            get { return FName; }
            set { FName = value; }
        }

        public string Cellphone
        {
            get { return CellNumber; }
            set { CellNumber = value; }
        }

        public string NameSuffix
        {
            get { return NSuffix; }
            set { NSuffix = value; }
        }

        public string NameTitle
        {
            get { return NTitle; }
            set { NTitle = value; }
        }

        public string Emailaddress
        {
            get { return Email; }
            set { Email = value; }
        }

        public string Birthdate
        {
            get { return Bdate; }
            set { Bdate = value; }
        }

        public string MiddleName
        {
            get { return MName; }
            set { MName = value; }
        }

        public string LastName
        {
            get { return LName; }
            set { LName = value; }
        }

        public string PhoneNumber
        {
            get { return TelNumber; }
            set { TelNumber = value; }
        }


    }
}