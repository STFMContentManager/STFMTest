//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\Log.cs $
//	$Revision: 1.1 $
//	---------------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Text;
using System.Reflection;

	/// <summary>
	/// Summary description for Log
	/// </summary>
public class Log
{
	private static void LogMsg(string Msg, Int32 Stacks2Jump)
	{
		if (Stacks2Jump > 0)
		{
			//	If we need to show who called us it is necessary to jump
			//	over a couple of stack frames to get the information
			//	we require.

			StackTrace st = new StackTrace(true);
			StackFrame sf = st.GetFrame(Stacks2Jump);
			MethodBase method = sf.GetMethod();
			string Caller = string.Format("{0} {1} (line {2})",
				sf.GetFileName().Substring(sf.GetFileName().LastIndexOf("\\") + 1),
				sf.GetMethod().Name,
				sf.GetFileLineNumber());

			Debug.WriteLine(string.Format("{0}: {1}", ClassTimeAndDate.HhMmSs(DateTime.Now), Caller));
		}

		Debug.WriteLine(string.Format("{0}: {1}", ClassTimeAndDate.HhMmSs(DateTime.Now), Msg));
	}

	public static void LogMsg(string Msg)
	{
		//	Show the calling function.

		LogMsg(Msg, 2);
	}

	public static void LogMsg(string Msg, Boolean bShowCaller)
	{
		//	Showing the calling function depends upon bShowCaller.

		LogMsg(Msg, (bShowCaller == true) ? 2 : 0);
	}

	public static void CallStack()
	{
		//	This method reports the callstack (not including the current class).

		StackTrace st = new StackTrace(true);
		Int32 StackCount = st.FrameCount;

		for (Int32 StackNo = 2; StackNo < StackCount; StackNo++)
		{
			StackFrame sf = st.GetFrame(StackNo);
			string Caller = string.Format("{0} (line {1})",
				sf.GetMethod().DeclaringType.FullName,
				sf.GetFileLineNumber());

			Debug.WriteLine(string.Format("{0}: {1}", ClassTimeAndDate.HhMmSs(DateTime.Now), Caller));
		}
	}
}
