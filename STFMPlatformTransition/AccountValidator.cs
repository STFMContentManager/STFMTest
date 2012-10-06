using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace AcctSys
{
    public class InfoVal
    {
        //public string Validate(MemberInfo mi, int Page)
        //{
        //    switch (Page)
        //    {
        //        case 1:
        //            {
        //                if (ValidateString(mi.FirstName) == 0)
        //                {
        //                    return "";
        //                }
        //                if (ValidateString(mi.MiddleName) == 0)
        //                {
        //                    return "";
        //                }
        //                if (ValidateString(mi.LastName) == 0)
        //                {
        //                    return "";
        //                }

        //                break;
        //            }
        //        default:
        //                {
        //                    return "";
        //                    break;
        //                }
        //    }
        //}

        public string Validate(MemberInfo mi, int page)
        {
            switch (page)
            {
                case 1:
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

                        if (ValidateString(mi.Birthdate) == 1)
                        {
                            return "";
                        }

                        if (ValidateEmail(mi.Emailaddress) == 1)
                        {
                            return "emailerror";
                        }

                        return "ok";

                    }
                case 2:
                    {
                        if (mi.Address1Type == 1 && mi.Address1Company == 0)
                        {
                            return "";
                        }
                        if (ValidateString(mi.Address1Line1) == 1)
                        {
                            return "";
                        }
                        if (ValidateString(mi.Address1City) == 1)
                        {
                            return "";
                        }

                        if (mi.Address1Country == 190 && (ValidateString(mi.Address1Zip) == 1 || mi.Address1State < 1 || ValidatePhone(mi.Address1Tel) == ""))
                        {
                            return "";
                        }
                        if (mi.Address1Country == 0)
                        {
                            return "";
                        }
                        //if (mi.Address1Country == 190 && ValidatePhone(mi.Address1Tel) == "")
                        //{
                        //    return "";
                        //}
                        //if(ValidatePhone(mi.Address1Tel) == "" &&  mi.Address1Country ==190)
                        //{
                        //    return "";
                        //}

                        return "ok";
                    }
                case 3:
                    {

                        if (mi.Address2Type == 1 && mi.Address2Company == 0)
                        {
                            return "";
                        }
                        if (ValidateString(mi.Address2Line1) == 1)
                        {
                            return "";
                        }
                        if (ValidateString(mi.Address2City) == 1)
                        {
                            return "";
                        }

                        if (mi.Address2Country == 190 && (ValidateString(mi.Address2Zip) == 1 || mi.Address2State < 1 || ValidatePhone(mi.Address2Phone) == ""))
                        {
                            return "";
                        }
                        if (mi.Address2Country == 0)
                        {
                            return "";
                        }

                        return "ok";

                    }
                default:
                    {
                        break;
                    }
            }
            return "";

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
            catch (Exception ex)
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

    }
}