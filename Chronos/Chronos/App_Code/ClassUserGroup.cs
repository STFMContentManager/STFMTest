//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\ClassUserGroup.cs $
//	$Revision: 1.1 $
//	---------------------------------------------------------------------------
using System;
using System.Data;
using System.Configuration;
using System.Text;

	/// <summary>
	/// Summary description for ClassUserGroup
	/// </summary>
public class ClassUserGroup
{
	#region Declarations
	private Int32 m_UserGroupId;
	private string m_UserGroupName;
	private Int32 m_UserGroupPermissions;
	#endregion

	public ClassUserGroup()
	{
		Init();
	}

	public ClassUserGroup(Int32 GrpId)
	{
		Load(GrpId);
	}

	private void Init()
	{
		this.m_UserGroupId = 0;
		this.m_UserGroupName = "";
		this.m_UserGroupPermissions = 0;
	}

	public Int32 Load(Int32 GrpId)
	{
		Int32 RetVal = 0;

		try
		{
			Init();

			DataSet oDs = Db.SqlQuery(string.Format("SELECT * FROM tblUserGroups WHERE UserGroupId = {0}", GrpId));

			if (Db.HasRecord(oDs) == true)
			{
				DataRow oDr = oDs.Tables[0].Rows[0];

				this.m_UserGroupId = (oDr["UserGroupId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["UserGroupId"].ToString());
				this.m_UserGroupName = (oDr["UserGroupName"] == System.DBNull.Value) ? "" : oDr["UserGroupName"].ToString();
				this.m_UserGroupPermissions = (oDr["UserGroupPermissions"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["UserGroupPermissions"].ToString());

				RetVal = this.m_UserGroupId;
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			RetVal = -1;
		}

		return RetVal;
	}

	public Int32 Save(Int32 GrpId)
	{
		Int32 RetVal = 0;

		try
		{
			StringBuilder oStr = new StringBuilder("");

			if (GrpId == 0)
			{
				oStr.Append("INSERT INTO tblUserGroups (UserGroupName, UserGroupPermissions) VALUES (");
				oStr.Append(Db.Quoted(this.m_UserGroupName));
				oStr.Append(string.Format(", {0});", this.m_UserGroupPermissions));
				oStr.Append("\r\nSELECT SCOPE_IDENTITY()");

				this.m_UserGroupId = Db.SqlAction(oStr.ToString());
				RetVal = this.m_UserGroupId;
			}
			else
			{
				oStr.Append("UPDATE tblUserGroups SET ");
				oStr.Append(string.Format("UserGroupName = {0}", Db.Quoted(this.m_UserGroupName)));
				oStr.Append(string.Format(", UserGroupPermissions = {0}", this.m_UserGroupPermissions));
				oStr.Append(string.Format(" WHERE UserGroupId = {0}", GrpId));

				Db.SqlAction(oStr.ToString());
				RetVal = Load(GrpId);
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			RetVal = -1;
		}

		return RetVal;
	}

	public void Delete(Int32 GrpId)
	{
		Db.SqlAction(string.Format("DELETE FROM tblUserGroups WHERE UserGroupId = {0}", GrpId));
	}

	public DataSet ShowUserGroups()
	{
		return Db.SqlQuery("SELECT UserGroupId, UserGroupName FROM tblUserGroups ORDER BY UserGroupName");
	}

	#region Properties
	public Int32 UserGroupId
	{
		get
		{
			return m_UserGroupId;
		}
	}

	public string UserGroupName
	{
		get
		{
			return m_UserGroupName;
		}
		set
		{
			m_UserGroupName = value;
		}
	}

	public Int32 UserGroupPermissions
	{
		get
		{
			return m_UserGroupPermissions;
		}
		set
		{
			m_UserGroupPermissions = value;
		}
	}
	#endregion

}
