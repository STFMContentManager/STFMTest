using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STFMAcctNavigate
{
    public class Navigate
    {
        public string ForwardNavString(string src, string loc)
        {

            switch (src)
            {
                case "NewMem":
                    {
                        switch (loc)
                        {
                            case "Step1":
                                {
                                    return "STFMAcct2.aspx?Src=NewMem&Loc=Step2";
                                }
                            case "Step2":
                                {
                                    return "STFMAcct3.aspx?Src=NewMem&Loc=Step3";
                                }
                            case "Step3":
                                {
                                    return "STFMAcct4.aspx?Src=NewMem&Loc=Step4";
                                }
                            case "Step4":
                                {
                                    return "STFMJoin1.aspx?Src=NewMem&Loc=Step5";
                                }
                            case "Step5":
                                {
                                    return "STFMJoin2.aspx?Src=NewMem&Loc=Step6";
                                }
                            case "Step6":
                                {
                                    return "http://www.stfm.org";
                                }
                            default:
                                {
                                    break;
                                }
                        }

                        break;
                    }
                case "Create":
                    {
                        switch (loc)
                        {
                            case "Step1":
                                {
                                    return "STFMAcct2.aspx?Src=Create&Loc=Step2";                                    
                                }
                            case "Step2":
                                {
                                    return "STFMAcct3.aspx?Src=Create&Loc=Step3";
                                }
                            case "Step3":
                                {
                                    return "STFMAcct4.aspx?Src=Create&Loc=Step4";
                                }
                        }
                        break;
                    }
                case "Update":
                    {
                        switch (loc)
                        {
                            case "Step3":
                            {
                                return "http://www.stfm.org";
                            }
                        }
                        return "STFMAcct3.aspx?Src=Create&Loc=Step3";
                    }
                default:
                    {
                        break;
                    }
            }

            return "";

        }
        public string BackNavString(string src, string loc)
        {
            switch (src)
            {
                case "NewMem":
                    {
                        switch (loc)
                        {
                            case "Step1":
                                {
                                    return "http://www.stfm.org";
                                }
                            case "Step2":
                                {
                                    return "STFMAcct1.aspx?Src=NewMem&Loc=Step1";
                                }
                            case "Step3":
                                {
                                    return "STFMAcct2.aspx?Src=NewMem&Loc=Step2";
                                }
                            case "Step4":
                                {
                                    return "STFMAcct3.aspx?Src=NewMem&Loc=Step3";
                                }
                            case "Step5":
                                {
                                    return "STFMAcct4.aspx?Src=NewMem&Loc=Step4";
                                }
                            case "Step6":
                                {
                                    return "STFMJoin1.aspx?Src=NewMem&Loc=Step5";
                                }
                            default:
                                {
                                    break;
                                }
                        }

                        break;
                    }

                case "Create":
                    {
                        switch (loc)
                        {
                            case "Step2":
                                {
                                    return "STFMAcct1.aspx?Src=Create&Loc=Step1";
                                }
                            case "Step3":
                                {
                                    return "STFMAcct2.aspx?Src=Create&Loc=Step2";
                                }
                            case "Step4":
                                {
                                    return "STFMAcct3.aspx?Src=Create&Loc=Step3";
                                }
                        }
                        break;
                    }
                case "Update":
                    {
                        switch (loc)
                        {
                            case "Step3":
                                {
                                    return "http://www.stfm.org";                                   
                                }
                            default:
                                {
                                    return "STFMAcct3.aspx?Src=Create&Loc=Step3";
                                }
                        }                        
                    }
                default:
                    {
                        break;
                    }
            }
            return "";
        }
    }
}