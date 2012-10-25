<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="UserAdmin.aspx.cs" Inherits="UserAdmin" Title="Untitled Page" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Table ID="MainPage" runat="server" Width="777px">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="PageHeader">
				<asp:Label ID="LblPageTitle" runat="server" Text="LblPageTitle"></asp:Label>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Surname:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:TextBox runat="server" ID="TxtSurname" Width="200px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Forename:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtForename" Width="200px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Email address:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtEmail" Width="200px" TextMode="SingleLine" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<b>OPTIONAL</b>: You can reset your password by completing the information requested<br />
				below. If you leave these fields blank your existing password will remain unchanged.
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				Existing password:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtOld" Width="200px" TextMode="Password" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				New password:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtNew1" Width="200px" TextMode="Password" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				New password again:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtNew2" Width="200px" TextMode="Password" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow runat="server" ID="RowMsg1" Visible="false"><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow runat="server" ID="RowMsg2" Visible="false">
			<asp:TableCell CssClass="ErrorMsg" ColumnSpan="2">
				<asp:Label ID="LblMsg" runat="server" Text="LblMsg" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow runat="server" ID="TableRow1">
			<asp:TableCell CssClass="FormCenter" ColumnSpan="2">
				User passwords must meet the following rules:
				<ul>
				<li>Must be a minimum of 6 characters in length</li>
				<li>Alphanumerics, underscores or hyphens only</li>
				<li>Must have uppercase, lowercase, and digit(s)</li>
				</ul>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Submit" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\UserAdmin.aspx $   $Revision: 1.2 $ -->
</asp:Content>
