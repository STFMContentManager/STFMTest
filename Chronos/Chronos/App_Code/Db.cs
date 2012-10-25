//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\Db.cs $
//	$Revision: 1.5 $
//	---------------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Db
/// </summary>
public class Db
{
	#region Declarations
	private static Boolean bShowSql = false;
	#endregion

	/// <summary>
	/// Get/set flag to show/hide SQL.
	/// </summary>
	public static Boolean ShowSql
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

	/// <summary>
	/// Returns TRUE if the supplied dataset has at least one record in the
	/// first table of the dataset.
	/// </summary>
	/// <param name="oDs"></param>
	/// <returns></returns>
	public static Boolean HasRecord(DataSet oDs)
	{
		Boolean bRetVal = false;

		try
		{
			if (oDs != null)
			{
				if (oDs.Tables.Count > 0)
				{
					if (oDs.Tables[0].Rows.Count > 0)
					{
						//	This dataset has at least one record.

						bRetVal = true;
					}
				}
			}
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return bRetVal;
	}

	/// <summary>
	/// Applies quotes to supplied string. If there are embedded quotation marks in the
	/// supplied string these are doubled-up to make sure that normal SQL processing
	/// can take place.
	/// </summary>
	/// <param name="SrcStr"></param>
	/// <returns></returns>
	public static string Quoted(string SrcStr)
	{
		string sRetVal = "";

		try
		{
			ClassDb oDb = new ClassDb(Util.ReadString("ConnectionString", ""), bShowSql);

			sRetVal = oDb.Quoted(SrcStr);
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return sRetVal;
	}

	/// <summary>
	/// Perform SQL action on database. This would be an INSERT, UPDATE or DELETE
	/// statement.
	/// </summary>
	/// <param name="SqlStr">The SQL statement to execute</param>
	/// <returns>Value returned by SQL action, or -1 on error</returns>
	public static int SqlAction(string SqlStr)
	{
		int nRetVal = 0;

		try
		{
			ClassDb oDb = new ClassDb(Util.ReadString("ConnectionString", ""), bShowSql);

			nRetVal = oDb.SqlAction(SqlStr);
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
			nRetVal = -1;
		}

		return nRetVal;
	}

	/// <summary>
	/// Perform SQL query. This will be a SELECT statement.
	/// </summary>
	/// <param name="SqlStr">The SQL command to execute</param>
	/// <returns>Dataset from query</returns>
	public static DataSet SqlQuery(string SqlStr)
	{
		DataSet oDs = null;

		try
		{
			ClassDb oDb = new ClassDb(Util.ReadString("ConnectionString", ""), bShowSql);

			oDs = oDb.SqlQuery(SqlStr);
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	/// <summary>
	/// Returns a dataset for an export.
	/// </summary>
	/// <param name="ProjectId">The project ID to which the export applies</param>
	/// <param name="UserId">The user ID to which the export applies</param>
	/// <param name="StartDate">The start date of the request</param>
	/// <param name="EndDate">The end date of the request</param>
	/// <returns>Dataset containing records matching the request</returns>
	public static DataSet GetExport(Int32 ProjectId, Int32 UserId, DateTime StartDate, DateTime EndDate)
	{
		DataSet oDs = null;

		try
		{
			string WhichUser = (UserId == 0) ? "" : string.Format(" AND (A.UserId = {0})", UserId);

			if (ProjectId == 0)
			{
				//	All projects.

				oDs = SqlQuery(string.Format("SELECT CONVERT(VARCHAR, A.DateVal, 106) AS DateVal, B.Surname, B.Forename, D.ProjectName, C.TaskName, A.JobRef, E.StatusText, A.Hours FROM tblTime AS A INNER JOIN tblStatus AS E ON E.StatusId = A.StatusId INNER JOIN tblUsers AS B ON B.UserId = A.UserId INNER JOIN tblTasks AS C ON C.TaskId = A.TaskId INNER JOIN tblProjects AS D ON D.ProjectId = C.ProjectId WHERE (A.DateVal BETWEEN '{0}' AND '{1}'){2} ORDER BY A.DateVal, B.Surname, B.Forename, D.ProjectName, C.TaskName, A.JobRef",
					StartDate.ToLongDateString(), EndDate.ToLongDateString(), WhichUser));
			}
			else
			{
				//	Specific project.

				oDs = SqlQuery(string.Format("SELECT CONVERT(VARCHAR, A.DateVal, 106) AS DateVal, B.Surname, B.Forename, D.ProjectName, C.TaskName, A.JobRef, E.StatusText, A.Hours FROM tblTime AS A INNER JOIN tblStatus AS E ON E.StatusId = A.StatusId INNER JOIN tblUsers AS B ON B.UserId = A.UserId INNER JOIN tblTasks AS C ON C.TaskId = A.TaskId INNER JOIN tblProjects AS D ON D.ProjectId = C.ProjectId WHERE (D.ProjectId = {0}) AND (A.DateVal BETWEEN '{1}' AND '{2}'){3} ORDER BY A.DateVal, B.Surname, B.Forename, D.ProjectName, C.TaskName, A.JobRef",
					ProjectId, StartDate.ToLongDateString(), EndDate.ToLongDateString(), WhichUser));
			}
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	public static DataSet GetCostCentre(DateTime DateStart, DateTime DateEnd)
	{
		DataSet oDs = null;

		try
		{
			oDs = SqlQuery(string.Format("SELECT A.CostCentre, CASE A.IsProductive WHEN 1 THEN 'Yes' ELSE 'No' END AS IsProductive, ISNULL(SUM(B.Hours), 0.0) AS Hours, dbo.CostCentrePercent(A.CostCentre, '{0}', '{1}') AS PercentHours FROM tblTasks AS A JOIN tblTime AS B ON B.TaskId = A.TaskId WHERE (B.DateVal BETWEEN '{0}' AND '{1}') GROUP BY A.CostCentre, A.IsProductive",
				DateStart.ToLongDateString(), DateEnd.ToLongDateString()));
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	public static DataSet GetTimeSheet(Int32 UserId, DateTime StartDate, DateTime EndDate)
	{
		DataSet oDs = null;

		try
		{
			//oDs = SqlQuery(string.Format("SELECT A.TimeId, CONVERT(VARCHAR, A.DateVal, 101) AS DateVal, DAY(A.DateVal) AS DayNo, dbo.GetDayName(A.DateVal, 1) AS DayName, D.ProjectName, C.TaskName, A.JobRef, A.Comment, B.StatusText, A.Hours FROM tblTime AS A (NOLOCK) INNER JOIN tblStatus AS B ON B.StatusId = A.StatusId INNER JOIN tblTasks AS C ON C.TaskId = A.TaskId INNER JOIN tblProjects AS D ON D.ProjectId = A.ProjectId WHERE (A.DateVal >= '{1}') AND (A.DateVal < '{2}') AND (A.UserId = {0}) ORDER BY DateVal, ProjectName, TaskName, StatusText",
			//	UserId, StartDate.ToShortDateString(), (EndDate.AddDays(1)).ToShortDateString()));
            oDs = SqlQuery(string.Format("SELECT TimeId, CONVERT(VARCHAR, DateVal, 101) AS DateVal, DAY(DateVal) AS DayNo, dbo.GetDayName(DateVal, 1) AS DayName, ProjectId, StatusId, Hours FROM TimeSheet where DateVal >= '{0}' and DateVal <= '{1}' ORDER BY DateVal", StartDate.ToShortDateString(), EndDate.ToShortDateString()));
        }

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	public static System.Data.DataSet GetReportByTask(Int32 TeamId, Int32 UsrId, DateTime StartDate, DateTime EndDate)
	{
		DataSet oDs = null;

		try
		{
			if (UsrId == 0)
			{
				oDs = SqlQuery(string.Format("SELECT B.TaskName, (C.Surname + ', ' + C.Forename) AS UserName, CAST(ROUND(SUM(A.Hours), 2) AS VARCHAR) AS Hours FROM tblTime AS A (NOLOCK) INNER JOIN tblTasks AS B ON B.TaskId = A.TaskId INNER JOIN tblUsers AS C ON C.UserId = A.UserId WHERE (A.DateVal BETWEEN '{1}' AND '{2}') AND (A.UserId IN (SELECT UserId FROM tblUsers WHERE (TeamId = {0}))) GROUP BY TaskName, Surname, Forename",
					TeamId, StartDate.ToLongDateString(), EndDate.ToLongDateString()));
			}
			else
			{
				oDs = SqlQuery(string.Format("SELECT B.TaskName, (C.Surname + ', ' + C.Forename) AS UserName, CAST(ROUND(SUM(A.Hours), 2) AS VARCHAR) AS Hours FROM tblTime AS A (NOLOCK) INNER JOIN tblTasks AS B ON B.TaskId = A.TaskId INNER JOIN tblUsers AS C ON C.UserId = A.UserId WHERE (A.DateVal BETWEEN '{1}' AND '{2}') AND (A.UserId IN (SELECT UserId FROM tblUsers WHERE (UserId = {0}))) GROUP BY TaskName, Surname, Forename",
					UsrId, StartDate.ToLongDateString(), EndDate.ToLongDateString()));
			}
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	public static System.Data.DataSet GetReportByReference(Int32 TeamId, Int32 UsrId, DateTime StartDate, DateTime EndDate)
	{
		DataSet oDs = null;

		try
		{
			if (UsrId == 0)
			{
				oDs = SqlQuery(string.Format("SELECT A.JobRef, (B.Surname + ', ' + B.Forename) AS UserName, CAST(ROUND(SUM(A.Hours), 2) AS VARCHAR) AS Hours FROM tblTime AS A (NOLOCK) INNER JOIN tblUsers AS B ON B.UserId = A.UserId WHERE (A.DateVal BETWEEN '{1}' AND '{2}') AND (A.UserId IN (SELECT UserId FROM tblUsers WHERE (TeamId = {0}))) GROUP BY JobRef, Surname, Forename",
					TeamId, StartDate.ToLongDateString(), EndDate.ToLongDateString()));
			}
			else
			{
				oDs = SqlQuery(string.Format("SELECT A.JobRef, (B.Surname + ', ' + B.Forename) AS UserName, CAST(ROUND(SUM(A.Hours), 2) AS VARCHAR) AS Hours FROM tblTime AS A (NOLOCK) INNER JOIN tblUsers AS B ON B.UserId = A.UserId WHERE (A.DateVal BETWEEN '{1}' AND '{2}') AND (A.UserId IN (SELECT UserId FROM tblUsers WHERE (UserId = {0}))) GROUP BY JobRef, Surname, Forename",
					UsrId, StartDate.ToLongDateString(), EndDate.ToLongDateString()));
			}
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	public static System.Data.DataSet GetBudgetReport(Int32 ProjectId)
	{
		DataSet oDs = null;

		try
		{
			oDs = SqlQuery(string.Format("SELECT ProjectName, TaskName, JobRef, BudgetHours AS Budget, (SELECT ISNULL(SUM(Hours), 0.0) FROM tblTime AS D WHERE (D.JobRef = A.JobRef) AND (D.TaskId = B.TaskId)) AS Actual FROM tblJobs AS A INNER JOIN tblTasks AS B ON B.TaskId = A.TaskId INNER JOIN tblProjects AS C ON C.ProjectId = B.ProjectId WHERE C.ProjectId = {0} ORDER BY ProjectName, TaskName, JobRef", ProjectId));
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	public static System.Data.DataSet GetProfitReport(Int32 TeamId, Int32 UsrId, DateTime StartDate, DateTime EndDate)
	{
		DataSet oDs = null;

		try
		{
			if (UsrId == 0)
			{
				oDs = SqlQuery(string.Format("SELECT (Surname + ', ' + Forename) AS UserName, dbo.SumHoursForUser(UserId, '{1}', '{2}', 1) AS Productive, dbo.SumHoursForUser(UserId, '{1}', '{2}', 0) AS NonProductive, dbo.TotalHoursForUser(UserId, '{1}', '{2}') AS TotalHours, ROUND(dbo.PercentProductiveForUser(UserId, '{1}', '{2}'), 2) AS PercentProductive FROM tblUsers AS A (NOLOCK) WHERE (A.UserId IN (SELECT UserId FROM tblUsers WHERE (TeamId = {0}))) GROUP BY Surname, Forename, UserId",
					TeamId, StartDate.ToLongDateString(), EndDate.ToLongDateString()));
			}
			else
			{
				oDs = SqlQuery(string.Format("SELECT (Surname + ', ' + Forename) AS UserName, dbo.SumHoursForUser(UserId, '{1}', '{2}', 1) AS Productive, dbo.SumHoursForUser(UserId, '{1}', '{2}', 0) AS NonProductive, dbo.TotalHoursForUser(UserId, '{1}', '{2}') AS TotalHours, ROUND(dbo.PercentProductiveForUser(UserId, '{1}', '{2}'), 2) AS PercentProductive FROM tblUsers AS A (NOLOCK) WHERE (A.UserId IN (SELECT UserId FROM tblUsers WHERE (UserId = {0}))) GROUP BY Surname, Forename, UserId",
					UsrId, StartDate.ToLongDateString(), EndDate.ToLongDateString()));
			}
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	public static System.Data.DataSet GetTeamProductivity(Int32 TeamId, Int32 UsrId, DateTime StartDate, DateTime EndDate)
	{
		DataSet oDs = null;

		try
		{
			if (UsrId == 0)
			{
				//	Show data for all team members.

				oDs = SqlQuery(string.Format("SELECT UserId, UserName, Surname, Forename, dbo.UserProductivity(UserId, '{1}', '{2}') AS Productivity FROM tblUsers WHERE tblUsers.TeamId = {0} ORDER BY UserName DESC",
					TeamId, StartDate.ToLongDateString(), EndDate.ToLongDateString()));
			}
			else
			{
				//	Show data for single team member.

				oDs = SqlQuery(string.Format("SELECT UserId, UserName, Surname, Forename, dbo.UserProductivity(UserId, '{1}', '{2}') AS Productivity FROM tblUsers WHERE tblUsers.UserId = {0} ORDER BY UserName DESC",
					UsrId, StartDate.ToLongDateString(), EndDate.ToLongDateString()));
			}
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	public static Int32 SaveTimeRecord(Int32 TimeId, DateTime DateVal, Int32 UserId, Int32 ProjectId, 
		Int32 TaskId, Int32 StatusId, string Comment, string JobRef, double Hours, Boolean Locked)
	{
		Int32 nRetVal = 0;

		try
		{
			ClassDb oDb = new ClassDb(Util.ReadString("ConnectionString", ""), bShowSql);

			nRetVal = oDb.SaveTimeRecord(TimeId, DateVal, UserId, ProjectId,
				TaskId, StatusId, Comment, JobRef, Hours, Locked);
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return nRetVal;
	}

	public static Int32 SaveUser(Int32 UsrId, Int32 TmId, Int32 GrpId, string UsrNam, 
		string Pwd, string SurNam, string ForNam, string Email, double Rate)
	{
		Int32 nRetVal = 0;

		try
		{
			ClassDb oDb = new ClassDb(Util.ReadString("ConnectionString", ""), bShowSql);

			nRetVal = oDb.SaveUser(UsrId, TmId, GrpId, UsrNam, Pwd, SurNam, ForNam, Email, Rate);
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return nRetVal;
	}

	public static Boolean SendEmail(string ToEmail, string Subject, string MsgBody, Boolean bSendHtml)
	{
		Boolean bRetVal = false;

		try
		{
			ClassDb oDb = new ClassDb(Util.ReadString("ConnectionString", ""), bShowSql);

			bRetVal = oDb.SendEmail(ToEmail, Subject, MsgBody, bSendHtml);
		}

		catch (System.Exception ex)
		{
			Log.LogMsg(ex.Message);
			bRetVal = false;
		}

		return bRetVal;
	}
}
