//	---------------------------------------------------------------------------
//	$Filename: D:\Inetpub\wwwroot\TimeRep\App_Code\Util.cs $
//	$Revision: 1.3 $
//	---------------------------------------------------------------------------
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Util
/// </summary>
public class Util
{
	public static string VersionNo()
	{
		return "1.0.1";
	}

	#region Web.Config
	public static string ReadString(string KeyName, string DefStr)
	{
		try
		{
			object setting = System.Configuration.ConfigurationManager.AppSettings[KeyName];

			if (setting != null)
			{
				if (setting.ToString() == "")
					setting = null;
			}

			return (setting == null) ? DefStr : (string)setting;
		}

		catch
		{
			return DefStr;
		}
	}

	public static long ReadLong(string KeyName, long DefVal)
	{
		try
		{
			return long.Parse(ReadString(KeyName, DefVal.ToString()));
		}

		catch
		{
			return DefVal;
		}
	}
	#endregion

	#region Attributes
	public static string AttributeLoad(string AttributeName, string DefaultValue)
	{
		string RetVal = DefaultValue;

		ClassAttribute oAttr = new ClassAttribute(AttributeName);

		if (oAttr.AttributeId != 0)
			RetVal = oAttr.AttributeValue;

		return RetVal;
	}

	public static void AttributeSave(string AttributeName, string AttributeValue)
	{
		ClassAttribute oAttr = new ClassAttribute(AttributeName);

		oAttr.DeleteByName(AttributeName);
		oAttr.AttributeName = AttributeName;
		oAttr.AttributeValue = AttributeValue;
		oAttr.Save(0);
	}

	public static void AttributeDelete(string AttributeName)
	{
		ClassAttribute oAttr = new ClassAttribute(AttributeName);

		oAttr.DeleteByName(AttributeName);
	}
	#endregion
}
