//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\ClassStatus.cs $
//	$Revision: 1.2 $
//	---------------------------------------------------------------------------
using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Diagnostics;

	/// <summary>
	/// Summary description for ClassStatus
	/// </summary>
public class ClassStatus
{
	#region Declarations
	private Int32 m_StatusId;
	private string m_StatusText;
	private Int16 m_SortOrder;
	#endregion

	public ClassStatus()
	{
		Init();
	}

	public ClassStatus(Int32 StatId)
	{
		Load(StatId);
	}

	private void Init()
	{
		this.m_StatusId = 0;
		this.m_StatusText = "";
	}

	public Int32 Load(Int32 StatId)
	{
		Int32 RetVal = 0;

		try
		{
			Init();
			DataSet oDs = Db.SqlQuery(string.Format("SELECT * FROM tblStatus WHERE StatusId = {0}", StatId));

			if (Db.HasRecord(oDs) == true)
			{
				DataRow oDr = oDs.Tables[0].Rows[0];
				Int16 SortOrder = 0;

				this.m_StatusId = (oDr["StatusId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["StatusId"]);
				this.m_StatusText = (oDr["StatusText"] == System.DBNull.Value) ? "" : oDr["StatusText"].ToString();
				Int16.TryParse(oDr["SortOrder"].ToString(), out SortOrder);
				this.m_SortOrder = SortOrder;

				RetVal = this.StatusId;
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			RetVal = -1;
		}

		return RetVal;
	}

	public Int32 Save(Int32 StatId)
	{
		Int32 RetVal = 0;

		try
		{
			StringBuilder oStr = new StringBuilder("");

			if (StatId == 0)
			{
				oStr.Append("INSERT INTO tblStatus (StatusText, SortOrder) VALUES (");
				oStr.Append(Db.Quoted(this.m_StatusText));
				oStr.Append(string.Format(", {0}", this.m_SortOrder));
				oStr.Append(");\r\nSELECT SCOPE_IDENTITY()");

				this.m_StatusId = Db.SqlAction(oStr.ToString());
				RetVal = this.m_StatusId;
			}
			else
			{
				oStr.Append("UPDATE tblStatus SET ");
				oStr.Append(string.Format("StatusText = {0}", Db.Quoted(this.m_StatusText)));
				oStr.Append(string.Format(", SortOrder = {0}", this.m_SortOrder));
				oStr.Append(string.Format(" WHERE StatusId = {0}", StatId));

				Db.SqlAction(oStr.ToString());
				RetVal = Load(StatId);
			}

			SetSortOrder();
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			RetVal = -1;
		}

		return RetVal;
	}

	public void Delete(Int32 StatId)
	{
		Db.SqlAction(string.Format("DELETE FROM tblStatus WHERE StatusId = {0}", StatId));
	}

	private void SetSortOrder()
	{
		try
		{
			DataSet oDs;

			oDs = Db.SqlQuery("SELECT StatusId, SortOrder, StatusText FROM tblStatus ORDER BY SortOrder, StatusText");

			if (Db.HasRecord(oDs) == true)
			{
				Int16 SortOrder = 1;

				foreach (DataRow oDr in oDs.Tables[0].Rows)
				{
					Db.SqlAction(string.Format("UPDATE tblStatus SET SortOrder = {0} WHERE (StatusId = {1})", SortOrder, oDr["StatusId"].ToString()));
					SortOrder++;
				}
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}
	}

	public DataSet ShowStatus()
	{
		return Db.SqlQuery("SELECT StatusId, StatusText FROM tblStatus ORDER BY SortOrder");
	}

	#region Properties
	public Int32 StatusId
	{
		get
		{
			return m_StatusId;
		}
	}

	public string StatusText
	{
		get
		{
			return m_StatusText;
		}
		set
		{
			m_StatusText = value;
		}
	}

	public Int16 SortOrder
	{
		get
		{
			return m_SortOrder;
		}
		set
		{
			m_SortOrder = value;
		}
	}
	#endregion

}
