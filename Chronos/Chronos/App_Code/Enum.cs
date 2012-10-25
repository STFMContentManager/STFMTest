//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\Enum.cs $
//	$Revision: 1.3 $
//	---------------------------------------------------------------------------
using System;
using System.Data;
using System.Configuration;

	/// <summary>
	/// Summary description for Enum
	/// </summary>
public class Enum
{
	public enum Permissions : int
	{
		Administration = 0x01,
		Project = 0x02,
		Team = 0x04,
		Report = 0x08,
		Lock = 0x10,
		Timesheet = 0x20,
		JobMaintenance = 0x40,
		ManagerOnly = 0x80
	}

	public enum ValidationType : int
	{
		NoValidation = 0x01,
		JobMustPreExist = 0x02,
		UseRegularExpression = 0x04,
		UseDropDownListBox = 0x08
	}
}
