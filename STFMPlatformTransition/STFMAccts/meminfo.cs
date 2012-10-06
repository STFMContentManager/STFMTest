using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STFM_Account_Manager_3
{
    public class MemberInfo
    {
        //This class stores the biographical member information.  Name, title, degree, and so on.
        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Degree { get; set; }
        public string NameSuffix { get; set; }
        public string NameTitle { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Birthdate { get; set; }
        public string Cellphone { get; set; }
        public int CellType { get; set; }
        public string PrimaryState { get; set; }
        public string PrimaryCountry { get; set; }

    }

    public class MemAddressInfo
    {
        //Here be address info!

        public string AddressCompany { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
        public string AddressCountry { get; set; }
        public string AddressPhone { get; set; }
        public string AddressFax { get; set; }
        public int AddressType { get; set; }
        public int AddressLoc { get; set; }
        
    }
}