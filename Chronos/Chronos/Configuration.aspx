<%@ Page Language="C#" MasterPageFile="~/Timesheet.master" AutoEventWireup="true" CodeFile="Configuration.aspx.cs" Inherits="Configuration" Title="Untitled Page" %>
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
				Company name:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:TextBox runat="server" ID="TxtCompanyName" Width="250px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight" Width="50%">
				Send method:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft" Width="50%">
				<asp:DropDownList ID="DdlSendMethod" runat="server" Width="255px">
				<asp:ListItem Text="Net.Mail" Value="Net.Mail" />
				</asp:DropDownList>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				From email address:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtFrom" Width="250px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				SMTP Server:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtSmtpServer" Width="250px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				SMTP port number:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtPortNo" Width="250px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				SMTP user name:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtUserName" Width="250px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell CssClass="FormRight">
				SMTP password:
			</asp:TableCell>
			<asp:TableCell CssClass="FormLeft">
				<asp:TextBox runat="server" ID="TxtPassword" Width="250px" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Submit" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2" CssClass="FormCenter">
				<asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Return To Main Menu" CssClass="Button" />
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
	</asp:Table>
	<asp:Table ID="TblMessage" runat="server" Width="777px" Visible="false">
	<asp:TableRow>
		<asp:TableCell CssClass="FormCenter">
			<asp:Label ID="LblMsg" runat="server" Text="LblMsg" />
		</asp:TableCell>
	</asp:TableRow>
	</asp:Table>
<!-- $Filename: D:\Inetpub\wwwroot\TimeRep\Configuration.aspx $   $Revision: 1.1 $ -->
</asp:Content>
