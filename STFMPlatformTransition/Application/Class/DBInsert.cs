using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STFMDBAccess
{

    public class PassDB
    {

        SqlConnection JoinData = new SqlConnection(ConfigurationManager.AppSettings["ISISConnection"].ToString());

        public int SQLReturnData(SqlParameter[] Params, string qstring)
        {
            JoinData.Open();
            int IDforInsert;

            try
            {

                SqlCommand AcctNameData = new SqlCommand(qstring, JoinData);

                AcctNameData.CommandType = System.Data.CommandType.StoredProcedure;

                AcctNameData.Parameters.AddRange(Params);

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

        public int SQLReturnData(string qstring)
        {
            JoinData.Open();
            int IDforInsert;

            try
            {

                SqlCommand AcctNameData = new SqlCommand(qstring, JoinData);

                AcctNameData.CommandType = System.Data.CommandType.Text;              

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

    }

}