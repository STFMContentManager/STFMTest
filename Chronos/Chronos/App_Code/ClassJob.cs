//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\ClassJob.cs $
//	$Revision: 1.2 $
//	---------------------------------------------------------------------------
using System;
using System.Data;
using System.Text;

	/// <summary>
	/// Summary description for ClassJob
	/// </summary>
public class ClassJob
{
	#region Declarations
	private Int32 m_JobId;
	private Int32 m_TaskId;
	private string m_JobRef;
	private string m_Description;
	private double m_BudgetHours;
	private Boolean m_Active;
	#endregion

	public ClassJob()
	{
		Init();
	}

	public ClassJob(Int32 JbId)
	{
		Load(JbId);
	}

	public ClassJob(string JbRef)
	{
		Load(JbRef);
	}

	private void Init()
	{
		this.m_JobId = 0;
		this.m_TaskId = 0;
		this.m_JobRef = "";
		this.m_Description = "";
		this.m_BudgetHours = 0.0;
		this.m_Active = true;
	}

	public Int32 Load(string JbRef)
	{
		Int32 RetVal = 0;

		try
		{
			DataSet oDs = Db.SqlQuery(string.Format("SELECT TOP 1 JobId FROM tblJobs WHERE JobRef = '{0}'", JbRef));

			if (Db.HasRecord(oDs) == true)
			{
				RetVal = Load(Convert.ToInt32(oDs.Tables[0].Rows[0]["JobId"].ToString()));
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			RetVal = -1;
		}

		return RetVal;
	}

	public Int32 Load(Int32 JbId)
	{
		Int32 RetVal = 0;

		try
		{
			Init();

			DataSet oDs = Db.SqlQuery(string.Format("SELECT * FROM tblJobs WHERE JobId = {0}", JbId));

			if (Db.HasRecord(oDs) == true)
			{
				DataRow oDr = oDs.Tables[0].Rows[0];

				this.m_JobId = (oDr["JobId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["JobId"].ToString());
				this.m_TaskId = (oDr["TaskId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["TaskId"].ToString());
				this.m_JobRef = (oDr["JobRef"] == System.DBNull.Value) ? "" : oDr["JobRef"].ToString();
				this.m_Description = (oDr["Description"] == System.DBNull.Value) ? "" : oDr["Description"].ToString();
				this.m_BudgetHours = (oDr["BudgetHours"] == System.DBNull.Value) ? 0 : Convert.ToDouble(oDr["BudgetHours"].ToString());
				this.m_Active = (oDr["Active"] == System.DBNull.Value) ? true : Convert.ToBoolean(oDr["Active"].ToString());
				RetVal = this.m_JobId;
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			RetVal = -1;
		}

		return RetVal;
	}

	public Int32 Save(Int32 JbId)
	{
		Int32 RetVal = 0;

		try
		{
			StringBuilder oStr = new StringBuilder("");

			if (JbId == 0)
			{
				oStr.Append("INSERT INTO tblJobs (TaskId, JobRef, Description, BudgetHours, Active) VALUES (");
				oStr.Append(string.Format("{0}, '{1}', '{2}', {3:f}, {4});", this.m_TaskId, this.m_JobRef,
					this.m_Description, this.m_BudgetHours, (this.m_Active == true) ? 1 : 0));
				oStr.Append("\r\nSELECT SCOPE_IDENTITY()");

				this.m_JobId = Db.SqlAction(oStr.ToString());
				RetVal = this.m_JobId;
			}
			else
			{
				oStr.Append("UPDATE tblJobs SET ");
				oStr.Append(string.Format("TaskId = {0}", this.m_TaskId));
				oStr.Append(string.Format(", JobRef = '{0}'", this.m_JobRef));
				oStr.Append(string.Format(", Description = '{0}'", this.m_Description));
				oStr.Append(string.Format(", BudgetHours = {0:f}", this.m_BudgetHours));
				oStr.Append(string.Format(", Active = {0}", (this.m_Active == true) ? 1 : 0));
				oStr.Append(string.Format(" WHERE JobId = {0}", JbId));

				Db.SqlAction(oStr.ToString());
				RetVal = Load(JbId);
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return RetVal;
	}

	public void Delete(Int32 JobId)
	{
		Db.SqlAction(string.Format("DELETE FROM tblJobs WHERE JobId = {0}", JobId));
	}

	public Boolean IsJobActive(string JobRef)
	{
		Boolean bRetVal = false;

		try
		{
			DataSet oDs = Db.SqlQuery(string.Format("SELECT COUNT(*) FROM tblJobs WHERE (JobRef = {0}) AND (Active = 1)", JobRef));

			if (Db.HasRecord(oDs) == true)
			{
				if (Convert.ToInt32(oDs.Tables[0].Rows[0][0].ToString()) > 0)
				{
					//	There is a valid job in the tblJobs table.

					bRetVal = true;
				}
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			bRetVal = false;
		}

		return bRetVal;
	}

	public DataSet ShowJobsForTask(Int32 TaskId, Boolean bOnlyActive)
	{
		if (bOnlyActive == true)
		{
			//	Only include those jobs which are currently set as active.

			return Db.SqlQuery(string.Format("SELECT *, ISNULL((SELECT SUM(B.Hours) FROM tblTime AS B WHERE A.JobRef = B.JobRef), 0) AS BookedHours FROM tblJobs AS A WHERE (TaskId = {0}) AND (Active = 1) ORDER BY A.Active DESC, A.JobRef DESC", TaskId));
		}
		else
		{
			//	Return all jobs.

			return Db.SqlQuery(string.Format("SELECT *, ISNULL((SELECT SUM(B.Hours) FROM tblTime AS B WHERE A.JobRef = B.JobRef), 0) AS BookedHours FROM tblJobs AS A WHERE (TaskId = {0}) ORDER BY A.Active DESC, A.JobRef DESC", TaskId));
		}
	}

	#region Properties
	public Int32 JobId
	{
		get
		{
			return m_JobId;
		}
	}

	public Int32 TaskId
	{
		get
		{
			return m_TaskId;
		}
		set
		{
			m_TaskId = value;
		}
	}

	public string JobRef
	{
		get
		{
			return m_JobRef;
		}
		set
		{
			m_JobRef = value;
		}
	}

	public string Description
	{
		get
		{
			return m_Description;
		}
		set
		{
			m_Description = value;
		}
	}

	public double BudgetHours
	{
		get
		{
			return m_BudgetHours;
		}
		set
		{
			m_BudgetHours = value;
		}
	}

	public Boolean Active
	{
		get
		{
			return m_Active;
		}
		set
		{
			m_Active = value;
		}
	}
	#endregion

}
