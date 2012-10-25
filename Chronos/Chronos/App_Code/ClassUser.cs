//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\ClassUser.cs $
//	$Revision: 1.2 $
//	---------------------------------------------------------------------------
using System;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Text;

	/// <summary>
	/// Summary description for ClassUser
	/// </summary>
public class ClassUser
{
	#region Declarations
	private int m_UserId;
	private int m_TeamId;
	private int m_UserGroupId;
	private string m_UserName;
	private string m_Password;
	private string m_Surname;
	private string m_Forename;
	private string m_EmailAddress;
	private float m_HourlyRate;
	private int m_Permissions;
	#endregion

	public ClassUser()
	{
		Init();
	}

	public ClassUser(int UsrId)
	{
		Load(UsrId);
	}

	private void Init()
	{
		//	Initialise properties.

		this.m_UserId = 0;
		this.m_TeamId = 0;
		this.m_UserGroupId = 0;
		this.m_UserName = "";
		this.m_Password = "";
		this.m_Surname = "";
		this.m_Forename = "";
		this.m_EmailAddress = "";
		this.m_HourlyRate = 0;
		this.m_Permissions = 0;
	}

	public int LoadByUserName(string UsrNam)
	{
		//	Loads user according to their user name.

		int nRetVal = 0;

		try
		{
			Init();

			string SqlStr = "SELECT UserId FROM tblUsers WHERE UserName = " + Db.Quoted(UsrNam);
			DataSet oDs = Db.SqlQuery(SqlStr);

			if (Db.HasRecord(oDs) == true)
			{
				nRetVal = Load(Convert.ToInt32(oDs.Tables[0].Rows[0]["UserId"]));
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			nRetVal = -1;
		}

		return nRetVal;
	}

	public int Load(int UsrId)
	{
		int nRetVal = 0;

		try
		{
			Init();

			string SqlStr = string.Format("SELECT *, (SELECT UserGroupPermissions FROM tblUserGroups AS B " +
				"WHERE (B.UserGroupId = A.UserGroupId)) " +
				"AS Permissions FROM tblUsers AS A WHERE UserId = {0}", UsrId);
			DataSet oDs = Db.SqlQuery(SqlStr);

			if (Db.HasRecord(oDs) == true)
			{
				DataRow oDr = oDs.Tables[0].Rows[0];
				ClassEncrypt oEnc = new ClassEncrypt();

				this.m_UserId = (oDr["UserId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["UserId"]);
				this.m_TeamId = (oDr["TeamId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["TeamId"]);
				this.m_UserGroupId = (oDr["UserGroupId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["UserGroupId"]);
				this.m_UserName = (oDr["UserName"] == System.DBNull.Value) ? "" : oDr["UserName"].ToString();

				if (oDr["Password"] == System.DBNull.Value)
				{
					this.m_Password = "";
				}
				else
				{
					this.m_Password = oEnc.Decrypt(oDr["Password"].ToString());
				}

				this.m_Surname = (oDr["Surname"] == System.DBNull.Value) ? "" : oDr["Surname"].ToString();
				this.m_Forename = (oDr["Forename"] == System.DBNull.Value) ? "" : oDr["Forename"].ToString();
				this.m_EmailAddress = (oDr["EmailAddress"] == System.DBNull.Value) ? "" : oDr["EmailAddress"].ToString();
				this.m_HourlyRate = (oDr["HourlyRate"] == System.DBNull.Value) ? 0 : (float)Math.Round(Convert.ToDouble(oDr["HourlyRate"].ToString()), 2);
				this.m_Permissions = (oDr["Permissions"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["Permissions"]);

				nRetVal = this.m_UserId;
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			nRetVal = -1;
		}

		return nRetVal;
	}

	public int Save(int UsrId)
	{
		int nRetVal = 0;

		try
		{
			ClassEncrypt oEnc = new ClassEncrypt();

			nRetVal = Db.SaveUser(UsrId, this.m_TeamId, this.m_UserGroupId, this.m_UserName,
				oEnc.Encrypt(this.m_Password), this.m_Surname, this.m_Forename,
				this.m_EmailAddress, this.m_HourlyRate);

			nRetVal = Load(nRetVal);
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			nRetVal = -1;
		}

		return nRetVal;
	}

	public Int32 Logon(string UsrNam, string UsrPwd)
	{
		Int32 UserId = 0;
		ClassEncrypt oEnc = new ClassEncrypt();
		DataSet oDs;

		oDs = Db.SqlQuery(string.Format("SELECT UserId FROM tblUsers WHERE (UserName = '{0}') AND (Password = '{1}')", UsrNam, oEnc.Encrypt(UsrPwd)));

		if (Db.HasRecord(oDs) == true)
		{
			//	User has been found.

			UserId = Convert.ToInt32(oDs.Tables[0].Rows[0]["UserId"].ToString());
		}

		return UserId;
	}

	public void Delete(Int32 UserId)
	{
		Db.SqlAction(string.Format("DELETE FROM tblUsers WHERE UserId = {0}", UserId));
	}

	public DataSet ShowUsers()
	{
		return Db.SqlQuery("SELECT UserId, UserName, Surname, Forename FROM tblUsers ORDER BY UserName");
	}

	public DataSet ShowUsers1()
	{
		return Db.SqlQuery("SELECT UserId, (Surname + ', ' + Forename) AS UserName FROM tblUsers ORDER BY UserName");
	}

	public DataSet ShowUsers2(Int32 UsrId)
	{
		return Db.SqlQuery(string.Format("SELECT UserId, (Surname + ', ' + Forename) AS UserName FROM tblUsers WHERE UserId = {0}", UsrId));
	}

	public DataSet ShowUsersForTeam(Int32 TmId)
	{
		return Db.SqlQuery(string.Format("SELECT UserId, UserName FROM tblUsers WHERE TeamId = {0} ORDER BY UserName", TmId));
	}

	#region Properties
	public int UserId
	{
		get
		{
			return m_UserId;
		}
	}

	public int TeamId
	{
		get
		{
			return m_TeamId;
		}
		set
		{
			m_TeamId = value;
		}
	}

	public int UserGroupId
	{
		get
		{
			return m_UserGroupId;
		}
		set
		{
			m_UserGroupId = value;
		}
	}

	public string UserName
	{
		get
		{
			return m_UserName;
		}
		set
		{
			m_UserName = value;
		}
	}

	public string Password
	{
		get
		{
			return m_Password;
		}
		set
		{
			m_Password = value;
		}
	}

	public string Surname
	{
		get
		{
			return m_Surname;
		}
		set
		{
			m_Surname = value;
		}
	}

	public string Forename
	{
		get
		{
			return m_Forename;
		}
		set
		{
			m_Forename = value;
		}
	}

	public string EmailAddress
	{
		get
		{
			return m_EmailAddress;
		}
		set
		{
			m_EmailAddress = value;
		}
	}

	public int Permissions
	{
		get
		{
			return m_Permissions;
		}
	}

	public float HourlyRate
	{
		get
		{
			return m_HourlyRate;
		}
		set
		{
			m_HourlyRate = value;
		}
	}
	#endregion
}
