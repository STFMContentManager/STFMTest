<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="GroupMenu.aspx.cs" Inherits="GroupMenu" Title="Untitled Page" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Table ID="Table1" runat="server">
					<asp:TableRow>
						<asp:TableCell ColumnSpan="5" CssClass="FormCenter">
							<asp:DropDownList ID="DdlGroups" runat="server" Width="300px">
							</asp:DropDownList>
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell CssClass="FormCenter">
							<asp:Button ID="BtnAddGroup" runat="server" OnClick="BtnAddGroup_Click" Text="Add" CssClass="Button" Width="80px" />
						</asp:TableCell>
						<asp:TableCell>&nbsp;</asp:TableCell>
						<asp:TableCell CssClass="FormCenter">
							<asp:Button ID="BtnEditGroup" runat="server" OnClick="BtnEditGroup_Click" Text="Edit" CssClass="Button" Width="80px" />
						</asp:TableCell>
						<asp:TableCell>&nbsp;</asp:TableCell>
						<asp:TableCell CssClass="FormCenter">
							<asp:Button ID="BtnDeleteGroup" runat="server" OnClick="BtnDeleteGroup_Click" CssClass="Button" Text="Delete" Width="80px" />
						</asp:TableCell>
					</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">
				<asp:Button ID="BtnAdminMenu" runat="server" OnClick="BtnAdminMenu_Click" Text="Return To Admin Menu" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\GroupMenu.aspx $   $Revision: 1.1 $ -->
</asp:Content>
