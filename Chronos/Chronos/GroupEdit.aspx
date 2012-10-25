<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="GroupEdit.aspx.cs" Inherits="GroupEdit" Title="Untitled Page" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Group name:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:TextBox ID="TxtGroupName" runat="server" Width="200px">
				</asp:TextBox>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Administration rights:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:CheckBox ID="ChkAdmin" runat="server" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Project management:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:CheckBox ID="ChkProjects" runat="server" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Team management:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:CheckBox ID="ChkUsers" runat="server" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Reporting:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:CheckBox ID="ChkReports" runat="server" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Lock management:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:CheckBox ID="ChkLocks" runat="server" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Submit timesheet:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:CheckBox ID="ChkTimesheet" runat="server" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Job maintenance:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:CheckBox ID="ChkJobAdmin" runat="server" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Manager reports:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:CheckBox ID="ChkManager" runat="server" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Submit" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\GroupEdit.aspx $   $Revision: 1.2 $ -->
</asp:Content>
