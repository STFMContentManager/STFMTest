<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="AdminMenu.aspx.cs" Inherits="AdminMenu" Title="Untitled Page" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" Width="50%">
				<asp:Button runat="server" ID="BtnGroups" Text="User Group Admin" CssClass="Button" OnClick="BtnGroupAdmin_Click" />
			</asp:TableCell>
			<asp:TableCell CssClass="FormCenter">
				<asp:Button runat="server" ID="BtnStatus" Text="Status Admin" CssClass="Button" OnClick="BtnStatusAdmin_Click" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter">
				<asp:Button runat="server" ID="BtnTeams" Text="Team Admin" CssClass="Button" OnClick="BtnTeamAdmin_Click" />
			</asp:TableCell>
			<asp:TableCell CssClass="FormCenter" Width="50%">
				<asp:Button runat="server" ID="BtnJobs" Text="Job Maintenance" CssClass="Button" OnClick="BtnJobs_Click" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter">
				<asp:Button runat="server" ID="BtnProjectAdmin" Text="Project Admin" CssClass="Button" OnClick="BtnProjectAdmin_Click" />
			</asp:TableCell>
			<asp:TableCell CssClass="FormCenter">
				<asp:Button runat="server" ID="BtnAdminLock" Text="Lock Timesheets" CssClass="Button" OnClick="BtnAdminLock_Click" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter">
				<asp:Button runat="server" ID="BtnUser" Text="User Admin" CssClass="Button" OnClick="BtnUserAdmin_Click" />
			</asp:TableCell>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnMainMenu" runat="server" OnClick="BtnMainMenu_Click" CssClass="Button" Text="Return To Main Menu" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\AdminMenu.aspx $   $Revision: 1.4 $ -->
</asp:Content>
