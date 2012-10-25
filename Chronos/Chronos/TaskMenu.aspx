<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="TaskMenu.aspx.cs" Inherits="TaskMenu" Title="Untitled Page" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Project:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<b><asp:Label ID="LblProject" runat="server" Text="LblProject" /></b>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Table ID="Table1" runat="server">
					<asp:TableRow>
						<asp:TableCell ColumnSpan="5" CssClass="FormCenter">
							<asp:DropDownList ID="DdlTasks" runat="server" Width="300px">
							</asp:DropDownList>
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell CssClass="FormCenter">
							<asp:Button ID="BtnAddTask" runat="server" OnClick="BtnAddTask_Click" Text="Add" CssClass="Button" Width="80px" />
						</asp:TableCell>
						<asp:TableCell>&nbsp;</asp:TableCell>
						<asp:TableCell CssClass="FormCenter">
							<asp:Button ID="BtnEditTask" runat="server" OnClick="BtnEditTask_Click" Text="Edit" CssClass="Button" Width="80px" />
						</asp:TableCell>
						<asp:TableCell>&nbsp;</asp:TableCell>
						<asp:TableCell CssClass="FormCenter">
							<asp:Button ID="BtnDeleteTask" runat="server" OnClick="BtnDeleteTask_Click" CssClass="Button" Text="Delete" Width="80px" />
						</asp:TableCell>
					</asp:TableRow>
				</asp:Table>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">
				<asp:Button ID="BtnProjectEdit" runat="server" OnClick="BtnProjectEdit_Click" Text="Return To Project" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\TaskMenu.aspx $   $Revision: 1.2 $ -->
</asp:Content>
