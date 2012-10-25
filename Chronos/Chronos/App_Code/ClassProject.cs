//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\ClassProject.cs $
//	$Revision: 1.1 $
//	---------------------------------------------------------------------------
using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Diagnostics;

	/// <summary>
	/// Summary description for ClassProject
	/// </summary>
public class ClassProject
{
	#region Declarations
	private int m_ProjectId;
	private string m_ProjectName;
	private string m_CostCentre;
	#endregion

	public ClassProject()
	{
		Init();
	}

	public ClassProject(int PrjId)
	{
		Load(PrjId);
	}

	private void Init()
	{
		this.m_ProjectId = 0;
		this.m_ProjectName = "";
		this.m_CostCentre = "";
	}

	public int Load(int PrjId)
	{
		int nRetVal = 0;

		try
		{
			Init();
			DataSet oDs = Db.SqlQuery("SELECT * FROM tblProjects WHERE ProjectId = " + PrjId.ToString());

			if (Db.HasRecord(oDs) == true)
			{
				DataRow oDr = oDs.Tables[0].Rows[0];

				this.m_ProjectId = (oDr["ProjectId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["ProjectId"].ToString());
				this.m_ProjectName = (oDr["ProjectName"] == System.DBNull.Value) ? "" : oDr["ProjectName"].ToString();
				this.m_CostCentre = (oDr["CostCentre"] == System.DBNull.Value) ? "" : oDr["CostCentre"].ToString();
				nRetVal = PrjId;
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			nRetVal = -1;
		}

		return nRetVal;
	}

	public int Save(int PrjId)
	{
		int nRetVal = 0;

		try
		{
			StringBuilder oBld = new StringBuilder("");

			if (PrjId == 0)
			{
				//	New project.

				oBld.Append("INSERT INTO tblProjects (ProjectName, CostCentre) VALUES (");
				oBld.Append(Db.Quoted(this.m_ProjectName));
				oBld.Append(", ");
				oBld.Append(Db.Quoted(this.m_CostCentre));
				oBld.Append(");\r\nSELECT SCOPE_IDENTITY()");

				nRetVal = Db.SqlAction(oBld.ToString());
			}
			else
			{
				//	Update existing project.

				oBld.Append("UPDATE tblProjects SET ProjectName = ");
				oBld.Append(Db.Quoted(this.m_ProjectName));
				oBld.Append(", CostCentre = ");
				oBld.Append(Db.Quoted(this.m_CostCentre));
				oBld.Append(" WHERE ProjectId = ");
				oBld.Append(PrjId.ToString());

				Db.SqlAction(oBld.ToString());
				nRetVal = PrjId;
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			nRetVal = -1;
		}

		return nRetVal;
	}

	public void Delete(Int32 PrjId)
	{
		Db.SqlAction(string.Format("DELETE FROM tblProjects WHERE ProjectId = {0}", PrjId));
	}

	public DataSet ShowProjects()
	{
		return Db.SqlQuery("SELECT ProjectId, ProjectName FROM tblProjects ORDER BY ProjectName");
	}

	public DataSet ShowProjectsWithUserFlag(Int32 UserId)
	{
        //return Db.SqlQuery(string.Format("SELECT ProjectId, ProjectName FROM tblProjects " +
        //"WHERE (ProjectID IN (SELECT ProjectId FROM tblTasks)) AND (ProjectId IN (SELECT ProjectId " +
        //"FROM tblMapProjectToUser WHERE UserId = {0})) ORDER BY ProjectName", UserId));
        return Db.SqlQuery(string.Format("SELECT ProjectId, ProjectName FROM tblProjects " +
        "WHERE (ProjectId IN (SELECT ProjectId " +
        "FROM tblMapProjectToUser WHERE UserId = {0})) ORDER BY ProjectName", UserId));
    }

	public DataSet ShowProjectsWithUserMap(Int32 UserId)
	{
		return Db.SqlQuery(string.Format("SELECT ProjectId, ProjectName, (SELECT COUNT(*) FROM tblMapProjectToUser AS B WHERE (UserId = {0}) AND (B.ProjectId = A.ProjectId)) AS Selected FROM tblProjects AS A ORDER BY ProjectName", UserId));
	}

	public void DeleteMapForUser(Int32 UserId)
	{
		Db.SqlAction(string.Format("DELETE FROM tblMapProjectToUser WHERE (UserId = {0})", UserId));
	}

	public void MapProjectToUser(Int32 UserId, Int32 PrjId)
	{
		Db.SqlAction(string.Format("INSERT INTO tblMapProjectToUser (UserId, ProjectId) VALUES ({0}, {1})", UserId, PrjId));
	}

	#region Properties
	public int ProjectId
	{
		get
		{
			return m_ProjectId;
		}
	}

	public string ProjectName
	{
		get
		{
			return m_ProjectName;
		}
		set
		{
			m_ProjectName = value;
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
	#endregion
}
