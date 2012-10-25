<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="UserMenu.aspx.cs" Inherits="UserMenu" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				<asp:Table runat="server">
					<asp:TableRow>
						<asp:TableCell CssClass="FormCenter" ColumnSpan="5">
							<asp:DropDownList ID="DdlUsers" runat="server" Width="300px" />
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell CssClass="FormCenter">
							<asp:Button runat="server" ID="BtnAddUser" Text="Add" CssClass="Button" Width="80px" OnClick="BtnAddUser_Click" />
						</asp:TableCell>
						<asp:TableCell>&nbsp;</asp:TableCell>
						<asp:TableCell CssClass="FormCenter">
							<asp:Button ID="BtnEditUser" runat="server" Text="Edit" CssClass="Button" Width="80px" OnClick="BtnEditUser_Click" />
						</asp:TableCell>
						<asp:TableCell>&nbsp;</asp:TableCell>
						<asp:TableCell CssClass="FormCenter">
							<asp:Button ID="BtnDeleteUser" runat="server" Text="Delete" CssClass="Button" Width="80px" OnClick="BtnDeleteUser_Click" />
						</asp:TableCell>
					</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">
				<asp:Button ID="BtnAdminMenu" runat="server" Text="Return To Admin Menu" OnClick="BtnAdminMenu_Click" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\UserMenu.aspx $   $Revision: 1.1 $ -->
</asp:Content>
