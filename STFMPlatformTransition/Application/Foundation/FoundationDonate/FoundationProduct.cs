using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STFMFoundationDonor
{
    public class Donation
    {
        public int Amount { get; set; }
        public string ProductType { get; set; }
        public string Designate { get; set; }
        public string HonorVal { get; set; }
        public string HonorFname { get; set; }
        public string HonorLname { get; set; }
        public string CCType { get; set; }
        public string CCNumber { get; set; }
        public string CCName { get; set; }
        public int CCExpMonth { get; set; }
        public int CCExpYear { get; set; }
        public bool PayNow { get; set; }
        public int ExtendedAmt { get; set; }
        public int ExtendedLength { get; set; }
    }
}