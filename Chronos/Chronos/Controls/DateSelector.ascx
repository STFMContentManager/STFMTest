<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="true" CodeFile="~/Controls/DateSelector.ascx.cs" Inherits="KazCustomControls.DateSelector" %>
<asp:Table ID="Table1" runat="server">
<asp:TableRow>
	<asp:TableCell CssClass="HeaderCenter" Width="50%">
		<b>Date</b>
	</asp:TableCell>
	<asp:TableCell CssClass="HeaderCenter" Width="50%">
		<b>Interval</b>
	</asp:TableCell>
</asp:TableRow>
<asp:TableRow ID="RowDateSel">
	<asp:TableCell CssClass="FormCenter" Width="50%" VerticalAlign="top">
		<asp:Table ID="Table2" runat="server">
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter">
				<asp:Table ID="Table3" runat="server">
				<asp:TableRow>
					<asp:TableCell CssClass="FormCenter">
						<asp:Button runat="server" ID="BtnDate" Width="200px" OnClick="BtnDate_Click" />
						<asp:Button runat="server" ID="BtnNext" Width="20px" Text="<" OnClick="BtnPrev_Click" />
						<asp:Button runat="server" ID="BtnPrev" Width="20px" Text=">" OnClick="BtnNext_Click" />
						<asp:Button runat="server" ID="BtnToday" Text="Today" OnClick="BtnToday_Click" />
						<asp:calendar
							id="CalDateSel"
							runat="server"
							backcolor="white"
							width="250px"
							height="200px"
							font-size="12px"
							font-names="Arial"
							borderwidth="2px"
							bordercolor="black"
							nextprevformat="shortmonth"
							daynameformat="firsttwoletters"
							Visible="False"
							FirstDayOfWeek="Monday"
							SelectionMode="Day"
							ShowGridLines="true"
							ShowNextPrevMonth="true"
							ShowTitle="true"
							ToolTip="Choose Date"
							onselectionchanged="CalDateSel_DateChanged"
							CssClass="Calender"
							DayHeaderStyle-CssClass="DayHeaderStyle"
							DayStyle-CssClass="DayStyle"
							NextPrevStyle-CssClass="NextPrevStyle"
							OtherMonthDayStyle-CssClass="OtherMonthDayStyle"
							SelectedDayStyle-CssClass="SelectedDayStyle"
							TitleStyle-CssClass="TitleStyle"
							TodayDayStyle-CssClass="TodayDayStyle"
							WeekendDayStyle-CssClass="WeekendDayStyle"
						/>
					</asp:TableCell>
				</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		</asp:Table>
	</asp:TableCell>
	<asp:TableCell CssClass="FormCenter" Width="50%" VerticalAlign="top">
		<asp:Table ID="Table4" runat="server">
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" Width="80px">
				<asp:RadioButton GroupName="GrpTime" ID="RadDay" runat="server" Text="Day" Width="80px" AutoPostBack="true" OnCheckedChanged="RadDay_CheckChanged" />
			</asp:TableCell>
			<asp:TableCell CssClass="FormCenter" Width="80px">
				<asp:RadioButton GroupName="GrpTime" ID="RadWeek" runat="server" Text="Week" Checked="true" Width="80px" AutoPostBack="true" OnCheckedChanged="RadWeek_CheckChanged" />
			</asp:TableCell>
			<asp:TableCell CssClass="FormCenter" Width="80px">
				<asp:RadioButton GroupName="GrpTime" ID="RadMonth" runat="server" Text="Month" Width="80px" AutoPostBack="true" OnCheckedChanged="RadMonth_CheckChanged" />
			</asp:TableCell>
			<asp:TableCell CssClass="FormCenter" Width="80px">
				<asp:RadioButton GroupName="GrpTime" ID="RadYear" runat="server" Text="Year" Width="80px" AutoPostBack="true" OnCheckedChanged="RadYear_CheckChanged" />
			</asp:TableCell>
		</asp:TableRow>
		</asp:Table>
	</asp:TableCell>
</asp:TableRow>
</asp:Table>
