//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\ClassTime.cs $
//	$Revision: 1.1 $
//	---------------------------------------------------------------------------
using System;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Text;

public class ClassTime
{
	#region Declarations
	private const Int32 EVALUATION_DAYS = 30;

	private int m_TimeId;
	private DateTime m_DateVal;
	private int m_UserId;
	private int m_ProjectId;
	private int m_TaskId;
	private int m_StatusId;
	private string m_Comment;
	private string m_JobRef;
	private double m_Hours;
	private Boolean m_Locked;
	#endregion

	public ClassTime()
	{
		Init();
	}

	public ClassTime(int TimId)
	{
		Load(TimId);
	}

	private void Init()
	{
		this.m_TimeId = 0;
		this.m_DateVal = DateTime.Today;
		this.m_UserId = 0;
		this.m_ProjectId = 0;
		this.m_TaskId = 0;
		this.m_StatusId = 0;
		this.m_Comment = "";
		this.m_JobRef = "";
		this.m_Hours = 0;
		this.m_Locked = false;
	}

	public int Load(int TimId)
	{
		int nRetVal = 0;

		try
		{
			Init();

			string SqlStr = string.Format(string.Format("SELECT * FROM TimeSheet WHERE TimeId = {0}", TimId));
			DataSet oDs = Db.SqlQuery(SqlStr);

			if (Db.HasRecord(oDs) == true)
			{
				DataRow oDr = oDs.Tables[0].Rows[0];

				this.m_TimeId = (oDr["TimeId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["TimeId"].ToString());
				this.m_DateVal = (oDr["DateVal"] == System.DBNull.Value) ? DateTime.Today : Convert.ToDateTime(oDr["DateVal"]);
				this.m_UserId = (oDr["UserId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["UserId"].ToString());
				this.m_ProjectId = (oDr["ProjectId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["ProjectId"].ToString());
				//this.m_TaskId = (oDr["TaskId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["TaskId"].ToString());
				this.m_StatusId = (oDr["StatusId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["StatusId"].ToString());
				//this.m_Comment = (oDr["Comment"] == System.DBNull.Value) ? "" : oDr["Comment"].ToString();
				//this.m_JobRef = (oDr["JobRef"] == System.DBNull.Value) ? "" : oDr["JobRef"].ToString();
				this.m_Hours = (oDr["Hours"] == System.DBNull.Value) ? 0 : (double)Math.Round(Convert.ToDouble(oDr["Hours"].ToString()), 2);

				if (oDr["Locked"] == System.DBNull.Value)
					this.m_Locked = false;
				else
					this.m_Locked = (oDr["Locked"].ToString() == "True") ? true : false;

				nRetVal = this.m_TimeId;
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			nRetVal = -1;
		}

		return nRetVal;
	}

	public int Save(int TimId)
	{
		int nRetVal = 0;

		try
		{
			this.m_TimeId = Db.SaveTimeRecord(TimId, this.m_DateVal, this.m_UserId, this.m_ProjectId,
				this.m_TaskId, this.m_StatusId, this.m_Comment, this.m_JobRef, this.m_Hours,
				this.m_Locked);
			nRetVal = this.m_TimeId;
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			nRetVal = -1;
		}

		return nRetVal;
	}

	public void Delete(Int32 TmId)
	{
		Db.SqlAction(string.Format("DELETE FROM TimeSheet WHERE TimeId = {0}", TmId));
	}

	public void LockAndUnlock(Boolean bSetLock, Int32 UserId, DateTime StartDate, DateTime EndDate)
	{
		Db.SqlAction(string.Format("UPDATE tblTime SET Locked = {0} WHERE (UserId = {1}) AND " +
		"(DateVal BETWEEN {2} AND {3})", bSetLock, UserId, StartDate, EndDate));
	}

	#region Properties.
	public int TimeId
	{
		get
		{
			return m_TimeId;
		}
	}

	public DateTime DateVal
	{
		get
		{
			return m_DateVal;
		}
		set
		{
			m_DateVal = value;
		}
	}

	public int UserId
	{
		get
		{
			return m_UserId;
		}
		set
		{
			m_UserId = value;
		}
	}

	public int ProjectId
	{
		get
		{
			return m_ProjectId;
		}
		set
		{
			m_ProjectId = value;
		}
	}

	public int TaskId
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

	public int StatusId
	{
		get
		{
			return m_StatusId;
		}
		set
		{
			m_StatusId = value;
		}
	}

	public string Comment
	{
		get
		{
			return m_Comment;
		}
		set
		{
			m_Comment = value;
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

	public double Hours
	{
		get
		{
			return m_Hours;
		}
		set
		{
			m_Hours = value;
		}
	}

	public Boolean Locked
	{
		get
		{
			return m_Locked;
		}
		set
		{
			m_Locked = value;
		}
	}
	#endregion

}
