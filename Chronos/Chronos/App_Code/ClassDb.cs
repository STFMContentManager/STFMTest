//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\ClassDb.cs $
//	$Revision: 1.1 $
//	---------------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Text;

class ClassDb
{
	#region Declarations
	private Boolean bShowSql = false;
	string ConnStr = "";
	System.Data.SqlClient.SqlConnection oDbConn;
	#endregion

	internal ClassDb(string ConnectionString)
	{
		try
		{
			//	Instantiator.

			ConnStr = ConnectionString;
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}
	}

	internal ClassDb(string ConnectionString, Boolean ShowSqlCommands)
	{
		try
		{
			//	Instantiator.

			bShowSql = ShowSqlCommands;
			ConnStr = ConnectionString;
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}
	}

	internal Boolean ShowSql
	{
		get
		{
			return bShowSql;
		}
		set
		{
			bShowSql = value;
		}
	}

	private void CloseDb()
	{
		try
		{
			//	Close database.

			oDbConn.Close();
			oDbConn = null;
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}
	}

	private System.Data.SqlClient.SqlConnection OpenDb()
	{
		try
		{
			//	Open database.

			if (oDbConn == null)
			{
				oDbConn = new System.Data.SqlClient.SqlConnection(ConnStr);
			}

			if (oDbConn.State == System.Data.ConnectionState.Closed)
			{
				oDbConn.ConnectionString = ConnStr;
				oDbConn.Open();
			}
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDbConn;
	}

	internal string Quoted(String SrcStr)
	{
		string DstStr = "";
		int DstLen;

		try
		{
			DstStr = SrcStr.Trim();

			if ((DstStr.StartsWith("\"")) && (DstStr.EndsWith("\"")))
			{
				//	Source string is bound with double-quotes. Remove.

				DstLen = DstStr.Length;
				DstStr = DstStr.Substring(1, DstLen - 2);
			}
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return "'" + DstStr.Replace("'", "''") + "'";
	}

	internal int SqlAction(string SqlStr)
	{
		int nRetVal = 0;
		SqlCommand oCmd;

		try
		{
			if (this.bShowSql == true)
				Log.LogMsg(SqlStr, false);

			oCmd = new SqlCommand();
			OpenDb();
			oCmd.Connection = oDbConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = SqlStr;

			try
			{
				nRetVal = (int)Convert.ToInt32(oCmd.ExecuteScalar().ToString());
			}

			catch (Exception)
			{
				//	Catches the exception where the supplied SQL does not return a value.
				//	We don't need to report this.
			}

			CloseDb();
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
			Log.LogMsg(SqlStr);
		}

		return nRetVal;
	}

	internal DataSet SqlQuery(string SqlStr)
	{
		DataSet oDs = null;
		SqlCommand oCmd;
		SqlDataAdapter oDa;

		try
		{
			if (this.bShowSql == true)
				Log.LogMsg(SqlStr, false);

			OpenDb();
			oCmd = new SqlCommand();
			oCmd.Connection = oDbConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = SqlStr;

			oDa = new SqlDataAdapter(oCmd);
			oDs = new DataSet();
			oDa.Fill(oDs);

			CloseDb();
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
			Log.LogMsg(SqlStr);
		}

		return oDs;
	}

	internal System.Data.DataSet GetTimeSheet(Int32 TeamId, DateTime StartDate, DateTime EndDate)
	{
		DataSet oDs = null;

		try
		{
			System.Data.SqlClient.SqlCommand oCmd = new SqlCommand();
			System.Data.SqlClient.SqlDataAdapter oDa = new SqlDataAdapter(oCmd);
			OpenDb();
			oCmd.Connection = oDbConn;

			oCmd.Connection = oDbConn;
			oCmd.CommandType = System.Data.CommandType.StoredProcedure;
			oCmd.CommandText = "GetTimeSheet";
			oCmd.Parameters.AddWithValue("@UserId", TeamId);
			oCmd.Parameters.AddWithValue("@StartDate", StartDate);
			oCmd.Parameters.AddWithValue("@EndDate", EndDate);
			oDs = new System.Data.DataSet();

			oDa.Fill(oDs);

			CloseDb();
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	internal System.Data.DataSet GetReportByReference(Int32 TeamId, DateTime StartDate, DateTime EndDate)
	{
		DataSet oDs = null;

		try
		{
			OpenDb();

			System.Data.SqlClient.SqlCommand oCmd = new SqlCommand();
			System.Data.SqlClient.SqlDataAdapter oDa = new SqlDataAdapter(oCmd);

			oCmd.Connection = oDbConn;
			oCmd.CommandType = System.Data.CommandType.StoredProcedure;
			oCmd.CommandText = "GetReportByReference";
			oCmd.Parameters.AddWithValue("@TeamId", TeamId);
			oCmd.Parameters.AddWithValue("@StartDate", StartDate);
			oCmd.Parameters.AddWithValue("@EndDate", EndDate);

			oDs = new System.Data.DataSet();
			oDa.Fill(oDs);

			CloseDb();
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	internal System.Data.DataSet GetReportByTask(Int32 TeamId, DateTime StartDate, DateTime EndDate)
	{
		DataSet oDs = null;

		try
		{
			OpenDb();

			System.Data.SqlClient.SqlCommand oCmd = new SqlCommand();
			System.Data.SqlClient.SqlDataAdapter oDa = new SqlDataAdapter(oCmd);

			oCmd.Connection = oDbConn;
			oCmd.CommandType = System.Data.CommandType.StoredProcedure;
			oCmd.CommandText = "GetReportByTask";
			oCmd.Parameters.AddWithValue("@TeamId", TeamId);
			oCmd.Parameters.AddWithValue("@StartDate", StartDate);
			oCmd.Parameters.AddWithValue("@EndDate", EndDate);

			oDs = new System.Data.DataSet();
			oDa.Fill(oDs);

			CloseDb();
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	internal System.Data.DataSet GetProfitReport(Int32 TeamId, DateTime StartDate, DateTime EndDate)
	{
		DataSet oDs = null;

		try
		{
			OpenDb();

			System.Data.SqlClient.SqlCommand oCmd = new SqlCommand();
			System.Data.SqlClient.SqlDataAdapter oDa = new SqlDataAdapter(oCmd);

			oCmd.Connection = oDbConn;
			oCmd.CommandType = System.Data.CommandType.StoredProcedure;
			oCmd.CommandText = "GetProfitReport";
			oCmd.Parameters.AddWithValue("@TeamId", TeamId);
			oCmd.Parameters.AddWithValue("@StartDate", StartDate);
			oCmd.Parameters.AddWithValue("@EndDate", EndDate);

			oDs = new System.Data.DataSet();
			oDa.Fill(oDs);

			CloseDb();
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	internal System.Data.DataSet GetTeamProductivity(Int32 TeamId, DateTime StartDate, DateTime EndDate)
	{
		DataSet oDs = null;

		try
		{
			OpenDb();

			System.Data.SqlClient.SqlCommand oCmd = new SqlCommand();
			System.Data.SqlClient.SqlDataAdapter oDa = new SqlDataAdapter(oCmd);

			oCmd.Connection = oDbConn;
			oCmd.CommandType = System.Data.CommandType.StoredProcedure;
			oCmd.CommandText = "GetTeamProductivity";
			oCmd.Parameters.AddWithValue("@TeamId", TeamId);
			oCmd.Parameters.AddWithValue("@DateStart", StartDate);
			oCmd.Parameters.AddWithValue("@DateEnd", EndDate);

			oDs = new System.Data.DataSet();
			oDa.Fill(oDs);

			CloseDb();
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	internal Int32 SaveTimeRecord(Int32 TimeId, DateTime DateVal, Int32 UserId, Int32 ProjectId,
		Int32 TaskId, Int32 StatusId, string Comment, string JobRef, double Hours, Boolean Locked)
	{
		Int32 nRetVal = 0;

		try
		{
			OpenDb();

			System.Data.SqlClient.SqlCommand oCmd = new SqlCommand();

			oCmd.Connection = oDbConn;
			oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            //oCmd.CommandText = "SaveTimeRecord";
            //oCmd.Parameters.Add("@TimeId", SqlDbType.Int);
            //oCmd.Parameters["@TimeId"].Direction = ParameterDirection.InputOutput;
            //oCmd.Parameters["@TimeId"].Value = TimeId;
            //oCmd.Parameters.AddWithValue("@DateVal", DateVal);
            //oCmd.Parameters.AddWithValue("@UserId", UserId);
            //oCmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            //oCmd.Parameters.AddWithValue("@TaskId", TaskId);
            //oCmd.Parameters.AddWithValue("@StatusId", StatusId);
            //oCmd.Parameters.AddWithValue("@Comment", Comment);
            //oCmd.Parameters.AddWithValue("@JobRef", JobRef);
            //oCmd.Parameters.AddWithValue("@Hours", Hours);
            //oCmd.Parameters.AddWithValue("@Locked", (Locked) ? 1 : 0);
            //oCmd.ExecuteNonQuery();
            //nRetVal = Int32.Parse(oCmd.Parameters["@TimeId"].Value.ToString());
            oCmd.CommandText = "SaveTimeRecord_New";
            oCmd.Parameters.Add("@TimeId", SqlDbType.Int);
            oCmd.Parameters["@TimeId"].Direction = ParameterDirection.InputOutput;
            oCmd.Parameters["@TimeId"].Value = TimeId;
            oCmd.Parameters.AddWithValue("@DateVal", DateVal);
            oCmd.Parameters.AddWithValue("@UserId", UserId);
            oCmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            oCmd.Parameters.AddWithValue("@StatusId", StatusId);
            oCmd.Parameters.AddWithValue("@Hours", Hours);
            oCmd.Parameters.AddWithValue("@Locked", (Locked) ? 1 : 0);
            oCmd.ExecuteNonQuery();
            nRetVal = Int32.Parse(oCmd.Parameters["@TimeId"].Value.ToString());
            CloseDb();
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
			nRetVal = -1;
		}

		return nRetVal;
	}

	internal Int32 SaveUser(Int32 UsrId, Int32 TmId, Int32 GrpId, string UsrNam,
		string Pwd, string SurNam, string ForNam, string Email, double Rate)
	{
		Int32 nRetVal = 0;

		try
		{
			OpenDb();

			System.Data.SqlClient.SqlCommand oCmd = new SqlCommand();

			oCmd.Connection = oDbConn;
			oCmd.CommandType = System.Data.CommandType.StoredProcedure;
			oCmd.CommandText = "SaveUser";
			oCmd.Parameters.AddWithValue("@UserId", UsrId);
			oCmd.Parameters.AddWithValue("@TeamId", TmId);
			oCmd.Parameters.AddWithValue("@UserGroupId", GrpId);
			oCmd.Parameters.AddWithValue("@UserName", UsrNam);
			oCmd.Parameters.AddWithValue("@Password", Pwd);
			oCmd.Parameters.AddWithValue("@Surname", SurNam);
			oCmd.Parameters.AddWithValue("@Forename", ForNam);
			oCmd.Parameters.AddWithValue("@EmailAddress", Email);
			oCmd.Parameters.AddWithValue("@HourlyRate", Rate);
			oCmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
			oCmd.Parameters["@ReturnVal"].Value = 0;
			oCmd.Parameters["@ReturnVal"].Direction = ParameterDirection.Output;
			oCmd.ExecuteNonQuery();
			nRetVal = Int32.Parse(oCmd.Parameters["@ReturnVal"].Value.ToString());
			CloseDb();
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
			nRetVal = -1;
		}

		return nRetVal;
	}

	internal Boolean SendEmail(string ToEmail, string Subject, string MsgBody, Boolean bSendHtml)
	{
		Boolean bRetVal = false;

		try
		{
			StringBuilder oHdr = new StringBuilder("");
			StringBuilder oFtr = new StringBuilder("");

			if (bSendHtml == true)
			{
				//	Sending HTML email.

				oHdr.Append("<!DOCTYPE HTML PUBLIC\"-//IETF//DTD HTML//EN\">");
				oHdr.Append("<html>");
				oHdr.Append("<head>");
				oHdr.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\">");
				oHdr.Append("</head>");
				oHdr.Append("<body bgcolor=\"FFFFFF\">");
				oFtr.Append("</body></html>");

				MsgBody = string.Format("{0}{1}{2}", oHdr.ToString(), MsgBody, oFtr.ToString());
			}

			OpenDb();

			System.Data.SqlClient.SqlCommand oCmd = new SqlCommand();

			oCmd.Connection = oDbConn;
			oCmd.CommandType = System.Data.CommandType.StoredProcedure;
			oCmd.CommandText = "SendEmail";
			oCmd.Parameters.AddWithValue("@ToEmail", ToEmail);
			oCmd.Parameters.AddWithValue("@Subject", Subject);
			oCmd.Parameters.AddWithValue("@MsgBody", MsgBody);
			oCmd.Parameters.AddWithValue("@HtmlEmail", (bSendHtml) ? 1 : 0);
			oCmd.ExecuteNonQuery();
			bRetVal = true;
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
			bRetVal = false;
		}

		finally
		{
			CloseDb();
		}

		return bRetVal;
	}
}
