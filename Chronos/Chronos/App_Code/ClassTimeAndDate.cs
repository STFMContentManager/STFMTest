//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\Tm.cs $
//	$Revision: 1.1 $
//	---------------------------------------------------------------------------
using System;
using System.Data;
using System.Configuration;
using System.Text;

	/// <summary>
	/// Summary description for Tm
	/// </summary>
public class ClassTimeAndDate
{
	//	This class provides shared methods for time & date functions.

	public static string HhMmSs(DateTime dt)
	{
		string RetVal = string.Format("{0:HH}{0:mm}{0:ss}", dt);

		return RetVal;
	}

	public static string ShowShortDate(DateTime dt)
	{
		string RetVal = string.Format("{0:dd} {0:MMM} {0:yy}", dt);

		return RetVal;
	}

	public static string DayNameFromDayNumber(Int32 DayOfWeek)
	{
		return DayNameFromDayNumber(DayOfWeek, true);
	}

	public static string DayNameFromDayNumber(Int32 DayOfWeek, Boolean bShort)
	{
		DateTime dt = DateTime.Today;

		while (dt.DayOfWeek.ToString() != "Sunday")
			dt = dt.AddDays(-1);

		return DayNameFromDate(dt.AddDays(DayOfWeek - 1), bShort);
	}

	public static string DayNameFromDate(DateTime dt, Boolean bShort)
	{
		if (bShort)
		{
			//	Return a short day name.

			return dt.DayOfWeek.ToString().Substring(0, 3);
		}
		else
		{
			//	Return full day name.

			return dt.DayOfWeek.ToString();
		}
	}

	public static string MonthNameFromNumber(Int32 MonthNo)
	{
		return MonthNameFromNumber(MonthNo, true);
	}

	public static string MonthNameFromNumber(Int32 MonthNo, Boolean bShort)
	{
		DateTime dt = DateTime.Parse("1 Jan 2000");

		while (MonthNo > 1)
		{
			dt = dt.AddMonths(1);
			MonthNo--;
		}

		if (bShort)
			return dt.ToString("MMMM").Substring(1, 3);
		else
			return dt.ToString("MMMM");
	}

	public static DateTime FirstDayOfMonth(DateTime dt)
	{
		while (dt.Day > 1)
			dt = dt.AddDays(-1);

		return dt;
	}

	public static DateTime LastDayOfMonth(DateTime dt)
	{
		Int32 MonthNo = dt.Month;

		while (dt.Month == MonthNo)
			dt = dt.AddDays(1);

		dt = dt.AddDays(-1);
		return dt;
	}

	public static DateTime FirstDayOfWeek(DateTime dt)
	{
		while (dt.DayOfWeek.ToString() != "Monday")
			dt = dt.AddDays(-1);

		return dt;
	}

	public static DateTime LastDayOfWeek(DateTime dt)
	{
		while (dt.DayOfWeek.ToString() != "Sunday")
			dt = dt.AddDays(1);

		return dt;
	}

	public static string DateToString(DateTime dt)
	{
		StringBuilder oStr = new StringBuilder("");

		oStr.Append(dt.Day.ToString());
		oStr.Append(string.Format(" {0}", MonthNameFromNumber(dt.Month, false)));
		oStr.Append(string.Format(" {0}", dt.Year.ToString()));

		return oStr.ToString();
	}
}
