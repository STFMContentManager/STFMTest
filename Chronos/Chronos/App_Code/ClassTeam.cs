//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\ClassTeam.cs $
//	$Revision: 1.2 $
//	---------------------------------------------------------------------------
using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Diagnostics;

	/// <summary>
	/// Summary description for ClassTeam
	/// </summary>
public class ClassTeam
{
	#region Declarations
	private int m_TeamId;
	private string m_TeamName;
	#endregion

	public ClassTeam()
	{
		Init();
	}

	public ClassTeam(int TmId)
	{
		Load(TmId);
	}

	private void Init()
	{
		this.m_TeamId = 0;
		this.m_TeamName = "";
	}

	public int Load(int TmId)
	{
		int nRetVal = 0;

		try
		{
			Init();
			DataSet oDs = Db.SqlQuery("SELECT * FROM tblTeams WHERE TeamId = " + TmId.ToString());

			if (Db.HasRecord(oDs) == true)
			{
				DataRow oDr = oDs.Tables[0].Rows[0];

				this.m_TeamId = (oDr["TeamId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["TeamId"].ToString());
				this.m_TeamName = (oDr["TeamName"] == System.DBNull.Value) ? "" : oDr["TeamName"].ToString();
				nRetVal = TmId;
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			nRetVal = -1;
		}

		return nRetVal;
	}

	public int Save(int TmId)
	{
		int nRetVal = 0;

		try
		{
			StringBuilder oBld = new StringBuilder("");

			if (TmId == 0)
			{
				//	New Team.

				oBld.Append("INSERT INTO tblTeams (TeamName) VALUES (");
				oBld.Append(Db.Quoted(this.m_TeamName));
				oBld.Append(");\nSELECT SCOPE_IDENTITY()");

				nRetVal = Db.SqlAction(oBld.ToString());
			}
			else
			{
				//	Update existing Team.

				oBld.Append("UPDATE tblTeams SET TeamName = ");
				oBld.Append(Db.Quoted(this.m_TeamName));
				oBld.Append(" WHERE TeamId = ");
				oBld.Append(TmId.ToString());

				Db.SqlAction(oBld.ToString());
				nRetVal = TmId;
			}
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
		Db.SqlAction(string.Format("DELETE FROM tblTeams WHERE TeamId = {0}", TmId));
	}

	public DataSet ShowTeams1()
	{
		return Db.SqlQuery("SELECT TeamId, TeamName FROM tblTeams ORDER BY TeamName");
	}

	public DataSet ShowTeams2(Int32 TmId)
	{
		return Db.SqlQuery(string.Format("SELECT TeamId, TeamName FROM tblTeams WHERE TeamId = {0}", TmId));
	}

	#region Properties
	public int TeamId
	{
		get
		{
			return m_TeamId;
		}
	}

	public string TeamName
	{
		get
		{
			return m_TeamName;
		}
		set
		{
			m_TeamName = value;
		}
	}
	#endregion
}
