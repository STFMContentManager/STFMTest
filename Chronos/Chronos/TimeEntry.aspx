<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="TimeEntry.aspx.cs" Inherits="TimeEntry" Title="Untitled Page" %>
<%@ Register TagPrefix="kaz" TagName="DateSelector" Src="~/Controls/DateSelector.ascx" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Label runat="server" ID="LblTimeId" Text="LblTimeId" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow ID="RowAdmin1" Visible="false"><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow ID="RowAdmin2" Visible="false">
			<asp:TableCell ColumnSpan="2" CssClass="Warning">
				<b>Administrator - Submitting Timesheet Is Disabled!</b>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="DateSelection">
				<kaz:DateSelector runat="server" ID="cc2DateSelector" EnableViewState="true" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableHeaderCell ColumnSpan="2" CssClass="Header">
				Time Definition
			</asp:TableHeaderCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="TimeEntry" ColumnSpan="2" Width="777px">
				<asp:Table ID="Table3" runat="server">
                <asp:TableRow>
					<asp:TableCell CssClass="HeaderCenter" ColumnSpan="4">
						<b>Project</b>
					</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
					<asp:TableCell CssClass="FormCenter" ColumnSpan="4">
       <asp:DropDownList ID="ddlProjects" runat="server" />
					</asp:TableCell>
                </asp:TableRow>
				<asp:TableRow>
					<asp:TableCell CssClass="HeaderCenter">
						<b>Time In</b>
					</asp:TableCell>
					<asp:TableCell CssClass="HeaderCenter">
						<b>Time Out</b>
					</asp:TableCell>
					<asp:TableCell CssClass="HeaderCenter">
						<b>Lunch</b>
					</asp:TableCell>
					<asp:TableCell CssClass="HeaderCenter">
						<b>Hours</b>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell CssClass="FormCenter">
       <asp:DropDownList ID="ddlTimeInHours" AutoPostBack="true" OnSelectedIndexChanged="CalculateTime" runat="server">
        <asp:ListItem Selected="True" Text="9" />
        <asp:ListItem Text="10" />
        <asp:ListItem Text="11" />
        <asp:ListItem Text="12" />
        <asp:ListItem Text="1" />
        <asp:ListItem Text="2" />
        <asp:ListItem Text="3" />
        <asp:ListItem Text="4" />
        <asp:ListItem Text="5" />
        <asp:ListItem Text="6" />
        <asp:ListItem Text="7" />
        <asp:ListItem Text="8" />
       </asp:DropDownList>
       <asp:DropDownList ID="ddlTimeInMinutes" AutoPostBack="true" OnSelectedIndexChanged="CalculateTime" runat="server">
        <asp:ListItem Value="0" Text="00" />
        <asp:ListItem Value="25" Text="15" />
        <asp:ListItem Value="50" Text="30" />
        <asp:ListItem Value="75" Text="45" />
       </asp:DropDownList>
       <asp:DropDownList ID="ddlTimeInAMPM" AutoPostBack="true" OnSelectedIndexChanged="CalculateTime" runat="server">
        <asp:ListItem Value="AM" Text="A.M." />
        <asp:ListItem Value="PM" Text="P.M." />
       </asp:DropDownList>
					</asp:TableCell>
					<asp:TableCell CssClass="FormCenter">
       <asp:DropDownList ID="ddlTimeOutHours" AutoPostBack="true" OnSelectedIndexChanged="CalculateTime" runat="server">
        <asp:ListItem Selected="True" Text="5" />
        <asp:ListItem Text="6" />
        <asp:ListItem Text="7" />
        <asp:ListItem Text="8" />
        <asp:ListItem Text="9" />
        <asp:ListItem Text="10" />
        <asp:ListItem Text="11" />
        <asp:ListItem Text="12" />
        <asp:ListItem Text="1" />
        <asp:ListItem Text="2" />
        <asp:ListItem Text="3" />
        <asp:ListItem Text="4" />
       </asp:DropDownList>
       <asp:DropDownList ID="ddlTimeOutMinutes" AutoPostBack="true" OnSelectedIndexChanged="CalculateTime" runat="server">
        <asp:ListItem Value="0" Text="00" />
        <asp:ListItem Value="25" Text="15" />
        <asp:ListItem Value="50" Text="30" />
        <asp:ListItem Value="75" Text="45" />
       </asp:DropDownList>
       <asp:DropDownList ID="ddlTimeOutAMPM" AutoPostBack="true" OnSelectedIndexChanged="CalculateTime" runat="server">
        <asp:ListItem Value="PM" Text="P.M." />
        <asp:ListItem Value="AM" Text="A.M." />
       </asp:DropDownList>
					</asp:TableCell>
                    <asp:TableCell>
       <asp:DropDownList ID="ddlLunchHours" AutoPostBack="true" OnSelectedIndexChanged="CalculateLunchTime" runat="server">
        <asp:ListItem Text="0" Selected="True" />
        <asp:ListItem Text="1" />
       </asp:DropDownList>
       <asp:DropDownList ID="ddlLunchMinutes" AutoPostBack="true" OnSelectedIndexChanged="CalculateLunchTime" runat="server">
        <asp:ListItem Value="0" Text="00" />
        <asp:ListItem Value="25" Text="15" />
        <asp:ListItem Value="50" Text="30" />
        <asp:ListItem Value="75" Text="45" />
       </asp:DropDownList>
                    </asp:TableCell>
					<asp:TableCell CssClass="FormCenter">
						<asp:TextBox runat="server" ID="txtTotalHours" Enabled="false" Width="50px" Text="8" />
					</asp:TableCell>
                </asp:TableRow>
				<asp:TableRow ID="RowTimeError" Visible="false">
					<asp:TableCell CssClass="FormCenter" ColumnSpan="7">
						<asp:Label runat="server" ID="LblTimeError" Text="LblTimeError" CssClass="ErrorMsg" Width="100%" />
					</asp:TableCell>
				</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
                <asp:TableRow>
					<asp:TableCell>
						<asp:Button runat="server" ID="BtnSubmit" Text="Submit" OnClick="BtnSubmit_Click" CssClass="Button" Width="80px" />&nbsp;&nbsp;
						<asp:Button runat="server" ID="BtnNew" Text="New" OnClick="BtnNew_Click" CssClass="Button"  Width="50px" />
					</asp:TableCell>
				</asp:TableRow>
		<asp:TableRow><asp:TableCell CssClass="FormCenter">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableHeaderCell ColumnSpan="2" CssClass="Header">
				Time Bookings (<asp:Label runat="server" ID="LblFrom" Text="LblFrom" /> - <asp:Label runat="server" ID="LblTo" Text="LblTo" />)
			</asp:TableHeaderCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2" BackColor="lightblue" BorderColor="black" BorderStyle="solid" BorderWidth="1" Width="777px">
				<asp:GridView
					ID="GridTime"
					runat="server"
					AlternatingRowStyle-BackColor="DarkCyan"
					AutoGenerateColumns="false"
					GridLines="None"
					CellPadding="0"
					CellSpacing="1"
					OnRowCommand="GridTime_RowCommand"
					OnRowDataBound="GridTime_RowDataBound"
					OnRowDeleting="GridTime_RowDeleting"
					OnRowDeleted="GridTime_RowDeleted"
					OnRowEditing="GridTime_RowEditing"
					DataKeyNames="TimeId"
					ShowFooter="true"
					AllowPaging="true"
					PagerSettings-Mode="NumericFirstLast"
					PageSize="10"
					OnPageIndexChanging="GridTime_PageIndexChanging"
				>
				<Columns>
					<asp:TemplateField
						HeaderText="Edit"
						HeaderStyle-CssClass="HeaderCenter"
						FooterStyle-CssClass="HeaderLeft"
					>
						<ItemStyle Width="20px" HorizontalAlign="center" />
						<ItemTemplate>
							<asp:ImageButton
								ID="ImgEdit"
								runat="server"
								ImageUrl="~/Images/Edit.gif"
								CommandArgument='<%# Eval("TimeId").ToString() %>'
								CommandName="Edit"
								ToolTip='<%# "Edit #" + Eval("TimeId").ToString() %>'
							/>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField
						HeaderStyle-CssClass="HeaderRight"
						FooterStyle-CssClass="HeaderRight"
						HeaderText="#"
						ItemStyle-Width="15px"
						ItemStyle-HorizontalAlign="right"
						HeaderStyle-HorizontalAlign="right"
					>
						<ItemTemplate>
							<asp:Label ID="LblDayNo" runat="server" Text='<%# Eval("DayNo") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						FooterStyle-CssClass="HeaderLeft"
						HeaderText="Day"
						DataField="DayName"
						ReadOnly="true"
						ItemStyle-Width="25px"
						ItemStyle-HorizontalAlign="left"
					/>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						FooterStyle-CssClass="HeaderLeft"
						HeaderText="Project"
						DataField="ProjectId"
						ReadOnly="true"
						ItemStyle-Width="125px"
						ItemStyle-HorizontalAlign="left"
					/>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						FooterStyle-CssClass="HeaderLeft"
						HeaderText="Status"
						DataField="StatusId"
						ReadOnly="true"
						ItemStyle-Width="125px"
						ItemStyle-HorizontalAlign="left"
					/>
					<asp:TemplateField
						HeaderStyle-CssClass="HeaderRight"
						FooterStyle-CssClass="HeaderRight"
						HeaderText="Hours"
						ItemStyle-Width="50px"
						ItemStyle-HorizontalAlign="right"
						FooterStyle-HorizontalAlign="right"
						FooterStyle-Font-Bold="true"
					>
						<ItemTemplate>
							<asp:Label ID="LblHours" runat="server" Text='<%# ShowHours(Eval("Hours").ToString()) %>' />
						</ItemTemplate>
						<FooterTemplate>
							<%# GetTotal().ToString("N2") %>
						</FooterTemplate>
					</asp:TemplateField>
					<asp:TemplateField
						HeaderStyle-CssClass="HeaderCenter"
						HeaderText="Del"
						FooterStyle-CssClass="HeaderCenter"
					>
						<ItemStyle Width="20px" HorizontalAlign="center" />
						<ItemTemplate>
							<asp:ImageButton
								ID="ImgTrash"
								runat="server"
								ImageUrl="~/Images/Trash.gif"
								CommandArgument='<%# Eval("TimeId") %>'
								CommandName="Delete"
								ToolTip='<%# "Delete #" + Eval("TimeId").ToString() %>'
							/>
						</ItemTemplate>
						<FooterTemplate>
							&nbsp;
						</FooterTemplate>
					</asp:TemplateField>
				</Columns>
				</asp:GridView>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormLeft">
				<asp:Table ID="Table2" runat="server" Visible="false" Width="777px">
				<asp:TableRow>
					<asp:TableCell CssClass="FormRight" Width="50%">
						<asp:ImageButton ID="BtnIncrease" runat="server" ImageUrl="~/Images/RedPlus.gif" BorderColor="black" BorderStyle="solid" BorderWidth="1" OnClick="BtnIncrease_Click" />
					</asp:TableCell>
					<asp:TableCell CssClass="FormLeft" Width="50%">
						<asp:ImageButton ID="BtnDecrease" runat="server" ImageUrl="~/Images/BlueMinus.gif" BorderColor="black" BorderStyle="solid" BorderWidth="1" OnClick="BtnDecrease_Click" />
					</asp:TableCell>
				</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow ID="RowJob1" Visible="false"><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow ID="RowJob2" Visible="false">
			<asp:TableCell ColumnSpan="2">
				<asp:Button ID="BtnJobs" runat="server" OnClick="BtnJobs_Click" Text="Job Maintenance"	CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">
				<asp:Button ID="BtnMainMenu" runat="server" OnClick="BtnMainMenu_Click" Text="Return To Main Menu"	CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\TimeEntry.aspx $   $Revision: 1.5 $ -->
</asp:Content>
