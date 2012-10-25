//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\ClassReport.cs $
//	$Revision: 1.5 $
//	---------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

	/// <summary>
	/// Report class.
	/// </summary>
public class ClassReport
{
	private const Int32 EVALUATION_DAYS = 30;

	public DataSet GetExport(Int32 ProjectId, Int32 UserId, DateTime StartDate, DateTime EndDate)
	{
		return Db.GetExport(ProjectId, UserId, StartDate, EndDate);
	}

	public DataSet GetCostCentre(DateTime StartDate, DateTime EndDate)
	{
		return Db.GetCostCentre(StartDate, EndDate);
	}

	public DataSet GetBudgetReport(Int32 ProjectId)
	{
		return Db.GetBudgetReport(ProjectId);
	}

	public DataSet GetProfitReport(Int32 TmId, Int32 UsrId, DateTime DateStart, DateTime DateEnd)
	{
		return Db.GetProfitReport(TmId, UsrId, DateStart, DateEnd);
	}

	public DataSet GetReportByReference(Int32 TmId, Int32 UsrId, DateTime DateStart, DateTime DateEnd)
	{
		return Db.GetReportByReference(TmId, UsrId, DateStart, DateEnd);
	}

	public DataSet GetReportByTask(Int32 TmId, Int32 UsrId, DateTime DateStart, DateTime DateEnd)
	{
		return Db.GetReportByTask(TmId, UsrId, DateStart, DateEnd);
	}

	public DataSet GetTimeSheet(Int32 UserId, DateTime DateStart, DateTime DateEnd)
	{
		return Db.GetTimeSheet(UserId, DateStart, DateEnd);
	}

	public DataSet GetTeamProductivity(Int32 TmId, Int32 UsrId, DateTime DateStart, DateTime DateEnd)
	{
		return Db.GetTeamProductivity(TmId, UsrId, DateStart, DateEnd);
	}
}
