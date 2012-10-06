using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace STFMFoundationDonor
{
    public class InfoVal
    {
        
        public string AddressValidate(MemAddressInfo addr)
        {
            //this checks to see if the whole thing is null. This comes after validation on the codebehind to make sure at least one of
            //the address fields is filled.  
            if (addr.AddressLoc == 0)
            {
                return "ok";
            }
            //Checks to make sure the required address fields have values in them
            if (ValidateString(addr.AddressLine1) == 1 || ValidateString(addr.AddressCity) == 1 || ValidateString(addr.AddressZip) == 1)
            {
                return "";
            }

            //Checks the address field to make sure it is used if the address is a business address
            if (addr.AddressLoc == 2 && addr.AddressCompany == "236")
            {
                try
                {
                    Convert.ToInt16(addr.AddressCompany);
                }
                catch
                {
                    return "";
                }
            }

            //Tests to make sure the country isn't set to 0, "Select One"
            //If the country is the United States, they must have a state selected (66 & 0 are non-state entries in the DDL)
            //Since we're already looking after USA stuff, the telephone validation is placed in here as well.

            try
            {
                Convert.ToInt16(addr.AddressCountry);
                if (addr.AddressCountry == "236")
                {
                    try
                    {
                        Convert.ToInt16(addr.AddressState);
                    }
                    catch
                    {
                        return "";
                    }
                }
            }
            catch
            {
                return "";
            }

            return "ok";                                                                                          
            
        }
        public string PersonValidate(MemberInfo mi)
        {

            if (mi.NameTitle == "0")
            {
                return "";
            }
            if (ValidateString(mi.FirstName) == 1)
            {
                return "";
            }

            if (ValidateString(mi.LastName) == 1)
            {
                return "";
            }

            if (ValidateDate(mi.Birthdate) == 1)
            {
                return "";
            }

            if (ValidateEmail(mi.EmailAddress) == 1)
            {
                return "emailerror";
            }

            return "ok";
        }

        public int ValidateDate(DateTime date)
        {
            if ((date.Month == 4 || date.Month == 6 || date.Month == 9 || date.Month == 11))
            {
                if(date.Day > 30)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            if (date.Month == 2)
            {
                if (DateTime.IsLeapYear(date.Year) == true)
                {
                    if (date.Day > 29)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    if (date.Day > 28)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }

                
            }

            return 0;

        }

        public int ValidateString(string val)
        {
            //try
            //{
            //    String.IsNullOrEmpty(val);

            //    return 1;
            //}
            //catch (Exception ex)
            //{
            //    return 0;
            //}
            if (String.IsNullOrEmpty(val) == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int ValidateNumber(string val)
        {
            try
            {
                Double.Parse(val);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int ValidateEmail(string val)
        {
            if (Regex.IsMatch(val, "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$") == false)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public string ValidatePhone(string x)
        {
            {

                if (string.IsNullOrEmpty(x) == true)
                {
                    return "";
                }

                string phonealter;
                int xpos;
                string phonenum;
                phonealter = Regex.Replace(x, "[^0-9x]", "");
                xpos = phonealter.LastIndexOf("x");


                if ((xpos != 10 && xpos >= 0) || (xpos < 0 && phonealter.Length != 10))
                {
                    return "";
                }

                if (xpos < 0)
                {
                    phonenum = phonealter;
                    return "(" + phonenum.Substring(0, 3) + ")" + phonenum.Substring(3, 3) + "-" + phonenum.Substring(6, 4);
                }


                if (xpos >= 0)
                {
                    phonenum = phonealter.Substring(0, xpos);
                    return "(" + phonenum.Substring(0, 3) + ")" + phonenum.Substring(3, 3) + "-" + phonenum.Substring(6, 4) + " ext." + phonealter.Substring((xpos + 1), (phonealter.Length - (xpos + 1)));
                }


                return "";
            }
        }

        public string ValidateCountryPage1(MemAddressInfo addr)
        {
            if (addr.AddressCountry != "0")
            {

                if (addr.AddressCountry == "236")
                {
                    if (addr.AddressState == "0" || addr.AddressState == "66")
                    {
                        return "";
                    }
                }
            }
            else
            {
                return "";
            }

            return "ok"; 
        }
    }
}

