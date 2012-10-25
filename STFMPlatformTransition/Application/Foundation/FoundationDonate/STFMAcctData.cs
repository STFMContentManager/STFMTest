using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STFMFoundationDonor
{
    public class STFMAcctData
    {
       
        public DropDownList BindMType(DropDownList x)
        {
            STFMAcctData MTypeData = new STFMAcctData();

            x.DataSource = MTypeData.MailTypeDropDown();
            x.DataTextField = "AddressType";
            x.DataValueField = "ID";
            x.DataBind();

            x.Items.Insert(0, "Select One");

            return x;
        }

        public DropDownList BindState(DropDownList x)
        {
            STFMAcctData StatesData = new STFMAcctData();

            x.DataSource = StatesData.StateDropDown();
            x.DataTextField = "nametext";
            x.DataValueField = "ID";
            x.DataBind();

            x.Items.Insert(0, "Select One");
            x.Items.Insert(66, "Non-US");

            return x;
        }

        public DropDownList BindCompany(DropDownList x, string y)
        {
            STFMAcctData CompanyData = new STFMAcctData();

            x.DataSource = CompanyData.CompanyDropDown(y);
            x.DataTextField = "AddressLine1";
            x.DataValueField = "ID";
            x.DataBind();

            x.Items.Insert(0, "Select One");
            x.Items.Insert(1, "Other");

            return x;
        }

        public DropDownList BindCountry(DropDownList x)
        {
            STFMAcctData CountryData = new STFMAcctData();

            x.DataSource = CountryData.CountryDropDown();
            x.DataTextField = "CountryName";
            x.DataValueField = "ID";
            x.DataBind();

            x.Items.Insert(0, "Select One");

            return x;
        }

        public DataTable StateDropDown()
        {

            DataTable StatesList = new DataTable();
            SqlConnection StateCon = new SqlConnection(ConfigurationManager.AppSettings["ISISConnection"].ToString());

            try
            {
                StateCon.Open();
                SqlDataAdapter StateAdapt = new SqlDataAdapter("SELECT (abbrev + ' - ' + name) as nametext, ID FROM StatesList", StateCon);
                StateAdapt.Fill(StatesList);
            }
            catch
            {
            }

            StateCon.Close(); 
            return StatesList;
        }

        public DataTable CountryDropDown()
        {

            DataTable CountryList = new DataTable();
            SqlConnection CountryCon = new SqlConnection(ConfigurationManager.AppSettings["ISISConnection"].ToString());

            try
            {
                CountryCon.Open();
                SqlDataAdapter CountryAdapt = new SqlDataAdapter("SELECT ID, CountryName FROM Countries Order BY CountryName", CountryCon);
                CountryAdapt.Fill(CountryList);
            }
            catch
            {
            }

            CountryCon.Close();
            return CountryList;
        }

        public DataTable CompanyDropDown(string stateval)
        {

            string qstring = "SELECT ID, AddressLine1 FROM CompanyAddresses WHERE State = ";
            qstring += stateval;
            qstring += " Order BY AddressLine1;";

            DataTable CompanyList = new DataTable();
            SqlConnection CompanyCon = new SqlConnection(ConfigurationManager.AppSettings["ISISConnection"].ToString());

            try
            {
                CompanyCon.Open();
                SqlDataAdapter CompanyAdapt = new SqlDataAdapter(qstring, CompanyCon);
                CompanyAdapt.Fill(CompanyList);
            }
            catch
            {
            }

            CompanyCon.Close();
            return CompanyList;
        }

        public DataTable MailTypeDropDown()
        {

            string qstring = "SELECT ID, AddressType FROM AddressMailingType";

            DataTable MTypeList = new DataTable();
            SqlConnection MTypeCon = new SqlConnection(ConfigurationManager.AppSettings["ISISConnection"].ToString());

            try
            {
                MTypeCon.Open();
                SqlDataAdapter MTypeAdapt = new SqlDataAdapter(qstring, MTypeCon);
                MTypeAdapt.Fill(MTypeList);
            }
            catch
            {
            }

            MTypeCon.Close();
            return MTypeList;
        }

        public string GetCompanyText(string CompVal)
        {
            string ReturnVal;
            string qstring = "Select CompanyName FROM Companies WHERE CompanyAddressID = ";
            qstring += CompVal;

            SqlConnection CompanyTxtCon = new SqlConnection(ConfigurationManager.AppSettings["ISISConnection"].ToString());

            try
            {
                CompanyTxtCon.Open();
                SqlCommand CompanyTxt = new SqlCommand(qstring, CompanyTxtCon);
                CompanyTxt.CommandType = System.Data.CommandType.Text;
                ReturnVal = Convert.ToString(CompanyTxt.ExecuteScalar());
            }
            catch
            {
                return "";
            }

            return ReturnVal;
            
        }

        public string GetStateText(string StateVal)
        {
            string ReturnVal;
            string qstring = "Select abbrev from StatesList Where ID = ";
            qstring += StateVal;

            SqlConnection CompanyTxtCon = new SqlConnection(ConfigurationManager.AppSettings["ISISConnection"].ToString());

            try
            {
                CompanyTxtCon.Open();
                SqlCommand CompanyTxt = new SqlCommand(qstring, CompanyTxtCon);
                CompanyTxt.CommandType = System.Data.CommandType.Text;
                ReturnVal = Convert.ToString(CompanyTxt.ExecuteScalar());
            }
            catch
            {
                return "";
            }

            return ReturnVal;

        }

        public string GetCountryText(string CountryVal)
        {
            string ReturnVal;
            string qstring = "Select CountryName from Countries Where ID = ";
            qstring += CountryVal;

            SqlConnection CompanyTxtCon = new SqlConnection(ConfigurationManager.AppSettings["ISISConnection"].ToString());

            try
            {
                CompanyTxtCon.Open();
                SqlCommand CompanyTxt = new SqlCommand(qstring, CompanyTxtCon);
                CompanyTxt.CommandType = System.Data.CommandType.Text;
                ReturnVal = Convert.ToString(CompanyTxt.ExecuteScalar());
            }
            catch
            {
                return "";
            }

            return ReturnVal;

        }

    }

    public class PassDB
    {

        SqlConnection JoinData = new SqlConnection(ConfigurationManager.AppSettings["ISISConnection"].ToString());

        public int SQLReturnData(SqlParameter[] mem, string qstring)
        {
            JoinData.Open();
            int IDforInsert;

            try
            {

                SqlCommand AcctNameData = new SqlCommand(qstring, JoinData);

                AcctNameData.CommandType = System.Data.CommandType.StoredProcedure;

                AcctNameData.Parameters.AddRange(mem);

                IDforInsert = Convert.ToInt32(AcctNameData.ExecuteScalar());
                JoinData.Close();
                return IDforInsert;

            }
            catch
            {
                JoinData.Close();
                return 0;
            }

        }

        public void SQLReturnVoid(SqlParameter[] ReturnVoidData, string qstring)
        {
            JoinData.Open();

            try
            {

                SqlCommand SqlData = new SqlCommand(qstring, JoinData);
                SqlData.CommandType = System.Data.CommandType.StoredProcedure;
                SqlData.Parameters.AddRange(ReturnVoidData);
                SqlData.ExecuteNonQuery();

                JoinData.Close();

            }
            catch
            {
                JoinData.Close();
            }
        }

        public MemberInfo RetrieveMemInfo(string PersonID)
        {
            JoinData.Open();

            string qstring = "Select TOP 1 Prefix, FirstName, LastName, MiddleName, LastName, Suffix, EmailAddress, Addresses.CountryID, States,PhoneNumber,PhoneTypeCode "; 
            qstring += "FROM Persons INNER JOIN Email ON Persons.PersonID = Email.PersonID ";
            qstring += "INNER JOIN Addresses ON Addresses.PersonID = Persons.PersonID ";
            qstring += "INNER JOIN Phone ON Phone.PersonID = Persons.PersonID ";
            qstring += "WHERE PhoneTypeCode IN (1,2) AND Persons.PersonID =" + PersonID;

            SqlDataAdapter RetrieveMem = new SqlDataAdapter(qstring, JoinData);

            DataSet MemInfo = new DataSet("Person");

            RetrieveMem.Fill(MemInfo, "Person");

            MemberInfo RetrievedPerson = new MemberInfo();

            RetrievedPerson.NameTitle = MemInfo.Tables[0].Rows[0].Field<string>("Prefix");
            RetrievedPerson.FirstName = MemInfo.Tables[0].Rows[0].Field<string>("FirstName");
            RetrievedPerson.MiddleName = MemInfo.Tables[0].Rows[0].Field<string>("MiddleName");
            RetrievedPerson.LastName = MemInfo.Tables[0].Rows[0].Field<string>("LastName");
            RetrievedPerson.NameSuffix = MemInfo.Tables[0].Rows[0].Field<string>("Suffix");
            RetrievedPerson.EmailAddress = MemInfo.Tables[0].Rows[0].Field<string>("EmailAddress");
            RetrievedPerson.Cellphone = MemInfo.Tables[0].Rows[0].Field<string>("PhoneNumber");
            RetrievedPerson.CellType = MemInfo.Tables[0].Rows[0].Field<int>("PhoneTypeCode");

            JoinData.Close();

            return RetrievedPerson;
        }

        public MemAddressInfo RetrieveMemAddr(string PersonID, int AddressType)
        {
            JoinData.Open();

            string qstring = "SELECT AddressLine1, AddressLine2, AddressLine3, City,States, Zip, CountryID, MailingTypeCode, LocationTypeCode ";
            qstring += "FROM Persons INNER JOIN Addresses on Persons.PersonID = Addresses.PersonID ";
            qstring += "WHERE Persons.PersonID = " + PersonID + "AND LocationTypeCode = " + AddressType;

            SqlDataAdapter GetAddr = new SqlDataAdapter(qstring, JoinData);

            DataSet AddrInfo = new DataSet("Address");

            GetAddr.Fill(AddrInfo, "Address");

            MemAddressInfo RetrievedAddr = new MemAddressInfo();

            RetrievedAddr.AddressLine1 = NullColumn(AddrInfo, "AddressLine1");
            RetrievedAddr.AddressLine2 = NullColumn(AddrInfo, "AddressLine2");
            RetrievedAddr.AddressLine3 = NullColumn(AddrInfo, "AddressLine3");
            RetrievedAddr.AddressCity = AddrInfo.Tables[0].Rows[0].Field<string>("City");
            
            foreach (DataRow row in AddrInfo.Tables[0].Rows)
            {
                object value = row["States"];
                if (value == DBNull.Value)
                {
                    RetrievedAddr.AddressState = null;
                }
                else
                {
                    RetrievedAddr.AddressState = AddrInfo.Tables[0].Rows[0].Field<byte>("States").ToString();
                }
            }

            //RetrievedAddr.AddressState = AddrInfo.Tables[0].Rows[0].Field<byte>("States").ToString();
            RetrievedAddr.AddressZip = AddrInfo.Tables[0].Rows[0].Field<string>("Zip");
            RetrievedAddr.AddressCountry = AddrInfo.Tables[0].Rows[0].Field<int>("CountryID").ToString();
            RetrievedAddr.AddressLoc = AddrInfo.Tables[0].Rows[0].Field<byte>("LocationTypeCode");
            RetrievedAddr.AddressType = AddrInfo.Tables[0].Rows[0].Field<byte>("MailingTypeCode");

            JoinData.Close();

            return RetrievedAddr;
        }

        public string NullColumn(DataSet e, string column)
        {  
                foreach (DataRow row in e.Tables[0].Rows)
                {
                    object value = row[column];
                    if (value == DBNull.Value)
                    {
                        return null;
                    }
                    else
                    {
                        return e.Tables[0].Rows[0].Field<string>(column);
                    }
                }

                return "";
         }

        

    }

}