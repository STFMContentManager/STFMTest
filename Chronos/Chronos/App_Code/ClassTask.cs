//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\ClassTask.cs $
//	$Revision: 1.2 $
//	---------------------------------------------------------------------------
using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Diagnostics;

	/// <summary>
	/// Summary description for ClassTask
	/// </summary>
public class ClassTask
{
	#region Declarations
	private int m_TaskId;
	private int m_ProjectId;
	private string m_TaskName;
	private string m_CostCentre;
	private string m_Description;
	private string m_ReferenceRegEx;
	private Boolean m_IsProductive;
	private Boolean m_Active;
	private Int16 m_ValidationType;
	#endregion

	public ClassTask()
	{
		Init();
	}

	public ClassTask(int TskId)
	{
		Load(TskId);
	}

	private void Init()
	{
		this.m_TaskId = 0;
		this.m_ProjectId = 0;
		this.m_TaskName = "";
		this.m_CostCentre = "";
		this.m_Description = "";
		this.m_ReferenceRegEx = "";
		this.m_IsProductive = false;
		this.m_Active = true;
		this.m_ValidationType = 0;
	}

	public int Load(int TskId)
	{
		int nRetVal = 0;

		try
		{
			Init();

			DataSet oDs = Db.SqlQuery(string.Format("SELECT * FROM tblTasks WHERE TaskId = {0}", TskId));

			if (Db.HasRecord(oDs) == true)
			{
				DataRow oDr = oDs.Tables[0].Rows[0];

				this.m_TaskId = (oDr["TaskId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["TaskId"].ToString());
				this.m_ProjectId = (oDr["ProjectId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["ProjectId"].ToString());
				this.m_TaskName = (oDr["TaskName"] == System.DBNull.Value) ? "" : oDr["TaskName"].ToString();
				this.m_CostCentre = (oDr["CostCentre"] == System.DBNull.Value) ? "" : oDr["CostCentre"].ToString();
				this.m_Description = (oDr["Description"] == System.DBNull.Value) ? "" : oDr["Description"].ToString();
				this.m_ReferenceRegEx = (oDr["ReferenceRegEx"] == System.DBNull.Value) ? "" : oDr["ReferenceRegEx"].ToString();
				this.m_IsProductive = (oDr["IsProductive"] == System.DBNull.Value) ? false : Convert.ToBoolean(oDr["IsProductive"].ToString());
				this.m_Active = (oDr["Active"] == System.DBNull.Value) ? false : Convert.ToBoolean(oDr["Active"].ToString());
				this.m_ValidationType = (oDr["ValidationType"] == System.DBNull.Value) ? Convert.ToInt16(0) : Convert.ToInt16(oDr["ValidationType"].ToString());

				nRetVal = this.m_TaskId;
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			this.m_TaskId = -1;
		}

		return nRetVal;
	}

	public int Save(int TskId)
	{
		int nRetVal = 0;

		try
		{
			StringBuilder oBld = new StringBuilder("");

			if (TskId == 0)
			{
				//	New task.

				oBld.Append("INSERT INTO tblTasks (ProjectId, TaskName, CostCentre, Description, ReferenceRegEx, IsProductive, Active, ValidationType) VALUES (");
				oBld.Append(this.m_ProjectId.ToString());
				oBld.Append(string.Format(", {0}", Db.Quoted(this.m_TaskName)));
				oBld.Append(string.Format(", {0}", Db.Quoted(this.m_CostCentre)));
				oBld.Append(string.Format(", {0}", Db.Quoted(this.m_Description)));
				oBld.Append(string.Format(", {0}", Db.Quoted(this.m_ReferenceRegEx)));
				oBld.Append(string.Format(", {0}", (this.m_IsProductive == false) ? "0" : "1"));
				oBld.Append(string.Format(", {0}", (this.m_Active == false) ? "0" : "1"));
				oBld.Append(string.Format(", {0}", this.m_ValidationType));
				oBld.Append(");\r\nSELECT SCOPE_IDENTITY()");

				this.m_TaskId = Db.SqlAction(oBld.ToString());
				nRetVal = this.m_TaskId;
			}
			else
			{
				//	Update existing task.

				oBld.Append(string.Format("UPDATE tblTasks SET ProjectId = {0}", this.m_ProjectId));
				oBld.Append(string.Format(", TaskName = {0}", Db.Quoted(this.m_TaskName)));
				oBld.Append(string.Format(", CostCentre = {0}", Db.Quoted(this.m_CostCentre)));
				oBld.Append(string.Format(", Description = {0}", Db.Quoted(this.m_Description)));
				oBld.Append(string.Format(", ReferenceRegEx = {0}", Db.Quoted(this.m_ReferenceRegEx)));
				oBld.Append(string.Format(", IsProductive = {0}", (this.m_IsProductive == false) ? "0" : "1"));
				oBld.Append(string.Format(", Active = {0}", (this.m_Active == false) ? "0" : "1"));
				oBld.Append(string.Format(", ValidationType = {0}", this.m_ValidationType));
				oBld.Append(string.Format(" WHERE TaskId = {0}", TskId));

				Db.SqlAction(oBld.ToString());
				this.m_TaskId = TskId;
				nRetVal = TskId;
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			this.m_TaskId = -1;
		}

		return nRetVal;
	}

	public void Delete(Int32 TskId)
	{
		Db.SqlAction(string.Format("DELETE FROM tblTasks WHERE TaskId = {0}", TskId));
	}

	public DataSet ShowTasksForProject(Int32 PrjId, Boolean bActiveOnly)
	{
		if (bActiveOnly == true)
			return Db.SqlQuery(string.Format("SELECT TaskId, TaskName FROM tblTasks WHERE (ProjectId = {0}) AND (Active = 1) ORDER BY TaskName", PrjId));
		else
			return Db.SqlQuery(string.Format("SELECT TaskId, TaskName FROM tblTasks WHERE (ProjectId = {0}) ORDER BY TaskName", PrjId));
	}

	#region Properties
	public int TaskId
	{
		get
		{
			return m_TaskId;
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

	public string TaskName
	{
		get
		{
			return m_TaskName;
		}
		set
		{
			m_TaskName = value;
		}
	}

	public string CostCentre
	{
		get
		{
			return m_CostCentre;
		}
		set
		{
			m_CostCentre = value;
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

	public string ReferenceRegEx
	{
		get
		{
			return m_ReferenceRegEx;
		}
		set
		{
			m_ReferenceRegEx = value;
		}
	}

	public Boolean IsProductive
	{
		get
		{
			return m_IsProductive;
		}
		set
		{
			m_IsProductive = value;
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

	public Int16 ValidationType
	{
		get
		{
			return m_ValidationType;
		}
		set
		{
			m_ValidationType = value;
		}
	}
	#endregion

}
