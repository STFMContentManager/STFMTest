using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

public class ClassAttribute
{
	#region Declarations
	private Int32 m_AttributeId;
	private string m_AttributeName;
	private string m_AttributeValue;
	#endregion

	public ClassAttribute()
	{
		Init();
	}

	public ClassAttribute(Int32 AttrId)
	{
		LoadById(AttrId);
	}

	public ClassAttribute(string AttrName)
	{
		LoadByName(AttrName);
	}

	private void Init()
	{
		this.m_AttributeId = 0;
		this.m_AttributeName = "";
		this.m_AttributeValue = "";
	}

	public Int32 LoadByName(string AttrName)
	{
		Int32 RetVal = 0;

		try
		{
			Init();

			DataSet oDs = Db.SqlQuery(string.Format("SELECT AttributeId FROM tblAttributes WHERE AttributeName = '{0}'", AttrName));

			if (Db.HasRecord(oDs) == true)
			{
				RetVal = LoadById(Convert.ToInt32(oDs.Tables[0].Rows[0]["AttributeId"].ToString()));
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			RetVal = -1;
		}

		return RetVal;
	}

	public Int32 LoadById(Int32 AttrId)
	{
		Int32 RetVal = 0;

		try
		{
			Init();

			DataSet oDs = Db.SqlQuery(string.Format("SELECT * FROM tblAttributes WHERE AttributeId = {0}", AttrId));

			if (Db.HasRecord(oDs) == true)
			{
				DataRow oDr = oDs.Tables[0].Rows[0];

				this.m_AttributeId = (oDr["AttributeId"] == System.DBNull.Value) ? 0 : Convert.ToInt32(oDr["AttributeId"].ToString());
				this.m_AttributeName = (oDr["AttributeName"] == System.DBNull.Value) ? "" : oDr["AttributeName"].ToString();
				this.m_AttributeValue = (oDr["AttributeValue"] == System.DBNull.Value) ? "" : oDr["AttributeValue"].ToString();

				RetVal = this.m_AttributeId;
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return RetVal;
	}

	public Int32 Save(Int32 AttrId)
	{
		Int32 RetVal = 0;

		try
		{
			StringBuilder oStr = new StringBuilder("");

			if (AttrId == 0)
			{
				oStr.Append("INSERT INTO tblAttributes (AttributeName, AttributeValue) VALUES (");
				oStr.Append(string.Format("'{0}', '{1}')\r\n", this.m_AttributeName, this.m_AttributeValue));
				oStr.Append("SELECT SCOPE_IDENTITY()");

				RetVal = LoadById(Db.SqlAction(oStr.ToString()));
			}
			else
			{
				oStr.Append("UPDATE tblAttributes SET ");
				oStr.Append(string.Format("AttributeName = '{0}'", this.m_AttributeName));
				oStr.Append(string.Format(", AttributeValue = '{0}'", this.m_AttributeValue));
				oStr.Append(string.Format(" WHERE AttributeId = {0}", AttrId));
				Db.SqlAction(oStr.ToString());

				RetVal = LoadById(AttrId);
			}
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
		}

		return RetVal;
	}

	public void DeleteById(Int32 AttrId)
	{
		Db.SqlAction(string.Format("DELETE FROM tblAttributes WHERE AttributeId = {0}", AttrId));
	}

	public void DeleteByName(string AttrName)
	{
		Db.SqlAction(string.Format("DELETE FROM tblAttributes WHERE AttributeName = '{0}'", AttrName));
	}

	#region Properties
	public Int32 AttributeId
	{
		get
		{
			return m_AttributeId;
		}
	}

	public string AttributeName
	{
		get
		{
			return m_AttributeName;
		}
		set
		{
			m_AttributeName = value;
		}
	}

	public string AttributeValue
	{
		get
		{
			return m_AttributeValue;
		}
		set
		{
			m_AttributeValue = value;
		}
	}
	#endregion
}
