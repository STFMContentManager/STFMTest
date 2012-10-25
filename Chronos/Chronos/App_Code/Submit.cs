using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;


/// <summary>
/// Summary description for Submit
/// </summary>
[WebService(Namespace = "http://timerep.co.uk/Submit/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Submit : System.Web.Services.WebService
{
	private Int32 GetUserId(string UsrNam, string UsrPwd)
	{
		Int32 RetVal = 0;

		try
		{
			ClassUser oUsr = new ClassUser();

			RetVal = oUsr.Logon(UsrNam,UsrPwd);
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			RetVal = -1;
		}

		return RetVal;
	}

	[WebMethod]
	public string GetVersionNumber(string UsrNam, string UsrPwd)
	{
		string RetVal = "UNKNOWN";

		try
		{
			Int32 UserId = GetUserId(UsrNam, UsrPwd);

			if (UserId > 0)
			{
				RetVal = string.Format("Version: {0}", Util.VersionNo());
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return RetVal;
	}

	[WebMethod]
	public Int32 SubmitTimesheetEntry(string UsrNam, string UsrPwd, DateTime DateVal, Int32 ProjectId,
		Int32 TaskId, Int32 StatusId, string Comment, string JobRef, double Hours)
	{
		Int32 RetVal = 0;

		try
		{
			Int32 UserId = GetUserId(UsrNam, UsrPwd);

			if (UserId > 0)
			{
				ClassTime oTim = new ClassTime();

				oTim.DateVal = DateVal;
				oTim.UserId = UserId;
				oTim.ProjectId = ProjectId;
				oTim.TaskId = TaskId;
				oTim.StatusId = StatusId;
				oTim.Comment = Comment;
				oTim.JobRef = JobRef;
				oTim.Hours = Hours;

				RetVal = oTim.Save(0);
			}
			else
			{
				//	Valid user not found!

				RetVal = -1;
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			RetVal = -1;
		}

		return RetVal;
	}

	[WebMethod]
	public void DeleteTimesheetEntry(string UsrNam, string UsrPwd, Int32 TimeId)
	{
		try
		{
			Int32 UserId = GetUserId(UsrNam, UsrPwd);

			if (UserId > 0)
			{
				ClassTime oTim = new ClassTime();

				oTim.Delete(TimeId);
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}
	}

	[WebMethod]
	public DataSet GetTimeSheet(string UsrNam, string UsrPwd, DateTime StartDate, DateTime EndDate)
	{
		DataSet oDs = null;

		try
		{
			Int32 UserId = GetUserId(UsrNam, UsrPwd);

			if (UserId > 0)
			{
				ClassReport oRep = new ClassReport();

				oDs = oRep.GetTimeSheet(UserId, StartDate, EndDate);
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	[WebMethod]
	public DataSet GetProjectsForUser(string UsrNam, string UsrPwd)
	{
		DataSet oDs = null;

		try
		{
			Int32 UserId = GetUserId(UsrNam, UsrPwd);

			if (UserId > 0)
			{
				ClassProject oPrj = new ClassProject();

				oDs = oPrj.ShowProjectsWithUserMap(UserId);
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	[WebMethod]
	public DataSet GetTasksForProject(string UsrNam, string UsrPwd, Int32 ProjectId, Boolean bActiveOnly)
	{
		DataSet oDs = null;

		try
		{
			Int32 UserId = GetUserId(UsrNam, UsrPwd);

			if (UserId > 0)
			{
				ClassTask oTsk = new ClassTask();

				oDs = oTsk.ShowTasksForProject(ProjectId, bActiveOnly);
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	[WebMethod]
	public DataSet GetStatusList(string UsrNam, string UsrPwd)
	{
		DataSet oDs = null;

		try
		{
			Int32 UserId = GetUserId(UsrNam, UsrPwd);

			if (UserId > 0)
			{
				ClassStatus oStat = new ClassStatus();

				oDs = oStat.ShowStatus();
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}

	[WebMethod]
	public DataSet GetJobListForTask(string UsrNam, string UsrPwd, Int32 TaskId, Boolean bOnlyActive)
	{
		DataSet oDs = null;

		try
		{
			Int32 UserId = GetUserId(UsrNam, UsrPwd);

			if (UserId > 0)
			{
				ClassJob oJob = new ClassJob();

				oDs = oJob.ShowJobsForTask(TaskId, bOnlyActive);
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return oDs;
	}
}

