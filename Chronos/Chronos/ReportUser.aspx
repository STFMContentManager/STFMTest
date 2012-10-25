<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="ReportUser.aspx.cs" Inherits="ReportUser" Title="Untitled Page" %>
<%@ Register TagPrefix="kaz" TagName="DateSelector" Src="~/Controls/DateSelector.ascx" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
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
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				<asp:Table runat="server">
				<asp:TableRow>
					<asp:TableHeaderCell CssClass="HeaderCenter">
						User
					</asp:TableHeaderCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell CssClass="FormCenter">
						<asp:DropDownList runat="server" ID="DdlUsers" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="DdlUsers_SelectedIndexChanged" />
					</asp:TableCell>
				</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Report from:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<b><asp:Label runat="server" ID="LblFrom" Text="LblFrom" /></b>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Report to:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<b><asp:Label runat="server" ID="LblTo" Text="LblTo" /></b>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				<asp:GridView
					ID="GridTime"
					runat="server"
					AlternatingRowStyle-BackColor="Beige"
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
				>
				<Columns>
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
						HeaderText="Weekday"
						DataField="DayName"
						ReadOnly="true"
						ItemStyle-Width="25px"
						ItemStyle-HorizontalAlign="left"
					/>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						FooterStyle-CssClass="HeaderLeft"
						HeaderText="Project"
						DataField="ProjectName"
						ReadOnly="true"
						ItemStyle-Width="125px"
						ItemStyle-HorizontalAlign="left"
					/>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						FooterStyle-CssClass="HeaderLeft"
						HeaderText="Task"
						DataField="TaskName"
						ReadOnly="true"
						ItemStyle-Width="125px"
						ItemStyle-HorizontalAlign="left"
					/>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						FooterStyle-CssClass="HeaderLeft"
						HeaderText="Status"
						DataField="StatusText"
						ReadOnly="true"
						ItemStyle-Width="125px"
						ItemStyle-HorizontalAlign="left"
					/>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						FooterStyle-CssClass="HeaderLeft"
						HeaderText="Comment"
						DataField="Comment"
						ReadOnly="true"
						ItemStyle-Width="150px"
						ItemStyle-HorizontalAlign="left"
						FooterStyle-Font-Bold="true"
					/>
					<asp:BoundField
						HeaderStyle-CssClass="HeaderLeft"
						FooterStyle-CssClass="HeaderLeft"
						HeaderText="Ref"
						DataField="JobRef"
						ReadOnly="true"
						ItemStyle-Width="70px"
						ItemStyle-HorizontalAlign="left"
						FooterStyle-Font-Bold="true"
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
				</Columns>
				</asp:GridView>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow ID="RowError1" Visible="false"><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow ID="RowError2" Visible="false">
			<asp:TableCell CssClass="ErrorMsg" ColumnSpan="2">
				<asp:Label runat="server" ID="LblMsg" Text="LblMsg" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnExcel" runat="server" OnClick="BtnExcel_Click" Text="Export To Microsoft Excel" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnCSV" runat="server" OnClick="BtnCSV_Click" Text="Export To CSV" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnReportMenu" runat="server" OnClick="BtnReportMenu_Click" Text="Return To Report Menu" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\ReportUser.aspx $   $Revision: 1.2 $ -->
</asp:Content>