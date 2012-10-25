//	---------------------------------------------------------------------------
//	$Filename: D:\Inetpub\wwwroot\TimeRep\Controls\DateSelector.ascx.cs $
//	$Revision: 1.8 $
//
//	Using this control:
//	Begin by registering the control in the page which is going to make use of
//	the control. The following definition needs to go at the top of the page,
//	immediately after the Page directive:
//
//		<%@ Register TagPrefix="kaz" TagName="DateSelector" Src="~/Controls/DateSelector.ascx" %>
//
//	Within the web page the control is implemented using the following:
//
//		<kaz:DateSelector runat="server" ID="cc2DateSelector" EnableViewState="true" />
//
//	The code behind page needs to create and manage two event procedures each
//	having the following signatures:
//
//		private void DateChanged(object sender, System.EventArgs e)
//		private void IntervalChanged(object sender, System.EventArgs e)
//
//	The Page_Load() event of the web page needs to set the event handlers to
//	point to these two event procedures. These event handlers should be
//	executed on every page load (not just on the first presentation), as the
//	event handlers are not sticky - they won't remember the address once the
//	page has rendered:
//
//		this.cc2DateSelector.DateChanged += new KazCustomControls.EventHandler(DateChanged);
//		this.cc2DateSelector.IntervalChanged += new KazCustomControls.EventHandler(IntervalChanged);
//
//	Once the above have been set up the methods and properties of this user
//	control will be available to the web page.
//	---------------------------------------------------------------------------
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace KazCustomControls
{
	public delegate void EventHandler(object sender, System.EventArgs e);

	public partial class DateSelector : UserControl
	{
		public event EventHandler DateChanged;
		public event EventHandler IntervalChanged;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Page.IsPostBack == false)
			{
				//	Default to current week view.

				this.RadWeek.Checked = true;
				SetDate(DateTime.Now);
			}
		}

		#region Public members
		public void SetDate(DateTime dt)
		{
			this.BtnDate.Text = dt.ToString("dddd d MMM yyyy");
			this.CalDateSel.SelectedDate = dt;
		}

		/// <summary>
		/// Returns the currently selected date from the date control.
		/// </summary>
		/// <returns>Date value</returns>
		public DateTime GetDate()
		{
			return this.CalDateSel.SelectedDate;
		}

		/// <summary>
		/// Defines the interval. D=day, W=week, M=month, Y=year.
		/// </summary>
		/// <param name="Interval">Interval</param>
		public void SetInterval(string Interval)
		{
			switch (Interval)
			{
				case "D":
					this.RadDay.Checked = true;
					break;

				case "W":
					this.RadWeek.Checked = true;
					break;

				case "M":
					this.RadMonth.Checked = true;
					break;

				default:
					this.RadYear.Checked = true;
					break;
			}
		}

		/// <summary>
		/// Returns the currently selected interval.
		/// </summary>
		/// <returns>D, W, M or Y</returns>
		public string GetInterval()
		{
			return GetCurrentInterval();
		}

		/// <summary>
		/// Returns the start date of the period relating to the
		/// currently selected date and the selected interval.
		/// </summary>
		/// <returns>Date value</returns>
		public DateTime StartDate()
		{
			DateTime RetVal = this.CalDateSel.SelectedDate;

			switch (GetInterval())
			{
				case "D":
					//	Return currently selected date.

					break;

				case "W":
					//	Return monday of current week.

					while (RetVal.DayOfWeek.ToString() != "Monday")
						RetVal = RetVal.AddDays(-1);
					break;

				case "M":
					//	Return 1st of the month.

					while (RetVal.Day.ToString() != "1")
						RetVal = RetVal.AddDays(-1);
					break;

				case "Y":
					//	Return 1st of the month.

					while (RetVal.Day.ToString() != "1")
						RetVal = RetVal.AddDays(-1);
					break;
			}

			return RetVal;
		}

		/// <summary>
		/// Returns the end date of the currently selected interval.
		/// </summary>
		/// <returns>Date value</returns>
		public DateTime EndDate()
		{
			DateTime DateStart = this.StartDate();
			DateTime RetVal = DateStart;

			switch (GetInterval())
			{
				case "D":
					//	Return currently selected date.

					break;

				case "W":
					//	Return sunday of current week.

					RetVal = DateStart.AddDays(6);
					break;

				case "M":
					//	Return last day of the month.

					RetVal = RetVal.AddMonths(1);
					RetVal = RetVal.AddDays(-1);
					break;

				case "Y":
					//	Return 1st of the month.

					RetVal = RetVal.AddYears(1);
					RetVal = RetVal.AddDays(-1);
					break;
			}

			return RetVal;
		}
		#endregion

		#region Private members
		private void DdcCalendar_SetDate(DateTime dt)
		{
			this.CalDateSel.SelectedDate = dt;
		}

		private string GetCurrentInterval()
		{
			if (this.RadDay.Checked == true)
				return "D";
			else if (this.RadWeek.Checked == true)
				return "W";
			else if (this.RadMonth.Checked == true)
				return "M";
			else
				return "Y";
		}
		#endregion

		#region Radiobutton events
		protected void RadDay_CheckChanged(object sender, EventArgs e)
		{
			this.RadDay.Checked = true;

			if (IntervalChanged != null)
				IntervalChanged(this, e);
		}

		protected void RadWeek_CheckChanged(object sender, EventArgs e)
		{
			this.RadWeek.Checked = true;

			if (IntervalChanged != null)
				IntervalChanged(this, e);
		}

		protected void RadMonth_CheckChanged(object sender, EventArgs e)
		{
			this.RadMonth.Checked = true;

			if (IntervalChanged != null)
				IntervalChanged(this, e);
		}

		protected void RadYear_CheckChanged(object sender, EventArgs e)
		{
			this.RadYear.Checked = true;

			if (IntervalChanged != null)
				IntervalChanged(this, e);
		}
		#endregion

		#region Protected members
		protected void CalDateSel_DateChanged(object sender, System.EventArgs e)
		{
			if (DateChanged != null)
				DateChanged(this, e);

			this.BtnDate.Text = this.CalDateSel.SelectedDate.ToString("dddd d MMM yyyy");
			this.CalDateSel.Visible = false;
		}

		protected void BtnToday_Click(object sender, System.EventArgs e)
		{
			SetDate(DateTime.Now);
			CalDateSel_DateChanged(sender, e);
		}

		protected void BtnPrev_Click(object sender, System.EventArgs e)
		{
			DateTime CurrDate = Convert.ToDateTime(this.BtnDate.Text);

			switch (GetCurrentInterval())
			{
				case "D":
					CurrDate = CurrDate.AddDays(-1);
					break;

				case "W":
					CurrDate = CurrDate.AddDays(-7);
					break;

				case "M":
					CurrDate = CurrDate.AddMonths(-1);
					break;

				default:
					CurrDate = CurrDate.AddYears(-1);
					break;
			}

			SetDate(CurrDate);
			SetDate(StartDate());
			CalDateSel_DateChanged(sender, e);
		}

		protected void BtnNext_Click(object sender, System.EventArgs e)
		{
			DateTime CurrDate = Convert.ToDateTime(this.BtnDate.Text);

			switch (GetCurrentInterval())
			{
				case "D":
					CurrDate = CurrDate.AddDays(1);
					break;

				case "W":
					CurrDate = CurrDate.AddDays(7);
					break;

				case "M":
					CurrDate = CurrDate.AddMonths(1);
					break;

				default:
					CurrDate = CurrDate.AddYears(1);
					break;
			}

			SetDate(CurrDate);
			SetDate(StartDate());
			CalDateSel_DateChanged(sender, e);
		}

		protected void BtnDate_Click(object sender, System.EventArgs e)
		{
			this.CalDateSel.SelectedDate = Convert.ToDateTime(this.BtnDate.Text);
			this.CalDateSel.VisibleDate = this.CalDateSel.SelectedDate;
			this.CalDateSel.Visible = true;
		}
		#endregion
	}
}
