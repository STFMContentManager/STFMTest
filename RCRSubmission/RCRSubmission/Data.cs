using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using RCRLogicNS;
using RCRWrappers;

namespace RCRDataNS
{
    public class RCRData
    {
        protected List<DropDownValue> GetDropDownValuesFromDB(string sTableVal, int iCoreTopicID = 0)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["RCRConnection"].ToString();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetDropDownValues";

            SqlParameter parm = new SqlParameter();
            parm.ParameterName = "@Table";
            parm.SqlDbType = SqlDbType.Char;
            parm.Size = 1;
            parm.Value = sTableVal;

            cmd.Parameters.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@CoreTopicID";
            parm.SqlDbType = SqlDbType.Int;
            parm.Size = 4;
            parm.Value = iCoreTopicID;

            cmd.Parameters.Add(parm);

            parm = null;

            cmd.Connection = conn;

            List<DropDownValue> lDropDownValues = new List<DropDownValue>();

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                DropDownValue objDropDownValues = new DropDownValue();

                objDropDownValues.Id = Convert.ToInt32(rdr[0].ToString());
                objDropDownValues.Name = rdr[1].ToString();

                lDropDownValues.Add(objDropDownValues);
            }

            conn.Close();

            conn.Dispose();
            cmd.Dispose();
            rdr.Dispose();

            conn = null;
            cmd = null;
            rdr = null;

            return lDropDownValues;
        }

        public void SubmitSubmission(RCRSubmissionObject objSubmission)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["RCRConnection"].ToString();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spInsertSubmission";

            cmd.Parameters.Add(new SqlParameter("@FName", objSubmission.FName));
            cmd.Parameters.Add(new SqlParameter("@MName", objSubmission.MName));
            cmd.Parameters.Add(new SqlParameter("@LName", objSubmission.LName));
            cmd.Parameters.Add(new SqlParameter("@Title", objSubmission.Title));
            cmd.Parameters.Add(new SqlParameter("@DegreeId", objSubmission.DegreeId));
            cmd.Parameters.Add(new SqlParameter("@Membership", objSubmission.Membership));
            cmd.Parameters.Add(new SqlParameter("@AffiliationId", objSubmission.AffiliationId));
            cmd.Parameters.Add(new SqlParameter("@Address1", objSubmission.Address1));
            cmd.Parameters.Add(new SqlParameter("@Address2", objSubmission.Address2));
            cmd.Parameters.Add(new SqlParameter("@Address3", objSubmission.Address3));
            cmd.Parameters.Add(new SqlParameter("@City", objSubmission.City));
            cmd.Parameters.Add(new SqlParameter("@State", objSubmission.State));
            cmd.Parameters.Add(new SqlParameter("@Zip", objSubmission.Zip));
            cmd.Parameters.Add(new SqlParameter("@Email", objSubmission.Email));
            cmd.Parameters.Add(new SqlParameter("@Phone", objSubmission.Phone));
            cmd.Parameters.Add(new SqlParameter("@CA1FName", objSubmission.CA1FName));
            cmd.Parameters.Add(new SqlParameter("@CA1MName", objSubmission.CA1MName));
            cmd.Parameters.Add(new SqlParameter("@CA1LName", objSubmission.CA1LName));
            cmd.Parameters.Add(new SqlParameter("@CA1DegreeId", objSubmission.CA1DegreeId));
            cmd.Parameters.Add(new SqlParameter("@CA1AffiliationId", objSubmission.CA1AffiliationId));
            cmd.Parameters.Add(new SqlParameter("@CA2FName", objSubmission.CA2FName));
            cmd.Parameters.Add(new SqlParameter("@CA2MName", objSubmission.CA2MName));
            cmd.Parameters.Add(new SqlParameter("@CA2LName", objSubmission.CA2LName));
            cmd.Parameters.Add(new SqlParameter("@CA2DegreeId", objSubmission.CA2DegreeId));
            cmd.Parameters.Add(new SqlParameter("@CA2AffiliationId", objSubmission.CA2AffiliationId));
            cmd.Parameters.Add(new SqlParameter("@AuthorsInterest", objSubmission.AuthorsInterest));
            cmd.Parameters.Add(new SqlParameter("@TopicId", objSubmission.TopicId));
            cmd.Parameters.Add(new SqlParameter("@Biosketch", objSubmission.Biosketch));
            cmd.Parameters.Add(new SqlParameter("@LearningObjectives", objSubmission.LearningObjectives));
            cmd.Parameters.Add(new SqlParameter("@CurrDesc", objSubmission.CurrDesc));
            cmd.Parameters.Add(new SqlParameter("@SessionTypeId", objSubmission.SessionTypeId));
            cmd.Parameters.Add(new SqlParameter("@SessionTypeOther", objSubmission.SessionTypeOther));
            cmd.Parameters.Add(new SqlParameter("@CurrFormat", objSubmission.CurrFormat));
            cmd.Parameters.Add(new SqlParameter("@TeachingTools", objSubmission.TeachingTools));
            cmd.Parameters.Add(new SqlParameter("@TopicAssigned", objSubmission.TopicAssigned));
            cmd.Parameters.Add(new SqlParameter("@UnderstandAttestation1", objSubmission.UnderstandAttestation1));
            cmd.Parameters.Add(new SqlParameter("@UnderstandAttestation2", objSubmission.UnderstandAttestation2));
            cmd.Parameters.Add(new SqlParameter("@UnderstandAttestation3", objSubmission.UnderstandAttestation3));
            cmd.Parameters.Add(new SqlParameter("@DateCreated", objSubmission.DateCreated));

            cmd.Connection = conn;

            cmd.ExecuteNonQuery();

            conn.Close();
            cmd = null;
            conn = null;
        }
    }
}